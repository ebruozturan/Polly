using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Polly.Domain.Entities
{
   public class ActionNote : BaseEntity
   {
      [DisplayName ("Açıklama")]
      [MinLength(10,ErrorMessage ="{0} {1} karakterden kısa olamaz")]
      [MaxLength(200,ErrorMessage ="{0} {1} karakterden uzun olamaz")]
      public string Description { get; set; }

      [DisplayName ("Ekleyen Kullanıcı")]
      public string AddedUser { get; set; }

      public int ActionId { get; set; }
      public Action Action { get; set; }
   }
}
