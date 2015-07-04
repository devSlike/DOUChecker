using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOUChecker.Loggers
{
    public interface ILogger
    {
        void LogMessage(String message);
        void LogMessage(LoggersTypeEnum loggerType, String message);
    }
}