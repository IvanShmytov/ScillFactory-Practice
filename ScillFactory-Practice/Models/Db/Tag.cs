using System.Collections.Generic;

namespace ScillFactory_Practice.Models.Db
{
    public class Tag
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
        public Tag()
        {
            Articles = new List<Article>();
        }
    }
}
