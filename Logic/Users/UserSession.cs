using Database.Models;
using System;
using System.Configuration;

namespace Logic.Users
{
    class UserSession
    {
        private DateTime login_date_time;
        private DateTime last_active_date_time;
        private bool active = false;

        public UserSession(User user, string password)
        {
            Password pass = new Password(password);
            if(user.Password == pass.get_encoded_password())
            {
                this.login_date_time = this.last_active_date_time = DateTime.Now;
                this.active = true;
            }
            else
                this.active = false;
        }

        public bool is_active()
        {
            TimeSpan idle_max = new TimeSpan(0, Int32.Parse(ConfigurationManager.AppSettings["SessionUptimeLimts:IdleMax"]), 0);
            TimeSpan session_max = new TimeSpan(0, Int32.Parse(ConfigurationManager.AppSettings["SessionUptimeLimts:SessionMax"]), 0);
            if (active 
                && (DateTime.Now - last_active_date_time) < idle_max
                && (DateTime.Now - login_date_time) < session_max)
                    return true;
            return false;
        }
    }
}
