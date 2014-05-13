using ConsoleApplication1.Interfaces;

namespace ConsoleApplication1.Loggers
{
    class WrapMyLogger:IWrapLogger
    {
        MyLogger log = new MyLogger();

        public void Error(string message0)
        {
            log.Error(message0);
        }
    }
}
