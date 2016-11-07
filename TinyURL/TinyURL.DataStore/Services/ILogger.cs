using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyURL.DataStore.Services
{
    public interface ILogger
    {
        void LogError(LogMessage logMessage);
    }
}
