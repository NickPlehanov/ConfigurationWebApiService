using ConfigurationWebApiService.CRUDModels;
using ConfigurationWebApiService.CRUDModels.Users;
using ConfigurationWebApiService.Models;
using ConfigurationWebApiService.Services.SignalR;
using System.ComponentModel.DataAnnotations;
using ModelUsers = ConfigurationWebApiService.Models.Users;

namespace ConfigurationWebApiService.Services.Users
{
    public class UserService : IUserService, IBaseServiceLogic<ModelUsers>
    {
        private readonly IRepository<Models.Users> _iUserRepository;
        public UserService(IRepository<Models.Users> iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }
        public UserEditRemoveModel? GetById(Guid id)
        {
            var user = _iUserRepository.GetById(id);
            return user != null ? new UserEditRemoveModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName ?? string.Empty,
                Login = user.Login,
                Id = user.Id,
                IsActive = user.IsActive,
            } : null;
        }

        public IEnumerable<UserEditRemoveModel> GetUsers()
        {
            return _iUserRepository.GetAll().Select(x => new UserEditRemoveModel()
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                MiddleName = x.MiddleName,
                Login = x.Login,
                Id = x.Id,
                IsActive = x.IsActive,
            }).AsEnumerable();
        }

        public Guid? Add(UserBase userAddModel)
        {
            if (userAddModel == null)
                return null;
            ModelUsers user = new()
            {
                Id = Guid.NewGuid(),
                LastName = userAddModel.LastName,
                FirstName = userAddModel.FirstName,
                MiddleName = userAddModel.MiddleName,
                Login = userAddModel.Login,
                PasswordHash = "1",//TODO: нужна функция
                CreateDate = userAddModel.CreateDate,
                UpdateDate = userAddModel.UpdateDate,
                IsActive = userAddModel.IsActive
            };
            if (!IBaseServiceLogic<ModelUsers>.ModelValidator(user, out List<ValidationResult> validationResults))
            {
                //TODO: логировать надо
                return null;
            }
            IBaseServiceLogic<ModelUsers>.ObjectWasBeChanged<ModelUsers>(new Models.EntityChangedEventArgs<ModelUsers>(user, EntityAction.Add, ""));
            return _iUserRepository.Add(user);
        }

        bool IUserService.Delete(Guid id)
        {
            ModelUsers? findedUser = _iUserRepository.GetById(id);
            if (findedUser == null)
            {
                return false;
            }
            _iUserRepository.Delete(id);
            IBaseServiceLogic<ModelUsers>.ObjectWasBeChanged<ModelUsers>(new Models.EntityChangedEventArgs<ModelUsers>(null, EntityAction.Remove, ""));
            return true;
        }

        bool IUserService.Update(UserEditRemoveModel userUpdateModel)
        {
            var resp = new ResponseModel();
            if (userUpdateModel == null)
            {
                return false;
            }
            ModelUsers? findedUser = _iUserRepository.GetById(userUpdateModel.Id);
            if (findedUser == null)
            {
                return false;
            }
            ModelUsers user = new()
            {
                Id = userUpdateModel.Id,
                LastName = string.IsNullOrEmpty(userUpdateModel.LastName) ? findedUser.LastName : userUpdateModel.LastName,
                FirstName = string.IsNullOrEmpty(userUpdateModel.FirstName) ? findedUser.FirstName : userUpdateModel.FirstName,
                MiddleName = string.IsNullOrEmpty(userUpdateModel.MiddleName) ? findedUser.MiddleName : userUpdateModel.MiddleName,
                Login = string.IsNullOrEmpty(userUpdateModel.Login) ? findedUser.Login : userUpdateModel.Login,
                PasswordHash = "1",//TODO: нужна функция
                CreateDate = userUpdateModel.CreateDate == DateTime.MinValue ? findedUser.CreateDate : DateTime.Now,
                UpdateDate = DateTime.Now,
                IsActive = userUpdateModel.IsActive == findedUser.IsActive ? userUpdateModel.IsActive : findedUser.IsActive,
            };
            if (!IBaseServiceLogic<ModelUsers>.ModelValidator(user, out List<ValidationResult> validationResults))
            {
                return false;
            }
            _iUserRepository.Update(user);
            IBaseServiceLogic<ModelUsers>.ObjectWasBeChanged<ModelUsers>(new Models.EntityChangedEventArgs<ModelUsers>(user, EntityAction.Update, ""));
            return true;
        }
    }
}
