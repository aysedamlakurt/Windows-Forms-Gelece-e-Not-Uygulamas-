using System;

namespace GeleceğeNot
{
    public class User
    {
        public static User myUser;
        public int Id;
        public string Username;
        public string Password;
        public User(int id, string username, string password)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
        }
    }
}
