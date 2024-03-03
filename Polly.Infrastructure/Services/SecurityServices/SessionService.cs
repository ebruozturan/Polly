using Microsoft.AspNetCore.Http;
using Polly.Application.Services.SecurityServices;
using Polly.Domain.DtoModels.SecurityModels;
using Polly.Domain.Entities;
using System.Text;
using System.Text.Json;

namespace Polly.Infrastructure.Services.SecurityServices
{
   public class SessionService : ISessionService
   {
      private readonly IHttpContextAccessor _httpContextAccessor;

      public SessionService(IHttpContextAccessor httpContextAccessor)
      {
         _httpContextAccessor = httpContextAccessor;
      }

      public void CleanSession()
      {
         _httpContextAccessor.HttpContext.Session.Clear();
      }

      public SessionModel GetInjection()
      {
         var user = new SessionModel();

         if (_httpContextAccessor.HttpContext == null)
         {
            user.Id = -1;
            return user;
         }

         //var val = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

         //if (val != null)
         //{
         //   var val2 = httpContextAccessor.HttpContext.User.FindFirst("CustomerID");

         //   if (val2 != null)
         //      user.CustomerId = Convert.ToInt32(val2.Value);


         //   if (val != null)
         //      user.ID = Convert.ToInt32(val.Value);
         //}
         //else
         //{

         var usr = GetUser();
         if (usr != null)
            user = usr;
         //}

         return user;
      }

      public T GetSession<T>(string key)
      {
         byte[] ss;
         var ctry = _httpContextAccessor.HttpContext.Session.TryGetValue(key, out ss);
         if (!ctry)
            return default(T);
         if (ss == null)
            return default(T);
         return FromByteArray<T>(ss);
      }

      public SessionModel GetUser()
      {
         return GetSession<SessionModel>("login");
      }

      public void SetSession<T>(string key, T model)
      {
         var ss = ToByteArray(model);
         _httpContextAccessor.HttpContext.Session.Set(key, ss);
      }

      public void SetUser(User user)
      {
         var sessionModel = new SessionModel()
         {
            Id = user.Id,
            Name = user.Name,
            Surname = user.Name,
            ImageUrl = user.ImageUrl,
         };
         var ss = ToByteArray(sessionModel);
         _httpContextAccessor.HttpContext.Session.Set("login", ss);
      }

      public T FromByteArray<T>(byte[] data)
      {
         if (data == null)
            return default(T);
         var stringObj = Encoding.ASCII.GetString(data);
         return JsonSerializer.Deserialize<T>(stringObj);
      }

      public byte[] ToByteArray<T>(T obj)
      {
         var objToString = JsonSerializer.Serialize(obj);
         return Encoding.ASCII.GetBytes(objToString);
      }
   }
}
