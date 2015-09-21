using System;
using System.Collections.Generic;

namespace SortingProg_1
{
    class SubFunctions
    {
        public static List<List<float>> RandomNumber( int col, int row)
        {
            List<List<float>> array = new List<List<float>>(0);
            Random rand = new Random();
            //List<float> subArr = new List<float>();
            for (int j = 0; j < row; j++)
            {
                List<float> subArr = new List<float>();
                for (int i = 0; i < col; i++)
                {
                    subArr.Add(rand.Next(0, 100));
                }
                array.Add(subArr);
                //subArr.Clear(); WTF???
            }
            return array;
        }
    }
}
