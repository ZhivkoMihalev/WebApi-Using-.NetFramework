using System;

namespace PariplayCars.Data.Logs.NLog
{
    public interface ILogger
    {
        void WriteException(Exception ex);
    }
}