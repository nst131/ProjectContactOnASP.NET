﻿using ContactTaskDomain.Repositories;
using ContactTaskDomain.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ContactTaskInfrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IUnitOfWork unitOfWork;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public virtual T Get(object id)
        {
            return DbSet().Find(id);
        }

        public virtual int Count()
        {
            return DbSet().Count();
        }

        public virtual void Add(T item)
        {
            DbSet().Add(item);
        }

        public virtual T Create() 
        {
            return DbSet().Create();
        }


        public virtual void Delete(T item)
        {
            DbSet().Remove(item);
        }

        public virtual void DeleteById(object itemId)
        {
            Delete(Get(itemId));
        }

        public virtual ICollection<T> GetCollection()
        {
            return DbSet().ToList();
        }

        public virtual IQueryable<T> GetQueryable()
        {
            return DbSet().AsQueryable();
        }

        private DbSet<T> DbSet()
        {
            return unitOfWork.Set<T>();
        }
    }
}
