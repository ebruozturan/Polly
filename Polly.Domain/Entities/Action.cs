using Polly.Domain.Enums;
using System.ComponentModel;

namespace Polly.Domain.Entities
{
   public class Action : BaseEntity
   {
      [DisplayName("Konu")]
      public string Subject { get; set; }

      [DisplayName("Açıklama")]
      public string? Description { get; set; }

      [DisplayName("Sorumlu")]
      public int ResponsibleId { get; set; }
      public User Responsible { get; set; }

      [DisplayName("Talep")]
      public int RequestId { get; set; }
      public Request Request { get; set; }

      [DisplayName("Açılma Tarihi")]
      public DateTime OpeningDate { get; set; }

      [DisplayName("Son Tarih")]
      public DateTime EndDate { get; set; }

      public ActionPriorityType PriorityType { get; set; }

      [DisplayName("Durum")]
      public ActionStatus ActionStatus { get; set; }
      public RequestStatus RequestStatus { get; set; }

      [DisplayName("Döküman")]
      public string? FileUrl { get; set; }

      public ICollection<ActionNote> ActionNotes { get; set; }
   }
}
