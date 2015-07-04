using DOUChecker.CheckMethods;
using DOUChecker.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOUChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            IocInit();
            var checker = new Checker();
            checker.Check();
        }

        static void IocInit()
        {
            var loggerType = LoggersTypeEnum.Mixed;
            var checkMethodType = CheckMethodTypeEnum.WebRequest;

            Ioc.Init((kernel) =>
            {
                switch (loggerType)
                {
                    case LoggersTypeEnum.Console: kernel.Bind<ILogger>().To<ConsoleLogger>().InSingletonScope(); break;
                    case LoggersTypeEnum.TextFile: kernel.Bind<ILogger>().To<TextFileLogger>().InSingletonScope(); break;
                    case LoggersTypeEnum.Mixed: kernel.Bind<ILogger>().To<MixedLogger>().InSingletonScope(); break;
                }
                switch (checkMethodType)
                {
                    case CheckMethodTypeEnum.Ping: kernel.Bind<ICheckMethod>().To<PingCheckMethod>().InTransientScope(); break;
                    case CheckMethodTypeEnum.WebRequest: kernel.Bind<ICheckMethod>().To<WebRequestCheckMethod>().InTransientScope(); break;
                }
            });
        }
    }
}