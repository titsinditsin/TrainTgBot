namespace TrainingBotClassLibrary
{
    public interface IWorkoutService
    {
        public Task<List<WorkoutSet>> GetAllByIdAsync(long TrId);
        public Task<WorkoutSet> CreateAsync(WorkoutCreateDTO dto);

    }
}