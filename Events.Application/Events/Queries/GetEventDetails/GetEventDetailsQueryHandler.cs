using AutoMapper;
using Events.Application.Common.Exceptions;
using Events.Application.Interfaces;
using Events.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Events.Application.Events.Queries.GetEventDetails
{
    public class GetEventDetailsQueryHandler
        : IRequestHandler<GetEventDetailsQuery, EventDetailsVm>
    {
        private readonly IEventsDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetEventDetailsQueryHandler(IEventsDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<EventDetailsVm> Handle(GetEventDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Events
                .FirstOrDefaultAsync(eve =>
                eve.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Event), request.Id);
            }
            return _mapper.Map<EventDetailsVm>(entity);
        }
    }
}
