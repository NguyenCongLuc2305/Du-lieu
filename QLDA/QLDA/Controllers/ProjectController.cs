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
    public class ProjectController : Controller
    {
        ProjectBusinesslayer project = new ProjectBusinesslayer();
        Model1 db = new Model1();
        // GET: Project
        public ActionResult Index(string SearchString, string currentFIlter, int? page)
        {
            int PageSize;
            int pageNumber;
            List<project> model = null;
            if (SearchString != null)
            {
                page = 1;
                ViewBag.currentFilter = SearchString;
                PageSize = 5;
                pageNumber = (page ?? 1);
                model = new ProjectBusinesslayer().Search(SearchString).ToList();
                return View(model.ToPagedList(pageNumber, PageSize));
            }
            else
            {
                SearchString = currentFIlter;
            }
            ViewBag.currentFilter = SearchString;
            PageSize = 5;
            pageNumber = (page ?? 1);
            model = db.projects.ToList();
            return View(model.ToPagedList(pageNumber, PageSize));
        }
        public ActionResult Create()
        {
  
           project project = new project();
            return View(project);
        }

        [HttpPost]
        public ActionResult Create(project pro)
        {
            bool isExist = project.AddProject(pro);

            if(isExist)
            {
                return View("Create", pro);
            }
           else
            {
                db.projects.Add(pro);
                 db.SaveChanges();
            return RedirectToAction("Index");
            }
           
            
        }
    
        public JsonResult listNameTeacher(string q)
        {
            var data = new ProjectBusinesslayer().listNameTeacher(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult listNameStudent(string q)
        {
            var data = new ProjectBusinesslayer().listNameStudent(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult listName(string q)
        {
            var data = new ProjectBusinesslayer().listName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Details(string id)
        {
            var project = db.projects.Where(x => x.project_id == id).FirstOrDefault();
            return Json(project, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetStudentNamebyId(string id)
        {
            string StudentName;
            student student = db.students.Where(x => x.student_id == id).FirstOrDefault();
            if (student == null)
            {
                StudentName = "null";
            }
            else
            {
            StudentName = student.name;
            }
            return Json(StudentName, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetTeacherNamebyId(string id)
        {
            string TeacherName;
            teacher teacher = db.teachers.Where(x => x.teacher_id == id).FirstOrDefault();
            if (teacher == null)
            {
                TeacherName = "null";
            }
            else
            {
                TeacherName = teacher.name;
            }
            return Json(TeacherName, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(string id)
        {
            var project = db.projects.Where(x => x.project_id == id).FirstOrDefault();
            return View(project);
        }
        [HttpPost]
        public ActionResult Edit(project pro)
        {
            var isTrue = new ProjectBusinesslayer().Update(pro);
            if(isTrue)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(pro);
            }
        }
        public JsonResult Delete(string ProjectId)
        {
            return Json(new ProjectBusinesslayer().Delete(ProjectId), JsonRequestBehavior.AllowGet);
        }
  
    }
}