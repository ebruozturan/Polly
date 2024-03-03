using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Polly.Application.Repositories;
using Polly.Domain.Entities;

namespace Polly.Web.Controllers
{
   public class ProjectNoteController : Controller
   {
      private readonly IUnitOfWork _uow;
      public ProjectNoteController(IUnitOfWork uow)
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
         return DataSourceLoader.Load(_uow.ProjectNoteRepository.GetProjectNoteList(), loadOptions);
      }

      [HttpPost]
      public async Task<IActionResult> Add(string values)
      {
         var newObject = new ProjectNote();
         JsonConvert.PopulateObject(values, newObject);

         //if (!TryValidateModel(newOrder))
         //   return BadProjectNote(ModelState.GetFullErrorMessage());

         await _uow.ProjectNoteRepository.AddProjectNote(newObject);

         return Ok(newObject);
      }

      [HttpPut]
      public async Task<IActionResult> Update(int key, string values)
      {
         var newObject = await _uow.ProjectNoteRepository.GetProjectNoteById(key);
         JsonConvert.PopulateObject(values, newObject);

         //if (!TryValidateModel(order))
         //   return BadProjectNote(ModelState.GetFullErrorMessage());

         await _uow.ProjectNoteRepository.UpdateProjectNote(newObject);

         return Ok(newObject);
      }


   }
}
