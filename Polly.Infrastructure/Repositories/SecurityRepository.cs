using Microsoft.EntityFrameworkCore;
using Polly.Application.Repositories;
using Polly.Domain.Entities;
using Polly.Domain.Enums;
using Polly.Persistance.PollyContext;

namespace Polly.Infrastructure.Repositories
{
   public class SecurityRepository : ISecurityRepository
   {
      private readonly PollyDbContext _context;
      public SecurityRepository(PollyDbContext context)
      {
         _context = context;
      }

      public async Task<User> Login(string username, string password)
      {
         return await _context.Users.FirstOrDefaultAsync(t => (t.Username == username || t.Email == username) && t.Password == password && t.ObjectStatus == ObjectStatus.NonDeleted && t.Status == Status.Active);
      }

   }
}
