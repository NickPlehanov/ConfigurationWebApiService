using System.ComponentModel.DataAnnotations;

namespace ConfigurationWebApiService.Services.SignalR
{
    public interface IBaseServiceLogic<T> where T : class
    {
        public static bool ModelValidator(T entity, out List<ValidationResult> results)
        {
            var context = new ValidationContext(entity);
            results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(entity, context, results, true))
            {
                return false;
            }
            else
                return true;
        }
    }
}
