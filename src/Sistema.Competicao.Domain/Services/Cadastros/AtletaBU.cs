using Sistema.Competicao.Domain.Entities.Cadastros;
using Sistema.Competicao.Domain.Interfaces;
using System;

namespace Sistema.Competicao.Domain.Services.Cadastros
{
    public class AtletaBU
    {
        private readonly IRepository<AtletaEN> _atletaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AtletaBU(IRepository<AtletaEN> atletaRepository, IUnitOfWork unitOfWork)
        {
            _atletaRepository = atletaRepository;
            _unitOfWork = unitOfWork;
        }

        public void Save(int atlCodigo, string atlNome, double atlCPF, string atlRG, DateTime atlDataNascimento, int posCodigo, int equCodigo, bool atlPrimeiroQuadro, bool atlSegundoQuadro, bool atlIsentoPagamento, string atlFoto)
        {
            AtletaEN atletaEN = _atletaRepository.GetByID(atlCodigo);

            if (atletaEN != null)
            {
                atletaEN.UpdateProperties(
                                        atlNome,
                                        atlCPF,
                                        atlRG,
                                        atlDataNascimento,
                                        posCodigo,
                                        equCodigo,
                                        atlPrimeiroQuadro,
                                        atlSegundoQuadro,
                                        atlIsentoPagamento,
                                        atlFoto
                                    );

                _atletaRepository.Edit(atletaEN);
            }
            else
            {
                atletaEN = new AtletaEN(
                                        atlNome,
                                        atlCPF,
                                        atlRG,
                                        atlDataNascimento,
                                        posCodigo,
                                        equCodigo,
                                        atlPrimeiroQuadro,
                                        atlSegundoQuadro,
                                        atlIsentoPagamento,
                                        atlFoto
                                    );

                _atletaRepository.Save(atletaEN);
            }

            _unitOfWork.Commit();
        }
    }
}