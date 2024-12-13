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
        [HttpGet("GetListUsers")]
        public ActionResult<IEnumerable<UserEditRemoveModel>> GetListUsers()
        {
            try
            {
                return Ok(_userService.GetUsers());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Получение пользователя по Id
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Пользователь</returns>
        [HttpGet("GetById")]
        public ActionResult<UserEditRemoveModel> GetById(Guid id)
        {
            try
            {
                return Ok(_userService.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Добавление пользователя
        /// </summary>
        /// <param name="user">Модель объекта пользователя</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("AddUser")]
        public ActionResult<Guid?> AddUser(Users user)
        {
            try
            {
                return Ok(_userService.Add(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Редактирование пользователя
        /// </summary>
        /// <param name = "user" > Модель объекта пользователя</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("EditUser")]
        public ActionResult<bool> EditUser(Users user)
        {
            try
            {
                return Ok(_userService.Update(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpGet("DeleteUser")]
        public ActionResult<bool> DeleteUser(Guid id)
        {
            try
            {
                return Ok(_userService.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
