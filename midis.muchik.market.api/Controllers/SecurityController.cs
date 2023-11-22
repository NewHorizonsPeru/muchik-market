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
        private readonly ILogger<SecurityController> _logger;
        private readonly ISecurityService _securityService;

        public SecurityController(ILogger<SecurityController> logger, ISecurityService securityService)
        {
            _logger = logger;
            _securityService = securityService;
        }

        [HttpPost("signIn")]
        public IActionResult SignIn([FromBody] SignInRequestDto signInRequestDto)
        {
            _logger.LogInformation("SignIn Method");
            return Ok(_securityService.SignIn(signInRequestDto));
        }

        [HttpPost("signUp")]
        public IActionResult SignUp([FromBody] SignUpRequestDto signUpRequestDto)
        {
            return Ok(_securityService.SignUp(signUpRequestDto));
        }

        [HttpPost("forgetPassword")]
        public IActionResult ForgetPassword([FromBody] ForgetPasswordDto forgetPasswordDto)
        {
            return Ok(_securityService.ForgetPassword(forgetPasswordDto));
        }

        [HttpPut("updatePassword")]
        public IActionResult UpdatePassword([FromBody] UpdatePasswordDto updatePasswordDto, [FromQuery] string forgetPasswordToken)
        {
            return Ok(_securityService.UpdatePassword(updatePasswordDto, forgetPasswordToken));
        }
    }
}
