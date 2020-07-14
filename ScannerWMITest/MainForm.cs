/*******************************************************************************
* FILENAME: MainForm.cs
*
* ©2016 Symbol Technologies LLC. All rights reserved.
*
* DESCRIPTION: Implements a utility for testing Symbol_BarcodeScanner WMI class
*
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
using System.Collections.Specialized;
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
using System.Net;


namespace WMI_Tester
{
    /// <summary>
    /// The main form of the Scanner WMI Test client application
    /// </summary>
    public class frmMain : System.Windows.Forms.Form
    {
        #region Windows Controls Declarations

        // Connect group 
        private GroupBox groupBoxConnect;
        private Label lblComputer;
        private TextBox txtComputer;
        private Label lblConnStatus;
        private Button btnConnect;

        // Discover group 
        private GroupBox groupBoxDiscover;
        private Button btnDiscover;
        private Label lblModel;
        private Label lblSerialNumber;
        private ComboBox cmbModel;
        private ComboBox cmbSerialFiltered;
        private TextBox txtFirmware;
        private TextBox txtDOM;
        private Label lblDOM;
        private Label lblFirmwareVersion;
        private Label lblDiscoverStatus;

        // Exec group
        private GroupBox groupBoxExec;
        private ComboBox cmbMethod;
        private ComboBox cmbIN;
        private Label lblMethod;
        private Label lblInParam;
        private Label lblInput;
        private TextBox txtIN;
        private Button btnExecute;
        private Label lblExecStatus;

        // Query group
        private GroupBox groupBoxQuery;
        private ListBox lstProperties;
        private Button btnGetProperty;
        private Label lblQueryStatus;

        // Output group
        private GroupBox groupBoxOutput;
        private TextBox txtOutMgmt;
        private Label lblMgmtData;
        private Button btnClearOut;
        private Label lblFirmwareProgress;
        private TextBox txtFirmwareProgress;

        // Cloning group
        private Label lblCloneStatus;
        private Button btnRetrieve;
        private Button btnRetrieveFile;
        private Button btnPush;
        private Button btnSaveToFile;


        // Quick set group
        private GroupBox groupBoxQuickSet;
        private SaveFileDialog saveFileDialogMain;
        private Label lblVal;
        private Label lblParameter;
        private ComboBox cmbQuickSetVal;
        private ComboBox cmbQuickSet;
        private ComboBox cmbQuickSetData;
        private Button btnSetPara;
        private Button btnQuickSetRetrieve;
        private Label lblQuickSetStatus;

        private ToolTip toolTipMain;
        private System.ComponentModel.IContainer components;
        
        private OpenFileDialog openFileDialogMain;
       
        #endregion

        delegate void SetTextCallback(string text);

        private StringCollection partCollection = new StringCollection();
        private StringCollection serialCollection = new StringCollection();

        private string strScanCount = "0";						
        private string strPartNumber = "";						
        private string strSerialNumber = "";					
        private string strComputer;								
       
        private int no_of_Scanners = 0;							
        private bool blnDiscovered = false;						
        private string strLastModel = "";						
        enum RetrieveMethod { Quickset = 1, Clone = 2 };
       
       
        static private frmMain instance;

        static private ManagementEventWatcher discEvWatcher;
        static private ManagementEventWatcher fwupEvWatcher;
        static private DiscoveryEventHandler discEventHandler;
        static private FirmwareUpdateEventHandler fwupEventHandler;

        private ManagementScope mgmtScope;
        private ManagementClass mgmtClass;
        private ManagementObjectSearcher objSearcher = null;
        private Label label1;  
      
        bool blnConnected = false;

        // Main Entry point to the Form
        public frmMain()
        {
            InitializeComponent();
            ControlFocus(false);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.GroupBox groupBoxCloning;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnRetrieveFile = new System.Windows.Forms.Button();
            this.lblCloneStatus = new System.Windows.Forms.Label();
            this.btnSaveToFile = new System.Windows.Forms.Button();
            this.btnPush = new System.Windows.Forms.Button();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.groupBoxDiscover = new System.Windows.Forms.GroupBox();
            this.btnDiscover = new System.Windows.Forms.Button();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.lblDiscoverStatus = new System.Windows.Forms.Label();
            this.cmbSerialFiltered = new System.Windows.Forms.ComboBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.txtFirmware = new System.Windows.Forms.TextBox();
            this.txtDOM = new System.Windows.Forms.TextBox();
            this.lblDOM = new System.Windows.Forms.Label();
            this.lblFirmwareVersion = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtComputer = new System.Windows.Forms.TextBox();
            this.lblComputer = new System.Windows.Forms.Label();
            this.groupBoxExec = new System.Windows.Forms.GroupBox();
            this.lblExecStatus = new System.Windows.Forms.Label();
            this.lblInput = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.txtIN = new System.Windows.Forms.TextBox();
            this.cmbIN = new System.Windows.Forms.ComboBox();
            this.cmbMethod = new System.Windows.Forms.ComboBox();
            this.lblMethod = new System.Windows.Forms.Label();
            this.lblInParam = new System.Windows.Forms.Label();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this.lblMgmtData = new System.Windows.Forms.Label();
            this.btnClearOut = new System.Windows.Forms.Button();
            this.txtOutMgmt = new System.Windows.Forms.TextBox();
            this.lblFirmwareProgress = new System.Windows.Forms.Label();
            this.txtFirmwareProgress = new System.Windows.Forms.TextBox();
            this.groupBoxQuickSet = new System.Windows.Forms.GroupBox();
            this.cmbQuickSetData = new System.Windows.Forms.ComboBox();
            this.btnQuickSetRetrieve = new System.Windows.Forms.Button();
            this.lblQuickSetStatus = new System.Windows.Forms.Label();
            this.btnSetPara = new System.Windows.Forms.Button();
            this.lblVal = new System.Windows.Forms.Label();
            this.cmbQuickSetVal = new System.Windows.Forms.ComboBox();
            this.cmbQuickSet = new System.Windows.Forms.ComboBox();
            this.lblParameter = new System.Windows.Forms.Label();
            this.saveFileDialogMain = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogMain = new System.Windows.Forms.OpenFileDialog();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxQuery = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblQueryStatus = new System.Windows.Forms.Label();
            this.btnGetProperty = new System.Windows.Forms.Button();
            this.lstProperties = new System.Windows.Forms.ListBox();
            this.groupBoxConnect = new System.Windows.Forms.GroupBox();
            this.lblConnStatus = new System.Windows.Forms.Label();
            groupBoxCloning = new System.Windows.Forms.GroupBox();
            groupBoxCloning.SuspendLayout();
            this.groupBoxDiscover.SuspendLayout();
            this.groupBoxExec.SuspendLayout();
            this.groupBoxOutput.SuspendLayout();
            this.groupBoxQuickSet.SuspendLayout();
            this.groupBoxQuery.SuspendLayout();
            this.groupBoxConnect.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCloning
            // 
            groupBoxCloning.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            groupBoxCloning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            groupBoxCloning.Controls.Add(this.btnRetrieveFile);
            groupBoxCloning.Controls.Add(this.lblCloneStatus);
            groupBoxCloning.Controls.Add(this.btnSaveToFile);
            groupBoxCloning.Controls.Add(this.btnPush);
            groupBoxCloning.Controls.Add(this.btnRetrieve);
            groupBoxCloning.Enabled = false;
            groupBoxCloning.Location = new System.Drawing.Point(8, 642);
            groupBoxCloning.Name = "groupBoxCloning";
            groupBoxCloning.Size = new System.Drawing.Size(400, 90);
            groupBoxCloning.TabIndex = 11;
            groupBoxCloning.TabStop = false;
            groupBoxCloning.Text = "Scanner Cloning";
            // 
            // btnRetrieveFile
            // 
            this.btnRetrieveFile.Location = new System.Drawing.Point(107, 23);
            this.btnRetrieveFile.Name = "btnRetrieveFile";
            this.btnRetrieveFile.Size = new System.Drawing.Size(87, 39);
            this.btnRetrieveFile.TabIndex = 16;
            this.btnRetrieveFile.Text = "Retrieve from File";
            this.btnRetrieveFile.Click += new System.EventHandler(this.btnRetrieveFile_Click);
            // 
            // lblCloneStatus
            // 
            this.lblCloneStatus.Location = new System.Drawing.Point(304, 68);
            this.lblCloneStatus.Name = "lblCloneStatus";
            this.lblCloneStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCloneStatus.Size = new System.Drawing.Size(85, 18);
            this.lblCloneStatus.TabIndex = 15;
            this.lblCloneStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Location = new System.Drawing.Point(205, 23);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(87, 39);
            this.btnSaveToFile.TabIndex = 2;
            this.btnSaveToFile.Text = "Save to File";
            this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
            // 
            // btnPush
            // 
            this.btnPush.Location = new System.Drawing.Point(303, 23);
            this.btnPush.Name = "btnPush";
            this.btnPush.Size = new System.Drawing.Size(88, 39);
            this.btnPush.TabIndex = 1;
            this.btnPush.Text = "Push";
            this.btnPush.Click += new System.EventHandler(this.btnPush_Click);
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Location = new System.Drawing.Point(8, 23);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(88, 39);
            this.btnRetrieve.TabIndex = 0;
            this.btnRetrieve.Text = "Retrieve from Scanner";
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // groupBoxDiscover
            // 
            this.groupBoxDiscover.Controls.Add(this.btnDiscover);
            this.groupBoxDiscover.Controls.Add(this.lblSerialNumber);
            this.groupBoxDiscover.Controls.Add(this.cmbModel);
            this.groupBoxDiscover.Controls.Add(this.lblDiscoverStatus);
            this.groupBoxDiscover.Controls.Add(this.cmbSerialFiltered);
            this.groupBoxDiscover.Controls.Add(this.lblModel);
            this.groupBoxDiscover.Controls.Add(this.txtFirmware);
            this.groupBoxDiscover.Controls.Add(this.txtDOM);
            this.groupBoxDiscover.Controls.Add(this.lblDOM);
            this.groupBoxDiscover.Controls.Add(this.lblFirmwareVersion);
            this.groupBoxDiscover.Location = new System.Drawing.Point(8, 88);
            this.groupBoxDiscover.Name = "groupBoxDiscover";
            this.groupBoxDiscover.Size = new System.Drawing.Size(400, 136);
            this.groupBoxDiscover.TabIndex = 7;
            this.groupBoxDiscover.TabStop = false;
            this.groupBoxDiscover.Text = "Scanner Asset Tracking Information";
            // 
            // btnDiscover
            // 
            this.btnDiscover.Location = new System.Drawing.Point(287, 25);
            this.btnDiscover.Name = "btnDiscover";
            this.btnDiscover.Size = new System.Drawing.Size(88, 25);
            this.btnDiscover.TabIndex = 3;
            this.btnDiscover.Text = "Discover";
            this.btnDiscover.Click += new System.EventHandler(this.btnDiscover_Click);
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.Location = new System.Drawing.Point(8, 52);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Size = new System.Drawing.Size(88, 20);
            this.lblSerialNumber.TabIndex = 3;
            this.lblSerialNumber.Text = "Serial Number";
            this.lblSerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbModel
            // 
            this.cmbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModel.Enabled = false;
            this.cmbModel.Location = new System.Drawing.Point(112, 25);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(160, 21);
            this.cmbModel.TabIndex = 4;
            this.cmbModel.SelectedIndexChanged += new System.EventHandler(this.cmbModel_SelectedIndexChanged);
            // 
            // lblDiscoverStatus
            // 
            this.lblDiscoverStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblDiscoverStatus.Location = new System.Drawing.Point(287, 95);
            this.lblDiscoverStatus.Name = "lblDiscoverStatus";
            this.lblDiscoverStatus.Size = new System.Drawing.Size(105, 32);
            this.lblDiscoverStatus.TabIndex = 0;
            this.lblDiscoverStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSerialFiltered
            // 
            this.cmbSerialFiltered.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerialFiltered.Enabled = false;
            this.cmbSerialFiltered.Location = new System.Drawing.Point(112, 51);
            this.cmbSerialFiltered.Name = "cmbSerialFiltered";
            this.cmbSerialFiltered.Size = new System.Drawing.Size(160, 21);
            this.cmbSerialFiltered.TabIndex = 4;
            this.cmbSerialFiltered.SelectedIndexChanged += new System.EventHandler(this.cmbSerialFiltered_SelectedIndexChanged);
            // 
            // lblModel
            // 
            this.lblModel.Location = new System.Drawing.Point(8, 26);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(88, 20);
            this.lblModel.TabIndex = 3;
            this.lblModel.Text = "Model Number";
            this.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFirmware
            // 
            this.txtFirmware.BackColor = System.Drawing.SystemColors.Info;
            this.txtFirmware.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFirmware.Location = new System.Drawing.Point(112, 77);
            this.txtFirmware.Name = "txtFirmware";
            this.txtFirmware.ReadOnly = true;
            this.txtFirmware.Size = new System.Drawing.Size(160, 20);
            this.txtFirmware.TabIndex = 5;
            // 
            // txtDOM
            // 
            this.txtDOM.BackColor = System.Drawing.SystemColors.Info;
            this.txtDOM.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDOM.Location = new System.Drawing.Point(112, 101);
            this.txtDOM.Name = "txtDOM";
            this.txtDOM.ReadOnly = true;
            this.txtDOM.Size = new System.Drawing.Size(160, 20);
            this.txtDOM.TabIndex = 5;
            // 
            // lblDOM
            // 
            this.lblDOM.Location = new System.Drawing.Point(8, 101);
            this.lblDOM.Name = "lblDOM";
            this.lblDOM.Size = new System.Drawing.Size(96, 19);
            this.lblDOM.TabIndex = 1;
            this.lblDOM.Text = "Manufacture Date";
            this.lblDOM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFirmwareVersion
            // 
            this.lblFirmwareVersion.Location = new System.Drawing.Point(8, 75);
            this.lblFirmwareVersion.Name = "lblFirmwareVersion";
            this.lblFirmwareVersion.Size = new System.Drawing.Size(96, 21);
            this.lblFirmwareVersion.TabIndex = 1;
            this.lblFirmwareVersion.Text = "Firmware Version";
            this.lblFirmwareVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(287, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(88, 26);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtComputer
            // 
            this.txtComputer.BackColor = System.Drawing.Color.White;
            this.txtComputer.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtComputer.Location = new System.Drawing.Point(112, 16);
            this.txtComputer.Name = "txtComputer";
            this.txtComputer.Size = new System.Drawing.Size(160, 20);
            this.txtComputer.TabIndex = 0;
            this.txtComputer.Text = "localhost";
            // 
            // lblComputer
            // 
            this.lblComputer.Location = new System.Drawing.Point(5, 16);
            this.lblComputer.Name = "lblComputer";
            this.lblComputer.Size = new System.Drawing.Size(116, 20);
            this.lblComputer.TabIndex = 3;
            this.lblComputer.Text = "Name or IP Address";
            this.lblComputer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxExec
            // 
            this.groupBoxExec.Controls.Add(this.lblExecStatus);
            this.groupBoxExec.Controls.Add(this.lblInput);
            this.groupBoxExec.Controls.Add(this.btnExecute);
            this.groupBoxExec.Controls.Add(this.txtIN);
            this.groupBoxExec.Controls.Add(this.cmbIN);
            this.groupBoxExec.Controls.Add(this.cmbMethod);
            this.groupBoxExec.Controls.Add(this.lblMethod);
            this.groupBoxExec.Controls.Add(this.lblInParam);
            this.groupBoxExec.Enabled = false;
            this.groupBoxExec.Location = new System.Drawing.Point(8, 230);
            this.groupBoxExec.Name = "groupBoxExec";
            this.groupBoxExec.Size = new System.Drawing.Size(400, 222);
            this.groupBoxExec.TabIndex = 8;
            this.groupBoxExec.TabStop = false;
            this.groupBoxExec.Text = "Execute Methods";
            // 
            // lblExecStatus
            // 
            this.lblExecStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblExecStatus.Location = new System.Drawing.Point(11, 115);
            this.lblExecStatus.Name = "lblExecStatus";
            this.lblExecStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblExecStatus.Size = new System.Drawing.Size(87, 47);
            this.lblExecStatus.TabIndex = 14;
            this.lblExecStatus.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblInput
            // 
            this.lblInput.Location = new System.Drawing.Point(8, 88);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(96, 27);
            this.lblInput.TabIndex = 15;
            this.lblInput.Text = "IN Param Value";
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExecute.Location = new System.Drawing.Point(11, 190);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(87, 24);
            this.btnExecute.TabIndex = 10;
            this.btnExecute.Text = "Execute";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // txtIN
            // 
            this.txtIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIN.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtIN.Location = new System.Drawing.Point(112, 88);
            this.txtIN.Multiline = true;
            this.txtIN.Name = "txtIN";
            this.txtIN.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtIN.Size = new System.Drawing.Size(280, 126);
            this.txtIN.TabIndex = 8;
            this.txtIN.WordWrap = false;
            // 
            // cmbIN
            // 
            this.cmbIN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIN.Location = new System.Drawing.Point(112, 56);
            this.cmbIN.Name = "cmbIN";
            this.cmbIN.Size = new System.Drawing.Size(160, 21);
            this.cmbIN.TabIndex = 5;
            // 
            // cmbMethod
            // 
            this.cmbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMethod.IntegralHeight = false;
            this.cmbMethod.Location = new System.Drawing.Point(112, 24);
            this.cmbMethod.MaxDropDownItems = 9;
            this.cmbMethod.Name = "cmbMethod";
            this.cmbMethod.Size = new System.Drawing.Size(160, 21);
            this.cmbMethod.Sorted = true;
            this.cmbMethod.TabIndex = 4;
            this.cmbMethod.SelectedIndexChanged += new System.EventHandler(this.cmbMethod_SelectedIndexChanged);
            // 
            // lblMethod
            // 
            this.lblMethod.Location = new System.Drawing.Point(8, 26);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(64, 20);
            this.lblMethod.TabIndex = 3;
            this.lblMethod.Text = "Method";
            this.lblMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInParam
            // 
            this.lblInParam.Location = new System.Drawing.Point(8, 55);
            this.lblInParam.Name = "lblInParam";
            this.lblInParam.Size = new System.Drawing.Size(96, 23);
            this.lblInParam.TabIndex = 1;
            this.lblInParam.Text = "IN Param Name";
            this.lblInParam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxOutput
            // 
            this.groupBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxOutput.Controls.Add(this.lblMgmtData);
            this.groupBoxOutput.Controls.Add(this.btnClearOut);
            this.groupBoxOutput.Controls.Add(this.txtOutMgmt);
            this.groupBoxOutput.Controls.Add(this.lblFirmwareProgress);
            this.groupBoxOutput.Controls.Add(this.txtFirmwareProgress);
            this.groupBoxOutput.Location = new System.Drawing.Point(416, 8);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Size = new System.Drawing.Size(548, 629);
            this.groupBoxOutput.TabIndex = 10;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "Output From Scanner";
            // 
            // lblMgmtData
            // 
            this.lblMgmtData.Location = new System.Drawing.Point(8, 24);
            this.lblMgmtData.Name = "lblMgmtData";
            this.lblMgmtData.Size = new System.Drawing.Size(104, 16);
            this.lblMgmtData.TabIndex = 8;
            this.lblMgmtData.Text = "Management Data";
            // 
            // btnClearOut
            // 
            this.btnClearOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearOut.Location = new System.Drawing.Point(459, 595);
            this.btnClearOut.Name = "btnClearOut";
            this.btnClearOut.Size = new System.Drawing.Size(80, 24);
            this.btnClearOut.TabIndex = 7;
            this.btnClearOut.Text = "Clear";
            this.btnClearOut.Click += new System.EventHandler(this.btnClearOut_Click);
            // 
            // txtOutMgmt
            // 
            this.txtOutMgmt.AcceptsTab = true;
            this.txtOutMgmt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutMgmt.BackColor = System.Drawing.SystemColors.Info;
            this.txtOutMgmt.Location = new System.Drawing.Point(8, 40);
            this.txtOutMgmt.MaxLength = 0;
            this.txtOutMgmt.Multiline = true;
            this.txtOutMgmt.Name = "txtOutMgmt";
            this.txtOutMgmt.ReadOnly = true;
            this.txtOutMgmt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutMgmt.Size = new System.Drawing.Size(532, 534);
            this.txtOutMgmt.TabIndex = 0;
            this.txtOutMgmt.TabStop = false;
            this.txtOutMgmt.WordWrap = false;
            // 
            // lblFirmwareProgress
            // 
            this.lblFirmwareProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFirmwareProgress.Location = new System.Drawing.Point(8, 595);
            this.lblFirmwareProgress.Name = "lblFirmwareProgress";
            this.lblFirmwareProgress.Size = new System.Drawing.Size(133, 24);
            this.lblFirmwareProgress.TabIndex = 13;
            this.lblFirmwareProgress.Text = "Firmware Update Status";
            this.lblFirmwareProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFirmwareProgress
            // 
            this.txtFirmwareProgress.AcceptsTab = true;
            this.txtFirmwareProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirmwareProgress.BackColor = System.Drawing.SystemColors.Info;
            this.txtFirmwareProgress.Location = new System.Drawing.Point(146, 598);
            this.txtFirmwareProgress.MaxLength = 0;
            this.txtFirmwareProgress.Name = "txtFirmwareProgress";
            this.txtFirmwareProgress.ReadOnly = true;
            this.txtFirmwareProgress.Size = new System.Drawing.Size(307, 20);
            this.txtFirmwareProgress.TabIndex = 14;
            this.txtFirmwareProgress.TabStop = false;
            // 
            // groupBoxQuickSet
            // 
            this.groupBoxQuickSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxQuickSet.Controls.Add(this.cmbQuickSetData);
            this.groupBoxQuickSet.Controls.Add(this.btnQuickSetRetrieve);
            this.groupBoxQuickSet.Controls.Add(this.lblQuickSetStatus);
            this.groupBoxQuickSet.Controls.Add(this.btnSetPara);
            this.groupBoxQuickSet.Controls.Add(this.lblVal);
            this.groupBoxQuickSet.Controls.Add(this.cmbQuickSetVal);
            this.groupBoxQuickSet.Controls.Add(this.cmbQuickSet);
            this.groupBoxQuickSet.Controls.Add(this.lblParameter);
            this.groupBoxQuickSet.Enabled = false;
            this.groupBoxQuickSet.Location = new System.Drawing.Point(416, 642);
            this.groupBoxQuickSet.Name = "groupBoxQuickSet";
            this.groupBoxQuickSet.Size = new System.Drawing.Size(548, 90);
            this.groupBoxQuickSet.TabIndex = 12;
            this.groupBoxQuickSet.TabStop = false;
            this.groupBoxQuickSet.Text = "Quick Set Parameter";
            // 
            // cmbQuickSetData
            // 
            this.cmbQuickSetData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuickSetData.Location = new System.Drawing.Point(267, 23);
            this.cmbQuickSetData.Name = "cmbQuickSetData";
            this.cmbQuickSetData.Size = new System.Drawing.Size(110, 21);
            this.cmbQuickSetData.TabIndex = 0;
            this.cmbQuickSetData.Visible = false;
            // 
            // btnQuickSetRetrieve
            // 
            this.btnQuickSetRetrieve.Location = new System.Drawing.Point(9, 23);
            this.btnQuickSetRetrieve.Name = "btnQuickSetRetrieve";
            this.btnQuickSetRetrieve.Size = new System.Drawing.Size(88, 39);
            this.btnQuickSetRetrieve.TabIndex = 16;
            this.btnQuickSetRetrieve.Text = "Retrieve";
            this.btnQuickSetRetrieve.Click += new System.EventHandler(this.btnQuickSetRetrieve_Click);
            // 
            // lblQuickSetStatus
            // 
            this.lblQuickSetStatus.Location = new System.Drawing.Point(8, 68);
            this.lblQuickSetStatus.Name = "lblQuickSetStatus";
            this.lblQuickSetStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblQuickSetStatus.Size = new System.Drawing.Size(85, 17);
            this.lblQuickSetStatus.TabIndex = 15;
            this.lblQuickSetStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSetPara
            // 
            this.btnSetPara.Enabled = false;
            this.btnSetPara.Location = new System.Drawing.Point(105, 23);
            this.btnSetPara.Name = "btnSetPara";
            this.btnSetPara.Size = new System.Drawing.Size(87, 39);
            this.btnSetPara.TabIndex = 3;
            this.btnSetPara.Text = "Set Parameter";
            this.btnSetPara.Click += new System.EventHandler(this.btnSetPara_Click);
            // 
            // lblVal
            // 
            this.lblVal.AutoSize = true;
            this.lblVal.Location = new System.Drawing.Point(200, 58);
            this.lblVal.Name = "lblVal";
            this.lblVal.Size = new System.Drawing.Size(34, 13);
            this.lblVal.TabIndex = 2;
            this.lblVal.Text = "Value";
            // 
            // cmbQuickSetVal
            // 
            this.cmbQuickSetVal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbQuickSetVal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuickSetVal.Enabled = false;
            this.cmbQuickSetVal.Location = new System.Drawing.Point(267, 52);
            this.cmbQuickSetVal.Name = "cmbQuickSetVal";
            this.cmbQuickSetVal.Size = new System.Drawing.Size(273, 21);
            this.cmbQuickSetVal.TabIndex = 1;
            // 
            // cmbQuickSet
            // 
            this.cmbQuickSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbQuickSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuickSet.Enabled = false;
            this.cmbQuickSet.Location = new System.Drawing.Point(267, 24);
            this.cmbQuickSet.Name = "cmbQuickSet";
            this.cmbQuickSet.Size = new System.Drawing.Size(273, 21);
            this.cmbQuickSet.TabIndex = 0;
            this.cmbQuickSet.SelectedIndexChanged += new System.EventHandler(this.cmbQuickSet_SelectedIndexChanged);
            this.cmbQuickSet.Click += new System.EventHandler(this.cmbQuickSet_Click);
            // 
            // lblParameter
            // 
            this.lblParameter.AutoSize = true;
            this.lblParameter.Location = new System.Drawing.Point(200, 30);
            this.lblParameter.Name = "lblParameter";
            this.lblParameter.Size = new System.Drawing.Size(55, 13);
            this.lblParameter.TabIndex = 2;
            this.lblParameter.Text = "Parameter";
            // 
            // groupBoxQuery
            // 
            this.groupBoxQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxQuery.Controls.Add(this.label1);
            this.groupBoxQuery.Controls.Add(this.lblQueryStatus);
            this.groupBoxQuery.Controls.Add(this.btnGetProperty);
            this.groupBoxQuery.Controls.Add(this.lstProperties);
            this.groupBoxQuery.Enabled = false;
            this.groupBoxQuery.Location = new System.Drawing.Point(8, 457);
            this.groupBoxQuery.Name = "groupBoxQuery";
            this.groupBoxQuery.Size = new System.Drawing.Size(400, 180);
            this.groupBoxQuery.TabIndex = 13;
            this.groupBoxQuery.TabStop = false;
            this.groupBoxQuery.Text = "Query Properties";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Properties";
            // 
            // lblQueryStatus
            // 
            this.lblQueryStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblQueryStatus.Location = new System.Drawing.Point(11, 77);
            this.lblQueryStatus.Name = "lblQueryStatus";
            this.lblQueryStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblQueryStatus.Size = new System.Drawing.Size(87, 48);
            this.lblQueryStatus.TabIndex = 19;
            this.lblQueryStatus.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnGetProperty
            // 
            this.btnGetProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGetProperty.Location = new System.Drawing.Point(11, 144);
            this.btnGetProperty.Name = "btnGetProperty";
            this.btnGetProperty.Size = new System.Drawing.Size(87, 23);
            this.btnGetProperty.TabIndex = 18;
            this.btnGetProperty.Text = "Get";
            this.btnGetProperty.Click += new System.EventHandler(this.btnGetProperty_Click);
            // 
            // lstProperties
            // 
            this.lstProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstProperties.Location = new System.Drawing.Point(112, 30);
            this.lstProperties.Name = "lstProperties";
            this.lstProperties.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstProperties.Size = new System.Drawing.Size(280, 121);
            this.lstProperties.TabIndex = 17;
            this.lstProperties.DoubleClick += new System.EventHandler(this.lstProperties_DoubleClick);
            // 
            // groupBoxConnect
            // 
            this.groupBoxConnect.Controls.Add(this.lblConnStatus);
            this.groupBoxConnect.Controls.Add(this.btnConnect);
            this.groupBoxConnect.Controls.Add(this.txtComputer);
            this.groupBoxConnect.Controls.Add(this.lblComputer);
            this.groupBoxConnect.Location = new System.Drawing.Point(8, 8);
            this.groupBoxConnect.Name = "groupBoxConnect";
            this.groupBoxConnect.Size = new System.Drawing.Size(400, 75);
            this.groupBoxConnect.TabIndex = 14;
            this.groupBoxConnect.TabStop = false;
            this.groupBoxConnect.Text = "Target Computer";
            // 
            // lblConnStatus
            // 
            this.lblConnStatus.AutoSize = true;
            this.lblConnStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblConnStatus.Location = new System.Drawing.Point(284, 55);
            this.lblConnStatus.Name = "lblConnStatus";
            this.lblConnStatus.Size = new System.Drawing.Size(79, 13);
            this.lblConnStatus.TabIndex = 14;
            this.lblConnStatus.Text = "Not Connected";
            this.lblConnStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(973, 740);
            this.Controls.Add(this.groupBoxConnect);
            this.Controls.Add(this.groupBoxDiscover);
            this.Controls.Add(this.groupBoxQuery);
            this.Controls.Add(this.groupBoxQuickSet);
            this.Controls.Add(groupBoxCloning);
            this.Controls.Add(this.groupBoxOutput);
            this.Controls.Add(this.groupBoxExec);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(802, 634);
            this.Name = "frmMain";
            this.Text = "Scanner WMI Test";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            groupBoxCloning.ResumeLayout(false);
            this.groupBoxDiscover.ResumeLayout(false);
            this.groupBoxDiscover.PerformLayout();
            this.groupBoxExec.ResumeLayout(false);
            this.groupBoxExec.PerformLayout();
            this.groupBoxOutput.ResumeLayout(false);
            this.groupBoxOutput.PerformLayout();
            this.groupBoxQuickSet.ResumeLayout(false);
            this.groupBoxQuickSet.PerformLayout();
            this.groupBoxQuery.ResumeLayout(false);
            this.groupBoxQuery.PerformLayout();
            this.groupBoxConnect.ResumeLayout(false);
            this.groupBoxConnect.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        // Main Entry point the Application
        [STAThread]
        static void Main()
        {
            instance = new frmMain();
            Application.Run(instance);
        }

        private void StopEventListeners()
        {
            if (discEvWatcher != null) discEvWatcher.Stop();
            if (fwupEvWatcher != null) fwupEvWatcher.Stop();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            blnConnected = false;
            Cursor.Current = Cursors.WaitCursor;
            ClearAllEx();

            ConnectionOptions options = new ConnectionOptions();
            options.Authentication = AuthenticationLevel.Packet;
            options.Impersonation = ImpersonationLevel.Impersonate;
            options.EnablePrivileges = true;

            txtComputer.Text = txtComputer.Text.Trim().Equals("") ? "." : txtComputer.Text.Trim();

            mgmtScope = new ManagementScope("\\\\" + txtComputer.Text + "\\root\\CIMV2", options);

            try
            {
                lblConnStatus.Text = "";
                mgmtScope.Connect();
            }
            catch (Exception)
            {
                string errmsg = "Failed to connect\r\n\r\nPossible Reasons:\r\n"
                + "- Host Name or IP Address may be incorrect\r\n"
                + "- Currently logged-on user credentials may not be sufficient\r\n"
                + "- Firewall group policies of remote host may not be configured";
                string errcap = "Connection Error";
                MessageBox.Show(errmsg, errcap, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lblConnStatus.Text = "Not Connected";
                this.Update();
                Cursor.Current = Cursors.Arrow;
                return;
            }

            StopEventListeners();

            // Subscribe for Disovery Events
            EventQuery query = new EventQuery("SELECT * FROM SymbScnrDiscoveryEvent");
            discEventHandler = new DiscoveryEventHandler(ref instance);
            discEvWatcher = new ManagementEventWatcher(mgmtScope, query);
            discEvWatcher.EventArrived += new EventArrivedEventHandler(discEventHandler.EventArrived);
            discEvWatcher.Stopped += new StoppedEventHandler(discEventHandler.StoppedEvent);

            // Subscribe for Firmware update events
            query = new EventQuery("SELECT * FROM SymbScnrFirmwareUpdateEvent");
            fwupEventHandler = new FirmwareUpdateEventHandler(ref instance);
            fwupEvWatcher = new ManagementEventWatcher(mgmtScope, query);
            fwupEvWatcher.EventArrived += new EventArrivedEventHandler(fwupEventHandler.EventArrived);
            fwupEvWatcher.Stopped += new StoppedEventHandler(fwupEventHandler.StoppedEvent);

            try
            {
                discEvWatcher.Start();
                fwupEvWatcher.Start();
            }
            catch (Exception)
            {
                string errmsg = "Failed to Subscribe for Events\r\n\r\nPossible Reasons:\r\n"
                + "- Currently logged-on user credentials may not be sufficient\r\n"
                + "- Firewall group policies of remote host may not be configured";
                string errcap = "Event Subscription Error";
                MessageBox.Show(errmsg, errcap, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (Init())
            {
                lblConnStatus.Text = "Connected";
                blnConnected = true;
                ControlFocus(true, groupBoxDiscover.Name);
            }
            else
            {
                string errmsg = "Failed to Initialize\r\n\r\nPossible Reasons:\r\n"
               + "- Symbol_BarcodeScanner WMI class may not be available in CIM\r\n";
                string errcap = "Connection Error";
                MessageBox.Show(errmsg, errcap, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lblConnStatus.Text = "Not Connected";
                this.Update();
                Cursor.Current = Cursors.Arrow;
                return;
            }
            Cursor.Current = Cursors.Arrow;
        }

        // Discover Button Click Event
        // Implementation is in the Init() function
        private void btnDiscover_Click(object sender, System.EventArgs e)
        {
            if (!blnConnected)
                return;
            Discover();
        }

        
        private void ClearAll()
        {
            serialCollection.Clear();
            partCollection.Clear();

            cmbModel.Items.Clear();
            cmbSerialFiltered.Items.Clear();

            txtDOM.Text = "";
            txtFirmware.Text = "";

            cmbModel.Enabled = false;
            cmbSerialFiltered.Enabled = false;

            this.Text = "Scanner WMI Test";
            strComputer = ".";
            strSerialNumber = "";
            strPartNumber = "";

            // Initialize the variables
            no_of_Scanners = 0;
            lblDiscoverStatus.Text = "";
                     
            lblExecStatus.Text = "";
            lblQueryStatus.Text = "";
            lblQuickSetStatus.Text = "";
            lblCloneStatus.Text = "";

            txtFirmwareProgress.Text = "";
            this.Update();
        }


        private void ClearAllEx()
        {
            ClearAll();
            cmbMethod.Items.Clear();
            lstProperties.Items.Clear();
            txtOutMgmt.Text = "";
            this.Update();
        }

        //Init() Function
        //Function used to enumurate the WMI directory and search for WMI Scanners and populate the Scanners
        //Function is called when the "Discover" Button is clicked
        private bool Init()
        {
            lock (this)
            {
                try
                {
                    mgmtClass = new ManagementClass();
                    mgmtClass.Scope = mgmtScope;
                    mgmtClass.Path = new ManagementPath("Symbol_BarcodeScanner");

                    // Enumurate Symbol_BarcodeScanner Management Class Methods and polutate the "Method" Listbox
                    foreach (MethodData mm in mgmtClass.Methods)
                    {
                        cmbMethod.Items.Add(mm.Name);
                    }
                    cmbMethod.SelectedIndex = 0;    //Select the first Item in the Method Listbox

                    // Enumurate Management class properties and populate the "Properties" Listbox
                    foreach (PropertyData pp in mgmtClass.Properties)
                    {
                        lstProperties.Items.Add(pp.Name);
                    }
                    this.Update();
                    return true;
                }
                // Generic All Exception Handler
                catch (Exception)
                {
                    return false;
                }
            }
        }

        private void Discover()
        {
            lock (this)
            {
                // Reset and setup controls on the form
                blnDiscovered = false;
                ClearAll();
                UpdateDiscoverStatus("Discovering...");

                try
                {
                    Cursor.Current = Cursors.WaitCursor;        //Change Cursor Icon

                    objSearcher = new ManagementObjectSearcher(mgmtScope,
                        new WqlObjectQuery("SELECT * FROM Symbol_BarcodeScanner"));

                    // Enumurate the ManagementObjectSearcher and populate the PartNumber 
                    //(Hidden) and Serial Number (Hidden) List Boxes
                    foreach (ManagementObject mo in objSearcher.Get())
                    {
                        no_of_Scanners++;
                        // Extract Model number from the Partnumber
                        string tempModel = mo["PartNumber"].ToString();
                        if (tempModel.IndexOf("-") > 0)
                        {
                            tempModel = tempModel.Substring(0, tempModel.IndexOf("-"));
                        }
                        else
                        {
                            if (tempModel.Length >= 7)
                            {
                                tempModel = tempModel.Substring(0, 7);
                            }
                        }
                        partCollection.Add(mo["PartNumber"].ToString());

                        serialCollection.Add(mo["SerialNumber"].ToString());

                        // Add Model number to the Model Listbox if it does not already contain the model number
                        if (cmbModel.Items.Contains(tempModel) == false)
                        {
                            cmbModel.Items.Add(tempModel);
                        }
                    }
                    if (no_of_Scanners > 0)
                    {
                        strComputer = txtComputer.Text.Trim();
                        cmbModel.Enabled = true;
                        cmbSerialFiltered.Enabled = true;
                        ControlFocus(true);
                    }
                    else
                    {
                        strComputer = ".";
                        ClearAll();
                        ControlFocus(false);
                        ControlFocus(true, groupBoxDiscover.Name);
                    }

                    // Select the first Model. Used to fire the cmdModel_SelectedIndexChanged event to
                    if (cmbModel.Items.Count > 0)
                        cmbModel.SelectedIndex = 0;

                    if (no_of_Scanners == 1)
                    {
                        lblDiscoverStatus.Text = no_of_Scanners.ToString() + " Scanner Found";
                    }
                    else if (no_of_Scanners > 1)
                    {
                        lblDiscoverStatus.Text = no_of_Scanners.ToString() + " Scanners Found";
                    }
                    else
                    {
                        lblDiscoverStatus.Text = "No Scanners Found";
                    }
                }
                // Generic All Exception Handler
                catch (Exception)
                {
                    ClearAll();
                    lblDiscoverStatus.Text = "Exception occurred. Please retry";
                }
                Cursor.Current = Cursors.Arrow;
            }

        }


        // Method Combo Box Index Changed Event
        // Used to clear and populate the the parameter listbox with the parameters applicable
        // to the current Method
        private void cmbMethod_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ClearStatus();
            UpdateParameters();
        }

        //Execute Button Click Event
        private void btnExecute_Click(object sender, System.EventArgs e)
        {
            ClearStatus();
            ExecuteWMI();
        }

        // Clean up code executed before the form is closed. objSeacher is disposed prior to exiting
        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StopEventListeners();
            if (objSearcher != null)
                objSearcher.Dispose();
            Thread.Sleep(1000);
        }

        // Property Button Click Event. 
        // Implementation is done in the QueryProperties() Function
        private void btnGetProperty_Click(object sender, System.EventArgs e)
        {
            ClearStatus();
            QueryProperties();
        }


        // Properties Listbox's Double Click Event
        // Implementation is in the QueryProperties() Function
        private void lstProperties_DoubleClick(object sender, System.EventArgs e)
        {
            QueryProperties();
        }

        // Function QueryProperties()
        // Called from the events lstProperties_DoubleClick and GetProperty_Click
        // Used to query the current setting from the selected scanner for the property(ies)
        // selected from the Properties List Box
        private void QueryProperties()
        {
            if (this.lstProperties.SelectedItems.Count == 0)
            {
                lblQueryStatus.ForeColor = Color.Blue;
                lblQueryStatus.Text = "Select one or more properties and Try Again";
                return;

            }

            try
            {
                ManagementObject o = new ManagementObject();
                o.Scope = mgmtScope;
                o.Path = new ManagementPath("Symbol_BarcodeScanner.PartNumber='" 
                    + strPartNumber + "',SerialNumber='" + strSerialNumber + "'");

                // Clean Status codes
                ClearStatus();

                // Check if the SerialNumber is identical (Used to create an exception if the WMI Path is invalid)
                // The exception is handled below
                if (o["SerialNumber"].ToString() == strSerialNumber)
                {
                    // Update Management Textbox
                    txtOutMgmt.AppendText("\r\n\r\n-----------------------------------------------------------------------------------------------------------\r\n");
                    txtOutMgmt.AppendText("Part Number\t: ");
                    txtOutMgmt.AppendText(o["PartNumber"].ToString());
                    txtOutMgmt.AppendText("\r\nSerial Number\t: ");
                    txtOutMgmt.AppendText(o["SerialNumber"].ToString());
                    txtOutMgmt.AppendText("\r\nQuery Results\t:\r\n");

                    // Invoke the GetPropertyValue method on each selected item in the Properties Listbox and
                    // display on the Management Textbox
                    foreach (object property in this.lstProperties.SelectedItems)
                    {
                        txtOutMgmt.AppendText("\r\n");
                        txtOutMgmt.AppendText(property.ToString());
                        txtOutMgmt.AppendText("\t= ");
                        Object objVal = o.GetPropertyValue(property.ToString());
                        if (objVal != null)
                        {
                            txtOutMgmt.AppendText(objVal.ToString());
                        }
                    }
                }

                // Undate Status Textbox
                lblQueryStatus.ForeColor = Color.Blue;
                lblQueryStatus.Text = "Succeeded";
                txtOutMgmt.AppendText("\r\n-----------------------------------------------------------------------------------------------------------\r\n");
            }
            // ManagementException Exception Handler
            // Invoked if the Scanner is not connected to the system at the time command is executed.
            catch (ManagementException )
            {
                lblQueryStatus.ForeColor = Color.Red;
                lblQueryStatus.Text = "Failed";
            }
            // Generic Exception Handler
            catch (Exception)
            {
                lblQueryStatus.ForeColor = Color.Red;
                lblQueryStatus.Text = "Failed";
            }
        }

        // Clear Button Event
        // Used to clear the Management Data Textbox and the Barcode Data Textbox.
        private void btnClearOut_Click(object sender, System.EventArgs e)
        {
            txtOutMgmt.Clear();
            txtFirmwareProgress.Clear();
        }

        // Retrieve Button Click Event
        // Used to retrieve all the storeable attributes from the scanner's property list.
        // Also populate the Quick Parameter Set Listbox with the configurable parameters.
        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            ClearStatus();
            RetrieveParameters(RetrieveMethod.Clone);
        }

        // Push Button Click Event
        // Used to push all the storeable attributes stored in the clipboard to the 
        // selected Scanner
        private void btnPush_Click(object sender, EventArgs e)
        {
            ClearStatus();
            OpenPushWindow();
        }

        // SavetoFile Click Event
        // Used to save the content in the clipboard to a user specified file.
        // Can be used after retrieving the data from the scanner to clipboard to save the settings to a XML/text file
        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            SaveSettingsToFile();
        }

        // Quick Set Parameter List Box Index Change Event
        // Used to change the values in the Value field based on the data type the selected parameter        
        private void cmbQuickSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear the Values field
            cmbQuickSetVal.Items.Clear();

            // If type is Boolean, change style to a dropdown box and populate with "True" and "False"
            if (cmbQuickSetData.Items[cmbQuickSet.SelectedIndex].ToString().Substring(0, 1) == "F")
            {
                cmbQuickSetVal.Items.Add("True");
                cmbQuickSetVal.Items.Add("False");
                cmbQuickSetVal.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else
            // Change the style to a text box
            {
                cmbQuickSetVal.DropDownStyle = ComboBoxStyle.Simple;
            }
            cmbQuickSetVal.Text = cmbQuickSetData.Items[cmbQuickSet.SelectedIndex].ToString().Substring(cmbQuickSetData.Items[cmbQuickSet.SelectedIndex].ToString().IndexOf("_") + 1);
        }

        // Set Quick Parameter Button Click Event
        // Used to set a parameter in the Quick parameter List, Once the parameter and the value is given
        private void btnSetPara_Click(object sender, EventArgs e)
        {
            ClearStatus();
            QuickSetParameter();
        }

        // QuickSet_Click Event
        // Used to inform the user to click 'Retieve' button to ppopulate the list if the list is empty
        private void cmbQuickSet_Click(object sender, EventArgs e)
        {
            if (cmbQuickSet.Items.Count < 1)
            {
                MessageBox.Show("Click 'Retrieve' button to populate the List");
            }
        }

        // RetrieveFile Click Event
        // Used to import scanner settings from a file to the clipboard.
        private void btnRetrieveFile_Click(object sender, EventArgs e)
        {
            // Open Dialog Box Set up
            openFileDialogMain.Filter = "XML files (*.xml)|*.xml|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            // Check if the Configuration file path exsist and set the default path to it. 
            // If the Configuration file path is not available set default path to current directory
            if (System.IO.Directory.Exists(System.Environment.CurrentDirectory + "\\Saved Configuration Files"))
            {
                openFileDialogMain.InitialDirectory = System.Environment.CurrentDirectory + "\\Saved Configuration Files";
            }
            else
            {
                openFileDialogMain.InitialDirectory = System.Environment.CurrentDirectory;
            }
            openFileDialogMain.FilterIndex = 1;
            openFileDialogMain.RestoreDirectory = true;

            // If user have selected a valid file and clicked OK button continue else exit event
            if (openFileDialogMain.ShowDialog() == DialogResult.OK)
            {
                if (System.IO.File.Exists(openFileDialogMain.FileName))
                {
                    // Read content to a temporary string and copy the content to the clipboard
                    String tempStr = "";
                    StreamReader sr = new StreamReader(openFileDialogMain.FileName);
                    tempStr += sr.ReadToEnd();
                    sr.Close();
                    Clipboard.SetDataObject(tempStr);
                    MessageBox.Show("Settings Copied to clipboard. Click 'Push' to send data to a scanner", "Success", MessageBoxButtons.OK);
                }
            }
        }

        // QuickSetRetrieve_Click event
        // Used to get the quickset parameter list relevant to the current scanner
        private void btnQuickSetRetrieve_Click(object sender, EventArgs e)
        {
            ClearStatus();
            RetrieveParameters(RetrieveMethod.Quickset);
        }

        // Main Form Load Event
        private void frmMain_Load(object sender, System.EventArgs e)
        {
            // Initilized the toolTipMain control to display Tool Tips
            toolTipMain.SetToolTip(btnRetrieve, "Retrieve settings from scanner and save to clipboard");
            toolTipMain.SetToolTip(btnPush, "Program all settings in clipboard to scanner");
            toolTipMain.SetToolTip(btnRetrieveFile, "Retrieve settings from file and save to clipboard");
            toolTipMain.SetToolTip(btnSaveToFile, "Save settings in clipboard to file");
            toolTipMain.SetToolTip(btnQuickSetRetrieve, "Retrieve Quick Set Parameter List");
            toolTipMain.SetToolTip(btnSetPara, "Set Current Parameter to the given value");
            toolTipMain.SetToolTip(btnDiscover, "Click Discover to get information about all scanners connected to computer");
            toolTipMain.SetToolTip(btnConnect, "Connect to localhost or remote computer");
        }

        // Model Combobox index changed event
        // Used to populate the serial numbers combobox with the serial numbers of the scanners 
        // related to the model selected
        private void cmbModel_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // Clear the Serial number combo box
            cmbSerialFiltered.Items.Clear();
            // Enumurate the cmbPart combobox and add serial numbers relevant to the selected model
            for (int i = 0; i < partCollection.Count; i++)
            {
                try
                {
                    if (partCollection[i].Substring(0, cmbModel.Text.Length) == cmbModel.Text)
                    {
                        cmbSerialFiltered.Items.Add(serialCollection[i]);
                    }
                }
                catch
                {
                    ;
                }
            }
            // Fire the SerialFiltered_SelectedIndexChanged event.
            cmbSerialFiltered.SelectedIndex = 0;
        }

        // SerialFiltered SelectedIndexChanged Event
        // Used to get the firmware and date of manufacture of the selected scanner from the 
        // Serial number combo box
        private void cmbSerialFiltered_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            int i = 0;
            for (i = 0; i < partCollection.Count; i++)
            {
                // Enumurate the SerialNumber and PartNumber hidden comboboxes and update the
                // global variables strPartNumber and strSerialNumber

                
                // Make this check, since certain scanners have XXXXXXXXX as model
                if (partCollection[i].Length < cmbModel.Text.Length)
                {   
                    continue;
                }

                if (serialCollection[i] == cmbSerialFiltered.Text.ToString() &&
                    partCollection[i].Substring(0, cmbModel.Text.Length) == cmbModel.Text)

                {
                    // Update Global Variables         
                    strPartNumber = partCollection[i].Trim();
                    strSerialNumber = serialCollection[i].Trim();
                    this.Text = "Scanner WMI Test - " + strComputer + " - " + strPartNumber + " - " + strSerialNumber;    // Update the Form's Caption
                    if (strLastModel != cmbModel.Text.ToString())
                    {
                        cmbQuickSet.Items.Clear();
                        cmbQuickSetData.Items.Clear();
                        cmbQuickSetVal.Items.Clear();
                        foreach (Control c in groupBoxQuickSet.Controls)
                        {
                            if (c.Name != btnQuickSetRetrieve.Name)
                            {
                                c.Enabled = false;
                            }
                        }
                        strLastModel = cmbModel.Text.ToString();
                    }
                    blnDiscovered = true;
                    ClearStatus();
                    // Exit enumeration
                    break;
                }
            }
            this.Update();
            // Change Cursor to Wait Cursor
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                ManagementObject o = new ManagementObject();
                o.Scope = mgmtScope;
                o.Path = new ManagementPath("Symbol_BarcodeScanner.PartNumber='" +
                   strPartNumber + "',SerialNumber='" + strSerialNumber + "'");

                //// Check if the SerialNumber is equalant (Used to create an exception if the WMI Path is invalid)
                // The exception is handled below
                if (o["SerialNumber"].ToString() == strSerialNumber)
                {
                    // Get the Manufacture Date and Firmware Version	
                    Object objVal = o.GetPropertyValue("DateOfManufacture");
                    if (objVal != null)
                    {
                        txtDOM.Text = objVal.ToString();
                    }
                    objVal = o.GetPropertyValue("FirmwareVersion");
                    if (objVal != null)
                    {
                        txtFirmware.Text = objVal.ToString();
                    }
                    objVal = o.GetPropertyValue("FirmwareUpdateStatus");
                    if (objVal != null)
                    {
                        string fwupStatus = objVal.ToString();
                        if (fwupStatus.Contains("Progress"))
                        {
                            objVal = o.GetPropertyValue("FirmwareUpdateBlockCount");
                            string blocks = objVal.ToString();
                            //txtFirmwareProgress.Text = "Progress - Block:" + blocks;
                            UpdateFirmwareDownloadProgress("Progress - Block:" + blocks);
                        }
                        else
                        {
                            //txtFirmwareProgress.Text = fwupStatus;
                            UpdateFirmwareDownloadProgress(fwupStatus);
                        }
                    }
                }
            }
            // Generic Exception Handler
            catch (Exception)
            {
                // Exception could occur if a scanner is disconnected while
                // executing this function.
                // Re-discover scanners
               // this.BeginInvoke(new MethodInvoker(Discover));
                serialCollection.RemoveAt(i) ;
                partCollection.RemoveAt(i);
                no_of_Scanners -= 1;
                cmbSerialFiltered.Items.Remove(cmbSerialFiltered.Text.ToString());
                cmbModel.SelectedIndex = 0;
                cmbSerialFiltered.SelectedIndex = 0;
            }
            Cursor.Current = Cursors.Default;
        }

        
        private void UpdateParameters()
        {
            ManagementBaseObject inparams = mgmtClass.GetMethodParameters(cmbMethod.Text.Trim());
            cmbIN.Items.Clear();
            txtIN.Text = "";
            txtIN.Update();
            // Enumarate the Properties and poplulate the Listbox if the current method have one or more 
            // paramaeters
            if (inparams != null)
            {
                foreach (PropertyData md in inparams.Properties)
                {
                    cmbIN.Items.Add(md.Name);
                }
                cmbIN.SelectedIndex = 0;
            }

            // If the Method is "GetAllAttributes" disable the parameter combo, value textbox
            if (cmbMethod.Text.Trim() == "GetAllAttributes")
            {
                txtIN.Enabled = false;
                cmbIN.Enabled = false;
                lblInParam.Enabled = false;
                lblInput.Enabled = false;
            }
            else
            {
                txtIN.Enabled = true;
                cmbIN.Enabled = true;
                lblInParam.Enabled = true;
                lblInput.Enabled = true;
            }

            // Based on the default methods available for WMI Scanner fill the Input Parameter Textbox with
            // sample XML queries
            if (cmbMethod.Text.Trim() == "GetAttributes")
            {
                txtIN.Text = "<attrib_list>533,534</attrib_list>";
            }
            else if (cmbMethod.Text.Trim() == "SetAttributes" || cmbMethod.Text.Trim() == "StoreAttributes")
            {
                txtIN.Text = "<attrib_list>\r\n"
                    + "\t<attribute>\r\n"
                    + "\t\t<id>0</id>\r\n" +
                    "\t\t<datatype>F</datatype>\r\n"
                    + "\t\t<value>False</value>\r\n"
                    + "\t</attribute>\r\n"
                    + "</attrib_list>\r\n";
            }
            else if (cmbMethod.Text.Trim() == "ControlBeeperLED")
            {
                txtIN.Text = "1";
            }
            else if (cmbMethod.Text.Trim() == "UpdateFirmware")
            {
                if (Dns.GetHostName().ToString().ToUpper() == strComputer.ToUpper() |
                    strComputer.ToUpper() == "LOCALHOST" |
                    strComputer == "127.0.0.1" |
                    strComputer == ".")
                {
                    openFileDialogMain.Filter = "DAT files (*.DAT)|*.DAT|All files (*.*)|*.*";
                    // Check if the Configuration file path exsist and set the default path to it. 
                    // If the Configuration file path is not available set default path to current directory
                    if (System.IO.Directory.Exists(System.Environment.CurrentDirectory + "\\..\\Sample Firmware Files"))
                    {
                        openFileDialogMain.InitialDirectory = System.Environment.CurrentDirectory + "\\..\\Sample Firmware Files";
                    }
                    else
                    {
                        openFileDialogMain.InitialDirectory = System.Environment.CurrentDirectory;
                    }
                    openFileDialogMain.FilterIndex = 1;
                    openFileDialogMain.RestoreDirectory = true;

                    // If user have selected a valid file and clicked OK button continue else exit event
                    if (openFileDialogMain.ShowDialog() == DialogResult.OK)
                    {
                        if (System.IO.File.Exists(openFileDialogMain.FileName))
                        {
                            txtIN.Text = openFileDialogMain.FileName.ToString();
                        }
                    }
                    else
                    {
                        txtIN.Text = "D:\\Scanner\\Firmware\\DS6707\\NBRPUCAI.DAT";
                    }
                }
                else
                {
                    MessageBox.Show("Please Specify the file location of the firmware file relative to the remote computer\r\n\r\n" +
                        "Ex: D:\\Scanner\\Firmware\\DS6707\\NBRPUCAI.DAT", "Remote Computer Detected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIN.Text = "D:\\Scanner\\Firmware\\LS4278\\NBRACAA8.dat";
                }
            }
            else if (cmbMethod.Text.Trim() == "UpdateAttribMetaFile")
            {
                txtIN.Text = "D:\\Temp\\ScannerAttribMetaData_new.xml";
            }
        }

        private void ClearStatus()
        {
            lblCloneStatus.Text = "";
            lblExecStatus.Text = "";
            lblQueryStatus.Text = "";
            lblQuickSetStatus.Text = "";
            this.Update();
        }

        // Retrieves parameters for cloning and quick setting
        private void RetrieveParameters(RetrieveMethod inParameterMethod)
        {
            Cursor.Current = Cursors.WaitCursor;        //Change Cursor Icon			
            System.Windows.Forms.Label lblStatus;
            if (inParameterMethod == RetrieveMethod.Clone)
            {
                lblStatus = lblCloneStatus;
            }
            else
            {
                lblStatus = lblQuickSetStatus;
            }
            try
            {
                // Create a new ManagementObject based on the current Serial Number and the Part Numebr
                ManagementObject o = new ManagementObject();
                o.Scope = mgmtScope;
                o.Path = new ManagementPath("Symbol_BarcodeScanner.PartNumber='" + strPartNumber + "',SerialNumber='" + strSerialNumber + "'");

                // Check if the SerialNumber is equalant (Used to create an exception if the WMI Path is invalid)
                // The exception is handled below
                if (o["SerialNumber"].ToString() == strSerialNumber)
                {
                    // Create ManagementBaseObject and get the parameters to the Method "GetAllAttributes"
                    ManagementBaseObject inParams = o.GetMethodParameters("GetAllAttributes");
                    // Create ManagementBaseObject and store the result from the InvokeMethod for "GetAllAttributes"
                    ManagementBaseObject outparams = o.InvokeMethod("GetAllAttributes", inParams, null);

                    if (outparams != null)
                    {
                        // Create Temporary XML File and Write the Attributes of the return ManagementBaseObject to it
                        using (StreamWriter sw = new StreamWriter(Path.GetTempPath()+"temp.xml"))
                        {
                            sw.Write((string)outparams["Attributes"].ToString());
                        }
                        string attributeList = "";

                        // Create New Dataset to Open the Temporary XML file as a dataset
                        DataSet dsGetAll = new DataSet();

                        // Read the XML file to the Dataset
                        dsGetAll.ReadXml(Path.GetTempPath() + "temp.xml");

                        // Append to the attributeList string all the Attribute ID's available 
                        // for the currently selected WMI scanner
                        foreach (DataRow dr in dsGetAll.Tables[0].Rows)
                        {
                            attributeList += dr["attribute_text"].ToString() + ",";
                        }
                        // Remove the Last ',' from the attributeList string
                        attributeList = attributeList.Substring(0, attributeList.Length - 1);
                        // Add the prefix and suffix "<attrib_list>" and "</attrib_list>" 
                        attributeList = "<attrib_list>" + attributeList + "</attrib_list>";

                        // Create ManagementBaseObject and get the parameters to the Method "GetAttributes"
                        inParams = o.GetMethodParameters("GetAttributes");
                        // Fill the Parameter "attNumberList" with the attributeList string
                        inParams["attNumberList"] = attributeList;

                        // Invoke the "GetAttributes" Method and save the result to a new ManagementBaseObject
                        outparams = o.InvokeMethod("GetAttributes", inParams, null);
                        if (outparams != null)
                        {
                            // Create Temporary XML File and Write the Attributes of the return ManagementBaseObject to it
                            using (StreamWriter sw = new StreamWriter(Path.GetTempPath() + "temp2.xml"))
                            {
                                sw.Write((string)outparams["attValueList"].ToString());
                            }

                            // Create New Dataset to Open the Temporary XML file as a dataset
                            DataSet dsAttr = new DataSet();

                            // Read the XML file to the Dataset
                            dsAttr.ReadXml(Path.GetTempPath() + "temp2.xml");

                            attributeList = "";
                            // Clear the Quick Parameter Set Combo box and the hidden Quick Parameter Set Data Combo box 
                            cmbQuickSet.Items.Clear();
                            cmbQuickSetData.Items.Clear();
                            bool blnBluetoothPinCode = false;
                            foreach (DataRow dr in dsAttr.Tables[0].Select("permission='RWP' OR permission='RW'"))
                            {
                                // Workaround: To remove the 392/552 Attribute IDs from the query. (Bug)
                                /*if (chkTestMode.Checked == true && dr["id"].ToString().Equals("392"))
                                {
                                    continue;
                                }*/
                                if (dr["id"].ToString().Equals("552"))
                                {
                                    blnBluetoothPinCode = true;
                                    continue;
                                }

                                // Add the Attribute to the Quick Parameter Set Combobox if the data type is not
                                // "A" which represent ADF Rules (Cannot be set using WMI Codes)
                                if (!dr["datatype"].ToString().Equals("A"))
                                {
                                    if (dr["name"].ToString().Length > 3)
                                    {
                                        cmbQuickSet.Items.Add(dr["name"].ToString().Substring(1, dr["name"].ToString().Length - 2));
                                    }
                                    else
                                    {
                                        cmbQuickSet.Items.Add(dr["id"].ToString());
                                    }
                                    // Add a entry to the hidden data combo box with the data type and the ID of the attribute 
                                    cmbQuickSetData.Items.Add(dr["datatype"].ToString() + "-" + dr["id"].ToString() + "_" + dr["value"].ToString());
                                }
                                // Append to the attributeList string all the Attribute ID's with ("permission='RWP' OR permission='RW'")
                                // for the currently selected WMI scanner
                                attributeList += dr["id"].ToString() + ",";
                            }
                            if (inParameterMethod == RetrieveMethod.Clone)
                            {
                                if (blnBluetoothPinCode)
                                {
                                    attributeList += "552,";
                                }

                                // Format the attributList string
                                attributeList = attributeList.Substring(0, attributeList.Length - 1);
                                attributeList = "<attrib_list>" + attributeList + "</attrib_list>";

                                // Create ManagementBaseObject and get the parameters to the Method "GetAttributes"
                                inParams = o.GetMethodParameters("GetAttributes");
                                // Fill the Parameter "attNumberList" with the attributeList string
                                inParams["attNumberList"] = attributeList;

                                // Invoke the "GetAttributes" Method and save the result to a new ManaementBaseObject
                                outparams = o.InvokeMethod("GetAttributes", inParams, null);
                                if (outparams != null)
                                {
                                    // Clear the Clipboard and save the output to the clipboard as a string
                                    Clipboard.SetDataObject(outparams["attValueList"].ToString());
                                }
                            }
                            // Restore the mouse icon to the arrow
                            Cursor.Current = Cursors.Arrow;

                            // Update Management Textbox
                            txtOutMgmt.AppendText("\r\n\r\n-----------------------------------------------------------------------------------------------------------\r\n");
                            txtOutMgmt.AppendText("Serial Number\t: ");
                            txtOutMgmt.AppendText(o["SerialNumber"].ToString());
                            txtOutMgmt.AppendText("\r\nRetrieved " + (inParameterMethod == RetrieveMethod.Clone ? "all settings and " : "") + "quick parameter list");
                            txtOutMgmt.AppendText("\r\nReturn Value\t: ");

                            string strRet = outparams["ReturnValue"].ToString();
                            txtOutMgmt.AppendText(strRet);
                            if (strRet.Equals("0"))     // ReturnValue=0 means the method invoked succesfully
                            {
                                if (inParameterMethod == RetrieveMethod.Clone)
                                {
                                    txtOutMgmt.AppendText("\r\nInfo :\tRetieved All Data from the Scanner to the Clipboard.\r\n\tSelect a scanner and click Push to Clone");
                                }
                                lblStatus.ForeColor = Color.Blue;
                                lblStatus.Text = "Succeeded";
                                cmbQuickSet.SelectedIndex = 0;
                                foreach (Control c in groupBoxQuickSet.Controls)
                                {
                                    c.Enabled = true;
                                }
                            }
                            else                        // Method failed
                            {
                                lblStatus.ForeColor = Color.Red;
                                lblStatus.Text = "Failed";
                            }
                        }
                    }
                }
                // Restore the mouse icon to the arrow
                Cursor.Current = Cursors.Arrow;
            }
            // ManagementException Exception Handler
            // Invoked if the Scanner is not connected to the system at the time command is executed.
            catch (ManagementException)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Failed";
            }
            catch (XmlException err)
            {
                MessageBox.Show("Illegal Characters Found while Passing XML data sent from the scanner\r\nPlease remove, reattach the scanner and try again\r\n\r\n" + "Error :" + err.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Failed";
            }
            // Generic Exception Handler
            catch (Exception)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Failed";
            }
        }



        private void ExecuteWMI()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                // Create a new ManagementObject based on the current Serial Number and the Part Numebr
                ManagementObject o = new ManagementObject();
                o.Scope = mgmtScope;
                o.Path = new ManagementPath("Symbol_BarcodeScanner.PartNumber='" + strPartNumber + "',SerialNumber='" + strSerialNumber + "'");

                // Check if the SerialNumber is equalant (Used to create an exception if the WMI Path is invalid)
                // The exception is handled below
                if (o["SerialNumber"].ToString() == strSerialNumber)
                {
                    // Update Management Textbox
                    txtOutMgmt.AppendText("\r\n\r\n-----------------------------------------------------------------------------------------------------------\r\n");
                    txtOutMgmt.AppendText("Part Number\t: ");
                    txtOutMgmt.AppendText(o["PartNumber"].ToString());
                    txtOutMgmt.AppendText("\r\nSerial Number\t: ");
                    txtOutMgmt.AppendText(o["SerialNumber"].ToString());
                    txtOutMgmt.AppendText("\r\nMethod Invoked\t: ");
                    txtOutMgmt.AppendText(cmbMethod.Text.Trim());

                    // Get the Method's Parameters and populate the parameter with the text in the 'In' textbox
                    ManagementBaseObject inParams = o.GetMethodParameters(cmbMethod.Text.Trim());
                    if (inParams != null)
                    {
                        inParams[cmbIN.Text.Trim()] = txtIN.Text.Trim();
                        txtOutMgmt.AppendText("\r\nInput Param\t: \r\n");
                        txtOutMgmt.AppendText(txtIN.Text);
                    }

                    // Invoke the method and save the result to a new ManaementBaseObject
                    ManagementBaseObject outparams = o.InvokeMethod(cmbMethod.Text.Trim(), inParams, null);

                    txtOutMgmt.AppendText("\r\nReturn Value\t: ");

                    // Check if an Output resulted from the Invoked Method
                    if (outparams != null)
                    {
                        string strRet = outparams["ReturnValue"].ToString();
                        txtOutMgmt.AppendText(strRet);
                        // ReturnValue=0 means the method invoked succesfully
                        if (strRet.Equals("0"))     
                        {
                            if (cmbMethod.Text.Trim() == "UpdateFirmware")
                            {
                                ;
                            }
                            else
                            {
                                lblExecStatus.ForeColor = Color.Blue;
                                lblExecStatus.Text = "Succeeded";
                            }
                        }
                        else // Method failed
                        {
                            lblExecStatus.ForeColor = Color.Red;
                            lblExecStatus.Text = "Failed";
                        }

                        // Display all the return values to the Management Textbox except the ReturnValue Data
                        foreach (PropertyData md in outparams.Properties)
                        {
                            if (md.Name != "ReturnValue")
                            {
                                txtOutMgmt.AppendText("\r\n");
                                txtOutMgmt.AppendText(md.Name);
                                txtOutMgmt.AppendText("\t:\r\n");


                                    txtOutMgmt.AppendText(outparams[md.Name].ToString());
                                }
                            }
                        }
                    }
                }
            
            // ManagementException Exception Handler
            // Exception occurs if the Scanner is not connected to the system at the time command is executed.
            catch (ManagementException)
            {
                lblExecStatus.ForeColor = Color.Red;
                lblExecStatus.Text = "Failed";
            }
            // Generic Exception Handler
            catch (Exception)
            {
                lblExecStatus.ForeColor = Color.Red;
                lblExecStatus.Text = "Failed";
            }
            txtOutMgmt.AppendText("\r\n-----------------------------------------------------------------------------------------------------------\r\n");
            Cursor.Current = Cursors.Arrow;
        }

       

        private void OpenPushWindow()
        {

            // Extract the Clipboard Data 
            IDataObject iData = Clipboard.GetDataObject();

            // Validate the content in the clipboard to check if the content is text
            if (iData.GetDataPresent(DataFormats.Text) == true)
            {
                string ClipboardText = (string)iData.GetData(DataFormats.Text).ToString();
                ClipboardText = ClipboardText.Replace("<name></name>", String.Empty);
                ClipboardText = ClipboardText.Replace("<permission>RWP</permission>", String.Empty);
                if (ClipboardText.Length > 13)
                {
                    // Create a new ManagementObject based on the current Serial Number and the Part Numebr

                    // Validate the content in the clipboard to check if its in valid format
                    if (ClipboardText.Substring(0, 13).Equals("<attrib_list>"))
                    {
                        try
                        {

                            frmCloneWiz frmWiz = new frmCloneWiz();
                            frmWiz.SetScope(ref mgmtScope);
                            for (int i = 0; i < serialCollection.Count; i++)
                            {
                                frmWiz.chkLstScanners.Items.Add(partCollection[i] + "\\" + serialCollection[i]);
                            }
                            frmWiz.strWizModel = cmbModel.Text;
                            frmWiz.strWizComputer = strComputer;
                            frmWiz.strParameters = ClipboardText;
                            frmWiz.ShowDialog(this);
                        }
                        // Generic Exception Handler
                        catch (Exception err)
                        {
                            MessageBox.Show("Unknown Error: " + err.Message.ToString());
                            lblCloneStatus.ForeColor = Color.Red;
                            lblCloneStatus.Text = "Failed";
                        }
                    }
                    else        // Data in the Clipboard is not an Attribute List
                    {
                        MessageBox.Show("Data in Clipboard is not an Attribute List.\nPlease Retrieve data and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else            // Data in the clipboard is not text or the length is not correct
            {
                MessageBox.Show("Data in Clipboard is not an Attribute List.\nPlease Retrieve data and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveSettingsToFile()
        {
            saveFileDialogMain.Filter = "XML files (*.xml)|*.xml|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (System.IO.Directory.Exists(System.Environment.CurrentDirectory + "\\Saved Configuration Files"))
            {
                saveFileDialogMain.InitialDirectory = System.Environment.CurrentDirectory + "\\Saved Configuration Files";
            }
            else
            {
                saveFileDialogMain.InitialDirectory = System.Environment.CurrentDirectory;
            }
            saveFileDialogMain.FilterIndex = 1;
            saveFileDialogMain.RestoreDirectory = true;

            // Extract the Clipboard Data 
            IDataObject iData = Clipboard.GetDataObject();

            // Check if the Clipboard contains Text
            if (iData.GetDataPresent(DataFormats.Text) == true)
            {
                // Show the Dialog box and if the user click the OK button save the content in the clipboard to the file
                if (saveFileDialogMain.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialogMain.FileName))
                    {
                        sw.Write((string)iData.GetData(DataFormats.Text).ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Content in the Clipboard is not of type Text.\nSave Aborted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void QuickSetParameter()
        {
            // Create a new ManagementObject based on the current Serial Number and the Part Numebr
            ManagementObject o = new ManagementObject();
            o.Scope = mgmtScope;
            o.Path = new ManagementPath("Symbol_BarcodeScanner.PartNumber='" +
               strPartNumber + "',SerialNumber='" + strSerialNumber + "'");

            try
            {
                // Check if the SerialNumber is equalant (Used to create an exception if the WMI Path is invalid)
                // The exception is handled below
                if (o["SerialNumber"].ToString() == strSerialNumber)
                {
                    // Update Management Textbox
                    txtOutMgmt.AppendText("\r\n\r\n-----------------------------------------------------------------------------------------------------------\r\n");
                    txtOutMgmt.AppendText("Serial Number\t: ");
                    txtOutMgmt.AppendText(o["SerialNumber"].ToString());
                    txtOutMgmt.AppendText("\r\nSet Parameter\t: ");
                    txtOutMgmt.AppendText(cmbQuickSet.Text);
                    txtOutMgmt.AppendText("\r\nReturn Value\t: ");

                    // Create ManagementBaseObject and get the parameters to the Method "StoreAttributes"
                    ManagementBaseObject inParams = o.GetMethodParameters("StoreAttributes");

                    if (inParams != null)
                    {
                        // Create the XML tags with the relevant data to be set as the parameter value for the StoreAtrribute Method
                        string tempPara = cmbQuickSetData.Items[cmbQuickSet.SelectedIndex].ToString();
                        string tempString =
                            "<attrib_list>" +
                            "<attribute>" +
                            "<id>" +
                            tempPara.Substring(2, tempPara.IndexOf("_") - 2) +
                            "</id>" +
                            "<datatype>" +
                            tempPara.Substring(0, 1) +
                            "</datatype>" +
                            "<value>" +
                            cmbQuickSetVal.Text.ToString() +
                            "</value>" +
                            "</attribute>" +
                            "</attrib_list>";
                        inParams["attributeSettings"] = tempString;     // Set the parameter to the tempString

                        // Invoke the method "StoreAttributes" and retrieve the Result
                        ManagementBaseObject outparams = o.InvokeMethod("StoreAttributes", inParams, null);

                        // Display Return value
                        if (outparams != null)
                        {
                            string strRet = outparams["ReturnValue"].ToString();
                            txtOutMgmt.AppendText(strRet);
                            if (strRet.Equals("0"))     // ReturnValue=0 means the method invoked succesfully
                            {
                                lblQuickSetStatus.ForeColor = Color.Blue;
                                lblQuickSetStatus.Text = "Succeeded";
                                cmbQuickSetData.Items[cmbQuickSet.SelectedIndex] = tempPara.Substring(0, tempPara.IndexOf("_")) + "_" + cmbQuickSetVal.Text.ToString();
                            }
                            else                        // Method failed
                            {
                                lblQuickSetStatus.ForeColor = Color.Red;
                                lblQuickSetStatus.Text = "Failed";
                            }
                        }
                        else                            // Method failed
                        {
                            lblQuickSetStatus.ForeColor = Color.Red;
                            lblQuickSetStatus.Text = "Failed";
                        }
                    }
                }
            }
            // ManagementException Exception Handler
            // Invoked if the Scanner is not connected to the system at the time command is executed.                    
            catch (ManagementException)
            {
                lblQuickSetStatus.ForeColor = Color.Red;
                lblQuickSetStatus.Text = "Failed";
            }
            // Generic Exception Handler
            catch (Exception err)
            {
                MessageBox.Show("Unknown Error: " + err.Message.ToString());
                lblQuickSetStatus.ForeColor = Color.Red;
                lblQuickSetStatus.Text = "Failed";
            }
        }

        // Disable all controls except groupBox1, and enable all
        private void ControlFocus(bool blnEnable)
        {
            foreach (Control c in this.Controls)
            {
                if (blnEnable == false)
                {
                    if ((c.GetType() == typeof(System.Windows.Forms.GroupBox)) &
                        c.Name != groupBoxConnect.Name)
                    {
                        c.Enabled = blnEnable;
                    }
                }
                else
                {
                    if (c.GetType() == typeof(System.Windows.Forms.GroupBox))
                    {
                        c.Enabled = blnEnable;
                    }
                }
            }
        }

        // Enable or disable only given groupbox
        private void ControlFocus(bool blnEnable, string selectGroupBox)
        {
            foreach (Control c in this.Controls)
            {
                if ((c.GetType() == typeof(System.Windows.Forms.GroupBox)) &
                   c.Name == selectGroupBox)
                {
                    c.Enabled = blnEnable;
                }
            }
        }


        private void UpdateFirmwareDownloadProgress(string strIn)
        {
            if (this.txtFirmwareProgress.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(UpdateFirmwareDownloadProgress);
                this.BeginInvoke(d, new object[] { strIn });
            }
            else
            {
                this.txtFirmwareProgress.Text = strIn;
            }
        }

        private void UpdateDiscoverStatus(string strIn)
        {
            this.lblDiscoverStatus.Text = strIn;
            this.lblDiscoverStatus.Update();
        }


        /// <summary>
        /// DiscoveryEventHandler implements the call back functions, the 
        /// ManagementEventWatcher events would invoke
        /// </summary>
        public class DiscoveryEventHandler
        {
            private frmMain mainFrm;
            public DiscoveryEventHandler(ref frmMain frm)
            {
                mainFrm = frm;
            }

            public void EventArrived(object sender, EventArrivedEventArgs e)
            {
                string serial = e.NewEvent["SerialNumber"].ToString();
                string model = e.NewEvent["PartNumber"].ToString();
                mainFrm.BeginInvoke(new MethodInvoker(mainFrm.Discover));
            }

            public void StoppedEvent(object sender, StoppedEventArgs e)
            {

            }
        }

        /// <summary>
        /// FirmwareUpdateEventHandler implements the call back functions, the 
        /// ManagementEventWatcher events would invoke
        /// </summary>
        public class FirmwareUpdateEventHandler
        {
            private frmMain mainFrm;

            public FirmwareUpdateEventHandler(ref frmMain frm)
            {
                mainFrm = frm;
            }

            public void EventArrived(object sender, EventArrivedEventArgs e)
            {
                string serial = e.NewEvent["SerialNumber"].ToString();
                string model = e.NewEvent["PartNumber"].ToString();
                if (serial.Equals(mainFrm.strSerialNumber) && model.Equals(mainFrm.strPartNumber))
                {
                    string type = e.NewEvent["Type"].ToString();
                    string status = "";
                    if (type.Equals("1"))
                    {
                        status = "Session Started";
                    }
                    else if (type.Equals("2"))
                    {
                        status = "Download Started";
                    }
                    else if (type.Equals("3"))
                    {
                        string blockCount = e.NewEvent["Progress"].ToString();
                        status = "Progress - Block:" + blockCount;
                    }
                    else if (type.Equals("12"))
                    {
                        status = "Download Ended";
                    }
                    else if (type.Equals("11"))
                    {
                        status = "Session Ended";
                    }
                    else if (type.Equals("100"))
                    {
                        status = "Firmware Update Error";
                    }
                    mainFrm.UpdateFirmwareDownloadProgress(status);
                }
            }

            public void StoppedEvent(object sender, StoppedEventArgs e)
            {

            }
        }



    }
}