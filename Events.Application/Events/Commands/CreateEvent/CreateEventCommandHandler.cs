using Events.Application.Interfaces;
using Events.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Events.Application.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler
        : IRequestHandler<CreateEventCommand, Guid>
    {

        private readonly IEventsDbContext _dbContext;

        public CreateEventCommandHandler(IEventsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateEventCommand request,
            CancellationToken cancellationToken)
        {
            var eve = new Event
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Title = request.Title,
                Details = request.Details,
                Address = request.Address,
                EventDate = request.EventDate,
                CreationDate = DateTime.UtcNow,
                EditDate = null
            };

            await _dbContext.Events.AddAsync(eve, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return eve.Id;
        }
    }
}
