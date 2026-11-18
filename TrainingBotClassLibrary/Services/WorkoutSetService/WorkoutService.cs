using Microsoft.EntityFrameworkCore;

namespace TrainingBotClassLibrary
{
    public class WorkoutService : IWorkoutService
    {
        private readonly TrainingDbContext _context;

        public WorkoutService(TrainingDbContext context)
        {
            _context = context;
        }
        public async Task<List<WorkoutSet>> GetAllByIdAsync(long TrId)
        {
            return await _context.WorkoutSets.Where(x=> x.TrId == TrId).ToListAsync();
        }
        public async Task<WorkoutSet> CreateAsync(WorkoutCreateDTO dto)
        {
            WorkoutSet workout = new WorkoutSet()
            {
                TrId = dto.TrId,
                ExId = dto.ExId,
                Weight = dto.Weight,
                Times = dto.Times
            };
            _context.WorkoutSets.Add(workout);
            await _context.SaveChangesAsync();
            return workout;
        }
    }
}