using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_MVC
{
    class SubViewFunc//interf
    {
        public static List<string> InputFromConsole(int rows)
        {
            LogClass.log.Info("Input From Console begun");

            List<string> inputArrayOfStrings = new List<string>(0);

            for (int i = 0; i < rows; i++)
            {
                string tempString = Console.ReadLine();
                inputArrayOfStrings.Add(tempString);
            }

            return inputArrayOfStrings;
        }

        public static Tuple<int, int> InputArrayDemention()
        {
            LogClass.log.Info("Input Array Demention begun");

            int rowCount = 0;
            int colCount = 0;

            Console.WriteLine("   Pls input number of rows in your array. Num mast be above zero");
            rowCount = SubViewFunc.FindArraySize();

            Console.WriteLine("   Pls input number of columns in your array. Num mast be above zero");
            colCount = SubViewFunc.FindArraySize();

            Tuple<int, int> arrayDemention = new Tuple<int, int>(rowCount, colCount);

            Console.WriteLine("   Your array [{0} x {1}]", arrayDemention.Item1, arrayDemention.Item2);

            return arrayDemention;
        }

        public static int FindKey()
        {
            LogClass.log.Info(" Find Key begun");
            int index = -1;
            string temp = Console.ReadLine();
            if (int.TryParse(temp, out index))
            {
                return index;
            }
            else
            {
                Console.WriteLine("   Something is wrong.Try again");
                index = FindKey();
            }
            return index;
        }
        // !~ maybe in 1 func whith FinkKey
        public static int FindArraySize()
        {
            LogClass.log.Info("Find Array Size begun");
            int size = 0;
            string temp = Console.ReadLine();

            if (int.TryParse(temp, out size) && size > 0)
            {
                return size;
            }
            else
            {
                Console.WriteLine("   Wrong simbol or not above zerp.Try again");
                size = FindArraySize();
            }
            return size;
        }

        public static List<int> FindStringOfNumbers()
        {
            LogClass.log.Info("Find String Of Numbers begun");
            View view = View.Instance();

            string tempString = Console.ReadLine();
            if (String.IsNullOrEmpty(tempString))
            {
                ViewFailFunc.SortingMethodChoose_Failed();
            }

            string[] tempArrayOfString = tempString.Split(' ');
            List<int> array = new List<int>(0);
            int tempFloat;
           
            for (int i = 0; i < tempArrayOfString.Length; i++)
            {
                if (Int32.TryParse(tempArrayOfString[i], out tempFloat))
                {
                    array.Add(tempFloat);
                }
                else
                {
                    ViewFailFunc.SortingMethodChoose_Failed();
                }
            }
            return array;
        }
    }
}
