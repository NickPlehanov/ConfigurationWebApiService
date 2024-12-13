using ConfigurationWebApiService.CRUDModels.Users;
using ConfigurationWebApiService.Services.SignalR;
using ModelUsers = ConfigurationWebApiService.Models.Users;

namespace ConfigurationWebApiService.Services.Users
{
    public class UserService(IRepository<Models.Users> iUserRepository) : IUserService, IBaseServiceLogic<ModelUsers>
    {
        public UserEditRemoveModel GetById(Guid id)
        {
            var user = iUserRepository.GetById(id) ?? throw new InvalidOperationException();

            return new UserEditRemoveModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Login = user.Login,
                Id = user.Id,
                IsActive = user.IsActive,
            };
        }

        public IList<UserEditRemoveModel> GetUsers()
        {
            return iUserRepository.GetAll().Select(x => new UserEditRemoveModel()
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                MiddleName = x.MiddleName,
                Login = x.Login,
                Id = x.Id,
                IsActive = x.IsActive,
            }).ToList();
        }

        public Guid Add(UserBase userAddModel)
        {
            ArgumentNullException.ThrowIfNull(userAddModel);
            ModelUsers user = new()
            {
                Id = Guid.NewGuid(),
                LastName = userAddModel.LastName,
                FirstName = userAddModel.FirstName,
                MiddleName = userAddModel.MiddleName,
                Login = userAddModel.Login,
                PasswordHash = "1", //TODO: нужна функция
                CreateDate = userAddModel.CreateDate,
                UpdateDate = userAddModel.UpdateDate,
                IsActive = userAddModel.IsActive
            };

            return iUserRepository.Add(user);
        }

        bool IUserService.Delete(Guid id)
        {
            ModelUsers foundUser = iUserRepository.GetById(id) ?? throw new InvalidOperationException();

            iUserRepository.Delete(id);
            return true;
        }

        bool IUserService.Update(UserEditRemoveModel userUpdateModel)
        {
            ArgumentNullException.ThrowIfNull(userUpdateModel);

            ModelUsers foundUser =
                iUserRepository.GetById(userUpdateModel.Id) ?? throw new InvalidOperationException();

            //Id = userUpdateModel.Id, незачем обновлять Id
            // TODO: в модели должны быть 
            foundUser.LastName = string.IsNullOrEmpty(userUpdateModel.LastName)
                ? foundUser.LastName
                : userUpdateModel.LastName;
            foundUser.FirstName = string.IsNullOrEmpty(userUpdateModel.FirstName)
                ? foundUser.FirstName
                : userUpdateModel.FirstName;
            foundUser.MiddleName = string.IsNullOrEmpty(userUpdateModel.MiddleName)
                ? foundUser.MiddleName
                : userUpdateModel.MiddleName;
            foundUser.Login = string.IsNullOrEmpty(userUpdateModel.Login) ? foundUser.Login : userUpdateModel.Login;
            foundUser.PasswordHash = "1"; //TODO: нужна функция
            foundUser.CreateDate =
                userUpdateModel.CreateDate == DateTime.MinValue ? foundUser.CreateDate : DateTime.Now;
            foundUser.UpdateDate = DateTime.Now;
            foundUser.IsActive = userUpdateModel.IsActive == foundUser.IsActive
                ? userUpdateModel.IsActive
                : foundUser.IsActive;

            iUserRepository.Update(foundUser);

            return true;
        }
    }
}