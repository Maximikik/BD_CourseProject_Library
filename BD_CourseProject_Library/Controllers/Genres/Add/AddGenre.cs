using BD_CourseProject_Library.Models;
using System;
using System.Linq;

namespace BD_CourseProject_Library.Controllers.Genres.Add
{
    static class AddGenre
    {
        public static bool Add(LibraryDbContext _context, AddGenreCommand command)
        {
            if (Validator(command))
            {
                _context.Genres.Add(new Models.Genre() { Name = command.Name });
                _context.ReportActions.Add(new ReportAction { Table = "Genres", Operation = Operations.Add.ToString(), DateOffered = DateTime.Now });

                _context.SaveChanges();

                return true;
            }

            return false;
        }

        private static bool Validator(AddGenreCommand command)
        {
            if (command != null && command.Name.Length <= 30
                && !command.Name.Any(char.IsDigit))
            {
                return true;
            }

            return false;
        }
    }
}
