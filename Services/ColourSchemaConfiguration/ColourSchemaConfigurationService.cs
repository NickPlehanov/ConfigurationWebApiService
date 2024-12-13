using ConfigurationWebApiService.CRUDModels;
using ConfigurationWebApiService.CRUDModels.ColourSchemaConfiguration;
using ConfigurationWebApiService.CRUDModels.Users;
using ConfigurationWebApiService.Services.SignalR;
using System.ComponentModel.DataAnnotations;
using csc = ConfigurationWebApiService.Models.ColourSchemaConfiguration;

namespace ConfigurationWebApiService.Services.ColourSchemaConfiguration
{
    public class ColourSchemaConfigurationService //: IColourSchemaConfigurationService, IBaseServiceLogic<csc>
    {
        //private readonly IRepository<csc> _iRepository;
        //public ColourSchemaConfigurationService(IRepository<csc> iRepository)
        //{
        //    _iRepository = iRepository;
        //}
        //public ResponseModel Add(ColourSchemaConfigurationModelBase ColourSchemaConfigurationAddModel)
        //{
        //    var resp = new ResponseModel();
        //    if (ColourSchemaConfigurationAddModel == null)
        //        return resp;
        //    csc ColourSchemaConfiguration = new()
        //    {
        //        Id = Guid.NewGuid(),
        //        ColourSchemaId = ColourSchemaConfigurationAddModel.ColourSchemaId,
        //        ConfigurationId = ColourSchemaConfigurationAddModel.ConfigurationId
        //    };
        //    List<ValidationResult> validationResults;
        //    if (!IBaseServiceLogic<csc>.ModelValidator(ColourSchemaConfiguration, out validationResults))
        //    {
        //        resp.Error = validationResults;
        //        return resp;
        //    }
        //    var result = _iRepository.Add(ColourSchemaConfiguration);
        //    resp.Value = result;
        //    resp.Message = "OK";
        //    resp.StatusCode = 1;
        //    return resp;
        //}

        //public ResponseModel Delete(Guid id)
        //{
        //    var resp = new ResponseModel();
        //    csc? findedCsc = _iRepository.GetById(id);
        //    if (findedCsc == null)
        //    {
        //        resp.Error = $"Конфигурация цветовой схемы с Id = {id} не найдена.";
        //        return resp;
        //    }
        //    _iRepository.Delete(id);
        //    resp.Message = "OK";
        //    resp.StatusCode = 1;
        //    return resp;
        //}

        //public ResponseModel GetAllColourSchemaConfigurations()
        //{
        //    var resp = new ResponseModel();
        //    var entityColourSchemaConfigurations = _iRepository.GetAll();
        //    if (entityColourSchemaConfigurations == null) return resp;
        //    if (!entityColourSchemaConfigurations.Any()) return resp;
        //    resp.Value = entityColourSchemaConfigurations.Select(x => new ColourSchemaConfigurationEditRemoveModel()
        //    {
        //        ColourSchemaId = x.ColourSchemaId,
        //        ConfigurationId = x.ConfigurationId,
        //        Id = x.Id
        //    });
        //    resp.StatusCode = resp.Value != null ? 1 : -1;
        //    resp.Message = resp.Value != null ? "OK" : "ERROR";
        //    return resp;
        //}

        //public ResponseModel GetById(Guid id)
        //{
        //    var resp = new ResponseModel();
        //    var colourSchemaConfiguration = _iRepository.GetById(id);
        //    if (colourSchemaConfiguration == null) return resp;
        //    resp.Value = new ColourSchemaConfigurationEditRemoveModel()
        //    {
        //        ColourSchemaId = colourSchemaConfiguration.ColourSchemaId,
        //        ConfigurationId = colourSchemaConfiguration.ConfigurationId,
        //        Id = colourSchemaConfiguration.Id
        //    };
        //    resp.StatusCode = 1;
        //    resp.Message = "OK";
        //    return resp;
        //}

        //public ResponseModel Update(ColourSchemaConfigurationEditRemoveModel cscModel)
        //{
        //    var resp = new ResponseModel();
        //    if (cscModel == null)
        //    {
        //        resp.Error = $"Пустая модель для обновления пользователя";
        //        return resp;
        //    }
        //    csc? findedCsc = _iRepository.GetById(cscModel.Id);
        //    if (findedCsc == null)
        //    {
        //        resp.Error = $"Пользователь с Id = {cscModel.Id} не найден.";
        //        return resp;
        //    }
        //    csc _csc = new()
        //    {
        //        Id = cscModel.Id,
        //        ColourSchemaId=cscModel.ColourSchemaId,
        //        ConfigurationId=cscModel.ConfigurationId
        //    };
        //    List<ValidationResult> validationResults;
        //    if (!IBaseServiceLogic<csc>.ModelValidator(_csc, out validationResults))
        //    {
        //        resp.Error = validationResults;
        //        return resp;
        //    }
        //    _iRepository.Update(_csc);
        //    resp.Message = "OK";
        //    resp.StatusCode = 1;
        //    return resp;
        //}
    }
}
