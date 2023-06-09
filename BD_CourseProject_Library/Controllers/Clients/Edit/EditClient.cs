﻿using BD_CourseProject_Library.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BD_CourseProject_Library.Controllers.Clients.Edit
{
    public static class EditClient
    {
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

                    _context.ReportActions.Add(new ReportAction { Table = "Clients", Operation = Operations.Edit.ToString(), DateOffered = DateTime.Now });

                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        private static bool Validate(EditClientCommand command)
        {
            if (command != null)
            {
                if ( command.Name.Length >= 30 || command.Name.Any(char.IsDigit)) return false;
                if ( command.Surname.Length >= 30 || command.Surname.Any(char.IsDigit)) return false;
                if ( command.PhoneNumber != string.Empty && !IsPhone(command.PhoneNumber) ) return false;
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
