using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using log4net;

namespace Sort_MVC
{
    public abstract class ABaseSortClass : ISorting
    {
        //end sorting event
        public delegate void DelegateHendler(List<List<float>> something);
        public event DelegateHendler sortingIsDoneEvent;

        // 1D-converted array 
        protected List<float> tempArray = new List<float>();
        // number of rows
        private int rowsCounter = 0;

        protected abstract void SortingMethod();
        protected abstract string GetSortName();

        protected void Swap(int a, int b)
        {
            float temp = tempArray[a];
            tempArray[a] = tempArray[b];
            tempArray[b] = temp;
        }

        private void Change2DTo1D(List<List<float>> sortin2DArray)
        {
            foreach (List<float> arrayRow in sortin2DArray)
            {
                foreach (float arrayItem in arrayRow)
                {
                    tempArray.Add(arrayItem);
                }
                rowsCounter += 1;
            }
        }

        private List<List<float>> Change1DTo2D()
        {
            List<List<float>> outputArray = new List<List<float>>(0);
            int colCount = tempArray.Count / rowsCounter;

            int j = 0;
            while (true)
            {
                List<float> subArray = new List<float>(0);
                for (int i = 0; i < colCount; i++)
                {
                    subArray.Add(tempArray[j]);
                    j++;
                }
                outputArray.Add(subArray);
                if (j == tempArray.Count)
                    break;
            }

            return outputArray;
        }
        
        public void Sorting(List<List<float>> newArray)
        {
            Thread.CurrentThread.Name = this.GetSortName();
            
            Change2DTo1D(newArray);
            SortingMethod();

            sortingIsDoneEvent( Change1DTo2D() ) ;
        }
    }
}
