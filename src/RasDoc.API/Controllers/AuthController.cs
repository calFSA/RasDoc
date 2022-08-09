using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rasdoc.API.Extensions;
using Rasdoc.DTO.Models;
using RasDoc.API.Extensions;
using RasDoc.Domain.Interfaces;

namespace RasDoc.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AuthController : MainController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtAuth _jwtAuth;

        public AuthController(INotifier notificador,
                              SignInManager<IdentityUser> signInManager,
                              UserManager<IdentityUser> userManager,
                              JwtAuth jwtAuth
                              ) : base(notificador)
        {
            _jwtAuth = jwtAuth;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [ClaimsAuthorize("Auth", "post")]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserDTO registerUser)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            var user = new IdentityUser
            {
                UserName = registerUser.Name,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return CustomResponse(await _jwtAuth.CreateJwt(user.Email!));
            }
            foreach (var error in result.Errors)
            {
                NotifyError(error.Description);
            }

            return CustomResponse(registerUser);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDTO loginUser)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                return CustomResponse(await _jwtAuth.CreateJwt(loginUser.Email!));
            }

            if (result.IsLockedOut)
            {
                NotifyError("Usuário temporariamente bloqueado por tentatidas inválidas");
                return CustomResponse(loginUser);
            }

            NotifyError("Usuário ou Senha incorretos");
            return CustomResponse(loginUser);
        }

        
    }
}
