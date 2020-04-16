using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMI_Test
{
    public partial class InParamsDlg : Form
    {
        const String strScannerIDXML = "<scanner><scannerID>10</scannerID></scanner>";
        public String inputVal;
        public DriverWMITestApp formParent;

        public InParamsDlg(DriverWMITestApp mainform)
        {
            InitializeComponent();
            formParent = mainform;

            inputVal = String.Empty;
            int selectedIndex = formParent.iSelectedIndex;

            String[] paramNameType = formParent.strSelectedIndexValue.Split('=');
            String sampleVal = String.Empty; ;
           
            if ("GetDeviceTopology" == formParent.cmbWMIMethodsList.SelectedItem.ToString())
            {
            }
            else if ("SwitchHostMode" == formParent.cmbWMIMethodsList.SelectedItem.ToString())
            {
                if ("ScannerIdentity" == paramNameType[0])
                {
                    inputVal = strScannerIDXML;
                    sampleVal = String.Empty;
                }
                else if ("TargetHostMode" == paramNameType[0])
                {
                    sampleVal = "Values: For IBMHID use XUA-45001-1,\n For HIDKB use XUA-45001-3";
                }
                else if ("IsSilentSwitch" == paramNameType[0])
                {
                    sampleVal = "Values: true,false";
                }
                else if ("IsPermanentChange" == paramNameType[0])
                {
                    sampleVal = "Values: true,false";
                }

            }
            else if ("GetScannerCapabilityProfile" == formParent.cmbWMIMethodsList.SelectedItem.ToString())
            {

            }
            else if ("RebootScanner" == formParent.cmbWMIMethodsList.SelectedItem.ToString())
            {
                if ("ScannerIdentity" == paramNameType[0])
                {
                    inputVal = strScannerIDXML;
                    sampleVal = String.Empty;
                }
            }

            this.richTextBox1.Text = inputVal;
            this.labelInParamHelp.Text = formParent.strSelectedIndexValue;
            this.labelInParamHelp.Text += "\r\n";
            this.labelInParamHelp.Text += sampleVal;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                inputVal = this.richTextBox1.Text;
                int selectedIndex = formParent.iSelectedIndex;
                String selectedIndexVal = formParent.strSelectedIndexValue;
                formParent.listBoxDW.SelectedItem = null;
                formParent.inparams[selectedIndex] = inputVal;
                formParent.listBoxDW.Items.RemoveAt(selectedIndex);
                formParent.listBoxDW.Items.Insert(selectedIndex, (selectedIndexVal.Split('=')[0] + "=" + inputVal));
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                this.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}