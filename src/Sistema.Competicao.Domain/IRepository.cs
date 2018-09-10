namespace Sistema.Competicao.Domain
{
    public interface IRepository<TEntity>
    {
         TEntity GetByID(int id);
         void Save(TEntity entity);
    }
}