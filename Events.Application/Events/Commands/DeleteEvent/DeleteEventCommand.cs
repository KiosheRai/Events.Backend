using MediatR;
using System;

namespace Events.Application.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
