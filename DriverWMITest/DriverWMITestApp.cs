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
        const String IBMHID = "XUA-45001-1";
        const String HIDKB = "XUA-45001-3";
        const String SNAPI_With_Iamging = "XUA-45001-9";
        const String SNAPI_Without_Imaging = "XUA-45001-10";
        const String IBMTT = "XUA-45001-2";
        const String USB_CDC = "XUA-45001-11";
        const String USB_SSI_CDC = "XUA-45001-14";

        private RSMDriverManagement rsmDriverManagementObject;
        private ScannerPNPEventHandler pnpEventHandler;
        static public DriverWMITestApp instance;
        public String hostAutoSwitchingEnabled = String.Empty;

        public DriverWMITestApp()
        {
            InitializeComponent();            
        }

        private void buttonConnectDW_Click(object sender, EventArgs e)
        {
            labelConnetionStatusDW.Text = String.Empty;
         
            ConnectionOptions options = new ConnectionOptions();
            options.Authentication = AuthenticationLevel.Packet;
            options.Impersonation = ImpersonationLevel.Impersonate;
            options.EnablePrivileges = true;

            listBoxPropertiesDW.Items.Clear();
            textBoxIPAddressDW.Text = textBoxIPAddressDW.Text.Trim().Equals("") ? "." : textBoxIPAddressDW.Text.Trim();

            rsmDriverManagementObject = new RSMDriverManagement();
            rsmDriverManagementObject.mgmtScope = new ManagementScope("\\\\" + textBoxIPAddressDW.Text + "\\root\\CIMV2", options);

            RSMDriverManagement serviceManagementObject = new RSMDriverManagement();
            serviceManagementObject.mgmtScope = new ManagementScope("\\\\" + textBoxIPAddressDW.Text + "\\root\\CIMV2", options);


            try
            {
                labelConnetionStatusDW.Text = String.Empty;
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
                labelConnetionStatusDW.Text = "Not Connected";
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
                
                labelConnetionStatusDW.Text = "Connected";
                InitDriverMgmntTabPage();

                if ("TRUE" == hostAutoSwitchingEnabled.ToUpper())
                {
                    checkBox1.Checked = true;
                }
 
            }
            catch (Exception)
            {
                labelConnetionStatusDW.Text = "Exception occurred. Please retry";
            }
            Cursor.Current = Cursors.Arrow;

            pnpEventHandler = new ScannerPNPEventHandler(ref instance);

            //Setup to receive ScannerEvent
            query = new WqlEventQuery("SELECT * FROM ScannerPNPEvent");
            watcher = new ManagementEventWatcher(query);
            watcher.EventArrived += new EventArrivedEventHandler(pnpEventHandler.EventArrived);
            
        }

        public static EventArrivedEventArgs scannerPNPEventArg;

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

        //Method to find the name and type of RSMDriver method parameters
        private void updateParameterList()
        {
            listBoxDW.Items.Clear();

            ManagementBaseObject inparams = rsmDriverManagementObject.mgmtClass.GetMethodParameters(comboBoxMethodsDW.Text.Trim());

            if (inparams != null)
            {
                foreach (PropertyData md in inparams.Properties)
                {
                    listBoxDW.Items.Add(md.Name + "= a value of type : " + md.Type);
                }
            }
    // ***************  Tharindu *************************************
            
            String selectedMethod = String.Empty;
            selectedMethod = comboBoxMethodsDW.SelectedItem.ToString();
                if (selectedMethod == "GetDeviceTopology")
                {
                    HideAllPannels();
                }
                else if (selectedMethod == "SwitchHostMode")
                {
                    HideAllPannels();
                    pnlSwitchHostMode.Visible = true;
                    cmbHostMode.SelectedIndex = 0;
                    txtSwitchHostScannerID.Enabled = true; ;
                }
                else if (selectedMethod == "GetScannerCapabilityProfile")
                {
                    HideAllPannels();
                    pnlScannerCapability.Visible = true;
                }
                else if (selectedMethod == "RebootScanner")
                {
                    HideAllPannels();
                    pnlReboot.Visible = true;
                }
                else if (selectedMethod == "UpdateAttributeMetaFile")
                {
                    HideAllPannels();
                    pnlAtributeMeta.Visible = true;
                }
                else if (selectedMethod == "SwitchCDCDevices")
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

        private void HideAllPannels()
        {
            pnlReboot.Visible = false;
            pnlSwitchHostMode.Visible = false;
            pnlAtributeMeta.Visible = false;
            pnlScannerCapability.Visible = false;
        }

   //***************************************************************

        public bool InitDriverMgmntTabPage()
        {
            lock (this)
            {
                try
                {
                    comboBoxMethodsDW.Items.Clear();

                    rsmDriverManagementObject.mgmtClass = new ManagementClass();
                    rsmDriverManagementObject.mgmtClass.Scope = rsmDriverManagementObject.mgmtScope;
                    rsmDriverManagementObject.mgmtClass.Path = new ManagementPath("RSMDriver");

                    // Enumurate RSMDriver Management Class Methods and polutate the "Method" Listbox
                    foreach (MethodData mm in rsmDriverManagementObject.mgmtClass.Methods)
                    {
                        if (mm.Name != "GetScannerCapabilityProfile")
                        comboBoxMethodsDW.Items.Add(mm.Name);
                    }
                    comboBoxMethodsDW.SelectedIndex = 0;    

                    // Enumurate Management class properties and populate the "Properties" Listbox
                    foreach (PropertyData pp in rsmDriverManagementObject.mgmtClass.Properties)
                    {
                        listBoxPropertiesDW.Items.Add(pp.Name);
                    }

                    groupBoxExecDW.Enabled = true;
                    groupBoxQuery.Enabled = true;
                    checkBoxDW.Enabled = true;
                    textBoxEvents.Enabled = true;
                    checkBox1.Enabled = true;
                    
                    this.Update();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        

        WqlEventQuery query;
        ManagementEventWatcher watcher;

        private ManualResetEvent pollEvent = new ManualResetEvent(false);        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDW.Checked)
            {
                watcher.Start();
            }
            else
            {
                watcher.Stop();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBoxManagementDataDW.Clear();
            textBoxEvents.Clear();
        }

        private void buttonGetPropertyDW_Click(object sender, EventArgs e)
        {
            try
            {
                String selectedProperty;
                if (null != listBoxPropertiesDW.SelectedItem)
                {
                    selectedProperty = listBoxPropertiesDW.SelectedItem.ToString().Trim();
                }
                else
                {
                    return;
                }

                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM RSMDriver");


                foreach (ManagementObject queryObj in searcher.Get())
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
                MessageBox.Show("An error occurred while querying for WMI data: " + ex.Message);
            }
        }
        
        private void ExecuteGetDeviceTopology()
        {
            try
            {
                ManagementObject classInstance =
                    new ManagementObject("root\\CIMV2",
                    "RSMDriver.Version='2.0.0.1'",
                    null);

                // no method in-parameters to define
                // Execute the method and obtain the return values.
                ManagementBaseObject outParams =
                    classInstance.InvokeMethod("GetDeviceTopology", null, null);
                
                // List outParams
                textBoxManagementDataDW.AppendText("Out parameters:");
                textBoxManagementDataDW.AppendText("\r\n======================\r\n");
                textBoxManagementDataDW.AppendText("DeviceTopology: \r\n--------------------------------\r\n" + IndentXMLString(outParams["DeviceTopology"].ToString().Replace("\n", "\r\n")));
                textBoxManagementDataDW.AppendText("\r\n\n");
                textBoxManagementDataDW.AppendText("ReturnValue: \r\n----------------------------------\r\n" + outParams["ReturnValue"]);
                textBoxManagementDataDW.AppendText("\r\n");
            }
            catch (ManagementException err)
            {
                MessageBox.Show("An error occurred while trying to execute the WMI method: " + err.Message);
            }
        }

/// <summary> (Tharindu)
/// Generate a formated XMl from a unformated XML
/// </summary>
/// <param name="xml">Unformated XML</param>
/// <returns>Formated XMl</returns>
        private static string IndentXMLString(string xml)
        {
            string outXml = string.Empty;
            MemoryStream ms = new MemoryStream();
            XmlTextWriter xtw = new XmlTextWriter(ms, Encoding.Unicode);
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.LoadXml(xml);
                xtw.Formatting = Formatting.Indented;
                doc.WriteContentTo(xtw);
                xtw.Flush();

                ms.Seek(0, SeekOrigin.Begin);
                StreamReader sr = new StreamReader(ms);
                return sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return string.Empty;
            }
        }

        private void ExecuteSwitcCDCDevices()
        {
            try
            {
                ManagementObject classInstance =
                    new ManagementObject("root\\CIMV2",
                    "RSMDriver.Version='2.0.0.1'",
                    null);

                // Obtain in-parameters for the method
                ManagementBaseObject inParams =
                    classInstance.GetMethodParameters("SwitchCDCDevices");



                inParams["IsPermanentChange"] = chkIsPermanant.Checked;
                inParams["IsSilentSwitch"] = chkIsSilentSwitch.Checked;

                StringBuilder sbSwitchingScanners = new StringBuilder();
                //sbSwitchingScanners.Append("<scanner><scannerID>");
                //sbSwitchingScanners.Append(txtSwitchHostScannerID.Text);
                //sbSwitchingScanners.Append("</scannerID></scanner>");

                //inParams["ScannerIdentity"] = sbSwitchingScanners.ToString();

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

                //******************************************************/

                // Execute the method and obtain the return values.
                ManagementBaseObject outParams =
                    classInstance.InvokeMethod("SwitchCDCDevices", inParams, null);

                // List outParams
                textBoxManagementDataDW.AppendText("Out parameters:");
                textBoxManagementDataDW.AppendText("\r\n");
                textBoxManagementDataDW.AppendText("ReturnValue: " + outParams["ReturnValue"]);
                textBoxManagementDataDW.AppendText("\r\n");
            }
            catch (ManagementException err)
            {
                MessageBox.Show("An error occurred while trying to execute the WMI method: " + err.Message);
            }
        }

        private void ExecuteSwitchHostMode()
        {
            try
            {
                ManagementObject classInstance =
                    new ManagementObject("root\\CIMV2",
                    "RSMDriver.Version='2.0.0.1'",
                    null);

                // Obtain in-parameters for the method
                ManagementBaseObject inParams =
                    classInstance.GetMethodParameters("SwitchHostMode");



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

            //******************************************************/
                
                // Execute the method and obtain the return values.
                ManagementBaseObject outParams =
                    classInstance.InvokeMethod("SwitchHostMode", inParams, null);

                // List outParams
                textBoxManagementDataDW.AppendText("Out parameters:");
                textBoxManagementDataDW.AppendText("\r\n");
                textBoxManagementDataDW.AppendText("ReturnValue: " + outParams["ReturnValue"]);
                textBoxManagementDataDW.AppendText("\r\n");
            }
            catch (ManagementException err)
            {
                MessageBox.Show("An error occurred while trying to execute the WMI method: " + err.Message);
            }
        }

        private void ExecuteGetScannerCapabilityProfile()
        {
            try
            {
                ManagementObject classInstance =
                    new ManagementObject("root\\CIMV2",
                    "RSMDriver.Version='2.0.0.1'",
                    null);

                // Obtain in-parameters for the method
                ManagementBaseObject inParams =
                    classInstance.GetMethodParameters("GetScannerCapabilityProfile");

                // Add the input parameters.
                //inParams["ScannerIdentity"] = inparams[0].Trim();

                //************ Tharindu *************************************

                inParams["ScannerIdentity"] = txtGetCapaScannerID.Text;


                //***********************************************************
                // Execute the method and obtain the return values.
                ManagementBaseObject outParams =
                    classInstance.InvokeMethod("GetScannerCapabilityProfile", inParams, null);

                // List outParams
                textBoxManagementDataDW.AppendText("Out parameters[GetScannerCapabilityProfile]:");
                textBoxManagementDataDW.AppendText("CapabilityProfile: " + outParams["CapabilityProfile"]);
                textBoxManagementDataDW.AppendText("ReturnValue: " + outParams["ReturnValue"]);
                textBoxManagementDataDW.AppendText("\r\n");
            }
            catch (ManagementException err)
            {
                MessageBox.Show("An error occurred while trying to execute the WMI method: " + err.Message);
            }
        }

        private void ExecuteRebootScanner()
        {
            try
            {
                ManagementObject classInstance =
                    new ManagementObject("root\\CIMV2",
                    "RSMDriver.Version='2.0.0.1'",
                    null);

                // Obtain in-parameters for the method
                ManagementBaseObject inParams = classInstance.GetMethodParameters("RebootScanner");

 
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
                ManagementBaseObject outParams =
                    classInstance.InvokeMethod("RebootScanner", inParams, null);

                // List outParams
                textBoxManagementDataDW.AppendText("Out parameters[RebootScanner]:");
                textBoxManagementDataDW.AppendText("ReturnValue: " + outParams["ReturnValue"]);
                textBoxManagementDataDW.AppendText("\r\n");
            }
            catch (ManagementException err)
            {
                MessageBox.Show("An error occurred while trying to execute the WMI method: " + err.Message);
            }
        }

        private void ExecuteUpdateAttributeMetaFile()
        {
            try
            {
                ManagementObject classInstance =
                    new ManagementObject("root\\CIMV2",
                    "RSMDriver.Version='2.0.0.1'",
                    null);

                // Obtain in-parameters for the method
                ManagementBaseObject inParams = classInstance.GetMethodParameters("UpdateAttributeMetaFile");
                inParams["AttributeMetaFilePath"] = txtAtribMetaPath.Text;

                ManagementBaseObject outParams =
                    classInstance.InvokeMethod("UpdateAttributeMetaFile", inParams, null);

                // List outParams
                textBoxManagementDataDW.AppendText("Out parameters[UpdateAttributeMetaFile]:");
                textBoxManagementDataDW.AppendText("ReturnValue: " + outParams["ReturnValue"]);
                textBoxManagementDataDW.AppendText("\r\n");
            }
            catch (ManagementException err)
            {
                MessageBox.Show("An error occurred while trying to execute the WMI method: " + err.Message);
            }

        }

        private void buttonExecuteDW_Click(object sender, EventArgs e)
        {
            String selectedMethod=String.Empty;
            try
            {
                if (null != comboBoxMethodsDW.SelectedItem)
                {
                    selectedMethod = comboBoxMethodsDW.SelectedItem.ToString();
                }
                else
                {
                    MessageBox.Show("Enter input");
                }


                if (selectedMethod == "GetDeviceTopology")
                {
                    ExecuteGetDeviceTopology();
                }
                else if (selectedMethod == "SwitchHostMode")
                {
                    ExecuteSwitchHostMode();
                }
                else if (selectedMethod == "SwitchCDCDevices")
                {
                    ExecuteSwitcCDCDevices();
                }
                else if (selectedMethod == "GetScannerCapabilityProfile")
                {
                    ExecuteGetScannerCapabilityProfile();
                }
                else if (selectedMethod == "RebootScanner")
                {
                    ExecuteRebootScanner();
                }
                else if (selectedMethod == "UpdateAttributeMetaFile")
                {
                    ExecuteUpdateAttributeMetaFile();
                }
            }
            catch 
            {
                MessageBox.Show("Check input");
            }
        }

        private void comboBoxMethodsDW_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateParameterList();
        }

        internal int selectedIndex;
        internal String selectedIndexval;

        private void listBoxDW_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != this.listBoxDW.SelectedItem)
            {
              //  IsDisplay = true;
                selectedIndex = this.listBoxDW.SelectedIndex;
                selectedIndexval = this.listBoxDW.SelectedItem.ToString();
                this.listBoxDW.SelectedItem = null;
                InParamsDlg inparamDlg = new InParamsDlg(this);
                //inparamDlg.Show();
               // inparamDlg.formParent = this;
                inparamDlg.ShowDialog();
                //inparamDlg.Show();
            }          
        }

        public bool IsDisplay = false;

        public String[] inparams = new String[10];

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM RSMDriver");

                String selectedProperty = "HostAutoSwitchingEnabled";
                Boolean setTrue = true;

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    if (checkBox1.Checked)
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
                MessageBox.Show("An error occurred while querying for WMI data: " + ex.Message);
            }
        }

        // *********************** Tharindu ***************************************
        private void DriverWMITestApp_Load(object sender, EventArgs e)
        {
            HideAllPannels();
        }

        private void rbIndividual_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIndividual.Checked)
            {
                txtScannerID.Enabled = true;
            }
            else
            {
                txtScannerID.Enabled = false;
            }
        }

        private void btnBrowseAtribMeta_Click(object sender, EventArgs e)
        {
            ofdAtribMeta.ShowDialog();
            txtAtribMetaPath.Text = ofdAtribMeta.FileName;

        }
        // *********************************************************************
     }
}