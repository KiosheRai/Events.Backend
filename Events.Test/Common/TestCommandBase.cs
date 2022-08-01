using Events.Persistence;
using System;

namespace Events.Test.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly EventsDbContext context;

        public TestCommandBase() =>
            context = EventsContextFactory.Create();


        public void Dispose() =>
            EventsContextFactory.Destroy(context);
    }
}
