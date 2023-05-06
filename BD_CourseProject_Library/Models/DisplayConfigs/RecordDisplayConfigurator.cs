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
                ListRecords.Add(new RecordDisplay
                {
                    Id = item.Id,
                    BookId = item.BookId,
                    ClientId = item.ClientId,
                    RentDateStart = DateOnly.FromDateTime(item.RentDateStart),
                    RentDateEnd = DateOnly.FromDateTime(item.RentDateEnd)
                });
            }

            return ListRecords;
        }
    }

    public class RecordDisplay
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public DateOnly RentDateStart { get; set; }
        public DateOnly RentDateEnd { get; set; } 

        public int ClientId { get; set; }
    }
}
