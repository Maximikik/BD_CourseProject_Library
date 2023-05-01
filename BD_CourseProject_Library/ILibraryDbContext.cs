using BD_CourseProject_Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BD_CourseProject_Library
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
