using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ASPNetCoreMastersTodoList.Api.ApiModels;

namespace ASPNetCoreMastersTodoList.Api.Controllers
{
    [Route("Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AuthenticationSetting _settings;

        public UsersController(IOptions<AuthenticationSetting> options)
        {
            _settings = options.Value;
            var securityKey = _settings.JwtProp.SecurityKey;
            var issuer =  _settings.JwtProp.Issuer;
            var audience = _settings.JwtProp.Audience;
            
        }
        [HttpGet]
        public IActionResult Login()
        {
            return Ok();
        }
    }
}
