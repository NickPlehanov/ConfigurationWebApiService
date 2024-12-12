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
    public class FontConfigurationController : BaseActionsForControllers
    {
        public FontConfigurationController(ConfugurationManagerDbContext confugurationManagerDbContext) : base()
        {
        }

        ///// <summary>
        ///// Получение всех привязок шрифтов к конфигурациям
        ///// </summary>
        ///// <returns>Список конфигураций шрифтов</returns>
        //[HttpGet("GetListFontConfigurations")]
        //public IEnumerable<FontConfiguration>? GetListFontConfigurations() => GetAll<FontConfiguration>();
        //[HttpGet("GetListFontConfigurationsByProperty")]
        //public IEnumerable<FontConfiguration>? GetListFontConfigurationsByProperty(string propertyName, string propertyValue) => GetByProperty<FontConfiguration>(propertyName,propertyValue);
        //[HttpGet("GetListFontConfigurationsById")]
        //public FontConfiguration? GetListFontConfigurationsById(Guid id) => GetById<FontConfiguration>(id);

        ///// <summary>
        ///// Назначение привязки шрифта к конфигурации
        ///// </summary>
        ///// <param name="fontId">Идентификатор шрифта</param>
        ///// <param name="configurationId">Идентификатор конфигурации</param>
        ///// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        //[HttpPost("SetFontWithConfiguration")]
        //public bool SetFontWithConfiguration(FontConfiguration fontConfiguration) => Add<FontConfiguration>(new FontConfiguration(fontConfiguration));
        ///// <summary>
        ///// Снятие привязки шрифта к конфигурации
        ///// </summary>
        ///// <param name="fontId">Идентификатор шрифта</param>
        ///// <param name="configurationId">Идентификатор конфигурации</param>
        ///// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        //[HttpPost("UnSetFontWithConfiguration")]
        //public bool UnSetFontWithConfiguration(string propertyName, string propertyValue) => RemoveByProperty<FontConfiguration>(propertyName, propertyValue);
        ///// <summary>
        ///// Удаление всех связок шрифтов с конфигурациями 
        ///// </summary>
        ///// <param name="id">Идентификатор связки шрифта с конфигурацией</param>
        //[HttpPost("DeleteFontConfigurationsById")]
        //public void DeleteFontConfigurationsById(Guid id)=> Remove<FontConfiguration>(id);
        //[HttpPost("DeleteAllFontConfigurations")]
        //public void DeleteAllFontConfigurations() => RemoveAll<FontConfiguration>();
    }
}
