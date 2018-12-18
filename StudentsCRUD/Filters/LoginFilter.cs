using StudentsCRUD.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsCRUD.Filters
{
    public static class LoginFilter
    {
        public static Enums.UserRoles GetRole()
        {
            Person user = (Person)HttpContext.Current.Session["LoggedUser"];

            if (user != null)
            {
                if (user is Admin)
                {
                    return Enums.UserRoles.Admin;
                }
                else if (user is Teacher)
                {
                    return Enums.UserRoles.Teacher;
                }
                else
                {
                    return Enums.UserRoles.Student;
                }
            }
            else
            {
                return Enums.UserRoles.NoUser;
            }
        }

        public static bool IsNotLogedUser()
        {
            if (HttpContext.Current.Session["LoggedUser"] == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int GetUserId()
        {
            Person person = (Person)HttpContext.Current.Session["LoggedUser"];

            return person.Id;
        }
    }
}
