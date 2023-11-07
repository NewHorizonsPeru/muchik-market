using Microsoft.AspNetCore.Mvc;
using midis.muchik.market.application.dto.security;
using midis.muchik.market.application.interfaces;

namespace midis.muchik.market.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;

        public SecurityController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpPost("signUp")]
        public IActionResult SignUp([FromBody] SignUpRequestDto signUpRequestDto)
        {
            _securityService.SignUp(signUpRequestDto);
            return Ok();
        }
    }
}
