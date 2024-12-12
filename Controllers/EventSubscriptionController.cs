using ConfigurationWebApiService.Data;
using ConfigurationWebApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ConfigurationWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventSubscriptionController : BaseActionsForControllers
    {
        public EventSubscriptionController(ConfugurationManagerDbContext confugurationManagerDbContext) : base()
        {
        }

        ///// <summary>
        ///// Получить список всех событий используемых в подписках пользователей
        ///// </summary>
        ///// <returns>Список событий</returns>
        //[HttpGet("GetListEventSubscriptions")]
        //public IEnumerable<EventSubscription>? GetListEventSubscriptions() => GetAll<EventSubscription>();
        //[HttpGet("GetEventSubscriptionsById")]
        //public EventSubscription? GetEventSubscriptionsById(Guid id) => GetById<EventSubscription>(id);
        //[HttpGet("GetEventSubscriptionsByProperty")]
        //public IEnumerable<EventSubscription>? GetEventSubscriptionsByProperty(string propertyName, string propertyValue) => GetByProperty<EventSubscription>(propertyName, propertyValue);
        ///// <summary>
        ///// Добавление нового события для подписки пользователей
        ///// </summary>
        ///// <param name="title">Название события</param>
        ///// <param name="description">Описание события</param>
        ///// <returns>Логическое значение об успешности/не успешности действия</returns>
        //[HttpPost("AddConfiguration")]
        //public bool AddEventSubscription(EventSubscription eventSubscription) => Add<EventSubscription>(new EventSubscription(eventSubscription));
        ///// <summary>
        ///// Редактирование события подписки пользователя.
        ///// В случае если событие не будет найдено, то будет создано новое.
        ///// </summary>
        ///// <param name="eventSubscription">Модель типа Событие подписки пользователя</param>
        ///// <returns>Логическое значение об успешности/не успешности действия</returns>
        //[HttpPost("EditEventSubscription")]
        //public bool EditEventSubscription(EventSubscription eventSubscription) => Update<EventSubscription>(new EventSubscription(eventSubscription));

        ///// <summary>
        ///// Удаление события подписки пользователя.
        ///// </summary>
        ///// <param name="id">Идентификатор события подписки пользователя</param>
        ///// <returns>Логическое значение об успешности/не успешности действия</returns>
        //[HttpPost("DeleteEventSubscriptionByID")]
        //public bool DeleteEventSubscription(Guid id) => Remove<EventSubscription>(id);
        //[HttpPost("DeleteAllEventSubscription")]
        //public bool DeleteAllEventSubscription() => RemoveAll<EventSubscription>();
        //[HttpPost("DeleteEventSubscriptionByProperty")]
        //public bool DeleteEventSubscriptionByProperty(string propertyName, string propertyValue) => RemoveByProperty<EventSubscription>(propertyName, propertyValue);
    }
}
