using StudentsCRUD.Entity.Entity;
using StudentsCRUD.Entity.Repositories;
using StudentsCRUD.Models.LoginViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentsCRUD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
           // UserRepository repo = new UserRepository();
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

            List<Person> items = allPeople.Where(i => i.Username == model.Username && i.Password == model.Password).ToList();
                //repo.GetAll(i => i.Username == model.Username && i.Password == model.Password);

            Session["LoggedUser"] = items.Count > 0 ? items[0] : null;

            Session["UserName"] = model.Username;


            if (items.Count <= 0)
                this.ModelState.AddModelError("Failed Login", "Login failed!");

            if (!ModelState.IsValid)
                return View(model);

            return RedirectToAction("Index", "Home");

        }

        public ActionResult Logout()
        {
            System.Web.HttpContext.Current.Session["LoggedUser"] = null;
            return RedirectToAction("Index", "Home");
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}