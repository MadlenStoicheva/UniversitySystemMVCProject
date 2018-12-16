﻿using System;
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
using StudentsCRUD.Models.AdminViewModel;

namespace StudentsCRUD.Controllers
{
    public class AdminsController : Controller
    {
        private AdminRepository repository = new AdminRepository();

        public ActionResult Index()
        {
            List<Admin> admins = repository.GetAll();

            AdminListViewModel model = new AdminListViewModel();
            model.Admins = admins;

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( AdminViewModel adminViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(adminViewModel);
            }

            Admin admin = new Admin();
            admin.FirstName = adminViewModel.FirstName.First().ToString().ToUpper() + String.Join("", adminViewModel.FirstName.Skip(1));
            admin.LastName = adminViewModel.LastName.First().ToString().ToUpper() + String.Join("", adminViewModel.LastName.Skip(1));
            admin.Email = adminViewModel.Email;
            admin.Username = adminViewModel.Username;
            admin.Password = adminViewModel.Password;

            repository.Insert(admin);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            AdminViewModel model = new AdminViewModel();

            if (id.HasValue)
            {
                Admin admin = repository.GetById(id.Value);
                model.Id = admin.Id;
                model.FirstName = admin.FirstName;
                model.LastName = admin.LastName;
                model.Email = admin.Email;
                model.Username = admin.Username;
                model.Password = admin.Password;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AdminViewModel adminViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(adminViewModel);
            }

            Admin admin = new Admin();
            admin.Id = adminViewModel.Id;
            admin.FirstName = adminViewModel.FirstName.First().ToString().ToUpper() + String.Join("", adminViewModel.FirstName.Skip(1));
            admin.LastName = adminViewModel.LastName.First().ToString().ToUpper() + String.Join("", adminViewModel.LastName.Skip(1));
            admin.Username = adminViewModel.Username;
            admin.Password = adminViewModel.Password;
            admin.Email = adminViewModel.Email;

            repository.Save(admin);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Admin admin = repository.GetById(id);

            AdminViewModel model = new AdminViewModel();
            model.FirstName = admin.FirstName;
            model.LastName = admin.LastName;
            model.Username = admin.Username;
            model.Password = admin.Password;
            model.Email = admin.Email;

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(AdminViewModel model)
        {
            if (model.Id.ToString() != String.Empty)
            {
                repository.Delete(model.Id);
            }
            return RedirectToAction("Index");
        }

    }
}
