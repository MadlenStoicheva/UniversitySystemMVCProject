using StudentsCRUD.Entity.Entity;
using StudentsCRUD.Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsCRUD.Helpers
{
    public class ListOfAllPeople
    {
        public List<Person> GetPeople()
        {
            List<Person> allPeople = new List<Person>();

            AdminRepository adminRepository = new AdminRepository();
            List<Admin> admins = adminRepository.GetAll();
            foreach (var item in admins)
            {
                allPeople.Add(item);
            }

            TeacherRepository teacherRepository = new TeacherRepository();
            List<Teacher> teachers = teacherRepository.GetAll();
            foreach (var item in teachers)
            {
                allPeople.Add(item);
            }

            StudentRepository studentRepository = new StudentRepository();
            List<Student> students = studentRepository.GetAll();
            foreach (var item in students)
            {
                allPeople.Add(item);
            }

            return allPeople;
        }
    }
}