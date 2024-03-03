using Polly.Domain.Entities;
using Polly.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Polly.Domain.DtoModels.EntityModels.RequestModels
{
   public class RequestDto
   {
      public int Id { get; set; }

      [DisplayName("Talep Konusu")]
      [MinLength(3, ErrorMessage = "{0} {1} karakterden kısa olamaz")]
      [MaxLength(100, ErrorMessage = "{0} {1} karakterden uzun olamaz")]
      public string Subject { get; set; }

      [DisplayName("Talep Açıklama")]
      [MinLength(10, ErrorMessage = "{0} {1} karakterden kısa olamaz")]
      [MaxLength(300, ErrorMessage = "{0} {1} karakterden uzun olamaz")]
      public string Description { get; set; }

      [DisplayName("Ekleyen Kullanıcı")]
      public string AddedUser { get; set; }

      [DisplayName("Bitiş Tarihi")]
      public DateTime PlanedEndDate { get; set; }

      [DisplayName("Talep Tipi")]
      public RequestType RequestType { get; set; }

      [DisplayName("Talep Durumu")]
      public RequestStatus RequestStatus { get; set; }

      [DisplayName("Aksiyon Durumu")]
      public ActionType ActionType { get; set; }

      public int ProjectId { get; set; }
      public Project Project { get; set; }
   }
}
