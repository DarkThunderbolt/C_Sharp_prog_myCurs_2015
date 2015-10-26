using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sort_MVC
{
    public class BubbleSort : ABaseSortClass /*, Interface.ISort*/    //Пузырьковая сортировка
    {
        protected override string GetSortName()
        {
            return "bubble sorting";
        }

        protected override void SortingMethod()
        {
            for (int i = 0; i < tempArray.Count; i++)
            {
                for (int j = i + 1; j < tempArray.Count; j++)
                {
                    if (tempArray[j] < tempArray[i])
                    {
                        Swap(i, j);
                    }
                }
            }
        }
    }
}
