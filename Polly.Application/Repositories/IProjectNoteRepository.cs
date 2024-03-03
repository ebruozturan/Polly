using Polly.Domain.Entities;
using System.Linq.Expressions;

namespace Polly.Application.Repositories
{
   public interface IProjectNoteRepository : IRepository
   {
      public IQueryable<ProjectNote> GetProjectNoteList();
      public Task<ProjectNote> GetProjectNoteById(int id);
      public IQueryable<ProjectNote> GetProjectNote(Expression<Func<ProjectNote, bool>> where);
      public Task<string> AddProjectNote(ProjectNote model);
      public Task<string> DeleteProjectNote(int id);
      public Task<string> UpdateProjectNote(ProjectNote model);
   }
}
