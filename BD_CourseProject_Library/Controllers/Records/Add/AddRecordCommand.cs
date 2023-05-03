using System;

namespace BD_CourseProject_Library.Controllers.Records.Add
{
    public class AddRecordCommand
    {
        public string BookName { get; set; } = null!;

        public string RentDateStart { get; set; } = null!;

        public string RentDateEnd { get; set; } = null!;

        public string ClientId { get; set; } = null!;
    }
}
