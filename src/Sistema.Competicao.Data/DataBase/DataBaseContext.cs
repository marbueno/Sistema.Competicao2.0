using Microsoft.EntityFrameworkCore;
using Sistema.Competicao.Domain.Account;

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

        //public DbSet<QuadraEN> tblQuadra { get; set; }
        //public DbSet<AdversarioEN> tblAdversario { get; set; }
    }
}