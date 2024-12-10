using ConfigurationWebApiService.Data;
using ConfigurationWebApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace ConfigurationWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FontsController : ControllerBase
    {
        /// <summary>
        /// Получение списка всех шрифтов
        /// </summary>
        /// <returns>Список шрифтов</returns>
        [HttpGet("GetListFonts")]
        public IEnumerable<Fonts>? GetListFonts() => ((IBaseActionsForControllers)this).GetAll<Fonts>();
        /// <summary>
        /// Получение шрифта по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор шрифта</param>
        /// <returns></returns>
        [HttpGet("GetFontsById")]
        public Fonts? GetFontsById(Guid id) => ((IBaseActionsForControllers)this).GetById<Fonts>(id);
        [HttpGet("GetFontsByProperty")]
        public IEnumerable<Fonts>? GetFontsByProperty(string propertyName, string propertyValue) => ((IBaseActionsForControllers)this).GetByProperty<Fonts>(propertyName,propertyValue);
        /// <summary>
        /// Добавление шрифта
        /// </summary>
        /// <param name="title">Наименование шрифта</param>
        /// <param name="description">Описание шрифта</param>
        /// <param name="value">Значение шрифта</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("AddFont")]
        public bool AddFont(Fonts font) => ((IBaseActionsForControllers)this).Add<Fonts>(new Fonts(font));
        /// <summary>
        /// Редактирование шрифта
        /// </summary>
        /// <param name="font">Модель объекта шрифта</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("EditFont")]
        public bool EditFont(Fonts font) => ((IBaseActionsForControllers)this).Update<Fonts>(new Fonts(font));
        /// <summary>
        /// Удаление шрифта
        /// </summary>
        /// <param name="id">Идентификатор удаляемого шрифта</param>
        /// <returns></returns>
        [HttpPost("DeleteFontById")]
        public bool DeleteFontById(Guid id) => ((IBaseActionsForControllers)this).Remove<Fonts>(id);
        [HttpPost("DeleteFontByProperty")]
        public bool DeleteFontByProperty(string propertyName, string propertyValue) => ((IBaseActionsForControllers)this).RemoveByProperty<Fonts>(propertyName, propertyValue);
        [HttpPost("DeleteAllFonts")]
        public bool DeleteAllFonts() => ((IBaseActionsForControllers)this).RemoveAll<Fonts>();
    }
}
