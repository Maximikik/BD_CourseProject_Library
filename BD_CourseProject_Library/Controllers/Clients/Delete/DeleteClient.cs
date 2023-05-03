using System.Linq;

namespace BD_CourseProject_Library.Controllers.Clients.Delete
{
    public static class DeleteClient
    {
        public static bool Delete(LibraryDbContext _context, DeleteClientCommand command)
        {
            var element = _context.Clients.FirstOrDefault( entity => entity.Id == command.Id );

            if (element != null )
            {
                _context.Clients.Remove( element );
                _context.SaveChanges();
                
                return true;
            }

            return false;
        }

    }
}
