using BD_CourseProject_Library.Controllers.Books.Add;
using BD_CourseProject_Library.Models;
using System;
using System.Linq;

namespace BD_CourseProject_Library.Controllers.Records.Add
{
    public static class AddRecord
    {
        public static bool Add(LibraryDbContext _context, AddRecordCommand command)
        {
            if (Validate(command))
            {
                var book = _context.Books.FirstOrDefault(entity => entity.Name == command.BookName);
 
                if (book != null)
                {
                    _context.Records.Add(new Models.Record { BookId = book.Id, 
                        RentDateStart = command.RentDateStart,
                        RentDateEnd = command.RentDateEnd, 
                        ClientId =  Convert.ToInt32(command.ClientId)
                    });
                    //_context.ReportRents.Add(new ReportRent { BookId = book.Id, ClientId = Convert.ToInt32(command.ClientId), DateOffered = DateTime.Now });

                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        private static bool Validate(AddRecordCommand command)
        {
            if (command.BookName != string.Empty &&
                command.RentDateStart < command.RentDateEnd)
            {
                return true;
            }

            return false; 
        }
    }

    
}