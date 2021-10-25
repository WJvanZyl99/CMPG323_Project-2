using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Directory
    {
        public Directory()
        {
            Files = new HashSet<File>();
            InverseParentNavigation = new HashSet<Directory>();
        }

        public int Iddirectories { get; set; }
        public int? Parent { get; set; }
        public string Name { get; set; }

        public virtual Directory ParentNavigation { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<Directory> InverseParentNavigation { get; set; }
    }
}
