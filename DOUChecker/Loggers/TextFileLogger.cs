using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DOUChecker.Loggers
{
    public class TextFileLogger : ILogger
    {
        private String _fileName = String.Format("{0}\\{1}.txt", AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString().Replace(':', '-'));

        public TextFileLogger()
        {
            try
            {
                StreamWriter file = new StreamWriter(_fileName);
                file.Close();
                Console.WriteLine(String.Format("Log will saved in file {0}", _fileName));
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Error creating file {0}, ", _fileName, ex.Message));
            }
        }

        public void LogMessage(LoggersTypeEnum loggerType, string message)
        {
            try
            {
                var s = String.Format("Text file logger: {0}", message);
                var file = File.AppendText(_fileName);
                file.WriteLine(s);
                file.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(String.Format("Error appending file: {0}", ex.Message));
            }
        }

        public void LogMessage(string message)
        {
            LogMessage(LoggersTypeEnum.TextFile, message);
        }
    }
}
