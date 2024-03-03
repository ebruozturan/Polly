using Polly.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Polly.Domain.Entities
{
   public class Request : BaseEntity
   {
      [DisplayName("Konu")]
      [MinLength(3, ErrorMessage = "{0} {1} karakterden kısa olamaz")]
      [MaxLength(100, ErrorMessage = "{0} {1} karakterden uzun olamaz")]
      public string Subject { get; set; }

      [DisplayName("Açıklama")]
      [MinLength(10, ErrorMessage = "{0} {1} karakterden kısa olamaz")]
      [MaxLength(300, ErrorMessage = "{0} {1} karakterden uzun olamaz")]
      public string Description { get; set; }

      [DisplayName("Ekleyen Kullanıcı")]
      public string AddedUser { get; set; }

      [DisplayName("Bitiş Tarihi")]
      public DateTime PlanedEndDate { get; set; }

      [DisplayName("Talep Tipi")]
      public RequestType RequestType { get; set; }

      [DisplayName("Sayfa Url")]
      public string? Url { get; set; }

      [DisplayName("Görüntü")]
      public string? ImageUrl { get; set; }

      [DisplayName("Talep Durumu")]
      public RequestStatus RequestStatus { get; set; }

      //[DisplayName("Aksiyon Durumu")]
      //public ActionType ActionType { get; set; }

      public ICollection<Action> Actions { get; set; }

      public int ProjectId { get; set; }
      public Project Project { get; set; }
   }
}
