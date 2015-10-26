using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Sort_MVC
{
    public class Model
    {
        #region Singltone
        private static Model instance;
        private Model() { }
        public static Model Instance()
        {
            if (instance == null)
            {
                LogClass.log.Info("Model is created");
                instance = new Model();
            }
            return instance;
        }
        #endregion

        public delegate void Handler(List<List<float>> array);
        public event Handler outputArrayEvent;
        public delegate void Handler2();
        public event Handler2 pushDone;

        // locker
        protected static Object thisLock = new Object();

        private static List<List<float>> inputedArray { get; set; }

        public void PushArrayToModel(List<List<float>> array)
        {
            LogClass.log.Info("Push Array To Model begun");

            inputedArray = array;
            //!v
            IAsyncResult result = outputArrayEvent.BeginInvoke(inputedArray, null, null);
            while (result.IsCompleted == false)
            {
                ;
            }
            pushDone();//fire
        }

        public void StartSortingMethods(List<ABaseSortClass> sortList)
        {
            LogClass.log.Info("Start Sorting Methods begun");

            foreach (ABaseSortClass sort in sortList)
            {
                sort.sortingIsDoneEvent += outputArrtay;
                List<List<float>> tempArray = inputedArray;

                Handler asyncDelegate = new Handler(sort.Sorting);
                asyncDelegate.BeginInvoke(tempArray,null, null);
            }
        }
        //!~
        public void outputArrtay(List<List<float>> array)
        {
            LogClass.log.Info("output Arrtay begun");

            lock (thisLock)
            {
                outputArrayEvent(array);
            }            
        }
    }
}
