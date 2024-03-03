using System.ComponentModel;

namespace Polly.Domain.DtoModels.EntityModels.ModuleModels
{
   public class ModuleDto
   {
      [DisplayName("Modül Adı")]
      public string Definition { get; set; }

      [DisplayName("Modül Açıklaması")]
      public string? Description { get; set; }

      [DisplayName("Proje")]
      public int ProjectId { get; set; }
   }
}
