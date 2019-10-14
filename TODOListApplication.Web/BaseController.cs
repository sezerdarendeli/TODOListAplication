using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace TODOListApplication.Web
{
    public class BaseController : Controller
    {

        /// 

        /// A session object that can/will be shared between all controllers that inherit from
        /// this base.
        /// 
        public Session GetSession
        {
            get
            {
                var session = new Session();
                session = (Session)System.Web.HttpContext.Current.Session["Session"];
                if (session == null)//if not have cookie user Id get cooike
                {
                     session = new Session();
                    HttpCookie cookie = Request.Cookies["userId"];
                    session.UserId = Convert.ToInt32(cookie.Values["userId"]);
                }
                return session;
            }
            set
            {
            }

        }
        public System.Web.SessionState.HttpSessionState Session
        {
            get
            {
                return System.Web.HttpContext.Current.Session;
            }
            set
            {
            }
        }


    }
}