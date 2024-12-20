﻿using ConfigurationWebApiService.Data;
using ConfigurationWebApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace ConfigurationWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotKeyController : BaseActionsForControllers
    {
        public HotKeyController(ConfugurationManagerDbContext confugurationManagerDbContext) : base()
        {
        }

        ///// <summary>
        ///// Получение списка всех горячих клавиш
        ///// </summary>
        ///// <returns>Список горячих клавиш</returns>
        //[HttpGet("GetListHotKeys")]
        //public IEnumerable<Hotkeys>? GetListHotKeys() => GetAll<Hotkeys>();
        ///// <summary>
        ///// Получение горячей клавиши по её идентификатору
        ///// </summary>
        ///// <param name="fontId">Идентификатор горячей клавиши</param>
        ///// <returns></returns>
        //[HttpGet("GetHotKeyById")]
        //public Hotkeys? GetHotKeyById(Guid id) => GetById<Hotkeys>(id);
        //[HttpGet("GetListHotKeysByProperty")]
        //public IEnumerable<Hotkeys>? GetListHotKeysByProperty(string propertyName, string propertyValue) => GetByProperty<Hotkeys>(propertyName,propertyValue);
        ///// <summary>
        ///// Добавление горячей клавиши
        ///// </summary>
        ///// <param name="title">Наименование горячей клавиши</param>
        ///// <param name="description">Описание горячей клавиши</param>
        ///// <param name="value">Значение горячей клавиши</param>
        ///// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        //[HttpPost("AddHotKey")]
        //public bool AddHotKey(Hotkeys hotkey) => Add<Hotkeys>(new Hotkeys(hotkey));
        ///// <summary>
        ///// Редактирование горячей клавиши
        ///// </summary>
        ///// <param name="hotkey">Модель объекта горячей клавиши</param>
        ///// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        //[HttpPost("EditHotKey")]
        //public bool EditHotKey(Hotkeys hotkey) => Update<Hotkeys>(new Hotkeys(hotkey));
        ///// <summary>
        ///// Удаление горячей клавиши
        ///// </summary>
        ///// <param name="id">Идентификатор удаляемой горячей клавиши</param>
        ///// <returns></returns>
        //[HttpPost("DeleteHotKeyById")]
        //public bool DeleteHotKeyById(Guid id) => Remove<Hotkeys>(id);
        //[HttpPost("DeleteHotKeyByProperty")]
        //public bool DeleteHotKeyByProperty(string propertyName, string propertyValue) => RemoveByProperty<Hotkeys>(propertyName,propertyValue);
        //[HttpPost("DeleteAllHotKeys")]
        //public bool DeleteAllHotKeys() => RemoveAll<Hotkeys>();
    }
}
