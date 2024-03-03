using Polly.Application.Repositories;
using Polly.Domain.DtoModels.EntityModels.ProjectModels;
using Polly.Domain.DtoModels.SecurityModels;
using Polly.Domain.Entities;
using Polly.Persistance.PollyContext;
using System.Linq.Expressions;

namespace Polly.Infrastructure.Repositories
{
   public class ProjectRepository : Repository, IProjectRepository
   {
      private readonly PollyDbContext _context;
      private readonly IUnitOfWork _uow;
      private readonly SessionModel _session;

      public ProjectRepository(PollyDbContext context, SessionModel session, IUnitOfWork unitOfWork) : base(context, session)
      {
         _context = context;
         _session = session;
         _uow = unitOfWork;
      }

      public async Task<string> AddProject(ProjectDto model)
      {
         try
         {
            var item = new Project()
            {
               Description = model.Description,
               Definition = model.Definition,
            };
            await Add(item);
            await _uow.SaveChanges();
            return "1";
         }
         catch (Exception e)
         {
            throw e;
         }
      }

      public async Task<string> UpdateProject(Project model)
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

      public async Task<string> DeleteProject(int id)
      {
         try
         {
            await Delete<Project>(id);
            await _uow.SaveChanges();

            return "1";
         }
         catch (Exception e)
         {
            throw e;
         }
      }

      public async Task<ProjectDto> GetProject(Expression<Func<Project, bool>> where)
      {
         var item = await Get(where);
         return new ProjectDto()
         {
            Definition = item.Definition,
            Description = item.Description,
            Id = item.Id,
         };
      }

      public async Task<ProjectDto> GetProjectDtoById(int id)
      {
         var item = await GetById<Project>(id);
         
         return new ProjectDto()
         {
            Definition = item.Definition,
            Description = item.Description,
            Id = item.Id,
         };
      }

      public async Task<Project> GetProjectById(int id)
      {
         return await GetById<Project>(id);
      }

      public IQueryable<Project> GetProjectList()
      {
         return GetList<Project>();
      }

      IQueryable<ProjectDto> IProjectRepository.GetProjectList()
      {
         throw new NotImplementedException();
      }
   }
}
