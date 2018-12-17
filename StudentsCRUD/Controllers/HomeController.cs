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
            Helpers.ListOfAllPeople list = new Helpers.ListOfAllPeople();
            List<Person> items = list.GetPeople().Where(i => i.Username == model.Username && i.Password == model.Password).ToList();

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