using MediatR;
using System;

namespace Events.Application.Events.Queries.GetEventDetails
{
    public class GetEventDetailsQuery : IRequest<EventDetailsVm>
    {
        public Guid Id { get; set; } 
    }
}
