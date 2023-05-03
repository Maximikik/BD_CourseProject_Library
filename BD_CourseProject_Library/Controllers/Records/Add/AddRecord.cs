using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BD_CourseProject_Library.Controllers.Records.Add
{
    public static class AddRecord
    {
        private static int _clientId { get; set; } = -1;
        private static DateTime _rentStart { get; set; } = DateTime.MinValue;
        private static DateTime _rentEnd { get; set; } = DateTime.MinValue;

        public static bool Add(LibraryDbContext _context, AddRecordCommand command)
        {
            if (Validate(command))
            {
                var book = _context.Books.FirstOrDefault(entity => entity.Name == command.BookName);

                if (book.Id != null && _clientId != 0)
                {
                    _context.Records.Add(new Models.Record { BookId = book.Id, RentDateStart = _rentStart, RentDateEnd = _rentEnd, ClientId = _clientId });
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        private static bool Validate(AddRecordCommand command)
        {
            int clientId = -1;
            DateTime rentStart = DateTime.MinValue;
            DateTime rentEnd = DateTime.MinValue;

            if (Int32.TryParse(command.ClientId, out clientId)
                && DateTime.TryParse(command.RentDateStart, out rentStart) && DateTime.TryParse(command.RentDateEnd, out rentEnd))
            {
                _clientId = clientId;
                _rentStart = rentStart;
                _rentEnd = rentEnd;

                return true;
            }

            return false; 
        }
    }

    
}