

namespace SoftBox.DataBase.InterfacesRepository.Base
{
    public interface INamedRepository<T, B> : IRepository<T, B> where T : InterfacesEntities.INamedEntities<B>
    {

        Task<T> GetByName(string name, CancellationToken cancel = default);

    }
}
