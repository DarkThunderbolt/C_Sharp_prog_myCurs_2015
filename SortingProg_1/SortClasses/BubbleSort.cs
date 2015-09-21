using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SortingProg_1
{
    class BubbleSort : aBaseSortClass, Interface.ISort    //Пузырьковая сортировка
    {
        public delegate void DelegateHendler();
        public event DelegateHendler onOutEvent;

        public BubbleSort(List<List<float>> newArray) : base(newArray)
        { }

        public void sorting(List<List<float>> sortArray)
        {
            //Console.WriteLine("!!!bubble sorting is began");
            //sWatch.Start();
            LogClass.log.Info(" bubble sorting is began");

            sort();

            //sWatch.Stop();
            //Console.WriteLine("timer: {0} mls", sWatch.ElapsedMilliseconds.ToString());
            //Console.WriteLine("!!!bubble sorting is end");

            //event который говорит что он завершил сортировку и выводит
            onOutEvent();
        }

        protected override void sortingMethod()
        {
            for (int i = 0; i < tempArray.Count; i++)
            {
                for (int j = i + 1; j < tempArray.Count; j++)
                {
                    if (tempArray[j] < tempArray[i])
                    {
                        swap(i, j);
                    }
                }
            }
        }
    }
}
