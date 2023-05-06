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
                    if (command.BookId != string.Empty)
                    {
                        element.BookId = Convert.ToInt32(command.BookId);
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

                    _context.SaveChanges();

                    return true;
                }

                return false;
            }

            return false;
        }
    }
}