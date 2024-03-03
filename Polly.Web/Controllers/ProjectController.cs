using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Polly.Application.Repositories;
using Polly.Domain.DtoModels.EntityModels.ProjectModels;

namespace Polly.Web.Controllers
{
   public class ProjectController : Controller
   {
      private readonly IUnitOfWork _uow;
      public ProjectController(IUnitOfWork uow)
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
         return DataSourceLoader.Load(_uow.ProjectRepository.GetProjectList(), loadOptions);
      }

      [HttpPost]
      public async Task<IActionResult> Add(string values)
      {
         var newObject = new ProjectDto();
         JsonConvert.PopulateObject(values, newObject);

         if (!TryValidateModel(newObject))
            return BadRequest(/*ModelState.GetFullErrorMessage()*/);

         await _uow.ProjectRepository.AddProject(newObject);

         return Ok(newObject);
      }

      [HttpPut]
      public async Task<IActionResult> Update(int key, string values)
      {
         var newObject = await _uow.ProjectRepository.GetProjectById(key);
         JsonConvert.PopulateObject(values, newObject);

         //if (!TryValidateModel(order))
         //   return BadProject(ModelState.GetFullErrorMessage());

         await _uow.ProjectRepository.UpdateProject(newObject);

         return Ok(newObject);
      }

      [HttpDelete]
      public async void DeleteOrder(int key)
      {
         var newObject = await _uow.ProjectRepository.GetProjectById(key);

         await _uow.ProjectRepository.DeleteProject(newObject.Id);

         return;
      }
   }
}
