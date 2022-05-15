using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SoftBox.DataBase.Entities;

namespace SoftBox.DataBase
{
    public class SoftBoxDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatUserType> ChatUserTypes { get; set; }
        public DbSet<ChatUser> ChatUsers { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }


        public SoftBoxDbContext(DbContextOptions<SoftBoxDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SoftBoxDbContext).Assembly);

            BuildModelUsers(modelBuilder);
            addGenerateGuidToId(modelBuilder);
        }

        private static void BuildModelUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(action =>
            {
                action.ToTable("Users");
                action.HasKey(c => c.Id);
                action.Property(dto => dto.Id).HasDefaultValueSql("NEWID()");
                action.Property(dto => dto.Name)
                        .HasMaxLength(50)
                        .IsRequired();

                action.Property(dto => dto.LegalName)
                        .HasMaxLength(50);

                action.Property(dto => dto.Surname)
                        .IsRequired();

                action.Property(dto => dto.Patronymic);
                action.Property(dto => dto.Phone);
                action.Property(dto => dto.OrganizationId);
                action.Property(dto => dto.Password);
                action.Property(dto => dto.TypeUserId);

            });
        }

        private void addGenerateGuidToId(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Chat>().Property(c => c.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Entities.ChatUser>().Property(c => c.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Entities.ChatMessage>().Property(c => c.Id).HasDefaultValueSql("NEWID()");

        }
    }
}
