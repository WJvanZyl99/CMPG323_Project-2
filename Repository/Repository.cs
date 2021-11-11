using System.Configuration;
using Database.Models;

namespace Repository
{
    class Repository
    {
        Cmpg323Context DB;

        public Repository()
        {
            DB = new Cmpg323Context(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            DB.Database.EnsureCreated();
            DB.SaveChanges();
        }

    }
}
