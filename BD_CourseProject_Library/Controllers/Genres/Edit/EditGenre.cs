using BD_CourseProject_Library.Models;
using System;
using System.Linq;

namespace BD_CourseProject_Library.Controllers.Genres.Edit
{
    public static class EditGenre
    {
        public static bool Edit(LibraryDbContext _context, EditGenreCommand command)
        {
            if (Validate(command))
            {
                var element = _context.Genres.FirstOrDefault(entity => entity.Id == command.Id);
                if (element != null)
                {
                    element.Name = command.Genre;
                    _context.ReportActions.Add(new ReportAction { Table = "Genres", Operation = Operations.Edit.ToString(), DateOffered = DateTime.Now });

                    _context.SaveChanges();

                    return true;
                }
                return false;
            }
            return false;
        }

        private static bool Validate(EditGenreCommand command)
        {
            if (command != null && command.Genre != string.Empty && command.Genre.Length <= 30 && !command.Genre.Any(char.IsDigit))
            {
                return true;
            }
            return false;
        }
    }
}
