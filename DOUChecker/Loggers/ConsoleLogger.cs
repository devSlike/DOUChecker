using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOUChecker.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void LogMessage(LoggersTypeEnum loggerType, String message)
        {
            Console.WriteLine(String.Format("{0}: {1}", loggerType.ToString(), message));
        }

        public void LogMessage(string message)
        {
            Console.WriteLine(String.Format("{0}: {1}", LoggersTypeEnum.Console.ToString(), message));
        }
    }
}