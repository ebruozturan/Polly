using System.ComponentModel.DataAnnotations;

namespace Polly.Domain.Enums
{
   public enum RequestType : byte
   {
      [Display(Name = "Sınıflandırılmamış")]
      Nonlisted = 1,
      [Display(Name = "Yeni Fonksiyon")]
      NewFunction = 2,
      [Display(Name = "Hata Giderme")]
      Error = 3,
      [Display(Name = "Veri Düzeltme")]
      Update = 4,      
      [Display(Name = "Veri Uyumluluk")]
      Compatibility = 5,
   }
}
