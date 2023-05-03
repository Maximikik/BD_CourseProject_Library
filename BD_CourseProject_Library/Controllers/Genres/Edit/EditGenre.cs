using System.Linq;

namespace BD_CourseProject_Library.Controllers.Genres.Edit
{
    public static class EditGenre
    {
        private static int _Id { get; set; }
        private static string _genreName { get; set; } = null!;


        public static bool Edit(LibraryDbContext _context, EditGenreCommand command)
        {

            if (Validate(command))
            {
                var element = _context.Genres.FirstOrDefault(entity => entity.Id == _Id);
                if (element != null)
                {
                    element.Name = _genreName;

                    _context.SaveChanges();

                    return true;
                }
                return false;
            }
            return false;
        }

        private static bool Validate(EditGenreCommand command)
        {
            if (command != null)
            {
                if (command.Id > 0)
                {
                    _Id = command.Id;
                }
                else return false;

                if (command.Genre.Length <= 30 && !command.Genre.All(char.IsDigit) && command.Genre != null)
                {
                    _genreName = command.Genre;
                }
                else return false;

                return true;
            }
            return false;
        }
    }
}
