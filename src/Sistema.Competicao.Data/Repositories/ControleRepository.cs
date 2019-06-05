using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Sistema.Competicao.Domain.Entities.Cadastros;
using Sistema.Competicao.Domain.Entities.Controles;

namespace Sistema.Competicao.Data.Repositories
{
    public class ControleRepository : Repository<ControleEN>
    {
        public ControleRepository(DataBaseContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<ExpandoObject> ListaControlesPagamentos()
        {
            var query = (from CN in _dbContext.tblControle.Cast<ControleEN>()
                         join AT in _dbContext.tblAtleta.Cast<AtletaEN>() on CN.atlCodigo equals AT.atlCodigo
                         select new
                         {
                             CN.conCodigo,
                             AT.atlCodigo,
                             AT.atlNome,
                             CN.conDataInclusao,
                             CN.conValorPago,
                             CN.conDataPagto,
                             CN.conMesReferencia
                         }).ToList();

            var result = new List<ExpandoObject>();
            foreach (var item in query.ToList())
            {
                dynamic itemResult = new ExpandoObject();
                itemResult.conCodigo = item.conCodigo;
                itemResult.atlCodigo = item.atlCodigo;
                itemResult.atlNome = item.atlNome;
                itemResult.conDataInclusao = item.conDataInclusao;
                itemResult.conValorPago = item.conValorPago;
                itemResult.conDataPagto = item.conDataPagto;
                itemResult.conMesReferencia = item.conMesReferencia;

                result.Add(itemResult);
            };

            return result;
        }
    }
}
