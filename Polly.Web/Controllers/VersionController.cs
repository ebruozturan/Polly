using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Polly.Application.Repositories;
using Version = Polly.Domain.Entities.Version;

namespace Polly.Web.Controllers
{
   public class VersionController : Controller
   {
      private readonly IUnitOfWork _uow;
      public VersionController(IUnitOfWork uow)
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
         return DataSourceLoader.Load(_uow.VersionRepository.GetVersionList(), loadOptions);
      }

      [HttpPost]
      public async Task<IActionResult> Add(string values)
      {
         var newObject = new Version();
         JsonConvert.PopulateObject(values, newObject);

         //if (!TryValidateModel(newOrder))
         //   return BadVersion(ModelState.GetFullErrorMessage());

         await _uow.VersionRepository.AddVersion(newObject);

         return Ok(newObject);
      }

      [HttpPut]
      public async Task<IActionResult> Update(int key, string values)
      {
         var newObject = await _uow.VersionRepository.GetVersionById(key);
         JsonConvert.PopulateObject(values, newObject);

         //if (!TryValidateModel(order))
         //   return BadVersion(ModelState.GetFullErrorMessage());

        await _uow.VersionRepository.UpdateVersion(newObject);

         return Ok(newObject);
      }
   }
}
