using ApplicationService.Services.AuthServices;
using Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Real_Time_Stock_Exchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthServices authServices;

        public AccountController(IAuthServices authServices)
        {
            this.authServices = authServices;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<AuthModel>> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await authServices.RegisterAsync(model);
            if (!result.IsAuthenticated)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }


        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await authServices.LoginAsync(model);
            if (!response.IsAuthenticated)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
