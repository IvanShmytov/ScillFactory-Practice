﻿using Microsoft.EntityFrameworkCore.Infrastructure;
using ScillFactory_Practice.Models.Db;
using ScillFactory_Practice.Models.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScillFactory_Practice.Models.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private BlogContext _appContext;

        private Dictionary<Type, object> _repositories;

        public UnitOfWork(BlogContext app)
        {
            this._appContext = app;
        }

        public void Dispose()
        {
           
        }

        public IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = true) where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<Type, object>();
            }

            if (hasCustomRepository)
            {
                var customRepo = _appContext.GetService<IRepository<TEntity>>();
                if (customRepo != null)
                {
                    return customRepo;
                }
            }

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new Repository<TEntity>(_appContext);
            }

            return (IRepository<TEntity>)_repositories[type];
           
        }
        public int SaveChanges(bool ensureAutoHistory = false)
        {
            throw new NotImplementedException();
        }
    }
}
