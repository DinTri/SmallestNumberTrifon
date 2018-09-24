using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmallestNumberTrifon.Contracts;
using SmallestNumberTrifon.Model.Calculate;

namespace SmallestNumberTrifon.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SmallestNumberController : ControllerBase
    {
        private readonly ICalculate _calculate;

        public SmallestNumberController(ICalculate calculate)
        {
            _calculate = calculate;
        }

        [Route("SmallestNumberR")]
        [HttpPost]
        public ActionResult<IEnumerable<Calculate>> SmallestNumberRecursive([FromBody] CalculateRequest request)
        {
            var response = new CalculateResponse();
            if (request.MessageBody.Limit == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            if (request.MessageBody == null)
            {
                response.StatusCodes = new List<int>() { 400 };
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var smallest = _calculate.RecursiveCalculateSmallestNumber(request.MessageBody.Limit);
            if (smallest == null)
            {
                response.StatusCodes = new List<int>() { 404 };
                return StatusCode(StatusCodes.Status404NotFound);
            }

            response.StatusCodes = new List<int>() { 200 };
            response.MessageBody = new CalculateResponseBody {SmallestNumber = new List<Calculate>(smallest)};
            return new ObjectResult(response);
        }

        [Route("SmallestNumberN")]
        [HttpPost]
        public ActionResult<IEnumerable<Calculate>> SmallestNumberNonRecursive([FromBody] CalculateRequest request)
        {
            var response = new CalculateResponse();
            if (request.MessageBody.Limit == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            if (request.MessageBody == null)
            {
                response.StatusCodes = new List<int>() { 400 };
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var smallestNr = _calculate.NonRecursiveCalculateSmallestNumber(request.MessageBody.Limit);
            if (smallestNr == null)
            {
                response.StatusCodes = new List<int>() { 404 };
                return StatusCode(StatusCodes.Status404NotFound);
            }

            response.StatusCodes = new List<int>() { 200 };
            response.MessageBody = new CalculateResponseBody {SmallestNumber = new List<Calculate>(smallestNr)};
            return new ObjectResult(response);
        }
    }
}