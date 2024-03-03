using Polly.Domain.DtoModels.SelectModels;
using Polly.Domain.Entities;
using System.Linq.Expressions;

namespace Polly.Application.Repositories
{
   public interface IRepository
   {
      Task<T> Add<T>(T _object) where T : BaseEntity;
      T Update<T>(T _object) where T : BaseEntity;
      Task<T> Delete<T>(int id) where T : BaseEntity;
      Task<T> GetById<T>(int id) where T : BaseEntity;
      //IQueryable<T> GetList<T>(Expression<Func<T, bool>> where) where T : BaseEntity;
      IQueryable<T> GetList<T>(Expression<Func<T, bool>> where = null) where T : BaseEntity;
      IQueryable<T> GetNonDeletedAndActive<T>(Expression<Func<T, bool>> expression = null) where T : BaseEntity;
      Task<T> Get<T>(Expression<Func<T, bool>> expression = null) where T : BaseEntity;
      //IQueryable<T> GetNonDeletedAndActive<T>(Expression<Func<T, bool>> expression) where T : BaseEntity;

      //Task<T> Get(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties) where T : BaseEntity;

      List<SelectModel> GetEnumSelect<E>();
      string GetDisplayValue<E>(E value);
      string LookUpResource(Type resourceManagerProvider, string resourceKey);
   }
}
