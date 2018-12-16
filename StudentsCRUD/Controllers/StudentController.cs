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
using StudentsCRUD.Models;

namespace StudentsCRUD.Controllers
{
    public class StudentController : Controller
    {
        
        private StudentRepository repository = new StudentRepository();

        public ActionResult Index()
        {
            List<Student> students = repository.GetAll();

            StudentListViewModel model = new StudentListViewModel();
            model.Students = students;

            return View(model);
        }

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

            Student student = new Student();
            student.FirstName = studentViewModel.FirstName.First().ToString().ToUpper() + String.Join("", studentViewModel.FirstName.Skip(1));
            student.LastName = studentViewModel.LastName.First().ToString().ToUpper() + String.Join("", studentViewModel.LastName.Skip(1)); ;
            student.Specialty = studentViewModel.Specialty;
            student.FacultyNumber = studentViewModel.FacultyNumber;
            student.Username = studentViewModel.Username;
            student.Password = studentViewModel.Password;
            student.Email = studentViewModel.Email;


            //var repository = new StudentRepository();
            repository.Insert(student);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
          //  StudentRepository repository = new StudentRepository();
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
            if (!ModelState.IsValid)
            {
                return View(studentViewModel);
            }

           // StudentRepository repository = new StudentRepository();

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

        [HttpGet]
        public ActionResult Delete(int id)
        {
          //  StudentRepository repository = new StudentRepository();
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
           // StudentRepository repository = new StudentRepository();
            if (model.Id.ToString() != String.Empty)
            {
                repository.Delete(model.Id);
            }

            return RedirectToAction("Index");
        }

    }
}
