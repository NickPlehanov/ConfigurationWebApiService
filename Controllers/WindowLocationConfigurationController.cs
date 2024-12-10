using ConfigurationWebApiService.Data;
using ConfigurationWebApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindowLocationConfigurationController : ControllerBase
    {
        /// <summary>
        /// Вывести список всех привязок расположений окон к конфигурациям
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetAllWindowLocationConfiguration")]
        public IEnumerable<WindowLocationConfiguration>? GetAll() => ((IBaseActionsForControllers)this).GetAll<WindowLocationConfiguration>();
        /// <summary>
        /// Получение привязки расположения окна к конфигурации по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetWindowLocationConfigurationById")]
        public WindowLocationConfiguration? GetById(Guid id) => ((IBaseActionsForControllers)this).GetById<WindowLocationConfiguration>(id);
        /// <summary>
        /// Получение привязки расположения окна к конфигурации по идентификатору расположения окна
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetWindowLocationConfigurationByProperty")]
        public IEnumerable<WindowLocationConfiguration>? GetByProperty(string propertyName, string propertyValue) => ((IBaseActionsForControllers)this).GetByProperty<WindowLocationConfiguration>(propertyName,propertyValue);
        /// <summary>
        /// Добавление привязки расположения окна к конфигурации
        /// </summary>
        /// <param name="windowLocationConfiguration"></param>
        /// <returns></returns>
        [HttpPost("AddWindowLocationConfiguration")]
        public bool AddWindowLocationConfiguration(WindowLocationConfiguration windowLocationConfiguration) => ((IBaseActionsForControllers)this).Add<WindowLocationConfiguration>(new WindowLocationConfiguration(windowLocationConfiguration));
        /// <summary>
        /// Редактирование привязки расположение окна с конфигурацией 
        /// </summary>
        /// <param name="windowLocationConfiguration"></param>
        /// <returns></returns>
        [HttpPost("EditWindowLocationConfiguration")]
        public bool EditWindowLocationConfiguration(WindowLocationConfiguration windowLocationConfiguration) => ((IBaseActionsForControllers)this).Update<WindowLocationConfiguration>(new WindowLocationConfiguration(windowLocationConfiguration));
        /// <summary>
        /// Удаление привязки расположения окна с конфигурацией
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("DeleteWindowLocationConfigurationById")]
        public bool DeleteWindowLocationConfigurationById(Guid id) => ((IBaseActionsForControllers)this).Remove<WindowLocationConfiguration>(id);
        [HttpPost("DeleteWindowLocationConfigurationByProperty")]
        public bool DeleteWindowLocationConfigurationByProperty(string propertyName, string propertyValue) => ((IBaseActionsForControllers)this).RemoveByProperty<WindowLocationConfiguration>(propertyName,propertyValue);
        [HttpPost("DeleteAllWindowLocationConfiguration")]
        public bool DeleteAllWindowLocationConfiguration() => ((IBaseActionsForControllers)this).RemoveAll<WindowLocationConfiguration>();
    }
}
