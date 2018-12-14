using StudentsCRUD.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentsCRUD.Models.SubjectViewModel
{
    public class SubjectViewModel: BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }
        public List<SelectListItem> Teachers { get; set; }
        public int TeacherId { get; set; }
    }
}