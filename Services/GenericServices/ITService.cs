using ConfigurationWebApiService.CRUDModels.Users;

namespace ConfigurationWebApiService.Services.GenericServices
{
    public interface ITService<G> where G : class
    {
        //IEnumerable<UserEditRemoveModel>? GetUsers();
        //UserEditRemoveModel? GetById(Guid id);
        //Guid? Add(UserBase user);
        //bool Update(UserEditRemoveModel user);
        //bool Delete(Guid id);
        IEnumerable<G>? GetAll();
        G? GetById(Guid id);
        Guid? Add(G user);
        bool Update(G user);
        bool Delete(Guid id);
    }
}
