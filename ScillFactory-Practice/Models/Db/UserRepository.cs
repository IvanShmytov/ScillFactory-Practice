using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ScillFactory_Practice.Models.Db
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
        public User GetByLogin(string login)
        {
            return Set.FirstOrDefault(x => x.Login == login);
        }
    }
}
