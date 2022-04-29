using System;
using System.Collections.Generic;

#nullable disable

namespace ResourcesBankNew.Models
{
    public partial class Material
    {
        public int MaterialId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
