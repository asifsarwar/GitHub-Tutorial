using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalyzer.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Delete(object id);
        void Delete(TEntity entity);

        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Insert(TEntity entity);
        void Update(TEntity entity);
    }
}
