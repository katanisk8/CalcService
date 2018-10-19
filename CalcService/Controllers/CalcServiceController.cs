using System.Collections.Generic;
using CalcService.Core.Model;
using CalcService.Model;
using Microsoft.AspNetCore.Mvc;

namespace CalcService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcServiceController : ControllerBase
    {
        ICalculator _calculator { get; set; }

        public CalcServiceController()
        {
            //_calculator = calculator;
        }


        [HttpPost("Test")]
        public IActionResult Test(TestModel model)
        {
            var lol = new TestModel
            {
                Name = model.Name + " 2",
                Ilosc = model.Ilosc + " 2"
            };

            return Ok(lol);
        }



        // GET: api/CalcService
        [HttpGet]
        public IEnumerable<string> Calculate()
        {
            return new string[] { "value1", "value2" };
        }

        // POST: api/CalcService
        [HttpPost]
        public IActionResult Calculate(CalcServiceRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            Result result = _calculator.Calculate(
                request.Ingredients,
                request.Flavor,
                request.AlcoholQuantity,
                request.JuiceCorretion,
                request.Supplements
                );

            CalcServiceResponse response = GetCalcServiceResponse(result);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response);
            }
        }

        private CalcServiceResponse GetCalcServiceResponse(Result result)
        {
            CalcServiceResponse response = new CalcServiceResponse();

            if (CheckResult(result))
            {
                response.Result = result;
                response.IsSuccess = true;
            }
            else
            {
                response.Result = null;
                response.IsSuccess = false;
            }

            return response;
        }

        private bool CheckResult(Result result)
        {
            return result != null &&
                   result.Mixture != null &&
                   result.Recipe != null &&
                   result.Wine != null;
        }
    }
}
