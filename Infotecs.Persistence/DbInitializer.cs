namespace Infotecs.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(InfotecsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
