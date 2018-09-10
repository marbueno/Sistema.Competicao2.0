using Sistema.Competicao.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Competicao.Data.Repositories
{
    public class UsuarioRepository : Repository<UsuarioEN>
    {
        public UsuarioRepository(DataBaseContext dbContext) : base(dbContext)
        {

        }

        public bool Authenticate(string usuLogin, string usuSenha)
        {
            return true;
        }
    }
}
