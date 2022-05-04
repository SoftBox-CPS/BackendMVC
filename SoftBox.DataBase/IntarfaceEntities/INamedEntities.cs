using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftBox.DataBase.IntarfaceEntities
{
    public interface INamedEntities<T> : IEntities<T>
    {
        string Name { get; set; }
    }
}
