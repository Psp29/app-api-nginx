using assignment1.Common.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace assignment1.DAL.UserDbContext
{
    public class UserDbContext : DbContext
    {
        public UserDbContext()
        {
        }

        public UserDbContext(DbContextOptions options):base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        //public string DbPath { get; private set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        //{
        //    dbContextOptionsBuilder.UseSqlite($"Data Source={DbPath}").LogTo(Console.Write); 
        //}

    }
}
