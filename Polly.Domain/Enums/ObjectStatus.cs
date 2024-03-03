using System.ComponentModel.DataAnnotations;

namespace Polly.Domain.Enums
{
   public enum ObjectStatus : byte
   {
      [Display(Name ="Silinmiş")]
      Deleted = 1,
      NonDeleted = 0,
   }
}
