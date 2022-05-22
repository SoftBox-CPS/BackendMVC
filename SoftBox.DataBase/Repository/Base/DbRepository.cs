using Microsoft.EntityFrameworkCore;

namespace SoftBox.DataBase.Repository.Base;

public abstract class DbRepository<T, B> : InterfacesRepository.Base.IRepository<T, B> where T : Entities.Base.Entity<B>, new()
{
    protected readonly SoftBoxDbContext db;

    protected DbSet<T> Set { get; }

    protected virtual IQueryable<T> Items => Set;

    public bool AutoSaveChanges { get; set; } = true;

    public DbRepository(SoftBoxDbContext db)
    {
        this.db = db;
        Set = db.Set<T>();
    }

    public async Task<IEnumerable<T>> Get(int skip, int count, CancellationToken cancel = default)
    {
        if (count < 0)
            return Enumerable.Empty<T>();

        IQueryable<T> query = Items switch
        {
            IOrderedQueryable<T> ordered_query => ordered_query,
            { } q => q.OrderBy(i => i.Id)
        };


        if (skip > 0)
            query = query.Skip(skip);

        return await query.Take(count).ToListAsync(cancel).ConfigureAwait(false);
            
    }

    public async Task<IEnumerable<T>> GetAll(CancellationToken cancel = default)
    {
        return await Items.ToListAsync<T>(cancel).ConfigureAwait(false);
    }

    public async Task<T> GetById(B id, CancellationToken cancel = default)
    { 
        return await Items.FirstOrDefaultAsync(i => Equals(i.Id, id), cancel).ConfigureAwait(false);
    }

    public async Task<int> GetCount(CancellationToken cancel = default)
    {
        return await Items.CountAsync(cancel).ConfigureAwait(false);
    }

    public async Task<T> Add(T item, CancellationToken cancel = default)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));

        await db.AddAsync(item, cancel).ConfigureAwait(false);

        if (AutoSaveChanges)
            await SaveChanges(cancel).ConfigureAwait(false);

        return item;
    }

    public async Task<T> Update(T item, CancellationToken cancel = default)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));

        db.Update(item);

        if (AutoSaveChanges)
            await SaveChanges(cancel).ConfigureAwait(false);

        return item;
    }

    public async Task<T> Delete(T item, CancellationToken cancel = default)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));

        db.Remove(item);

        if (AutoSaveChanges)
            await SaveChanges(cancel).ConfigureAwait(false);

        return item;
    }

    public async Task<T> DeleteById(B id, CancellationToken cancel = default)
    {
        var item = Set.Local.FirstOrDefault(i => Equals(i.Id, id));
        if (item is null)
            item = await Set
               .Select(i => new T { Id = i.Id })
               .FirstOrDefaultAsync(i => Equals(i.Id, id), cancel)
               .ConfigureAwait(false);

        return await Delete(item, cancel).ConfigureAwait(false);
    }

    public async Task<bool> Exist(T item, CancellationToken cancel = default)
    {
        return await Items.AnyAsync(i => Equals(i.Id, item.Id), cancel).ConfigureAwait(false);
    }

    public async Task<bool> ExistById(B id, CancellationToken cancel = default)
    {
        return await Items.AnyAsync(i => Equals(i.Id, id), cancel).ConfigureAwait(false);
    }

    public async Task<int> SaveChanges(CancellationToken Cancel = default)
    {
        return await db.SaveChangesAsync(Cancel).ConfigureAwait(false);
    }


}
