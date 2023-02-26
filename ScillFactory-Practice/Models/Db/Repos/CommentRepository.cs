namespace ScillFactory_Practice.Models.Db
{
    public class CommentRepository : Repository<Comment>
    {
        public CommentRepository(BlogContext db): base(db)
        {

        }
    }
}
