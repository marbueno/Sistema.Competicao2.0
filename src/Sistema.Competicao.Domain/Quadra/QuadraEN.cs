using System.ComponentModel.DataAnnotations;

namespace Sistema.Competicao.Domain
{
    public class QuadraEN
    {
        [Key]
        public int quaCodigo { get; set; }
        public string quaNome { get; set; }
        public string quaEndereco { get; set; }
        public int quaNumero { get; set; }
        public string quaBairro { get; set; }
        
        public QuadraEN (string quaNome, string quaEndereco, int quaNumero, string quaBairro) 
        {
            ValidateAndSetProperties(quaNome, quaEndereco, quaNumero, quaBairro);
        }

        public void UpdateProperties (string quaNome, string quaEndereco, int quaNumero, string quaBairro) 
        {
            ValidateAndSetProperties(quaNome, quaEndereco, quaNumero, quaBairro);
        }

        private void ValidateAndSetProperties (string quaNome, string quaEndereco, int quaNumero, string quaBairro) 
        {
            DomainException.When(string.IsNullOrEmpty(quaNome), "Nome da Quadra não informado.");
            DomainException.When(string.IsNullOrEmpty(quaEndereco), "Endereço da Quadra não informado.");
            DomainException.When(string.IsNullOrEmpty(quaBairro), "Bairro da Quadra não informado.");

            this.quaNome = quaNome;
            this.quaEndereco = quaEndereco;
            this.quaNumero = quaNumero;
            this.quaBairro = quaBairro;
        }
    }
}