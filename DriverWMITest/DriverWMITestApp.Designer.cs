namespace WMI_Test
{
    partial class DriverWMITestApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnRetrieveFile = new System.Windows.Forms.Button();
            this.lblCloneStatus = new System.Windows.Forms.Label();
            this.btnSaveToFile = new System.Windows.Forms.Button();
            this.btnPush = new System.Windows.Forms.Button();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.lblExecStatus = new System.Windows.Forms.Label();
            this.lblFirmwareProgress = new System.Windows.Forms.Label();
            this.txtFirmwareProgress = new System.Windows.Forms.TextBox();
            this.cmbQuickSetData = new System.Windows.Forms.ComboBox();
            this.btnQuickSetRetrieve = new System.Windows.Forms.Button();
            this.lblQuickSetStatus = new System.Windows.Forms.Label();
            this.btnSetPara = new System.Windows.Forms.Button();
            this.lblVal = new System.Windows.Forms.Label();
            this.cmbQuickSetVal = new System.Windows.Forms.ComboBox();
            this.cmbQuickSet = new System.Windows.Forms.ComboBox();
            this.lblParameter = new System.Windows.Forms.Label();
            this.lblInput = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.txtIN = new System.Windows.Forms.TextBox();
            this.lblMgmtData = new System.Windows.Forms.Label();
            this.btnClearOut = new System.Windows.Forms.Button();
            this.txtOutMgmt = new System.Windows.Forms.TextBox();
            this.cmbIN = new System.Windows.Forms.ComboBox();
            this.cmbMethod = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblQueryStatus = new System.Windows.Forms.Label();
            this.btnGetProperty = new System.Windows.Forms.Button();
            this.lstProperties = new System.Windows.Forms.ListBox();
            this.lblConnStatus = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtComputer = new System.Windows.Forms.TextBox();
            this.lblComputer = new System.Windows.Forms.Label();
            this.txtOutBarcode = new System.Windows.Forms.TextBox();
            this.cbPollData = new System.Windows.Forms.CheckBox();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.lblDiscoverStatus = new System.Windows.Forms.Label();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.btnDiscover = new System.Windows.Forms.Button();
            this.cmbSerialFiltered = new System.Windows.Forms.ComboBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.txtFirmware = new System.Windows.Forms.TextBox();
            this.txtDOM = new System.Windows.Forms.TextBox();
            this.lblDOM = new System.Windows.Forms.Label();
            this.lblFirmwareVersion = new System.Windows.Forms.Label();
            this.lblMethod = new System.Windows.Forms.Label();
            this.lblInParam = new System.Windows.Forms.Label();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialogMain = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogMain = new System.Windows.Forms.SaveFileDialog();
            this.tabPageDriverWMITest = new System.Windows.Forms.TabPage();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this.listBoxDW = new System.Windows.Forms.ListBox();
            this.chkAutoSwitchHostMode = new System.Windows.Forms.CheckBox();
            this.chkPNPEventsCapture = new System.Windows.Forms.CheckBox();
            this.textBoxEvents = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.textBoxManagementDataDW = new System.Windows.Forms.TextBox();
            this.groupBoxQuery = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnQueryProperty = new System.Windows.Forms.Button();
            this.lstWMIPorpertyList = new System.Windows.Forms.ListBox();
            this.groupBoxExecDW = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnQueryMethod = new System.Windows.Forms.Button();
            this.pnlReboot = new System.Windows.Forms.Panel();
            this.txtScannerID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbGroup = new System.Windows.Forms.RadioButton();
            this.rbIndividual = new System.Windows.Forms.RadioButton();
            this.cmbWMIMethodsList = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlScannerCapability = new System.Windows.Forms.Panel();
            this.txtGetCapaScannerID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlSwitchHostMode = new System.Windows.Forms.Panel();
            this.cmbHostMode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSwitchHostScannerID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkIsSilentSwitch = new System.Windows.Forms.CheckBox();
            this.chkIsPermanant = new System.Windows.Forms.CheckBox();
            this.pnlAtributeMeta = new System.Windows.Forms.Panel();
            this.btnBrowseAtribMeta = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAtribMetaPath = new System.Windows.Forms.TextBox();
            this.groupBoxConnect = new System.Windows.Forms.GroupBox();
            this.lblDriverWMIConnectStatus = new System.Windows.Forms.Label();
            this.btnConnectWMIDriver = new System.Windows.Forms.Button();
            this.txtHostIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControlWMITest = new System.Windows.Forms.TabControl();
            this.openFileDialogAttribMetaFile = new System.Windows.Forms.OpenFileDialog();
            this.tabPageDriverWMITest.SuspendLayout();
            this.groupBoxOutput.SuspendLayout();
            this.groupBoxQuery.SuspendLayout();
            this.groupBoxExecDW.SuspendLayout();
            this.pnlReboot.SuspendLayout();
            this.pnlScannerCapability.SuspendLayout();
            this.pnlSwitchHostMode.SuspendLayout();
            this.pnlAtributeMeta.SuspendLayout();
            this.groupBoxConnect.SuspendLayout();
            this.tabControlWMITest.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRetrieveFile
            // 
            this.btnRetrieveFile.Location = new System.Drawing.Point(107, 23);
            this.btnRetrieveFile.Name = "btnRetrieveFile";
            this.btnRetrieveFile.Size = new System.Drawing.Size(87, 39);
            this.btnRetrieveFile.TabIndex = 16;
            this.btnRetrieveFile.Text = "Retrieve from File";
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
            // 
            // btnPush
            // 
            this.btnPush.Location = new System.Drawing.Point(303, 23);
            this.btnPush.Name = "btnPush";
            this.btnPush.Size = new System.Drawing.Size(88, 39);
            this.btnPush.TabIndex = 1;
            this.btnPush.Text = "Push";
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Location = new System.Drawing.Point(8, 23);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(88, 39);
            this.btnRetrieve.TabIndex = 0;
            this.btnRetrieve.Text = "Retrieve from Scanner";
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
            // lblFirmwareProgress
            // 
            this.lblFirmwareProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFirmwareProgress.Location = new System.Drawing.Point(8, 607);
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
            this.txtFirmwareProgress.Location = new System.Drawing.Point(146, 610);
            this.txtFirmwareProgress.MaxLength = 0;
            this.txtFirmwareProgress.Name = "txtFirmwareProgress";
            this.txtFirmwareProgress.ReadOnly = true;
            this.txtFirmwareProgress.Size = new System.Drawing.Size(307, 20);
            this.txtFirmwareProgress.TabIndex = 14;
            this.txtFirmwareProgress.TabStop = false;
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
            // 
            // lblVal
            // 
            this.lblVal.Location = new System.Drawing.Point(0, 0);
            this.lblVal.Name = "lblVal";
            this.lblVal.Size = new System.Drawing.Size(100, 23);
            this.lblVal.TabIndex = 0;
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
            this.btnClearOut.Location = new System.Drawing.Point(459, 607);
            this.btnClearOut.Name = "btnClearOut";
            this.btnClearOut.Size = new System.Drawing.Size(80, 24);
            this.btnClearOut.TabIndex = 7;
            this.btnClearOut.Text = "Clear";
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
            this.txtOutMgmt.Size = new System.Drawing.Size(532, 377);
            this.txtOutMgmt.TabIndex = 0;
            this.txtOutMgmt.TabStop = false;
            this.txtOutMgmt.WordWrap = false;
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
            this.lblQueryStatus.Location = new System.Drawing.Point(11, 90);
            this.lblQueryStatus.Name = "lblQueryStatus";
            this.lblQueryStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblQueryStatus.Size = new System.Drawing.Size(87, 47);
            this.lblQueryStatus.TabIndex = 19;
            this.lblQueryStatus.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnGetProperty
            // 
            this.btnGetProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGetProperty.Location = new System.Drawing.Point(11, 156);
            this.btnGetProperty.Name = "btnGetProperty";
            this.btnGetProperty.Size = new System.Drawing.Size(87, 24);
            this.btnGetProperty.TabIndex = 18;
            this.btnGetProperty.Text = "Get";
            // 
            // lstProperties
            // 
            this.lstProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstProperties.Location = new System.Drawing.Point(112, 30);
            this.lstProperties.Name = "lstProperties";
            this.lstProperties.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstProperties.Size = new System.Drawing.Size(280, 134);
            this.lstProperties.TabIndex = 17;
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
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(287, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(88, 26);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // txtComputer
            // 
            this.txtComputer.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
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
            // txtOutBarcode
            // 
            this.txtOutBarcode.AcceptsTab = true;
            this.txtOutBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutBarcode.BackColor = System.Drawing.SystemColors.Info;
            this.txtOutBarcode.Location = new System.Drawing.Point(8, 449);
            this.txtOutBarcode.MaxLength = 0;
            this.txtOutBarcode.Multiline = true;
            this.txtOutBarcode.Name = "txtOutBarcode";
            this.txtOutBarcode.ReadOnly = true;
            this.txtOutBarcode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutBarcode.Size = new System.Drawing.Size(532, 150);
            this.txtOutBarcode.TabIndex = 14;
            this.txtOutBarcode.TabStop = false;
            this.txtOutBarcode.WordWrap = false;
            // 
            // cbPollData
            // 
            this.cbPollData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbPollData.AutoSize = true;
            this.cbPollData.Location = new System.Drawing.Point(11, 425);
            this.cbPollData.Name = "cbPollData";
            this.cbPollData.Size = new System.Drawing.Size(206, 17);
            this.cbPollData.TabIndex = 15;
            this.cbPollData.Text = "Barcode Data (Polled every 1 second)";
            this.cbPollData.UseVisualStyleBackColor = true;
            // 
            // cmbModel
            // 
            this.cmbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModel.Enabled = false;
            this.cmbModel.Location = new System.Drawing.Point(112, 25);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(160, 21);
            this.cmbModel.TabIndex = 4;
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
            // lblSerialNumber
            // 
            this.lblSerialNumber.Location = new System.Drawing.Point(0, 0);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Size = new System.Drawing.Size(100, 23);
            this.lblSerialNumber.TabIndex = 0;
            // 
            // btnDiscover
            // 
            this.btnDiscover.Location = new System.Drawing.Point(287, 25);
            this.btnDiscover.Name = "btnDiscover";
            this.btnDiscover.Size = new System.Drawing.Size(88, 25);
            this.btnDiscover.TabIndex = 3;
            this.btnDiscover.Text = "Discover";
            // 
            // cmbSerialFiltered
            // 
            this.cmbSerialFiltered.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerialFiltered.Enabled = false;
            this.cmbSerialFiltered.Location = new System.Drawing.Point(112, 51);
            this.cmbSerialFiltered.Name = "cmbSerialFiltered";
            this.cmbSerialFiltered.Size = new System.Drawing.Size(160, 21);
            this.cmbSerialFiltered.TabIndex = 4;
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
            // tabPageDriverWMITest
            // 
            this.tabPageDriverWMITest.Controls.Add(this.groupBoxOutput);
            this.tabPageDriverWMITest.Controls.Add(this.groupBoxQuery);
            this.tabPageDriverWMITest.Controls.Add(this.groupBoxExecDW);
            this.tabPageDriverWMITest.Controls.Add(this.groupBoxConnect);
            this.tabPageDriverWMITest.Location = new System.Drawing.Point(4, 22);
            this.tabPageDriverWMITest.Name = "tabPageDriverWMITest";
            this.tabPageDriverWMITest.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDriverWMITest.Size = new System.Drawing.Size(992, 864);
            this.tabPageDriverWMITest.TabIndex = 1;
            this.tabPageDriverWMITest.Text = "Driver WMI Test";
            this.tabPageDriverWMITest.UseVisualStyleBackColor = true;
            // 
            // groupBoxOutput
            // 
            this.groupBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxOutput.Controls.Add(this.listBoxDW);
            this.groupBoxOutput.Controls.Add(this.chkAutoSwitchHostMode);
            this.groupBoxOutput.Controls.Add(this.chkPNPEventsCapture);
            this.groupBoxOutput.Controls.Add(this.textBoxEvents);
            this.groupBoxOutput.Controls.Add(this.label15);
            this.groupBoxOutput.Controls.Add(this.btnClear);
            this.groupBoxOutput.Controls.Add(this.textBoxManagementDataDW);
            this.groupBoxOutput.Location = new System.Drawing.Point(414, 6);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Size = new System.Drawing.Size(548, 534);
            this.groupBoxOutput.TabIndex = 19;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "Output From Driver";
            // 
            // listBoxDW
            // 
            this.listBoxDW.FormattingEnabled = true;
            this.listBoxDW.Location = new System.Drawing.Point(11, 349);
            this.listBoxDW.Name = "listBoxDW";
            this.listBoxDW.Size = new System.Drawing.Size(279, 147);
            this.listBoxDW.TabIndex = 16;
            this.listBoxDW.Visible = false;
            this.listBoxDW.SelectedIndexChanged += new System.EventHandler(this.listBoxDW_SelectedIndexChanged);
            // 
            // chkAutoSwitchHostMode
            // 
            this.chkAutoSwitchHostMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAutoSwitchHostMode.AutoSize = true;
            this.chkAutoSwitchHostMode.Enabled = false;
            this.chkAutoSwitchHostMode.Location = new System.Drawing.Point(208, 326);
            this.chkAutoSwitchHostMode.Name = "chkAutoSwitchHostMode";
            this.chkAutoSwitchHostMode.Size = new System.Drawing.Size(138, 17);
            this.chkAutoSwitchHostMode.TabIndex = 16;
            this.chkAutoSwitchHostMode.Text = "Auto Switch Host Mode";
            this.chkAutoSwitchHostMode.UseVisualStyleBackColor = true;
            this.chkAutoSwitchHostMode.CheckedChanged += new System.EventHandler(this.chkAutoSwitchHostMode_CheckedChanged);
            // 
            // chkPNPEventsCapture
            // 
            this.chkPNPEventsCapture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkPNPEventsCapture.AutoSize = true;
            this.chkPNPEventsCapture.Enabled = false;
            this.chkPNPEventsCapture.Location = new System.Drawing.Point(11, 326);
            this.chkPNPEventsCapture.Name = "chkPNPEventsCapture";
            this.chkPNPEventsCapture.Size = new System.Drawing.Size(153, 17);
            this.chkPNPEventsCapture.TabIndex = 15;
            this.chkPNPEventsCapture.Text = "Listen Scanner PNP Event";
            this.chkPNPEventsCapture.UseVisualStyleBackColor = true;
            this.chkPNPEventsCapture.CheckedChanged += new System.EventHandler(this.chkPNPEventsCapture_CheckedChanged);
            // 
            // textBoxEvents
            // 
            this.textBoxEvents.AcceptsTab = true;
            this.textBoxEvents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEvents.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxEvents.Location = new System.Drawing.Point(10, 349);
            this.textBoxEvents.MaxLength = 0;
            this.textBoxEvents.Multiline = true;
            this.textBoxEvents.Name = "textBoxEvents";
            this.textBoxEvents.ReadOnly = true;
            this.textBoxEvents.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxEvents.Size = new System.Drawing.Size(532, 128);
            this.textBoxEvents.TabIndex = 14;
            this.textBoxEvents.TabStop = false;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(8, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 16);
            this.label15.TabIndex = 8;
            this.label15.Text = "Management Data";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(459, 501);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 24);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // textBoxManagementDataDW
            // 
            this.textBoxManagementDataDW.AcceptsTab = true;
            this.textBoxManagementDataDW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxManagementDataDW.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxManagementDataDW.Location = new System.Drawing.Point(8, 41);
            this.textBoxManagementDataDW.MaxLength = 0;
            this.textBoxManagementDataDW.Multiline = true;
            this.textBoxManagementDataDW.Name = "textBoxManagementDataDW";
            this.textBoxManagementDataDW.ReadOnly = true;
            this.textBoxManagementDataDW.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxManagementDataDW.Size = new System.Drawing.Size(532, 280);
            this.textBoxManagementDataDW.TabIndex = 0;
            this.textBoxManagementDataDW.TabStop = false;
            // 
            // groupBoxQuery
            // 
            this.groupBoxQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxQuery.Controls.Add(this.label13);
            this.groupBoxQuery.Controls.Add(this.label14);
            this.groupBoxQuery.Controls.Add(this.btnQueryProperty);
            this.groupBoxQuery.Controls.Add(this.lstWMIPorpertyList);
            this.groupBoxQuery.Enabled = false;
            this.groupBoxQuery.Location = new System.Drawing.Point(8, 348);
            this.groupBoxQuery.Name = "groupBoxQuery";
            this.groupBoxQuery.Size = new System.Drawing.Size(400, 192);
            this.groupBoxQuery.TabIndex = 18;
            this.groupBoxQuery.TabStop = false;
            this.groupBoxQuery.Text = "Query Properties";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(110, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Properties";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.Location = new System.Drawing.Point(8, 30);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label14.Size = new System.Drawing.Size(87, 47);
            this.label14.TabIndex = 19;
            this.label14.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnQueryProperty
            // 
            this.btnQueryProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQueryProperty.Location = new System.Drawing.Point(185, 144);
            this.btnQueryProperty.Name = "btnQueryProperty";
            this.btnQueryProperty.Size = new System.Drawing.Size(87, 24);
            this.btnQueryProperty.TabIndex = 18;
            this.btnQueryProperty.Text = "Get";
            this.btnQueryProperty.Click += new System.EventHandler(this.btnQueryProperty_Click);
            // 
            // lstWMIPorpertyList
            // 
            this.lstWMIPorpertyList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstWMIPorpertyList.Location = new System.Drawing.Point(112, 30);
            this.lstWMIPorpertyList.Name = "lstWMIPorpertyList";
            this.lstWMIPorpertyList.ScrollAlwaysVisible = true;
            this.lstWMIPorpertyList.Size = new System.Drawing.Size(280, 108);
            this.lstWMIPorpertyList.TabIndex = 17;
            // 
            // groupBoxExecDW
            // 
            this.groupBoxExecDW.Controls.Add(this.label10);
            this.groupBoxExecDW.Controls.Add(this.btnQueryMethod);
            this.groupBoxExecDW.Controls.Add(this.pnlReboot);
            this.groupBoxExecDW.Controls.Add(this.cmbWMIMethodsList);
            this.groupBoxExecDW.Controls.Add(this.label11);
            this.groupBoxExecDW.Controls.Add(this.pnlScannerCapability);
            this.groupBoxExecDW.Controls.Add(this.pnlSwitchHostMode);
            this.groupBoxExecDW.Controls.Add(this.pnlAtributeMeta);
            this.groupBoxExecDW.Enabled = false;
            this.groupBoxExecDW.Location = new System.Drawing.Point(8, 99);
            this.groupBoxExecDW.Name = "groupBoxExecDW";
            this.groupBoxExecDW.Size = new System.Drawing.Size(400, 243);
            this.groupBoxExecDW.TabIndex = 17;
            this.groupBoxExecDW.TabStop = false;
            this.groupBoxExecDW.Text = "Execute Methods";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(11, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 27);
            this.label10.TabIndex = 15;
            this.label10.Text = "Input Parameters";
            // 
            // btnQueryMethod
            // 
            this.btnQueryMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQueryMethod.Location = new System.Drawing.Point(187, 204);
            this.btnQueryMethod.Name = "btnQueryMethod";
            this.btnQueryMethod.Size = new System.Drawing.Size(87, 24);
            this.btnQueryMethod.TabIndex = 4;
            this.btnQueryMethod.Text = "Execute";
            this.btnQueryMethod.Click += new System.EventHandler(this.btnQueryMethod_Click);
            // 
            // pnlReboot
            // 
            this.pnlReboot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReboot.Controls.Add(this.txtScannerID);
            this.pnlReboot.Controls.Add(this.label2);
            this.pnlReboot.Controls.Add(this.rbGroup);
            this.pnlReboot.Controls.Add(this.rbIndividual);
            this.pnlReboot.Location = new System.Drawing.Point(112, 65);
            this.pnlReboot.Name = "pnlReboot";
            this.pnlReboot.Size = new System.Drawing.Size(280, 130);
            this.pnlReboot.TabIndex = 16;
            this.pnlReboot.Visible = false;
            // 
            // txtScannerID
            // 
            this.txtScannerID.Enabled = false;
            this.txtScannerID.Location = new System.Drawing.Point(115, 31);
            this.txtScannerID.Name = "txtScannerID";
            this.txtScannerID.Size = new System.Drawing.Size(68, 20);
            this.txtScannerID.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Scanner ID";
            // 
            // rbGroup
            // 
            this.rbGroup.AutoSize = true;
            this.rbGroup.Checked = true;
            this.rbGroup.Location = new System.Drawing.Point(24, 63);
            this.rbGroup.Name = "rbGroup";
            this.rbGroup.Size = new System.Drawing.Size(54, 17);
            this.rbGroup.TabIndex = 1;
            this.rbGroup.TabStop = true;
            this.rbGroup.Text = "Group";
            this.rbGroup.UseVisualStyleBackColor = true;
            // 
            // rbIndividual
            // 
            this.rbIndividual.AutoSize = true;
            this.rbIndividual.Location = new System.Drawing.Point(24, 10);
            this.rbIndividual.Name = "rbIndividual";
            this.rbIndividual.Size = new System.Drawing.Size(113, 17);
            this.rbIndividual.TabIndex = 0;
            this.rbIndividual.Text = "Individual Scanner";
            this.rbIndividual.UseVisualStyleBackColor = true;
            this.rbIndividual.CheckedChanged += new System.EventHandler(this.rbIndividual_CheckedChanged);
            // 
            // cmbWMIMethodsList
            // 
            this.cmbWMIMethodsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWMIMethodsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWMIMethodsList.IntegralHeight = false;
            this.cmbWMIMethodsList.Location = new System.Drawing.Point(114, 25);
            this.cmbWMIMethodsList.MaxDropDownItems = 9;
            this.cmbWMIMethodsList.Name = "cmbWMIMethodsList";
            this.cmbWMIMethodsList.Size = new System.Drawing.Size(160, 21);
            this.cmbWMIMethodsList.Sorted = true;
            this.cmbWMIMethodsList.TabIndex = 3;
            this.cmbWMIMethodsList.SelectedIndexChanged += new System.EventHandler(this.cmbWMIMethodsList_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(11, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 20);
            this.label11.TabIndex = 3;
            this.label11.Text = "Method";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlScannerCapability
            // 
            this.pnlScannerCapability.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlScannerCapability.Controls.Add(this.txtGetCapaScannerID);
            this.pnlScannerCapability.Controls.Add(this.label7);
            this.pnlScannerCapability.Location = new System.Drawing.Point(112, 68);
            this.pnlScannerCapability.Name = "pnlScannerCapability";
            this.pnlScannerCapability.Size = new System.Drawing.Size(280, 130);
            this.pnlScannerCapability.TabIndex = 17;
            this.pnlScannerCapability.Visible = false;
            // 
            // txtGetCapaScannerID
            // 
            this.txtGetCapaScannerID.Location = new System.Drawing.Point(88, 16);
            this.txtGetCapaScannerID.Name = "txtGetCapaScannerID";
            this.txtGetCapaScannerID.Size = new System.Drawing.Size(100, 20);
            this.txtGetCapaScannerID.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Scanner ID";
            // 
            // pnlSwitchHostMode
            // 
            this.pnlSwitchHostMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSwitchHostMode.Controls.Add(this.cmbHostMode);
            this.pnlSwitchHostMode.Controls.Add(this.label5);
            this.pnlSwitchHostMode.Controls.Add(this.txtSwitchHostScannerID);
            this.pnlSwitchHostMode.Controls.Add(this.label4);
            this.pnlSwitchHostMode.Controls.Add(this.chkIsSilentSwitch);
            this.pnlSwitchHostMode.Controls.Add(this.chkIsPermanant);
            this.pnlSwitchHostMode.Location = new System.Drawing.Point(110, 69);
            this.pnlSwitchHostMode.Name = "pnlSwitchHostMode";
            this.pnlSwitchHostMode.Size = new System.Drawing.Size(280, 130);
            this.pnlSwitchHostMode.TabIndex = 5;
            this.pnlSwitchHostMode.Visible = false;
            // 
            // cmbHostMode
            // 
            this.cmbHostMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHostMode.FormattingEnabled = true;
            this.cmbHostMode.Items.AddRange(new object[] {
            "HIDKB",
            "IBMHID",
            "SNAPI With Imaging",
            "SNAPI Witout Imaging",
            "IBMTT",
            "RS232 Over CDC",
            "SSI Over CDC"});
            this.cmbHostMode.Location = new System.Drawing.Point(103, 45);
            this.cmbHostMode.Name = "cmbHostMode";
            this.cmbHostMode.Size = new System.Drawing.Size(121, 21);
            this.cmbHostMode.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Target Host Mode";
            // 
            // txtSwitchHostScannerID
            // 
            this.txtSwitchHostScannerID.Location = new System.Drawing.Point(103, 10);
            this.txtSwitchHostScannerID.Name = "txtSwitchHostScannerID";
            this.txtSwitchHostScannerID.Size = new System.Drawing.Size(100, 20);
            this.txtSwitchHostScannerID.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Scanner ID";
            // 
            // chkIsSilentSwitch
            // 
            this.chkIsSilentSwitch.AutoSize = true;
            this.chkIsSilentSwitch.Location = new System.Drawing.Point(103, 102);
            this.chkIsSilentSwitch.Name = "chkIsSilentSwitch";
            this.chkIsSilentSwitch.Size = new System.Drawing.Size(63, 17);
            this.chkIsSilentSwitch.TabIndex = 1;
            this.chkIsSilentSwitch.Text = "Is Silent";
            this.chkIsSilentSwitch.UseVisualStyleBackColor = true;
            // 
            // chkIsPermanant
            // 
            this.chkIsPermanant.AutoSize = true;
            this.chkIsPermanant.Location = new System.Drawing.Point(103, 80);
            this.chkIsPermanant.Name = "chkIsPermanant";
            this.chkIsPermanant.Size = new System.Drawing.Size(88, 17);
            this.chkIsPermanant.TabIndex = 0;
            this.chkIsPermanant.Text = "Is Permanant";
            this.chkIsPermanant.UseVisualStyleBackColor = true;
            // 
            // pnlAtributeMeta
            // 
            this.pnlAtributeMeta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAtributeMeta.Controls.Add(this.btnBrowseAtribMeta);
            this.pnlAtributeMeta.Controls.Add(this.label6);
            this.pnlAtributeMeta.Controls.Add(this.txtAtribMetaPath);
            this.pnlAtributeMeta.Location = new System.Drawing.Point(112, 68);
            this.pnlAtributeMeta.Name = "pnlAtributeMeta";
            this.pnlAtributeMeta.Size = new System.Drawing.Size(280, 130);
            this.pnlAtributeMeta.TabIndex = 6;
            this.pnlAtributeMeta.Visible = false;
            // 
            // btnBrowseAtribMeta
            // 
            this.btnBrowseAtribMeta.Location = new System.Drawing.Point(61, 51);
            this.btnBrowseAtribMeta.Name = "btnBrowseAtribMeta";
            this.btnBrowseAtribMeta.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseAtribMeta.TabIndex = 2;
            this.btnBrowseAtribMeta.Text = "Browse";
            this.btnBrowseAtribMeta.UseVisualStyleBackColor = true;
            this.btnBrowseAtribMeta.Click += new System.EventHandler(this.btnBrowseAtribMeta_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "File Path";
            // 
            // txtAtribMetaPath
            // 
            this.txtAtribMetaPath.Location = new System.Drawing.Point(61, 15);
            this.txtAtribMetaPath.Name = "txtAtribMetaPath";
            this.txtAtribMetaPath.Size = new System.Drawing.Size(197, 20);
            this.txtAtribMetaPath.TabIndex = 0;
            // 
            // groupBoxConnect
            // 
            this.groupBoxConnect.Controls.Add(this.lblDriverWMIConnectStatus);
            this.groupBoxConnect.Controls.Add(this.btnConnectWMIDriver);
            this.groupBoxConnect.Controls.Add(this.txtHostIP);
            this.groupBoxConnect.Controls.Add(this.label3);
            this.groupBoxConnect.Location = new System.Drawing.Point(8, 6);
            this.groupBoxConnect.Name = "groupBoxConnect";
            this.groupBoxConnect.Size = new System.Drawing.Size(400, 75);
            this.groupBoxConnect.TabIndex = 15;
            this.groupBoxConnect.TabStop = false;
            this.groupBoxConnect.Text = "Target Computer";
            // 
            // lblDriverWMIConnectStatus
            // 
            this.lblDriverWMIConnectStatus.AutoSize = true;
            this.lblDriverWMIConnectStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblDriverWMIConnectStatus.Location = new System.Drawing.Point(284, 55);
            this.lblDriverWMIConnectStatus.Name = "lblDriverWMIConnectStatus";
            this.lblDriverWMIConnectStatus.Size = new System.Drawing.Size(79, 13);
            this.lblDriverWMIConnectStatus.TabIndex = 14;
            this.lblDriverWMIConnectStatus.Text = "Not Connected";
            this.lblDriverWMIConnectStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnConnectWMIDriver
            // 
            this.btnConnectWMIDriver.Location = new System.Drawing.Point(278, 13);
            this.btnConnectWMIDriver.Name = "btnConnectWMIDriver";
            this.btnConnectWMIDriver.Size = new System.Drawing.Size(88, 26);
            this.btnConnectWMIDriver.TabIndex = 1;
            this.btnConnectWMIDriver.Text = "Connect";
            this.btnConnectWMIDriver.UseVisualStyleBackColor = true;
            this.btnConnectWMIDriver.Click += new System.EventHandler(this.btnConnectWMIDriver_Click);
            // 
            // txtHostIP
            // 
            this.txtHostIP.BackColor = System.Drawing.Color.White;
            this.txtHostIP.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtHostIP.Location = new System.Drawing.Point(112, 16);
            this.txtHostIP.Name = "txtHostIP";
            this.txtHostIP.Size = new System.Drawing.Size(160, 20);
            this.txtHostIP.TabIndex = 0;
            this.txtHostIP.Text = "localhost";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Name or IP Address";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControlWMITest
            // 
            this.tabControlWMITest.Controls.Add(this.tabPageDriverWMITest);
            this.tabControlWMITest.Location = new System.Drawing.Point(0, 0);
            this.tabControlWMITest.Name = "tabControlWMITest";
            this.tabControlWMITest.SelectedIndex = 0;
            this.tabControlWMITest.Size = new System.Drawing.Size(1000, 890);
            this.tabControlWMITest.TabIndex = 0;
            // 
            // openFileDialogAttribMetaFile
            // 
            this.openFileDialogAttribMetaFile.Title = "Browse for a Atribute Meta File";
            // 
            // DriverWMITestApp
            // 
            this.AcceptButton = this.btnExecute;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 574);
            this.Controls.Add(this.tabControlWMITest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(702, 601);
            this.Name = "DriverWMITestApp";
            this.Text = "Driver WMI Test";
            this.Load += new System.EventHandler(this.DriverWMITestApp_Load);
            this.tabPageDriverWMITest.ResumeLayout(false);
            this.groupBoxOutput.ResumeLayout(false);
            this.groupBoxOutput.PerformLayout();
            this.groupBoxQuery.ResumeLayout(false);
            this.groupBoxQuery.PerformLayout();
            this.groupBoxExecDW.ResumeLayout(false);
            this.pnlReboot.ResumeLayout(false);
            this.pnlReboot.PerformLayout();
            this.pnlScannerCapability.ResumeLayout(false);
            this.pnlScannerCapability.PerformLayout();
            this.pnlSwitchHostMode.ResumeLayout(false);
            this.pnlSwitchHostMode.PerformLayout();
            this.pnlAtributeMeta.ResumeLayout(false);
            this.pnlAtributeMeta.PerformLayout();
            this.groupBoxConnect.ResumeLayout(false);
            this.groupBoxConnect.PerformLayout();
            this.tabControlWMITest.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRetrieveFile;
        private System.Windows.Forms.Label lblCloneStatus;
        private System.Windows.Forms.Button btnSaveToFile;
        private System.Windows.Forms.Button btnPush;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Label lblExecStatus;
        private System.Windows.Forms.Label lblFirmwareProgress;
        private System.Windows.Forms.TextBox txtFirmwareProgress;
        private System.Windows.Forms.ComboBox cmbQuickSetData;
        private System.Windows.Forms.Button btnQuickSetRetrieve;
        private System.Windows.Forms.Label lblQuickSetStatus;
        private System.Windows.Forms.Button btnSetPara;
        private System.Windows.Forms.Label lblVal;
        private System.Windows.Forms.ComboBox cmbQuickSetVal;
        private System.Windows.Forms.ComboBox cmbQuickSet;
        private System.Windows.Forms.Label lblParameter;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.TextBox txtIN;
        private System.Windows.Forms.Label lblMgmtData;
        private System.Windows.Forms.Button btnClearOut;
        private System.Windows.Forms.TextBox txtOutMgmt;
        private System.Windows.Forms.ComboBox cmbIN;
        private System.Windows.Forms.ComboBox cmbMethod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblQueryStatus;
        private System.Windows.Forms.Button btnGetProperty;
        private System.Windows.Forms.ListBox lstProperties;
        private System.Windows.Forms.Label lblConnStatus;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtComputer;
        private System.Windows.Forms.Label lblComputer;
        private System.Windows.Forms.TextBox txtOutBarcode;
        private System.Windows.Forms.CheckBox cbPollData;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.Label lblDiscoverStatus;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.Button btnDiscover;
        private System.Windows.Forms.ComboBox cmbSerialFiltered;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TextBox txtFirmware;
        private System.Windows.Forms.TextBox txtDOM;
        private System.Windows.Forms.Label lblDOM;
        private System.Windows.Forms.Label lblFirmwareVersion;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.Label lblInParam;
        private System.Windows.Forms.ToolTip toolTipMain;
        private System.Windows.Forms.OpenFileDialog openFileDialogMain;
        private System.Windows.Forms.SaveFileDialog saveFileDialogMain;
        private System.Windows.Forms.TabPage tabPageDriverWMITest;
        private System.Windows.Forms.GroupBox groupBoxOutput;
        private System.Windows.Forms.CheckBox chkPNPEventsCapture;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox textBoxManagementDataDW;
        private System.Windows.Forms.GroupBox groupBoxQuery;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnQueryProperty;
        private System.Windows.Forms.ListBox lstWMIPorpertyList;
        private System.Windows.Forms.GroupBox groupBoxExecDW;
        public System.Windows.Forms.ListBox listBoxDW;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnQueryMethod;
        internal System.Windows.Forms.ComboBox cmbWMIMethodsList;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBoxConnect;
        private System.Windows.Forms.Label lblDriverWMIConnectStatus;
        private System.Windows.Forms.Button btnConnectWMIDriver;
        private System.Windows.Forms.TextBox txtHostIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControlWMITest;
        private System.Windows.Forms.TextBox textBoxEvents;
        private System.Windows.Forms.CheckBox chkAutoSwitchHostMode;
        private System.Windows.Forms.Panel pnlReboot;
        private System.Windows.Forms.RadioButton rbGroup;
        private System.Windows.Forms.RadioButton rbIndividual;
        private System.Windows.Forms.TextBox txtScannerID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlSwitchHostMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSwitchHostScannerID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkIsSilentSwitch;
        private System.Windows.Forms.CheckBox chkIsPermanant;
        private System.Windows.Forms.ComboBox cmbHostMode;
        private System.Windows.Forms.Panel pnlAtributeMeta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAtribMetaPath;
        private System.Windows.Forms.OpenFileDialog openFileDialogAttribMetaFile;
        private System.Windows.Forms.Button btnBrowseAtribMeta;
        private System.Windows.Forms.Panel pnlScannerCapability;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGetCapaScannerID;
    }
}

