using DOUChecker.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DOUChecker.CheckMethods
{
    public class WebRequestCheckMethod : ICheckMethod
    {
        public void Check(String url, ILogger logger)
        {
            var request = HttpWebRequest.Create(url);
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    if (response != null || response.StatusCode == HttpStatusCode.OK)
                        logger.LogMessage("Available");
                    else
                        logger.LogMessage("NotAvailable");
                }
            }
            catch
            {
                logger.LogMessage("Web request error");
            }
        }
    }
}
