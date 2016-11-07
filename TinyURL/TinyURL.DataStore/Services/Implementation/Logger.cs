using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyURL.DataStore.Services.Implementation
{
    public class Logger : ILogger
    {
        public void LogError(LogMessage logMessage)
        {
            using (var context = new TinyURLEntities())
            {
                context.LogMessages.Add(logMessage);
                context.SaveChanges();
            }
        }

    }
}
