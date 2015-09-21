using System;
using System.Collections.Generic;
using SortingProg_1;

namespace SortingProg_1
{
    class ShellSort : aBaseSortClass, Interface.ISort    //Сортировка Шелла
    {
        public delegate void DelegateHendler();
        public event DelegateHendler onOutEvent;

        public ShellSort(List<List<float>> newArray) : base(newArray)
        { }

        public void sorting(List<List<float>> sortArray)
        {
            //Console.WriteLine("!!!shell sorting is began");
            //sWatch.Start();
            LogClass.log.Info(" shell sorting is began");

            sort();

            //sWatch.Stop();
            //Console.WriteLine("timer: {0} mls", sWatch.ElapsedMilliseconds.ToString());
            //Console.WriteLine("!!!shell sorting is end");

            //event который говорит что он завершил сортировку и выводит
            onOutEvent();
        }

        protected override void sortingMethod()
        {
            int k;
            int step = tempArray.Count / 2;
            while (step > 0)
            {
                for (int i = 0; i < (tempArray.Count - step); i++)
                {
                    k = i;
                    while ((k >= 0) && (tempArray[k] > tempArray[k + step]))
                    {
                        swap(k, k + step);
                        k -= step;
                    }
                }
                step = step / 2;
            }
        }
    }
}
