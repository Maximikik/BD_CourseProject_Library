﻿namespace BD_CourseProject_Library.Controllers.Clients.Edit
{
    public class EditClientCommand
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
