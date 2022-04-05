using NEWTODOAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace NEWTODOAPP.Controllers
{
    public class AdminController : Controller
    {
        Service service = new Service();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login logg)
        {
            string res = service.Login(logg);
            return Json(res,JsonRequestBehavior.AllowGet);
        }

        public ActionResult Register()
        {
            return View();
        }
        
       [HttpPost]
        public ActionResult Register(Register regg)
        {
            string response = service.Register(regg);
            return Json(response,JsonRequestBehavior.AllowGet);
        }

      
        public ActionResult Todoitem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Todoitem(Todo todo)
        {
            return View();
        }
    } 
}
