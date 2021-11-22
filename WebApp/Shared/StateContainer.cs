using Microsoft.AspNetCore.Http;
using Database.Models;

namespace WebApp.Shared
{
    public class StateContainer
    {
        public ISession session { get; set; }
        public User user { get; set; }
    }
}
