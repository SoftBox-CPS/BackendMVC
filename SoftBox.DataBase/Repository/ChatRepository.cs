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
    }
}
