using Microsoft.EntityFrameworkCore;
using SoftBox.DataBase.Entities;
using SoftBox.DataBase.InterfacesRepository;

namespace SoftBox.DataBase.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly DbContextFactory _dbContextFactory;
        public UserRepository(DbContextFactory dbContextFactory)
        {
            this._dbContextFactory = dbContextFactory;
        }

        public async Task<long> GetTypeUserByIdAsync(Guid userId)
        {
            var dbContext = _dbContextFactory.Create(typeof(UserRepository));

            return await dbContext.Users.Where(c => c.Id == userId)
                                  .Select(c => c.TypeUserId)
                                  .FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            var dbContext = _dbContextFactory.Create(typeof(UserRepository));

            return await dbContext.Users.FirstOrDefaultAsync(c => c.Id == userId);
        }
    }
}
