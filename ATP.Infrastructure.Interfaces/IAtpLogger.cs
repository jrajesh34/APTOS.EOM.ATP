using System;
using System.Collections.Generic;
using System.Text;

namespace ATP.Infrastructure.Interfaces
{
    public interface IAtpLogger
    {
        void LogDebug(string format, params object[] args);
        void LogInformation(string format, params object[] args);
        void LogWarning(string format, params object[] args);
        void LogError(string format, params object[] args);
        void LogError(string message, Exception ex);
        void LogError(Exception ex, string format, params object[] args);
    }
}
