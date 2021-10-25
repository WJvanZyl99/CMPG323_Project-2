using System.Configuration;
using Repository.Models;

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
