using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Interfaces;
using log4net;

namespace ConsoleApplication1.Loggers
{
    class WrapLog4Net:IWrapLogger
    {
        ILog log = LogManager.GetLogger(typeof(WrapLog4Net));

        public void Error(string message0)
        {
            //настраиваем логер
            log4net.Config.DOMConfigurator.Configure();

            //пишем
            log.Error(message0);
        }
    }
}
