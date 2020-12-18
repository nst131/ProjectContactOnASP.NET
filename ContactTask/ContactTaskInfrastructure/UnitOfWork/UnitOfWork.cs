using ContactTaskDomain.UnitOfWork;
using ContactTaskInfrastructure.Context;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ContactTaskInfrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IContextDatabase db;

        public UnitOfWork(IContextDatabase db)
        {
            this.db = db;
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return db.Set<TEntity>();
        }

        public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return db.Entry(entity);
        }
    }
}
