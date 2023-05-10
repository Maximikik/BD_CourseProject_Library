using BD_CourseProject_Library.Models;
using Microsoft.EntityFrameworkCore;
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
            var element = _context.Records.FirstOrDefault(entity => entity.Id == Convert.ToInt32(command.Id));

            if (element != null)
            {
                try
                {
                    _context.Records.Remove(element);
                    _context.SaveChanges();

                    _context.ReportActions.Add(new ReportAction { Table = "Records", Operation = Operations.Delete.ToString(), DateOffered = DateTime.Now });
                }
                catch (DbUpdateException)
                {
                    return false;
                }

                return true;
            }

            return false;
        }
    }
}
