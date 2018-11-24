using System;
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

        public CalcServiceController(ICalculator calculator)
        {
            _calculator = calculator;
        }

        // POST: api/CalcService
        [HttpPost("Calculate")]
        public IActionResult Calculate(CalcServiceRequest request)
        {
            if (request == null) return BadRequest();

            try
            {
                Result result = _calculator.Calculate(
                    request.Ingredients,
                    request.Flavor,
                    request.AlcoholQuantity,
                    request.JuiceCorretion,
                    request.Supplements
                );

                CalcServiceResponse response = GetCalcServiceResponse(result);

                return response.IsSuccess ? Ok(response) : (IActionResult)NotFound(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
