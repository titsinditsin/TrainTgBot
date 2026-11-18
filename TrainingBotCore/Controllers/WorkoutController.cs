using Microsoft.AspNetCore.Mvc;
using TrainingBotClassLibrary;

namespace TrainingBotCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }
        
        [HttpGet("{TrId}")]
        public async Task<IActionResult>  GetById([FromRoute] long TrId)
        {
            try
            {
                var workout = await _workoutService.GetAllByIdAsync(TrId);
                return Ok(workout);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] WorkoutCreateDTO dto)
        {
            try { 
            var created = await _workoutService.CreateAsync(dto);
            return Ok(created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}