using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Sistema.Competicao.Domain;
using Sistema.Competicao.Web.Areas.Admin.Models;

namespace Sistema.Competicao.Web.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        public IConfiguration _configuration { get; }

        //private readonly IRepository<UsuarioEN> _usuarioRepository;

        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
            //_usuarioRepository = usuarioRepository;
        }

        public IActionResult Login()
        {
            ViewBag.NomeEquipe = _configuration.GetValue<string>("NomeEquipe");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioVM usuarioVM)
        {
            return Ok();
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