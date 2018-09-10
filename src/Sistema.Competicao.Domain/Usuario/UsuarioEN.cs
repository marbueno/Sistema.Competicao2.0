using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Competicao.Domain
{
    public class UsuarioEN
    {
        [Key]
        public int usuCodigo { get; set; }
        public string usuNome { get; set; }
        public string usuLogin { get; set; }
        public string usuSenha { get; set; }
        public DateTime usuDataInclusao { get { return DateTime.Now; } }
        public int perCodigo { get; set; }

        public UsuarioEN(string usuNome, string usuLogin, string usuSenha, int perCodigo)
        {
            ValidateAndSetProperties(usuNome, usuLogin, usuSenha, perCodigo);
        }

        public void UpdateProperties(string usuNome, string usuLogin, string usuSenha, int perCodigo)
        {
            ValidateAndSetProperties(usuNome, usuLogin, usuSenha, perCodigo);
        }

        private void ValidateAndSetProperties(string usuNome, string usuLogin, string usuSenha, int perCodigo)
        {
            DomainException.When(string.IsNullOrEmpty(usuNome), "Nome do Usuário não informado.");
            DomainException.When(string.IsNullOrEmpty(usuLogin), "Login do Usuário não informado.");
            DomainException.When(string.IsNullOrEmpty(usuSenha), "Senha não informada.");

            this.usuNome = usuNome;
            this.usuLogin = usuLogin;
            this.usuSenha = usuSenha;
            this.perCodigo = perCodigo;
        }
    }
}
