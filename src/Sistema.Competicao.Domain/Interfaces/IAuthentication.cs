using Sistema.Competicao.Domain.Account;
using System.Threading.Tasks;

namespace Sistema.Competicao.Domain
{
    public interface IAuthentication
    {
        Task Authenticate(string login, string senha);
        UsuarioEN GetUserLogged();
        Task Logout();
        bool IsLoggedIn();
    }
}
