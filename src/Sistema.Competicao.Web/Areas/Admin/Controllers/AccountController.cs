using System.Collections.Generic;
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
        private readonly IRepository<UsuarioEN> _usuarioRepository;
        private readonly UsuarioBU _usuarioBU;
        private readonly IRepository<PerfilEN> _perfilRepository;
        private readonly PerfilBU _perfilBU;

        #endregion Variables

        #region Constructor

        public AccountController(IConfiguration configuration, IAuthentication authentication, IRepository<UsuarioEN> usuarioRepository, UsuarioBU usuarioBU, IRepository<PerfilEN> perfilRepository, PerfilBU perfilBU)
        {
            _configuration = configuration;
            _authentication = authentication;
            _usuarioRepository = usuarioRepository;
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
            return View();
        }

        public JsonResult ListPerfil()
        {
            var listPerfil = _perfilRepository.All();
            var perfilVM = listPerfil.Select(c => new PerfilVM { Codigo = c.perCodigo, Nome = c.perNome });
            return Json(perfilVM);
        }

        [HttpPost]
        public IActionResult PerfilCreateOrUpdate(PerfilVM perfilVM)
        {
            _perfilBU.Save(perfilVM.Codigo, perfilVM.Nome);

            return Ok();
        }

        [HttpDelete]
        public IActionResult PerfilRemove(int id)
        {
            _perfilRepository.Delete(id);

            return Ok();
        }

        #endregion Perfil

        #region Usuario

        public IActionResult Usuario()
        {
            return View();
        }

        public JsonResult ListUsuario()
        {
            var listUsuario = _usuarioRepository.All();
            var usuarioVM = listUsuario.Select(c => new UsuarioVM { Codigo = c.usuCodigo, Nome = c.usuNome, Login = c.usuLogin, Email = c.usuEmail, Perfil = c.perCodigo });
            return Json(usuarioVM);
        }

        [HttpPost]
        public IActionResult UsuarioCreateOrUpdate(UsuarioVM usuarioVM)
        {
            _usuarioBU.Save(usuarioVM.Codigo, usuarioVM.Nome, usuarioVM.Login, usuarioVM.Email, usuarioVM.Senha, usuarioVM.Perfil);

            return Ok();
        }

        [HttpDelete]
        public IActionResult UsuarioRemove(int id)
        {
            _usuarioRepository.Delete(id);

            return Ok();
        }

        #endregion Usuario
    }
}