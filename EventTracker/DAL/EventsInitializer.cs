using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EventTracker.Models;

namespace EventTracker.DAL
{
    public class EventsInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EventsContext>
    {
        protected override void Seed(EventsContext context)
        {
            var events = new List<Event> { new Event{ Title="Massage", Description="Free Massages", Location="Gallery", OwnerENT="ent\bmtoney", Seats=3, BlockDuration=15, StartDateTime=DateTime.Parse("2015-03-05 08:00:00.000"), EndDateTime=DateTime.Parse("2015-03-05 09:00:00.000") }};

            events.ForEach(s => context.Events.Add(s));
            context.SaveChanges();

            var participants = new List<Participant> { 
                new Participant { BlockId=0, EventId=1, ParticipantENT=@"ent\jmelis", SeatId=2 },
                new Participant { BlockId=2, EventId=1, ParticipantENT=@"ent\tstahl", SeatId=2 },
                new Participant { BlockId=2, EventId=1, ParticipantENT=@"ent\bmtoney", SeatId=1 },
                new Participant { BlockId=3, EventId=1, ParticipantENT=@"ent\banderso", SeatId=2 },
                new Participant { BlockId=4, EventId=1, ParticipantENT=@"ent\mscobell", SeatId=2 }            
            };

            participants.ForEach(s => context.Participants.Add(s));
            context.SaveChanges();
        }
    }
}