using ConfigurationWebApiService.CRUDModels;
using ConfigurationWebApiService.CRUDModels.Users;
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
        public ResponseModel GetById(Guid id)
        {
            var resp= new ResponseModel();
            var user = _iUserRepository.GetById(id);
            if (user == null) return resp;
            resp.Value= new UserEditRemoveModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName ?? string.Empty,
                Login = user.Login,
                Id = user.Id,
                IsActive = user.IsActive,
            };
            resp.StatusCode = 1;
            resp.Message = "OK";
            return resp;
        }

        public ResponseModel GetUsers()
        {
            var resp = new ResponseModel();
            var entityUsers = _iUserRepository.GetAll();
            if (entityUsers == null) return resp;
            if(!entityUsers.Any()) return resp;
            resp.Value=entityUsers.Select(x => new UserEditRemoveModel()
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                MiddleName = x.MiddleName,
                Login = x.Login,
                Id = x.Id,
                IsActive = x.IsActive,
            });
            resp.StatusCode = resp.Value != null ? 1:-1;
            resp.Message= resp.Value!=null ? "OK": "ERROR";
            return resp;
        }

        public ResponseModel Add(UserBase userAddModel)
        {
            var resp = new ResponseModel();
            if (userAddModel == null)
                return resp;
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
            List<ValidationResult> validationResults;
            if (!IBaseServiceLogic<ModelUsers>.ModelValidator(user, out validationResults))
            {
                resp.Error = validationResults;
                return resp;
            }
            var result = _iUserRepository.Add(user);
            resp.Value=result;
            resp.Message = "OK";
            resp.StatusCode = 1;
            return resp;
        }

        ResponseModel IUserService.Delete(Guid id)
        {
            var resp = new ResponseModel();
            ModelUsers? findedUser = _iUserRepository.GetById(id);
            if (findedUser == null)
            {
                resp.Error = $"Пользователь с Id = {id} не найден.";
                return resp;
            }
            _iUserRepository.Delete(id);
            resp.Message = "OK";
            resp.StatusCode = 1;
            return resp;
        }

        ResponseModel IUserService.Update(UserEditRemoveModel userUpdateModel)
        {
            var resp = new ResponseModel();
            if (userUpdateModel == null)
            {
                resp.Error = $"Пустая модель для обновления пользователя";
                return resp;
            }
            ModelUsers? findedUser = _iUserRepository.GetById(userUpdateModel.Id);
            if (findedUser == null)
            {
                resp.Error = $"Пользователь с Id = {userUpdateModel.Id} не найден.";
                return resp;
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
            List<ValidationResult> validationResults;
            if (!IBaseServiceLogic<ModelUsers>.ModelValidator(user, out validationResults))
            {
                resp.Error = validationResults;
                return resp;
            }
            _iUserRepository.Update(user);
            resp.Message = "OK";
            resp.StatusCode = 1;
            return resp;
        }
    }
}
