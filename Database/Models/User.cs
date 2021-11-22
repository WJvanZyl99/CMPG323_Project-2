using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Models1
{
    public partial class User
    {
        public User()
        {
            Images = new HashSet<Image>();
        }

        public int Idusers { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
