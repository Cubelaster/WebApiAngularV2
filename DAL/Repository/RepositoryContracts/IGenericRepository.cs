

namespace DAL.Repository.RepositoryContracts
{
    public interface IGenericRepository<TEntity>
    {
        TEntity GetById(int id);
        void Insert(TEntity entity);
        void Delete(int id);
        void SoftDelete(TEntity entityToDelete);
        void HardDelete(int id);
        void DeleteForever(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
    }
}
