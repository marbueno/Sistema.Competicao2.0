using Sistema.Competicao.Data;
using Sistema.Competicao.Domain;
using System.Linq;

namespace Sistema.Competicao.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DataBaseContext _dbContext;

        public Repository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity GetByID(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public void Save(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }
    }
}