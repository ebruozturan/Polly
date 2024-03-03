using Polly.Domain.Enums;
using System.ComponentModel;

namespace Polly.Domain.DtoModels.EntityModels.ActionModels
{
   public class ActionDto
   {
      public int Id { get; set; }

      [DisplayName("Aksiyon Konusu")]
      public string Subject { get; set; }

      [DisplayName("Aksiyon Açıklaması")]
      public string? Description { get; set; }

      [DisplayName("Sorumlu")]
      public int ResponsibleId { get; set; }

      [DisplayName("Talep")]
      public int RequestId { get; set; }

      [DisplayName("Açılma Tarihi")]
      public DateTime OpeningDate { get; set; }

      [DisplayName("Son Tarih")]
      public DateTime EndDate { get; set; }

      [DisplayName("Oluşturulma Tarihi")]
      public DateTime CreatedOn { get; set; }

      [DisplayName("Oluşturan")]
      public string CreatedBy { get; set; }

      public ActionPriorityType PriorityType { get; set; }

      [DisplayName("Durum")]
      public ActionStatus ActionStatus { get; set; }

      [DisplayName("Talep Durum")]
      public RequestStatus RequestStatus { get; set; }

   }
}
