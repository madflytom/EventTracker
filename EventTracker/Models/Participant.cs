using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventTracker.Models
{
    public class Participant
    {
        public int ParticipantId { get; set; }
        public int EventId { get; set; }
        public string ParticipantENT { get; set; }
        public int SeatId { get; set; }
        public int BlockId { get; set; }
    }
}