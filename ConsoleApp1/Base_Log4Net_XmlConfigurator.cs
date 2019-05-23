using log4net;
using log4net.Config;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace ConsoleApp1
{
    public class BaseLog4NetXmlConfigurator
    {
        [assembly: log4net.Config.XmlConfigurator(ConfigFileExtension = "log4net", Watch = true)]
        public BaseLog4NetXmlConfigurator()
        {
            //-> Para adicionar o arquivo de config ao assembly compilado:
            //  Open SolutionExplorer -> ... -> log4net.config -> (RightButton) Properties -> BuildAction = "Embedded resource"
            // Now you find the config in your assembly file
            string log4netAssemblyName = Assembly
                .GetExecutingAssembly()
                .GetManifestResourceNames()
                .FirstOrDefault(name => name.Contains("log4net"));

            Stream log4netStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(log4netAssemblyName);

            XmlDocument log4netConfig = new XmlDocument();

            log4netConfig.Load(log4netStream);

            var repo = LogManager.CreateRepository(
                Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

            System.Console.WriteLine(repo.Name);

            XmlConfigurator.Configure(repo, log4netConfig["log4net"]);//tag no xml! <log4net>...</tag4net>
        }
    }
}
