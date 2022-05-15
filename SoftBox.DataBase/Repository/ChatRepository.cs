using Microsoft.EntityFrameworkCore;
using SoftBox.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftBox.DataBase.Repository
{
    public class ChatRepository : Base.DbNamedRepository<Entities.Chat, Guid>, InterfacesRepository.IChatRepository
    {
        public ChatRepository(SoftBoxDbContext db) : base(db)
        {
        }

        public async Task<Entities.ChatUser> GetChatUserByChatUserId(Guid id, CancellationToken cancel = default)
        {
            return await db.Set<Entities.ChatUser>().FirstOrDefaultAsync(i => i.Id == id, cancel).ConfigureAwait(false);
        }
        public async Task<List<Entities.User>> GetAllUser(CancellationToken cancel = default)
        {

            return await db.Set<User>().ToListAsync<User>(cancel).ConfigureAwait(false);
        }

        public async Task<Entities.ChatMessage> AddChatMessage(ChatMessage item, CancellationToken cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            await db.AddAsync(item, cancel).ConfigureAwait(false);

            SaveChanges(cancel).ConfigureAwait(false);

            return item;
        }

        public async Task<Chat> GetChatUser(Guid chatId, CancellationToken cancel = default)
        {

            return await Set
                .Include(x => x.ChatUsers)
                .ThenInclude(x => x.ChatMessages)
                .Include(x => x.ChatUsers)
                .ThenInclude(x => x.User)
                                .FirstOrDefaultAsync(c => c.Id == chatId, cancel)
                .ConfigureAwait(false);
        }
    }
}
