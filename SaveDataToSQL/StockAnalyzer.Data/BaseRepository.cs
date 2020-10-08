using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace StockAnalyzer.Data
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class 
    {
        protected DbSet<TEntity> dbSet { get; set; }
        protected DbContext context{ get; set; }
        public BaseRepository(DbContext dbContext)
        {
            this.context = dbContext;
            dbSet = context.Set<TEntity>();
        }
        public virtual void Delete(object id)
        {
            TEntity entity = dbSet.Find(id);
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if(context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet;
        }

        public virtual TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
