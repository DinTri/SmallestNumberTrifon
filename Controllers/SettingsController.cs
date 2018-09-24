using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmallestNumberTrifon.Contracts;
using SmallestNumberTrifon.Model.Settings;

namespace SmallestNumberTrifon.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ISettings _settings;

        public SettingsController(ISettings settings)
        {
            _settings = settings;
        }

        [Route("FetchLimit")]
        [HttpGet]
        public ActionResult<int> FetchLimit()
        {
           // var response = new SettingsResponse();
            var result = _settings.GetLimit();
           // response.MessageBody = new SettingsResponseBody {Limit = result};
            if (result == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return new ObjectResult(result);
        }


        [Route("LimitSet")]
        [HttpPost]
        public ActionResult SetLimit([FromBody] SettingsRequest request)
        {
            var k = 0;
            var response = new SettingsResponse();
            if (request.MessageBody.UpperLimit.Limit == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            if (request.MessageBody.UpperLimit.Id == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            
            if (request.MessageBody == null)
            {
                response.StatusCodes = new List<int>() { 400 };
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var id = request.MessageBody.UpperLimit.Id;
            id += ++k;
           var addLimit = _settings.AddLimit(id, request.MessageBody.UpperLimit.Limit);
            if (!addLimit)
            {
                response.StatusCodes = new List<int>() { 404 };
                return StatusCode(StatusCodes.Status404NotFound);
            }

            response.StatusCodes = new List<int>() { 200 };
            response.MessageBody = new SettingsResponseBody {Id = request.MessageBody.UpperLimit.Id, Limit = request.MessageBody.UpperLimit.Limit};
            return new ObjectResult(response.MessageBody);
        }
    }
}