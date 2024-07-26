using Microsoft.AspNetCore.Mvc;

namespace OpenTelemetryAspireApi.Controllers
{
    [ApiController]
    [Route("primes")]
    public class PrimeController : ControllerBase
    {
        [HttpGet("{number:int}")]
        public IActionResult IsPrime(int number)
        {
            if (number < 1)
                return BadRequest("O número deve ser maior ou igual a 1.");

            bool isPrime = IsPrimeNumber(number);

            return Ok(new { Number = number, IsPrime = isPrime });
        }

        private bool IsPrimeNumber(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
}
