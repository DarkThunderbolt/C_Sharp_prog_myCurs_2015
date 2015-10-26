using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_MVC
{
    public class ChooseSort : ABaseSortClass /*, Interface.ISort*/ //Сортировка выбором
    {
        protected override string GetSortName()
        {
            return "choose sorting";
        }
        protected override void SortingMethod()
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
                    Swap(i, min);
                }
            }
        }
    }
}
