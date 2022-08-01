using Events.Application.Common.Exceptions;
using Events.Application.Events.Commands.UpdateEvent;
using Events.Test.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Events.Test.Events.Commands
{
    public class UpdateEventCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateEventCommandHandler_Success()
        {
            //Arrange
            var handler = new UpdateEventCommandHandler(context);
            var updateTitle = "new Title";
            //Act
            var eventId = await handler.Handle(
                new UpdateEventCommand
                {
                    Id = EventsContextFactory.EventIdForUpdate,
                    UserId = EventsContextFactory.UserBId,
                    Title = updateTitle
                },
                CancellationToken.None);
            //Assert
            Assert.NotNull(
                await context.Events.SingleOrDefaultAsync(eve =>
                eve.Id == EventsContextFactory.EventIdForUpdate &&
                eve.Title == updateTitle));
        }

        [Fact]
        public async Task UpdateEventCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new UpdateEventCommandHandler(context);
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
               await handler.Handle(
                   new UpdateEventCommand
                   {
                       Id = Guid.NewGuid(),
                       UserId = EventsContextFactory.UserAId
                   },
                   CancellationToken.None));
        }

        [Fact]
        public async Task UpdateEventCommandHandler_FailOnWrongUserId()
        {
            //Arrange
            var handler = new UpdateEventCommandHandler(context);
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
               await handler.Handle(
                   new UpdateEventCommand
                   {
                       Id = EventsContextFactory.EventIdForUpdate,
                       UserId = EventsContextFactory.UserAId
                   },
                   CancellationToken.None));
        }
    }
}
