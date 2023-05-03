using System.Linq;

namespace BD_CourseProject_Library.Controllers.Authors.Add
{
    public static class AddAuthor
    {
        public static bool Add(LibraryDbContext _context, AddAuthorCommand command)
        {
            if (Validate(command))
            {
                _context.Authors.Add(new Models.Author() { Name = command.authorName });
                _context.SaveChanges();

                return true;
            }
            return false;
        }

        private static bool Validate(AddAuthorCommand command)
        {
            if (command.authorName != null && command.authorName.Length <= 30 && !command.authorName.All(char.IsDigit)) 
            {
                return true;
            }
            return false;
        }
    }
}