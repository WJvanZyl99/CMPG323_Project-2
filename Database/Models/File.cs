using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Models
{
    public partial class File
    {
        public File()
        {
            Images = new HashSet<Image>();
        }

        public int Idfiles { get; set; }
        public string Name { get; set; }
        public int Directory { get; set; }
        public DateTime DateUploaded { get; set; }
        public int? User { get; set; }

        public virtual Directory DirectoryNavigation { get; set; }
        public virtual User UserNavigation { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
