using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using midis.muchik.market.application.dto.security;
using midis.muchik.market.application.interfaces;

namespace midis.muchik.market.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;

        public SecurityController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpPost("signIn")]
        public IActionResult SignIn([FromBody] SignInRequestDto signInRequestDto)
        {
            return Ok(_securityService.SignIn(signInRequestDto));
        }

        [HttpPost("signUp")]
        public IActionResult SignUp([FromBody] SignUpRequestDto signUpRequestDto)
        {
            return Ok(_securityService.SignUp(signUpRequestDto));
        }
    }
}
