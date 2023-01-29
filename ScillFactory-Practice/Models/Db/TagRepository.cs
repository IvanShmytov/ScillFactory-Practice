namespace ScillFactory_Practice.Models.Db
{
    public class TagRepository : Repository<Tag>
    {
        public TagRepository(BlogContext db): base(db)
        {

        }
    }
}
