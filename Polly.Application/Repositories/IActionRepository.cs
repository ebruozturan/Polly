using Polly.Domain.DtoModels.EntityModels.ActionModels;
using System.Linq.Expressions;
using Action = Polly.Domain.Entities.Action;

namespace Polly.Application.Repositories
{
   public interface IActionRepository : IRepository
   {
      public IQueryable<ActionDto> GetActionList();
      public Task<ActionDto> GetActionById(int id);
      public IQueryable<ActionDto> GetAction(Expression<Func<Action, bool>> where);
      public Task<string> AddAction(ActionDto model);
      public Task<string> DeleteAction(int id);
      public Task<string> UpdateAction(ActionDto model);
   }
}
