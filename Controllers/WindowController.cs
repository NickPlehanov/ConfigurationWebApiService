using ConfigurationWebApiService.Data;
using ConfigurationWebApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindowController : BaseActionsForControllers
    {
        public WindowController(ConfugurationManagerDbContext confugurationManagerDbContext) : base()
        {
        }

        ///// <summary>
        ///// Вывести список всех окон
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet("GetAll")]
        //public IEnumerable<Models.Windows>? GetAll() => GetAll<Models.Windows>();
        ///// <summary>
        ///// Получение окна по идентификатору
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet("GetById")]
        //public Models.Windows? GetById(Guid id) => GetById<Models.Windows>(id);
        //[HttpGet("GetByProperty")]
        //public IEnumerable<Models.Windows>? GetByProperty(string propertyName, string propertyValue) => GetByProperty<Models.Windows>(propertyName,propertyValue);
        ///// <summary>
        ///// Добавление окна
        ///// </summary>
        ///// <param name="window"></param>
        ///// <returns></returns>
        //[HttpPost("AddWindow")]
        //public bool AddWindow(Models.Windows window) => Add<Models.Windows>(new Models.Windows(window));
        ///// <summary>
        ///// Редактирование окна
        ///// </summary>
        ///// <param name="window"></param>
        ///// <returns></returns>
        //[HttpPost("EditWindow")]
        //public bool EditWindow(Models.Windows window) => Update<Models.Windows>(new Models.Windows(window));
        ///// <summary>
        ///// Удаление окна
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpPost("DeleteWindowById")]
        //public bool DeleteWindowById(Guid id) => Remove<Models.Windows>(id);
        //[HttpPost("DeleteWindowByProperty")]
        //public bool DeleteWindowByProperty(string propertyName, string propertyValue) => RemoveByProperty<Models.Windows>(propertyName,propertyValue);
        //[HttpPost("DeleteAllWindows")]
        //public bool DeleteAllWindows() => RemoveAll<Models.Windows>();
    }
}
