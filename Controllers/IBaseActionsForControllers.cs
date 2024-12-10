using ConfigurationWebApiService.Data;
using ConfigurationWebApiService.Models;
using ConfigurationWebApiService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection;

namespace ConfigurationWebApiService.Controllers
{
    public interface IBaseActionsForControllers
    {
        async void ObjectWasBeChanged<T>(object sender, EntityChangedEventArgs<T> e)
        {
            MessageForSubscribers messageForSubscribers = new();
            if (e.Entity != null)
            {
                await messageForSubscribers.Send($"Сформировано событие типа {e.Action} для объекта типа {e.Entity.GetType().Name} с идентификатором {e.Entity.GetType().GetProperty("Id")?.GetValue(e)}", e?.Notes ?? string.Empty, BaseMessage.GetSubscribersForMessage([e.Action.ToString()], [e.Entity.GetType().Name.ToString()]));
            }
            else
                await messageForSubscribers.Send(typeof(T).Name ?? string.Empty, e.Notes ?? string.Empty, BaseMessage.GetSubscribersForMessage([e.Action.ToString()], [typeof(T).Name]));
        }
        public IEnumerable<T>? GetAll<T>() where T : class
        {
            ConfugurationManagerDbContext context = new();
            return context.Set<T>().AsEnumerable();
        }

        public T? GetById<T>(Guid id) where T : class
        {
            ConfugurationManagerDbContext context = new();
            return context.Find<T>(id);
        }
        public IEnumerable<T>? GetByProperty<T>(string propertyName, string propertyValue) where T : class
        {
            var propertyInfo = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            ConfugurationManagerDbContext context = new();
            return propertyInfo == null ? default : context.Set<T>().AsEnumerable().Where(x=> propertyValue.Equals(propertyInfo.GetValue(x)?.ToString()));
        }
        public virtual bool Add<T>(T entity) where T : class
        {
            ConfugurationManagerDbContext context = new();
            context.Add<T>(entity);
            context.SavingChanges += (sender, e) => ObjectWasBeChanged<T>(sender, new EntityChangedEventArgs<T>(entity,EntityAction.Add,string.Empty));
            int res = context.SaveChanges();
            return res > 0;
        }
        public virtual bool Update<T>(T entity) where T : class
        {
            ConfugurationManagerDbContext context = new();
            context.Update<T>(entity);
            context.SavingChanges += (sender, e) => ObjectWasBeChanged<T>(sender, new EntityChangedEventArgs<T>(entity, EntityAction.Update, string.Empty));
            int res = context.SaveChanges();
            return res > 0;
        }
        public virtual bool Remove<T>(T entity) where T : class
        {
            ConfugurationManagerDbContext context = new();
            context.Remove<T>(entity);
            context.SavingChanges += (sender, e) => ObjectWasBeChanged<T>(sender, new EntityChangedEventArgs<T>(entity, EntityAction.Remove, string.Empty));
            int res = context.SaveChanges();
            return res > 0;
        }
        public virtual bool Remove<T>(Guid id) where T : class
        {
            ConfugurationManagerDbContext context = new();
            int res = 0;
            var obj = context.Find<T>(id);
            if (obj != null)
            {
                context.Remove<T>(obj);
                context.SavingChanges += (sender, e) => ObjectWasBeChanged<T>(sender, new EntityChangedEventArgs<T>(obj, EntityAction.Remove, string.Empty));
                res = context.SaveChanges();
            }
            return res > 0;
        }
        public virtual bool RemoveAll<T>() where T : class
        {
            ConfugurationManagerDbContext context = new();
            context.RemoveRange(context.Set<T>().AsEnumerable());
            context.SavingChanges += (sender, e) => ObjectWasBeChanged<T>(sender, new EntityChangedEventArgs<T>(null, EntityAction.Remove, "Удаление всех объектов"));
            int res = context.SaveChanges();
            return res > 0;
        }
        public bool RemoveByProperty<T>(string propertyName, string propertyValue) where T : class
        {
            var propertyInfo = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            ConfugurationManagerDbContext context = new();
            context.SavingChanges += (sender, e) => ObjectWasBeChanged<T>(sender, new EntityChangedEventArgs<T>(null, EntityAction.Remove, "Удаление всех объектов"));
            if (propertyInfo != null)
            {
                context.Set<T>().RemoveRange(context.Set<T>().AsEnumerable().Where(x => propertyValue.Equals(propertyInfo.GetValue(x)?.ToString())));
                return context.SaveChanges()>0;
            }
            else
                return context.SaveChanges()>0;
        }
    }
}
