using Microsoft.EntityFrameworkCore;
using Sistema.Competicao.Domain.Entities.Account;
using Sistema.Competicao.Domain.Entities.Administracao;
using Sistema.Competicao.Domain.Entities.Cadastros;
using Sistema.Competicao.Domain.Entities.Controles;

namespace Sistema.Competicao.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        #region Account

        public DbSet<UsuarioEN> tblUsuario { get; set; }
        public DbSet<PerfilEN> tblPerfil { get; set; }

        #endregion Account

        #region Administracao

        public DbSet<ParametrosEN> tblParametros { get; set; }

        #endregion Administracao

        #region Cadastros

        public DbSet<AdversarioEN> tblAdversario { get; set; }
        public DbSet<EquipeEN> tblEquipe { get; set; }
        public DbSet<PosicaoEN> tblPosicao { get; set; }
        public DbSet<QuadraEN> tblQuadra { get; set; }

        #endregion Cadastros

        #region Controles

        public DbSet<TipoDespesaReceitaEN> tblTipoDespesaReceita { get; set; }

        #endregion Controles
    }
}