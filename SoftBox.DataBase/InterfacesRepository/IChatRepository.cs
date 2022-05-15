using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftBox.DataBase.InterfacesRepository
{
    public interface IChatRepository : Base.IRepository<Entities.Chat, Guid>
    {
    }
}
