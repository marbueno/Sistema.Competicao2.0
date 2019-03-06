namespace Sistema.Competicao.Domain
{
    public class UsuarioBU
    {
        private readonly IRepository<UsuarioEN> _repositoryUsuarioEN;

        public UsuarioBU (IRepository<UsuarioEN> repositoryUsuarioEN)
        {
            _repositoryUsuarioEN = repositoryUsuarioEN;
        }

        public void Save(int usuCodigo, string usuNome, string usuLogin, string usuEmail, string usuSenha, int perCodigo)
        {
            UsuarioEN usuarioEN = _repositoryUsuarioEN.GetByID(usuCodigo);

            if (usuarioEN != null)
            {
                usuarioEN.UpdateProperties
                    (
                        usuNome, 
                        usuarioEN.usuLogin,
                        usuEmail,
                        usuSenha, 
                        perCodigo
                    );
            }
            else
            {
                usuarioEN = new UsuarioEN
                    (
                        usuNome, 
                        usuLogin,
                        usuEmail,
                        usuSenha, 
                        perCodigo
                    );
            }

            _repositoryUsuarioEN.Save(usuarioEN);
        }
    }
}
