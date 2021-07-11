using System;
using System.Collections.Generic;
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
    }
}