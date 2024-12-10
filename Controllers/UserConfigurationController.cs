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
    public class UserConfigurationController : ControllerBase
    {
        /// <summary>
        /// Получение всех привязок пользователей к конфигурациям
        /// </summary>
        /// <returns>Список конфигураций пользователей</returns>
        [HttpGet("GetListUserConfigurations")]
        public IEnumerable<UserConfiguration>? GetListUserConfigurations() => ((IBaseActionsForControllers)this).GetAll<UserConfiguration>();
        /// <summary>
        /// Получение всех привязок пользователей к конфигурациям по идентификатору пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>Список конфигураций пользователя</returns>
        [HttpGet("GetListUserConfigurationsById")]
        public UserConfiguration? GetListUserConfigurationsById(Guid id) => ((IBaseActionsForControllers)this).GetById<UserConfiguration>(id);
        [HttpGet("GetListUserConfigurationsByProperty")]
        public IEnumerable<UserConfiguration>? GetListUserConfigurationsByProperty(string propertyName, string propertyValue) => ((IBaseActionsForControllers)this).GetByProperty<UserConfiguration>(propertyName,propertyValue);
        /// <summary>
        /// Назначение привязки пользователя к конфигурации
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="configurationId">Идентификатор конфигурации</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("SetUserWithConfiguration")]
        public bool SetUserWithConfiguration(UserConfiguration userConfiguration) => ((IBaseActionsForControllers)this).Add<UserConfiguration>(new UserConfiguration(userConfiguration));
        /// <summary>
        /// Снятие привязки привязки к конфигурации
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="configurationId">Идентификатор конфигурации</param>
        /// <returns>true - если добавление прошло успешно и false - в обратном случае</returns>
        [HttpPost("UnSetUserWithConfiguration")]
        public bool UnSetUserWithConfiguration(string propertyName, string propertyValue) => ((IBaseActionsForControllers)this).RemoveByProperty<UserConfiguration>(propertyName,propertyValue);
        /// <summary>
        /// Удаление всех связок пользователей с конфигурациями 
        /// </summary>
        /// <param name="configurationId">Идентификатор конфигурации</param>
        [HttpPost("DeleteUserConfigurationsById")]
        public void DeleteUserConfigurationsById(Guid id) => ((IBaseActionsForControllers)this).Remove<UserConfiguration>(id);
        [HttpPost("DeleteAllUserConfigurations")]
        public void DeleteAllUserConfigurations() => ((IBaseActionsForControllers)this).RemoveAll<UserConfiguration>();
    }
}
