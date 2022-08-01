using AutoMapper;
using Events.Application.Events.Queries.GetEventDetails;
using Events.Persistence;
using Events.Test.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Events.Test.Events.Queries
{
    [Collection("QueryCollection")]
    public class GetEventDetailsQueryHandlerTests
    {
        private readonly EventsDbContext _context;
        private readonly IMapper _mapper;

        public GetEventDetailsQueryHandlerTests(QueryTestFixture fixture) =>
            (_context, _mapper) = (fixture.context, fixture.mapper);

        [Fact]
        public async Task GetEventDetailsQueryHandler_Success()
        {
            //Arrange
            var handler = new GetEventDetailsQueryHandler(_context, _mapper);

            //Act
            var result = await handler.Handle(
                new GetEventDetailsQuery
                {
                    Id = Guid.Parse("4E5CBD95-B035-4278-BB31-66C72191468C")
                },
                CancellationToken.None);

            //Assert
            result.ShouldBeOfType<EventDetailsVm>();
            result.Title.ShouldBe("Title2");
            result.CreationDate.ShouldBe(DateTime.Today);
        }
    }
}
