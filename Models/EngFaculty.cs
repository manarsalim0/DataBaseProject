using System;
using System.Collections.Generic;

#nullable disable

namespace ResourcesBankNew.Models
{
    public  class EngFaculty
    {
        public EngFaculty()
        {
            Majors = new HashSet<Major>();
        }

        public int FacultyId { get; set; }
        public string FacultyName { get; set; }

        public virtual ICollection<Major> Majors { get; set; }
    }
}
