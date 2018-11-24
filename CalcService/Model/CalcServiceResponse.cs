using CalcService.Core.Model;

namespace CalcService.Model
{
    public class CalcServiceResponse
    {
        public Result Result { get; set; }
        public bool IsSuccess { get; set; }
    }
}
