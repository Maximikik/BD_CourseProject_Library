using System.Linq;
using System.Text.RegularExpressions;

namespace BD_CourseProject_Library.Controllers.Clients.Add
{
    public static class AddClient
    {
        public static bool Add(LibraryDbContext _context, AddClientCommand command)
        {
            if (Validate(command))
            {
                _context.Clients.Add(new Models.Client() { Name = command.Name, Surname = command.Surname, PhoneNumber = command.PhoneNumber} );
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        private static bool Validate(AddClientCommand command)
        {

            if (command != null &&
                command.Name.Length <= 30 && !command.Name.All(char.IsDigit)
                && command.Surname.Length <= 30 && !command.Surname.All(char.IsDigit)
                && IsPhone(command.PhoneNumber))
            {
                return true;
            }


            return false;
        }
        public static bool IsPhone(string str)
        {
            var rg = new Regex(@"^(\+375+(24|25|29|33|44)+([0-9]){7})$");
            if (!rg.IsMatch(str))
                return false;
            return true;
        }
    }
}
