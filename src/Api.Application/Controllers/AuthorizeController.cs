using Api.Domain.Dtos;
using Api.Domain.Entities;
using Domain.Dtos.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Services.TokenServices;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly UserTokenService _userTokenService;

        public AuthorizeController(UserManager<User> userManager,
                                   SignInManager<User> signInManager,
                                   IConfiguration configuration,
                                   UserTokenService userTokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _userTokenService = userTokenService;
        }

        [HttpGet]
        [Route("authorize")]
        public ActionResult<string> Get() => $"AutorizaController :: Acessado em : {DateTime.Now.ToLongDateString()}";

        [HttpPost]
        [Route("register-person")]
        public async Task<IActionResult> RegisterPerson([FromBody] UserCreateDto create)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var user = new User
            {
                UserName = create.Email,
                Name = create.Name,
                Email = create.Email,
                EmailConfirmed = false,
                Birthday = create.BirthDay,
                Rg = create.Rg,
                Cpf = (int)create.Cpf,
                PhoneNumber = create.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, create.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);
            
            await _userManager.AddToRoleAsync(user, "Person");

            await _signInManager.SignInAsync(user, false);

            return Ok();
        }

        [HttpPost]
        [Route("register-agent")]
        public async Task<IActionResult> RegisterAgent([FromBody] UserCreateDto login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var user = new User
            {
                UserName = login.Email,
                Email = login.Email,
                EmailConfirmed = false
            };

            var result = await _userManager.CreateAsync(user, login.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(user, "Agent");

            await _signInManager.SignInAsync(user, false);

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var result = await _signInManager.PasswordSignInAsync(login.Email,
                login.Password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Login Inválido...");
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user == null) return BadRequest("Usuário não encontrado");

            var roles = await _userManager.GetRolesAsync(user);

            return Ok(_userTokenService.GenerateToken(login, roles.ToList()));
        }
    }
}
