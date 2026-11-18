using Microsoft.AspNetCore.Mvc;
using TrainingBotClassLibrary;

namespace TrainingBotCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("{tgId}")]
        public async Task<IActionResult>  GetById([FromRoute] long tgId)
        {
            try { 
            var user = await _userService.GetByIdAsync(tgId);
            return Ok(user);
        }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
    }
}
        [HttpPost]
        public async Task<IActionResult> CreateAsync(User user)
        {
            try { 
            var created = await _userService.CreateAsync(user);
            return Ok(created);
        }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
    }
}
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(User user)
        {
            try { 
            var updated = await _userService.UpdateAsync(user);
            return Ok(updated);
        }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
    }
}
    }
}