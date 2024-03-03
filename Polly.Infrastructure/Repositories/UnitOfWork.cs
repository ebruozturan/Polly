using Polly.Application.Repositories;
using Polly.Application.Services.SecurityServices;
using Polly.Domain.DtoModels.SecurityModels;
using Polly.Persistance.PollyContext;

namespace Polly.Infrastructure.Repositories
{
   public class UnitOfWork : IUnitOfWork
   {
      private readonly PollyDbContext _context;
      private readonly SessionModel _session;
      public UnitOfWork(PollyDbContext dbContext, ISessionService session)
      {
         _context = dbContext;
         _session = session.GetInjection();
      }

      private IRepository _repository;
      public IRepository Repository => _repository ?? (_repository = new Repository(_context, _session));

      private IActionRepository _actionRepository;
      public IActionRepository ActionRepository => _actionRepository ?? (_actionRepository = new ActionRepository(_context, _session, this));

      private IActionNoteRepository _actionNoteRepository;
      public IActionNoteRepository ActionNoteRepository => _actionNoteRepository ?? (_actionNoteRepository = new ActionNoteRepository(_context, _session, this));

      private IModuleRepository _moduleRepository;
      public IModuleRepository ModuleRepository => _moduleRepository ?? (_moduleRepository = new ModuleRepository(_context, _session, this));

      private IProjectRepository _projectRepository;
      public IProjectRepository ProjectRepository => _projectRepository ?? (_projectRepository = new ProjectRepository(_context, _session, this));

      private IProjectNoteRepository _projectNoteRepository;
      public IProjectNoteRepository ProjectNoteRepository => _projectNoteRepository ??(_projectNoteRepository = new ProjectNoteRepository(_context, _session,this));

      private IRequestRepository _requestRepository;
      public IRequestRepository RequestRepository => _requestRepository ?? (_requestRepository = new RequestRepository(_context, _session, this));

      private IUserRepository _userRepository;
      public IUserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(_context, _session, this));

      private IVersionRepository _versionRepository;
      public IVersionRepository VersionRepository => _versionRepository ??(_versionRepository = new VersionRepository(_context, _session, this));

      public async Task<int> SaveChanges()
      {
         try
         {
            return await _context.SaveChangesAsync();
         }
         catch (Exception e)
         {
            throw e;
         }
      }

      public SessionModel GetSession()
      {
         return _session;
      }
   }
}
