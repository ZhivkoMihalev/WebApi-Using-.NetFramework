using NLog;
using System;

namespace PariplayCars.Data.Logs.NLog
{
    public class NLogLogger : ILogger
    {
        private static Logger _logger = LogManager.GetLogger("PariplayCarsLogger");

        public void WriteException(Exception ex)
        {
            _logger.Error(ex);
        }
    }
}