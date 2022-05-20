using Microsoft.EntityFrameworkCore;
using SoftBox.DataBase.Entities;
using SoftBox.DataBase.InterfacesRepository;

namespace SoftBox.DataBase.Repository;

public class UserRepository : Base.DbRepository<User, Guid>, IUserRepository
{
    public UserRepository(SoftBoxDbContext db) : base(db)
    {
    }

    public async Task<bool> IsLoginExist(string login)
    {
        return await Set.Where(x => x.Login == login).AnyAsync();
    }

    public async Task<int> GetTypeUserByIdAsync(Guid userId)
    {

        return await Set.Where(c => c.Id == userId)
                              .Select(c => c.UserTypeId)
                              .FirstOrDefaultAsync();
    }

    public async Task<User> GetUserByIdAsync(Guid userId)
    {

        return await GetById(userId);
    }
}
