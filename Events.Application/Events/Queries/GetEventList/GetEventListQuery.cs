using MediatR;
using System;

namespace Events.Application.Events.Queries.GetEventList
{
    public class GetEventListQuery : IRequest<EventListVm>
    {
        public Guid UserId { get; set; }
    }
}
