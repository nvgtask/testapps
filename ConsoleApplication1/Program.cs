using log4net.Config;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            var appLogic = new AppLogic();
            appLogic.ExecuteTask(args);
        }
    }
}
