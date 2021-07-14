using QLDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLDA.Businesslayer
{
    public class UserBusinessLayer
    {
        Model1 db = new Model1();
        public bool Login(string Name, string Password)
        {
            if (db.users.Any(x => x.name == Name && x.password == Password))
            {
                return true;
            }
            else
                return false;
        }
        public users getUserByID(String Name)
        {
            return db.users.SingleOrDefault(x => x.name == Name);
        }
    }
}