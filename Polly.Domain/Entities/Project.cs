using System.ComponentModel;

namespace Polly.Domain.Entities
{
   public class Project : BaseEntity
   {
      [DisplayName("Proje Adı")]
      public string Definition { get; set; }

      [DisplayName("Proje Açıklaması")]
      public string? Description { get; set; }
      public ICollection<Request> Requests { get; set; }
      public ICollection<ProjectNote> Notes { get; set; }
      public ICollection<Version> Versions { get; set; }
      public ICollection<Module> Modules { get; set; }
   }
}
