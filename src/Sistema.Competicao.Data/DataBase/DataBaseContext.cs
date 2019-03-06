using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sistema.Competicao.Domain;

namespace Sistema.Competicao.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbSet<UsuarioEN> tblUsuario { get; set; }
        public DbSet<QuadraEN> tblQuadra { get; set; }
        //public DbSet<AdversarioEN> tblAdversario { get; set; }
    }
}