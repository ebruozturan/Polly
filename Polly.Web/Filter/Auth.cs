using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Polly.Web.Filter
{
   public class Auth : ResultFilterAttribute, IAuthorizationFilter
   {
      public void OnAuthorization(AuthorizationFilterContext context)
      {
         var session = context.HttpContext.Session;

         Byte[] ss;
         var ctry = session.TryGetValue("login", out ss);
         if (!ctry)
         {
            var uri = context.HttpContext.Request.Path;
            //context.Result = new RedirectToActionResult("Login", "Security", new { uri });
            context.Result = new RedirectResult("/Security/Login");
            return;
         }
      }
   }
}
