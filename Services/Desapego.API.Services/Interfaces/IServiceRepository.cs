namespace Desapego.API.Services.Interfaces
{
    internal interface IServiceRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(string Id);

        Task Create(TEntity entity);

        Task Update(string Id, TEntity entity);

        Task Delete(string Id);
    }
}
