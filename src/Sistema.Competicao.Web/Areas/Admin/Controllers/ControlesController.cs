using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema.Competicao.Domain.Entities.Controles;
using Sistema.Competicao.Domain.Interfaces;
using Sistema.Competicao.Domain.Services.Controles;
using Sistema.Competicao.Web.Areas.Admin.Models.Controles;

namespace Sistema.Competicao.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class ControlesController : Controller
    {
        #region Variables

        private readonly IRepository<TipoDespesaReceitaEN> _tipoDespesaReceitaRepository;
        private readonly TipoDespesaReceitaBU _tipoDespesaReceitaBU;

        #endregion Variables

        #region Constructor

        public ControlesController(IRepository<TipoDespesaReceitaEN> tipoDespesaReceitaRepository, TipoDespesaReceitaBU tipoDespesaReceitaBU)
        {
            _tipoDespesaReceitaRepository = tipoDespesaReceitaRepository;
            _tipoDespesaReceitaBU = tipoDespesaReceitaBU;
        }

        #endregion Constructor

        #region TipoDespesaReceita

        public IActionResult TipoDespesaReceita()
        {
            return View();
        }

        public JsonResult ListTipoDespesaReceita()
        {
            var listTipoDespesaReceita = _tipoDespesaReceitaRepository.All();
            var tipoDespesaReceitaVM = listTipoDespesaReceita.Select(c => new TipoDespesaReceitaVM { Codigo = c.tipCodigo, Descricao = c.tipDescricao, TipoDespesaReceita = c.tipDespesaReceita });
            return Json(tipoDespesaReceitaVM);
        }

        [HttpPost]
        public IActionResult TipoDespesaReceitaCreateOrUpdate(TipoDespesaReceitaVM tipoDespesaReceitaVM)
        {
            _tipoDespesaReceitaBU.Save(tipoDespesaReceitaVM.Codigo, tipoDespesaReceitaVM.Descricao, tipoDespesaReceitaVM.TipoDespesaReceita);

            return Ok();
        }

        [HttpDelete]
        public IActionResult TipoDespesaReceitaRemove(int id)
        {
            _tipoDespesaReceitaRepository.Delete(id);

            return Ok();
        }

        #endregion TipoDespesaReceita
    }
}