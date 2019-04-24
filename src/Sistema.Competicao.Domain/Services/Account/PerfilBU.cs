using Sistema.Competicao.Domain.Entities.Account;
using Sistema.Competicao.Domain.Interfaces;

namespace Sistema.Competicao.Domain.Services.Account
{
    public class PerfilBU
    {
        private readonly IRepository<PerfilEN> _repositoryPerfilEN;
        private readonly IUnitOfWork _unitOfWork;

        public PerfilBU(IRepository<PerfilEN> repositoryPerfilEN, IUnitOfWork unitOfWork)
        {
            _repositoryPerfilEN = repositoryPerfilEN;
            _unitOfWork = unitOfWork;
        }

        public void Save(int perCodigo, string perDescricao)
        {
            PerfilEN perfilEN = _repositoryPerfilEN.GetByID(perCodigo);

            if (perfilEN != null)
            {
                perfilEN.UpdateProperties
                    (
                        perDescricao
                    );

                _repositoryPerfilEN.Edit(perfilEN);
            }
            else
            {
                perfilEN = new PerfilEN
                    (
                        perDescricao
                    );

                _repositoryPerfilEN.Save(perfilEN);
            }

            _unitOfWork.Commit();
        }
    }
}
