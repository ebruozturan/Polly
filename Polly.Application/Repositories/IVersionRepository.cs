using System.Linq.Expressions;
using Version = Polly.Domain.Entities.Version;

namespace Polly.Application.Repositories
{
   public interface IVersionRepository : IRepository
   {
      public IQueryable<Version> GetVersionList();
      public Task<Version> GetVersionById(int id);
      public IQueryable<Version> GetVersion(Expression<Func<Version, bool>> where);
      public Task<string> AddVersion(Version model);
      public Task<string> DeleteVersion(int id);
      public Task<string> UpdateVersion(Version model);
   }
}
