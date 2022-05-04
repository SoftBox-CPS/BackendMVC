using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftBox.DataBase.InterfacesEntities
{
    public interface IEntities<T>
    {
        T Id { get; set; }

    }
}
