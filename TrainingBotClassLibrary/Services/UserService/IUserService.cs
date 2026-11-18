namespace TrainingBotClassLibrary
{
    public interface IUserService
    {
        public Task<User?> GetByIdAsync(long tgId);
        public Task<User> CreateAsync(User user);
        public Task<User> UpdateAsync(User user);

    }
}