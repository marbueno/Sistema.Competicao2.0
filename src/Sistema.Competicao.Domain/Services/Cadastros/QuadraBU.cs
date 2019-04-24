using Sistema.Competicao.Domain.Entities.Cadastros;
using Sistema.Competicao.Domain.Interfaces;

namespace Sistema.Competicao.Domain.Services.Cadastros
{
    public class QuadraBU
    {
        private readonly IRepository<QuadraEN> _quadraRepository;
        private readonly IUnitOfWork _unitOfWork;

        public QuadraBU(IRepository<QuadraEN> quadraRepository, IUnitOfWork unitOfWork)
        {
            _quadraRepository = quadraRepository;
            _unitOfWork = unitOfWork;
        }

        public void Save(int quaCodigo, string quaNome, string quaEndereco, int quaNumero, string quaBairro)
        {
            QuadraEN quadraEN = _quadraRepository.GetByID(quaCodigo);

            if (quadraEN != null)
            {
                quadraEN.UpdateProperties
                                (
                                    quaNome,
                                    quaEndereco,
                                    quaNumero,
                                    quaBairro
                                );

                _quadraRepository.Edit(quadraEN);
            }
            else
            {
                quadraEN = new QuadraEN
                                (
                                    quaNome,
                                    quaEndereco,
                                    quaNumero,
                                    quaBairro
                                );

                _quadraRepository.Save(quadraEN);
            }

            _unitOfWork.Commit();
        }
    }
}