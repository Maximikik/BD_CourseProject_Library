using System;
using System.Collections.Generic;
using System.Linq;

namespace BD_CourseProject_Library.Models
{
    public static class ReportRentDisplayConfigurator
    {
        //public static List<ReportDisplay> GetReports(LibraryDbContext _context)
        //{
        //    var reports = new List<ReportDisplay>();
        //    foreach (var item in _context.ReportRents)
        //    {
        //        var tempBook = _context.Books.FirstOrDefault(x => x.Id == item.BookId);
        //        var tempClient = _context.Clients.FirstOrDefault(x => x.Id == item.ClientId);
        //        reports.Add(new ReportDisplay { BookName = tempBook.Name, ClientName = tempClient.Name, ClientSurname = tempClient.Surname, DateOffered = item.DateOffered });
        //    }

        //    return reports;
        //}


        public class ReportDisplay
        {
            public int Id { get; set; }

            public string ClientName { get; set; } = null!;
            public string ClientSurname { get; set; } = null!;

            public string BookName { get; set; } = null!;

            public DateTime DateOffered { get; set; }
        }
    }
}

