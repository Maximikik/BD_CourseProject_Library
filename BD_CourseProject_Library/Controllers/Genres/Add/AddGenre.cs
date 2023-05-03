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
                _context.SaveChanges();

                return true;
            }

            return false;
        }

        private static bool Validator(AddGenreCommand command)
        {
            if (command != null && command.Name.Length <= 30
                && !command.Name.All(char.IsDigit))
            {
                return true;
            }

            return false;
        }
    }
}
