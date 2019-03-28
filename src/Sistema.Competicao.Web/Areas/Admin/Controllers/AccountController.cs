using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Sistema.Competicao.Domain;
using Sistema.Competicao.Web.Areas.Admin.Models;

namespace Sistema.Competicao.Web.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        #region Variables

        private readonly IConfiguration _configuration;
        private readonly IAuthentication _authentication;
        private readonly IRepository<UsuarioEN> _usuarioRepository;
        private readonly UsuarioBU _usuarioBU;

        #endregion Variables

        #region Constructor

        public AccountController(IConfiguration configuration, IAuthentication authentication, IRepository<UsuarioEN> usuarioRepository, UsuarioBU usuarioBU)
        {
            _configuration = configuration;
            _authentication = authentication;
            _usuarioRepository = usuarioRepository;
            _usuarioBU = usuarioBU;
        }

        #endregion Constructor

        #region Authentication

        public IActionResult Login()
        {
            ViewBag.NomeEquipe = _configuration.GetValue<string>("NomeEquipe");

            if (_authentication.IsLoggedIn())
                return Redirect("/Admin/Home/Dashboard");

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _authentication.Logout();
            return Redirect("/Admin");
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioVM usuarioVM)
        {
            await _authentication.Authenticate(usuarioVM.Login, usuarioVM.Senha);

            return Ok();
        }

        #endregion Authentication

        #region Profile

        public IActionResult Profile()
        {
            if (!_authentication.IsLoggedIn())
                return Redirect("/Admin");

            UsuarioEN usuarioEN = _authentication.GetUserLogged();
            UsuarioVM usuarioVM = new UsuarioVM()
            {
                Codigo = usuarioEN.usuCodigo,
                Login = usuarioEN.usuLogin,
                Nome = usuarioEN.usuNome,
                Email = usuarioEN.usuEmail
            };

            return View(usuarioVM);
        }

        [HttpPost]
        public IActionResult ProfileUpdate(UsuarioVM usuarioVM)
        {
            _usuarioBU.Save(usuarioVM.Codigo, usuarioVM.Nome, usuarioVM.Login, usuarioVM.Email, usuarioVM.Senha, usuarioVM.Perfil);

            return Ok();
        }

        #endregion Profile
    }
}