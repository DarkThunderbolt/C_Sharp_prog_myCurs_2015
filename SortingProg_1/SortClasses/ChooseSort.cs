using System;
using System.Collections.Generic;
using SortingProg_1;

namespace SortingProg_1
{
    class ChooseSort : aBaseSortClass, Interface.ISort //Сортировка выбором
    {
        public delegate void DelegateHendler();
        public event DelegateHendler onOutEvent;

        public ChooseSort(List<List<float>> newArray) : base(newArray)
        { }

        public void sorting(List<List<float>> sortArray)
        {
            //Console.WriteLine("!!!choose sorting is began");
            //sWatch.Start();
            LogClass.log.Info(" choose sorting is began");

            sort();

            //sWatch.Stop();
            //Console.WriteLine("timer: {0} mls", sWatch.ElapsedMilliseconds.ToString());
            //Console.WriteLine("!!!choose sorting is end");

            //event который говорит что он завершил сортировку и выводит
            onOutEvent();
        }

        protected override void sortingMethod()
        {
            int min;
            int length = tempArray.Count;

            for (int i = 0; i < length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < length; j++)
                {
                    if (tempArray[j] < tempArray[min])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    swap(i, min);
                }
            }
        }
    }
}
