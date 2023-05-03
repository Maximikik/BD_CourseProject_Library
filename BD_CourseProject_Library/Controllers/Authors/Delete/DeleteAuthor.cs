using System.Linq;

namespace BD_CourseProject_Library.Controllers.Authors.Delete
{
    public static class DeleteAuthor
    {
        public static bool Delete(LibraryDbContext _context, DeleteAuthorCommand command)
        {
            var element = _context.Authors.FirstOrDefault( entity => entity.Id == command.Id );

            if (element != null)
            {
                _context.Authors.Remove(element);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}