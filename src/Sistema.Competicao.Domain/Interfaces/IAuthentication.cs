using Sistema.Competicao.Domain.Entities.Account;
using System.Threading.Tasks;

namespace Sistema.Competicao.Domain.Interfaces
{
    public interface IAuthentication
    {
        Task Authenticate(string login, string senha);
        UsuarioEN GetUserLogged();
        Task Logout();
        bool IsLoggedIn();
    }
}
