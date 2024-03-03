using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Polly.Application.Repositories;
using Polly.Domain.Entities;

namespace Polly.Web.Controllers
{
   public class RequestController : Controller
   {
      private readonly IUnitOfWork _uow;
      public RequestController(IUnitOfWork uow)
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
         return DataSourceLoader.Load(_uow.RequestRepository.GetRequestList(), loadOptions);
      }

      [HttpPost]
      public async Task<IActionResult> Add(string values)
      {
         var newObject = new Request();
         JsonConvert.PopulateObject(values, newObject);

         //if (!TryValidateModel(newOrder))
         //   return BadRequest(ModelState.GetFullErrorMessage());

         await _uow.RequestRepository.AddRequest(newObject);

         return Ok(newObject);
      }

      [HttpPut]
      public async Task<IActionResult> Update(int key, string values)
      {
         var newObject = await _uow.RequestRepository.GetRequestById(key);
         JsonConvert.PopulateObject(values, newObject);

         //if (!TryValidateModel(order))
         //   return BadRequest(ModelState.GetFullErrorMessage());

         await _uow.RequestRepository.UpdateRequest(newObject);

         return Ok(newObject);
      }

   }
}
