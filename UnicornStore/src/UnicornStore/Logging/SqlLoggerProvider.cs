using System;
using System.Linq;
using Microsoft.Framework.Logging;
using Microsoft.Data.Entity.Update;
using Microsoft.Data.Entity.Query;

namespace UnicornStore.Logging
{
    public class SqlLoggerProvider : ILoggerProvider
    {
        private static readonly string[] _whitelist = new string[]
        {
                typeof(BatchExecutor).FullName,
                typeof(QueryContextFactory).FullName
        };

        public ILogger CreateLogger(string name)
        {
            // TODO return our logger for components that generate SQL


            return NullLogger.Instance;
        }

        public void Dispose()
        { }
    }
}
