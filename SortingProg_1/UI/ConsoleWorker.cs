using System;
using System.Collections.Generic;
using System.IO;


namespace SortingProg_1
{
    class ConsoleWorker
    {
        public List<List<float>> inputMethodChoose(List<List<float>> inputArray)
        {
            LogClass.log.Info(" inputMethodChoose method is began");

            Console.WriteLine("  Choose array input method :");
            Console.WriteLine("  1 for handwrite iput");
            Console.WriteLine("  2 for imput from file");
            Console.WriteLine("  3 for random array ");
            Console.WriteLine("  0 for exit");

            int methodIndex = findKey();

            switch (methodIndex)
            {
                case 1:
                    inputArray = inputFromConsole();
                    break;
                case 2:
                    inputArray = inputFromFile(@"E:\Projects\SortingProg_2\TestFile.txt");
                    break;
                case 3:
                    inputArray = inputFromRandom();
                    break;
                case 0:
                    LogClass.log.Info(" exit");
                    Environment.Exit(0);
                    break;
                default:
                    LogClass.log.Info(" wrong input method number");
                    Console.WriteLine("   Something is wrong.Try again");
                    inputMethodChoose(inputArray);
                    break;
            }
            outputArrayToConsl(inputArray);
            return inputArray;
        }

        public List<List<float>> sortingMethodChoose(List<List<float>> inputArray)
        {
            LogClass.log.Info(" inputMethodChoose method is began");

            List<List<float>> outputArray = new List<List<float>>();

            Console.WriteLine("  Choose method of sorting");
            Console.WriteLine("  1 for Bubble sorting");
            Console.WriteLine("  2 for Choose sorting");
            Console.WriteLine("  3 for Shell sorting");
            Console.WriteLine("  4 for Standart sorting");
            Console.WriteLine("  0 for exit");

            int sortIndex = findKey();
            Console.WriteLine("   New array = ");
            switch (sortIndex)
            {
                case 1:
                    BubbleSort sort1 = new BubbleSort(inputArray);
                    sort1.onOutEvent += sort1.outputArrayToConsl;
                    sort1.sorting(inputArray);
                    break;

                case 2:
                    ChooseSort sort2 = new ChooseSort(inputArray);
                    sort2.onOutEvent += sort2.outputArrayToConsl;
                    sort2.sorting(inputArray);
                    break;

                case 3:
                    ShellSort sort3 = new ShellSort(inputArray);
                    sort3.onOutEvent += sort3.outputArrayToConsl;
                    sort3.sorting(inputArray);
                    break;

                case 4:
                    StandartSort sort4 = new StandartSort(inputArray);
                    sort4.onOutEvent += sort4.outputArrayToConsl;
                    sort4.sorting(inputArray);
                    break;

                case 0:
                    LogClass.log.Info((" exit"));
                    Environment.Exit(0);
                    break;

                default:
                    LogClass.log.Info((" wrong sorting method number"));
                    Console.WriteLine("   Something is wrong.Try again");
                    sortingMethodChoose(inputArray);
                    break;
            }

            Console.ReadKey();
            Console.Clear();

            return outputArray;
        }
        
        private List<List<float>> inputFromConsole()
        {
            LogClass.log.Info((" input from consol is began"));

            int rowCount = 0;
            int colCount = 0;

            Console.WriteLine("   Pls input number of rows in your array  =  ");
            rowCount = findArraySize();

            Console.WriteLine("   Pls input number of columns in your array  =  ");
            colCount = findArraySize();

            List<string> inputArrayOfStrings = new List<string>(0);

            for (int i = 0; i < rowCount; i++)
            {
                string tempString = Console.ReadLine();
                if (String.IsNullOrEmpty(tempString))
                {
                    LogClass.log.Info(" string is empty");

                    Console.WriteLine("   String is empty.Try again");
                    Console.ReadKey();
                    i--;
                }
                else
                {
                    string[] tempArrayOfString = tempString.Split(' ');
                    if (tempArrayOfString.Length != colCount)
                    {
                        LogClass.log.Info((" wrong number of colums"));

                        Console.WriteLine("   Wrong number of colums.Try again");
                        Console.ReadKey();
                        i--;
                    }
                    else
                    {
                        inputArrayOfStrings.Add(tempString);
                    }
                }
            }

            return findNumFromArrStr(inputArrayOfStrings);
        }

        private List<List<float>> inputFromFile(string path)
        {
            LogClass.log.Info((" iput from file is began"));

            List<List<float>> inputArray = new List<List<float>>(0);
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
            catch (Exception e)
            {

                LogClass.log.Debug(($"The file could not be read: {e}"));
                Console.WriteLine("   Something is wrong.Press ENTER and try againn");
                Console.ReadKey();
                inputMethodChoose(inputArray);
            }

            inputArray = findNumFromArrStr(inputArrayOfStrings);
            Console.WriteLine("   Array from file:");
            //outputArrayToConsl(inputArray);
            Console.WriteLine();

            return inputArray;
        }

        private List<List<float>> inputFromRandom()
        {
            LogClass.log.Info((" iput from random numbers is began"));

            int rowCount = 0;
            int colCount = 0;

            Console.WriteLine("   Pls input number of rows in your array");
            rowCount = findArraySize();

            Console.WriteLine("   Pls input number of columns in your array");
            colCount = findArraySize();

            List<List<float>> arrayRandom = SubFunctions.RandomNumber(colCount, rowCount);

            return arrayRandom;
        }

        private List<List<float>> findNumFromArrStr(List<string> arrayOfString)
        {
            LogClass.log.Info((" finding number from inputed string"));

            List<List<float>> outputArray = new List<List<float>>(0);
            foreach (string tempString in arrayOfString)
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
                catch (Exception e)
                {
                    LogClass.log.Debug($"error in converting: {e}");

                    Console.WriteLine("   Something is wrong.Press ENTER and try again");
                    Console.ReadKey();
                }
                outputArray.Add(findingArray);
            }

            return outputArray;
        }

        private int findArraySize()
        {
            LogClass.log.Info(" finding array size");

            int size = 0;
            try
            {
                size = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                LogClass.log.Debug($"error in converting: {e}");

                Console.WriteLine("   Something is wrong.Press ENTER and try again");
                Console.ReadKey();
                size = findArraySize();
            }
            if (size <= 0)
            {
                LogClass.log.Debug(" entered zero size");

                Console.WriteLine("   Enter not zero size!");
                size = findArraySize();
            }
            return size;
        }

        private int findKey()
        {
            LogClass.log.Info(" finding key is began");

            int index = 0;
            string temp = Console.ReadLine();
            if (int.TryParse(temp, out index))
            {
                return index;
            }
            else
            {
                LogClass.log.Debug(" error in converting key");
                Console.WriteLine("   Something is wrong.Try again");
                index = findKey();
            }
            return index;
        }

        public static void outputArrayToConsl(List<List<float>> sortin2Darray)
        {
            foreach (List<float> lists in sortin2Darray)
            {
                foreach (float item in lists)
                {
                    Console.Write(" {0} ", item);
                }
                Console.WriteLine();
            }
        }
    }
}
