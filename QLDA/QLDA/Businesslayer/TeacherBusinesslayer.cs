using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLDA.Models;

namespace QLDA.Businesslayer
{
    public class TeacherBusinesslayer
    {
        Model1 db = null;
        public TeacherBusinesslayer()
        {
            db = new Model1();
        }
        public List<string> listName(string keyword)
        {
            return db.teachers.Where(x => x.name.Contains(keyword)).Select(x => x.name).ToList();
        }
        public List<teacher> Search(string keyword)
        {
            var model = db.teachers.Where(x => x.name.Contains(keyword)).OrderByDescending(x => x.name).ToList();
            return model;
        }
        public bool Delete(string teacherId)
        {
            try
            {
                teacher std = db.teachers.SingleOrDefault(x => x.teacher_id == teacherId);
                db.teachers.Remove(std);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool Update(teacher tch)
        {
            try
            {
                teacher refteacher = db.teachers.Where(x => x.teacher_id == tch.teacher_id).FirstOrDefault();
                refteacher.gender = tch.gender;
                refteacher.phone = tch.phone;
                refteacher.image = tch.image;
                refteacher.name = tch.name;
                refteacher.address = tch.address;
                refteacher.age = tch.age;
                refteacher.faculty = tch.faculty;
                refteacher.subject = tch.subject;
                refteacher.education = tch.education;
                refteacher.projects = tch.projects;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}