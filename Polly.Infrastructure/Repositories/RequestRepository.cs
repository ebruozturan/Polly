using Polly.Application.Repositories;
using Polly.Domain.DtoModels.SecurityModels;
using Polly.Domain.Entities;
using Polly.Persistance.PollyContext;
using System.Linq.Expressions;

namespace Polly.Infrastructure.Repositories
{
   public class RequestRepository : Repository, IRequestRepository
   {
      private readonly PollyDbContext _context;
      private readonly IUnitOfWork _uow;
      private readonly SessionModel _session;

      public RequestRepository(PollyDbContext context, SessionModel session, IUnitOfWork unitOfWork) : base(context, session)
      {
         _context = context;
         _session = session;
         _uow = unitOfWork;
      }

      public async Task<string> AddRequest(Request model)
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

      public async Task<string> UpdateRequest(Request model)
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

      public async Task<string> DeleteRequest(int id)
      {
         try
         {
            await Delete<Request>(id);
            await _uow.SaveChanges();

            return "1";
         }
         catch (Exception e)
         {
            throw e;
         }
      }

      public IQueryable<Request> GetRequest(Expression<Func<Request, bool>> where)
      {
         return GetQueryable(where);
      }

      public Task<Request> GetRequestById(int id)
      {
         return GetById<Request>(id);
      }

      public IQueryable<Request> GetRequestList()
      {
         return GetList<Request>();
      }
   }
}
