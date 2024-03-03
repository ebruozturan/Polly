using Microsoft.EntityFrameworkCore;
using Polly.Application.Repositories;
using Polly.Domain.DtoModels.SecurityModels;
using Polly.Domain.DtoModels.SelectModels;
using Polly.Domain.Entities;
using Polly.Domain.Enums;
using Polly.Persistance.PollyContext;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace Polly.Infrastructure.Repositories
{
   public class Repository : IRepository
   {
      public readonly PollyDbContext context;

      public readonly SessionModel session;

      public Repository(PollyDbContext _context, SessionModel _session)
      {
         context = _context;
         session = _session;
      }

      private DbSet<T> GetTable<T>() where T : BaseEntity
      {
         return context.Set<T>();
      }

      public async Task<T> Add<T>(T _object) where T : BaseEntity
      {
         try
         {
            var time = DateTime.Now;
            _object.Status = Status.Active;
            _object.ObjectStatus = ObjectStatus.NonDeleted;
            _object.CreatedOn = time;
            _object.CreatedBy = session.FullName;
            _object.LastModifiedOn = time;
            _object.LastModifiedBy = session.FullName;
            await GetTable<T>().AddAsync(_object);
            return _object;
         }
         catch (Exception e)
         {
            throw e;
         }
      }

      public T Update<T>(T _object) where T : BaseEntity
      {
         try
         {
            _object.LastModifiedBy = session.FullName;
            _object.LastModifiedOn = DateTime.Now;
            GetTable<T>().Update(_object);
            return _object;
         }
         catch (Exception e)
         {
            throw e;
         }
      }

      public async Task UpdateRange<T>(ICollection<T> _objectList) where T : BaseEntity
      {
         try
         {
            var time = DateTime.Now;
            foreach (var item in _objectList)
            {
               item.LastModifiedOn = time;
               item.LastModifiedBy = session.FullName;
            }

            GetTable<T>().UpdateRange(_objectList);
         }
         catch (Exception e)
         {

            throw e;
         }
      }

      public async Task<T> Delete<T>(int id) where T : BaseEntity
      {
         try
         {
            var _object = await GetById<T>(id);
            _object.ObjectStatus = ObjectStatus.Deleted;
            _object.Status = Status.Pasive;
            return Update<T>(_object);
         }
         catch (Exception e)
         {
            throw e;
         }
      }

      public async Task DeleteRange<T>(ICollection<T> _objectList) where T : BaseEntity
      {
         try
         {
            foreach (var item in _objectList)
            {
               item.ObjectStatus = ObjectStatus.Deleted;
               item.Status = Status.Pasive;
            }
            await UpdateRange(_objectList);
         }
         catch (Exception e)
         {
            throw e;
         }
      }

      public async Task<T> GetById<T>(int id) where T : BaseEntity
      {
         try
         {
            return await GetTable<T>().FindAsync(id);
         }
         catch (Exception e)
         {
            throw e;
         }
      }

      public IQueryable<T> GetList<T>(Expression<Func<T, bool>> where = null) where T : BaseEntity
      {
         try
         {
            return GetTable<T>().Where(where);
         }
         catch (Exception e)
         {

            throw e;
         }
      }

      public IQueryable<T> GetNonDeletedAndActive<T>(Expression<Func<T, bool>> expression = null) where T : BaseEntity
      {
         try
         {
            return GetQueryable(expression).Where(t => t.Status == Status.Active && t.ObjectStatus == ObjectStatus.NonDeleted);
         }
         catch (Exception e)
         {
            throw e;
         }
      }

      public IQueryable<T> GetQueryable<T>(Expression<Func<T, bool>> where) where T : BaseEntity
      {
         return GetTable<T>().Where(where);
      }

      public async Task<T> Get<T>(Expression<Func<T, bool>> where) where T : BaseEntity
      {
         try
         {
            return await GetTable<T>().FirstOrDefaultAsync(where);
         }
         catch (Exception e)
         {
            throw e;
         }
      }

      public string GetDisplayValue<E>(E value)
      {
         var fieldInfo = value.GetType().GetField(value.ToString());

         var descriptionAttributes = fieldInfo.GetCustomAttributes(
                 typeof(DisplayAttribute), false) as DisplayAttribute[];

         if (descriptionAttributes[0].ResourceType != null)
            return LookUpResource(descriptionAttributes[0].ResourceType, descriptionAttributes[0].Name);

         if (descriptionAttributes == null) return string.Empty;
         return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
      }

      public List<SelectModel> GetEnumSelect<E>()
      {
         return (Enum.GetValues(typeof(E)).Cast<E>().Select(e => new SelectModel() { Text = GetDisplayValue<E>(e), Value = e.ToString(), Id = Convert.ToInt32(e) })).ToList();
      }

      public string LookUpResource(Type resourceManagerProvider, string resourceKey)
      {
         foreach (PropertyInfo staticProperty in resourceManagerProvider.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
         {
            if (staticProperty.PropertyType == typeof(System.Resources.ResourceManager))
            {
               System.Resources.ResourceManager resourceManager = (System.Resources.ResourceManager)staticProperty.GetValue(null, null);
               return resourceManager.GetString(resourceKey);
            }
         }

         return resourceKey;
      }

   }
}
