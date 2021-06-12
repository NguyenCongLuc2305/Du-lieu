using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLDA.Models;
using System.Data.Entity;

namespace QLDA.Controllers
{
    public class TeacherController : Controller
    {
        QLDAEntities db = new QLDAEntities();

        // GET: Teacher
        public ActionResult Index()
        {
            return View(db.teachers.ToList());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(teacher gv)
        {
            if(ModelState.IsValid)
            {
                db.teachers.Add(gv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
             return View();
            
        }

        public ActionResult Edit(int id)
        {
            return View(db.teachers.Where(x => x.ID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id,teacher gv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gv).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        
    }
}