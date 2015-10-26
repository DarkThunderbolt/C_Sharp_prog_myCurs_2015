using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_MVC
{
    public class ShellSort : ABaseSortClass /*, Interface.ISort*/    //Сортировка Шелла
    {
        protected override string GetSortName()
        {
            return "shell sorting";
        }
        protected override void SortingMethod()
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
                        Swap(k, k + step);
                        k -= step;
                    }
                }
                step = step / 2;
            }
        }
    }
}
