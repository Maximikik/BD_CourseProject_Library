namespace BD_CourseProject_Library.Controllers.Books.Add
{
    public class AddBookCommand
    {
        public string Name { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
