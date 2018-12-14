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
using StudentsCRUD.Models.SubjectViewModel;

namespace StudentsCRUD.Controllers
{
    public class SubjectController : Controller
    {
        public ActionResult Index()
        {
            SubjectRepository repository = new SubjectRepository();
            List<Subject> subjects = repository.GetAll();

            SubjectListViewModel model = new SubjectListViewModel();
            model.Subjects = subjects;

            return View(model);
        }

        public ActionResult Create()
        {
            SubjectViewModel model = new SubjectViewModel();
            model.Teachers = PopulateTeacherList();
            model.Title = model.Title;
            model.Description = model.Description;
            model.Credits = model.Credits;
            model.TeacherId = model.TeacherId;

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(SubjectViewModel subjectViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(subjectViewModel);
            }

            Subject subject = new Subject();
            subject.Title = subjectViewModel.Title.First().ToString().ToUpper() + String.Join("", subjectViewModel.Title.Skip(1));
            subject.Description = subjectViewModel.Description.First().ToString().ToUpper() + String.Join("", subjectViewModel.Description.Skip(1));
            subject.TeacherId = subjectViewModel.TeacherId;
            subject.Credits = subjectViewModel.Credits;

            var repository = new SubjectRepository();
            repository.Insert(subject);

            return RedirectToAction("Index");
        }

        private List<SelectListItem> PopulateTeacherList()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            TeacherRepository teacherRepository = new TeacherRepository();
            List<Teacher> teachers = teacherRepository.GetAll();
            foreach (Teacher teacher in teachers)
            {
                SelectListItem item = new SelectListItem();
                item.Value = teacher.Id.ToString();
                item.Text = $"{teacher.FirstName} {teacher.LastName }";

                result.Add(item);
            }

            return result;
        }

        public ActionResult Edit(int? id)
        {

            SubjectRepository repository = new SubjectRepository();
            SubjectViewModel model = new SubjectViewModel();

            if (id.HasValue)
            {
                Subject subject = repository.GetById(id.Value);
                model.Id = subject.Id;
                model.Title = subject.Title;
                model.Description = subject.Description;
                model.Credits = subject.Credits;
                model.Teachers = PopulateTeacherList();
                model.TeacherId = subject.TeacherId;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(SubjectViewModel subjectViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(subjectViewModel);
            }

            SubjectRepository repository = new SubjectRepository();

            Subject subject = new Subject();
            subject.Id = subjectViewModel.Id;
            subject.Title = subjectViewModel.Title.First().ToString().ToUpper() + String.Join("", subjectViewModel.Title.Skip(1));
            subject.Description = subjectViewModel.Description.First().ToString().ToUpper() + String.Join("", subjectViewModel.Description.Skip(1));
            subject.Credits = subjectViewModel.Credits;
            subject.TeacherId = subjectViewModel.TeacherId;

            repository.Save(subject);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            SubjectRepository repository = new SubjectRepository();
            Subject subject = repository.GetById(id);

            SubjectViewModel model = new SubjectViewModel();
            model.Title = subject.Title;
            model.Description = subject.Description;
            model.Credits = subject.Credits;
            model.TeacherId = subject.TeacherId;

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(SubjectViewModel subjectViewModel)
        {
            SubjectRepository repository = new SubjectRepository();
            if (subjectViewModel.Id.ToString() != String.Empty)
            {
                repository.Delete(subjectViewModel.Id);
            }

            return RedirectToAction("Index");
        }
    }
}
