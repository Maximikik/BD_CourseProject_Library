using System;
using System.Linq;

namespace BD_CourseProject_Library.Controllers.Books.Edit
{
    static class EditBook
    {
        private static int _Id { get; set; } 
        private static int _authorId { get; set; } 
        private static int _genreId { get; set; }
        private static int _quantity { get; set; }

        public static bool Edit(LibraryDbContext _context, EditBookCommand command)
        {
            Validate(command);

            var element = _context.Books.FirstOrDefault(entity => entity.Id == _Id);

            if (_Id != -1 && element != null)
            {
                if (command.Name != string.Empty && !command.Name.All(char.IsDigit))
                {
                    element.Name = command.Name;
                }

                if (_authorId != -1)
                {
                    element.AuthorId = _authorId;
                }

                if (_genreId != -1)
                {
                    element.GenreId = _genreId;
                }

                if (_quantity != -1)
                {
                    element.Quantity = _quantity;
                }

                _context.SaveChanges();

                return true;
            }
            return false;
        }

        private static void Validate(EditBookCommand command)
        {
            if (Int32.TryParse(command.Id, out int a) && a > 0)
            {
                _Id = a;
            }
            else _Id = -1;

            if (Int32.TryParse(command.AuthorId, out int b) && b > 0)
            {
                _authorId = b;
            }
            else _authorId = -1;

            if (Int32.TryParse(command.GenreId, out int c) && c > 0)
            {
                _genreId = c;
            }
            else _genreId = -1;

            if (Int32.TryParse(command.Quantity, out int d) && d > 0)
            {
                _quantity = d;
            }
            else _quantity = -1;
        }
    }
}
