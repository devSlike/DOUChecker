using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOUChecker.Loggers
{
    public class MixedLogger : ILogger
    {
        private ConsoleLogger _consoleLogger = new ConsoleLogger();
        private TextFileLogger _textFileLogger = new TextFileLogger();

        public void LogMessage(LoggersTypeEnum loggerType, string message)
        {
            _consoleLogger.LogMessage(loggerType, message);
            _textFileLogger.LogMessage(loggerType, message);
        }

        public void LogMessage(string message)
        {
            _consoleLogger.LogMessage(LoggersTypeEnum.Mixed, message);
            _textFileLogger.LogMessage(LoggersTypeEnum.Mixed, message);
        }
    }
}
