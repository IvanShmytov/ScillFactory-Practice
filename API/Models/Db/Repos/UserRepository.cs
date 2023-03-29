using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Db
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(BlogContext db)
      : base(db)
        {

        }
        public new async Task Add(User user)
        {
            user.Roles.Add(new Role { ID = 1, Name = "Admin" });
            Set.Add(user);
            await _db.SaveChangesAsync();
        }
        public new async Task Update(User user, User newUser)
        {
            user.Password = newUser.Password;
            user.Login = newUser.Login;
            user.Age = newUser.Age;
            user.FirstName = newUser.FirstName;
            user.LastName = newUser.LastName;
            user.Role = newUser.Role;
            Set.Update(user);
            await _db.SaveChangesAsync();
        }
        public new User GetByLogin(string login)
        {
            return Set.FirstOrDefault(x => x.Login == login);
        }
    }
}
