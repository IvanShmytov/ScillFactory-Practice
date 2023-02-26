using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScillFactory_Practice.Models.Db
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected BlogContext _db;

        public DbSet<T> Set { get; private set; }

        public Repository(BlogContext db)
        {
            _db = db;
            var set = _db.Set<T>();
            set.Load();

            Set = set;
        }

        public async Task Add(T item)
        {
            Set.Add(item);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(T item)
        {
            Set.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<T> Get(int id)
        {
            return await Set.FindAsync(id);
        }
        

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Set.ToListAsync();
        }

        public async Task Update(T item)
        {            
            Set.Update(item);
            await _db.SaveChangesAsync();
        }

        public User GetByLogin(string login)
        { 
            return Set.FirstOrDefault(x => (x as User).Login == login) as User;
        }
    }
}
