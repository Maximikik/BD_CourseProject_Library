using BD_CourseProject_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BD_CourseProject_Library.Controllers.Books.Edit
{
    static class EditBook
    {
        private static int _Id { get; set; } 
        private static int _authorId { get; set; } 
        private static int _genreId { get; set; }
        private static int _quantity { get; set; }

        public static bool Edit(LibraryDbContext _context, EditBookQuery query)
        {
            Validate(query);

            var element = _context.Books.FirstOrDefault(entity => entity.Id == _Id);

            if (_Id != -1 && element != null)
            {
                if (query.Name != string.Empty)
                {
                    element.Name = query.Name;
                }

                if (_authorId != -1)
                {
                    element.AuthorId = _authorId;
                }

                if (_genreId != -1)
                {
                    element.GenreId = _genreId;
                }

                if (_quantity != -1)
                {
                    element.Quantity = _quantity;
                }

                _context.SaveChangesAsync(CancellationToken.None);

                return true;
            }
            return false;
        }

        private static void Validate(EditBookQuery query)
        {
            if (Int32.TryParse(query.Id, out int a) && a > 0)
            {
                _Id = a;
            }
            else _Id = -1;

            if (Int32.TryParse(query.AuthorId, out int b) && b > 0)
            {
                _authorId = b;
            }
            else _authorId = -1;

            if (Int32.TryParse(query.GenreId, out int c) && c > 0)
            {
                _genreId = c;
            }
            else _genreId = -1;

            if (Int32.TryParse(query.Quantity, out int d) && d > 0)
            {
                _quantity = d;
            }
            else _quantity = -1;
        }
    }
}
