using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace ConsoleApp
{
    class Program
    {
        /// <summary>
        /// New instance for log
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            //-> Para adicionar o arquivo de config ao assembly compilado:
            //  Open SolutionExplorer -> ... -> log4net.config -> (RightButton) Properties -> BuildAction = "Embedded resource"
            // Now you find the config in your assembly file
            string log4netAssemblyName = Assembly
                .GetExecutingAssembly()
                .GetManifestResourceNames()
                .FirstOrDefault(name => name.Contains("log4net.config"));

            Stream log4netStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(log4netAssemblyName);

            XmlDocument log4netConfig = new XmlDocument();

            log4netConfig.Load(log4netStream);

            var repo = log4net.LogManager.CreateRepository(
                Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);

            log.Debug("desenvolvimento");
            log.Warn("atenção!");
            log.Info("informção");
            log.Error("problema!");
            log.Fatal("vixee");
        }
    }
}