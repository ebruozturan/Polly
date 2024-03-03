using Polly.Domain.DtoModels.EntityModels.ProjectModels;
using Polly.Domain.Entities;
using System.Linq.Expressions;

namespace Polly.Application.Repositories
{
   public interface IProjectRepository : IRepository
   {
      public IQueryable<ProjectDto> GetProjectList();
      public Task<ProjectDto> GetProjectDtoById(int id);
      public Task<Project> GetProjectById(int id);
      public Task<ProjectDto> GetProject(Expression<Func<Project, bool>> where);
      public Task<string> AddProject(ProjectDto model);
      public Task<string> DeleteProject(int id);
      public Task<string> UpdateProject(Project model);
   }
}
