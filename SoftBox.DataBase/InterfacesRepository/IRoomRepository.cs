using SoftBox.DataBase.Entities;

namespace SoftBox.DataBase.InterfacesRepository;

public interface IRoomRepository : Base.IRepository<Room, Guid>
{
    public Task<Room> GetRoomUser(Guid roomId, CancellationToken cancel = default);

    public Task<IEnumerable<Room>> GetRoomByUserId(string userId);

    public Task<RoomMessage> AddRoomMessage(RoomMessage item, CancellationToken cancel = default);

    public Task<RoomUser> GetRoomUserByRoomUserId(Guid roomUserid, CancellationToken cancel = default);
}
