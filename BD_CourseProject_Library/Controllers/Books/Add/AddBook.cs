using System.Linq;

namespace BD_CourseProject_Library.Controllers.Books.Add
{
    static class AddBook
    {
        public static bool Add(LibraryDbContext _context, AddBookCommand command)
        {
            if (Validate(command))
            {
                var authorId = _context.Authors.FirstOrDefault(entity => entity.Name == command.Author);
                var genreId = _context.Genres.FirstOrDefault(entity => entity.Name == command.Genre);

                if (authorId != null && genreId != null && !command.Name.Any(char.IsDigit))
                {
                    _context.Books.Add(new Models.Book { Name = command.Name, AuthorId = authorId.Id, GenreId = genreId.Id, Quantity = command.Quantity });
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        static private bool Validate(AddBookCommand command)
        {
            if (command.Genre != string.Empty && !command.Genre.Any(char.IsDigit) && command.Genre.Length <= 30 &&
                command.Author != string.Empty && !command.Author.Any(char.IsDigit) && command.Author.Length <= 30 &&
                command.Quantity > 0 && command.Name != string.Empty && !command.Name.All(char.IsDigit))
            {
                return true;
            }
            else return false;
        }
    }
}
