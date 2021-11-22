using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Models1
{
    public partial class LogCategory
    {
        public LogCategory()
        {
            InverseParentNavigation = new HashSet<LogCategory>();
            Logs = new HashSet<Log>();
        }

        public int IdlogCategories { get; set; }
        public int? Parent { get; set; }
        public string Name { get; set; }

        public virtual LogCategory ParentNavigation { get; set; }
        public virtual ICollection<LogCategory> InverseParentNavigation { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
    }
}
