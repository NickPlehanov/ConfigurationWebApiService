using ConfigurationWebApiService.CRUDModels;
using ConfigurationWebApiService.CRUDModels.Users;
using ConfigurationWebApiService.Models;

namespace ConfigurationWebApiService.Services.Users
{
    public interface IUserService
    {
        //IEnumerable<UserEditRemoveModel>? GetUsers();
        ResponseModel GetUsers();
        ResponseModel GetById(Guid id);
        ResponseModel Add(UserBase user);
        ResponseModel Update(UserEditRemoveModel user);
        ResponseModel Delete(Guid id);
    }
}
