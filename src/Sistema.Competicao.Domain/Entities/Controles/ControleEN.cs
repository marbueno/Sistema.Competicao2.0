using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Competicao.Domain.Entities.Controles
{
    public class ControleEN
    {
        [Key]
        public int conCodigo { get; set; }
        public DateTime conDataInclusao { get; set; }
        public int atlCodigo { get; set; }
        public decimal conValorPago { get; set; }
        public DateTime conDataPagto { get; set; }
        public int conMesReferencia { get; set; }

        private ControleEN()
        {
            conDataInclusao = DateTime.Now;
            conValorPago = 0;
            conMesReferencia = DateTime.Now.Month;
        }

        public ControleEN(int atlCodigo, decimal conValorPago, DateTime conDataPagto, int conMesReferencia)
        {
            ValidateAndSetProperties(atlCodigo, conValorPago, conDataPagto, conMesReferencia);
        }

        public void UpdateProperties(int atlCodigo, decimal conValorPago, DateTime conDataPagto, int conMesReferencia)
        {
            ValidateAndSetProperties(atlCodigo, conValorPago, conDataPagto, conMesReferencia);
        }

        private void ValidateAndSetProperties(int atlCodigo, decimal conValorPago, DateTime conDataPagto, int conMesReferencia)
        {
            DomainException.When(atlCodigo == 0, "Atleta não informado.");
            DomainException.When(conValorPago == 0, "Valor Pago não informado.");
            DomainException.When(conDataPagto == DateTime.MinValue, "Descrição não informada.");
            DomainException.When(conMesReferencia == 0, "Mês de Referência não informado.");

            this.atlCodigo = atlCodigo;
            this.conValorPago = conValorPago;
            this.conDataPagto = conDataPagto;
            this.conMesReferencia = conMesReferencia;
        }
    }
}
