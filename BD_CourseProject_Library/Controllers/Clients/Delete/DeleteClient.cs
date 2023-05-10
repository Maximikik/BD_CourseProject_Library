using BD_CourseProject_Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BD_CourseProject_Library.Controllers.Clients.Delete
{
    public static class DeleteClient
    {
        public static bool Delete(LibraryDbContext _context, DeleteClientCommand command)
        {
            var element = _context.Clients.FirstOrDefault( entity => entity.Id == command.Id );

            if (element != null )
            {
                try
                {
                    _context.Clients.Remove(element);
                    _context.ReportActions.Add(new ReportAction { Table = "Clients", Operation = Operations.Delete.ToString(), DateOffered = DateTime.Now });

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
