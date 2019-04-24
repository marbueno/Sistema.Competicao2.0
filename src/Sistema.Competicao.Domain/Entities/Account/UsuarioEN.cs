using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Competicao.Domain.Entities.Account
{
    public class UsuarioEN
    {
        [Key]
        public int usuCodigo { get; set; }
        public string usuNome { get; set; }
        public string usuLogin { get; set; }
        public string usuEmail { get; set; }
        public string usuSenha { get; set; }
        public DateTime usuDataInclusao { get { return DateTime.Now; } }
        public int perCodigo { get; set; }

        private UsuarioEN() { }

        public UsuarioEN(string usuNome, string usuLogin, string usuEmail, string usuSenha, int perCodigo)
        {
            ValidateAndSetProperties(usuNome, usuLogin, usuEmail, usuSenha, perCodigo);
        }

        public void UpdateProperties(string usuNome, string usuLogin, string usuEmail, string usuSenha, int perCodigo)
        {
            ValidateAndSetProperties(usuNome, usuLogin, usuEmail, usuSenha, perCodigo);
        }

        private void ValidateAndSetProperties(string usuNome, string usuLogin, string usuEmail, string usuSenha, int perCodigo)
        {
            DomainException.When(string.IsNullOrEmpty(usuNome), "Nome do Usuário não informado.");
            DomainException.When(string.IsNullOrEmpty(usuLogin), "Login do Usuário não informado.");
            DomainException.When(string.IsNullOrEmpty(usuEmail), "E-mail não informado.");
            DomainException.When(string.IsNullOrEmpty(usuSenha), "Senha não informada.");
            DomainException.When(perCodigo == 0, "Perfil não informado.");

            this.usuNome = usuNome;
            this.usuLogin = usuLogin;
            this.usuEmail = usuEmail;
            this.usuSenha = usuSenha;
            this.perCodigo = perCodigo;
        }
    }
}
