using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Sistema.Competicao.Domain;
using Sistema.Competicao.Domain.Account;
using Sistema.Competicao.Web.Areas.Admin.Models.Account;

namespace Sistema.Competicao.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        #region Variables

        private readonly IConfiguration _configuration;
        private readonly IAuthentication _authentication;
        private readonly UsuarioBU _usuarioBU;
        private readonly IRepository<PerfilEN> _perfilRepository;
        private readonly PerfilBU _perfilBU;

        #endregion Variables

        #region Constructor

        public AccountController(IConfiguration configuration, IAuthentication authentication, UsuarioBU usuarioBU, IRepository<PerfilEN> perfilRepository, PerfilBU perfilBU)
        {
            _configuration = configuration;
            _authentication = authentication;
            _usuarioBU = usuarioBU;
            _perfilRepository = perfilRepository;
            _perfilBU = perfilBU;
        }

        #endregion Constructor

        #region Authentication

        [AllowAnonymous]
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

        [AllowAnonymous]
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

        #region Perfil

        public IActionResult Perfil()
        {
            var listPerfil = _perfilRepository.All();
            var perfilVM = listPerfil.Select(c => new PerfilVM { Codigo = c.perCodigo, Nome = c.perNome });
            ViewBag.ListPerfil = Json(perfilVM);
            return View(perfilVM);
        }

        public JsonResult ListPerfil()
        {
            var listPerfil = _perfilRepository.All();
            var perfilVM = listPerfil.Select(c => new PerfilVM { Codigo = c.perCodigo, Nome = c.perNome });
            return Json(perfilVM);
        }

        [HttpPost]
        public IActionResult PerfilUpdate(PerfilVM perfilVM)
        {
            _perfilBU.Save(perfilVM.Codigo, perfilVM.Nome);

            return Ok();
        }

        #endregion Perfil
    }
}