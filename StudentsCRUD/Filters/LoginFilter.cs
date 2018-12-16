using StudentsCRUD.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsCRUD.Filters
{
    public static class LoginFilter
    {
        public static int IsAdmin()
        {
            Person user = (Person)HttpContext.Current.Session["LoggedUser"];

            if (user != null)
            {
                if (user is Admin)
                {
                    return 0;
                }
                else if (user is Teacher)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }

            }
            else
            {
                return -1;
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
