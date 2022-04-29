using System;
using System.Collections.Generic;

#nullable disable

namespace ResourcesBankNew.Models
{
    public partial class Level
    {
        public Level()
        {
            Courses = new HashSet<Course>();
        }

        public int LevelId { get; set; }
        public int LevelNum { get; set; }
        public int TermNum { get; set; }
        public int TakenYear { get; set; }
        public string RootLink { get; set; }
        public int MajorId { get; set; }

        public virtual Major Major { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
