using Sistema.Competicao.Domain.Entities.Administracao;
using Sistema.Competicao.Domain.Interfaces;

namespace Sistema.Competicao.Domain.Services.Account
{
    public class ParametrosBU
    {
        private readonly IRepository<ParametrosEN> _repositoryParametrosEN;
        private readonly IUnitOfWork _unitOfWork;

        public ParametrosBU(IRepository<ParametrosEN> repositoryParametrosEN, IUnitOfWork unitOfWork)
        {
            _repositoryParametrosEN = repositoryParametrosEN;
            _unitOfWork = unitOfWork;
        }

        public void Save(int parCodigo, bool parEsconderValorPagamentoSumula, string parCaminhoFotos, int parTamanhoFotos, string parExtensaoFotos, string parCaminhoFotosAtletas, int parTamanhoAlturaFotos, int parTamanhoLarguraFotos, int tipCodigo)
        {
            ParametrosEN parametrosEN = _repositoryParametrosEN.GetByID(parCodigo);

            if (parametrosEN != null)
            {
                parametrosEN.UpdateProperties
                    (
                        parEsconderValorPagamentoSumula,
                        parCaminhoFotos,
                        parTamanhoFotos,
                        parExtensaoFotos,
                        parCaminhoFotosAtletas,
                        parTamanhoAlturaFotos,
                        parTamanhoLarguraFotos,
                        tipCodigo
                    );

                _repositoryParametrosEN.Edit(parametrosEN);
            }
            else
            {
                parametrosEN = new ParametrosEN
                    (
                        parEsconderValorPagamentoSumula,
                        parCaminhoFotos,
                        parTamanhoFotos,
                        parExtensaoFotos,
                        parCaminhoFotosAtletas,
                        parTamanhoAlturaFotos,
                        parTamanhoLarguraFotos,
                        tipCodigo
                    );

                _repositoryParametrosEN.Save(parametrosEN);
            }

            _unitOfWork.Commit();
        }
    }
}
