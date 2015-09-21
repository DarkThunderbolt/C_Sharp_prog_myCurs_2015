using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace SortingProg_1
{
    class ThreadWorker
    {
        public static void theadExempl(List<List<float>> inputArray)
        {
            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();

            BubbleSort sort1 = new BubbleSort(inputArray);
            sort1.onOutEvent += sort1.outputArrayToConsl;
            Thread sThreat1 = new Thread(() => sort1.sorting(inputArray));
            sThreat1.Name = "thread1";


            List<List<float>> tempInputArray2 = new List<List<float>>(0);
            tempInputArray2.Add(new List<float> {25,6,33,2 });

            ChooseSort sort2 = new ChooseSort(tempInputArray2);
            sort2.onOutEvent += sort2.outputArrayToConsl;
            Thread sThreat2 = new Thread(() => sort2.sorting(tempInputArray2));
            sThreat2.Name = "thread2";

            List<List<float>> tempInputArray3 = new List<List<float>>(0);
            tempInputArray3.Add(new List<float> { 15, 26, 3, 2 });

            ShellSort sort3 = new ShellSort(tempInputArray3);
            sort3.onOutEvent += sort3.outputArrayToConsl;
            Thread sThreat3 = new Thread(() => sort3.sorting(tempInputArray3));
            sThreat3.Name = "thread3";

            
            List<List<float>> tempInputArray4 = new List<List<float>>(0);
            tempInputArray4.Add(new List<float> { 5, 0, 8, 2 });
            
            StandartSort sort4 = new StandartSort(tempInputArray4);
            sort4.onOutEvent += sort4.outputArrayToConsl;
            Thread sThreat4 = new Thread(() => sort4.sorting(tempInputArray4));
            sThreat4.Name = "thread4";

            sThreat1.Start();
            sThreat2.Start();
            sThreat3.Start();
            sThreat4.Start();

            sThreat1.Join();
            sThreat2.Join();
            sThreat3.Join();
            sThreat4.Join();

            sWatch.Stop();
            Console.WriteLine("Alltimer: {0} mls", sWatch.ElapsedMilliseconds.ToString());

        }
    }
}
