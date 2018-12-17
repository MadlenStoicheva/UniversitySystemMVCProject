using StudentsCRUD.Entity.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentsCRUD.Models.TeacherViewModel
{
    public class TeacherViewModel : BaseEntity
    {
        [Required(ErrorMessage = "Please enter first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter username.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter Faculty Qualification Degree.")]
        public string QualificationDegree { get; set; }
    
    }
}