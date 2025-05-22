namespace EventManagement.Infrastructure.Persistence;

using EventManagement.Domain.Entities;

public static class SeedData
{
    public static void Initialize(EventManagementDbContext context)
    {
        if (context.Events.Any())
        {

            return;
        }

        //crear evento 
        var event1 = new Event(
            "Event 1",
            "Somos las mejores",
             DateTime.Now,
             DateTime.Now.AddDays(1),
             "Casa",
             "Dormir",
             "Activo");

        context.Events.Add(event1);
        context.SaveChanges();
    }
}
