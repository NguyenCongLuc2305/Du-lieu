using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLDA.Models;
using PagedList;
using QLDA.Businesslayer;
using System.Threading.Tasks;
using System.IO;

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
           
                string fileName = Path.GetFileNameWithoutExtension(std.ImageFile.FileName);
                string extension = Path.GetExtension(std.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                std.image = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                std.ImageFile.SaveAs(fileName);
                db.teachers.Add(std);
                db.SaveChanges();
            
            ModelState.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            var teacher = db.teachers.Where(x => x.teacher_id == id).FirstOrDefault();
            return View(teacher);
        }

        [HttpPost]
        public ActionResult Edit(teacher tch)
        {
            string fileName = Path.GetFileNameWithoutExtension(tch.ImageFile.FileName);
            string extension = Path.GetExtension(tch.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            tch.image = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            tch.ImageFile.SaveAs(fileName);
            ModelState.Clear();
            if (new TeacherBusinesslayer().Update(tch))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(tch);
            }
        }
        public JsonResult Details(string id)
        {
            var teacher = db.teachers.Where(x => x.teacher_id  == id).FirstOrDefault();
            var imageUrl = Url.Content(teacher.image);
            teacher.image = imageUrl;
            return Json(teacher, JsonRequestBehavior.AllowGet);
        }
    }
}