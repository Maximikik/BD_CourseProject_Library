using BD_CourseProject_Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BD_CourseProject_Library.Controllers.Authors.Delete
{
    public static class DeleteAuthor
    {
        public static bool Delete(LibraryDbContext _context, DeleteAuthorCommand command)
        {
            var element = _context.Authors.FirstOrDefault( entity => entity.Id == command.Id );

            if (element != null)
            {
                try
                {
                    _context.Authors.Remove(element);
                    _context.ReportActions.Add(new ReportAction { Table = "Authors", Operation = Operations.Delete.ToString(), DateOffered = DateTime.Now });

                    _context.SaveChanges();
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

//Microsoft.EntityFrameworkCore.DbUpdateException