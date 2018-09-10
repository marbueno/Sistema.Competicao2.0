using System.Threading.Tasks;

namespace Sistema.Competicao.Domain
{
    public interface IUnitOfWork
    {
         Task Commit();
    }
}