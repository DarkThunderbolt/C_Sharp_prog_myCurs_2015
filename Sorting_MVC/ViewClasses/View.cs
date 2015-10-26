using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sort_MVC
{
    public class View
    {
        #region Singltone
        private static View instance;
        private View() { }
        public static View Instance()
        {
            if (instance == null)
            {
                LogClass.log.Info("Viev is created");
                instance = new View();
            }
            return instance;
        }
        #endregion

        Controller controller = Controller.Instance();

        public void InputMethodChoose()
        {
            LogClass.log.Info("Input Method Choose began");

            Console.Clear();
            Console.WriteLine("  Choose array input method :");
            Console.WriteLine("  1 for handwrite input");
            Console.WriteLine("  2 for input from file");
            Console.WriteLine("  3 for random array");
            Console.WriteLine("  0 for exit");
            Console.WriteLine("  You must input one of the number and than press ENTER");

            int methodIndex = SubViewFunc.FindKey();

            controller.Input_MethodChoose(methodIndex);
        }

        public void SortingMethodChoose() //viev sort method
        {
            LogClass.log.Info("Sorting Method Choose began");

            Console.WriteLine("  Array input is done. Press any keys to continue");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("  Choose method of sorting");
            Console.WriteLine("  1 for Bubble sorting");
            Console.WriteLine("  2 for Choose sorting");
            Console.WriteLine("  3 for Shell sorting");
            Console.WriteLine("  4 for Standart sorting");
            Console.WriteLine("  5 for inpur array again");
            Console.WriteLine("  0 for exit");
            Console.WriteLine("  You must input one or more of the number and than press ENTER");
            Console.WriteLine("  PS: if you enterd 0 or 5 not in first plase it will be ignored");

            List<int> sortIndex = SubViewFunc.FindStringOfNumbers();

            controller.SortMethodChoose(sortIndex);
        }

        public void OutputArrayToConsl(List<List<float>> sortin2Darray)
        {
            LogClass.log.Info("Output Array To Consl began");

            Console.WriteLine("  This is {0} array:", Thread.CurrentThread.Name);
            foreach (List<float> lists in sortin2Darray)
            {
                foreach (float item in lists)
                {
                    Console.Write(" {0} ", item);
                }
                Console.WriteLine();
            }
        }

        public void SortIsDone()
        {
            LogClass.log.Info("Sort Is Done");

            Console.WriteLine("   Sorting is end!Press ENTER to continue");
            Console.ReadKey();
            InputMethodChoose();
        }
    }
}