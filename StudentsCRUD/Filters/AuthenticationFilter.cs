using StudentsCRUD.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudentsCRUD.Filters
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public bool RequireAdminRole { get; set; }

        public AuthenticationFilter()
        {
            RequireAdminRole = false;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Person loggedUser = (Person)HttpContext.Current.Session["LoggedUser"];

            if (loggedUser == null || RequireAdminRole == false)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index" }));
                return;
            }
            base.OnActionExecuting(filterContext);

            Helpers.ListOfAllPeople listOfAllPeople = new Helpers.ListOfAllPeople();
            Person loggedPerson = listOfAllPeople.GetPeople().Find(X => X.Id == loggedUser.Id);

            if (RequireAdminRole == true && !(loggedUser is Admin))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index" }));
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}