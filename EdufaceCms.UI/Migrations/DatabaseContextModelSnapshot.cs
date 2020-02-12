﻿// <auto-generated />
using System;
using EdufaceCms.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EdufaceCms.UI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.BranchEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.ToTable("Branch");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.CityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.CountyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityId");

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CreUserId");

                    b.ToTable("County");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.DataQualityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.ToTable("DataQuality");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.DataSourceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.ToTable("DataSource");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.EducationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.GuarantorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("CellPhone")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<int>("CityId");

                    b.Property<int>("CountyId");

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Proximity")
                        .IsRequired();

                    b.Property<int>("StudentId");

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.Property<string>("TC")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.HasIndex("CityId")
                        .IsUnique();

                    b.HasIndex("CountyId")
                        .IsUnique();

                    b.HasIndex("CreUserId");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("Guarantor");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.LevelEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.ToTable("Level");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.LogEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<string>("IP")
                        .HasMaxLength(20);

                    b.Property<bool>("IsActive");

                    b.Property<int>("Level");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.PaymentTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.ToTable("PaymentType");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.PreRegisterEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppointmentDate")
                        .IsRequired();

                    b.Property<string>("CellPhone")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<int>("DataQualityId");

                    b.Property<int>("DataSourceId");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<decimal>("EstimatedPrice");

                    b.Property<decimal>("GivenPrice");

                    b.Property<string>("InterviewDate")
                        .IsRequired();

                    b.Property<string>("InterviewPerson")
                        .IsRequired();

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsRegister");

                    b.Property<int>("LevelId");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Not")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int>("PaymentTypeId");

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.Property<int>("TimeId");

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.HasIndex("DataQualityId")
                        .IsUnique();

                    b.HasIndex("DataSourceId")
                        .IsUnique();

                    b.HasIndex("LevelId")
                        .IsUnique();

                    b.HasIndex("PaymentTypeId")
                        .IsUnique();

                    b.HasIndex("TimeId")
                        .IsUnique();

                    b.ToTable("PreRegister");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.PriceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.ToTable("Price");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.StudentEducationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<int>("EducationId");

                    b.Property<bool>("IsActive");

                    b.Property<int>("LevelId");

                    b.Property<decimal>("ListPrice");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<decimal>("SavePrice");

                    b.Property<int>("StudentId");

                    b.Property<int>("TimeId");

                    b.Property<int>("TotalHour");

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.HasIndex("EducationId")
                        .IsUnique();

                    b.HasIndex("LevelId")
                        .IsUnique();

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.HasIndex("TimeId")
                        .IsUnique();

                    b.ToTable("StudentEducation");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.StudentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<int>("BranchId");

                    b.Property<string>("CellPhone")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<int>("CityId");

                    b.Property<int>("CountyId");

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("EmergencyPerson")
                        .IsRequired();

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Neighborhood")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .HasMaxLength(15);

                    b.Property<string>("Proximity")
                        .IsRequired();

                    b.Property<string>("Reference")
                        .IsRequired();

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.Property<string>("TC")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.HasIndex("BranchId")
                        .IsUnique();

                    b.HasIndex("CityId")
                        .IsUnique();

                    b.HasIndex("CountyId")
                        .IsUnique();

                    b.HasIndex("CreUserId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.StudentPaymentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AdvancePaymentDate");

                    b.Property<decimal>("AdvancePaymentPrice");

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<DateTime>("FirstPaymentDate");

                    b.Property<decimal>("InstallementCount");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<int>("PaymentTypeId");

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.HasIndex("PaymentTypeId")
                        .IsUnique();

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("StudentPayment");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.TimeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.ToTable("Time");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreDate");

                    b.Property<string>("CreUserId");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<DateTime>("ModDate");

                    b.Property<string>("ModUser")
                        .HasMaxLength(30);

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CreUserId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.BranchEntity", b =>
                {
                    b.HasOne("EdufaceCms.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.CityEntity", b =>
                {
                    b.HasOne("EdufaceCms.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.CountyEntity", b =>
                {
                    b.HasOne("EdufaceCms.Entities.Concrete.CityEntity", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("EdufaceCms.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.DataQualityEntity", b =>
                {
                    b.HasOne("EdufaceCms.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.DataSourceEntity", b =>
                {
                    b.HasOne("EdufaceCms.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.EducationEntity", b =>
                {
                    b.HasOne("EdufaceCms.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.GuarantorEntity", b =>
                {
                    b.HasOne("EdufaceCms.Entities.Concrete.CityEntity", "City")
                        .WithOne()
                        .HasForeignKey("EdufaceCms.Entities.Concrete.GuarantorEntity", "CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EdufaceCms.Entities.Concrete.CountyEntity", "County")
                        .WithOne()
                        .HasForeignKey("EdufaceCms.Entities.Concrete.GuarantorEntity", "CountyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EdufaceCms.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");

                    b.HasOne("EdufaceCms.Entities.Concrete.StudentEntity", "Student")
                        .WithOne()
                        .HasForeignKey("EdufaceCms.Entities.Concrete.GuarantorEntity", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.LevelEntity", b =>
                {
                    b.HasOne("EdufaceCms.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.LogEntity", b =>
                {
                    b.HasOne("EdufaceCms.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");

                    b.HasOne("EdufaceCms.Entities.Concrete.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.PaymentTypeEntity", b =>
                {
                    b.HasOne("EdufaceCms.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.PreRegisterEntity", b =>
                {
                    b.HasOne("EdufaceCms.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");

                    b.HasOne("EdufaceCms.Entities.Concrete.DataQualityEntity", "DataQuality")
                        .WithOne()
                        .HasForeignKey("EdufaceCms.Entities.Concrete.PreRegisterEntity", "DataQualityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EdufaceCms.Entities.Concrete.DataSourceEntity", "DataSource")
                        .WithOne()
                        .HasForeignKey("EdufaceCms.Entities.Concrete.PreRegisterEntity", "DataSourceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EdufaceCms.Entities.Concrete.LevelEntity", "Level")
                        .WithOne()
                        .HasForeignKey("EdufaceCms.Entities.Concrete.PreRegisterEntity", "LevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EdufaceCms.Entities.Concrete.PaymentTypeEntity", "PaymentType")
                        .WithOne()
                        .HasForeignKey("EdufaceCms.Entities.Concrete.PreRegisterEntity", "PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EdufaceCms.Entities.Concrete.TimeEntity", "Time")
                        .WithOne()
                        .HasForeignKey("EdufaceCms.Entities.Concrete.PreRegisterEntity", "TimeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.PriceEntity", b =>
                {
                    b.HasOne("EdufaceCms.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.StudentEducationEntity", b =>
                {
                    b.HasOne("EdufaceCms.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");

                    b.HasOne("EdufaceCms.Entities.Concrete.EducationEntity", "Education")
                        .WithOne()
                        .HasForeignKey("EdufaceCms.Entities.Concrete.StudentEducationEntity", "EducationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EdufaceCms.Entities.Concrete.LevelEntity", "Level")
                        .WithOne()
                        .HasForeignKey("EdufaceCms.Entities.Concrete.StudentEducationEntity", "LevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EdufaceCms.Entities.Concrete.StudentEntity", "Student")
                        .WithOne()
                        .HasForeignKey("EdufaceCms.Entities.Concrete.StudentEducationEntity", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EdufaceCms.Entities.Concrete.TimeEntity", "Time")
                        .WithOne()
                        .HasForeignKey("EdufaceCms.Entities.Concrete.StudentEducationEntity", "TimeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.StudentEntity", b =>
                {
                    b.HasOne("EdufaceCms.Entities.Concrete.BranchEntity", "Branch")
                        .WithOne()
                        .HasForeignKey("EdufaceCms.Entities.Concrete.StudentEntity", "BranchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EdufaceCms.Entities.Concrete.CityEntity", "City")
                        .WithOne()
                        .HasForeignKey("EdufaceCms.Entities.Concrete.StudentEntity", "CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EdufaceCms.Entities.Concrete.CountyEntity", "County")
                        .WithOne()
                        .HasForeignKey("EdufaceCms.Entities.Concrete.StudentEntity", "CountyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EdufaceCms.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.StudentPaymentEntity", b =>
                {
                    b.HasOne("EdufaceCms.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");

                    b.HasOne("EdufaceCms.Entities.Concrete.PaymentTypeEntity", "PaymentType")
                        .WithOne()
                        .HasForeignKey("EdufaceCms.Entities.Concrete.StudentPaymentEntity", "PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EdufaceCms.Entities.Concrete.StudentEntity", "Student")
                        .WithOne()
                        .HasForeignKey("EdufaceCms.Entities.Concrete.StudentPaymentEntity", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.TimeEntity", b =>
                {
                    b.HasOne("EdufaceCms.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");
                });

            modelBuilder.Entity("EdufaceCms.Entities.Concrete.UserEntity", b =>
                {
                    b.HasOne("EdufaceCms.Entities.Concrete.UserEntity", "CreUser")
                        .WithMany()
                        .HasForeignKey("CreUserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EdufaceCms.Entities.Concrete.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EdufaceCms.Entities.Concrete.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EdufaceCms.Entities.Concrete.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EdufaceCms.Entities.Concrete.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
