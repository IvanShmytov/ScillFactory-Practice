using System.Collections.Generic;

namespace ScillFactory_Practice.Models.Db
{
    public class Article
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public Article()
        {
            Tags = new List<Tag>();
        }
    }
}
