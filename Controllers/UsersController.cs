using ConfigurationWebApiService.Data;
using ConfigurationWebApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ConfigurationWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase, IBaseActionsForControllers
    {
        /// <summary>
        /// Получение списка всех пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        [HttpGet("GetListUser")]
        public IEnumerable<Users>? GetListUser() => ((IBaseActionsForControllers)this).GetAll<Users>();
        /// <summary>
        /// Получение пользователя по Id
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Пользователь</returns>
        [HttpGet("GetById")]
        public Users? GetById(Guid id) => ((IBaseActionsForControllers)this).GetById<Users>(id);
        /// <summary>
        /// Получение информации о пользователе
        /// </summary>
        /// <param name="propertyName">Наименование поля для поиска</param>
        /// <param name="propertyValue">Искомое значение</param>
        /// <returns></returns>
        [HttpGet("GetUser")]
        public IEnumerable<Users>? GetUser(string propertyName, string propertyValue) => ((IBaseActionsForControllers)this).GetByProperty<Users>(propertyName: propertyName, propertyValue: propertyValue);
        /// <summary>
        /// Блокировка пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("BlockUser")]
        public bool BlockUser(Guid id)
        {
            var user = ((IBaseActionsForControllers)this).GetById<Users>(id);
            if (user != null)
            {
                user.IsActive = false;
                return ((IBaseActionsForControllers)this).Update<Users>(new Users(user));
            }
            else
                return false;
        }
        /// <summary>
        /// Разблокировка пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("UnblockUser")]
        public bool UnblockUser(Guid id)
        {
            var user = ((IBaseActionsForControllers)this).GetById<Users>(id);
            if (user != null)
            {
                user.IsActive = true;
                return ((IBaseActionsForControllers)this).Update<Users>(new Users(user));
            }
            else
                return false;
        }
        /// <summary>
        /// Добавление пользователя
        /// </summary>
        /// <param name="user">Модель объекта пользователя</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("AddUser")]
        public bool AddUser(Users user) => ((IBaseActionsForControllers)this).Add<Users>(new Users(user));
        /// <summary>
        /// Редактирование пользователя
        /// </summary>
        /// <param name="user">Модель объекта пользователя</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("EditUser")]
        public bool EditUser(Users user) => ((IBaseActionsForControllers)this).Update<Users>(new Users(user));
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("DeleteUser")]
        public bool DeleteUser(Guid id) => ((IBaseActionsForControllers)this).Remove<Users>(id);
    }
}
