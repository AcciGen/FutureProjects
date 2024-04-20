using FutureProjects.Application.Abstractions.IServices;
using FutureProjects.Application.Services.UserServices;
using FutureProjects.Domain.Entities.DTOs;
using FutureProjects.Domain.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FutureProjects.API.Controllers.Identity
{
    [Route("api/User/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseLogin>> Login(RequestLogin model)
        {
            var result = await _authService.GenerateToken(model);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseLogin>> Register(RegisterLogin model)
        {
            if (model.Password != model.ConiformPassword)
            {
                return BadRequest("Passwords are not same!");
            }

            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new UserDTO
            {
                Name = model.Name,
                Email = model.Email,
                Login = model.Login,
                Password = model.Password,
                Role = model.Role
            };
            var requestLogin = new RequestLogin
            {
                Login = model.Login,
                Password = model.Password
            };


            var result = await _userService.Create(user);

            var accessToken = await _authService.GenerateToken(requestLogin);

            return Ok(accessToken);
        }
    }
}
