using ConfigurationWebApiService.Data;
using ConfigurationWebApiService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ConfigurationWebApiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigurationController: ControllerBase
    {
        /// <summary>
        /// Возвращает список всех конфигураций
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetListConfigurations")]
        public IEnumerable<Configurations> GetListConfigurations()
        {
            using ConfugurationManagerDbContext context = new();
            return context.Configurations.ToList();
        }
        /// <summary>
        /// Возвращает список конфигураций пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns></returns>
        [HttpGet("GetConfigurationsByUser")]
        public IEnumerable<Configurations> GetConfigurationsByUser(Guid userId)
        {
            using ConfugurationManagerDbContext context = new();
            return context.UserConfiguration.Where(x => x.UserId == userId).Select(x => x.Configuration);
        }
        [HttpPost("AddConfiguration")]
        public bool AddConfiguration(string title, string? description) {
            using ConfugurationManagerDbContext context = new();
            var model = new Configurations(title, description ?? string.Empty);
            context.Configurations.Add(model);
            int res = context.SaveChanges();
            return res > 0;
        }
        [HttpPost("EditConfiguration")]
        public bool EditConfiguration(Configurations configuration)
        {
            using ConfugurationManagerDbContext context = new();
            Configurations? existingConfiguration = context.Configurations.First(x => x.Id == configuration.Id);
            if (existingConfiguration != null) {
                existingConfiguration.UpdateDate = DateTime.Now;
                existingConfiguration.Version++;
                existingConfiguration.Id = Guid.NewGuid();
                context.Configurations.Add(existingConfiguration);
                int res = context.SaveChanges();
                return res > 0;
            }
            else
                return AddConfiguration(configuration.Title, configuration.Description);
            
        }
        [HttpPost("DeleteConfiguration")]
        public bool DeleteConfiguration(Guid id) {
            using ConfugurationManagerDbContext context = new();
            context.Configurations.Remove(context.Configurations.First(x=>x.Id==id));
            int res = context.SaveChanges();
            return res > 0;
        }
    }
}
