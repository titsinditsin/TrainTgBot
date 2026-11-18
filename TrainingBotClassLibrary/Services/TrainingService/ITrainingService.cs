namespace TrainingBotClassLibrary
{
    public interface ITrainingService
    {
        public Task<Training?> GetByIdAsync(long TrId);
        public Task<Training> TrStartAsync(long TgId);
        public Task<Training> TrEndAsync(long TgId);

        public Task<Training?> IsTrainingAsync(long TgId);

    }
}