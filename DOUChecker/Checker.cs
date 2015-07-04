using DOUChecker.CheckMethods;
using DOUChecker.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DOUChecker
{
    public class Checker
    {
        private String _siteUrl = "http://www.dou.ua";
        private Int32 _timeOut = 1000;
        private ICheckMethod _checkMethod;
        private ILogger _logger;

        public Checker()
        {
            _checkMethod = Ioc.Get<ICheckMethod>();
            _logger = Ioc.Get<ILogger>();
        }

        public String SiteUrl
        {
            get { return _siteUrl; }
            set { _siteUrl = value; }
        }

        public Int32 TimeOut
        {
            get { return _timeOut; }
            set { _timeOut = value; }
        }

        public void Check()
        {
            _logger.LogMessage(String.Format("Check site: {0}, timeout: {1} ms", _siteUrl, _timeOut));
            for (; ; )
            {
                _checkMethod.Check(_siteUrl, _logger);
                Thread.Sleep(_timeOut);
            }
        }
    }
}
