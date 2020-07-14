using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Windows.Forms;

namespace WMI_Test
{
    class RSMDriverManagement
    {
        public ManagementScope mgmtScope;
        public ManagementObjectSearcher objSearcher = null;
        public ManagementClass mgmtClass;

    }

    class ScannerPNPEventHandler
    {
        private DriverWMITestApp mainFrm;
        public ScannerPNPEventHandler(ref DriverWMITestApp frm)
        {
            mainFrm = frm;
        }

        public void EventArrived(object sender, EventArrivedEventArgs e)
        {
            DriverWMITestApp.scannerPNPEventArg = e;
            mainFrm.BeginInvoke(new MethodInvoker(mainFrm.UpdateOnScannerPNPEvent));
        }

        public void StoppedEvent(object sender, StoppedEventArgs e)
        {

        }
    }
}
