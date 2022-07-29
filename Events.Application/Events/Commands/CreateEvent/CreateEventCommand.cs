using MediatR;
using System;

namespace Events.Application.Events.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Address { get; set; }
        public DateTime EventDate { get; set; }
    }
}
