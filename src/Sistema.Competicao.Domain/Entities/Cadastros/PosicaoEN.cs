using System.ComponentModel.DataAnnotations;


namespace Sistema.Competicao.Domain.Entities.Cadastros
{
    public class PosicaoEN
    {
        [Key]
        public int posCodigo { get; set; }
        public string posDescricao { get; set; }
        public bool posGoleiro { get; set; }
        public bool posTecnico { get; set; }

        private PosicaoEN() { }

        public PosicaoEN(string posDescricao, bool posGoleiro, bool posTecnico)
        {
            ValidateAndSetProperties(posDescricao, posGoleiro, posTecnico);
        }

        public void UpdateProperties(string posDescricao, bool posGoleiro, bool posTecnico)
        {
            ValidateAndSetProperties(posDescricao, posGoleiro, posTecnico);
        }

        private void ValidateAndSetProperties(string posDescricao, bool posGoleiro, bool posTecnico)
        {
            DomainException.When(string.IsNullOrEmpty(posDescricao), "Descrição não informada.");

            this.posDescricao = posDescricao;
            this.posGoleiro = posGoleiro;
            this.posTecnico = posTecnico;
        }
    }
}
