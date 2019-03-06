using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sistema.Competicao.Domain
{
    public interface IRepository<TEntity>
    {
        TEntity GetByID(int id);
        void Save(TEntity entity);
        IQueryable Where(Expression<Func<TEntity, bool>> expression);
    }
}