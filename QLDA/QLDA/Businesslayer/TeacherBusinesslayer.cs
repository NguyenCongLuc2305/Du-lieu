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
        public bool Update(teacher std)
        {
            try
            {
                teacher refteacher = (teacher)db.teachers.Where(x => x.teacher_id == std.teacher_id);
                refteacher.gender = std.gender;
                refteacher.phone = std.phone;
                refteacher.image = std.image;
                refteacher.name = std.name;
                refteacher.address = std.address;
                refteacher.age = std.age;
                refteacher.faculty = std.faculty;
                refteacher.subject = std.subject;
                refteacher.education = std.education;
                refteacher.projects = std.projects;
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