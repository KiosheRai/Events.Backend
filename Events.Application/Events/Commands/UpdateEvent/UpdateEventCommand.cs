using MediatR;
using System;

namespace Events.Application.Events.Commands.UpdateEvent
{
    public class UpdateEventCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Address { get; set; }
        public DateTime EventDate { get; set; }
    }
}
