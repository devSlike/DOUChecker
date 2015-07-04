using DOUChecker.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOUChecker.CheckMethods
{
    public interface ICheckMethod
    {
        void Check(String url, ILogger logger);
    }
}