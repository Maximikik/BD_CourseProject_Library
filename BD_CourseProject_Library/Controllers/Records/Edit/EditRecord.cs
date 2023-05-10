using BD_CourseProject_Library.Models;
using System;
using System.Linq;

namespace BD_CourseProject_Library.Controllers.Records.Edit
{
    public static class EditRecord
    {
        public static bool Edit(LibraryDbContext _context, EditRecordCommand command)
        {
            if (command.Id != string.Empty)
            {
                var element = _context.Records.FirstOrDefault(entity => entity.Id == Convert.ToInt32(command.Id));

                if (element != null)
                {
                    if (command.BookName != string.Empty)
                    {
                        var book = _context.Books.FirstOrDefault(entity => entity.Name == command.BookName);
                        if (book != null)
                        {
                            element.BookId = book.Id;
                        }
                    }
                    if (command.RentDateStart != default)
                    {
                        element.RentDateStart = command.RentDateStart;
                    }
                    if (command.RentDateEnd != default)
                    {
                        element.RentDateEnd = command.RentDateEnd;
                    }
                    if (command.ClientId != string.Empty)
                    {
                        element.ClientId = Convert.ToInt32(command.ClientId);
                    }

                    _context.ReportActions.Add(new ReportAction { Table = "Records", Operation = Operations.Edit.ToString(), DateOffered = DateTime.Now });

                    _context.SaveChanges();

                    return true;
                }

                return false;
            }

            return false;
        }
    }
}