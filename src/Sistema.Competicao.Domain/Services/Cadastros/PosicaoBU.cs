using Sistema.Competicao.Domain.Entities.Cadastros;
using Sistema.Competicao.Domain.Interfaces;

namespace Sistema.Competicao.Domain.Services.Cadastros
{
    public class PosicaoBU
    {
        private readonly IRepository<PosicaoEN> _repositoryPosicaoEN;
        private readonly IUnitOfWork _unitOfWork;

        public PosicaoBU(IRepository<PosicaoEN> repositoryPosicaoEN, IUnitOfWork unitOfWork)
        {
            _repositoryPosicaoEN = repositoryPosicaoEN;
            _unitOfWork = unitOfWork;
        }

        public void Save(int posCodigo, string posDescricao, bool posGoleiro, bool posTecnico)
        {
            PosicaoEN posicaoEN = _repositoryPosicaoEN.GetByID(posCodigo);

            if (posicaoEN != null)
            {
                posicaoEN.UpdateProperties
                    (
                        posDescricao,
                        posGoleiro,
                        posTecnico
                    );

                _repositoryPosicaoEN.Edit(posicaoEN);
            }
            else
            {
                posicaoEN = new PosicaoEN
                    (
                        posDescricao,
                        posGoleiro,
                        posTecnico
                    );

                _repositoryPosicaoEN.Save(posicaoEN);
            }

            _unitOfWork.Commit();
        }
    }
}
