using System;
using System.Linq;

namespace BD_CourseProject_Library.Controllers.Books.Edit
{
    static class EditBook
    {
        public static bool Edit(LibraryDbContext _context, EditBookCommand command)
        {
            if (Validate(command))
            {
                var element = _context.Books.FirstOrDefault(entity => entity.Id == Convert.ToInt32(command.Id));

                if (element != null)
                {
                    if (command.Name != string.Empty && !command.Name.Any(char.IsDigit))
                    {
                        element.Name = command.Name;
                    }

                    if (command.AuthorId != string.Empty)
                    {
                        element.AuthorId = Convert.ToInt32(command.AuthorId);
                    }

                    if (command.GenreId != string.Empty)
                    {
                        element.GenreId = Convert.ToInt32(command.GenreId);
                    }

                    if (command.Quantity != string.Empty)
                    {
                        element.Quantity = Convert.ToInt32(command.Quantity);
                    }

                    _context.SaveChanges();

                    return true;
                }
            }
            return false;
        }

        private static bool Validate(EditBookCommand command)
        {
            int quantityTemp = -1;

            if (Int32.TryParse(command.Quantity, out quantityTemp) &&
                command.Name.Length <=30)
            {
                return true;
            }

            return false;
        }
    }
}
