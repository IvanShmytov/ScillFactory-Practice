namespace ScillFactory_Practice.Models.Db
{
    public class RoleRepository : Repository<Role>
    {
        public RoleRepository(BlogContext db) : base(db)
        {

        }
    }
}
