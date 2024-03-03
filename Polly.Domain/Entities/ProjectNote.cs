using System.ComponentModel.DataAnnotations;

namespace Polly.Domain.Entities
{
   public class ProjectNote : BaseEntity
   {
      [Display(Name ="Açıklama")]
      [MinLength(10,ErrorMessage ="{0} {1} karakterden kısa olamaz")]
      [MaxLength(200,ErrorMessage ="{0} {1} karakterden uzun olamaz")]
      public string Description { get; set; }

      [Display(Name = "Ekleyen Kullanıcı")]
      public string AddedUser { get; set; }

      public int ProjectId { get; set; }
      public Project Project { get; set; }
   }
}
