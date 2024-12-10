using ConfigurationWebApiService.Data;
using ConfigurationWebApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ConfigurationWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColourSchemaConfigurationController : ControllerBase, IBaseActionsForControllers
    {
        /// <summary>
        /// Получение всех привязок цветовых конфигураций к конфигурациям
        /// </summary>
        /// <returns>Список цветовых конфигураций</returns>
        [HttpGet("GetListColourSchemaConfigurations")]
        public IEnumerable<ColourSchemaConfiguration>? GetListColourSchemaConfigurations() => ((IBaseActionsForControllers)this).GetAll<ColourSchemaConfiguration>();
        /// <summary>
        /// Получение цветовой схемы по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор цветовой схемы</param>
        /// <returns>Объект типа привязки цветовой конфигурации</returns>
        [HttpGet("GetColourSchemaConfigurationsById")]
        public ColourSchemaConfiguration? GetById(Guid id) => ((IBaseActionsForControllers)this).GetById<ColourSchemaConfiguration>(id);
        /// <summary>
        /// Получение привязок цветовых схем по заданному условию
        /// </summary>
        /// <param name="propertyName">Наименование свойства для поиска</param>
        /// <param name="propertyValue">Значение свойства для поиска</param>
        /// <returns>Список цветовых конфигураций</returns>
        [HttpGet("GetColourSchemaConfigurations")]
        public IEnumerable<ColourSchemaConfiguration>? GetListColourSchemaConfigurationsByColourSchemaID(string propertyName, string propertyValue) => ((IBaseActionsForControllers)this).GetByProperty<ColourSchemaConfiguration>(propertyName, propertyValue);
        /// <summary>
        /// Назначение привязки цветовой схемы и конфигурации
        /// </summary>
        /// <param name="colourSchemaConfiguration">Объект типа привязки цветовой схемы к конфигурации</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случаевия</returns>
        [HttpPost("SetColourSchemaWithConfiguration")]
        public bool SetColourSchemaWithConfiguration(ColourSchemaConfiguration colourSchemaConfiguration) => ((IBaseActionsForControllers)this).Add<ColourSchemaConfiguration>(new ColourSchemaConfiguration(colourSchemaConfiguration));
        /// <summary>
        /// Снятие привязки цветовой схемы и конфигурации
        /// </summary>
        /// <param name="colourSchemaId">Идентификатор цветовой схемы</param>
        /// <param name="configurationId">Идентификатор конфигурации</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("UnSetColourSchemaWithConfiguration")]
        public bool UnSetColourSchemaWithConfiguration(string propertyName, string propertyValue) => ((IBaseActionsForControllers)this).RemoveByProperty<ColourSchemaConfiguration>(propertyName, propertyValue);
        /// <summary>
        /// Удаление всех связок цветовых конфигураций с конфигурациями 
        /// </summary> 
        [HttpPost("DeleteAllColourSchemaConfigurations")]
        public void DeleteAllColourSchemaConfigurations() => ((IBaseActionsForControllers)this).RemoveAll<ColourSchemaConfiguration>();       
    }
}
