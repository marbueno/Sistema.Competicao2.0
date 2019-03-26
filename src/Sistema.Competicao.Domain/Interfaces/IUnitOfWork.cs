using System.Threading.Tasks;

namespace Sistema.Competicao.Domain
{
    public interface IUnitOfWork
    {
         void Commit();
    }
}