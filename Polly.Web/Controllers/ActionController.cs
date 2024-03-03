using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Polly.Application.Repositories;
using Polly.Domain.DtoModels.EntityModels.ActionModels;
using Polly.Web.Filter;
using Action = Polly.Domain.Entities.Action;

namespace Polly.Web.Controllers
{
   [Auth]
   public class ActionController : Controller
   {
      private readonly IUnitOfWork _uow;
      public ActionController(IUnitOfWork uow)
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
         return DataSourceLoader.Load(_uow.ActionRepository.GetActionList(), loadOptions);
      }

      [HttpPost]
      public IActionResult Add(string values)
      {
         var newObject = new ActionDto();
         JsonConvert.PopulateObject(values, newObject);
         
         //if (!TryValidateModel(newOrder))
         //   return BadRequest(ModelState.GetFullErrorMessage());

         _uow.ActionRepository.AddAction(newObject);

         return Ok(newObject);
      }

      [HttpPut]
      public async Task<IActionResult> Update(int key, string values)
      {
         var newObject = await _uow.ActionRepository.GetActionById(key);
         JsonConvert.PopulateObject(values, newObject);

         //if (!TryValidateModel(order))
         //   return BadRequest(ModelState.GetFullErrorMessage());

         await _uow.ActionRepository.UpdateAction(newObject);

         return Ok(newObject);
      }

   }
}
