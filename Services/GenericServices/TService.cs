using ConfigurationWebApiService.CRUDModels.Users;

namespace ConfigurationWebApiService.Services.GenericServices
{
    public class TService<G> : ITService<G> where G : class
    {
        private readonly IRepository<G> repository;
        public TService(IRepository<G> _repository)
        {
            repository = _repository;
        }
        public Guid? Add(G user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public G? GetById(Guid id)
        {
            var user = repository.GetById(id);
            if (user == null) return null;
            return user;
        }

        public IEnumerable<G>? GetAll()
        {
            var entityUsers = repository.GetAll();
            if (entityUsers == null) return [];
            if (!entityUsers.Any()) return [];
            return entityUsers;
        }

        public bool Update(G user)
        {
            throw new NotImplementedException();
        }
    }
}
