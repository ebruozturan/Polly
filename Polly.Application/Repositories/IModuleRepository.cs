using Polly.Domain.Entities;
using System.Linq.Expressions;

namespace Polly.Application.Repositories
{
   public interface IModuleRepository : IRepository
   {
      public IQueryable<Module> GetModuleList();
      public Task<Module> GetModuleById(int id);
      public IQueryable<Module> GetModule(Expression<Func<Module, bool>> where);
      public Task<string> AddModule(Module model);
      public Task<string> DeleteModule(int id);
      public Task<string> UpdateModule(Module model);
   }
}
