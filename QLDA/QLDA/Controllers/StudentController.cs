using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLDA.Models;


namespace QLDA.Controllers
{

    public class StudentController : Controller
    {
        public QLDAEntities db = new QLDAEntities();


        public EntityState EntitiState { get; private set; }

        // GET: Student
        public ActionResult Index()
        {
            return View(db.studens.ToList());
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Add(studen sv)
        {
            try
            {
                db.studens.Add(sv);
                db.studens.Add(sv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            return View(db.studens.Where(x => x.ID == id).FirstOrDefault());
        }
        [HttpPost]

        public ActionResult Edit(int id, studen sv)
        {
            try
            {
                db.Entry(sv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

      

    }
}