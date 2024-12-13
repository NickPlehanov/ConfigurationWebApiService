using ConfigurationWebApiService.Data;
using ConfigurationWebApiService.Models;
using ConfigurationWebApiService.Services.GenericServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ConfigurationWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColourSchemaConfigurationController : ControllerBase
    {
        private readonly ITService<ColourSchemaConfiguration> Service;
        public ColourSchemaConfigurationController(ITService<ColourSchemaConfiguration> service)
        {
            Service = service;
        }
        /// <summary>
        /// Получение списка всех пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        //[HttpGet("GetListColourSchemaConfiguration")]
        //public IEnumerable<ColourSchemaConfiguration>? GetListUser()
        //{
        //    return Service.GetAll();
        //}
    }
}
