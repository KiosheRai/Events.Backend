using Events.Application.Common.Exceptions;
using Events.Application.Interfaces;
using Events.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Events.Application.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler
       : IRequestHandler<UpdateEventCommand>
    {

        private readonly IEventsDbContext _dbContext;

        public UpdateEventCommandHandler(IEventsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateEventCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Events.FirstOrDefaultAsync(eve => eve.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Event), request.Id);
            }

            entity.Title = request.Title;
            entity.Details = request.Details;
            entity.Address = request.Address;
            entity.EventDate = request.EventDate;
            entity.EditDate = DateTime.Now;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
