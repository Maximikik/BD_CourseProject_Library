using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BD_CourseProject_Library.Controllers.Books.Delete
{
    static class DeleteBook
    {
        public static bool Delete(LibraryDbContext _context, DeleteBookQuery query)
        {
            var element = _context.Books.FirstOrDefault( entity => entity.Id == query.id );

            if (element != null ) 
            {
                _context.Books.Remove( element );
                _context.SaveChangesAsync(CancellationToken.None);
                return true;
            }

            return false;
        }
    }
}
