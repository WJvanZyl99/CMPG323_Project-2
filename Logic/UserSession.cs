using Database.Models;
using Settings;
using System;


namespace Logic
{
    public class UserSession
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
            TimeSpan idle_max = new TimeSpan(0, UserSessionSettings.idle_max, 0);
            TimeSpan session_max = new TimeSpan(0, UserSessionSettings.session_max, 0);
            if (active 
                && (DateTime.Now - last_active_date_time) < idle_max
                && (DateTime.Now - login_date_time) < session_max)
                    return true;
            return false;
        }
    }
}
