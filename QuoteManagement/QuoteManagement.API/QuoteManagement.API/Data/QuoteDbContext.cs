using Microsoft.EntityFrameworkCore;
using QuoteManagement.API.Models.Entities;

namespace QuoteManagement.API.Data
{
    public class QuoteDbContext : DbContext
    {
        public QuoteDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quote>()
                .HasOne(x=>x.Author)
                .WithMany(x=>x.Quotes)
                .HasForeignKey(x=>x.AuthorId);
        }
    }
}
