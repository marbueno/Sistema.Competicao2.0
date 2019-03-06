namespace Sistema.Competicao.Domain
{
    public class PerfilBU
    {
        private readonly IRepository<PerfilEN> _repositoryPerfilEN;

        public PerfilBU(IRepository<PerfilEN> repositoryPerfilEN)
        {
            _repositoryPerfilEN = repositoryPerfilEN;
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
            }
            else
            {
                perfilEN = new PerfilEN
                    (
                        perDescricao
                    );
            }

            _repositoryPerfilEN.Save(perfilEN);
        }
    }
}
