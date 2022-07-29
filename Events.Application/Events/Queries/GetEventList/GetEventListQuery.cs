using MediatR;
using System;

namespace Events.Application.Events.Queries.GetEventList
{
    public class GetEventListQuery : IRequest<EventListVm>
    {
    }
}
