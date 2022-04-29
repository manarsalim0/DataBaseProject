using System;
using System.Collections.Generic;

#nullable disable

namespace ResourcesBankNew.Models
{
    public partial class Course
    {
        public Course()
        {
            Materials = new HashSet<Material>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string FolderLink { get; set; }
        public int LevelId { get; set; }

        public virtual Level Level { get; set; }
        public virtual ICollection<Material> Materials { get; set; }
    }
}
