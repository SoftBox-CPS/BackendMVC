﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoftBox.DataBase;

#nullable disable

namespace SoftBox.DataBase.Migrations
{
    [DbContext(typeof(SoftBoxDbContext))]
    partial class SoftBoxDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SoftBox.DataBase.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("image_url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Аптека",
                            Name = "Аптека"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Книги",
                            Name = "Книги"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Одежда",
                            Name = "Одежда"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Обувь",
                            Name = "Обувь"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Техника",
                            Name = "Техника"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Мебель",
                            Name = "Мебель"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Спорт и отдых",
                            Name = "Спорт и отдых"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Хобби и творчество",
                            Name = "Хобби и творчество"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Для школы и офиса",
                            Name = "Для школы и офиса"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Для дома",
                            Name = "Для дома"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Зоотовары",
                            Name = "Зоотовары"
                        },
                        new
                        {
                            Id = 12,
                            Description = "Юверирные украшения",
                            Name = "Юверирные украшени"
                        },
                        new
                        {
                            Id = 13,
                            Description = "Оборудование",
                            Name = "Оборудование"
                        },
                        new
                        {
                            Id = 14,
                            Description = "Детские товары",
                            Name = "Детские товары"
                        },
                        new
                        {
                            Id = 15,
                            Description = "Дача и сад",
                            Name = "Дача и сад"
                        },
                        new
                        {
                            Id = 16,
                            Description = "Строительство и ремонт",
                            Name = "Строительство и ремонт"
                        },
                        new
                        {
                            Id = 17,
                            Description = "Красота и гигиена",
                            Name = "Красота и гигиена"
                        },
                        new
                        {
                            Id = 18,
                            Description = "Электроника",
                            Name = "Электроника"
                        });
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("organizations");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTimeOffset>("CreateDateTimeOffset")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("create_date_time_offset");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("image_url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("organization_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("price");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("products");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.ProductCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("product_id");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId", "CategoryId")
                        .IsUnique();

                    b.ToTable("product_categories");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<int>("AmountProduct")
                        .HasColumnType("int")
                        .HasColumnName("amount_product");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("date")
                        .HasColumnName("expiration_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("price");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("product_id");

                    b.Property<int>("RoomStatusId")
                        .HasColumnType("int")
                        .HasColumnName("room_status_id");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("RoomStatusId");

                    b.ToTable("rooms");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.RoomMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTimeOffset>("CreateDateTimeOffset")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("create_date_time_offset");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("message");

                    b.Property<Guid>("RoomUserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("room_user_id");

                    b.HasKey("Id");

                    b.HasIndex("RoomUserId");

                    b.ToTable("room_messages");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.RoomStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("room_statuses");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.RoomUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<int>("AmountProduct")
                        .HasColumnType("int")
                        .HasColumnName("amount_product");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("room_id");

                    b.Property<int>("RoomUserTypeID")
                        .HasColumnType("int")
                        .HasColumnName("room_user_type_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("RoomUserTypeID");

                    b.HasIndex("UserId", "RoomId")
                        .IsUnique();

                    b.ToTable("room_users");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.RoomUserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("room_user_types");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Владелец"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Пользователь"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Модератор"
                        });
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("login");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password_hash");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("patronymic");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("phone");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int")
                        .HasColumnName("user_type_id");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.HasIndex("UserTypeId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.UserOrganization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTimeOffset?>("EndDateTimeOffset")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("end_date_time_offset");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("organization_id");

                    b.Property<DateTimeOffset>("StartDateTimeOffset")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("start_date_time_offset");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.Property<int>("UserOrganizationTypeId")
                        .HasColumnType("int")
                        .HasColumnName("user_organization_type_id");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserOrganizationTypeId");

                    b.ToTable("user_organizations");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.UserOrganizationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("user_organization_types");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Организатор"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Директор"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Представитель"
                        });
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("user_types");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "user"
                        },
                        new
                        {
                            Id = 3,
                            Name = "moderator"
                        });
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.Product", b =>
                {
                    b.HasOne("SoftBox.DataBase.Entities.Organization", "Organization")
                        .WithMany("Products")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.ProductCategory", b =>
                {
                    b.HasOne("SoftBox.DataBase.Entities.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftBox.DataBase.Entities.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.Room", b =>
                {
                    b.HasOne("SoftBox.DataBase.Entities.Product", "Product")
                        .WithMany("Rooms")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftBox.DataBase.Entities.RoomStatus", "RoomStatus")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("RoomStatus");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.RoomMessage", b =>
                {
                    b.HasOne("SoftBox.DataBase.Entities.RoomUser", "RoomUser")
                        .WithMany("RoomMessages")
                        .HasForeignKey("RoomUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomUser");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.RoomUser", b =>
                {
                    b.HasOne("SoftBox.DataBase.Entities.Room", "Room")
                        .WithMany("RoomUsers")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftBox.DataBase.Entities.RoomUserType", "RoomUserType")
                        .WithMany("RoomUsers")
                        .HasForeignKey("RoomUserTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftBox.DataBase.Entities.User", "User")
                        .WithMany("RoomUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("RoomUserType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.User", b =>
                {
                    b.HasOne("SoftBox.DataBase.Entities.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.UserOrganization", b =>
                {
                    b.HasOne("SoftBox.DataBase.Entities.Organization", "Organization")
                        .WithMany("UserOrganizations")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftBox.DataBase.Entities.User", "User")
                        .WithMany("UserOrganizations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftBox.DataBase.Entities.UserOrganizationType", "UserOrganizationType")
                        .WithMany("UserOrganizations")
                        .HasForeignKey("UserOrganizationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("User");

                    b.Navigation("UserOrganizationType");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.Category", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.Organization", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("UserOrganizations");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.Product", b =>
                {
                    b.Navigation("ProductCategories");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.Room", b =>
                {
                    b.Navigation("RoomUsers");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.RoomStatus", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.RoomUser", b =>
                {
                    b.Navigation("RoomMessages");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.RoomUserType", b =>
                {
                    b.Navigation("RoomUsers");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.User", b =>
                {
                    b.Navigation("RoomUsers");

                    b.Navigation("UserOrganizations");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.UserOrganizationType", b =>
                {
                    b.Navigation("UserOrganizations");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.UserType", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
