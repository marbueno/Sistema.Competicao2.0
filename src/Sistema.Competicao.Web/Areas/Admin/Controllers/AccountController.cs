using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Sistema.Competicao.Domain;
using Sistema.Competicao.Web.Areas.Admin.Models;

namespace Sistema.Competicao.Web.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<AuthenticationEN> _repositoryAuthentication;
        private readonly IRepository<QuadraEN> _repositoryQuadra;
        private readonly AuthenticationBU _authentication;

        //public AccountController(IConfiguration configuration, IRepository<AuthenticationEN> repositoryAuthentication, AuthenticationBU authentication)
        //{
        //    _configuration = configuration;
        //    _repositoryAuthentication = repositoryAuthentication;
        //    _authentication = authentication;
        //}

        //public AccountController(IConfiguration configuration, IRepository<AuthenticationEN> repositoryAuthentication)
        //{
        //    _repositoryAuthentication = repositoryAuthentication;
        //    _configuration = configuration;
        //}

        public AccountController(IConfiguration configuration, IRepository<QuadraEN> repositoryQuadra)
        {
            _repositoryQuadra = repositoryQuadra;
            _configuration = configuration;
        }

        public IActionResult Login()
        {
            ViewBag.NomeEquipe = _configuration.GetValue<string>("NomeEquipe");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioVM usuarioVM)
        {
            var result = _authentication.Authenticate(usuarioVM.Login, usuarioVM.Senha);
            return View();

            //var result = await _authentication.Authenticate(usuarioVM.Login, usuarioVM.Senha);

            //if (result)
            //    return Redirect("/");
            //else
            //{
            //    ModelState.AddModelError(string.Empty, "Login Inválido");
            //    return View(usuarioVM);
            //}
        }
    }
}