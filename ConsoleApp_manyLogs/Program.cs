using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace ConsoleApp_manyLogs
{
    class Program
    {
        /// <summary>
        /// New instance for log
        /// </summary>
        private static readonly ILog logA = LogManager.GetLogger(Assembly.GetExecutingAssembly(), "Logger_Sample_A");
        private static readonly ILog logB = LogManager.GetLogger(Assembly.GetExecutingAssembly(), "Logger_Sample_B");

        static void Main(string[] args)
        {
            new BaseLog4NetXmlConfigurator();

            logA.Debug("desenvolvimento");
            logA.Warn("atenção!");
            logA.Info("informção");
            logA.Error("problema!");
            logA.Fatal("vixee");

            logB.Debug("desenvolvimento");
            logB.Warn("atenção!");
            logB.Info("informção");
            logB.Error("problema!");
            logB.Fatal("vixee");
        }
    }
}
