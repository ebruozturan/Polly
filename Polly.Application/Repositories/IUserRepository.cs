using Polly.Domain.Entities;
using System.Linq.Expressions;

namespace Polly.Application.Repositories
{
   public interface IUserRepository : IRepository
   {
      public IQueryable<User> GetUserList();
      public Task<User> GetUserById(int id);
      public IQueryable<User> GetUser(Expression<Func<User, bool>> where);
      public Task<string> AddUser(User model);
      public Task<string> DeleteUser(int id);
      public Task<string> UpdateUser(User model);
   }
}
