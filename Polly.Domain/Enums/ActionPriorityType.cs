using System.ComponentModel.DataAnnotations;

namespace Polly.Domain.Enums
{
   public enum ActionPriorityType : byte
   {
      [Display(Name = "Öncelik Belirtilmedi")]
      NotSpecified = 0,
      [Display(Name = "1")]
      Priority1 = 1,
      [Display(Name = "2")]
      Priority2 = 2,
      [Display(Name = "3")]
      Priority3 = 3
   }
}
