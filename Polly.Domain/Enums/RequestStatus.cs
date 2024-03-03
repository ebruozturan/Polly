using System.ComponentModel.DataAnnotations;

namespace Polly.Domain.Enums
{
   public enum RequestStatus : byte
   {
      [Display(Name = "Beklemede")]
      Waiting = 1,

      [Display(Name = "Başlandı")]
      Started = 2,

      [Display(Name = "Tamamlandı")]
      Closed = 3,

      [Display(Name = "İptal/Reddedildi")]
      Canceled = 4,
   }
}
