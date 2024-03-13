using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blockBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace blockBackend.Services.Context
{
    public class DataContext : DbContext
    {
        public DbSet<UserModel> UserInfo { get; set; }
        public DbSet<BlogItemModel> BlogInfo { get; set; }

        public DataContext(DbContextOptions options) : base(options){}

        // this function will build out our table in the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}