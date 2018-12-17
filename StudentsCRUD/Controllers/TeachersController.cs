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
using StudentsCRUD.Models.TeacherViewModel;

namespace StudentsCRUD.Controllers
{
    public class TeachersController : Controller
    {
        private TeacherRepository repository = new TeacherRepository();

        [AuthenticationFilter(RequireAdminRole = true)]
        public ActionResult Index()
        {
            List<Teacher> teachers = repository.GetAll();

            TeacherListViewModel model = new TeacherListViewModel();
            model.Teachers = teachers;

            return View(model);
        }

        [AuthenticationFilter(RequireAdminRole = true)]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TeacherViewModel teacherViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(teacherViewModel);
            }

            Helpers.ListOfAllPeople list = new Helpers.ListOfAllPeople();

            if (list.GetPeople().Where(u => u.Email == teacherViewModel.Email).Any())
            {
                ModelState.AddModelError("error_email", "This email is already taken!");
                return View();
            }
            else if (list.GetPeople().Where(u => u.Username == teacherViewModel.Username).Any())
            {

                ModelState.AddModelError("error_username", "This username is already taken!");
                return View();
            }
            else
            {
                Teacher teacher = new Teacher();
                teacher.FirstName = teacherViewModel.FirstName.First().ToString().ToUpper() + String.Join("", teacherViewModel.FirstName.Skip(1));
                teacher.LastName = teacherViewModel.LastName.First().ToString().ToUpper() + String.Join("", teacherViewModel.LastName.Skip(1));
                teacher.QualificationDegree = teacherViewModel.QualificationDegree;
                teacher.Username = teacherViewModel.Username;
                teacher.Password = teacherViewModel.Password;
                teacher.Email = teacherViewModel.Email;

                repository.Insert(teacher);
            }
            return RedirectToAction("Index");
        }

        [AuthenticationFilter(RequireAdminRole = true)]
        public ActionResult Edit(int? id)
        {
            TeacherViewModel model = new TeacherViewModel();

            if (id.HasValue)
            {
                Teacher teacher = repository.GetById(id.Value);
                model.Id = teacher.Id;
                model.FirstName = teacher.FirstName;
                model.LastName = teacher.LastName;
                model.QualificationDegree = teacher.QualificationDegree;
                model.Username = teacher.Username;
                model.Password = teacher.Password;
                model.Email = teacher.Email;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(TeacherViewModel teacherViewModel)
        {

            Teacher teacher = new Teacher();
            teacher.Id = teacherViewModel.Id;
            teacher.FirstName = teacherViewModel.FirstName.First().ToString().ToUpper() + String.Join("", teacherViewModel.FirstName.Skip(1));
            teacher.LastName = teacherViewModel.LastName.First().ToString().ToUpper() + String.Join("", teacherViewModel.LastName.Skip(1));
            teacher.QualificationDegree = teacherViewModel.QualificationDegree;
            teacher.Username = teacherViewModel.Username;
            teacher.Password = teacherViewModel.Password;
            teacher.Email = teacherViewModel.Email;

            repository.Save(teacher);

            return RedirectToAction("Index");
        }

        [AuthenticationFilter(RequireAdminRole = true)]
        public ActionResult Delete(int id)
        {
            Teacher teacher = repository.GetById(id);

            TeacherViewModel model = new TeacherViewModel();
            model.FirstName = teacher.FirstName;
            model.LastName = teacher.LastName;
            model.QualificationDegree = teacher.QualificationDegree;
            model.Username = teacher.Username;
            model.Password = teacher.Password;
            model.Email = teacher.Email;

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(TeacherViewModel model)
        {
            if (model.Id.ToString() != String.Empty)
            {
                repository.Delete(model.Id);
            }
            return RedirectToAction("Index");
        }
    }
}
