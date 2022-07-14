using Microsoft.EntityFrameworkCore;
using SoftBox.DataBase.Entities;

namespace SoftBox.DataBase;

public class SoftBoxDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserType> UserTypes { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<UserOrganization> UserOrganizations { get; set; }
    public DbSet<UserOrganizationType> UserOrganizationTypes { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomStatus> RoomStatus { get; set; }
    public DbSet<RoomUser> RoomUsers { get; set; }
    public DbSet<RoomUserType> RoomUserTypes { get; set; }
    public DbSet<RoomMessage> RoomMessages { get; set; }


    public SoftBoxDbContext(DbContextOptions<SoftBoxDbContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SoftBoxDbContext).Assembly);

        addGenerateGuidToId(modelBuilder);
    }

    private void addGenerateGuidToId(ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes()
            .Where(e => typeof(Entities.Base.Entity<Guid>).IsAssignableFrom(e.ClrType))
            .Select(m => modelBuilder.Entity(m.ClrType)))
        {
            entity.Property(nameof(Entities.Base.Entity<Guid>.Id)).HasDefaultValueSql("NEWID()");
        }

    }

}
