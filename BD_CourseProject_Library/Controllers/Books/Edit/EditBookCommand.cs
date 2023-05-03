using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_CourseProject_Library.Controllers.Books.Edit
{
    class EditBookCommand
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string AuthorId { get; set; } = null!;
        public string GenreId { get; set; } = null!;
        public string Quantity { get; set; } = null!;
    }
}
