using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ASPNetCoreMastersTodoList.Api.ApiModels;
using Microsoft.AspNetCore.Identity;
using ASPNetCoreMastersTodoList.Api.BindingModels;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace ASPNetCoreMastersTodoList.Api.Controllers
{
    [Route("Users")]
    [ApiController]
    
    
    public class UsersController : ControllerBase
    {
        private readonly AuthenticationSetting _settings;

        private readonly UserManager<IdentityUser> userManager;
        private readonly JwtOptions jwtOptions;
        

        public UsersController(UserManager<IdentityUser> userManager,
            IOptions<JwtOptions> options)
        {
            this.userManager = userManager;
            this.jwtOptions = options.Value;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterBindingModel model)
        {
            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Email
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                return Ok(new { code = code, email = model.Email });
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }
        }

        [HttpPost("confirm")]
        public async Task<IActionResult> Confirm(RegisterBindingModel confirm)
        {
            var user = await userManager.FindByEmailAsync(confirm.Email);
            var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(confirm.Code));

            if (user == null || user.EmailConfirmed)
            {
                return BadRequest();
            }
            else if ((await userManager.ConfirmEmailAsync(user, code)).Succeeded)
            {
                return Ok("Your email is confirmed");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(RegisterBindingModel login)
        {
            IActionResult actionResult;

            var user = await userManager.FindByEmailAsync(login.Email);

            if (user == null)
            {
                actionResult = NotFound(new { errors = new[] { $"User with email '{login.Email}' is not found" } });
            }
            else if (await userManager.CheckPasswordAsync(user, login.Password))
            {
                if (!user.EmailConfirmed)
                {
                    actionResult = BadRequest(new { errors = new[] { "Email is not confirmed. Please, go to your email account" } });
                }
                else
                {
                    var token = GenerateTokenAsync(user);
                    actionResult = Ok(new { jwt = token });
                }
            }
            else
            {
                actionResult = BadRequest(new { errors = new[] { "User password is not valid" } });
            }

            return actionResult;
        }

        private string GenerateTokenAsync(IdentityUser user)
        {
            IList<Claim> userClaims = new List<Claim>
            {
                new Claim("UserName", user.UserName),
                new Claim("Email", user.Email)
            };

            return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
              claims: userClaims,
              expires: DateTime.UtcNow.AddMonths(1),
              signingCredentials: new SigningCredentials(jwtOptions.SecurityKey, SecurityAlgorithms.HmacSha256)
            ));
        }


        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return Ok();
        //}
    }
}
