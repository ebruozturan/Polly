using System.Web.Mvc;

namespace Polly.Helper.Extentions;

public static class ModelStateValidationHelper
{
  public static IEnumerable<object> GetModelErrorList(ModelStateDictionary modelstate)
  {
    var errorModel =
      from x in modelstate.Keys
      where modelstate[x].Errors.Count > 0
      select new
      {
        key = x,
        errors = modelstate[x].Errors.
          Select(y => y.ErrorMessage).
          ToArray()
      };

    return errorModel;
  }

  public static string GetFullErrorMessage(this ModelStateDictionary modelState) {
    var messages = (from entry in modelState from error in entry.Value.Errors select error.ErrorMessage).ToList();

    return string.Join(" ", messages);
  }
}