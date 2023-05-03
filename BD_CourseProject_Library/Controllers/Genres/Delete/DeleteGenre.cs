using System.Collections.Generic;
using System.Linq;

namespace BD_CourseProject_Library.Controllers.Genres.Delete
{
    public static class DeleteGenre
    {
        public static bool Delete(LibraryDbContext _context, DeleteGenreCommand command)
        {
            var element = _context.Genres.FirstOrDefault(entity => entity.Id == command.Id);

            if (element != null)
            {
                _context.Genres.Remove(element);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
