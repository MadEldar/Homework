using System;
using Microsoft.EntityFrameworkCore;

namespace Homework_2021_03_25.Models
{
    public class MemberMVCContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Member> Members { get; set; }

        public MemberMVCContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=MemberMVC;Trusted_Connection=True;MultipleActiveResultSets=True;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin"
                },
                new Role
                {
                    Id = 2,
                    Name = "User"
                }
            );

            builder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "Admin",
                    Password  = "1",
                    RoleId = 1
                },
                new User
                {
                    Id = 2,
                    Username = "User",
                    Password  = "2",
                    RoleId = 2
                }
            );

            builder.Entity<Member>().HasData(
                new Member
                {
                    Id = 1,
                    FirstName = "Hai",
                    LastName = "Le",
                    Gender = "Male",
                    DoB = new DateTime(1998, 1, 6),
                    PhoneNumber = "0934251231",
                    BirthPlace = "Ha Noi",
                    IsGraduated = false,
                    StartDate = new DateTime(2021, 3, 15),
                    EndDate = new DateTime(2021, 6, 15)
                },
                new Member
                {
                    Id = 2,
                    FirstName = "Vinh",
                    LastName = "Truong",
                    Gender = "Male",
                    DoB = new DateTime(2001, 12, 1),
                    PhoneNumber = "0931252314",
                    BirthPlace = "Ha Noi",
                    IsGraduated = false,
                    StartDate = new DateTime(2021, 3, 15),
                    EndDate = new DateTime(2021, 6, 15)
                },
                new Member
                {
                    Id = 3,
                    FirstName = "Trang",
                    LastName = "Bui",
                    Gender = "Female",
                    DoB = new DateTime(2000, 4, 9),
                    PhoneNumber = "0934251234",
                    BirthPlace = "Ha Noi",
                    IsGraduated = false,
                    StartDate = new DateTime(2021, 3, 15),
                    EndDate = new DateTime(2021, 6, 15)
                },
                new Member
                {
                    Id = 4,
                    FirstName = "Thang",
                    LastName = "Le",
                    Gender = "Male",
                    DoB = new DateTime(1995, 5, 2),
                    PhoneNumber = "0934251234",
                    BirthPlace = "Ha Noi",
                    IsGraduated = false,
                    StartDate = new DateTime(2021, 3, 15),
                    EndDate = new DateTime(2021, 6, 15)
                },
                new Member
                {
                    Id = 5,
                    FirstName = "Hanh",
                    LastName = "Vu",
                    Gender = "Female",
                    DoB = new DateTime(1994, 9, 1),
                    PhoneNumber = "0937582931",
                    BirthPlace = "Hai Phong",
                    IsGraduated = false,
                    StartDate = new DateTime(2021, 3, 15),
                    EndDate = new DateTime(2021, 6, 15)
                },
                new Member
                {
                    Id = 6,
                    FirstName = "Anh",
                    LastName = "Tran",
                    Gender = "Male",
                    DoB = new DateTime(2002, 8, 4),
                    PhoneNumber = "0931751231",
                    BirthPlace = "Can Tho",
                    IsGraduated = false,
                    StartDate = new DateTime(2021, 3, 23),
                    EndDate = new DateTime(2021, 6, 15)
                }
            );
        }
    }
}