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
        const String scannerIDXML = "<scanner><scannerID>10</scannerID></scanner>";
        public String inputVal;
        public DriverWMITestApp formParent;
        public InParamsDlg(DriverWMITestApp mainform)
        {
            InitializeComponent();
            formParent = mainform;

            inputVal = String.Empty;
            int selectedIndex = formParent.selectedIndex;

            String[] paramNameType = formParent.selectedIndexval.Split('=');
            String sampleVal = String.Empty; ;
           
            if ("GetDeviceTopology" == formParent.comboBoxMethodsDW.SelectedItem.ToString())
            {

            }
            else if ("SwitchHostMode" == formParent.comboBoxMethodsDW.SelectedItem.ToString())
            {
                if ("ScannerIdentity" == paramNameType[0])
                {
                    inputVal = scannerIDXML;
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
            else if ("GetScannerCapabilityProfile" == formParent.comboBoxMethodsDW.SelectedItem.ToString())
            {

            }
            else if ("RebootScanner" == formParent.comboBoxMethodsDW.SelectedItem.ToString())
            {
                if ("ScannerIdentity" == paramNameType[0])
                {
                    inputVal = scannerIDXML;
                    sampleVal = String.Empty;
                }

            }

            this.richTextBox1.Text = inputVal;
            this.labelInParamHelp.Text = formParent.selectedIndexval;
            this.labelInParamHelp.Text += "\r\n";
            this.labelInParamHelp.Text += sampleVal;

        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                inputVal = this.richTextBox1.Text;
                int selectedIndex = formParent.selectedIndex;
                String selectedIndexVal = formParent.selectedIndexval;
                formParent.listBoxDW.SelectedItem = null;
                formParent.inparams[selectedIndex] = inputVal;
                formParent.listBoxDW.Items.RemoveAt(selectedIndex);
                formParent.listBoxDW.Items.Insert(selectedIndex, (selectedIndexVal.Split('=')[0] + "=" + inputVal));
               // formParent.IsDisplay = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}