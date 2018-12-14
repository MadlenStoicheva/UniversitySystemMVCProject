using StudentsCRUD.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentsCRUD.Models.TeacherViewModel
{
    public class TeacherViewModel : Person
    {
        public string QualificationDegree { get; set; }
      //  public List<SelectListItem> QualificationDegree { get; set; }
      //  public int QualificationDegreeId { get; set; }
    }
}