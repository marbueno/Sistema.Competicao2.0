using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Competicao.Domain.Entities.Cadastros
{
    public class EquipeEN
    {
        [Key]
        public int equCodigo { get; set; }
        public string equNome { get; set; }
        public string equResponsavel { get; set; }
        public DateTime equDataFundacao { get; set; }
        public int? equDDD1 { get; set; }
        public int? equTelefone1 { get; set; }
        public int? equDDD2 { get; set; }
        public int? equTelefone2 { get; set; }
        public bool equComQuadra { get; set; }
        public int? quaCodigo { get; set; }
        public DateTime equDataInclusao { get; set; }
        public string equHorario { get; set; }

        public EquipeEN()
        {
            equDataInclusao = DateTime.Now;
            equDDD2 = 0;
            equTelefone2 = 0;
            quaCodigo = 0;
        }

        public EquipeEN(string equNome, string equResponsavel, DateTime equDataFundacao, int equDDD1, int equTelefone1, int equDDD2, int equTelefone2, bool equComQuadra, int quaCodigo, string equHorario)
        {
            ValidateAndSetProperties(equNome, equResponsavel, equDataFundacao, equDDD1, equTelefone1, equDDD2, equTelefone2, equComQuadra, quaCodigo, equHorario);
        }

        public void UpdateProperties(string equNome, string equResponsavel, DateTime equDataFundacao, int equDDD1, int equTelefone1, int equDDD2, int equTelefone2, bool equComQuadra, int quaCodigo, string equHorario)
        {
            ValidateAndSetProperties(equNome, equResponsavel, equDataFundacao, equDDD1, equTelefone1, equDDD2, equTelefone2, equComQuadra, quaCodigo, equHorario);
        }

        private void ValidateAndSetProperties(string equNome, string equResponsavel, DateTime equDataFundacao, int equDDD1, int equTelefone1, int equDDD2, int equTelefone2, bool equComQuadra, int quaCodigo, string equHorario)
        {
            DomainException.When(string.IsNullOrEmpty(equNome), "Nome do Adversário não informado.");
            DomainException.When(string.IsNullOrEmpty(equResponsavel), "Nome do Responsável não informado.");
            DomainException.When(equDDD1 == 0, "DDD não informado.");
            DomainException.When(equTelefone1 == 0, "Telefone não informado.");
            DomainException.When(equDataFundacao == DateTime.MinValue, "Data da Fundação não informada.");

            this.equDataInclusao = DateTime.Now;
            this.equNome = equNome;
            this.equResponsavel = equResponsavel;
            this.equDataFundacao = equDataFundacao;
            this.equDDD1 = equDDD1;
            this.equTelefone1 = equTelefone1;
            this.equDDD2 = equDDD2;
            this.equTelefone2 = equTelefone2;
            this.equComQuadra = equComQuadra;
            this.quaCodigo = quaCodigo;
            this.equHorario = equHorario;
        }
    }
}
