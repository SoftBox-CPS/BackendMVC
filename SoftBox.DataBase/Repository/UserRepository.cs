using SoftBox.DataBase.Entities;
using SoftBox.DataBase.IntarfaceRepository;

namespace SoftBox.DataBase.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;
        private readonly List<UsersType> _userTypes;

        public UserRepository()
        {
            this._users = new List<User>();
            this._userTypes = new List<UsersType>();
        }

        public long GetTypeUserById(Guid userId)
        {
            return _users.Where(c => c.Id == userId).Select(c => c.TypeUserId).FirstOrDefault();
        }

        public User GetUserById(Guid userId)
        {
            return _users.FirstOrDefault(c => c.Id == userId);
        }
    }
}
