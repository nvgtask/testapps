using ConsoleApplication1.AppData;
using ConsoleApplication1.Task;

namespace ConsoleApplication1
{
    public class AppLogic
    {
        public void ExecuteTask(string[] args)
        {
             var filePath = @"C:\nvgtask\testapps\ConsoleApplication1\Testdata\is24_iis.log";
            //TODO: Add applogic here
            AppInfo.Introduce();
            ITaskHandler handler = new ExamHandler(filePath);
            handler.Listener();
        }
    }
}
