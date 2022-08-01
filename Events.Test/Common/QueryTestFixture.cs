using AutoMapper;
using Events.Application.Common.Mappings;
using Events.Application.Interfaces;
using Events.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Events.Test.Common
{
    public class QueryTestFixture : IDisposable
    {
        public EventsDbContext context;
        public IMapper mapper;

        public QueryTestFixture()
        {
            context = EventsContextFactory.Create();
            var configurationProvider = new MapperConfiguration(conf =>
            {
                conf.AddProfile(new AssemblyMappingProfile(
                    typeof(IEventsDbContext).Assembly));
            });

            mapper = configurationProvider.CreateMapper();
        }

        public void Dispose() =>
            EventsContextFactory.Destroy(context);
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
