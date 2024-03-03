using Polly.Domain.DtoModels.SecurityModels;
using Polly.Domain.Entities;

namespace Polly.Application.Services.SecurityServices
{
   public interface ISessionService
   {
      SessionModel GetInjection();

      void SetSession<T>(string key, T model);

      T GetSession<T>(string key);

      void SetUser(User user);

      SessionModel GetUser();

      void CleanSession();
   }
}
