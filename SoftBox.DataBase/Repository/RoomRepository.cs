using Microsoft.EntityFrameworkCore;
using SoftBox.DataBase.Entities;

namespace SoftBox.DataBase.Repository;

public class RoomRepository : Base.DbNamedRepository<Entities.Room, Guid>, InterfacesRepository.IRoomRepository
{
    public RoomRepository(SoftBoxDbContext db) : base(db)
    {
    }

    public async Task<Entities.RoomUser> GetRoomUserByRoomUserId(Guid id, CancellationToken cancel = default)
    {
        return await db.Set<Entities.RoomUser>().FirstOrDefaultAsync(i => i.Id == id, cancel).ConfigureAwait(false);
    }
    public async Task<List<Entities.User>> GetAllUser(CancellationToken cancel = default)
    {

        return await db.Set<User>().ToListAsync<User>(cancel).ConfigureAwait(false);
    }

    public async Task<Entities.RoomMessage> AddRoomMessage(RoomMessage item, CancellationToken cancel = default)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));

        await db.AddAsync(item, cancel).ConfigureAwait(false);

        SaveChanges(cancel).ConfigureAwait(false);

        return item;
    }

    public async Task<Room> GetRoomUser(Guid roomId, CancellationToken cancel = default)
    {

        return await Set
            .Include(x => x.RoomUsers)
            .ThenInclude(x => x.RoomMessages)
            .Include(x => x.RoomUsers)
            .ThenInclude(x => x.User)
                            .FirstOrDefaultAsync(c => c.Id == roomId, cancel)
            .ConfigureAwait(false);
    }
}
