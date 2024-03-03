using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Polly.Domain.Entities;

namespace Polly.Persistance.Seeds
{
   public class UserSeed : IEntityTypeConfiguration<User>
   {
      public void Configure(EntityTypeBuilder<User> builder)
      {
         builder.HasData(new User
         {
            Id = 1,
            CreatedBy = "System",
            CreatedOn = DateTime.Now,
            LastModifiedBy = "-",
            LastModifiedOn = DateTime.Now,
            Name = "Admin",
            Surname = "Admin",
            Email = "admin@polly.com",
            Password = "123456",
            Status = Domain.Enums.Status.Active,
            ObjectStatus = Domain.Enums.ObjectStatus.NonDeleted,
            Authorization = Domain.Enums.AuthorizationType.Developer,
            ImageUrl = "",
            Username = "Dev"
         }); ;
      }
   }
}
