﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventTracker
{
    public class Block
    {
        public int BlockId { get; set; }
        public int EventId { get; set; }
        public DateTime BlockStart { get; set; }
        public DateTime BlockEnd { get; set; }
    }
}