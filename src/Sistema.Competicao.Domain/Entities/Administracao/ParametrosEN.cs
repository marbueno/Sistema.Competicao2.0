using System.ComponentModel.DataAnnotations;

namespace Sistema.Competicao.Domain.Entities.Administracao
{
    public class ParametrosEN
    {
        [Key]
        public int parCodigo { get; set; }

        public bool parEsconderValorPagamentoSumula { get; set; }

        public string parCaminhoFotos { get; set; }

        public int parTamanhoFotos { get; set; }

        public string parExtensaoFotos { get; set; }

        public string parCaminhoFotosAtletas { get; set; }

        public int parTamanhoAlturaFotos { get; set; }

        public int parTamanhoLarguraFotos { get; set; }
        public int tipCodigo { get; set; }

        public ParametrosEN()
        {
            parEsconderValorPagamentoSumula = false;
            parTamanhoFotos = 500;
            parExtensaoFotos = "'jpg','jpeg','bmp','gif','png'";
        }

        public ParametrosEN(bool parEsconderValorPagamentoSumula, string parCaminhoFotos, int parTamanhoFotos, string parExtensaoFotos, string parCaminhoFotosAtletas, int parTamanhoAlturaFotos, int parTamanhoLarguraFotos, int tipCodigo)
        {
            ValidateAndSetProperties(parEsconderValorPagamentoSumula, parCaminhoFotos, parTamanhoFotos, parExtensaoFotos, parCaminhoFotosAtletas, parTamanhoAlturaFotos, parTamanhoLarguraFotos, tipCodigo);
        }

        public void UpdateProperties(bool parEsconderValorPagamentoSumula, string parCaminhoFotos, int parTamanhoFotos, string parExtensaoFotos, string parCaminhoFotosAtletas, int parTamanhoAlturaFotos, int parTamanhoLarguraFotos, int tipCodigo)
        {
            ValidateAndSetProperties(parEsconderValorPagamentoSumula, parCaminhoFotos, parTamanhoFotos, parExtensaoFotos, parCaminhoFotosAtletas, parTamanhoAlturaFotos, parTamanhoLarguraFotos, tipCodigo);
        }

        private void ValidateAndSetProperties(bool parEsconderValorPagamentoSumula, string parCaminhoFotos, int parTamanhoFotos, string parExtensaoFotos, string parCaminhoFotosAtletas, int parTamanhoAlturaFotos, int parTamanhoLarguraFotos, int tipCodigo)
        {
            DomainException.When(string.IsNullOrEmpty(parCaminhoFotos), "Caminho para exibição das fotos não informado.");
            DomainException.When(parTamanhoFotos == 0, "Tamanho máximo para upload das fotos não informado.");
            DomainException.When(string.IsNullOrEmpty(parCaminhoFotosAtletas), "Caminho para exibição das fotos dos atletas não informado.");
            DomainException.When(parTamanhoAlturaFotos == 0, "Tamanho da altura das fotos não informado.");
            DomainException.When(parTamanhoLarguraFotos == 0, "Tamanho da largura das fotos não informado.");
            DomainException.When(tipCodigo == 0, "Tipo de receita dos atletas não informado.");

            this.parEsconderValorPagamentoSumula = parEsconderValorPagamentoSumula;
            this.parCaminhoFotos = parCaminhoFotos;
            this.parTamanhoFotos = parTamanhoFotos;
            this.parExtensaoFotos = parExtensaoFotos;
            this.parCaminhoFotosAtletas = parCaminhoFotosAtletas;
            this.parTamanhoAlturaFotos = parTamanhoAlturaFotos;
            this.parTamanhoLarguraFotos = parTamanhoLarguraFotos;
            this.tipCodigo = tipCodigo;
        }
    }
}
