using ConfigurationWebApiService.Data;
using ConfigurationWebApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindowLocationsController : ControllerBase
    {
        /// <summary>
        /// Вывести список всех расположений окон
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetAllWindowLocations")]
        public IEnumerable<WindowLocations>? GetAllWindowLocations() => ((IBaseActionsForControllers)this).GetAll<WindowLocations>();
        /// <summary>
        /// Получение расположения окна по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetWindowLocationsById")]
        public WindowLocations? GetWindowLocationsById(Guid id) => ((IBaseActionsForControllers)this).GetById<WindowLocations>(id);
        [HttpGet("GetWindowLocationsByProperty")]
        public IEnumerable<WindowLocations>? GetWindowLocationsByProperty(string propertyName, string propertyValue) => ((IBaseActionsForControllers)this).GetByProperty<WindowLocations>(propertyName,propertyValue);
        /// <summary>
        /// Добавление расположения окна
        /// </summary>
        /// <param name="windowLocation"></param>
        /// <returns></returns>
        [HttpPost("AddWindowLocation")]
        public bool AddWindow(WindowLocations windowLocation) => ((IBaseActionsForControllers)this).Add<WindowLocations>(new WindowLocations(windowLocation));
        /// <summary>
        /// Редактирование расположения окна
        /// </summary>
        /// <param name="windowLocation"></param>
        /// <returns></returns>
        [HttpPost("EditWindowLocation")]
        public bool EditWindow(WindowLocations windowLocation) => ((IBaseActionsForControllers)this).Update<WindowLocations>(new WindowLocations(windowLocation));
        /// <summary>
        /// Удаление расположения окна
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("DeleteWindowLocationById")]
        public bool DeleteWindowLocationById(Guid id) => ((IBaseActionsForControllers)this).Remove<WindowLocations>(id);
        [HttpPost("DeleteWindowLocationByProperty")]
        public bool DeleteWindowLocationByProperty(string propertyName, string propertyValue) => ((IBaseActionsForControllers)this).RemoveByProperty<WindowLocations>(propertyName,propertyValue);
        [HttpPost("DeleteAllWindowLocations")]
        public bool DeleteAllWindowLocations() => ((IBaseActionsForControllers)this).RemoveAll<WindowLocations>();
    }
}
