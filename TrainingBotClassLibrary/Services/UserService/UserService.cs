using Microsoft.EntityFrameworkCore;

namespace TrainingBotClassLibrary
{
    public class UserService : IUserService
    {
        private readonly TrainingDbContext _context;

        public UserService(TrainingDbContext context)
        {
            _context = context;
        }
        public async Task<User?> GetByIdAsync(long tgId)
        {
            return await _context.Users.FindAsync(tgId);
        }
        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}