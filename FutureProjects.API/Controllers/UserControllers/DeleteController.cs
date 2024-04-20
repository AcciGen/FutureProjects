using FutureProjects.Application.Abstractions.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FutureProjects.API.Controllers.UserControllers
{
    [Route("api/User")]
    [ApiController]
    [Authorize]
    public class DeleteController : ControllerBase
    {
        private readonly IUserService _userService;

        public DeleteController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteById(int id)
        {
            var result = await _userService.DeleteById(id);

            return result;
        }
    }
}
