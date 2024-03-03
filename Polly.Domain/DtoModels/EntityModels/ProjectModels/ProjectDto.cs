using System.ComponentModel;

namespace Polly.Domain.DtoModels.EntityModels.ProjectModels
{
   public class ProjectDto
   {
      public int Id { get; set; }

      [DisplayName("Proje Adı")]
      public string Definition { get; set; }

      [DisplayName("Proje Açıklaması")]
      public string? Description { get; set; }
   }
}
