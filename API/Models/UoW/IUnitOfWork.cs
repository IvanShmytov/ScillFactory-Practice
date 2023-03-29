using API.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.UoW
{
    public interface IUnitOfWork: IDisposable
    {
        int SaveChanges(bool ensureAutoHistory = false);

        IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = true) where TEntity : class;
    }
}
