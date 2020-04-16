using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WMI_Test
{
    static class Program
    {
        /// <summary>
        /// The main entry poinWMIt for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           Application.EnableVisualStyles();
           Application.SetCompatibleTextRenderingDefault(false);

           DriverWMITestApp.objAppRef = new DriverWMITestApp();
           Application.Run(DriverWMITestApp.objAppRef);
        }
    }
}