using AutoMapper;
using Events.Application.Events.Queries.GetEventList;
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
    public class GetEventListQueryHandlerTests
    {
        private readonly EventsDbContext _context;
        private readonly IMapper _mapper;

        public GetEventListQueryHandlerTests(QueryTestFixture fixture) =>
            (_context, _mapper) = (fixture.context, fixture.mapper);

        [Fact]
        public async Task GetEventListQueryHandler_Success()
        {
            //Arrange
            var handler = new GetEventListQueryHandler(_context, _mapper);

            //Act
            var result = await handler.Handle(
                new GetEventListQuery{},
                CancellationToken.None);

            //Assert 
            result.ShouldBeOfType<EventListVm>();
            result.Events.Count.ShouldBe(4);
        }
    }
}
