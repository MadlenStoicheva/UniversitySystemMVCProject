using StudentsCRUD.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentsCRUD.Entity.Context
{
    public class SchoolDBContext: DbContext
    {
        public SchoolDBContext()
           : base("StudentSystemDB")
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Subject> Subjects { get; set; }

    }
}