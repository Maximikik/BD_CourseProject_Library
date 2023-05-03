namespace BD_CourseProject_Library
{
    public static class DbInitialiser
    {
        public static void Initialise(LibraryDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
