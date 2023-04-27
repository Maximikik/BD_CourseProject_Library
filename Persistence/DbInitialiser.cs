namespace Persistence
{
    public static class DbInitialiser
    {
        public static void Initialise(LibraryDbContext context)
        {
            context.Database.EnsureCreated();
        }


    }
}
