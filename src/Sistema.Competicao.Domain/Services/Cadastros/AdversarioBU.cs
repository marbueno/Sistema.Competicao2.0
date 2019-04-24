using Sistema.Competicao.Domain.Entities.Cadastros;
using Sistema.Competicao.Domain.Interfaces;

namespace Sistema.Competicao.Domain.Services.Cadastros
{
    public class AdversarioBU
    {
        private readonly IRepository<AdversarioEN> _adversarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AdversarioBU(IRepository<AdversarioEN> adversarioRepository, IUnitOfWork unitOfWork)
        {
            _adversarioRepository = adversarioRepository;
            _unitOfWork = unitOfWork;
        }

        public void Save(int advCodigo, string advNome, string advResponsavel, int advDDD1, int advTelefone1, int advDDD2, int advTelefone2, int advDDD3, int advTelefone3, bool advComQuadra, int quaCodigo)
        {
            AdversarioEN adversarioEN = _adversarioRepository.GetByID(advCodigo);

            if (adversarioEN != null)
            {
                adversarioEN.UpdateProperties(
                                        advNome,
                                        advResponsavel,
                                        advDDD1,
                                        advTelefone1,
                                        advDDD2,
                                        advTelefone2,
                                        advDDD3,
                                        advTelefone3,
                                        advComQuadra,
                                        quaCodigo
                                    );

                _adversarioRepository.Edit(adversarioEN);
            }
            else
            {
                adversarioEN = new AdversarioEN(
                                        advNome,
                                        advResponsavel,
                                        advDDD1,
                                        advTelefone1,
                                        advDDD2,
                                        advTelefone2,
                                        advDDD3,
                                        advTelefone3,
                                        advComQuadra,
                                        quaCodigo
                                    );

                _adversarioRepository.Save(adversarioEN);
            }

            _unitOfWork.Commit();
        }
    }
}