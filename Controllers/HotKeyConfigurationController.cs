using ConfigurationWebApiService.Data;
using ConfigurationWebApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace ConfigurationWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotKeyConfigurationController : BaseActionsForControllers
    {
        public HotKeyConfigurationController(ConfugurationManagerDbContext confugurationManagerDbContext) : base()
        {
        }

        ///// <summary>
        ///// Получение всех привязок горячих клавиш к конфигурациям
        ///// </summary>
        ///// <returns>Список конфигураций горячих клавиш</returns>
        //[HttpGet("GetListHotKeyConfigurations")]
        //public IEnumerable<HotKeyConfigurations>? GetListHotKeyConfigurations() => GetAll<HotKeyConfigurations>();

        //[HttpGet("GetListHotKeyConfigurationsByProperty")]
        //public IEnumerable<HotKeyConfigurations>? GetListHotKeyConfigurationsByProperty(string propertyName, string propertyValue) => GetByProperty<HotKeyConfigurations>(propertyName,propertyValue);
        //[HttpGet("GetListHotKeyConfigurationsById")]
        //public HotKeyConfigurations? GetListHotKeyConfigurationsById(Guid id) => GetById<HotKeyConfigurations>(id);

        ///// <summary>
        ///// Назначение привязки горячих клавиш к конфигурации
        ///// </summary>
        ///// <param name="hotKeyId">Идентификатор горячей клавиши</param>
        ///// <param name="configurationId">Идентификатор конфигурации</param>
        ///// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        //[HttpPost("SetHotKeyWithConfiguration")]
        //public bool SetHotKeyWithConfiguration(HotKeyConfigurations hotKeyConfiguration) => Add<HotKeyConfigurations>(new HotKeyConfigurations(hotKeyConfiguration));
        ///// <summary>
        ///// Снятие привязки горячей клавиши к конфигурации
        ///// </summary>
        ///// <param name="hotKeyId">Идентификатор горячей клавиши</param>
        ///// <param name="configurationId">Идентификатор конфигурации</param>
        ///// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        //[HttpPost("UnSetHotKeyWithConfiguration")]
        //public bool UnSetHotKeyWithConfiguration(string propertyName, string propertyValue) => RemoveByProperty<HotKeyConfigurations>(propertyName, propertyValue);

        ///// <summary>
        ///// Удаление связок горячих клавиш с конфигурациями 
        ///// </summary>
        ///// <param name="id">Идентификатор связки горячих клавиш с конфигурацией</param>
        //[HttpPost("DeleteFontConfigurationsById")]
        //public void DeleteFontConfigurationsById(Guid id)=> Remove<HotKeyConfigurations>(id);
        //[HttpPost("DeleteAllFontConfigurations")]
        //public void DeleteAllFontConfigurations() => RemoveAll<HotKeyConfigurations>();
    }
}
