using System.ComponentModel.DataAnnotations;


namespace Sistema.Competicao.Domain.Account
{
    public class PerfilEN
    {
        [Key]
        public int perCodigo { get; set; }
        public string perNome { get; set; }

        private PerfilEN() { }

        public PerfilEN(string perNome)
        {
            ValidateAndSetProperties(perNome);
        }

        public void UpdateProperties(string perNome)
        {
            ValidateAndSetProperties(perNome);
        }

        private void ValidateAndSetProperties(string perNome)
        {
            DomainException.When(string.IsNullOrEmpty(perNome), "Nome do Perfil não informado.");

            this.perNome = perNome;
        }
    }
}
