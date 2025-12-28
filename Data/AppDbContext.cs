using Microsoft.EntityFrameworkCore;
using MiniLink.Models;

namespace MiniLink.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<ShortUrl> ShortUrls{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortUrl>().HasIndex(s=>s.Code).IsUnique();
        }
    }
}