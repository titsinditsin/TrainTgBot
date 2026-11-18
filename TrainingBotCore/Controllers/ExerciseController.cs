using Microsoft.AspNetCore.Mvc;
using TrainingBotClassLibrary;

namespace TrainingBotCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try 
            { 
                return Ok(await _exerciseService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
}
        [HttpGet("MuscleGroup")]
        public async Task<IActionResult> GetByMuscleGroup([FromQuery] string muscleGroup)
        {
            var created = await _exerciseService.GetByTypeAsync(muscleGroup);
            return Ok(created);
        }
    }
}