using Polly.Domain.Entities;
using System.Linq.Expressions;

namespace Polly.Application.Repositories
{
   public interface IRequestRepository : IRepository
   {
      public IQueryable<Request> GetRequestList();
      public Task<Request> GetRequestById(int id);
      public IQueryable<Request> GetRequest(Expression<Func<Request, bool>> where);
      public Task<string> AddRequest(Request model);
      public Task<string> DeleteRequest(int id);
      public Task<string> UpdateRequest(Request model);
   }
}
