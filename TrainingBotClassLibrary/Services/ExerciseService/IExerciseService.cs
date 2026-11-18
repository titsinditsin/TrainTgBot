namespace TrainingBotClassLibrary
{
    public interface IExerciseService
    {
        public Task<List<Exercise>> GetAllAsync();
        public Task<List<Exercise>> GetByTypeAsync(string MuscleGroup);
    }
}