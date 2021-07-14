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
        public List<string> listNameTeacher(string keyword)
        {
            return db.teachers.Where(x => x.teacher_id.Contains(keyword)).Select(x => x.teacher_id).ToList();
        }
        public List<string> listNameStudent(string keyword)
        {
            return db.students.Where(x => x.student_id.Contains(keyword)).Select(x => x.student_id).ToList();
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
        public bool Update(project pro)
        {
            try
            {
            var project = db.projects.Where(x => x.project_id == pro.project_id).FirstOrDefault();
            project.name = pro.name;
            project.start = pro.start;
            project.end = pro.end;
            project.student_id = pro.student_id;
            project.teacher_id = pro.teacher_id;
              db.SaveChanges();
            return true;
            }
            catch(Exception ex)
            {
                return false;
            }
           
        }
        public bool Delete(string ProjectId)
        {
            try
            {
                project pro = db.projects.SingleOrDefault(x => x.project_id == ProjectId);

                db.projects.Remove(pro);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool AddProject(project pro)
        {
            bool isExsit = db.projects.Any(x => x.student_id == pro.student_id);
            if(isExsit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}