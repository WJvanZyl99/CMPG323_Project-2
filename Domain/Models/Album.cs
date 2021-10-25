﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class Album
    {
        public Album()
        {
            Shared = new HashSet<Shared>();
        }

        public int Idalbums { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public int User { get; set; }
        public string Caption { get; set; }

        public virtual ICollection<Shared> Shared { get; set; }
    }
}