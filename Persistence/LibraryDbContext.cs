using Microsoft.EntityFrameworkCore;
using Persistence.Models;
using Persistence.Models.Configurations;

namespace Persistence
{
    public class LibraryDbContext: DbContext, ILibraryDbContext
    {
        DbSet<Author> ILibraryDbContext.Authors { get; set; }
        DbSet<Book> ILibraryDbContext.Books { get; set; }
        DbSet<Client> ILibraryDbContext.Clients { get; set; }
        DbSet<Genre> ILibraryDbContext.Genres { get; set; }
        DbSet<Record> ILibraryDbContext.Records { get; set; }

        public LibraryDbContext() { }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Library;Trusted_Connection=true;Encrypt=false;TrustServerCertificate=false");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfig());
            modelBuilder.ApplyConfiguration(new BookConfig());
            modelBuilder.ApplyConfiguration(new ClientConfig());
            modelBuilder.ApplyConfiguration(new GenreConfig());
            modelBuilder.ApplyConfiguration(new RecordConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
