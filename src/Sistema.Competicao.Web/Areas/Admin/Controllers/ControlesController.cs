using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema.Competicao.Data.Repositories;
using Sistema.Competicao.Domain.Entities.Controles;
using Sistema.Competicao.Domain.Interfaces;
using Sistema.Competicao.Domain.Services.Controles;
using Sistema.Competicao.Domain.Utils;
using Sistema.Competicao.Web.Areas.Admin.Models.Controles;

namespace Sistema.Competicao.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class ControlesController : Controller
    {
        #region Variables

        private readonly ControleRepository _controleRepository;
        private readonly ControleBU _controleBU;

        private readonly IRepository<TipoDespesaReceitaEN> _tipoDespesaReceitaRepository;
        private readonly TipoDespesaReceitaBU _tipoDespesaReceitaBU;

        #endregion Variables

        #region Constructor

        public ControlesController
            (
                ControleRepository controleRepository, ControleBU controleBU,
                IRepository<TipoDespesaReceitaEN> tipoDespesaReceitaRepository, TipoDespesaReceitaBU tipoDespesaReceitaBU
            )
        {
            _controleRepository = controleRepository;
            _controleBU = controleBU;

            _tipoDespesaReceitaRepository = tipoDespesaReceitaRepository;
            _tipoDespesaReceitaBU = tipoDespesaReceitaBU;
        }

        #endregion Constructor

        #region Controle de Pagamento dos Atletas

        public IActionResult ControlePagamento()
        {
            return View();
        }

        public JsonResult ListControlePagamento()
        {
            var listControlePagamento = _controleRepository.ListaControlesPagamentos();

            var listControlePagamentoVM = new List<ControleVM>();
            foreach (var item in listControlePagamento)
            {
                listControlePagamentoVM.Add(new ControleVM()
                {
                    Codigo = (int)item.Where(o => o.Key == "conCodigo").FirstOrDefault().Value,
                    Atleta = (int)item.Where(o => o.Key == "atlCodigo").FirstOrDefault().Value,
                    NomeAtleta = (string)item.Where(o => o.Key == "atlNome").FirstOrDefault().Value,
                    DataPagto = (DateTime)item.Where(o => o.Key == "conDataPagto").FirstOrDefault().Value,
                    DataPagtoFormatada = ((DateTime)item.Where(o => o.Key == "conDataPagto").FirstOrDefault().Value).ToString("dd-MM-yyyy"),
                    ValorPago = (decimal)item.Where(o => o.Key == "conValorPago").FirstOrDefault().Value,
                    ValorPagoFormatado = ((decimal)item.Where(o => o.Key == "conValorPago").FirstOrDefault().Value).ToString("R$ #0.00"),
                    MesReferencia = (int)item.Where(o => o.Key == "conMesReferencia").FirstOrDefault().Value,
                    MesReferenciaDescricao = Helper.GetMes((int)item.Where(o => o.Key == "conMesReferencia").FirstOrDefault().Value)
                });
            }

            return Json(listControlePagamentoVM);
        }

        [HttpPost]
        public IActionResult ControlePagamentoCreateOrUpdate(ControleVM controlePagamentoVM)
        {
            _controleBU.Save(controlePagamentoVM.Codigo, controlePagamentoVM.Atleta, controlePagamentoVM.ValorPago, controlePagamentoVM.DataPagto, controlePagamentoVM.MesReferencia);

            return Ok();
        }

        [HttpDelete]
        public IActionResult ControlePagamentoRemove(int id)
        {
            _controleRepository.Delete(id);

            return Ok();
        }

        #endregion Controle de Pagamento dos Atletas

        #region Tipo de Despesa /Receita

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

        #endregion Tipo de Despesa /Receita
    }
}