using BD_CourseProject_Library.Models;
using BD_CourseProject_Library.Models.Configurations;
using BD_CourseProject_Library.Models.DisplayConfigs;
using Microsoft.EntityFrameworkCore;
using System;

namespace BD_CourseProject_Library
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<ReportAction> ReportActions { get; set; }
        public DbSet<ReportRent> ReportRents { get; set; }
        public DbSet<ReportAllRents> ReportAllRents { get; set; }

        public LibraryDbContext() : base() 
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Library;Trusted_Connection=true;Encrypt=false;TrustServerCertificate=false");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfig());
            modelBuilder.ApplyConfiguration(new BookConfig());
            modelBuilder.ApplyConfiguration(new ClientConfig());
            modelBuilder.ApplyConfiguration(new GenreConfig());
            modelBuilder.ApplyConfiguration(new RecordConfig());
            modelBuilder.ApplyConfiguration(new ReportActionConfig());
            modelBuilder.ApplyConfiguration(new ReportRentConfig());


            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "J.D.Robb" },
                new Author { Id = 2, Name = "Colleen Hoover" },
                new Author { Id = 3, Name = "Bonnie Garmus" },
                new Author { Id = 4, Name = "Prince Harry" },
                new Author { Id = 5, Name = "Bessel van der Kolk" },
                new Author { Id = 6, Name = "Jennette McCurdy" },
                new Author { Id = 7, Name = "Pamela Anderson" });

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

            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, Name = "Maxim", Surname = "Rudolovskiy", PhoneNumber = "+375296261410" },
                new Client { Id = 2, Name = "Oleg", Surname = "Ivanov", PhoneNumber = "+375296261411" },
                new Client { Id = 3, Name = "Daniil", Surname = "Mihadiuk", PhoneNumber = "+375296958473" },
                new Client { Id = 4, Name = "Dmitry", Surname = "Kudlasevich", PhoneNumber = "+375255019461" },
                new Client { Id = 5, Name = "Denis", Surname = "Gavrilov", PhoneNumber = "+375335671023" },
                new Client { Id = 6, Name = "Kirill", Surname = "Lashukevich", PhoneNumber = "+375445671753" },
                new Client { Id = 7, Name = "Alexandr", Surname = "Drozdov", PhoneNumber = "+375294756471" },
                new Client { Id = 8, Name = "Pavel", Surname = "Milkevich", PhoneNumber = "+375294763841" }
                );

            modelBuilder.Entity<Record>().HasData(
                new Record { Id = 1, BookId = 1, RentDateStart = DateTime.Parse("17-Dec-2022"), RentDateEnd = DateTime.Parse("17-Mar-2023"), ClientId = 2 },
                new Record { Id = 2, BookId = 3, RentDateStart = DateTime.Parse("23-Dec-2022"), RentDateEnd = DateTime.Parse("17-Mar-2023"), ClientId = 4 },
                new Record { Id = 3, BookId = 4, RentDateStart = DateTime.Parse("13-Jan-2023"), RentDateEnd = DateTime.Parse("25-Apr-2023"), ClientId = 3 },
                new Record { Id = 4, BookId = 5, RentDateStart = DateTime.Parse("19-Jan-2023"), RentDateEnd = DateTime.Parse("22-May-2023"), ClientId = 3 },
                new Record { Id = 5, BookId = 6, RentDateStart = DateTime.Parse("15-Feb-2023"), RentDateEnd = DateTime.Parse("21-May-2023"), ClientId = 6 },
                new Record { Id = 6, BookId = 7, RentDateStart = DateTime.Parse("03-Jan-2023"), RentDateEnd = DateTime.Parse("08-Jun-2023"), ClientId = 5 },
                new Record { Id = 7, BookId = 2, RentDateStart = DateTime.Parse("22-Dec-2022"), RentDateEnd = DateTime.Parse("01-Jul-2023"), ClientId = 1 }
                );

            modelBuilder.Entity<ReportRent>().HasData(
                new ReportRent { Id = 1, BookId = 1, DateOffered = DateTime.Parse("17-Dec-2022"), ClientId = 2 },
                new ReportRent { Id = 2, BookId = 3, DateOffered = DateTime.Parse("23-Dec-2022"), ClientId = 4 },
                new ReportRent { Id = 3, BookId = 4, DateOffered = DateTime.Parse("13-Jan-2023"), ClientId = 3 },
                new ReportRent { Id = 4, BookId = 5, DateOffered = DateTime.Parse("19-Jan-2023"), ClientId = 3 },
                new ReportRent { Id = 5, BookId = 6, DateOffered = DateTime.Parse("15-Feb-2023"), ClientId = 6 },
                new ReportRent { Id = 6, BookId = 7, DateOffered = DateTime.Parse("03-Jan-2023"), ClientId = 5 },
                new ReportRent { Id = 7, BookId = 2, DateOffered = DateTime.Parse("22-Dec-2022"), ClientId = 1 }
                );


            base.OnModelCreating(modelBuilder);
        }
    }
}
