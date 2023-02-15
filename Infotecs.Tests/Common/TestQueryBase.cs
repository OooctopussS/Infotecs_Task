using Infotecs.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infotecs.Tests.Common
{
    public abstract class TestQueryBase : IDisposable
    {
        protected readonly InfotecsDbContext Context;

        public TestQueryBase()
        {
            Context = InfotecsContextFactory.Create();
        }

        public void Dispose()
        {
            InfotecsContextFactory.Destroy(Context);
        }
    }
}
