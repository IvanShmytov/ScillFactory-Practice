using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScillFactory_Practice.Models.Db
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task Add(T item);
        Task Update(T item);
        Task Delete(T item);
        User GetByLogin(string login);

    }
}
