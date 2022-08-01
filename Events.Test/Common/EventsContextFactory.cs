using Events.Domain;
using Events.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace Events.Test.Common
{
    public static class EventsContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid EventIdForDelete = Guid.NewGuid();
        public static Guid EventIdForUpdate = Guid.NewGuid();

        public static EventsDbContext Create()
        {
            var options = new DbContextOptionsBuilder<EventsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new EventsDbContext(options);
            context.Database.EnsureCreated();
            context.Events.AddRange(
                new Event
                {
                    CreationDate = DateTime.Today,
                    Address = "Address1",
                    EventDate = DateTime.Today,
                    Details = "Detail1",
                    EditDate = null,
                    Id = Guid.Parse("DBE15A20-05A4-466D-97CA-4C3243ABEDF6"),
                    Title = "Title1",
                    UserId = UserAId
                },
                new Event
                {
                    CreationDate = DateTime.Today,
                    Address = "Address2",
                    EventDate = DateTime.Today,
                    Details = "Detail2",
                    EditDate = null,
                    Id = Guid.Parse("4E5CBD95-B035-4278-BB31-66C72191468C"),
                    Title = "Title2",
                    UserId = UserBId
                },
                new Event
                {
                    CreationDate = DateTime.Today,
                    Address = "Address3",
                    EventDate = DateTime.Today,
                    Details = "Detail3",
                    EditDate = null,
                    Id = EventIdForDelete,
                    Title = "Title3",
                    UserId = UserAId
                },
                new Event
                {
                    CreationDate = DateTime.Today,
                    Address = "Address4",
                    EventDate = DateTime.Today,
                    Details = "Detail4",
                    EditDate = null,
                    Id = EventIdForUpdate,
                    Title = "Title4",
                    UserId = UserBId
                }
             );

            context.SaveChanges();
            return context;
        }

        public static void Destroy(EventsDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
