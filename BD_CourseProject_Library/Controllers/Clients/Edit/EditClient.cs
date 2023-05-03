using System.Linq;
using System.Text.RegularExpressions;

namespace BD_CourseProject_Library.Controllers.Clients.Edit
{
    public static class EditClient
    {
        private static int _id { get; set; }
        private static string _name { get; set; } = null!;
        private static string _surname { get; set; } = null!;
        private static string _phoneNumber { get; set; } = null!;

        public static bool Edit(LibraryDbContext _context, EditClientCommand command)
        {
            if (Validate(command))
            {
                var element = _context.Clients.FirstOrDefault(entity => entity.Id == command.Id);

                if (element != null)
                {
                    if (_name != string.Empty) element.Name = _name;
                    if (_surname != string.Empty) element.Surname = _surname;
                    if (_phoneNumber != string.Empty) element.PhoneNumber = _phoneNumber;
                    return true;
                }
            }
            return false;
        }

        private static bool Validate(EditClientCommand command)
        {
            if (command != null)
            {
                if (command.Id >= 0) _id = command.Id;
                else return false;
                if (command.Name.Length <= 30 && !command.Name.All(char.IsDigit) && command.Name != string.Empty) _name = command.Name;
                if (command.Surname.Length <= 30 && !command.Surname.All(char.IsDigit) && command.Surname != string.Empty) _surname = command.Surname;
                if ( IsPhone(command.PhoneNumber) ) command.PhoneNumber = _phoneNumber;
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
