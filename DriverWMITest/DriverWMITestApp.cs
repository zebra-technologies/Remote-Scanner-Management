using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Threading;
using System.IO;
using System.Xml;

namespace WMI_Test
{
    public partial class DriverWMITestApp : Form
    {
        private WqlEventQuery wmiEventQuery;
        
        private ManagementEventWatcher mgmtEventWatcher;

        private RSMDriverManagement rsmDriverManagementObject;

        // Scanner host modes
        const String IBMHID = "XUA-45001-1";
        const String HIDKB = "XUA-45001-3";
        const String SNAPI_With_Iamging = "XUA-45001-9";
        const String SNAPI_Without_Imaging = "XUA-45001-10";
        const String IBMTT = "XUA-45001-2";
        const String USB_CDC = "XUA-45001-11";
        const String USB_SSI_CDC = "XUA-45001-14";

        // Event handlers
        private ScannerPNPEventHandler pnpEventHandler;
        public static EventArrivedEventArgs scannerPNPEventArg;
        private ManualResetEvent pollEvent = new ManualResetEvent(false);

        static public DriverWMITestApp objAppRef;
        public String hostAutoSwitchingEnabled = String.Empty;

        public bool bIsDisplay = false;
        public String[] inparams = new String[10];
        internal int iSelectedIndex;
        internal String strSelectedIndexValue;

        public DriverWMITestApp()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// Init Driver WMI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnectWMIDriver_Click(object sender, EventArgs e)
        {
            lblDriverWMIConnectStatus.Text = String.Empty;
         
            ConnectionOptions options = new ConnectionOptions();
            options.Authentication = AuthenticationLevel.Packet;
            options.Impersonation = ImpersonationLevel.Impersonate;
            options.EnablePrivileges = true;

            lstWMIPorpertyList.Items.Clear();
            txtHostIP.Text = txtHostIP.Text.Trim().Equals("") ? "." : txtHostIP.Text.Trim();

            rsmDriverManagementObject = new RSMDriverManagement();
            rsmDriverManagementObject.mgmtScope = new ManagementScope("\\\\" + txtHostIP.Text + "\\root\\CIMV2", options);

            RSMDriverManagement serviceManagementObject = new RSMDriverManagement();
            serviceManagementObject.mgmtScope = new ManagementScope("\\\\" + txtHostIP.Text + "\\root\\CIMV2", options);

            try
            {
                lblDriverWMIConnectStatus.Text = String.Empty;
                rsmDriverManagementObject.mgmtScope.Connect();
                serviceManagementObject.mgmtScope.Connect();
            }
            catch (Exception)
            {
                string errmsg = "Failed to connect\r\n\r\nPossible Reasons:\r\n"
                + "- Host Name or IP Address may be incorrect\r\n"
                + "- Currently logged-on user credentials may not be sufficient\r\n"
                + "- Firewall group policies of remote host may not be configured";
                string errcap = "Connection Error";
                MessageBox.Show(errmsg, errcap, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lblDriverWMIConnectStatus.Text = "Not Connected";
                this.Update();
                Cursor.Current = Cursors.Arrow;
                return;
            }

            try
            {
                serviceManagementObject.objSearcher = new ManagementObjectSearcher(serviceManagementObject.mgmtScope,
                new WqlObjectQuery("SELECT * FROM Win32_Service"));

                foreach (ManagementObject mo in serviceManagementObject.objSearcher.Get())
                {
                    String name = mo["Name"].ToString();
                    String state = mo["State"].ToString();
                    if (name == "rsmdriverproviderservice" && state != "Running")
                    {
                        ManagementBaseObject output = mo.InvokeMethod("StartService",null,null);
                    }
                }
                                
                //Enumerate RSMDriver class 
                //It will return singleton RSMDriver WMI object
                rsmDriverManagementObject.objSearcher = new ManagementObjectSearcher(rsmDriverManagementObject.mgmtScope,
                new WqlObjectQuery("SELECT * FROM RSMDriver"));

                //Update RSMDriver properties
                foreach (ManagementObject mo in rsmDriverManagementObject.objSearcher.Get())
                {
                    String version = mo["version"].ToString();
                    hostAutoSwitchingEnabled = mo["HostAutoSwitchingEnabled"].ToString();
                }
                
                lblDriverWMIConnectStatus.Text = "Connected";
                InitDriverMgmntTabPage();

                if ("TRUE" == hostAutoSwitchingEnabled.ToUpper())
                {
                    chkAutoSwitchHostMode.Checked = true;
                }
 
            }
            catch (Exception)
            {
                lblDriverWMIConnectStatus.Text = "Exception occurred. Please retry";
            }
            Cursor.Current = Cursors.Arrow;

            pnpEventHandler = new ScannerPNPEventHandler(ref objAppRef);

            //Setup to receive ScannerEvent
            wmiEventQuery = new WqlEventQuery("SELECT * FROM ScannerPNPEvent");
            mgmtEventWatcher = new ManagementEventWatcher(wmiEventQuery);
            mgmtEventWatcher.EventArrived += new EventArrivedEventHandler(pnpEventHandler.EventArrived);
            
        }

        /// <summary>
        /// Scanner PNP event data
        /// </summary>
        public void UpdateOnScannerPNPEvent()
        {
            String scannerClass = scannerPNPEventArg.NewEvent.Properties["__CLASS"].Value.ToString();
            //  Scanner Information
            String scannerInfo = scannerPNPEventArg.NewEvent.Properties["ScannerInfo"].Value.ToString();
            //  EventType
            String eventType = scannerPNPEventArg.NewEvent.Properties["EventType"].Value.ToString();

            textBoxEvents.Text += scannerClass;
            textBoxEvents.Text += "-";
            if ("0" == eventType)
            {
                textBoxEvents.Text += "Attached";
            }
            else if ("1" == eventType)
            {
                textBoxEvents.Text += "Detached";
            }
            else
            {
                textBoxEvents.Text += "invalid";
            }
            textBoxEvents.Text += "\r\n";
            
            textBoxManagementDataDW.Text += scannerClass;
            textBoxManagementDataDW.Text += ": ";
            textBoxManagementDataDW.Text += "\r\n"; 
            textBoxManagementDataDW.Text += scannerInfo;
            textBoxManagementDataDW.Text += "\r\n";            
        }

        /// <summary>
        /// Method to find the name and type of RSMDriver method parameters 
        /// </summary>
        private void updateParameterList()
        {
            listBoxDW.Items.Clear();
            ManagementBaseObject inparams = rsmDriverManagementObject.mgmtClass.GetMethodParameters(cmbWMIMethodsList.Text.Trim());

            if (inparams != null)
            {
                foreach (PropertyData propertyData in inparams.Properties)
                {
                    listBoxDW.Items.Add(propertyData.Name + "= a value of type : " + propertyData.Type);
                }
            }

            String strSelectedMethod = String.Empty;
            strSelectedMethod = cmbWMIMethodsList.SelectedItem.ToString();
            if (strSelectedMethod == "GetDeviceTopology")
            {
                HideAllPannels();
            }
            else if (strSelectedMethod == "SwitchHostMode")
            {
                HideAllPannels();
                pnlSwitchHostMode.Visible = true;
                cmbHostMode.SelectedIndex = 0;
                txtSwitchHostScannerID.Enabled = true; ;
            }
            else if (strSelectedMethod == "GetScannerCapabilityProfile")
            {
                HideAllPannels();
                pnlScannerCapability.Visible = true;
            }
            else if (strSelectedMethod == "RebootScanner")
            {
                HideAllPannels();
                pnlReboot.Visible = true;
            }
            else if (strSelectedMethod == "UpdateAttributeMetaFile")
            {
                HideAllPannels();
                pnlAtributeMeta.Visible = true;
            }
            else if (strSelectedMethod == "SwitchCDCDevices")
            {
                HideAllPannels();
                pnlSwitchHostMode.Visible = true;
                txtSwitchHostScannerID.Enabled = false;
                cmbHostMode.SelectedIndex = 2;
            }
            else
            {
                HideAllPannels();
            }
        }
        
        /// <summary>
        /// Query GetDeviceTopology
        /// </summary>
        private void ExecuteGetDeviceTopology()
        {
            try
            {
                ManagementObject mgmtObject = new ManagementObject("root\\CIMV2", "RSMDriver.Version='2.0.0.1'", null);

                // Execute the method and obtain the return values.
                ManagementBaseObject outParams = mgmtObject.InvokeMethod("GetDeviceTopology", null, null);
                
                // List outParams
                textBoxManagementDataDW.AppendText("Out parameters:");
                textBoxManagementDataDW.AppendText("\r\n======================\r\n");
                textBoxManagementDataDW.AppendText("DeviceTopology: \r\n--------------------------------\r\n" + IndentXMLString(outParams["DeviceTopology"].ToString().Replace("\n", "\r\n")));
                textBoxManagementDataDW.AppendText("\r\n\n");
                textBoxManagementDataDW.AppendText("ReturnValue: \r\n----------------------------------\r\n" + outParams["ReturnValue"]);
                textBoxManagementDataDW.AppendText("\r\n");
            }
            catch (ManagementException ex)
            {
                MessageBox.Show(this, "An error occurred while trying to execute the WMI method: " + ex.Message);
            }
        }

        /// <summary>
        /// Generate a formated XMl from a unformated XML
        /// </summary>
        /// <param name="xml">Unformated XML</param>
        /// <returns>Formated XMl</returns>
        private static string IndentXMLString(string xml)
        {
            string outXml = string.Empty;
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.Unicode);
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.LoadXml(xml);
                xmlTextWriter.Formatting = Formatting.Indented;
                xmlDoc.WriteContentTo(xmlTextWriter);
                xmlTextWriter.Flush();

                memoryStream.Seek(0, SeekOrigin.Begin);
                StreamReader sr = new StreamReader(memoryStream);
                return sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return string.Empty;
            }
        }

        /// <summary>
        /// Query SwitchCDCDevices
        /// </summary>
        private void ExecuteSwitcCDCDevices()
        {
            try
            {
                ManagementObject classInstance = new ManagementObject("root\\CIMV2", "RSMDriver.Version='2.0.0.1'", null);

                // Obtain in-parameters for the method
                ManagementBaseObject inParams = classInstance.GetMethodParameters("SwitchCDCDevices");

                inParams["IsPermanentChange"] = chkIsPermanant.Checked;
                inParams["IsSilentSwitch"] = chkIsSilentSwitch.Checked;

                StringBuilder sbSwitchingScanners = new StringBuilder();

                switch (cmbHostMode.SelectedIndex)
                {
                    case 0:
                        inParams["TargetHostMode"] = HIDKB;
                        break;
                    case 1:
                        inParams["TargetHostMode"] = IBMHID;
                        break;
                    case 2:
                        inParams["TargetHostMode"] = SNAPI_With_Iamging;
                        break;
                    case 3:
                        inParams["TargetHostMode"] = SNAPI_Without_Imaging;
                        break;
                    case 4:
                        inParams["TargetHostMode"] = IBMTT;
                        break;
                    case 5:
                        inParams["TargetHostMode"] = USB_CDC;
                        break;
                    case 6:
                        inParams["TargetHostMode"] = USB_SSI_CDC;
                        break;
                }

                // Execute the method and obtain the return values.
                ManagementBaseObject outParams = classInstance.InvokeMethod("SwitchCDCDevices", inParams, null);

                // List outParams
                textBoxManagementDataDW.AppendText("Out parameters:");
                textBoxManagementDataDW.AppendText("\r\n");
                textBoxManagementDataDW.AppendText("ReturnValue: " + outParams["ReturnValue"]);
                textBoxManagementDataDW.AppendText("\r\n");
            }
            catch (ManagementException ex)
            {
                MessageBox.Show(this, "An error occurred while trying to execute the WMI method: " + ex.Message);
            }
        }

        /// <summary>
        /// Query SwitchHostMode
        /// </summary>
        private void ExecuteSwitchHostMode()
        {
            try
            {
                ManagementObject mgmtObject = new ManagementObject("root\\CIMV2", "RSMDriver.Version='2.0.0.1'", null);

                // Obtain in-parameters for the method
                ManagementBaseObject inParams = mgmtObject.GetMethodParameters("SwitchHostMode");

               inParams["IsPermanentChange"] = chkIsPermanant.Checked;
               inParams["IsSilentSwitch"] = chkIsSilentSwitch.Checked;

               StringBuilder sbSwitchingScanners = new StringBuilder();
               sbSwitchingScanners.Append("<scanner><scannerID>");
               sbSwitchingScanners.Append(txtSwitchHostScannerID.Text);
               sbSwitchingScanners.Append("</scannerID></scanner>");

               inParams["ScannerIdentity"] = sbSwitchingScanners.ToString();

               switch(cmbHostMode.SelectedIndex)
               {
                   case 0:
                       inParams["TargetHostMode"] = HIDKB ;
                       break;
                   case 1:
                       inParams["TargetHostMode"] = IBMHID;
                       break;
                   case 2:
                       inParams["TargetHostMode"] = SNAPI_With_Iamging;
                       break;
                   case 3:
                       inParams["TargetHostMode"] = SNAPI_Without_Imaging;
                       break;
                   case 4:
                       inParams["TargetHostMode"] = IBMTT;
                       break;
                   case 5:
                       inParams["TargetHostMode"] = USB_CDC;
                       break;
                   case 6:
                       inParams["TargetHostMode"] = USB_SSI_CDC;
                       break;
                }
                
                // Execute the method and obtain the return values.
                ManagementBaseObject outParams = mgmtObject.InvokeMethod("SwitchHostMode", inParams, null);

                // List outParams
                textBoxManagementDataDW.AppendText("Out parameters:");
                textBoxManagementDataDW.AppendText("\r\n");
                textBoxManagementDataDW.AppendText("ReturnValue: " + outParams["ReturnValue"]);
                textBoxManagementDataDW.AppendText("\r\n");
            }
            catch (ManagementException ex)
            {
                MessageBox.Show(this, "An error occurred while trying to execute the WMI method: " + ex.Message);
            }
        }

        /// <summary>
        /// Query GetScannerCapabilityProfile
        /// </summary>
        private void ExecuteGetScannerCapabilityProfile()
        {
            try
            {
                ManagementObject classInstance = new ManagementObject("root\\CIMV2", "RSMDriver.Version='2.0.0.1'", null);

                // Obtain in-parameters for the method
                ManagementBaseObject inParams = classInstance.GetMethodParameters("GetScannerCapabilityProfile");

                inParams["ScannerIdentity"] = txtGetCapaScannerID.Text;

                // Execute the method and obtain the return values.
                ManagementBaseObject outParams = classInstance.InvokeMethod("GetScannerCapabilityProfile", inParams, null);

                // List outParams
                textBoxManagementDataDW.AppendText("Out parameters[GetScannerCapabilityProfile]:");
                textBoxManagementDataDW.AppendText("CapabilityProfile: " + outParams["CapabilityProfile"]);
                textBoxManagementDataDW.AppendText("ReturnValue: " + outParams["ReturnValue"]);
                textBoxManagementDataDW.AppendText("\r\n");
            }
            catch (ManagementException ex)
            {
                MessageBox.Show(this, "An error occurred while trying to execute the WMI method: " + ex.Message);
            }
        }

        /// <summary>
        /// Query RebootScanner
        /// </summary>
        private void ExecuteRebootScanner()
        {
            try
            {
                ManagementObject mgmtObject = new ManagementObject("root\\CIMV2", "RSMDriver.Version='2.0.0.1'", null);

                // Obtain in-parameters for the method
                ManagementBaseObject inParams = mgmtObject.GetMethodParameters("RebootScanner");
 
                StringBuilder sbRebootScanners = new StringBuilder();
                if (rbIndividual.Checked)
                {
                    sbRebootScanners.Append("<scanner><scannerID>");
                    sbRebootScanners.Append(txtScannerID.Text);
                    sbRebootScanners.Append("</scannerID></scanner>");
                }
                if (rbGroup.Checked)
                {
                    sbRebootScanners.Append("<scanner><group>*</group></scanner>");
                }
                inParams["ScannerIdentity"] = sbRebootScanners.ToString();
 
                // Execute the method and obtain the return values.
                ManagementBaseObject outParams = mgmtObject.InvokeMethod("RebootScanner", inParams, null);

                // List outParams
                textBoxManagementDataDW.AppendText("Out parameters[RebootScanner]:");
                textBoxManagementDataDW.AppendText("ReturnValue: " + outParams["ReturnValue"]);
                textBoxManagementDataDW.AppendText("\r\n");
            }
            catch (ManagementException ex)
            {
                MessageBox.Show(this, "An error occurred while trying to execute the WMI method: " + ex.Message);
            }
        }

        /// <summary>
        /// Query UpdateAttributeMetaFile
        /// </summary>
        private void ExecuteUpdateAttributeMetaFile()
        {
            try
            {
                ManagementObject mgmtObject = new ManagementObject("root\\CIMV2", "RSMDriver.Version='2.0.0.1'", null);

                // Obtain in-parameters for the method
                ManagementBaseObject inParams = mgmtObject.GetMethodParameters("UpdateAttributeMetaFile");
                inParams["AttributeMetaFilePath"] = txtAtribMetaPath.Text;

                ManagementBaseObject outParams = mgmtObject.InvokeMethod("UpdateAttributeMetaFile", inParams, null);

                // List outParams
                textBoxManagementDataDW.AppendText("Out parameters[UpdateAttributeMetaFile]:");
                textBoxManagementDataDW.AppendText("ReturnValue: " + outParams["ReturnValue"]);
                textBoxManagementDataDW.AppendText("\r\n");
            }
            catch (ManagementException ex)
            {
                MessageBox.Show(this, "An error occurred while trying to execute the WMI method: " + ex.Message);
            }
        }

        /// <summary>
        /// Init UI controls
        /// </summary>
        /// <returns></returns>
        public bool InitDriverMgmntTabPage()
        {
            lock (this)
            {
                try
                {
                    cmbWMIMethodsList.Items.Clear();

                    rsmDriverManagementObject.mgmtClass = new ManagementClass();
                    rsmDriverManagementObject.mgmtClass.Scope = rsmDriverManagementObject.mgmtScope;
                    rsmDriverManagementObject.mgmtClass.Path = new ManagementPath("RSMDriver");

                    // Enumurate RSMDriver Management Class Methods and polutate the "Method" Listbox
                    foreach (MethodData mm in rsmDriverManagementObject.mgmtClass.Methods)
                    {
                        if (mm.Name != "GetScannerCapabilityProfile")
                            cmbWMIMethodsList.Items.Add(mm.Name);
                    }
                    cmbWMIMethodsList.SelectedIndex = 0;

                    // Enumurate Management class properties and populate the "Properties" Listbox
                    foreach (PropertyData pp in rsmDriverManagementObject.mgmtClass.Properties)
                    {
                        lstWMIPorpertyList.Items.Add(pp.Name);
                    }

                    groupBoxExecDW.Enabled = true;
                    groupBoxQuery.Enabled = true;
                    chkPNPEventsCapture.Enabled = true;
                    textBoxEvents.Enabled = true;
                    chkAutoSwitchHostMode.Enabled = true;

                    this.Update();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Query WMI properties event 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueryProperty_Click(object sender, EventArgs e)
        {
            try
            {
                String selectedProperty;
                if (null != lstWMIPorpertyList.SelectedItem)
                {
                    selectedProperty = lstWMIPorpertyList.SelectedItem.ToString().Trim();
                }
                else
                {
                    return;
                }

                ManagementObjectSearcher mgmtObjectSearch = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM RSMDriver");

                foreach (ManagementObject queryObj in mgmtObjectSearch.Get())
                {
                    textBoxManagementDataDW.AppendText("RSMDriver Instance Property:");
                    textBoxManagementDataDW.AppendText(selectedProperty);
                    textBoxManagementDataDW.AppendText(":");
                    if (null != queryObj[selectedProperty])
                    {
                        textBoxManagementDataDW.AppendText(queryObj[selectedProperty].ToString());
                    }
                    textBoxManagementDataDW.AppendText("\r\n");
                }
            }
            catch (ManagementException ex)
            {
                MessageBox.Show(this, "An error occurred while querying for WMI data: " + ex.Message);
            }
        }

        /// <summary>
        /// Query WMI methods event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueryMethod_Click(object sender, EventArgs e)
        {
            String strWMIMethodSelected = String.Empty;
            try
            {
                if (cmbWMIMethodsList.SelectedItem != null)
                {
                    strWMIMethodSelected = cmbWMIMethodsList.SelectedItem.ToString();
                }
                else
                {
                    MessageBox.Show("Enter input");
                }

                if (strWMIMethodSelected == "GetDeviceTopology")
                {
                    ExecuteGetDeviceTopology();
                }
                else if (strWMIMethodSelected == "SwitchHostMode")
                {
                    ExecuteSwitchHostMode();
                }
                else if (strWMIMethodSelected == "SwitchCDCDevices")
                {
                    ExecuteSwitcCDCDevices();
                }
                else if (strWMIMethodSelected == "GetScannerCapabilityProfile")
                {
                    ExecuteGetScannerCapabilityProfile();
                }
                else if (strWMIMethodSelected == "RebootScanner")
                {
                    ExecuteRebootScanner();
                }
                else if (strWMIMethodSelected == "UpdateAttributeMetaFile")
                {
                    ExecuteUpdateAttributeMetaFile();
                }
            }
            catch 
            {
                MessageBox.Show("Check input");
            }
        }

        /// <summary>
        /// Selected WMI method changed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbWMIMethodsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateParameterList();
        }

        private void listBoxDW_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != this.listBoxDW.SelectedItem)
            {
                iSelectedIndex = this.listBoxDW.SelectedIndex;
                strSelectedIndexValue = this.listBoxDW.SelectedItem.ToString();
                this.listBoxDW.SelectedItem = null;
                InParamsDlg inparamDlg = new InParamsDlg(this);
                inparamDlg.ShowDialog();
            }          
        }

        /// <summary>
        /// Scanner host mode auto switching event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAutoSwitchHostMode_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM RSMDriver");
                String selectedProperty = "HostAutoSwitchingEnabled";
                Boolean setTrue = true;

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    if (chkAutoSwitchHostMode.Checked)
                    {
                        queryObj.SetPropertyValue(selectedProperty, setTrue);
                        queryObj.Put();
                    }
                    else
                    {
                        setTrue = false;
                        queryObj.SetPropertyValue(selectedProperty, setTrue);
                        queryObj.Put();
                    }
                }
            }
            catch (ManagementException ex)
            {
                MessageBox.Show(this, "An error occurred while querying for WMI data: " + ex.Message);
            }
        }

        /// <summary>
        /// Scanner PNPN events lsitner event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkPNPEventsCapture_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPNPEventsCapture.Checked)
            {
                mgmtEventWatcher.Start();
            }
            else
            {
                mgmtEventWatcher.Stop();
            }
        }

        /// <summary>
        /// Main form load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DriverWMITestApp_Load(object sender, EventArgs e)
        {
            HideAllPannels();
        }

        /// <summary>
        /// Enable scanner ID text box for individual scanner event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbIndividual_CheckedChanged(object sender, EventArgs e)
        {
            txtScannerID.Enabled = rbIndividual.Checked ? true : false;
        }

        /// <summary>
        /// Select attribute meta file event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowseAtribMeta_Click(object sender, EventArgs e)
        {
            openFileDialogAttribMetaFile.ShowDialog();
            txtAtribMetaPath.Text = openFileDialogAttribMetaFile.FileName;
        }

        /// <summary>
        /// Clear the output results event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxManagementDataDW.Clear();
            textBoxEvents.Clear();
        }

        /// <summary>
        /// Hide all UI panels
        /// </summary>
        private void HideAllPannels()
        {
            pnlReboot.Visible = false;
            pnlSwitchHostMode.Visible = false;
            pnlAtributeMeta.Visible = false;
            pnlScannerCapability.Visible = false;
        }
     }
}