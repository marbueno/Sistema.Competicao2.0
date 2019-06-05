using Sistema.Competicao.Domain.Entities.Controles;
using Sistema.Competicao.Domain.Interfaces;
using System;

namespace Sistema.Competicao.Domain.Services.Controles
{
    public class ControleBU
    {
        private readonly IRepository<ControleEN> _repositoryControleEN;
        private readonly IUnitOfWork _unitOfWork;

        public ControleBU(IRepository<ControleEN> repositoryControleEN, IUnitOfWork unitOfWork)
        {
            _repositoryControleEN = repositoryControleEN;
            _unitOfWork = unitOfWork;
        }

        public void Save(int conCodigo, int atlCodigo, decimal conValorPago, DateTime conDataPagto, int conMesReferencia)
        {
            ControleEN controleEN = _repositoryControleEN.GetByID(conCodigo);

            if (controleEN != null)
            {
                controleEN.UpdateProperties
                    (
                        atlCodigo,
                        conValorPago,
                        conDataPagto,
                        conMesReferencia
                    );

                _repositoryControleEN.Edit(controleEN);
            }
            else
            {
                controleEN = new ControleEN
                    (
                        atlCodigo,
                        conValorPago,
                        conDataPagto,
                        conMesReferencia
                    );

                _repositoryControleEN.Save(controleEN);
            }

            _unitOfWork.Commit();
        }        
    }
}
