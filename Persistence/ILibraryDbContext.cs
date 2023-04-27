using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence
{
    public interface ILibraryDbContext
    {
        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Record> Records { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
