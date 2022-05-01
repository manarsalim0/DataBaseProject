using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcesBankNew.Models
{
    public class selecitListModel
    {
        public List<EngFaculty> engFaculties { get; set; }
        public List<Level> level { get; set; }
        public List<Course> courses { get; set; }
        public List<Major> major { get; set; }
        public List<searchM> searchM { get; set; }
    }
}
