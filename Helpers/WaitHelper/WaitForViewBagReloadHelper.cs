using System;
using System.Threading;

namespace PropertyInspection_WebApp.Helpers.WaitHelper
{
    public class WaitForViewBagReloadHelper
    {
        /// <summary>
        /// Causes a wait of 2000ms on the calling method.
        /// </summary>
        public static void ExecuteWait()
        {
            Thread.Sleep(2000);
        }
    }
}

