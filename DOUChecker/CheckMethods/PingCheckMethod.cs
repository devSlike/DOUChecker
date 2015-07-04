using DOUChecker.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace DOUChecker.CheckMethods
{
    public class PingCheckMethod : ICheckMethod
    {
        public void Check(string url, ILogger logger)
        {
            using (var ping = new Ping())
            {
                PingReply pingReply = null;
                try
                {
                    pingReply = ping.Send(url);
                }
                catch (PingException ex)
                {
                    logger.LogMessage(String.Format("Ping error: {0}", ex.Message));
                    return;
                }
                var result = String.Empty;
                switch (pingReply.Status)
                {
                    case IPStatus.Success:
                        result = "Available";
                        break;
                    case IPStatus.TimedOut:
                        result = "NotAvailable";
                        break;
                    default:
                        result = String.Format("Ping failed: {0}", pingReply.Status.ToString());
                        break;
                }
                logger.LogMessage(result);
            }
        }
    }
}