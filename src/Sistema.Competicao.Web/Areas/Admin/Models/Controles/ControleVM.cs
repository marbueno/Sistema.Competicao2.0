using System;

namespace Sistema.Competicao.Web.Areas.Admin.Models.Controles
{
    public class ControleVM
    {
        public int Codigo { get; set; }
        public int Atleta { get; set; }
        public string NomeAtleta { get; set; }
        public decimal ValorPago { get; set; }
        public string ValorPagoFormatado { get; set; }
        public DateTime DataPagto { get; set; }
        public string DataPagtoFormatada { get; set; }
        public int MesReferencia { get; set; }
        public string MesReferenciaDescricao { get; set; }
    }
}
