using ConsoleApplication1.AppData;

namespace ConsoleApplication1.Command
{
    public class HelpCommand : ICommand
    {
        public void DoJob()
        {
            AppInfo.Introduce();
        }
    }
}
