using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_MVC
{
    public class Controller
    {
        #region Singltone
        private static Controller instance;
        private Controller() { }
        public static Controller Instance()
        {
            if (instance == null)
            {
                LogClass.log.Info("Controller is created");
                instance = new Controller();
            }
            else { /*-*/}
            return instance;
        }
        #endregion

        private bool subscribeLock = false;

        public void Input_MethodChoose(int methodIndex)
        {
            LogClass.log.Info("Input_Method Choose  in controller begun");

            List<List<float>> array = new List<List<float>>(0);
            switch (methodIndex)
            {
                case 1:
                    array = SubControllerFunc.Input_FromConsole();
                    break;

                case 2:
                    array = SubControllerFunc.Input_FromFile(@"E:\Projects\Sorting_MVC\TestFile.txt");
                    break;

                case 3:
                    array = SubControllerFunc.Input_FromRandom();
                    break;

                case 0:
                    Environment.Exit(0);
                    break;

                default:
                    
                    ViewFailFunc.InputMethodChoosed_Failed();
                    break;
            }

            Model model = Model.Instance();
            // !V
            if (!subscribeLock)
            {
                View view = View.Instance();
                model.outputArrayEvent += view.OutputArrayToConsl;
                model.pushDone += view.SortingMethodChoose;
                subscribeLock = true;
            }

            model.PushArrayToModel(array);
        }

        public void SortMethodChoose(List<int> sortIndexs)
        {
            LogClass.log.Info(" Sort Method Choose in controller begun");

            List<ABaseSortClass> sortList = new List<ABaseSortClass>();//interface
            View view = View.Instance();

            if(sortIndexs[0]==0)
                Environment.Exit(0);
            if (sortIndexs[0] == 4)
                view.InputMethodChoose();
            foreach (int index in sortIndexs)
            {
                switch (index)
                {
                    case 1:
                        BubbleSort bubbleSort = new BubbleSort();
                        sortList.Add(bubbleSort);
                        break;
                    case 2:
                        ChooseSort chooseSort = new ChooseSort();
                        sortList.Add(chooseSort);
                        break;
                    case 3:
                        ShellSort shellSort = new ShellSort();
                        sortList.Add(shellSort);
                        break;
                    case 4:
                        StandartSort standartSort = new StandartSort();
                        sortList.Add(standartSort);
                        break;
                }
            }

            Model model = Model.Instance();
            model.StartSortingMethods(sortList);
            // !~
            view.SortIsDone();
        }
    }
}
