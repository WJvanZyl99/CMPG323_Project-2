using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Repository
{
    class Repository
    {
        cmpg323Context DB;

        public Repository()
        {
            DB = new cmpg323Context(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            DB.Database.EnsureCreated();
            DB.SaveChanges();
        }

    }
}
