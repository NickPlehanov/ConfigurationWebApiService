using ConfigurationWebApiService.Data;
using ConfigurationWebApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ConfigurationWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventSubscriptionController : ControllerBase
    {
        /// <summary>
        /// Получить список всех событий используемых в подписках пользователей
        /// </summary>
        /// <returns>Список событий</returns>
        [HttpGet("GetListEventSubscriptions")]
        public IEnumerable<EventSubscription>? GetListEventSubscriptions() => ((IBaseActionsForControllers)this).GetAll<EventSubscription>();
        [HttpGet("GetEventSubscriptionsById")]
        public EventSubscription? GetEventSubscriptionsById(Guid id) => ((IBaseActionsForControllers)this).GetById<EventSubscription>(id);
        [HttpGet("GetEventSubscriptionsByProperty")]
        public IEnumerable<EventSubscription>? GetEventSubscriptionsByProperty(string propertyName, string propertyValue) => ((IBaseActionsForControllers)this).GetByProperty<EventSubscription>(propertyName, propertyValue);
        /// <summary>
        /// Добавление нового события для подписки пользователей
        /// </summary>
        /// <param name="title">Название события</param>
        /// <param name="description">Описание события</param>
        /// <returns>Логическое значение об успешности/не успешности действия</returns>
        [HttpPost("AddConfiguration")]
        public bool AddEventSubscription(EventSubscription eventSubscription) => ((IBaseActionsForControllers)this).Add<EventSubscription>(new EventSubscription(eventSubscription));
        /// <summary>
        /// Редактирование события подписки пользователя.
        /// В случае если событие не будет найдено, то будет создано новое.
        /// </summary>
        /// <param name="eventSubscription">Модель типа Событие подписки пользователя</param>
        /// <returns>Логическое значение об успешности/не успешности действия</returns>
        [HttpPost("EditEventSubscription")]
        public bool EditEventSubscription(EventSubscription eventSubscription) => ((IBaseActionsForControllers)this).Update<EventSubscription>(new EventSubscription(eventSubscription));

        /// <summary>
        /// Удаление события подписки пользователя.
        /// </summary>
        /// <param name="id">Идентификатор события подписки пользователя</param>
        /// <returns>Логическое значение об успешности/не успешности действия</returns>
        [HttpPost("DeleteEventSubscriptionByID")]
        public bool DeleteEventSubscription(Guid id) => ((IBaseActionsForControllers)this).Remove<EventSubscription>(id);
        [HttpPost("DeleteAllEventSubscription")]
        public bool DeleteAllEventSubscription() => ((IBaseActionsForControllers)this).RemoveAll<EventSubscription>();
        [HttpPost("DeleteEventSubscriptionByProperty")]
        public bool DeleteEventSubscriptionByProperty(string propertyName, string propertyValue) => ((IBaseActionsForControllers)this).RemoveByProperty<EventSubscription>(propertyName, propertyValue);
    }
}
