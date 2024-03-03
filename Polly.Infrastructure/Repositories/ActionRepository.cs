using Polly.Application.Repositories;
using Polly.Domain.DtoModels.EntityModels.ActionModels;
using Polly.Domain.DtoModels.SecurityModels;
using Polly.Persistance.PollyContext;
using System.Linq.Expressions;
using Action = Polly.Domain.Entities.Action;

namespace Polly.Infrastructure.Repositories
{
   public class ActionRepository : Repository, IActionRepository
   {
      private readonly PollyDbContext _context;
      private readonly IUnitOfWork _uow;
      private readonly SessionModel _session;

      public ActionRepository(PollyDbContext context, SessionModel session, IUnitOfWork unitOfWork) : base(context, session)
      {
         _context = context;
         _session = session;
         _uow = unitOfWork;
      }

      public async Task<string> AddAction(ActionDto model)
      {
         try
         {
            //await Add(model);
            await _uow.SaveChanges();
            //T.T
            return "1";
         }
         catch (Exception e)
         {
            throw e;
         }
      }

      public async Task<string> UpdateAction(ActionDto model)
      {
         try
         {
            //Update(model);
            await _uow.SaveChanges();

            return "1";
         }
         catch (Exception e)
         {
            throw e;
         }
      }

      public async Task<string> DeleteAction(int id)
      {
         try
         {
            await Delete<Action>(id);
            await _uow.SaveChanges();

            return "1";
         }
         catch (Exception e)
         {
            throw e;
         }
      }

      public IQueryable<ActionDto> GetAction(Expression<Func<Action, bool>> where)
      {
         return GetQueryable(where).Select(s => new ActionDto()
         {
            Id = s.Id,
            Subject = s.Subject,
            Description = s.Description,
            EndDate = s.EndDate,
            OpeningDate = s.OpeningDate,
            ResponsibleId = s.ResponsibleId,
            ActionStatus = s.ActionStatus,
            RequestId = s.RequestId,
            RequestStatus = s.RequestStatus, //??
            PriorityType = s.PriorityType,
         });
      }

      public async Task<ActionDto> GetActionById(int id)
      {
         var result = await GetById<Action>(id);

         return new ActionDto()
         {
            Id = result.Id,
            Subject = result.Subject,
            Description = result.Description,
            EndDate = result.EndDate,
            OpeningDate = result.OpeningDate,
            ResponsibleId = result.ResponsibleId,
            ActionStatus = result.ActionStatus,
            RequestId = result.RequestId,
            RequestStatus = result.RequestStatus, //??
            PriorityType = result.PriorityType,
         };
      }

      public IQueryable<ActionDto> GetActionList()
      {
         return GetNonDeletedAndActive<Action>().Select(s => new ActionDto()
         {
            Id = s.Id,
            Subject = s.Subject,
            Description = s.Description,
            EndDate = s.EndDate,
            OpeningDate = s.OpeningDate,
            ResponsibleId = s.ResponsibleId,
            ActionStatus = s.ActionStatus,
            RequestId = s.RequestId,
            RequestStatus = s.RequestStatus, //??
            PriorityType = s.PriorityType,
         });
      }

   }
}
