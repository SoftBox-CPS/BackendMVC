using SoftBox.DataBase.Entities;

namespace SoftBox.DataBase.InterfacesRepository;

public interface IUserRepository : Base.IRepository<User, Guid>
{

    public Task<bool> IsLoginExist(string login);

    public Task<User> GetUserByLogin(string login);

    public Task<int> GetTypeUserByIdAsync(Guid userId);

    public Task<User> GetUserByIdAsync(Guid userId);

}
