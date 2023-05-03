using BD_CourseProject_Library.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_CourseProject_Library.Controllers.Records.Delete
{
    public static class DeleteRecord
    {
        public static bool Delete(LibraryDbContext _context, DeleteRecordCommand command)
        {
            var element = _context.Records.FirstOrDefault( entity => entity.Id == command.Id );

            if ( element != null )
            {
                _context.Records.Remove(element);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
