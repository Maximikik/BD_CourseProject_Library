using System;

namespace BD_CourseProject_Library.Controllers.Records.Edit
{
    public class EditRecordCommand
    {
        public string Id { get; set; } = null!;
        public string BookId { get; set; } = null!;

        public string RentDateStart { get; set; } = null!;

        public string RentDateEnd { get; set; } = null!;

        public string ClientId { get; set; } = null!;
    }
}
