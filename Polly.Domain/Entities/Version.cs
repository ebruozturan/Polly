using Polly.Domain.Enums;
using System.ComponentModel;

namespace Polly.Domain.Entities
{
   public class Version : BaseEntity
   {
      [DisplayName("Versiyon")]
      public string Definition { get; set; }

      [DisplayName("Açıklama")]
      public string? Description { get; set; }
      public int ProjectId { get; set; }

      [DisplayName("Database Değişikliği")]
      public DatabaseChangeStatus? DatabaseChangeStatus { get; set; }

   }
}
