using System.Collections.Generic;

namespace ScillFactory_Practice.Models.Db
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public ICollection<Role> Roles { get; set; }
        public User()
        {
            Roles = new List<Role>();
        }
    }
}
