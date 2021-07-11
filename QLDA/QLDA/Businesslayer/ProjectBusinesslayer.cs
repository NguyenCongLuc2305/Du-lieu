using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLDA.Models;
namespace QLDA.Businesslayer
{
    public class ProjectBusinesslayer
    {
        Model1 db = null;
        public ProjectBusinesslayer()
        {
            db = new Model1();
        }
        public List<string> listName(string keyword)
        {
            return db.projects.Where(x => x.name.Contains(keyword)).Select(x => x.name).ToList();
        }
        public List<project> Search(string keyword)
        {
            var model = db.projects.Where(x => x.name.Contains(keyword)).OrderByDescending(x => x.name).ToList();
            return model;
        }
    }
}