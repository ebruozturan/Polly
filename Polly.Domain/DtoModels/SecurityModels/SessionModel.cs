namespace Polly.Domain.DtoModels.SecurityModels
{
   public class SessionModel
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public string Surname { get; set; }
      public string FullName => Name + " " + Surname;
      public string ImageUrl { get; set; }
   }
}
