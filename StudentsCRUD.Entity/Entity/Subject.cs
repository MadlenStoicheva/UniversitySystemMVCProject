using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsCRUD.Entity.Entity
{
    public class Subject : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }
        public int TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
