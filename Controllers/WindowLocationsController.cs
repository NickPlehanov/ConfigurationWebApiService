using ConfigurationWebApiService.Data;
using ConfigurationWebApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindowLocationsController : BaseActionsForControllers
    {
        public WindowLocationsController(ConfugurationManagerDbContext confugurationManagerDbContext) : base()
        {
        }

        ///// <summary>
        ///// Вывести список всех расположений окон
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet("GetAllWindowLocations")]
        //public IEnumerable<WindowLocations>? GetAllWindowLocations() => GetAll<WindowLocations>();
        ///// <summary>
        ///// Получение расположения окна по идентификатору
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet("GetWindowLocationsById")]
        //public WindowLocations? GetWindowLocationsById(Guid id) => GetById<WindowLocations>(id);
        //[HttpGet("GetWindowLocationsByProperty")]
        //public IEnumerable<WindowLocations>? GetWindowLocationsByProperty(string propertyName, string propertyValue) => GetByProperty<WindowLocations>(propertyName,propertyValue);
        ///// <summary>
        ///// Добавление расположения окна
        ///// </summary>
        ///// <param name="windowLocation"></param>
        ///// <returns></returns>
        //[HttpPost("AddWindowLocation")]
        //public bool AddWindow(WindowLocations windowLocation) => Add<WindowLocations>(new WindowLocations(windowLocation));
        ///// <summary>
        ///// Редактирование расположения окна
        ///// </summary>
        ///// <param name="windowLocation"></param>
        ///// <returns></returns>
        //[HttpPost("EditWindowLocation")]
        //public bool EditWindow(WindowLocations windowLocation) => Update<WindowLocations>(new WindowLocations(windowLocation));
        ///// <summary>
        ///// Удаление расположения окна
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpPost("DeleteWindowLocationById")]
        //public bool DeleteWindowLocationById(Guid id) => Remove<WindowLocations>(id);
        //[HttpPost("DeleteWindowLocationByProperty")]
        //public bool DeleteWindowLocationByProperty(string propertyName, string propertyValue) => RemoveByProperty<WindowLocations>(propertyName,propertyValue);
        //[HttpPost("DeleteAllWindowLocations")]
        //public bool DeleteAllWindowLocations() => RemoveAll<WindowLocations>();
    }
}
