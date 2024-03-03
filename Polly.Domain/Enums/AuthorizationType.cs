using System.ComponentModel.DataAnnotations;

namespace Polly.Domain.Enums
{
   public enum AuthorizationType : byte
   {
      [Display(Name ="Geliştirici")]
      Developer = 1,
      [Display(Name = "Yönetici")]
      Admin = 2,
      [Display(Name = "Ekip Lideri")]
      TeamLeader = 3,
      [Display(Name = "Kullanıcı")]
      User = 4,
   }
}
