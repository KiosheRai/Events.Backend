using Events.Application.Common.Exceptions;
using Events.Application.Interfaces;
using Events.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Events.Application.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler
        : IRequestHandler<DeleteEventCommand>
    {
        private readonly IEventsDbContext _dbContext;
        public DeleteEventCommandHandler(IEventsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteEventCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Events
                .FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Event), request.Id);
            }

            _dbContext.Events.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
