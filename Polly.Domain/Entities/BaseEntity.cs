using Polly.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polly.Domain.Entities
{
   public class BaseEntity
   {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }

      [Display(Name = "Oluşturulma Tarihi")]
      public DateTime CreatedOn { get; set; }

      [Display(Name = "Oluşturan Kullanıcı")]
      public string CreatedBy { get; set; }

      [Display(Name = "Değiştirilme Tarihi")]
      public DateTime LastModifiedOn { get; set; }

      [Display(Name = "Değiştiren Kullanıcı")]
      public string LastModifiedBy { get; set; }

      [Display(Name = "Durum")]
      [DefaultValue(1)]
      public Status Status { get; set; }

      [Display(Name = "Silindi Durumu")]
      [DefaultValue(0)]
      public ObjectStatus ObjectStatus { get; set; }
   }
}
