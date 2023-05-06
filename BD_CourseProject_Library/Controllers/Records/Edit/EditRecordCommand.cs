using System;

namespace BD_CourseProject_Library.Controllers.Records.Edit
{
    public class EditRecordCommand
    {
        public string Id { get; set; } = null!;
        public string BookId { get; set; } = null!;

        public DateTime RentDateStart { get; set; } 

        public DateTime RentDateEnd { get; set; }

        public string ClientId { get; set; } = null!;
    }
}
