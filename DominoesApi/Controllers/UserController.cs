using DominoesApi.Business;
using DominoesApi.Dtos;
using DominoesApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DominoesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {   
        private readonly IUserLogic userLogic;

        public UserController(IUserLogic userLogic)
        {
            this.userLogic = userLogic;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserResponseDto>> Login([FromBody] User request)
        {
            return await userLogic.Login(request);
        }
    }
}
