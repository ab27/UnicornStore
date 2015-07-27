using System.Linq;
using Microsoft.Framework.Logging;

namespace UnicornStore.Logging
{
    public class SqlLoggerProvider : ILoggerProvider
    {
        private static readonly string[] _whitelist = new string[]
        {
                "Microsoft.Data.Entity.Update.BatchExecutor",
                "Microsoft.Data.Entity.Query.QueryContextFactory"
        };

        public ILogger CreateLogger(string name)
        {
            // TODO return our logger sometimes

            return NullLogger.Instance;
        }
    }
}
