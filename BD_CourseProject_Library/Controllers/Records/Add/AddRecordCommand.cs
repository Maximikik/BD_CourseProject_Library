using System;

namespace BD_CourseProject_Library.Controllers.Records.Add
{
    public class AddRecordCommand
    {
        public string BookName { get; set; } = null!;

        public DateTime RentDateStart { get; set; }

        public DateTime RentDateEnd { get; set; } 

        public string ClientId { get; set; } = null!;
    }
}
