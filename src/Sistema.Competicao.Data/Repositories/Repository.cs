using Sistema.Competicao.Domain;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sistema.Competicao.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DataBaseContext _dbContext;

        public Repository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual TEntity GetByID(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public virtual void Edit(TEntity entity)
        {
            _dbContext.Set<TEntity>().Attach(entity);
        }

        public virtual void Save(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public virtual IQueryable Where(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().Where(expression);
        }
    }
}