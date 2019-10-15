using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TODOListApplication.ServiceModel.ToDo;
using TODOListApplication.Web.AccountService;

namespace TODOListApplication.Web.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            ViewBag.successMessage = "";
            return View();
        }

        /// <summary>
        /// User profile created action
        /// </summary>
        /// <param name="formCollection"></param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult Register(FormCollection formCollection)
        {  
            //Get formCollection in key parameters
            var name = formCollection.Get("firstName")??"";
            var email=formCollection.Get("email") ?? "";
            var password = formCollection.Get("password") ?? "";

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.successMessage = "Error";
                return View();
            }
            var requestRegisterRq= new TODOListApplication.ServiceModel.Account.RegisterRq();
            requestRegisterRq.Name = name;
            requestRegisterRq.Email = email;
            requestRegisterRq.Password = password;
            WCFService.AccountService accountServiceClient = new WCFService.AccountService();
            WCFService.ToDoService toDoService = new WCFService.ToDoService();
    
            var result = accountServiceClient.Register(requestRegisterRq);
             toDoService.AddToDo(new AddToDoRq { Name = "Welcome ToDo List", UserId = result.UserId});
            ViewBag.successMessage = "Success";

            return View();
        }


        /// <summary>
        /// User login action
        /// </summary>
        /// <param name="formCollection"></param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult Login(FormCollection formCollection)
        {
            //Get formCollection in key parameters
            var email = formCollection.Get("email") ?? "";
            var password = formCollection.Get("password") ?? "";

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.IsSuccess = false;
                ViewBag.Message = "Please fill in the required fields.";
                return View();
            }
            var requestRegisterRq = new TODOListApplication.ServiceModel.Account.LoginRq();
            requestRegisterRq.Email = email;
            requestRegisterRq.Password = password;
            //WCF Service call.
            WCFService.AccountService accountServiceClient = new WCFService.AccountService();
            var result = accountServiceClient.Login(requestRegisterRq);

            if (result.IsSuccess == false)
            {

                ViewBag.IsSuccess = false;
                ViewBag.Message = result.Message;
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(email, true);

                HttpCookie cookie = new HttpCookie("userId");
                cookie.Values["userId"] = result.UserId.ToString();
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);

                var session = new Session();
                session.UserId = result.UserId;
                this.Session["Session"] =(Session) session ;
                WCFService.ToDoService toDoService = new WCFService.ToDoService();
                var getAllToDo = toDoService.GetToDoList(new GetToDoListRq { UserId = session.UserId});
                var lastItem = 0;
                if (getAllToDo.ToDoList.Count > 0)
                {
                    ToDoModel first = null;
                    foreach (var model in getAllToDo.ToDoList)
                    {
                        first = model;
                        break;
                    }

                    if (first != null) lastItem = first.Id;
                }

                return RedirectToAction("GetToDo", "ToDo",new { id=lastItem });
            }
            ViewBag.IsSuccess = true;

            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }


    }
}