using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScillFactory_Practice.Models.Db
{
    public class ArticlesRepository : Repository<Article>
    {
        public ArticlesRepository(BlogContext db)
      : base(db)
        {

        }
        public IEnumerable<Article> GetArticlesByAuthorId(int userId)
        {
            var articles = Set.AsEnumerable().Where(x => x.UserID == userId);

            return articles.ToList();
        }
    }
}
