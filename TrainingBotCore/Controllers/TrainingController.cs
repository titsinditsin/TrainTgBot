using Microsoft.AspNetCore.Mvc;
using TrainingBotClassLibrary;

namespace TrainingBotCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpGet("{TrId}")]
        public async Task<IActionResult>  GetById([FromRoute] long TrId)
        {
            try
            {
                var training = await _trainingService.GetByIdAsync(TrId);
                return Ok(training);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("IsActive")]
        public async Task<IActionResult> IsActive([FromQuery] long tgId)
        {
            try { 
            var training = await _trainingService.IsTrainingAsync(tgId);
            return Ok(training);
        }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
    }
}

        [HttpPost("Start")]
        public async Task<IActionResult> CreateAsync([FromQuery] long tgId)
        {
            try { 
            var created = await _trainingService.TrStartAsync(tgId);
            return Ok(created);
        }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
    }
}

        [HttpPut("End")]
        public async Task<IActionResult> UpdateAsync([FromQuery] long tgId)
        {
            try { 
            var updated = await _trainingService.TrEndAsync(tgId);
            return Ok(updated);
        }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
    }
}

    }
}