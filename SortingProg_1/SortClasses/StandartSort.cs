using System;
using System.Collections.Generic;
using SortingProg_1;


namespace SortingProg_1
{
    class StandartSort : aBaseSortClass, Interface.ISort
    {
        public delegate void DelegateHendler();
        public event DelegateHendler onOutEvent;

        public StandartSort(List<List<float>> newArray) : base(newArray)
        { }

        public void sorting(List<List<float>> sortArray)
        {
            //sWatch.Start();
            //Console.WriteLine("!!!standart sorting is began");
            LogClass.log.Info(" standart sorting is began");

            sort();

            //sWatch.Stop();
            //Console.WriteLine("timer: {0} mls", sWatch.ElapsedMilliseconds.ToString());
            //Console.WriteLine("!!!standart sorting is end");

            //event который говорит что он завершил сортировку и выводит
            onOutEvent();
        }

        protected override void sortingMethod()
        {
            tempArray.Sort();
        }
    
    }
}
