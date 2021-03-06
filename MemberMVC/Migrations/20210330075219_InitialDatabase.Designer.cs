// <auto-generated />
using System;
using Homework_2021_03_25.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Homework_2021_03_25.Migrations
{
    [DbContext(typeof(MemberMVCContext))]
    [Migration("20210330075219_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Homework_2021_03_25.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BirthPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DoB")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsGraduated")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthPlace = "Ha Noi",
                            DoB = new DateTime(1998, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDate = new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Hai",
                            Gender = "Male",
                            IsGraduated = false,
                            LastName = "Le",
                            PhoneNumber = "0934251231",
                            StartDate = new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            BirthPlace = "Ha Noi",
                            DoB = new DateTime(2001, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDate = new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Vinh",
                            Gender = "Male",
                            IsGraduated = false,
                            LastName = "Truong",
                            PhoneNumber = "0931252314",
                            StartDate = new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            BirthPlace = "Ha Noi",
                            DoB = new DateTime(2000, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDate = new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Trang",
                            Gender = "Female",
                            IsGraduated = false,
                            LastName = "Bui",
                            PhoneNumber = "0934251234",
                            StartDate = new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            BirthPlace = "Ha Noi",
                            DoB = new DateTime(1995, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDate = new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Thang",
                            Gender = "Male",
                            IsGraduated = false,
                            LastName = "Le",
                            PhoneNumber = "0934251234",
                            StartDate = new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            BirthPlace = "Hai Phong",
                            DoB = new DateTime(1994, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDate = new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Hanh",
                            Gender = "Female",
                            IsGraduated = false,
                            LastName = "Vu",
                            PhoneNumber = "0937582931",
                            StartDate = new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            BirthPlace = "Can Tho",
                            DoB = new DateTime(2002, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDate = new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Anh",
                            Gender = "Male",
                            IsGraduated = false,
                            LastName = "Tran",
                            PhoneNumber = "0931751231",
                            StartDate = new DateTime(2021, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Homework_2021_03_25.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("Homework_2021_03_25.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "1",
                            RoleId = 1,
                            Username = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Password = "2",
                            RoleId = 2,
                            Username = "User"
                        });
                });

            modelBuilder.Entity("Homework_2021_03_25.Models.User", b =>
                {
                    b.HasOne("Homework_2021_03_25.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Homework_2021_03_25.Models.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
