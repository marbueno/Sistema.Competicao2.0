using System.Threading.Tasks;
using Sistema.Competicao.Data;
using Sistema.Competicao.Domain;

namespace Sistema.Competicao.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _dbContext;

        public UnitOfWork(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}