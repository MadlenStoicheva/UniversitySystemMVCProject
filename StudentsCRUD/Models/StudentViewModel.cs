using StudentsCRUD.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsCRUD.Models
{
    public class StudentViewModel: Person
    { 
        public string Specialty { get; set; }
        public int FacultyNumber { get; set; }
    }
}