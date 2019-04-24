namespace Sistema.Competicao.Web.Areas.Admin.Models.Administracao
{
    public class ParametrosVM
    {
        public int Codigo { get; set; }
        public bool EsconderValorPagamentoSumula { get; set; }
        public string CaminhoFotos { get; set; }
        public int TamanhoFotos { get; set; }
        public string ExtensaoFotos { get; set; }
        public string CaminhoFotosAtletas { get; set; }
        public int TamanhoAlturaFotos { get; set; }
        public int TamanhoLarguraFotos { get; set; }
        public int TipoReceita { get; set; }
    }
}
