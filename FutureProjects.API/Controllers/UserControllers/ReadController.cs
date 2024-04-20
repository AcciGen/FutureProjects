using FutureProjects.Application.Abstractions.IServices;
using FutureProjects.Domain.Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FutureProjects.API.Controllers.UserControllers
{
    [Route("api/User")]
    [ApiController]
    [Authorize]
    public class ReadController : ControllerBase
    {
        private readonly IUserService _userService;

        public ReadController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAll()
        {
            var result = await _userService.GetAll();

            return Ok(result);
        }

        [HttpGet("GetByName")]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetByName(string name)
        {
            var result = await _userService.GetByName(name);

            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<UserViewModel>> GetById(int id)
        {
            var result = await _userService.GetById(id);

            return Ok(result);
        }

        [HttpGet("GetByRole")]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetByRole(string role)
        {
            var result = await _userService.GetByRole(role);

            return Ok(result);
        }

        [HttpGet("GetByLogin")]
        public async Task<ActionResult<UserViewModel>> GetByLogin(string login)
        {
            var result = await _userService.GetByLogin(login);

            return Ok(result);
        }

        [HttpGet("GetByEmail")]
        public async Task<ActionResult<UserViewModel>> GetByEmail(string email)
        {
            var result = await _userService.GetByEmail(email);

            return Ok(result);
        }
    }
}
