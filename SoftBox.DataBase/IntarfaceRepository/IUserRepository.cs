using SoftBox.DataBase.Entities;

namespace SoftBox.DataBase.IntarfaceRepository;

public interface IUserRepository
{
    public Task<long> GetTypeUserByIdAsync(Guid userId);

    public Task<User> GetUserByIdAsync(Guid userId);

}
