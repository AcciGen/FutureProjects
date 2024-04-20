using FutureProjects.Application.Abstractions.IServices;
using FutureProjects.Domain.Entities.DTOs;
using FutureProjects.Domain.Entities.Models;
using FutureProjects.Domain.Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FutureProjects.API.Controllers.UserControllers
{
    [Route("api/User")]
    [ApiController]
    [Authorize]
    public class CreateController : ControllerBase
    {
        private readonly IUserService _userService;

        public CreateController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<User> Create(UserDTO model)
        {
            var result = await _userService.Create(model);

            return result;
        }
    }
}
