using ConfigurationWebApiService.Models;
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
        public static void ObjectWasBeChanged<T>(EntityChangedEventArgs<T> e)
        {
            MessageForSubscribers messageForSubscribers = new();
            if (e.Entity != null && e.AffectedRows > 0)
            {
                messageForSubscribers.Send($"Сформировано событие типа {e.Action} для объекта типа {e.Entity.GetType().Name} с идентификатором {e.Entity.GetType().GetProperty("Id")?.GetValue(e.Entity)}", e?.Notes ?? string.Empty, BaseMessage.GetSubscribersForMessage([e.Action.ToString()], [e.Entity.GetType().Name.ToString()]));
            }
        }
    }
}
