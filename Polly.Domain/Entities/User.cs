using Polly.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polly.Domain.Entities
{
   public class User : BaseEntity
   {
      [DisplayName("Ad")]
      [MinLength(3,ErrorMessage ="{0} {1} karakterden kısa olamaz.")]
      [MaxLength(50,ErrorMessage ="{0} {1} karakterden daha uzun olamaz.")]
      public string Name { get; set; }

      [DisplayName("Soyad")]
      [MinLength(3, ErrorMessage = "{0} {1} karakterden kısa olamaz.")]
      [MaxLength(50, ErrorMessage = "{0} {1} karakterden daha uzun olamaz.")]
      public string Surname { get; set; }

      [DisplayName("Ad Soyad")]
      public string FullName => Name + " " + Surname;

      [DisplayName("Email")]
      [EmailAddress]
      public string Email { get; set; }

      [DisplayName("Kullanıcı Adı")]
      [MinLength(3, ErrorMessage = "{0} {1} karakterden kısa olamaz.")]
      [MaxLength(50, ErrorMessage = "{0} {1} karakterden daha uzun olamaz.")]
      public string Username { get; set; }

      [DisplayName("Parola")]
      [MinLength(3, ErrorMessage = "{0} {1} karakterden kısa olamaz.")]
      [MaxLength(20, ErrorMessage = "{0} {1} karakterden daha uzun olamaz.")]
      public string Password { get; set; }

      [DisplayName("Parola")]
      [NotMapped]
      [MinLength(3, ErrorMessage = "{0} {1} karakterden kısa olamaz.")]
      [MaxLength(20, ErrorMessage = "{0} {1} karakterden daha uzun olamaz.")]
      public string PasswordRepeat { get; set; }

      public string ImageUrl { get; set; }

      [DisplayName("Yetki")]
      public AuthorizationType Authorization { get; set; }

      //public int CustomerId { get; set; }
   }
}
