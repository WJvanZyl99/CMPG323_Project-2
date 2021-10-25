using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Models
{
    public partial class Shared
    {
        public int IdaccessControl { get; set; }
        public int? Image { get; set; }
        public int? Album { get; set; }
        public int User { get; set; }

        public virtual Album AlbumNavigation { get; set; }
        public virtual Image ImageNavigation { get; set; }
    }
}
