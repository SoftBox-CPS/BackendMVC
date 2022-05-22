

namespace SoftBox.DataBase.InterfacesRepository.Base;

public interface IRepository<T, B> where T : InterfacesEntities.IEntity<B>
{
    Task<bool> Exist(T item, CancellationToken cancel = default);
    Task<bool> ExistById(B id, CancellationToken cancel = default);

    Task<int> GetCount(CancellationToken cancel = default);

    Task<IEnumerable<T>> GetAll(CancellationToken cancel = default);

    Task<IEnumerable<T>> Get(int skip, int count, CancellationToken cancel = default);

    Task<T> GetById(B id, CancellationToken cancel = default);

    Task<T> Add(T item, CancellationToken cancel = default);

    Task<T> Update(T item, CancellationToken cancel = default);

    Task<T> Delete(T item, CancellationToken cancel = default);

    Task<T> DeleteById(B id, CancellationToken cancel = default);

    Task<int> SaveChanges(CancellationToken cancel = default);
}
