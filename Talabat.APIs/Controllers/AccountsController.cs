using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Talabat.Applcation.Dtos.Account;
using Talabat.Applcation.Specification.Users;
using Talabat.Domain.Entities.Accounts;
using Talabat.Domain.Interfaces;

namespace Talabat.APIs.Controllers
{
    public class AccountsController : BaseApiController
    {
        private readonly SignInManager<ApplcationUser> _signInManager;
        private readonly UserManager<ApplcationUser> _userManager;
        private readonly ITokenServies _token;
        private readonly IGenericRepository<Address> _addressrepo;
        private readonly IMapper _mapper;

        public AccountsController(SignInManager<ApplcationUser> signInManager,
            UserManager<ApplcationUser> userManager,
            ITokenServies token,
            IGenericRepository<Address> addressrepo,
            IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _token = token;
            _addressrepo = addressrepo;
            _mapper = mapper;
        }


        [HttpPost("login")]
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
                    DisplayName = userLogin.userEmail.Split("@")[0],
                    Email = userLogin.userEmail,
                    Token = await _token.GenerateTokenAsync(user, _userManager)
                });
        }

        [HttpPost("register")]

        public async Task<ActionResult<RegisterDetailsDto>> Register(UserRegisterDto userRegisterDto)
        {

            var result = await _userManager.FindByEmailAsync(userRegisterDto.Email);
            if (result is not null)
                return BadRequest();

            var applcationUser = new ApplcationUser()
            {
                UserName = userRegisterDto.FristName + "" + userRegisterDto.LastName,
                DisplayName = userRegisterDto.Email.Split("@")[0],
                Email = userRegisterDto.Email,
                PhoneNumber = userRegisterDto.PhoneNumber
            };
            var userResult = await _userManager.CreateAsync(applcationUser, userRegisterDto.Password);
            if (!userResult.Succeeded)
                return BadRequest();
            return Ok(new RegisterDetailsDto
            {
                DisplayName = applcationUser.DisplayName,
                Email = applcationUser.Email,
                Token = await _token.GenerateTokenAsync(applcationUser, _userManager)
            });
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<LoginDetailsDto>> GetCurrentUser()
        {

            var email = User.FindFirstValue(ClaimTypes.Email) ?? string.Empty;

            var user = await _userManager.FindByEmailAsync(email);
            return Ok(new LoginDetailsDto()
            {
                DisplayName = user?.DisplayName ?? string.Empty,
                Email = user?.Email ?? string.Empty,
                Token = await _token.GenerateTokenAsync(user!, _userManager)
            });

        }
        [Authorize]
        [HttpGet("address")]
        public async Task<ActionResult<UserAddressDto>> GetUserAddress()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email ?? string.Empty);
            if (user is null)
                return BadRequest();
            var address = await _addressrepo.GetWithSpec(new GetUserAddressSpecification(user));
            if (address is null)
                return Ok("No address for this User");
            return Ok(address);
        }

        [Authorize]
        [HttpPut("address")]
        public async Task<ActionResult<UserAddressDto>> UpdateUserAddresss(UserAddressDto address)
        {

            var updatedAddress = _mapper.Map<Address>(address);
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.Users.Where(u => u.Email == email).Include(u => u.Address).FirstOrDefaultAsync();
            updatedAddress.Id = user.Address.Id;
            user.Address = updatedAddress;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return NotFound();
            return Ok(_mapper.Map<UserAddressDto>(updatedAddress));
        }
    }
}
