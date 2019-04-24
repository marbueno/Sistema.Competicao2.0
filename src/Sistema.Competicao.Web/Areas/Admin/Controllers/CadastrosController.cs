using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema.Competicao.Domain.Entities.Cadastros;
using Sistema.Competicao.Domain.Interfaces;
using Sistema.Competicao.Domain.Services.Cadastros;
using Sistema.Competicao.Web.Areas.Admin.Models.Cadastros;

namespace Sistema.Competicao.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class CadastrosController : Controller
    {
        #region Variables

        private readonly IRepository<AdversarioEN> _adversarioRepository;
        private readonly AdversarioBU _adversarioBU;

        private readonly IRepository<EquipeEN> _equipeRepository;
        private readonly EquipeBU _equipeBU;

        private readonly IRepository<PosicaoEN> _posicaoRepository;
        private readonly PosicaoBU _posicaoBU;

        private readonly IRepository<QuadraEN> _quadraRepository;
        private readonly QuadraBU _quadraBU;

        #endregion Variables

        #region Constructor

        public CadastrosController(
                IRepository<AdversarioEN> adversarioRepository, AdversarioBU adversarioBU,
                IRepository<EquipeEN> equipeRepository, EquipeBU equipeBU,
                IRepository<PosicaoEN> posicaoRepository, PosicaoBU posicaoBU,
                IRepository<QuadraEN> quadraRepository, QuadraBU quadraBU)
        {
            _adversarioRepository = adversarioRepository;
            _adversarioBU = adversarioBU;

            _equipeRepository = equipeRepository;
            _equipeBU = equipeBU;

            _posicaoRepository = posicaoRepository;
            _posicaoBU = posicaoBU;

            _quadraRepository = quadraRepository;
            _quadraBU = quadraBU;
        }

        #endregion Constructor

        #region Adversário

        public IActionResult Adversario()
        {
            return View();
        }

        public JsonResult ListAdversario()
        {
            var listAdversario = _adversarioRepository.All();
            var adversarioVM = listAdversario.Select(
                c => new AdversarioVM
                {
                    Codigo = c.advCodigo,
                    Nome = c.advNome,
                    Responsavel = c.advResponsavel,
                    DDD1 = c.advDDD1,
                    Telefone1 = c.advTelefone1,
                    DDD2 = c.advDDD2,
                    Telefone2 = c.advTelefone2,
                    ComQuadra = c.advComQuadra,
                    Quadra = c.quaCodigo
                });

            return Json(adversarioVM);
        }

        [HttpPost]
        public IActionResult AdversarioCreateOrUpdate(AdversarioVM adversarioVM)
        {
            _adversarioBU.Save(adversarioVM.Codigo, adversarioVM.Nome, adversarioVM.Responsavel, adversarioVM.DDD1, adversarioVM.Telefone1, adversarioVM.DDD2 ?? 0, adversarioVM.Telefone2 ?? 0, 0, 0, adversarioVM.ComQuadra, adversarioVM.Quadra ?? 0);

            return Ok();
        }

        [HttpDelete]
        public IActionResult AdversarioRemove(int id)
        {
            _adversarioRepository.Delete(id);

            return Ok();
        }

        #endregion Adversário

        #region Equipe

        public IActionResult Equipe()
        {
            return View();
        }

        public JsonResult ListEquipe()
        {
            var listEquipe = _equipeRepository.All();
            var equipeVM = listEquipe.Select(
                c => new EquipeVM
                {
                    Codigo = c.equCodigo,
                    Nome = c.equNome,
                    Responsavel = c.equResponsavel,
                    DataFundacao = c.equDataFundacao,
                    DataFundacaoFormatada = c.equDataFundacao.ToString("dd-MM-yyyy"),
                    DDD1 = c.equDDD1.ToString(),
                    Telefone1 = c.equTelefone1.ToString(),
                    DDD2 = c.equDDD2.ToString(),
                    Telefone2 = c.equTelefone2.ToString(),
                    ComQuadra = c.equComQuadra,
                    Quadra = c.quaCodigo,
                    Horario = c.equHorario
                });

            return Json(equipeVM);
        }

        [HttpPost]
        public IActionResult EquipeCreateOrUpdate(EquipeVM equipeVM)
        {
            if (string.IsNullOrEmpty(equipeVM.DDD1)) equipeVM.DDD1 = "0";
            if (string.IsNullOrEmpty(equipeVM.Telefone1)) equipeVM.Telefone1 = "0";
            if (string.IsNullOrEmpty(equipeVM.DDD2)) equipeVM.DDD2 = "0";
            if (string.IsNullOrEmpty(equipeVM.Telefone2)) equipeVM.Telefone2 = "0";

            equipeVM.Telefone1 = equipeVM.Telefone1.Replace("-", "");
            equipeVM.Telefone2 = equipeVM.Telefone2.Replace("-", "");
            
            _equipeBU.Save(
                equipeVM.Codigo, 
                equipeVM.Nome, 
                equipeVM.Responsavel, 
                equipeVM.DataFundacao, 
                int.Parse(equipeVM.DDD1), 
                int.Parse(equipeVM.Telefone1), 
                int.Parse(equipeVM.DDD2), 
                int.Parse(equipeVM.Telefone2), 
                equipeVM.ComQuadra, 
                equipeVM.Quadra ?? 0, 
                equipeVM.Horario);

            return Ok();
        }

        [HttpDelete]
        public IActionResult EquipeRemove(int id)
        {
            _equipeRepository.Delete(id);

            return Ok();
        }

        #endregion Equipe

        #region Posição

        public IActionResult Posicao()
        {
            return View();
        }

        public JsonResult ListPosicao()
        {
            var listPosicao = _posicaoRepository.All();
            var PosicaoVM = listPosicao.Select(c => new PosicaoVM { Codigo = c.posCodigo, Descricao = c.posDescricao, Goleiro = c.posGoleiro, Tecnico = c.posTecnico });
            return Json(PosicaoVM);
        }

        [HttpPost]
        public IActionResult PosicaoCreateOrUpdate(PosicaoVM posicaoVM)
        {
            _posicaoBU.Save(posicaoVM.Codigo, posicaoVM.Descricao, posicaoVM.Goleiro, posicaoVM.Tecnico);

            return Ok();
        }

        [HttpDelete]
        public IActionResult PosicaoRemove(int id)
        {
            _posicaoRepository.Delete(id);

            return Ok();
        }

        #endregion Posição

        #region Quadra

        private IEnumerable<QuadraVM> GetQuadra()
        {
            var listQuadra = _quadraRepository.All();
            var quadraVM = listQuadra.Select(c => new QuadraVM { Codigo = c.quaCodigo, Nome = c.quaNome, Endereco = c.quaEndereco, Numero = c.quaNumero, Bairro = c.quaBairro });
            return quadraVM;
        }

        public IActionResult Quadra()
        {
            return View();
        }

        public JsonResult ListQuadra()
        {
            return Json(GetQuadra());
        }

        [HttpPost]
        public IActionResult QuadraCreateOrUpdate(QuadraVM quadraVM)
        {
            _quadraBU.Save(quadraVM.Codigo, quadraVM.Nome, quadraVM.Endereco, quadraVM.Numero, quadraVM.Bairro);

            return Ok();
        }

        [HttpDelete]
        public IActionResult QuadraRemove(int id)
        {
            _quadraRepository.Delete(id);

            return Ok();
        }

        #endregion Quadra
    }
}