using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Sort_MVC
{
    class SubControllerFunc
    {
        // !~
        public static List<List<float>> Input_FromConsole()
        {
            LogClass.log.Info("Input_FromConsole begun");

            Tuple<int, int> arrayDemention = SubViewFunc.InputArrayDemention();

            List<string> inputArrayOfStrings = SubViewFunc.InputFromConsole(arrayDemention.Item1);

            foreach (string tempString in inputArrayOfStrings)
            {
                if (String.IsNullOrEmpty(tempString))
                {
                    ViewFailFunc.InputFronConsol_Failed(true);
                }
                else
                {
                    string[] tempArrayOfString = tempString.Split(' ');
                    if (tempArrayOfString.Length != arrayDemention.Item2)
                    {
                        ViewFailFunc.InputFronConsol_Failed(false);
                    }
                }
            }

            List<List<float>> inputArray = new List<List<float>>(0);
            foreach (string tempString in inputArrayOfStrings)
            {
                List<float> findingArray = new List<float>();

                string[] str = tempString.Split(' ');
                float tempFloat;
                try
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (float.TryParse(str[i], out tempFloat))
                        {
                            findingArray.Add(tempFloat);
                        }
                    }
                }
                catch (Exception)
                {
                    ViewFailFunc.InputFronConsolConvert_Failed();
                }
                inputArray.Add(findingArray);
            }

            return inputArray;

        }

        public static List<List<float>> Input_FromRandom()
        {
            LogClass.log.Info("Input_FromRandom begun");

            Tuple<int, int> arrayDemention = SubViewFunc.InputArrayDemention();

            List<List<float>> array = new List<List<float>>(0);
            Random rand = new Random();

            for (int j = 0; j < arrayDemention.Item1; j++)
            {
                List<float> subArr = new List<float>();
                for (int i = 0; i < arrayDemention.Item2; i++)
                {
                    subArr.Add(rand.Next(0, 100));
                }
                array.Add(subArr);
            }
            return array;
        }

        public static List<List<float>> Input_FromFile(string path)
        {
            LogClass.log.Info("Input_FromFile begun");

            List<string> inputArrayOfStrings = new List<string>(0);
            try
            {
                StreamReader sr = new StreamReader(path);
                string tempString = sr.ReadLine();
                string[] str = tempString.Split(' ');
                int row = 0, col = 0;
                int.TryParse(str[0], out row);
                int.TryParse(str[0], out col);
                int i = 0;
                while (i < row)
                {
                    tempString = sr.ReadLine();
                    inputArrayOfStrings.Add(tempString);
                    i++;
                }
            }
            catch (Exception)
            {
                ViewFailFunc.InputFromFile_Failed();
            }

            List<List<float>> inputArray = new List<List<float>>(0);
            foreach (string tempString in inputArrayOfStrings)
            {
                List<float> findingArray = new List<float>();

                string[] str = tempString.Split(' ');
                float tempFloat;
                try
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (float.TryParse(str[i], out tempFloat))
                        {
                            findingArray.Add(tempFloat);
                        }
                    }
                }
                catch (Exception)
                {
                    ViewFailFunc.InputFromFile_Failed();
                }
                inputArray.Add(findingArray);
            }
            return inputArray;
        }

    }
}
