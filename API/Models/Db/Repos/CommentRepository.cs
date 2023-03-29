using System.Threading.Tasks;

namespace API.Models.Db
{
    public class CommentRepository : Repository<Comment>
    {
        public CommentRepository(BlogContext db): base(db)
        {

        }
        public new async Task Update(Comment comment, Comment newComment)
        {
            comment.Text = newComment.Text;
            Set.Update(comment);
            await _db.SaveChangesAsync();
        }
    }
}
