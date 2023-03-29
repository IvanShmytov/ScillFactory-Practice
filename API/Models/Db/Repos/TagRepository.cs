using System.Threading.Tasks;

namespace API.Models.Db
{
    public class TagRepository : Repository<Tag>
    {
        public TagRepository(BlogContext db): base(db)
        {
        }

        public new async Task Update(Tag tag, Tag newTag)
        {
            tag.Name = newTag.Name;
            Set.Update(tag);
            await _db.SaveChangesAsync();
        }
    }
}
