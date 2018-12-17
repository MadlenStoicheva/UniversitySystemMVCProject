using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentsCRUD.Entity.Context;
using StudentsCRUD.Entity.Entity;
using StudentsCRUD.Entity.Repositories;
using StudentsCRUD.Filters;
using StudentsCRUD.Models;

namespace StudentsCRUD.Controllers
{
    public class StudentController : Controller
    {
        private StudentRepository repository = new StudentRepository();


        [AuthenticationFilter(RequireAdminRole = true)]
        public ActionResult Index()
        {
            List<Student> students = repository.GetAll();

            StudentListViewModel model = new StudentListViewModel();
            model.Students = students;

            return View(model);
        }

        [AuthenticationFilter(RequireAdminRole = true)]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentViewModel studentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(studentViewModel);
            }

            Helpers.ListOfAllPeople list = new Helpers.ListOfAllPeople();

            if (list.GetPeople().Where(u => u.Email == studentViewModel.Email).Any())
            {
                ModelState.AddModelError("error_email", "This email is already taken!");
                return View();
            }
            else if (list.GetPeople().Where(u => u.Username == studentViewModel.Username).Any())
            {

                ModelState.AddModelError("error_username", "This username is already taken!");
                return View();
            }
            else
            {
                Student student = new Student();
                student.FirstName = studentViewModel.FirstName.First().ToString().ToUpper() + String.Join("", studentViewModel.FirstName.Skip(1));
                student.LastName = studentViewModel.LastName.First().ToString().ToUpper() + String.Join("", studentViewModel.LastName.Skip(1)); ;
                student.Specialty = studentViewModel.Specialty;
                student.FacultyNumber = studentViewModel.FacultyNumber;
                student.Username = studentViewModel.Username;
                student.Password = studentViewModel.Password;
                student.Email = studentViewModel.Email;

                repository.Insert(student);
            }
            return RedirectToAction("Index");
        }

        [AuthenticationFilter(RequireAdminRole = true)]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            StudentViewModel model = new StudentViewModel();

            if (id.HasValue)
            {
                Student student = repository.GetById(id.Value);
                model.Id = student.Id;
                model.FirstName = student.FirstName;
                model.LastName = student.LastName;
                model.Specialty = student.Specialty;
                model.FacultyNumber = student.FacultyNumber;
                model.Username = student.Username;
                model.Password = student.Password;
                model.Email = student.Email;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(StudentViewModel studentViewModel)
        {

            Student student = new Student();
            student.Id = studentViewModel.Id;
            student.FirstName = studentViewModel.FirstName.First().ToString().ToUpper() + String.Join("", studentViewModel.FirstName.Skip(1));
            student.LastName = studentViewModel.LastName.First().ToString().ToUpper() + String.Join("", studentViewModel.LastName.Skip(1)); ;
            student.Specialty = studentViewModel.Specialty;
            student.FacultyNumber = studentViewModel.FacultyNumber;
            student.Username = studentViewModel.Username;
            student.Password = studentViewModel.Password;
            student.Email = studentViewModel.Email;

            repository.Save(student);

            return RedirectToAction("Index");
        }

        [AuthenticationFilter(RequireAdminRole = true)]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Student student = repository.GetById(id);

            StudentViewModel model = new StudentViewModel();
            model.FirstName = student.FirstName;
            model.LastName = student.LastName;
            model.Specialty = student.Specialty;
            model.FacultyNumber = student.FacultyNumber;
            model.Username = student.Username;
            model.Password = student.Password;
            model.Email = student.Email;

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(StudentViewModel model)
        {
            if (model.Id.ToString() != String.Empty)
            {
                repository.Delete(model.Id);
            }

            return RedirectToAction("Index");
        }

    }
}
