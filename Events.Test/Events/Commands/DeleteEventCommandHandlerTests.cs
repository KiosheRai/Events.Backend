using Events.Application.Common.Exceptions;
using Events.Application.Events.Commands.CreateEvent;
using Events.Application.Events.Commands.DeleteEvent;
using Events.Test.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Events.Test.Events.Commands
{
    public class DeleteEventCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteEventCommandHandler_Success()
        {
            //Arrange
            var handler = new DeleteEventCommandHandler(context);

            //Act
            var eventId = await handler.Handle(
                new DeleteEventCommand
                {
                    Id = EventsContextFactory.EventIdForDelete,
                    UserId = EventsContextFactory.UserAId
                },
                CancellationToken.None);

            //Assert
            Assert.Null(
                await context.Events.SingleOrDefaultAsync(eve =>
                eve.Id == EventsContextFactory.EventIdForDelete));
        }

        [Fact]
        public async Task DeleteEventCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new DeleteEventCommandHandler(context);
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteEventCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = EventsContextFactory.UserAId,
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task DeleteEventCommandHandler_FailOnWrongUserId()
        {
            //Arrange
            var deleteHandler = new DeleteEventCommandHandler(context);
            var createHandler = new CreateEventCommandHandler(context);
            var eventId = await createHandler.Handle(
                 new CreateEventCommand
                 {
                     Title = "Event Title",
                     Details = "Event Details",
                     Address = "Event Address",
                     EventDate = DateTime.Today,
                     UserId = EventsContextFactory.UserAId,
                 },
                 CancellationToken.None);
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await deleteHandler.Handle(
                    new DeleteEventCommand
                    {
                        Id = eventId,
                        UserId = EventsContextFactory.UserBId
                    },
                    CancellationToken.None));
        }
    }
}
