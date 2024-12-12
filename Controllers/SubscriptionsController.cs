using ConfigurationWebApiService.Data;
using ConfigurationWebApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : BaseActionsForControllers
    {
        public SubscriptionsController(ConfugurationManagerDbContext confugurationManagerDbContext) : base()
        {
        }

        ///// <summary>
        ///// Получение списка всех подписок
        ///// </summary>
        ///// <returns>Список шрифтов</returns>
        //[HttpGet("GetListSubscriptions")]
        //public IEnumerable<Subscriptions>? GetListSubscriptions() => GetAll<Subscriptions>();
        ///// <summary>
        ///// Получение подписки по её идентификатору
        ///// </summary>
        ///// <param name="fontId">Идентификатор подписки</param>
        ///// <returns></returns>
        //[HttpGet("GetSubscriptionsById")]
        //public Subscriptions? GetSubscriptionsById(Guid id) => GetById<Subscriptions>(id);
        //[HttpGet("GetListSubscriptionsByProperty")]
        //public IEnumerable<Subscriptions>? GetListSubscriptionsByProperty(string propertyName, string propertyValue) => GetByProperty<Subscriptions>(propertyName,propertyValue);
        ///// <summary>
        ///// Добавление подписки
        ///// </summary>
        ///// <param name="title">Наименование шрифта</param>
        ///// <param name="description">Описание шрифта</param>
        ///// <param name="value">Значение шрифта</param>
        ///// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        //[HttpPost("AddSubscription")]
        //public bool AddSubscription(Subscriptions subscription) => Add<Subscriptions>(new Subscriptions(subscription));
        ///// <summary>
        ///// Редактирование подписки
        ///// </summary>
        ///// <param name="subscription">Модель объекта подписки</param>
        ///// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        //[HttpPost("EditSubscription")]
        //public bool EditSubscription(Subscriptions subscription) => Update<Subscriptions>(new Subscriptions(subscription));
        ///// <summary>
        ///// Удаление подписки
        ///// </summary>
        ///// <param name="id">Идентификатор удаляемого шрифта</param>
        ///// <returns></returns>
        //[HttpPost("DeleteSubscriptionById")]
        //public bool DeleteSubscriptionById(Guid id) => Remove<Subscriptions>(id);
        //[HttpPost("DeleteSubscriptionByProperty")]
        //public bool DeleteSubscriptionByProperty(string propertyName, string propertyValue) => RemoveByProperty<Subscriptions>(propertyName,propertyValue);
        //[HttpPost("DeleteAllSubscriptions")]
        //public bool DeleteAllSubscriptions() => RemoveAll<Subscriptions>();
    }
}
