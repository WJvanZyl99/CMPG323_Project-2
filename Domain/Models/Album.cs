using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Album
    {
        public Album()
        {
            Shareds = new HashSet<Shared>();
        }

        public int Idalbums { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public int User { get; set; }
        public string Caption { get; set; }

        public virtual ICollection<Shared> Shareds { get; set; }
    }
}
