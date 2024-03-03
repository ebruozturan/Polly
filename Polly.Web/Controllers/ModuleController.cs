using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Polly.Application.Repositories;
using Polly.Domain.Entities;

namespace Polly.Web.Controllers
{
   public class ModuleController : Controller
   {
      private readonly IUnitOfWork _uow;
      public ModuleController(IUnitOfWork uow)
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
         return DataSourceLoader.Load(_uow.ModuleRepository.GetModuleList(), loadOptions);
      }

      [HttpPost]
      public async Task<IActionResult> Add(string values)
      {
         var newObject = new Module();
         JsonConvert.PopulateObject(values, newObject);

         //if (!TryValidateModel(newOrder))
         //   return BadModule(ModelState.GetFullErrorMessage());

         await _uow.ModuleRepository.AddModule(newObject);

         return Ok(newObject);
      }

      [HttpPut]
      public async Task<IActionResult> Update(int key, string values)
      {
         var newObject = await _uow.ModuleRepository.GetModuleById(key);
         JsonConvert.PopulateObject(values, newObject);

         //if (!TryValidateModel(order))
         //   return BadModule(ModelState.GetFullErrorMessage());

         await _uow.ModuleRepository.UpdateModule(newObject);

         return Ok(newObject);
      }
   }
}
