using System.Threading.Tasks;

namespace API.Models.Db
{
    public class RoleRepository : Repository<Role>
    {
        public RoleRepository(BlogContext db) : base(db)
        {

        }
        public new async Task Update(Role role, Role newRole)
        {
            role.Name = newRole.Name;
            role.Description = newRole.Description;
            Set.Update(role);
            await _db.SaveChangesAsync();
        }
    }
}
