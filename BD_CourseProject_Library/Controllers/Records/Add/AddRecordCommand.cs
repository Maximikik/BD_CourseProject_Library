using System;

namespace BD_CourseProject_Library.Controllers.Records.Add
{
    public class AddRecordCommand
    {
        public int BookId { get; set; }

        public DateTime RentDateStart { get; set; }

        public DateTime RentDateEnd { get; set; }

        public int ClientId { get; set; }
    }
}
