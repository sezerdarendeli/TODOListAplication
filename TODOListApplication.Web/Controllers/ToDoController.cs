using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using TODOListApplication.ServiceModel.ToDo;
using TODOListApplication.Web.Models;

namespace TODOListApplication.Web.Controllers
{
    public class ToDoController : BaseController
    {
        // GET:
        public ActionResult Add()
        {
            var viewModel = new AddNewViewModel();
            LayoutModel layoutModel = new LayoutModel<AddNewViewModel>(pageModel: viewModel, title: "Test", toDoId: 1);
            return View(layoutModel);
        }

        [HttpPost]
        public ActionResult Add(FormCollection formCollection)
        {
            var userId = GetSession.UserId;
            var toDoService = new WCFService.ToDoService();
            var request = new AddToDoRq { Name = formCollection.Get("name") ?? "", UserId = userId };
            var result = toDoService.AddToDo(request);
            ViewBag.RedirectToDoId = result.ToDoId;
            return RedirectToAction("GetToDo", new { id = result.ToDoId });
        }

        [HttpPost]
        public JsonResult AddToDoTask(AddToDoTaskRq request)
        {
            var userId = GetSession.UserId;
            request.ExpireDateTime = Convert.ToDateTime(request.ExpireDateTimeString);
            var toDoService = new WCFService.ToDoService();


            toDoService.AddToDoTask(request);
            return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetToDo(int id)
        {


            var viewModel = new ToDoViewModel();
            ViewBag.ToDoId = id;
            ViewData.Add("selecteToDo",id);
            var toDoService = new WCFService.ToDoService();
            var request = new GetToDoRq();
            request.Id = id;
            var todoResponse = toDoService.GetToDoById(request);
            ViewBag.ToDoName = todoResponse.Name;
            viewModel.ToDoTaskList = new List<ToDoTaskViewModel>();
            foreach (var item in todoResponse.ToDoTaskList)
            {
                viewModel.ToDoTaskList.Add(new ToDoTaskViewModel
                {
                    Id = item.Id,
                    ToDoId = item.Id,
                    TaskName = item.TaskName,
                    Completed = item.Completed,
                    Description = item.Description,
                    ExpireDateTime = item.ExpireDateTime
                });
            }
            viewModel.Name = todoResponse.Name;
            viewModel.Id = id;
            ViewBag.ToDoName = todoResponse.Name;
            LayoutModel layoutModel = new LayoutModel<ToDoViewModel>(viewModel, ViewBag.ToDoName, viewModel.Id);
            return View(layoutModel);
        }

        [HttpPost]
        public ActionResult GetToDoPage(int id , string filterText =null)
        {
         
            var viewModel = new ToDoViewModel();
            var toDoService = new WCFService.ToDoService();
            var request = new GetToDoRq();
            if (!string.IsNullOrEmpty(filterText) && filterText.Equals("completedTask"))
            {
                request.CompletedTask =  true;
            }
            else if (!string.IsNullOrEmpty(filterText) && filterText.Equals("expiredTask"))
            {
                request.ExpireDate = true;
            }
            request.Id = id;
          
            var todoResponse = toDoService.GetToDoById(request);
            viewModel.Id = todoResponse.Id;
            viewModel.Name = todoResponse.Name;
            viewModel.ToDoTaskList = new List<ToDoTaskViewModel>();
            foreach (var item in todoResponse.ToDoTaskList)
            {
                viewModel.ToDoTaskList.Add(new ToDoTaskViewModel
                {
                    Id = item.Id,
                    ToDoId =item.Id,
                    TaskName = item.TaskName,
                    Completed = item.Completed,
                    Description = item.Description,
                    ExpireDateTime = item.ExpireDateTime
                });
            }

            ViewBag.ToDoName = todoResponse.Name;
            ViewBag.ToDoId = id;
            LayoutModel layoutModel = new LayoutModel<ToDoViewModel>(viewModel, ViewBag.ToDoName, viewModel.Id);
            return PartialView("_ToDoList", viewModel);
        }

        [HttpPost]
        public JsonResult DeleteToDoTask(int id)
        {
            var toDoService = new WCFService.ToDoService();
            var todoResponse = toDoService.DeleteTodoTaskById(id);
            return Json(todoResponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetToDoList()
        {
            var userId = GetSession.UserId;
            var viewModel = new ToDoListViewModel();
            var toDoService = new WCFService.ToDoService();
            var todoResponse = toDoService.GetToDoList(new GetToDoListRq { UserId = userId });
            viewModel.ToDoList = new List<TodoVModel>();

            foreach (var item in todoResponse.ToDoList)
            {
                viewModel.ToDoList.Add(new TodoVModel { Id = item.Id, Name = item.Name });
            }

            return PartialView("_GetToDoList", viewModel);

        }
    }
}