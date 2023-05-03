using Microsoft.EntityFrameworkCore;
using System;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;

namespace BD_CourseProject_Library.Controllers.Records.Edit
{
    public static class EditRecord
    {
        private static int _Id { get; set; } = -1;
        private static int _bookId { get; set; } = -1;
        private static DateTime _rentDateStart { get; set; } = DateTime.MinValue;
        private static DateTime _rentDateEnd { get; set; } = DateTime.MinValue;
        private static int _clientId { get; set; } = -1;


        public static bool Edit(LibraryDbContext _context, EditRecordCommand command)
        {
            if (Validate(_context, command))
            {
                var element = _context.Records.FirstOrDefault(entity => entity.Id == _Id);
                
                if (element != null)
                {
                    if (_bookId != -1) element.BookId = _bookId;
                    if (_clientId != -1) element.ClientId = _bookId;
                    if (_rentDateStart != DateTime.MinValue) element.RentDateStart = _rentDateStart;
                    if (_rentDateEnd != DateTime.MinValue) element.RentDateEnd = _rentDateEnd;
                    _context.SaveChanges();

                    return true;
                }

                return false;
            }

            return false;
        }

        public static bool Validate(LibraryDbContext _context, EditRecordCommand command)
        {
            if (command != null)
            {
                int id = -1;
                if (Int32.TryParse(command.Id, out id)) _Id = id;
                else return false;

                int tempBookId = 0;
                if (command.BookId != string.Empty && Int32.TryParse(command.BookId, out tempBookId) && tempBookId >= 0)
                {
                    _bookId = tempBookId;
                }
                else return false;

                DateTime rentDateStart = DateTime.MinValue;
                DateTime rentDateEnd = DateTime.MinValue;
                if (command.RentDateStart != string.Empty && command.RentDateEnd != string.Empty &&
                    DateTime.TryParse(command.RentDateStart, out rentDateStart) && DateTime.TryParse(command.RentDateEnd, out rentDateEnd))
                {
                    _rentDateStart = rentDateStart;
                    _rentDateEnd = rentDateEnd;
                }
                else return false;

                int tempClientId = 0;
                if (command.ClientId != string.Empty && Int32.TryParse(command.ClientId, out tempClientId) && tempClientId >= 0)
                {
                    _clientId = tempClientId;
                }
                else return false;

                return true;
            }

            return false;
        }
    }
}
