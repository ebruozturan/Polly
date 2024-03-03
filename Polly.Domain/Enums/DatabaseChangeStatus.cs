using System.ComponentModel.DataAnnotations;

namespace Polly.Domain.Enums
{
   public enum DatabaseChangeStatus
   {
      [Display(Name = "Hayır")]
      No = 0,

      [Display(Name = "Evet")]
      Yes = 1,
   }
}
