namespace EventTracker.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using EventTracker.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<EventTracker.Models.EventTrackerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EventTracker.Models.EventTrackerContext";
        }

        protected override void Seed(EventTracker.Models.EventTrackerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Events.AddOrUpdate(x => x.EventId,
                new Event() { Title = "Massage", Description = "Free Massages", Location = "Gallery", OwnerENT = "ent\bmtoney", Seats = 3, BlockDuration = 15, StartDateTime = DateTime.Parse("2015-03-05 08:00:00.000"), EndDateTime = DateTime.Parse("2015-03-05 09:00:00.000") }
                );
            context.Participants.AddOrUpdate(x => x.ParticipantId,
                new Participant() {BlockId=0, EventId=1, ParticipantENT=@"ent\jmelis", SeatId=2 },
                new Participant() { BlockId=2, EventId=1, ParticipantENT=@"ent\tstahl", SeatId=2 },
                new Participant(){ BlockId=2, EventId=1, ParticipantENT=@"ent\bmtoney", SeatId=1 },
                new Participant() { BlockId=3, EventId=1, ParticipantENT=@"ent\banderso", SeatId=2 },
                new Participant() { BlockId=4, EventId=1, ParticipantENT=@"ent\mscobell", SeatId=2 }
                );

        }
    }
}
