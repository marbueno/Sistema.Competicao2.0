namespace Sistema.Competicao.Domain
{
    public class AdversarioBU
    {
        private readonly IRepository<AdversarioEN> _adversarioRepository;
        private readonly IRepository<QuadraEN> _quadraRepository;
        
        public AdversarioBU(IRepository<AdversarioEN> adversarioRepository, IRepository<QuadraEN> quadraRepository)
        {
            _adversarioRepository = adversarioRepository;
            _quadraRepository = quadraRepository;
        }

        public void Save(int advCodigo, string advNome, string advResponsavel, int advDDD1, int advTelefone1, int advDDD2, int advTelefone2, int advDDD3, int advTelefone3, bool advComQuadra, int quaCodigo)
        {
            AdversarioEN adversarioEN = _adversarioRepository.GetByID(advCodigo);
            QuadraEN quadraEN = _quadraRepository.GetByID(quaCodigo);

            if (adversarioEN == null)
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
                                        quadraEN
                                    );

                _adversarioRepository.Save(adversarioEN);
            }
            else
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
                                        quadraEN
                                    );
            }
        }
    }
}