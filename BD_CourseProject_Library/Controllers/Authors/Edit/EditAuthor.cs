using BD_CourseProject_Library.Models;
using System;
using System.Linq;

namespace BD_CourseProject_Library.Controllers.Authors.Edit
{
    public static class EditAuthor
    {
        private static int _Id { get; set; }
        private static string _authorName { get; set; } = null!;


        public static bool Edit(LibraryDbContext _context, EditAuthorCommand command)
        {

            if (Validate(command))
            {
                var element = _context.Authors.FirstOrDefault(entity => entity.Id == _Id);
                if (element != null) 
                {
                    element.Name = _authorName;
                    _context.ReportActions.Add(new ReportAction { Table = "Authors", Operation = Operations.Edit.ToString(), DateOffered = DateTime.Now });

                    _context.SaveChanges();

                    return true;
                }
                return false;
            }
            return false;
        }

        private static bool Validate(EditAuthorCommand command)
        {
            if (command != null)
            {
                if (command.Id > 0)
                {
                    _Id = command.Id;
                }
                else return false;

                if (command.Author.Length <= 30 && !command.Author.All(char.IsDigit) && command.Author != string.Empty)
                {
                    _authorName = command.Author;
                }
                else return false;

                return true;
            }
            return false;
        }
    }
}