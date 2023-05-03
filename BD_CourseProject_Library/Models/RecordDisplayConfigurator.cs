using System;
using System.Collections.Generic;

namespace BD_CourseProject_Library.Models
{
    public static class RecordDisplayConfigurator
    {
        public static List<RecordDisplay> GetRecords(LibraryDbContext _context)
        {
            List<RecordDisplay> ListRecords = new List<RecordDisplay>();

            foreach (var item in _context.Records)
            {
                ListRecords.Add(new RecordDisplay { Id = item.Id, BookId = item.BookId, ClientId = item.ClientId, RentDateStart = item.RentDateStart.ToString("dd:MM:yyyy"),
                RentDateEnd=item.RentDateEnd.ToString("MM:dd:yyyy")});
            }

            return ListRecords;
        }
    }

    public class RecordDisplay
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string RentDateStart { get; set; } = null!;
        public string RentDateEnd { get; set; } = null!;

        public int ClientId { get; set; }
    }
}
