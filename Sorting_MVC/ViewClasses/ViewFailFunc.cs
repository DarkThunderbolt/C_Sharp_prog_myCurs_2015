using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_MVC
{
    class ViewFailFunc
    {
        static View view = View.Instance();
        public static void InputFronConsol_Failed(bool a)
        {
            LogClass.log.Error("InputFronConsol_Failed begun");
            if (a)
            {
                Console.WriteLine("   One of rows is empty.Press ENTER and try againn");
            }
            if (a)
            {
                Console.WriteLine("   Wrong number of colums.Press ENTER and try again");
            }
            Console.ReadKey();
            view.InputMethodChoose();
        }

        public static void InputFronConsolConvert_Failed()
        {
            LogClass.log.Error("InputFronConsolConvert_Failed begun");

            Console.WriteLine("   Something is wrong. Press ENTER and try againn");
            Console.ReadKey();
            view.InputMethodChoose();
        }

        public static void InputMethodChoosed_Failed()
        {
            LogClass.log.Error("InputMethodChoosed_Failed begun");

            Console.WriteLine("   Something is wrong. Press any key to continue");
            view.InputMethodChoose();
        }

        public static void InputFromFile_Failed()
        {
            LogClass.log.Error("InputFromFile_Failed begun");

            Console.WriteLine("   Something is wrong whith file. Press ENTER and try againn");
            Console.ReadKey();
            view.InputMethodChoose();
        }

        public static void SortingMethodChoose_Failed()
        {
            LogClass.log.Error("SortingMethodChoose_Failed begun");

            Console.WriteLine("   Something is wrong. Press ENTER and try againn");
            Console.ReadKey();
            view.SortingMethodChoose();
        }

    }
}
