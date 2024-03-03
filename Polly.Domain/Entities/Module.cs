using System.ComponentModel;

namespace Polly.Domain.Entities
{
   public class Module : BaseEntity
   {
      [DisplayName("Modül Adı")]
      public string Definition { get; set; }

      [DisplayName("Modül Açıklaması")]
      public string? Description { get; set; }

      public int ProjectId { get; set; }
   }
}
