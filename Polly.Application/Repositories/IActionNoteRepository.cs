using Polly.Domain.Entities;
using System.Linq.Expressions;

namespace Polly.Application.Repositories
{
   public interface IActionNoteRepository : IRepository
   {
      public IQueryable<ActionNote> GetActionNoteList();
      public Task<ActionNote> GetActionNoteById(int id);
      public IQueryable<ActionNote> GetActionNote(Expression<Func<ActionNote, bool>> where);
      public Task<string> AddActionNote(ActionNote model);
      public Task<string> DeleteActionNote(int id);
      public Task<string> UpdateActionNote(ActionNote model);
   }
}
