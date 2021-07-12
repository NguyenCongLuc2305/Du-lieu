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
    public class StudentController : Controller
    {
        Model1 db = new Model1();
        // GET: Student
        public ActionResult Index(string SearchString, string currentFIlter, int? page)
        {
            int PageSize;
            int pageNumber;
            List<student> model = null;
            if (SearchString != null)
            {
                page = 1;
                ViewBag.currentFilter = SearchString;
                PageSize = 5;
                pageNumber = (page ?? 1);
                model = new StudentBusinesslayer().Search(SearchString).ToList();
                return View(model.ToPagedList(pageNumber, PageSize));
            }
            else
            {
                SearchString = currentFIlter;

            }
            ViewBag.currentFilter = SearchString;
            PageSize = 5;
            pageNumber = (page ?? 1);
            model = db.students.ToList();

            return View(model.ToPagedList(pageNumber, PageSize));
        }
        public JsonResult listName(string q)
        {
            var data = new StudentBusinesslayer().listName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
    
        public JsonResult Delete(string studentId)
        {
            bool isDeleted = false;
            isDeleted = new StudentBusinesslayer().Delete(studentId);
            if (isDeleted)
            {
                return Json(isDeleted, JsonRequestBehavior.AllowGet);
            }
            return Json(isDeleted, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(student std)
        {
            string fileName = Path.GetFileNameWithoutExtension(std.ImageFile.FileName);
            string extension = Path.GetExtension(std.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            std.image = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            std.ImageFile.SaveAs(fileName);
            db.students.Add(std);
            db.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            var student = db.students.Where(x => x.student_id == id).FirstOrDefault();
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(student std)
        {
            string fileName = Path.GetFileNameWithoutExtension(std.ImageFile.FileName);
            string extension = Path.GetExtension(std.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            std.image = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            std.ImageFile.SaveAs(fileName);
            ModelState.Clear();
            if (new StudentBusinesslayer().Update(std))
            {
                return RedirectToAction("Index");
            }else
            {
                return View(std);
            }

        }
        public ActionResult Details(string id)
        {
            var student = db.students.Where(x => x.student_id == id).FirstOrDefault();
            var imageUrl = Url.Content(student.image);
            student.image = imageUrl;
            
            return Json(student, JsonRequestBehavior.AllowGet);
        }
     
    }
}