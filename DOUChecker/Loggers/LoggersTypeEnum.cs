using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOUChecker.Loggers
{
    public enum LoggersTypeEnum
    {
        [Description("Console logger")]
        Console,
        [Description("Text file logger")]
        TextFile,
        [Description("Mixed logger")]
        Mixed
    }
}
