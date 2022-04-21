using SoftBox.DataBase.Entities;

namespace SoftBox.DataBase.IntarfaceRepository;

public interface IUserRepository
{
    public long GetTypeUserById(Guid userId);

    public User GetUserById(Guid userId);

}
