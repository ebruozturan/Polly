using Polly.Application.Repositories;
using Polly.Domain.DtoModels.SecurityModels;
using Polly.Domain.Entities;
using Polly.Persistance.PollyContext;
using System.Linq.Expressions;

namespace Polly.Infrastructure.Repositories
{
   public class ProjectNoteRepository : Repository, IProjectNoteRepository
   {
      private readonly PollyDbContext _context;
      private readonly IUnitOfWork _uow;
      private readonly SessionModel _session;


      public ProjectNoteRepository(PollyDbContext context, SessionModel session, IUnitOfWork unitOfWork) : base(context, session)
      {
         _context = context;
         _session = session;
         _uow = unitOfWork;
      }

      public async Task<string> AddProjectNote(ProjectNote model)
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

      public async Task<string> UpdateProjectNote(ProjectNote model)
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

      public async Task<string> DeleteProjectNote(int id)
      {
         try
         {
            await Delete<ProjectNote>(id);
            await _uow.SaveChanges();

            return "1";
         }
         catch (Exception e)
         {
            throw e;
         }
      }

      public IQueryable<ProjectNote> GetProjectNote(Expression<Func<ProjectNote, bool>> where)
      {
         return GetQueryable(where);
      }

      public Task<ProjectNote> GetProjectNoteById(int id)
      {
         return GetById<ProjectNote>(id);
      }

      public IQueryable<ProjectNote> GetProjectNoteList()
      {
         return GetList<ProjectNote>();
      }
   }
}
