using System;
using System.Collections.Generic;
using SortingProg_1;
using System.Diagnostics;

namespace SortingProg_1
{
    abstract class aBaseSortClass
    {
        protected List<float> tempArray =new List<float>();
        protected List<List<float>> sortin2Darray = new List<List<float>>();
        protected Stopwatch sWatch = new Stopwatch();
        protected int rowsCounter=0;

        public delegate void outputDelegate(List<List<float>> a);

        public aBaseSortClass(List<List<float>> newArray)
        {
            sortin2Darray = newArray;
        }

        protected abstract void sortingMethod();

        protected void swap(int a, int b)
        {
            float temp = tempArray[a];
            tempArray[a] = tempArray[b];
            tempArray[b] = temp;
        }

        protected void change2DTo1D()
        {
            foreach (List<float> arrayRow in sortin2Darray)
            {
                foreach (float arrayItem in arrayRow)
                {
                    tempArray.Add(arrayItem);
                }
                rowsCounter += 1;
            }
        }

        protected void change1DTo2D()
        {
            sortin2Darray.Clear();
            int colCount = tempArray.Count / rowsCounter;

            int j = 0;
            while(true)
            {
                List<float> subArray = new List<float>(0);
                for (int i = 0; i < colCount; i++)
                {
                    subArray.Add(tempArray[j]);
                    j++;
                }
                sortin2Darray.Add(subArray);
                if (j == tempArray.Count)
                    break;
            }
        }

        public void outputArrayToConsl()
        {
            outputDelegate myDelegate = new outputDelegate(ConsoleWorker.outputArrayToConsl);
            myDelegate(sortin2Darray);
        }

        protected void sort()
        {
            change2DTo1D();
            sortingMethod();
            change1DTo2D();
        }
    }

}
