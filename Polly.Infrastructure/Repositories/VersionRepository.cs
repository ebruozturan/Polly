using Polly.Application.Repositories;
using Polly.Domain.DtoModels.SecurityModels;
using Polly.Domain.Entities;
using Polly.Persistance.PollyContext;
using System.Linq.Expressions;
using Version = Polly.Domain.Entities.Version;

namespace Polly.Infrastructure.Repositories
{
   public class VersionRepository : Repository, IVersionRepository
   {
      private readonly PollyDbContext _context;
      private readonly IUnitOfWork _uow;
      private readonly SessionModel _session;

      public VersionRepository(PollyDbContext context, SessionModel session, IUnitOfWork unitOfWork) : base(context, session)
      {
         _context = context;
         _session = session;
         _uow = unitOfWork;
      }

      public async Task<string> AddVersion(Version model)
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

      public async Task<string> UpdateVersion(Version model)
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

      public async Task<string> DeleteVersion(int id)
      {
         try
         {
            await Delete<Version>(id);
            await _uow.SaveChanges();

            return "1";
         }
         catch (Exception e)
         {
            throw e;
         }
      }

      public IQueryable<Version> GetVersion(Expression<Func<Version, bool>> where)
      {
         return GetQueryable(where);
      }

      public Task<Version> GetVersionById(int id)
      {
         return GetById<Version>(id);
      }

      public IQueryable<Version> GetVersionList()
      {
         return GetList<Version>();
      }
   }
}
