using Sistema.Competicao.Domain.Entities.Controles;
using Sistema.Competicao.Domain.Interfaces;

namespace Sistema.Competicao.Domain.Services.Controles
{
    public class TipoDespesaReceitaBU
    {
        private readonly IRepository<TipoDespesaReceitaEN> _repositoryTipoDespesaReceitaEN;
        private readonly IUnitOfWork _unitOfWork;

        public TipoDespesaReceitaBU(IRepository<TipoDespesaReceitaEN> repositoryTipoDespesaReceitaEN, IUnitOfWork unitOfWork)
        {
            _repositoryTipoDespesaReceitaEN = repositoryTipoDespesaReceitaEN;
            _unitOfWork = unitOfWork;
        }

        public void Save(int tipCodigo, string tipDescricao, string tipDespesaReceita)
        {
            TipoDespesaReceitaEN tipoDespesaReceitaEN = _repositoryTipoDespesaReceitaEN.GetByID(tipCodigo);

            if (tipoDespesaReceitaEN != null)
            {
                tipoDespesaReceitaEN.UpdateProperties
                    (
                        tipDescricao,
                        tipDespesaReceita
                    );

                _repositoryTipoDespesaReceitaEN.Edit(tipoDespesaReceitaEN);
            }
            else
            {
                tipoDespesaReceitaEN = new TipoDespesaReceitaEN
                    (
                        tipDescricao,
                        tipDespesaReceita
                    );

                _repositoryTipoDespesaReceitaEN.Save(tipoDespesaReceitaEN);
            }

            _unitOfWork.Commit();
        }
    }
}
