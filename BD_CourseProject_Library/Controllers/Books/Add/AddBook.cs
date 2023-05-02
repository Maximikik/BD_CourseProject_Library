using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BD_CourseProject_Library.Controllers.Books.Add
{
    static class AddBook
    {
        public static bool Add(LibraryDbContext _context, AddBookQuery query)
        {
            var authorId = (from Id in _context.Authors where Id.Name == query.Author select Id);
            var genreId = (from Id in _context.Genres where Id.Name == query.Genre select Id);
            
            if (authorId != null ) 
            {
                _context.Books.Add(new Models.Book { Name = query.Name, AuthorId = authorId.First().Id, GenreId = genreId.First().Id, Quantity = query.Quantity });
                _context.SaveChangesAsync(CancellationToken.None);
                //_context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
