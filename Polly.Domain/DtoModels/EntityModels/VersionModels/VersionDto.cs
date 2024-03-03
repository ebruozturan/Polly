using Polly.Domain.Enums;
using System.ComponentModel;

namespace Polly.Domain.DtoModels.EntityModels.VersionModels
{
   public class VersionDto
   {
      [DisplayName("Versiyon")]
      public string Definition { get; set; }

      [DisplayName("Versiyon Açıklama")]
      public string? Description { get; set; }

      [DisplayName("Proje")]
      public int ProjectId { get; set; }

      [DisplayName("Database Değişikliği")]
      public DatabaseChangeStatus? DatabaseChangeStatus { get; set; }
   }
}
