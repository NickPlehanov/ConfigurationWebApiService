using ConfigurationWebApiService.Data;
using ConfigurationWebApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColourSchemasController : ControllerBase
    {
        /// <summary>
        /// Получение списка цветовых схем
        /// </summary>
        /// <returns>Список цветовых схем</returns>
        [HttpGet("GetListColourSchemas")]
        public IEnumerable<ColourSchemas>? GetListConfigurations() => ((IBaseActionsForControllers)this).GetAll<ColourSchemas>();
        /// <summary>
        /// Получение цветовой схемы по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор цветовой схемы</param>
        /// <returns>Цветовая схема</returns>
        [HttpGet("GetColourSchemasById")]
        public ColourSchemas? GetConfigurationsById(Guid id)=>((IBaseActionsForControllers)this).GetById<ColourSchemas>(id);
        /// <summary>
        /// Получение привязок цветовых схем по заданному условию
        /// </summary>
        /// <param name="propertyName">Наименование свойства для поиска</param>
        /// <param name="propertyValue">Значение</param>
        /// <returns>Список цветовых конфигураций</returns>
        [HttpGet("GetColourSchemas")]
        public IEnumerable<ColourSchemas>? GetColourSchemas(string propertyName, string propertyValue) => ((IBaseActionsForControllers)this).GetByProperty<ColourSchemas>(propertyName, propertyValue);
        /// <summary>
        /// <summary>
        /// Добавление цветовой схемы
        /// </summary>
        /// <param name="title">Наименование цветовой схемы</param>
        /// <param name="description">Описание цветовой схемы</param>
        /// <param name="value">Значение цветовой схемы</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("AddColourSchemas")]
        public bool AddColourSchemas(ColourSchemas colourSchemas) => ((IBaseActionsForControllers)this).Add<ColourSchemas>(new ColourSchemas(colourSchemas));
        /// <summary>
        /// Редактирование цветовой схемы
        /// </summary>
        /// <param name="colourSchema">Модель объекта цветовой схемы</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("EditColourSchemas")]
        public bool EditColourSchemas(ColourSchemas colourSchema) => ((IBaseActionsForControllers)this).Update<ColourSchemas>(new ColourSchemas(colourSchema));
        /// <summary>
        /// Удаление цветовой схемы
        /// </summary>
        /// <param name="id">Идентификатор удаляемой цветовой схемы</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("DeleteColourSchemas")]
        public bool DeleteColourSchemas(string propertyName, string propertyValue) => ((IBaseActionsForControllers)this).RemoveByProperty<ColourSchemas>(propertyName,propertyValue);
        [HttpPost("DeleteAllColourSchemas")]
        public bool DeleteAllColourSchemas() => ((IBaseActionsForControllers)this).RemoveAll<ColourSchemas>();
    }
}
