using BlazorApp2.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Server
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Customer> Customer { get; set; }
    }
}
