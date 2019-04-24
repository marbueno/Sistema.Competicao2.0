using System.ComponentModel.DataAnnotations;


namespace Sistema.Competicao.Domain.Entities.Controles
{
    public class TipoDespesaReceitaEN
    {
        [Key]
        public int tipCodigo { get; set; }
        public string tipDescricao { get; set; }
        public string tipDespesaReceita { get; set; }

        private TipoDespesaReceitaEN() { }

        public TipoDespesaReceitaEN(string tipDescricao, string tipDespesaReceita)
        {
            ValidateAndSetProperties(tipDescricao, tipDespesaReceita);
        }

        public void UpdateProperties(string tipDescricao, string tipDespesaReceita)
        {
            ValidateAndSetProperties(tipDescricao, tipDespesaReceita);
        }

        private void ValidateAndSetProperties(string tipDescricao, string tipDespesaReceita)
        {
            DomainException.When(string.IsNullOrEmpty(tipDescricao), "Descrição não informada.");
            DomainException.When(string.IsNullOrEmpty(tipDespesaReceita), "Despesa / Receita não informada.");

            this.tipDescricao = tipDescricao;
            this.tipDespesaReceita = tipDespesaReceita;
        }
    }
}
