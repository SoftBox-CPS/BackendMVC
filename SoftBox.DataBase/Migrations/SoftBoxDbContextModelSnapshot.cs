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
                .HasAnnotation("ProductVersion", "6.0.5")
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

            modelBuilder.Entity("SoftBox.DataBase.Entities.OrganizationProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("organization_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("price");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("product_id");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("ProductId", "OrganizationId")
                        .IsUnique();

                    b.ToTable("organization_products");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTimeOffset>("CreatedDateOffset")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("created_date_offset");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("image_url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("price");

                    b.HasKey("Id");

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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<Guid>("OrganizationProductId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("organization_product_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("price");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationProductId");

                    b.ToTable("rooms");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.RoomMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTimeOffset>("DateTimeUTCMessage")
                        .HasColumnType("datetimeoffset");

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

                    b.Property<DateTimeOffset?>("DateEndOffset")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("date_end_offset");

                    b.Property<DateTimeOffset>("DateStartOffset")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("date_start_offset");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("organization_id");

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
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.OrganizationProduct", b =>
                {
                    b.HasOne("SoftBox.DataBase.Entities.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftBox.DataBase.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("Product");
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
                    b.HasOne("SoftBox.DataBase.Entities.OrganizationProduct", "OrganizationProduct")
                        .WithMany("Rooms")
                        .HasForeignKey("OrganizationProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrganizationProduct");
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
                    b.Navigation("UserOrganizations");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.OrganizationProduct", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.Product", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("SoftBox.DataBase.Entities.Room", b =>
                {
                    b.Navigation("RoomUsers");
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
