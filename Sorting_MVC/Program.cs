using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_MVC
{
    class Program
    {
        static void Main(string[] args)
        {
            LogClass.log.Debug("Start of programm");
            View view =View.Instance();
            view.InputMethodChoose();
        }
    }
}
