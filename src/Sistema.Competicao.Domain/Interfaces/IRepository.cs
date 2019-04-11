using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sistema.Competicao.Domain
{
    public interface IRepository<TEntity>
    {
        TEntity GetByID(int id);
        void Edit(TEntity entity);
        void Save(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        IQueryable Where(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> All();
    }
}