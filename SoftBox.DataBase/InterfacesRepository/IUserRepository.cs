using SoftBox.DataBase.Entities;

namespace SoftBox.DataBase.InterfacesRepository;

public interface IUserRepository
{
    public Task<long> GetTypeUserByIdAsync(Guid userId);

    public Task<User> GetUserByIdAsync(Guid userId);

}
