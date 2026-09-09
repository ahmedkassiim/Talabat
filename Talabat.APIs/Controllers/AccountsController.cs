using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Talabat.Applcation.Dtos.Account;
using Talabat.Domain.Entities.Accounts;
using Talabat.Domain.Interfaces;

namespace Talabat.APIs.Controllers
{
    public class AccountsController : BaseApiController
    {
        private readonly SignInManager<ApplcationUser> _signInManager;
        private readonly UserManager<ApplcationUser> _userManager;
        private readonly ITokenServies _token;

        public AccountsController(SignInManager<ApplcationUser> signInManager,
            UserManager<ApplcationUser> userManager,
            ITokenServies token)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _token = token;
        }


        [HttpPost("/login")]
        public async Task<ActionResult<LoginDetailsDto>> Login(UserLoginDto userLogin)
        {

            var user = await _userManager.FindByEmailAsync(userLogin.userEmail);
            if (user is null)
                return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, userLogin.password, false);
            if (!result.Succeeded)
                return BadRequest();
            else
                return Ok(new LoginDetailsDto
                {
                    UserName = userLogin.userEmail,
                    Token = _token.GenerateToken(user)
                });
        }

        [HttpPost("/register")]

        public async Task<ActionResult<RegisterDetailsDto>> Register(UserRegisterDto userRegisterDto)
        {

            var result = await _userManager.FindByEmailAsync(userRegisterDto.Email);
            if(result is not null)
                return BadRequest();

            var applcationUser = new ApplcationUser()
            {
                DisplayName = userRegisterDto.FristName + " " + userRegisterDto.LastName,
                UserName = userRegisterDto.Email,
                Email = userRegisterDto.Email,
                PhoneNumber = userRegisterDto.PhoneNumber
            };
          var userResult =   await _userManager.CreateAsync(applcationUser, userRegisterDto.Password);
            if (!userResult.Succeeded)
                return BadRequest();
           return Ok( new RegisterDetailsDto
           {
               UserName = applcationUser.DisplayName,
               Token = _token.GenerateToken(applcationUser)
           });       
        }
    }
 }
