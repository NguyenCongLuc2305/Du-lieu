using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using QLDA.Businesslayer;
using QLDA.Models;

namespace QLDA.Controllers
{
    public class TeacherController : Controller
    {
        Model1 db = new Model1();
        // GET: Teacher
        public ActionResult Index(string SearchString, string currentFIlter, int? page)
        {
            int PageSize;
            int pageNumber;
            List<teacher> model = null;
            if (SearchString != null)
            {
                page = 1;
                ViewBag.currentFilter = SearchString;
                PageSize = 5;
                pageNumber = (page ?? 1);
                model = new TeacherBusinesslayer().Search(SearchString).ToList();
                return View(model.ToPagedList(pageNumber, PageSize));
            }
            else
            {
                SearchString = currentFIlter;

            }
            ViewBag.currentFilter = SearchString;
            PageSize = 5;
            pageNumber = (page ?? 1);
            model = db.teachers.ToList();

            return View(model.ToPagedList(pageNumber, PageSize));
        }
        public JsonResult listName(string q)
        {
            var data = new TeacherBusinesslayer().listName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(teacher std)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(std.ImageFile.FileName);
                string extension = Path.GetExtension(std.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                std.image = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                object p = std.ImageFile.SaveAs(fileName);
                db.teachers.Add(std);
                db.SaveChanges();
            }
            ModelState.Clear();
            return RedirectToAction("Index");
        }
    }
}