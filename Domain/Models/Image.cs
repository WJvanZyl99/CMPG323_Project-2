using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Image
    {
        public Image()
        {
            Shareds = new HashSet<Shared>();
        }

        public int Idimages { get; set; }
        public int File { get; set; }
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Location { get; set; }
        public int User { get; set; }
        public string Caption { get; set; }

        public virtual File FileNavigation { get; set; }
        public virtual User UserNavigation { get; set; }
        public virtual ICollection<Shared> Shareds { get; set; }
    }
}
