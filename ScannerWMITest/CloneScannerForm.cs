/*******************************************************************************
* FILENAME: CloneScannerForm.cs
*
* ©2016 Symbol Technologies LLC. All rights reserved.
*
* DESCRIPTION: Implements cloning functionality of WMI Test Utility
*
* CREATION DATE: May 2006
*
* DERIVED FROM: 
*
* NOTES: *
* EDIT HISTORY:
*
********************************************************************************/


using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Management;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Runtime.InteropServices;
using System.Threading;


namespace WMI_Tester
{
	/// <summary>
    /// Summary description for CloneScannerForm.
	/// </summary>
	public class frmCloneWiz : System.Windows.Forms.Form
	{
		public System.Windows.Forms.CheckedListBox chkLstScanners;
		private System.Windows.Forms.Button cmdSASM;
		private System.Windows.Forms.Button cmdSAAM;
		private System.Windows.Forms.Button cmdCA;
		private System.Windows.Forms.Button cmdStartClone;

        delegate void SetTextCallback(string text);

		public string strWizModel;
		public string strWizComputer;
        public string strParameters;		
		public int intCurrentScan;
		private System.Windows.Forms.TextBox txtOutMgmt;
		private System.Windows.Forms.GroupBox grpSelectScanner;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnClose;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        private ManagementScope mgmtScope;

		public frmCloneWiz()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

        public void SetScope(ref ManagementScope scope)
        {
            mgmtScope = scope;
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.chkLstScanners = new System.Windows.Forms.CheckedListBox();
            this.cmdSASM = new System.Windows.Forms.Button();
            this.cmdSAAM = new System.Windows.Forms.Button();
            this.cmdCA = new System.Windows.Forms.Button();
            this.cmdStartClone = new System.Windows.Forms.Button();
            this.txtOutMgmt = new System.Windows.Forms.TextBox();
            this.grpSelectScanner = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpSelectScanner.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkLstScanners
            // 
            this.chkLstScanners.Location = new System.Drawing.Point(10, 18);
            this.chkLstScanners.Name = "chkLstScanners";
            this.chkLstScanners.Size = new System.Drawing.Size(364, 157);
            this.chkLstScanners.TabIndex = 0;
            // 
            // cmdSASM
            // 
            this.cmdSASM.Location = new System.Drawing.Point(10, 203);
            this.cmdSASM.Name = "cmdSASM";
            this.cmdSASM.Size = new System.Drawing.Size(182, 37);
            this.cmdSASM.TabIndex = 1;
            this.cmdSASM.Text = "Select All - Same Model";
            this.cmdSASM.Click += new System.EventHandler(this.cmdSASM_Click);
            // 
            // cmdSAAM
            // 
            this.cmdSAAM.Location = new System.Drawing.Point(192, 203);
            this.cmdSAAM.Name = "cmdSAAM";
            this.cmdSAAM.Size = new System.Drawing.Size(182, 37);
            this.cmdSAAM.TabIndex = 1;
            this.cmdSAAM.Text = "Select All - All Models";
            this.cmdSAAM.Click += new System.EventHandler(this.cmdSAAM_Click);
            // 
            // cmdCA
            // 
            this.cmdCA.Location = new System.Drawing.Point(10, 240);
            this.cmdCA.Name = "cmdCA";
            this.cmdCA.Size = new System.Drawing.Size(182, 37);
            this.cmdCA.TabIndex = 1;
            this.cmdCA.Text = "Clear All";
            this.cmdCA.Click += new System.EventHandler(this.cmdCA_Click);
            // 
            // cmdStartClone
            // 
            this.cmdStartClone.Location = new System.Drawing.Point(192, 240);
            this.cmdStartClone.Name = "cmdStartClone";
            this.cmdStartClone.Size = new System.Drawing.Size(182, 37);
            this.cmdStartClone.TabIndex = 1;
            this.cmdStartClone.Text = "Start Clone";
            this.cmdStartClone.Click += new System.EventHandler(this.cmdStartClone_Click);
            // 
            // txtOutMgmt
            // 
            this.txtOutMgmt.BackColor = System.Drawing.SystemColors.Info;
            this.txtOutMgmt.Location = new System.Drawing.Point(10, 28);
            this.txtOutMgmt.Multiline = true;
            this.txtOutMgmt.Name = "txtOutMgmt";
            this.txtOutMgmt.ReadOnly = true;
            this.txtOutMgmt.Size = new System.Drawing.Size(364, 166);
            this.txtOutMgmt.TabIndex = 2;
            // 
            // grpSelectScanner
            // 
            this.grpSelectScanner.Controls.Add(this.cmdCA);
            this.grpSelectScanner.Controls.Add(this.cmdSAAM);
            this.grpSelectScanner.Controls.Add(this.cmdStartClone);
            this.grpSelectScanner.Controls.Add(this.chkLstScanners);
            this.grpSelectScanner.Controls.Add(this.cmdSASM);
            this.grpSelectScanner.Location = new System.Drawing.Point(10, 9);
            this.grpSelectScanner.Name = "grpSelectScanner";
            this.grpSelectScanner.Size = new System.Drawing.Size(384, 286);
            this.grpSelectScanner.TabIndex = 3;
            this.grpSelectScanner.TabStop = false;
            this.grpSelectScanner.Text = "Select Scanners";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOutMgmt);
            this.groupBox1.Location = new System.Drawing.Point(10, 295);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 213);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(298, 517);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 37);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmCloneWiz
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(404, 561);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpSelectScanner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCloneWiz";
            this.Text = "Clone Scanner";
            this.Load += new System.EventHandler(this.CloneScannerForm_Load);
            this.grpSelectScanner.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        private void CloneScannerForm_Load(object sender, System.EventArgs e)
		{
			//ParentForm.
		}

		private void cmdSASM_Click(object sender, System.EventArgs e)
		{
			for (int index = 0; index < chkLstScanners.Items.Count; index++)
			{
				if (chkLstScanners.Items[index].ToString().IndexOf(strWizModel)==0)
				{
					chkLstScanners.SetItemChecked(index,true);
				}
				else
				{
					chkLstScanners.SetItemChecked(index,false);
				}
			}
		}

		private void cmdSAAM_Click(object sender, System.EventArgs e)
		{
			for (int index = 0; index < chkLstScanners.Items.Count; index++)
			{
				chkLstScanners.SetItemChecked(index,true);
			}
		}

		private void cmdCA_Click(object sender, System.EventArgs e)
		{
            for (int index = 0; index < chkLstScanners.Items.Count; index++)
			{
                chkLstScanners.SetItemChecked(index, false);
			}
		}

		private void cmdStartClone_Click(object sender, System.EventArgs e)
		{
			btnClose.Enabled=false;
			for (int index = 0; index < chkLstScanners.Items.Count; index++)
			{
				if (chkLstScanners.GetItemChecked(index)==true)
				{
					intCurrentScan = index;
					Thread threadClone = new Thread(new ThreadStart(CloneManagementThread ));
					threadClone.Name = "Clone_" + index.ToString();
					threadClone.Start();
					while (intCurrentScan == index)
					{
						Thread.Sleep(10);
					}
				}
			}
			btnClose.Enabled=true;
		}

        private void UpdateManagementResults(string strIn)
        {
            if (this.txtOutMgmt.InvokeRequired)
            {
                SetTextCallback callback = new SetTextCallback(UpdateManagementResults);
                this.Invoke(callback, new object[] { strIn });
            }
            else
            {
                this.txtOutMgmt.AppendText(strIn);
            }
        }

		private void CloneManagementThread()
		{
			string strCurItem=chkLstScanners.Items[intCurrentScan].ToString();
			string strWizPartNumber=strCurItem.Substring(0,strCurItem.IndexOf("\\"));
			string strWizSerialNumber=strCurItem.Substring(strCurItem.IndexOf("\\")+1);
			intCurrentScan++;
			try
			{
				UpdateManagementResults("\r\n" + "Start Cloning: " + strWizSerialNumber + " on Thread " + Thread.CurrentThread.Name);
                ManagementObject mgmtObject = new ManagementObject();
                mgmtObject.Scope = mgmtScope;
                mgmtObject.Path = new ManagementPath("Symbol_BarcodeScanner.PartNumber='" + strWizPartNumber + "',SerialNumber='" + strWizSerialNumber + "'");
              
                // Create ManagementBaseObject and get the parameters to the Method "StoreAttributes"
				ManagementBaseObject inParams = mgmtObject.GetMethodParameters("StoreAttributes");

				// Populate the parameter "attributeSettings" with the content of the clipboard
                inParams["attributeSettings"] = strParameters; //Clipboard.GetDataObject().ToString(); // (string)Clipboard.GetDataObject().GetData(DataFormats.Text).ToString();

				// Invoke the method "StoreAttributes" and retrieve the Result
				ManagementBaseObject outparams = mgmtObject.InvokeMethod("StoreAttributes", inParams, null);

				// Update Management Textbox				
				UpdateManagementResults("\r\n\r\n" + "Cloning Done: " + strWizSerialNumber + " on Thread " + Thread.CurrentThread.Name );
				UpdateManagementResults("\r\n" + "Return Value: " );

				// Display Return value
				string strRet = outparams["ReturnValue"].ToString();
				UpdateManagementResults(strRet);
				if (strRet.Equals("0"))         // ReturnValue=0 means the method invoked succesfully
				{
				}
				else
				{
				}
			}
            catch (ManagementException ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString() + "\nCheck if the Scanner is still connected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unknown Error: " + ex.Message.ToString());
            }
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
