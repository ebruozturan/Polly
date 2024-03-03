using Microsoft.AspNetCore.Mvc;
using Polly.Application.Repositories;
using Polly.Application.Services.SecurityServices;
using Polly.Web.Models.SecurityModels;

namespace Polly.Web.Controllers
{
   public class SecurityController : Controller
   {
      private readonly ISecurityRepository _security;
      private readonly ISessionService _session;

      public SecurityController(ISecurityRepository security, ISessionService session)
      {
         _security = security;
         _session = session;
      }

      public IActionResult Login()
      {
         return View();
      }

      [HttpPost]
      public async Task<IActionResult> Login(UserLoginDto model)
      {
         var result = await _security.Login(model.Username, model.Password);
         if(result == null)
         {
            ModelState.AddModelError("All", "Kullanıcı Adı veya Şifre Hatalı");
            return View(model);
         }

         _session.SetUser(result);
         return RedirectToAction("Index", "Home");
      }

      public IActionResult Logout()
      {
         _session.CleanSession();
         return RedirectToAction(nameof(Login));
      }
   }
}
