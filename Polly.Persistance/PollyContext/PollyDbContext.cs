using Microsoft.EntityFrameworkCore;
using Polly.Domain.Entities;

namespace Polly.Persistance.PollyContext
{
   public class PollyDbContext : DbContext
   {
      public PollyDbContext(DbContextOptions options) : base(options)
      {
      }

      public DbSet<Domain.Entities.Action> Actions { get; set; }
      public DbSet<ActionNote> ActionNotes { get; set; }
      public DbSet<Module> Modules { get; set; }
      public DbSet<Project> Projects { get; set; }
      public DbSet<ProjectNote> ProjectNotes { get; set; }
      public DbSet<Request> Requests { get; set; }
      public DbSet<User> Users { get; set; }
      public DbSet<Domain.Entities.Version> Versions { get; set; }
      
   }
}

//   protected ISessionService _session;

//public PollyDbContext(DbContextOptions options, ISessionService session) : base(options)
//      {
//   _session = session;
//}

//public override int SaveChanges()
//{
//   SetBaseObjectValues();

//   return base.SaveChanges();
//}

//private void SetBaseObjectValues()
//{
//   var user = _session.GetUser();

//   var userName = user != null ? user.FullName : "-";

//   ChangeTracker.DetectChanges();

//   var entries = ChangeTracker.Entries();

//   foreach (var entry in entries)
//   {
//      if (entry.Entity is BaseEntity trackable)
//      {
//         var now = DateTime.Now;

//         switch (entry.State)
//         {
//            case EntityState.Modified:
//               trackable.LastModifiedOn = now;
//               trackable.LastModifiedBy = userName;
//               break;

//            case EntityState.Added:
//               trackable.LastModifiedOn = now;
//               trackable.CreatedOn = now;  
//               trackable.CreatedBy = userName;
//               trackable.LastModifiedBy = userName;
//               trackable.Status = Status.Active;
//               trackable.ObjectStatus = ObjectStatus.NonDeleted;
//               break;
//         }
//      }
//   }
//}


//private readonly ISessionService _session;

//public PollyDbContext(DbContextOptions options, ISessionService session) : base(options)
//      {
//   _session = session;
//}

//public override int SaveChanges()
//{
//   SetBaseObjectValues();

//   return base.SaveChanges();
//}

//private void SetBaseObjectValues()
//{
//   var user = _session.GetUser();

//   var userName = user != null ? user.FullName : "-";

//   ChangeTracker.DetectChanges();

//   var entries = ChangeTracker.Entries();

//   foreach (var entry in entries)
//   {
//      if (entry.Entity is BaseEntity trackable)
//      {
//         var now = DateTime.Now;

//         switch (entry.State)
//         {
//            case EntityState.Modified:
//               trackable.LastModifiedOn = now;
//               trackable.LastModifiedBy = userName;
//               break;

//            case EntityState.Added:
//               trackable.LastModifiedOn = now;
//               trackable.CreatedOn = now;
//               trackable.CreatedBy = userName;
//               trackable.LastModifiedBy = userName;
//               trackable.Status = Status.Active;
//               trackable.ObjectStatus = ObjectStatus.NonDeleted;
//               break;
//         }
//      }
//   }
//}

