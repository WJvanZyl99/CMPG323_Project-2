using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public partial class Log
    {
        public int Idlog { get; set; }
        public DateTime Date { get; set; }
        public int? Category { get; set; }
        public string Description { get; set; }

        public virtual LogCategory CategoryNavigation { get; set; }
    }
}
