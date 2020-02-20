
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model.SongModel;
using Model.TabModel;
using Model.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbRepository
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Tab> Tabs { get; set; }

        public DbSet<DrumTab> DrumTabs { get; set; }

        public DbSet<GuitarTab> GuitarTabs { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=R9ETEM7\\\\SQLEXPRESS;Initial Catalog=AdkTabber;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //}
    }
}
