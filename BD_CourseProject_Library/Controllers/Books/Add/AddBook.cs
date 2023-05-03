using System.Linq;

namespace BD_CourseProject_Library.Controllers.Books.Add
{
    static class AddBook
    {
        public static bool Add(LibraryDbContext _context, AddBookCommand command)
        {
            var authorId = (from Id in _context.Authors where Id.Name == command.Author select Id);
            var genreId = (from Id in _context.Genres where Id.Name == command.Genre select Id);
            
            if (authorId != null && genreId != null && !command.Name.All(char.IsDigit)) 
            {
                _context.Books.Add(new Models.Book { Name = command.Name, AuthorId = authorId.First().Id, GenreId = genreId.First().Id, Quantity = command.Quantity });
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
