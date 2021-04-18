using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestNet5Api.Controllers
{
    [ApiController]
    [Route("/calculadora")]
    public class Calculadora : ControllerBase
    {
       private readonly ILogger<Calculadora> _logger;

        public Calculadora(ILogger<Calculadora> logger)
        {
            _logger = logger;
        }
        
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber){

            if(IsNumeric(firstNumber) && IsNumeric(secondNumber)){
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber){

            if(IsNumeric(firstNumber) && IsNumeric(secondNumber)){
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber){

            if(IsNumeric(firstNumber) && IsNumeric(secondNumber)){
                var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(div.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("med/{firstNumber}/{secondNumber}")]
        public IActionResult Med(string firstNumber, string secondNumber){

            if(IsNumeric(firstNumber) && IsNumeric(secondNumber)){
                var med = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(med.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("sqrt/{firstNumber}")]
        public IActionResult Sqrt(string firstNumber){

            if(IsNumeric(firstNumber)){
                var sqrt = Math.Sqrt((double)ConvertToDecimal(firstNumber));

                return Ok(sqrt.ToString());
            }

            return BadRequest("Invalid input");
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal retorno;

            if(decimal.TryParse(number, out retorno))
                return retorno;

            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }
    }
}