using System;
using System.Collections.Generic;
using System.Threading;

namespace SortingProg_1
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            while (true)
            {
                List<List<float>> myArray = new List<List<float>>();

                ConsoleWorker cons = new ConsoleWorker();

                myArray = cons.inputMethodChoose(myArray);

                //ThreadWorker.theadExempl(myArray);

                myArray = cons.sortingMethodChoose(myArray);
            }
        }

    }
}