using ConfigurationWebApiService.Data;
using ConfigurationWebApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace ConfigurationWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionEventSubscriptionController : ControllerBase
    {
        /// <summary>
        /// Получение списка всех привязок событий подписок к подпискам
        /// </summary>
        /// <returns>Список шрифтов</returns>
        [HttpGet("GetListSubscriptionEventSubscriptions")]
        public IEnumerable<SubscriptionEventSubscription>? GetListSubscriptions() => ((IBaseActionsForControllers)this).GetAll<SubscriptionEventSubscription>();
        /// <summary>
        /// Получение привязки событий подписок к подпискам по идентификатору привязки
        /// </summary>
        /// <param name="id">Идентификатор подписки</param>
        /// <returns></returns>
        [HttpGet("GetSubscriptionEventSubscriptionById")]
        public SubscriptionEventSubscription? GetSubscriptionEventSubscriptionById(Guid id) => ((IBaseActionsForControllers)this).GetById<SubscriptionEventSubscription>(id);
        [HttpGet("GetSubscriptionEventSubscriptionByProperty")]
        public IEnumerable<SubscriptionEventSubscription>? GetSubscriptionEventSubscriptionByProperty(string propertyName, string propertyValue) => ((IBaseActionsForControllers)this).GetByProperty<SubscriptionEventSubscription>(propertyName,propertyValue);
        /// <summary>
        /// Добавление привязки событий подписки к подпискам
        /// </summary>
        /// <param name="subscriptionId">Идентификатор подписки</param>
        /// <param name="eventSubscriptionId">Идентификатор события подписки</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("AddSubscriptionEventSubscription")]
        public bool AddSubscriptionEventSubscription(SubscriptionEventSubscription subscriptionEventSubscription) => ((IBaseActionsForControllers)this).Add<SubscriptionEventSubscription>(new SubscriptionEventSubscription(subscriptionEventSubscription));
        /// <summary>
        /// Редактирование привязки событий подписки к подпискам
        /// </summary>
        /// <param name="subscriptionEventSubscription">Модель объекта подписки</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("EditSubscriptionEventSubscription")]
        public bool EditSubscriptionEventSubscription(SubscriptionEventSubscription subscriptionEventSubscription) => ((IBaseActionsForControllers)this).Update<SubscriptionEventSubscription>(new SubscriptionEventSubscription(subscriptionEventSubscription));
        /// <summary>
        /// Удаление привязки событий подписки к подпискам
        /// </summary>
        /// <param name="id">Идентификатор удаляемой связки</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("DeleteSubscriptionEventSubscriptionById")]
        public bool DeleteSubscriptionEventSubscription(Guid id) => ((IBaseActionsForControllers)this).Remove<SubscriptionEventSubscription>(id);
        /// <summary>
        /// Удаление всех событий подписки из подписки
        /// </summary>
        /// <param name="id">Идентификатор удаляемого шрифта</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("DeleteAllSubscriptionEventSubscription")]
        public bool DeleteAllSubscriptionEventSubscription() => ((IBaseActionsForControllers)this).RemoveAll<SubscriptionEventSubscription>();
        [HttpPost("DeleteSubscriptionEventSubscriptionByProperty")]
        public bool DeleteSubscriptionEventSubscriptionByProperty(string propertyName, string propertyValue) => ((IBaseActionsForControllers)this).RemoveByProperty    <SubscriptionEventSubscription>(propertyName,propertyValue);
    }
}
