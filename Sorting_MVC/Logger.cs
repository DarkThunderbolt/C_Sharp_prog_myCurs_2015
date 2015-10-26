using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;


namespace Sort_MVC


{ 
    class LogClass
    {
        LogClass()
        {
            log4net.Config.XmlConfigurator.Configure();
            LogClass.log.Info("Logger is created and configurated");
        }
        public static readonly ILog log = LogManager.GetLogger(typeof(Program));
    }

}
