using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Sistema.Competicao.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sistema.Competicao.Data
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
                new Claim(ClaimTypes.Name, usuario.FirstOrDefault().usuLogin),
                new Claim(ClaimTypes.Email, usuario.FirstOrDefault().usuEmail),
                new Claim("FullName", usuario.FirstOrDefault().usuNome),
                new Claim(ClaimTypes.Role, "Administrator"),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            _httpContextAccessor.HttpContext.Session.SetInt32("usuCodigo", usuario.FirstOrDefault().usuCodigo);

            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }

        public UsuarioEN GetUserLogged()
        {
            var usuCodigo = _httpContextAccessor.HttpContext.Session.GetInt32("usuCodigo");
            UsuarioEN usuarioEN = _dbContext.Set<UsuarioEN>().Find(usuCodigo);

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
