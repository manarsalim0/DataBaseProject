using System;
using System.Collections.Generic;

#nullable disable

namespace ResourcesBankNew.Models
{
    public  class Major
    {
        public Major()
        {
            Levels = new HashSet<Level>();
        }

        public int MajorId { get; set; }
        public string Name { get; set; }
        public string RootLink { get; set; }
        public int FacultyId { get; set; }

        public virtual EngFaculty Faculty { get; set; }
        public virtual ICollection<Level> Levels { get; set; }
    }
}
