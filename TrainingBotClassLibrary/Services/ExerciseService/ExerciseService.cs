using Microsoft.EntityFrameworkCore;

namespace TrainingBotClassLibrary
{
    public class ExerciseService : IExerciseService
    {
        private readonly TrainingDbContext _context;

        public ExerciseService(TrainingDbContext context)
        {
            _context = context;
        }
        public async Task<List<Exercise>> GetAllAsync()
        {
            return await _context.Exercises.ToListAsync();
        }
        public async Task<List<Exercise>> GetByTypeAsync(string MuscleGroup)
        {
            return await _context.Exercises.Where(e => e.MuscleGroup == MuscleGroup).ToListAsync();
        }
    }
}