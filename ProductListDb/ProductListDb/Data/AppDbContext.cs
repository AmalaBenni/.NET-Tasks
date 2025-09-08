using Microsoft.EntityFrameworkCore;
using ProductListDb.Models;
using ProductListDb.Models;
using System.Collections.Generic;

namespace ProductListDb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<product> Products { get; set; }
    }
}