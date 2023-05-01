using BD_CourseProject_Library.Models;
using BD_CourseProject_Library.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BD_CourseProject_Library
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


            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "J.D.Robb"},
                new Author { Id = 2, Name = "Colleen Hoover"},
                new Author { Id = 3, Name = "Bonnie Garmus"},
                new Author { Id = 4, Name = "Prince Harry"},
                new Author { Id = 5, Name = "Bessel van der Kolk"},
                new Author { Id = 6, Name = "Jennette McCurdy"},
                new Author { Id = 7, Name = "Pamela Anderson"});

            modelBuilder.Entity<Genre>().HasData(
                    new Genre { Id = 1, Name = "Fiction" },
                    new Genre { Id = 2, Name = "Nonfiction" },
                    new Genre { Id = 3, Name = "Fantasy" },
                    new Genre { Id = 4, Name = "Science fiction" },
                    new Genre { Id = 5, Name = "Dystopian" },
                    new Genre { Id = 6, Name = "Action & Adventure" },
                    new Genre { Id = 7, Name = "Mystery" },
                    new Genre { Id = 8, Name = "Horror" },
                    new Genre { Id = 9, Name = "Thriller & Suspense" },
                    new Genre { Id = 10, Name = "Historical Fiction" },
                    new Genre { Id = 11, Name = "Romance" },
                    new Genre { Id = 12, Name = "Women’s Fiction" },
                    new Genre { Id = 13, Name = "LGBTQ+" },
                    new Genre { Id = 14, Name = "Contemporary Fiction" },
                    new Genre { Id = 15, Name = "Literary Fiction" },
                    new Genre { Id = 16, Name = "Magical Realism" },
                    new Genre { Id = 17, Name = "Graphic Novel" },
                    new Genre { Id = 18, Name = "Short Story" },
                    new Genre { Id = 19, Name = "Young Adult" },
                    new Genre { Id = 20, Name = "New Adult" },
                    new Genre { Id = 21, Name = "Children’s" },
                    new Genre { Id = 22, Name = "Nonfiction genres" },
                    new Genre { Id = 23, Name = "Memoir & Autobiography" },
                    new Genre { Id = 24, Name = "Biography" },
                    new Genre { Id = 25, Name = "Food & Drink" },
                    new Genre { Id = 26, Name = "Art & Photography" },
                    new Genre { Id = 27, Name = "Self-help" },
                    new Genre { Id = 28, Name = "History" },
                    new Genre { Id = 29, Name = "Travel" },
                    new Genre { Id = 30, Name = "True Crime" },
                    new Genre { Id = 31, Name = "Humor" },
                    new Genre { Id = 32, Name = "Essays" },
                    new Genre { Id = 33, Name = "Guide / How-to" },
                    new Genre { Id = 34, Name = "Religion & Spirituality" },
                    new Genre { Id = 35, Name = "Humanities & Social Sciences" },
                    new Genre { Id = 36, Name = "Parenting & Families" },
                    new Genre { Id = 37, Name = "Science & Technology" });

            modelBuilder.Entity<Book>().HasData(
                    new Book { Id = 1, Name = "Encore in death", AuthorId = 1, GenreId = 12, Quantity = 1 },
                    new Book { Id = 2, Name = "It ends with us", AuthorId = 2, GenreId = 13, Quantity = 11 },
                    new Book { Id = 3, Name = "It starts with us", AuthorId = 2, GenreId = 11, Quantity = 11 },
                    new Book { Id = 4, Name = "Heart bones", AuthorId = 2, GenreId = 5, Quantity = 11 },
                    new Book { Id = 5, Name = "Lessons in chemistry", AuthorId = 3, GenreId = 3, Quantity = 1 },
                    new Book { Id = 6, Name = "Spare", AuthorId = 4, GenreId = 6, Quantity = 2 },
                    new Book { Id = 7, Name = "The body keeps the score", AuthorId = 5, GenreId = 5, Quantity = 27 },
                    new Book { Id = 8, Name = "Im glad my mom died", AuthorId = 6, GenreId = 3, Quantity = 2 },
                    new Book { Id = 9, Name = "Love, Pamela", AuthorId = 7, GenreId = 2, Quantity = 11 });

            base.OnModelCreating(modelBuilder);

        }
    }
}
