﻿using BD_CourseProject_Library.Models;
using System;
using System.Linq;

namespace BD_CourseProject_Library.Controllers.Books.Delete
{
    static class DeleteBook
    {
        public static bool Delete(LibraryDbContext _context, DeleteBookCommand command)
        {
            var element = _context.Books.FirstOrDefault( entity => entity.Id == command.Id );

            if (element != null ) 
            {
                _context.Books.Remove( element );
                _context.ReportActions.Add(new ReportAction { Table = "Books", Operation = Operations.Delete.ToString(), DateOffered = DateTime.Now });

                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
