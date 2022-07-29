using AutoMapper;
using AutoMapper.QueryableExtensions;
using Events.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Events.Application.Events.Queries.GetEventList
{
    public class GetEventListQueryHandler
       : IRequestHandler<GetEventListQuery, EventListVm>
    {
        private readonly IEventsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEventListQueryHandler(IEventsDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<EventListVm> Handle(GetEventListQuery request,
            CancellationToken cancellationToken)
        {
            var noteQuery = await _dbContext.Events
                .ProjectTo<EventLookUpDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new EventListVm { Notes = noteQuery };
        }
    }
}
