using Polly.Domain.DtoModels.SecurityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly.Application.Repositories
{
   public interface IUnitOfWork
   {
      IRepository Repository { get; }
      IActionRepository ActionRepository { get; }
      IActionNoteRepository ActionNoteRepository { get; }
      IModuleRepository ModuleRepository { get; }
      IProjectRepository ProjectRepository { get; }
      IProjectNoteRepository ProjectNoteRepository { get; }
      IRequestRepository RequestRepository { get; }
      IUserRepository UserRepository { get; }
      IVersionRepository VersionRepository { get; }
      Task<int> SaveChanges();
      SessionModel GetSession();
   }
}
