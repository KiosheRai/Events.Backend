using Events.Application.Events.Commands.CreateEvent;
using Events.Test.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Events.Test.Events.Commands
{
    public class CreateEventCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateEventCommandHandler_Success()
        {
            //Arrange
            var handler = new CreateEventCommandHandler(context);
            var eventName = "event name";
            var eventDetails = "event details";
            var eventAddress = "event address";
            var eventDate = DateTime.Today;

            //Act
            var eventId = await handler.Handle(
                new CreateEventCommand
                {
                    Title = eventName,
                    Details = eventDetails,
                    Address = eventAddress,
                    EventDate = eventDate,
                    UserId = EventsContextFactory.UserAId
                },
                CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.Events.SingleOrDefaultAsync(eve =>
                eve.Id == eventId
                && eve.Title == eventName
                && eve.Details == eventDetails
                && eve.Address == eventAddress
                && eve.EventDate == eventDate));
        }
    }
}
