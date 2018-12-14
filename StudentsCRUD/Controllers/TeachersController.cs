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
using StudentsCRUD.Models.TeacherViewModel;

namespace StudentsCRUD.Controllers
{
    public class TeachersController : Controller
    {
        public ActionResult Index()
        {
            TeacherRepository repository = new TeacherRepository();
            List<Teacher> teachers = repository.GetAll();

            TeacherListViewModel model = new TeacherListViewModel();
            model.Teachers = teachers;

            return View(model);
        }

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

            Teacher teacher = new Teacher();
            teacher.FirstName = teacherViewModel.FirstName.First().ToString().ToUpper() + String.Join("", teacherViewModel.FirstName.Skip(1));
            teacher.LastName = teacherViewModel.LastName.First().ToString().ToUpper() + String.Join("", teacherViewModel.LastName.Skip(1));
            teacher.QualificationDegree = teacherViewModel.QualificationDegree;
           
            var repository = new TeacherRepository();
            repository.Insert(teacher);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            TeacherRepository repository = new TeacherRepository();
            TeacherViewModel model = new TeacherViewModel();

            if (id.HasValue)
            {
                Teacher teacher = repository.GetById(id.Value);
                model.Id = teacher.Id;
                model.FirstName = teacher.FirstName;
                model.LastName = teacher.LastName;
                model.QualificationDegree = teacher.QualificationDegree;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(TeacherViewModel teacherViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(teacherViewModel);
            }

            TeacherRepository repository = new TeacherRepository();

            Teacher teacher = new Teacher();
            teacher.Id = teacherViewModel.Id;
            teacher.FirstName = teacherViewModel.FirstName.First().ToString().ToUpper() + String.Join("", teacherViewModel.FirstName.Skip(1));
            teacher.LastName = teacherViewModel.LastName.First().ToString().ToUpper() + String.Join("", teacherViewModel.LastName.Skip(1));
            teacher.QualificationDegree = teacherViewModel.QualificationDegree;

            repository.Save(teacher);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            TeacherRepository repository = new TeacherRepository();
            Teacher teacher = repository.GetById(id);

            TeacherViewModel model = new TeacherViewModel();
            model.FirstName = teacher.FirstName;
            model.LastName = teacher.LastName;
            model.QualificationDegree = teacher.QualificationDegree;

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(TeacherViewModel model)
        {
            TeacherRepository repository = new TeacherRepository();
            if (model.Id.ToString() != String.Empty)
            {
                repository.Delete(model.Id);
            }
            return RedirectToAction("Index");
        }
    }
}
