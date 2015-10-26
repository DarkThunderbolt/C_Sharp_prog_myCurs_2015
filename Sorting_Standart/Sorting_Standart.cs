using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_MVC
{
    public class StandartSort : ABaseSortClass/*, Interface.ISort*/
    {
        protected override string GetSortName()
        {
            return "standart sorting";
        }
        protected override void SortingMethod()
        {
            tempArray.Sort();
        }

    }
}
