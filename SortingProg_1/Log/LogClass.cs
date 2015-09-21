using System;
using log4net;
using log4net.Config;

namespace SortingProg_1
{
    class LogClass
    {
        LogClass()
        {
            log4net.Config.XmlConfigurator.Configure();
            LogClass.log.Info("Logger is created and configurated");
        }
        public static readonly ILog log = LogManager.GetLogger(typeof(MainProgram));
    }
}
//LogClass.log.Debug("thishe first log message");