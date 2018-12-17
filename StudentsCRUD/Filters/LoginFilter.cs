using StudentsCRUD.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsCRUD.Filters
{
    public static class LoginFilter
    {
        public static Enums.Enums GetRole()
        {
            Person user = (Person)HttpContext.Current.Session["LoggedUser"];

            if (user != null)
            {
                if (user is Admin)
                {
                    return Enums.Enums.Admin;
                }
                else if (user is Teacher)
                {
                    return Enums.Enums.Teacher;
                }
                else
                {
                    return Enums.Enums.Student;
                }
            }
            else
            {
                return Enums.Enums.NoUser;
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
    }
}
