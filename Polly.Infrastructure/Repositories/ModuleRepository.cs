using Polly.Application.Repositories;
using Polly.Domain.DtoModels.SecurityModels;
using Polly.Domain.Entities;
using Polly.Persistance.PollyContext;
using System.Linq.Expressions;

namespace Polly.Infrastructure.Repositories
{
   public class ModuleRepository : Repository, IModuleRepository
   {
      private readonly PollyDbContext _context;
      private readonly IUnitOfWork _uow;
      private readonly SessionModel _session;

      public ModuleRepository(PollyDbContext context, SessionModel session, IUnitOfWork unitOfWork) : base(context, session)
      {
         _context = context;
         _session = session;
         _uow = unitOfWork;
      }

      public async Task<string> AddModule(Module model)
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

      public async Task<string> UpdateModule(Module model)
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

      public async Task<string> DeleteModule(int id)
      {
         try
         {
            await Delete<Module>(id);
            await _uow.SaveChanges();

            return "1";
         }
         catch (Exception e)
         {
            throw e;
         }
      }

      public IQueryable<Module> GetModule(Expression<Func<Module, bool>> where)
      {
         return GetQueryable(where);
      }

      public Task<Module> GetModuleById(int id)
      {
         return GetById<Module>(id);
      }

      public IQueryable<Module> GetModuleList()
      {
         return GetList<Module>();
      }
   }
}