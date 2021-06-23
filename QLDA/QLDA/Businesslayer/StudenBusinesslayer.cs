using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using QLDA.Models;

namespace QLDA.Businesslayer
{
    public class StudentBusinesslayer
    {
        Model1 db = null;
        public StudentBusinesslayer()
        {
            db = new Model1();
        }
        public List<string> listName(string keyword)
        {
            return db.students.Where(x => x.name.Contains(keyword)).Select(x => x.name).ToList();
        }
        public List<student> Search(string keyword)
        {
            var model = db.students.Where(x => x.name.Contains(keyword)).OrderByDescending(x => x.name).ToList();
            return model;
        }
        public bool Delete(string studentId)
        {
            try
            {
                student std = db.students.SingleOrDefault(x => x.student_id == studentId);
                db.students.Remove(std);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool Update(student std)
        {
            try
            {

                student refstudent = (student)db.students.Where(x => x.student_id == std.student_id);
                refstudent.name = std.name;
                refstudent.address = std.address;
                refstudent.age = std.age;
                refstudent.email = std.email;
                refstudent.faculty = std.faculty;
                refstudent.gender = std.gender;
                refstudent.image = std.image;
                refstudent.phone = std.phone;
                refstudent._class = std._class;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
          
        }
    }
}