using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsCRUD.Entity.Entity
{
    public class Student : Person
    {
        public string Specialty { get; set; }
        public int FacultyNumber { get; set; }
    }
}
