using System.ComponentModel.DataAnnotations;

namespace Polly.Domain.Enums
{
   public enum ActionStatus : byte
   {
      [Display(Name = "Beklemede")]
      Waiting = 0,

      [Display(Name = "Başlandı")]
      Started = 1,

      [Display(Name = "Tamamlandı")]
      Completed = 2,

      [Display(Name = "İptal/Reddedildi")]
      Cancel = 3
   }
}
