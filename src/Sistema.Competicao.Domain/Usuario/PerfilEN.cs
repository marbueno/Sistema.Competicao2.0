using System;
using System.ComponentModel.DataAnnotations;


namespace Sistema.Competicao.Domain
{
    public class PerfilEN
    {
        [Key]
        public int perCodigo { get; set; }
        public string perDescricao { get; set; }

        private PerfilEN() { }

        public PerfilEN(string perDescricao)
        {
            ValidateAndSetProperties(perDescricao);
        }

        public void UpdateProperties(string perDescricao)
        {
            ValidateAndSetProperties(perDescricao);
        }

        private void ValidateAndSetProperties(string perDescricao)
        {
            DomainException.When(string.IsNullOrEmpty(perDescricao), "Descrição do Perfil não informado.");

            this.perDescricao = perDescricao;
        }
    }
}
