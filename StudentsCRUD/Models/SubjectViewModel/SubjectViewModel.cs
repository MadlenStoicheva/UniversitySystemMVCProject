using StudentsCRUD.Entity.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentsCRUD.Models.SubjectViewModel
{
    public class SubjectViewModel: BaseEntity
    {
        [Required(ErrorMessage = "Please enter title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter description.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter credits.")]
        public int Credits { get; set; }

        public List<SelectListItem> Teachers { get; set; }
        public int TeacherId { get; set; }
    }
}