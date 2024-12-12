using ConfigurationWebApiService.Data;
using ConfigurationWebApiService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ConfigurationWebApiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigurationController : BaseActionsForControllers
    {
        public ConfigurationController(ConfugurationManagerDbContext confugurationManagerDbContext) : base()
        {
        }

        ///// <summary>
        ///// Получить список всех конфигураций
        ///// </summary>
        ///// <returns>Список всех конфигураций</returns>
        //[HttpGet("GetListConfigurations")]
        //public IEnumerable<Configurations>? GetListConfigurations() => GetAll<Configurations>();
        ///// <summary>
        ///// Получение конфигурации по заданному условию
        ///// </summary>
        ///// <param name="propertyName">Наименование свойства для поиска</param>
        ///// <param name="propertyValue">Значение</param>
        ///// <returns>Список цветовых конфигураций</returns>
        //[HttpGet("GetListConfigurationsByProperty")]
        //public IEnumerable<Configurations>? GetListConfigurationsByProperty(string propertyName, string propertyValue) => GetByProperty<Configurations>(propertyName, propertyValue);
        ///// <summary>
        ///// Получить конфигурацию по идентификатору
        ///// </summary>
        ///// <param name="id">Идентификатор пользователя</param>
        ///// <returns>Список всех конфигураций пользователя</returns>
        //[HttpGet("GetById")]
        //public Configurations? GetConfigurationsByUser(Guid id) => GetById<Configurations>(id);
        ///// <summary>
        ///// Добавление новой конфигурации
        ///// </summary>
        ///// <param name="title">Наименование конфигурации</param>
        ///// <param name="description">Описание конфигурации</param>
        ///// <returns>Логическое значение об успешности/не успешности действия</returns>
        //[HttpPost("AddConfiguration")]
        //public bool AddConfiguration(Configurations configuration) => Add<Configurations>(new Configurations(configuration));
        ///// <summary>
        ///// Редактирование конфигурации.
        ///// В случае если такой конфигурации нет, то будет добавлена новая.
        ///// </summary>
        ///// <param name="configuration">Модель данных конфигурации</param>
        ///// <returns>Логическое значение об успешности/не успешности действия</returns>
        //[HttpPost("EditConfiguration")]
        //public bool EditConfiguration(Configurations configuration) => Update<Configurations>(new Configurations(configuration));
        ///// <summary>
        ///// Удаление конфигурации по идентификатору
        ///// </summary>
        ///// <param name="id">Идентификатор конфигурации</param>
        ///// <returns>Логическое значение об успешности/не успешности действия</returns>
        //[HttpPost("DeleteConfigurationById")]
        //public bool DeleteConfigurationById(Guid id) => Remove<Configurations>(id);
        ///// <summary>
        ///// Удаление всех конфигураций
        ///// </summary>
        ///// <param name="id">Идентификатор конфигурации</param>
        ///// <returns>Логическое значение об успешности/не успешности действия</returns>
        //[HttpPost("DeleteAllConfiguration")]
        //public bool DeleteAllConfiguration() => RemoveAll<Configurations>();
        ///// <summary>
        ///// Удаление всех конфигураций
        ///// </summary>
        ///// <param name="id">Идентификатор конфигурации</param>
        ///// <returns>Логическое значение об успешности/не успешности действия</returns>
        //[HttpPost("DeleteConfigurationByProperty")]
        //public bool DeleteConfigurationByProperty(string propertyName, string propertyValue) => RemoveByProperty<Configurations>(propertyName,propertyValue);
    }
}
