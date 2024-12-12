using ConfigurationWebApiService.CRUDModels;
using ConfigurationWebApiService.CRUDModels.Users;
using ConfigurationWebApiService.Data;
using ConfigurationWebApiService.Models;
using ConfigurationWebApiService.Services.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ConfigurationWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        //private readonly ITService<Users> _userService;
        //public UsersController(ITService<Users> userService)
        //{
        //    _userService = userService;
        //}

        /// <summary>
        /// Получение списка всех пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        [HttpGet("GetListUser")]
        //public IEnumerable<UserEditRemoveModel>? GetListUser()
        public ResponseModel GetListUser()
        {
            return _userService.GetUsers();
        }

        /// <summary>
        /// Получение пользователя по Id
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Пользователь</returns>
        [HttpGet("GetById")]
        public ResponseModel GetById(Guid id)
        {
            return _userService.GetById(id);
        }
        /// <summary>
        /// Добавление пользователя
        /// </summary>
        /// <param name="user">Модель объекта пользователя</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("AddUser")]
        public OkResult AddUser(Users user)
        {
            _userService.Add(user);
            return Ok();
        }

        /// <summary>
        /// Редактирование пользователя
        /// </summary>
        /// <param name = "user" > Модель объекта пользователя</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("EditUser")]
        public OkResult EditUser(Users user)
        {
            _userService.Update(user);
            return Ok();
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpGet("DeleteUser")]
        public OkResult DeleteUser(Guid id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}
