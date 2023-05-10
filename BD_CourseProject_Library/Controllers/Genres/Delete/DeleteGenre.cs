using BD_CourseProject_Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BD_CourseProject_Library.Controllers.Genres.Delete
{
    public static class DeleteGenre
    {
        public static bool Delete(LibraryDbContext _context, DeleteGenreCommand command)
        {
            var element = _context.Genres.FirstOrDefault(entity => entity.Id == command.Id);

            if (element != null)
            {
                try
                {
                    _context.Genres.Remove(element);
                    _context.ReportActions.Add(new ReportAction { Table = "Delete", Operation = Operations.Delete.ToString(), DateOffered = DateTime.Now });

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
