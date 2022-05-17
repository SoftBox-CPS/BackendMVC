using Microsoft.EntityFrameworkCore;

namespace SoftBox.DataBase.Repository.Base;

public abstract class DbNamedRepository<T, B> : DbRepository<T, B>, InterfacesRepository.Base.INamedRepository<T, B> where T : Entities.Base.EntityName<B>, new()
{
    public DbNamedRepository(SoftBoxDbContext db) : base(db) { }

    public async Task<T> GetByName(string name, CancellationToken cancel = default)
    {
        return await Items.FirstOrDefaultAsync(item => item.Name == name, cancel).ConfigureAwait(false);
    }
}
