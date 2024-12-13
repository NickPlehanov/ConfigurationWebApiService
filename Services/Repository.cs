
using ConfigurationWebApiService.Data;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationWebApiService.Services
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly ConfugurationManagerDbContext _context;

        public Repository(ConfugurationManagerDbContext context)
        {
            _context = context;
        }
        public Guid Add(T entity)
        {
            var addedEntity = _context.Set<T>().Add(entity);
            Save();
            
                return Guid.Parse(addedEntity.Entity.GetType().GetProperty("Id").GetValue(addedEntity.Entity).ToString());
            
        }

        public void Delete(Guid id)
        {
            T entityToDelete = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(entityToDelete);
            Save();
        }

        public IEnumerable<T>? GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public T? GetById(Guid id)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }
        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
