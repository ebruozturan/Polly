using Polly.Application.Repositories;
using Polly.Domain.DtoModels.SecurityModels;
using Polly.Domain.Entities;
using Polly.Persistance.PollyContext;
using System.Linq.Expressions;

namespace Polly.Infrastructure.Repositories
{
   public class ActionNoteRepository : Repository, IActionNoteRepository
   {
      private readonly PollyDbContext _context;
      private readonly IUnitOfWork _uow;
      private readonly SessionModel _session;

      public ActionNoteRepository(PollyDbContext context, SessionModel session, IUnitOfWork unitOfWork) : base(context, session)
      {
         _context = context;
         _session = session;
         _uow = unitOfWork;
      }

      public async Task<string> AddActionNote(ActionNote model)
      {
         try
         {
            await Add(model);
            await _uow.SaveChanges();
            //T.T
            return "1";
         }
         catch (Exception e)
         {
            throw e;
         }
      }

      public async Task<string> UpdateActionNote(ActionNote model)
      {
         try
         {
            Update(model);
            await _uow.SaveChanges();

            return "1";
         }
         catch (Exception e)
         {
            throw e;
         }
      }

      public async Task<string> DeleteActionNote(int id)
      {
         try
         {
            await Delete<ActionNote>(id);
            await _uow.SaveChanges();

            return "1";
         }
         catch (Exception e)
         {
            throw e;
         }
      }

      public IQueryable<ActionNote> GetActionNote(Expression<Func<ActionNote, bool>> where)
      {
         return GetQueryable(where);
      }

      public Task<ActionNote> GetActionNoteById(int id)
      {
         return GetById<ActionNote>(id);
      }

      public IQueryable<ActionNote> GetActionNoteList()
      {
         return GetList<ActionNote>();
      }
   }

}
