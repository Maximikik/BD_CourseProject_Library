using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_CourseProject_Library.Controllers.Books.Edit
{
    class EditBookQuery
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? AuthorId { get; set; }
        public string? GenreId { get; set; }
        public string? Quantity { get; set; }
    }
}
