using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Interfaces;
using NLog;

namespace ConsoleApplication1.Loggers
{
    class WrapNLog:IWrapLogger
    {
        private Logger log = LogManager.GetCurrentClassLogger();

        public void Error(string message0)
        {
            log.Error(message0);
        }
    }
}
