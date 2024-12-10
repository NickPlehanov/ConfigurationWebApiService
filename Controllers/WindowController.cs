using ConfigurationWebApiService.Data;
using ConfigurationWebApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindowController : ControllerBase, IBaseActionsForControllers
    {
        /// <summary>
        /// Вывести список всех окон
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public IEnumerable<Models.Windows>? GetAll() => ((IBaseActionsForControllers)this).GetAll<Models.Windows>();
        /// <summary>
        /// Получение окна по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetById")]
        public Models.Windows? GetById(Guid id) => ((IBaseActionsForControllers)this).GetById<Models.Windows>(id);
        [HttpGet("GetByProperty")]
        public IEnumerable<Models.Windows>? GetByProperty(string propertyName, string propertyValue) => ((IBaseActionsForControllers)this).GetByProperty<Models.Windows>(propertyName,propertyValue);
        /// <summary>
        /// Добавление окна
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        [HttpPost("AddWindow")]
        public bool AddWindow(Models.Windows window) => ((IBaseActionsForControllers)this).Add<Models.Windows>(new Models.Windows(window));
        /// <summary>
        /// Редактирование окна
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        [HttpPost("EditWindow")]
        public bool EditWindow(Models.Windows window) => ((IBaseActionsForControllers)this).Update<Models.Windows>(new Models.Windows(window));
        /// <summary>
        /// Удаление окна
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("DeleteWindowById")]
        public bool DeleteWindowById(Guid id) => ((IBaseActionsForControllers)this).Remove<Models.Windows>(id);
        [HttpPost("DeleteWindowByProperty")]
        public bool DeleteWindowByProperty(string propertyName, string propertyValue) => ((IBaseActionsForControllers)this).RemoveByProperty<Models.Windows>(propertyName,propertyValue);
        [HttpPost("DeleteAllWindows")]
        public bool DeleteAllWindows() => ((IBaseActionsForControllers)this).RemoveAll<Models.Windows>();
    }
}
