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
               student student = db.students.SingleOrDefault(x => x.student_id == studentId);
                db.students.Remove(student);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
        public bool Update(student std)
        {
            try
            {

                student refstudent = db.students.Where(x => x.student_id == std.student_id).FirstOrDefault();
                refstudent.name = std.name;
                refstudent.address = std.address;
                refstudent.age = std.age;
                refstudent.email = std.email;
                refstudent.faculty = std.faculty;
                refstudent.gender = std.gender;
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