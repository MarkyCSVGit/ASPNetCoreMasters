//using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Services.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }


    }
}
