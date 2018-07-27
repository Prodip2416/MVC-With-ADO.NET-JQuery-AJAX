using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullCRUDWithJquery.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department{ get; set; } 
    }
}