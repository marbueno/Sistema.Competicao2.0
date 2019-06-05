using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Competicao.Domain.Entities.Cadastros
{    
    public class AtletaEN
    {
        [Key]
        public int atlCodigo { get; set; }
        public DateTime atlDataInclusao { get; set; }
        public string atlNome { get; set; }
        public double? atlCPF { get; set; }
        public string atlRG { get; set; }
        public DateTime atlDataNascimento { get; set; }
        public int posCodigo { get; set; }
        public int equCodigo { get; set; }
        public bool atlPrimeiroQuadro { get; set; }
        public bool atlSegundoQuadro { get; set; }
        public bool atlIsentoPagamento { get; set; }
        public string atlFoto { get; set; }

        public AtletaEN()
        {
            atlDataInclusao = DateTime.Now;
        }

        public AtletaEN(string atlNome, double atlCPF, string atlRG, DateTime atlDataNascimento, int posCodigo, int equCodigo, bool atlPrimeiroQuadro, bool atlSegundoQuadro, bool atlIsentoPagamento, string atlFoto)
        {
            ValidateAndSetProperties(atlNome, atlCPF, atlRG, atlDataNascimento, posCodigo, equCodigo, atlPrimeiroQuadro, atlSegundoQuadro, atlIsentoPagamento, atlFoto);
        }

        public void UpdateProperties(string atlNome, double atlCPF, string atlRG, DateTime atlDataNascimento, int posCodigo, int equCodigo, bool atlPrimeiroQuadro, bool atlSegundoQuadro, bool atlIsentoPagamento, string atlFoto)
        {
            ValidateAndSetProperties(atlNome, atlCPF, atlRG, atlDataNascimento, posCodigo, equCodigo, atlPrimeiroQuadro, atlSegundoQuadro, atlIsentoPagamento, atlFoto);
        }

        private void ValidateAndSetProperties(string atlNome, double atlCPF, string atlRG, DateTime atlDataNascimento, int posCodigo, int equCodigo, bool atlPrimeiroQuadro, bool atlSegundoQuadro, bool atlIsentoPagamento, string atlFoto)
        {
            DomainException.When(string.IsNullOrEmpty(atlNome), "Nome do Atleta não informado.");
            DomainException.When(atlDataNascimento == DateTime.MinValue, "Data de Nascimento não informada.");
            DomainException.When(posCodigo == 0, "Posição que o Atleta joga não informada.");
            DomainException.When(equCodigo == 0, "Equipe não informada.");

            this.atlDataInclusao = DateTime.Now;
            this.atlNome = atlNome;
            this.atlCPF = atlCPF;
            this.atlRG = atlRG;
            this.atlDataNascimento = atlDataNascimento;
            this.posCodigo = posCodigo;
            this.equCodigo = equCodigo;
            this.atlPrimeiroQuadro = atlPrimeiroQuadro;
            this.atlSegundoQuadro = atlSegundoQuadro;
            this.atlIsentoPagamento = atlIsentoPagamento;
            this.atlFoto = atlFoto;
        }
    }
}