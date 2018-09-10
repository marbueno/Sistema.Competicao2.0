namespace Sistema.Competicao.Domain
{
    public class QuadraBU
    {
        private readonly IRepository<QuadraEN> _quadraRepository;

        public QuadraBU(IRepository<QuadraEN> quadraRepository)
        {
            _quadraRepository = quadraRepository;
        }

        public void Save(int quaCodigo, string quaNome, string quaEndereco, int quaNumero, string quaBairro)
        {
            QuadraEN quadraEN = _quadraRepository.GetByID(quaCodigo);

            if (quadraEN == null)
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
            else
            {
                quadraEN.UpdateProperties
                                (
                                    quaNome, 
                                    quaEndereco, 
                                    quaNumero, 
                                    quaBairro
                                );
            }
        }
    }
}