using Infotecs.Persistence;

namespace Infotecs.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly InfotecsDbContext Context;

        public TestCommandBase()
        {
            Context = InfotecsContextFactory.Create();
        }

        public void Dispose()
        {
            InfotecsContextFactory.Destroy(Context);
        }
    }
}
