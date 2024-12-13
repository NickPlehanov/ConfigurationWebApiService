using ConfigurationWebApiService.CRUDModels;
using ConfigurationWebApiService.CRUDModels.Users;
using ConfigurationWebApiService.Models;

namespace ConfigurationWebApiService.Services.Users
{
    public interface IUserService
    {
        //IEnumerable<UserEditRemoveModel>? GetUsers();
        IList<UserEditRemoveModel> GetUsers();
        UserEditRemoveModel GetById(Guid id);
        Guid Add(UserBase user);
        bool Update(UserEditRemoveModel user);
        bool Delete(Guid id);
    }
}
