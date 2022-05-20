using Microsoft.EntityFrameworkCore;
using SoftBox.DataBase.Entities;

namespace SoftBox.DataBase.Repository;

public class RoomRepository : Base.DbNamedRepository<Room, Guid>, InterfacesRepository.IRoomRepository
{
    public RoomRepository(SoftBoxDbContext db) : base(db)
    {
    }

    public async Task<RoomUser> GetRoomUserByRoomUserId(Guid roomUserid, CancellationToken cancel = default)
    {
        return await db.Set<RoomUser>().FirstOrDefaultAsync(i => i.Id == roomUserid, cancel).ConfigureAwait(false);
    }

    public async Task<IEnumerable<Room>> GetRoomByUserId(string userId)
    { 
        return await db.Set<Entities.RoomUser>()
            .Include(x => x.Room)
            .Where(x => x.UserId.ToString() == userId)
            .Select(x => x.Room)
            .ToListAsync(); ;
    }

    public async Task<RoomMessage> AddRoomMessage(RoomMessage item, CancellationToken cancel = default)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));

        await db.AddAsync(item, cancel).ConfigureAwait(false);

        await SaveChanges(cancel).ConfigureAwait(false);

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
