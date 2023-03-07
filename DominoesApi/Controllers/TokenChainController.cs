using DominoesApi.Business;
using DominoesApi.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DominoesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TokenChainController : ControllerBase
    {
        private readonly ITokenChainLogic tokenChainLogic;
        public TokenChainController(ITokenChainLogic tokenChainLogic)
        {
            this.tokenChainLogic = tokenChainLogic;
        }

        [HttpPost("calculateAll")]
        public IActionResult CalculateAll([FromBody] IEnumerable<DominoesApi.Dtos.Token> tokens)
        {
            if (tokens.Count() < 2 || tokens.Count() > 6)
                return BadRequest("the size must be between two and six tokens");
            IEnumerable<string> strings = tokenChainLogic.CalculateAll(tokens);
            if (strings.Any())
                return Ok(strings);
            else
                return NotFound("result not found");

        }

        [HttpPost("firstCalculated")]
        public IActionResult FirstCalculated([FromBody] IEnumerable<DominoesApi.Dtos.Token> tokens)
        {
            if (tokens.Count() < 2 || tokens.Count() > 6)
                return BadRequest("the size must be between two and six tokens");
            string result = tokenChainLogic.FirstCalculated(tokens);
            if (string.IsNullOrEmpty(result))
                return NotFound("result not found");
            else
                return Ok(result);
        }
    }
}
