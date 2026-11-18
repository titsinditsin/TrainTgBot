using Microsoft.EntityFrameworkCore;

namespace TrainingBotClassLibrary
{
    public class TrainingService : ITrainingService
    {
        private readonly TrainingDbContext _context;

        public TrainingService(TrainingDbContext context)
        {
            _context = context;
        }
        public async Task<Training?> GetByIdAsync(long TrId)
        {
            return await _context.Trainings.FindAsync(TrId);
        }
        public async Task<Training> TrStartAsync(long TgId)
        {
            Training Tr = new Training();
            Tr.TgId = TgId;
            Tr.StartTime = DateTime.UtcNow;
            _context.Trainings.Add(Tr);
            await _context.SaveChangesAsync();
            return Tr;
        }
        public async Task<Training> TrEndAsync(long TgId)
        {
            Training Tr = await IsTrainingAsync(TgId);
            if (Tr == null)
            {
                return null;
            }
            Tr.TgId = TgId;
            Tr.EndTime = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return Tr;
        }
        public async Task<Training?> IsTrainingAsync(long TgId)
        {
            return await _context.Trainings.FirstOrDefaultAsync(x => x.TgId == TgId && x.EndTime == null);
        }
           
    }
}