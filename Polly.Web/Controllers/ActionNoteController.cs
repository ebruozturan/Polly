using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Polly.Application.Repositories;
using Polly.Domain.Entities;

namespace Polly.Web.Controllers
{
   public class ActionNoteController : Controller
   {
      private readonly IUnitOfWork _uow;
      public ActionNoteController(IUnitOfWork uow)
      {
         _uow = uow;
      }

      public IActionResult List()
      {
         return View();
      }

      [HttpGet]
      public async Task<object> Get(DataSourceLoadOptions loadOptions)
      {
         return DataSourceLoader.Load(_uow.ActionNoteRepository.GetActionNoteList(), loadOptions);
      }

      [HttpPost]
      public async Task<IActionResult> Add(string values)
      {
         var newObject = new ActionNote();
         JsonConvert.PopulateObject(values, newObject);

         //if (!TryValidateModel(newOrder))
         //   return BadActionNote(ModelState.GetFullErrorMessage());

         await _uow.ActionNoteRepository.AddActionNote(newObject);

         return Ok(newObject);
      }

      [HttpPut]
      public async Task<IActionResult> Update(int key, string values)
      {
         var newObject = await _uow.ActionNoteRepository.GetActionNoteById(key);
         JsonConvert.PopulateObject(values, newObject);

         //if (!TryValidateModel(order))
         //   return BadActionNote(ModelState.GetFullErrorMessage());

         await _uow.ActionNoteRepository.UpdateActionNote(newObject);

         return Ok(newObject);
      }
   }
}
