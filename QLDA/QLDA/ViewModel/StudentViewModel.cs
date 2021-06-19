using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLDA.Models;
namespace QLDA.ViewModel
{
    public class StudentViewModel
    {
        public List<student> student {get; set;}
        public project project { get; set; }
    }
}