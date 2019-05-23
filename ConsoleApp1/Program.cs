using log4net;
using System;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        private static readonly ILog logA = LogManager.GetLogger(Assembly.GetExecutingAssembly(), "Logger_Sample_A");

        static void Main(string[] args)
        {
            new BaseLog4NetXmlConfigurator();

            log.Debug("Padrão");
            logA.Debug("especifico");
        }
    }
}
