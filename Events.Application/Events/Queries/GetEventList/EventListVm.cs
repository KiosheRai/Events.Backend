﻿using System.Collections.Generic;

namespace Events.Application.Events.Queries.GetEventList
{
    public class EventListVm
    {
        public IList<EventLookUpDto> Events { get; set; }
    }
}
