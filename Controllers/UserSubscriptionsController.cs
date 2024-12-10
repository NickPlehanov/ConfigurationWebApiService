using ConfigurationWebApiService.Data;
using ConfigurationWebApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSubscriptionsController : ControllerBase
    {
        /// <summary>
        /// Получение списка всех подписок всех пользователей
        /// </summary>
        /// <returns>Список подписок</returns>
        [HttpGet("GetListUserSubscriptions")]
        public IEnumerable<UserSubscriptions>? GetListUserSubscriptions() => ((IBaseActionsForControllers)this).GetAll<UserSubscriptions>();
        /// <summary>
        /// Получение подписки пользователя по идентификатору
        /// </summary>
        /// <param name="fontId">Идентификатор шрифта</param>
        /// <returns></returns>
        [HttpGet("GetListUserSubscriptionsById")]
        public UserSubscriptions? GetListUserSubscriptionsById(Guid id) => ((IBaseActionsForControllers)this).GetById<UserSubscriptions>(id);
        [HttpGet("GetListUserSubscriptionsByProperty")]
        public IEnumerable<UserSubscriptions>? GetListUserSubscriptionsByProperty(string propertyName, string propertyValue) => ((IBaseActionsForControllers)this).GetByProperty<UserSubscriptions>(propertyName, propertyValue);
        /// <summary>
        /// Добавление подписки пользователю
        /// </summary>
        /// <param name="userSubscriptions">Модель объекта пользовательской подписки</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("AddUserSubscriptions")]
        public bool AddUserSubscriptions(UserSubscriptions userSubscriptions) => ((IBaseActionsForControllers)this).Add<UserSubscriptions>(new UserSubscriptions(userSubscriptions));
        /// <summary>
        /// Редактирование подписки пользователю
        /// </summary>
        /// <param name="userSubscriptions">Модель объекта пользовательской подписки</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("EditUserSubscriptions")]
        public bool EditUserSubscriptions(UserSubscriptions userSubscriptions) => ((IBaseActionsForControllers)this).Update<UserSubscriptions>(new UserSubscriptions(userSubscriptions));
        /// <summary>
        /// Удаление подписки пользователя
        /// </summary>
        /// <param name="id">Идентификатор подписки пользователя</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("DeleteUserSubscriptions")]
        public bool DeleteUserSubscriptions(Guid id) => ((IBaseActionsForControllers)this).Remove<UserSubscriptions>(id);
        /// <summary>
        /// Активация подписки пользователя
        /// </summary>
        /// <param name="id">Идентификатор подписки пользователя</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("ActivateUserSubscription")]
        public bool ActivateUserSubscription(Guid id)
        {
            var obj = ((IBaseActionsForControllers)this).GetById<UserSubscriptions>(id);
            if (obj != null)
            {
                obj.IsActive = true;
                return ((IBaseActionsForControllers)this).Update<UserSubscriptions>(new UserSubscriptions(obj));
            }
            else return false;
        }
        /// <summary>
        /// Деактивация подписки пользователя
        /// </summary>
        /// <param name="id">Идентификатор подписки пользователя</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("DeactivateUserSubscription")]
        public bool DeactivateUserSubscription(Guid id)
        {
            var obj = ((IBaseActionsForControllers)this).GetById<UserSubscriptions>(id);
            if (obj != null)
            {
                obj.IsActive = false;
                return ((IBaseActionsForControllers)this).Update<UserSubscriptions>(new UserSubscriptions(obj));
            }
            else return false;
        }
        [HttpPost("DeleteUserSubscription")]
        public bool DeleteUserSubscription(string propertyName, string propertyValue) => ((IBaseActionsForControllers)this).RemoveByProperty<UserSubscriptions>(propertyName, propertyValue);
        [HttpPost("DeleteUserSubscriptionById")]
        public void DeleteUserSubscriptionById(Guid id) => ((IBaseActionsForControllers)this).Remove<UserSubscriptions>(id);
        [HttpPost("DeleteAllUserSubscription")]
        public void DeleteAllUserSubscription() => ((IBaseActionsForControllers)this).RemoveAll<UserSubscriptions>();
    }
}
