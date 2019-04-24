using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema.Competicao.Domain.Entities.Administracao;
using Sistema.Competicao.Domain.Interfaces;
using Sistema.Competicao.Domain.Services.Account;
using Sistema.Competicao.Web.Areas.Admin.Models.Administracao;
using System.Linq;

namespace Sistema.Competicao.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class AdministracaoController : Controller
    {
        #region Variables

        private readonly IRepository<ParametrosEN> _parametrosRepository;
        private readonly ParametrosBU _parametrosBU;

        #endregion Variables

        #region Constructor

        public AdministracaoController(IRepository<ParametrosEN> parametrosRepository, ParametrosBU parametrosBU)
        {
            _parametrosRepository = parametrosRepository;
            _parametrosBU = parametrosBU;
        }

        #endregion Constructor

        #region Administração

        public JsonResult ListParametros()
        {
            ParametrosEN parametrosEN = _parametrosRepository.All().FirstOrDefault();
            ParametrosVM parametrosVM = new ParametrosVM()
            {
                Codigo = parametrosEN.parCodigo,
                EsconderValorPagamentoSumula = parametrosEN.parEsconderValorPagamentoSumula,
                CaminhoFotos = parametrosEN.parCaminhoFotos,
                TamanhoFotos = parametrosEN.parTamanhoFotos,
                ExtensaoFotos = parametrosEN.parExtensaoFotos,
                CaminhoFotosAtletas = parametrosEN.parCaminhoFotosAtletas,
                TamanhoAlturaFotos = parametrosEN.parTamanhoAlturaFotos,
                TamanhoLarguraFotos = parametrosEN.parTamanhoLarguraFotos,
                TipoReceita = parametrosEN.tipCodigo,
            };

            return Json(parametrosVM);
        }

        public IActionResult Parametros()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ParametrosUpdate(ParametrosVM parametrosVM)
        {
            _parametrosBU.Save
                (
                    parametrosVM.Codigo, 
                    parametrosVM.EsconderValorPagamentoSumula, 
                    parametrosVM.CaminhoFotos, 
                    parametrosVM.TamanhoFotos, 
                    parametrosVM.ExtensaoFotos, 
                    parametrosVM.CaminhoFotosAtletas,
                    parametrosVM.TamanhoAlturaFotos,
                    parametrosVM.TamanhoLarguraFotos,
                    parametrosVM.TipoReceita
                );

            return Ok();
        }

        #endregion Administração
    }
}