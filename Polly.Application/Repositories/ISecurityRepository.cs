using Polly.Domain.Entities;

namespace Polly.Application.Repositories
{
   public interface ISecurityRepository
   {
      Task<User> Login(string username, string password);
   }
}
