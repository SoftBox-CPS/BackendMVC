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
    public DbSet<RoomStatus> RoomStatuses { get; set; }
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

       Seed(modelBuilder);
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

	private void Seed(ModelBuilder modelBuilder)
	{
		// Seeds table of user_types
		modelBuilder.Entity<UserType>().HasData(
			new UserType { Id = 1, Name = "admin" },
			new UserType { Id = 2, Name = "user" },
			new UserType { Id = 3, Name = "moderator" });

		// Seeds table of user_organization_types
		modelBuilder.Entity<UserOrganizationType>().HasData(
			new UserOrganizationType { Id = 1, Name = "Организатор" },
			new UserOrganizationType { Id = 2, Name = "Директор" },
			new UserOrganizationType { Id = 3, Name = "Представитель" });

		// Seeds table of user_room_types
		modelBuilder.Entity<RoomUserType>().HasData(
			new RoomUserType { Id = 1, Name = "Владелец" },
			new RoomUserType { Id = 2, Name = "Пользователь" },
			new RoomUserType { Id = 3, Name = "Модератор" });

		// Seeds table of categories
		modelBuilder.Entity<Category>().HasData(
			new Category { Id = 1, Name = "Аптека", Description = "Аптека" },
			new Category { Id = 2, Name = "Книги", Description = "Книги" },
			new Category { Id = 3, Name = "Одежда", Description = "Одежда" },
			new Category { Id = 4, Name = "Обувь", Description = "Обувь" },
			new Category { Id = 5, Name = "Техника", Description = "Техника" },
			new Category { Id = 6, Name = "Мебель", Description = "Мебель" },
			new Category { Id = 7, Name = "Спорт и отдых", Description = "Спорт и отдых" },
			new Category { Id = 8, Name = "Хобби и творчество", Description = "Хобби и творчество" },
			new Category { Id = 9, Name = "Для школы и офиса", Description = "Для школы и офиса" },
			new Category { Id = 10, Name = "Для дома", Description = "Для дома" },
			new Category { Id = 11, Name = "Зоотовары", Description = "Зоотовары" },
			new Category { Id = 12, Name = "Юверирные украшени", Description = "Юверирные украшения" },
			new Category { Id = 13, Name = "Оборудование", Description = "Оборудование" },
			new Category { Id = 14, Name = "Детские товары", Description = "Детские товары" },
			new Category { Id = 15, Name = "Дача и сад", Description = "Дача и сад" },
			new Category { Id = 16, Name = "Строительство и ремонт", Description = "Строительство и ремонт" },
			new Category { Id = 17, Name = "Красота и гигиена", Description = "Красота и гигиена" },
			new Category { Id = 18, Name = "Электроника", Description = "Электроника" });
	}


}
