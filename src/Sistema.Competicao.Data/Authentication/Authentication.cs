using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Sistema.Competicao.Domain;
using Sistema.Competicao.Domain.Entities.Account;
using Sistema.Competicao.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sistema.Competicao.Data.Authentication
{
    public class Authentication : IAuthentication
    {
        protected readonly DataBaseContext _dbContext;
        private IHttpContextAccessor _httpContextAccessor;

        public Authentication(DataBaseContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Authenticate(string login, string senha)
        {
            var usuario = _dbContext.Set<UsuarioEN>().Where(obj => obj.usuLogin == login && obj.usuSenha == senha);

            DomainException.When(usuario == null || !usuario.Any(), "Usuário ou Senhas Inválidos.");

            var claims = new List<Claim>
            {
                new Claim("ID", usuario.FirstOrDefault().usuCodigo.ToString()),
                new Claim(ClaimTypes.Name, usuario.FirstOrDefault().usuLogin),
                new Claim(ClaimTypes.Email, usuario.FirstOrDefault().usuEmail ?? ""),
                new Claim("FullName", usuario.FirstOrDefault().usuNome),
                new Claim(ClaimTypes.Role, "Administrator"),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }

        public UsuarioEN GetUserLogged()
        {
            var usuCodigo =  _httpContextAccessor.HttpContext.User.Identities.FirstOrDefault().Claims.Where(x => x.Type == "ID").FirstOrDefault().Value;
            UsuarioEN usuarioEN = _dbContext.Set<UsuarioEN>().Find(int.Parse(usuCodigo));

            return usuarioEN;
        }

        public async Task Logout()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public bool IsLoggedIn()
        {
            return _httpContextAccessor.HttpContext.User.Identities.Any(x => x.IsAuthenticated);
        }
    }
}
