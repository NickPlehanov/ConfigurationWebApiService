using ConfigurationWebApiService.CRUDModels;
using ConfigurationWebApiService.CRUDModels.Users;
using ConfigurationWebApiService.Models;
using ConfigurationWebApiService.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
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
        public ActionResult<ResponseModel<IList<UserEditRemoveModel>>> GetListUser()
        {
            var response = new ResponseModel<IList<UserEditRemoveModel>>();
            try
            {
                response.Value = userService.GetUsers();
                return Ok(response);
            }
            catch (Exception e)
            {
                response.Error = e.Message;
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Получение пользователя по Id
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Пользователь</returns>
        [HttpGet("GetById")]
        public ActionResult<ResponseModel<UserEditRemoveModel>> GetById(Guid id)
        {
            var result = new ResponseModel<UserEditRemoveModel>();
            try
            {
                result.Value = userService.GetById(id);
                result.StatusCode = 200;
                return Ok(result);
            }
            catch (InvalidOperationException e)
            {
                result.Error = "Пользователь не найден";
                return BadRequest(e);
            }
            catch (ArgumentNullException)
            {
                return NotFound(result);
            }
        }

        /// <summary>
        /// Добавление пользователя
        /// </summary>
        /// <param name="user">Модель объекта пользователя</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("AddUser")]
        public ActionResult<ResponseModel<Guid>> AddUser(Users user)
        {
            var resp = new ResponseModel<Guid>();
            if (!ModelState.IsValid)
            {
                resp.Error = ModelState.Select(x => x.Value?.Errors)
                    .Where(y => y != null && y.Count > 0)
                    .ToList();
                return BadRequest(resp);
            }

            try
            {
                resp.Value = userService.Add(user);
                return Ok(resp);
            }
            catch (Exception e)
            {
                resp.Error = e.Message;
                return BadRequest(resp);
            }
        }

        /// <summary>
        /// Редактирование пользователя
        /// </summary>
        /// <param name = "user" > Модель объекта пользователя</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("EditUser")]
        public ActionResult<ResponseModel<bool>> EditUser(Users user)
        {
            ResponseModel<bool> response = new ResponseModel<bool>();
            try
            {
                response.Value = userService.Update(user);
                return Ok(response);
            }
            catch (Exception e)
            {
                response.Error = e.Message;
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpGet("DeleteUser")]
        public ActionResult DeleteUser(Guid id)
        {
            var response = new ResponseModel<bool>();
            try
            {
                userService.Delete(id);
            }
            catch (Exception e)
            {
                response.Error = e.Message;
            }

            return Ok(response);
        }
    }
}