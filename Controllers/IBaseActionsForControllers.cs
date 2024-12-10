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

        async void ObjectWasBeChanged<T>(object sender, EntityChangedEventArgs<T> e) 
        {
            MessageForSubscribers messageForSubscribers = new();
            await messageForSubscribers.Send("", BaseMessage.GetSubscribersForMessage(""));
            bool y = false;
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
            context.Remove<T>(context.Find<T>(id));
            context.SavingChanges += (sender, e) => ObjectWasBeChanged<T>(sender, new EntityChangedEventArgs<T>(context.Find<T>(id), EntityAction.Remove, string.Empty));
            int res = context.SaveChanges();
            return res > 0;
        }
        public virtual bool RemoveAll<T>() where T : class
        {
            ConfugurationManagerDbContext context = new();
            context.RemoveRange(context.Set<T>().AsEnumerable());
            int res = context.SaveChanges();
            return res > 0;
        }
        public bool RemoveByProperty<T>(string propertyName, string propertyValue) where T : class
        {
            var propertyInfo = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            ConfugurationManagerDbContext context = new();
            if (propertyInfo != null)
            {
                context.Set<T>().RemoveRange(context.Set<T>().AsEnumerable().Where(x => propertyValue.Equals(propertyInfo.GetValue(x)?.ToString())));
                return true;
            }
            else
                return false;
        }
    }
}
