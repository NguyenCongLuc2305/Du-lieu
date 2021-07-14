using QLDA.Businesslayer;
using QLDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDA.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
   
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(users model)
        {
            if (ModelState.IsValid)
            {
                var userbusinesslayer = new UserBusinessLayer();
                var result = userbusinesslayer.Login(model.name, model.password);
                if (result)
                {
                    var user = userbusinesslayer.getUserByID(model.name);
                    var userSession = new users();
                    userSession.id = user.id;
                    userSession.name = user.name;
                    Session.Add(SessionString.USER_SESSION,userSession);
                    return RedirectToAction("Index", "Project");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không chính xác");
                }


            }

            return View();
        }
    }
}