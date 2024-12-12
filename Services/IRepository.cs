namespace ConfigurationWebApiService.Services
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T>? GetAll();
        T? GetById(Guid id);
        Guid? Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}
