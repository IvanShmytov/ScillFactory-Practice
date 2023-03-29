using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models.Db
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task Add(T item);
        Task Update(T item, T newItem);
        Task Delete(T item);
        User GetByLogin(string login);

    }
}
