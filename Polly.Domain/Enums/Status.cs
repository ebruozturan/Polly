using System.ComponentModel.DataAnnotations;

namespace Polly.Domain.Enums
{
   public enum Status : byte
   {
      [Display(Name ="Aktif")]
      Active = 1,
      [Display(Name = "Aktif Değil")]
      Pasive = 0,
   }
}
