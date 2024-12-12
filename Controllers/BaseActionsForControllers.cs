using ConfigurationWebApiService.Data;
using ConfigurationWebApiService.Models;
using ConfigurationWebApiService.Services.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ConfigurationWebApiService.Controllers
{
    public abstract class BaseActionsForControllers
    {
        private readonly ConfugurationManagerDbContext context;
        private bool CheckObject<T>(T entity)
        {
            if (entity == null) return false;
            else if (entity.GetType() != typeof(T)) return false;
            else if (!ModelValidator<T>(entity)) return false;
            else return true;
        }
        public async void ObjectWasBeChanged<T>(EntityChangedEventArgs<T> e)
        {
            MessageForSubscribers messageForSubscribers = new();
            if (e.Entity != null && e.AffectedRows>0)
            {
                await messageForSubscribers.Send($"Сформировано событие типа {e.Action} для объекта типа {e.Entity.GetType().Name} с идентификатором {e.Entity.GetType().GetProperty("Id")?.GetValue(e.Entity)}", e?.Notes ?? string.Empty, BaseMessage.GetSubscribersForMessage([e.Action.ToString()], [e.Entity.GetType().Name.ToString()]));
            }
        }
        private bool ModelValidator<T>(T entity)
        {
            var context = new ValidationContext(entity);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(entity, context, results, true))
            {
                return false;
            }
            else
                return true;
        }
        public IEnumerable<T>? GetAll<T>() where T : class
        {
            return context.Set<T>().AsEnumerable();
        }
        public T? GetById<T>(Guid id) where T : class
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return context.Find<T>(id) ?? default(T);
        }
        public IEnumerable<T>? GetByProperty<T>(string propertyName, string propertyValue) where T : class
        {
            if ((string.IsNullOrEmpty(propertyName) && string.IsNullOrEmpty(propertyValue)) || string.IsNullOrEmpty(propertyName))
                return [];
            var propertyInfo = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            return propertyInfo == null ? [] : context.Set<T>().AsEnumerable().Where(x => string.Equals(propertyValue, propertyInfo.GetValue(x)?.ToString(), StringComparison.CurrentCultureIgnoreCase));
        }
        public virtual bool Add<T>(T entity) where T : class
        {
            if (!CheckObject(entity)) return false;
            //var context = this.context;
            context.Add<T>(entity);
            int res = context.SaveChanges();
            ObjectWasBeChanged(new EntityChangedEventArgs<T>(entity, EntityAction.Add, string.Empty,res));
            return res > 0;
        }
        private T? CheckExists<T>(T entity) where T:class
        {
            Guid guid = Guid.Empty;
            if (!Guid.TryParse(entity.GetType().GetProperty("Id")?.GetValue(entity)?.ToString(), out guid))
                return default;
            if (guid == Guid.Empty)
                return default;
            return GetById<T>(guid);
        }
        public virtual bool Update<T>(T entity) where T : class
        {
            if (!CheckObject(entity)) return false;
            //var context = this.context;
            var obj = CheckExists(entity);
            if (obj == null) return false;
            context.Update<T>(entity);
            int res = context.SaveChanges();
            ObjectWasBeChanged(new EntityChangedEventArgs<T>(entity, EntityAction.Update, string.Empty, res));
            return res > 0;
        }
        public virtual bool Remove<T>(T entity) where T : class
        {
            if (!CheckObject(entity)) return false;
            var context = this.context;
            var obj = CheckExists(entity);
            if (obj == null) return false;
            context.Remove<T>(entity);
            int res = context.SaveChanges();
            ObjectWasBeChanged(new EntityChangedEventArgs<T>(entity, EntityAction.Remove, string.Empty, res));
            return res > 0;
        }
        public virtual bool Remove<T>(Guid id) where T : class
        {
            var context = this.context;
            int res = 0;
            var obj = context.Find<T>(id);
            if (obj != null)
            {
                context.Remove<T>(obj);
                res = context.SaveChanges();
                ObjectWasBeChanged(new EntityChangedEventArgs<T>(obj, EntityAction.Remove, string.Empty, res));
            }
            return res > 0;
        }
        public virtual bool RemoveAll<T>() where T : class
        {
            context.RemoveRange(context.Set<T>().AsEnumerable());
            int res = context.SaveChanges();
            ObjectWasBeChanged(new EntityChangedEventArgs<T>(null, EntityAction.Remove, "Удаление всех объектов", res));
            return res > 0;
        }
        public bool RemoveByProperty<T>(string propertyName, string propertyValue) where T : class
        {
            if ((string.IsNullOrEmpty(propertyName) && string.IsNullOrEmpty(propertyValue)) || string.IsNullOrEmpty(propertyName))
                return false;
            int res = 0;
            var propertyInfo = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (propertyInfo != null)
            {
                context.Set<T>().RemoveRange(context.Set<T>().AsEnumerable().Where(x => string.Equals(propertyValue, propertyInfo.GetValue(x)?.ToString(), StringComparison.CurrentCultureIgnoreCase)));
                res = context.SaveChanges();
                ObjectWasBeChanged(new EntityChangedEventArgs<T>(null, EntityAction.Remove, $"Удаление объектов по заданному условию, поле {propertyName}, значение: {propertyValue}", res));
                return res > 0;
            }
            else
                return false;
        }
    }
}
