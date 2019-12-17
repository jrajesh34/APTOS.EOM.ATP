using ATP.Infrastructure.Interfaces;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ATP.Infrastructure
{
    public class AtpLogger : IAtpLogger
    {
        internal readonly ILog Logger;

        public AtpLogger()
        {
            var assembly = Assembly.GetEntryAssembly();
            Logger = LogManager.GetLogger(assembly, assembly.GetName().Name);
            var logRepository = LogManager.GetRepository(assembly);
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }

        public void LogDebug(string msg, params object[] args)
        {
            Logger.DebugFormat(msg, args);
        }

        public void LogInformation(string msg, params object[] args)
        {
            Logger.InfoFormat(msg, args);
        }

        public void LogWarning(string msg, params object[] args)
        {
            Logger.WarnFormat(msg, args);
        }

        public void LogError(string msg, params object[] args)
        {
            Logger.ErrorFormat(msg, args);
        }

        public void LogError(string message, Exception ex)
        {
            Logger.Error(message + SerializeException(ex));
        }

        public void LogError(Exception ex, string message, params object[] args)
        {
            Logger.ErrorFormat(message + SerializeException(ex), args);
        }

        private static string SerializeException(Exception ex)
        {
            return " -- Exception: " + ex;
        }
    }
}
