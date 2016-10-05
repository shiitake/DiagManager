/**************************************************
beginning of licensing agreement
Microsoft Public License (Ms-PL)

This license governs use of the accompanying software. If you use the software, you accept this license. If you do not accept the license, do not use the software.

1. Definitions

The terms "reproduce," "reproduction," "derivative works," and "distribution" have the same meaning here as under U.S. copyright law.

A "contribution" is the original software, or any additions or changes to the software.

A "contributor" is any person that distributes its contribution under this license.

"Licensed patents" are a contributor's patent claims that read directly on its contribution.

2. Grant of Rights

(A) Copyright Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free copyright license to reproduce its contribution, prepare derivative works of its contribution, and distribute its contribution or any derivative works that you create.

(B) Patent Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free license under its licensed patents to make, have made, use, sell, offer for sale, import, and/or otherwise dispose of its contribution in the software or derivative works of the contribution in the software.

3. Conditions and Limitations

(A) No Trademark License- This license does not grant you rights to use any contributors' name, logo, or trademarks.

(B) If you bring a patent claim against any contributor over patents that you claim are infringed by the software, your patent license from such contributor to the software ends automatically.

(C) If you distribute any portion of the software, you must retain all copyright, patent, trademark, and attribution notices that are present in the software.

(D) If you distribute any portion of the software in source code form, you may do so only under this license by including a complete copy of this license with your distribution. If you distribute any portion of the software in compiled or object code form, you may only do so under a license that complies with this license.

(E) The software is licensed "as-is." You bear the risk of using it. The contributors give no express warranties, guarantees or conditions. You may have additional consumer rights under your local laws which this license cannot change. To the extent permitted under your local laws, the contributors exclude the implied warranties of merchantability, fitness for a particular purpose and non-infringement. 
end of licensing agreement
**************************************************/
#define TRACE
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Xml;
using System.ServiceProcess;
using System.Diagnostics;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Reflection;
//using Microsoft.Office.Interop;
using System.Globalization;
using PssdiagTraceFilterSchema.Namespace;
using System.Text;


namespace PssdiagConfig
{

	public struct eventlogdata
	{
		public string[] Details;
		public int LogIndex;
	}

	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class fmPssdiagConfig : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ContextMenu cmAnalyze;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.Panel paTop;
		private System.Windows.Forms.Panel paTopLeft;
		private System.Windows.Forms.TextBox edCaseNumber;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel paBottom;
		private System.Windows.Forms.TabControl tcVersion;
		private System.Windows.Forms.TabPage tp70;
		private System.Windows.Forms.TabPage tp2K;
		private System.Windows.Forms.Panel paClient;
		private System.Windows.Forms.Panel paClientLeft;
		private System.Windows.Forms.Splitter splitter3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox rgAuth;
		private System.Windows.Forms.RadioButton rbWindowsAuth;
		private System.Windows.Forms.TextBox edLogin;
		private System.Windows.Forms.Splitter splitter4;
		private System.Windows.Forms.Panel paPMTop;
		private System.Windows.Forms.CheckBox ckEventLogs;
		private System.Windows.Forms.CheckBox ckEventLogsStartup;
		private System.Windows.Forms.CheckBox ckEventLogsShutdown;
		private System.Windows.Forms.Panel paClientRightTop;
		private System.Windows.Forms.Splitter splitter5;
		private System.Windows.Forms.GroupBox rgCustom;
		private System.Windows.Forms.ComboBox cbMachine;
		private System.Windows.Forms.Button btDeleteMachine;
		private System.Windows.Forms.OpenFileDialog od_Cfg;
		private System.Windows.Forms.SaveFileDialog sd_Cfg;
		private System.Windows.Forms.ToolBarButton btOpen;
		private System.Windows.Forms.ToolBarButton btSave;
		private System.Windows.Forms.ToolBarButton btAnalyze;
		private System.Windows.Forms.RadioButton rbSSAuth;
		private System.Windows.Forms.ImageList imGlyphs;
		private System.Windows.Forms.ToolBarButton btMerge;
		private System.Windows.Forms.Label laLogin;
		private System.Windows.Forms.Button btAddMachine;
		private System.Windows.Forms.ComboBox cbInstance;
		private System.Windows.Forms.Button btAddInstance;
		private System.Windows.Forms.Button btDeleteInstance;
		private System.Windows.Forms.Label laInstance;
		private System.Windows.Forms.TextBox edMachine;
		private System.Windows.Forms.TextBox edInstance;
		private System.Windows.Forms.Splitter spLeft;
		private System.Windows.Forms.Splitter spBottom;
		private System.Windows.Forms.ComboBox cbPMInterval;
		private System.Windows.Forms.ComboBox cbPMMaxFileSize;
		private System.Windows.Forms.CheckBox ckPerfmon;
		private System.Windows.Forms.TreeView tvPM;
		private System.Windows.Forms.Label laPMInterval;
		private System.Windows.Forms.Label laPMMaxFileSize;
		private System.ServiceProcess.ServiceController scPssdiag;
		private System.Timers.Timer tmPoll;
		private System.Windows.Forms.ToolBarButton btStart;
		private System.Windows.Forms.ToolBarButton btStop;
		private System.Diagnostics.EventLog evPssdiag;
		private System.Windows.Forms.GroupBox rgInstanceDiagnostics;
		private System.Windows.Forms.GroupBox rgMachineDiagnostics;
		private System.Windows.Forms.GroupBox rgConnection;
		private System.Timers.Timer tmOutput;
		private System.Windows.Forms.ContextMenu cmOutput;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.TextBox edTargetMachine;
		private System.Windows.Forms.Label laTargetMachine;
		private System.Windows.Forms.NotifyIcon niPssdiag;
		private System.Windows.Forms.ContextMenu cmNotify;
		private System.Windows.Forms.MenuItem miStart;
		private System.Windows.Forms.MenuItem miStop;
		private System.Windows.Forms.MenuItem miExit;
		private System.Windows.Forms.TextBox edAppName;
		private System.Windows.Forms.DataGridBoolColumn dataGridBoolColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
		private System.Windows.Forms.DataGrid dgSummary;
		private System.Windows.Forms.ToolBarButton btSummaryUp;
		private System.Windows.Forms.ToolBarButton btSummaryDown;
		private System.Windows.Forms.ToolBar toolBar2;
		private System.Windows.Forms.DataGrid dgDetails;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBar toolBar3;
		private System.Windows.Forms.TabControl tcInstructions;
		private System.Windows.Forms.TabPage tpInstructions;
		private System.Windows.Forms.RichTextBox reInstructions;
		private System.Windows.Forms.TabPage tpOutput;
		private System.Windows.Forms.RichTextBox reStrings;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.ListView lvOutput;
		private System.Windows.Forms.ColumnHeader chType;
		private System.Windows.Forms.ColumnHeader chMsg;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.Windows.Forms.ToolBarButton toolBarButton5;
		private System.Windows.Forms.ToolBarButton toolBarButton6;
		private System.Windows.Forms.ToolBarButton toolBarButton7;
		private System.Windows.Forms.ToolBarButton toolBarButton8;
		private System.Windows.Forms.ToolBarButton toolBarButton9;
		private System.Windows.Forms.TabPage tp2K5;
		private System.Windows.Forms.ListView lvCustomGroups;
		private System.Windows.Forms.ColumnHeader colGroup;
		private System.Windows.Forms.ToolBar tbCustomGroups;
		private System.Windows.Forms.ToolBarButton btUp;
		private System.Windows.Forms.ToolBarButton btDown;
		private System.Windows.Forms.ToolBar tbMain;
		private System.Windows.Forms.Label laAppName;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem miDetails;
        private System.Windows.Forms.ContextMenu cmCustomDiag;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ImageList imPlat;
		private System.Windows.Forms.Panel paPlat;
		private System.Windows.Forms.TabControl tcPlat;
		private System.Windows.Forms.TabPage tp32;
		private System.Windows.Forms.TabPage tpIA64;
		private System.Windows.Forms.TabPage tpX64;
		private System.Windows.Forms.ListBox lbCfgs;
		private System.Windows.Forms.Panel paLeftTop;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Panel paPlatClient;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel paInstanceTop;
		private System.Windows.Forms.ComboBox cbBSInterval;
		private System.Windows.Forms.Label laBSInterval;
		private System.Windows.Forms.CheckBox ckBSFast;
		private System.Windows.Forms.CheckBox ckBSLatch;
		private System.Windows.Forms.CheckBox ckBlocker;
		private System.Windows.Forms.CheckBox ckSDShutdown;
		private System.Windows.Forms.CheckBox ckSDStartup;
		private System.Windows.Forms.CheckBox ckSqldiag;
		private System.Windows.Forms.ContextMenu cmTrace;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.TabControl tcTrace;
		private System.Windows.Forms.TabPage tpDatabase;
		private System.Windows.Forms.TabPage tpAS;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TreeView tvProfiler;
		private System.Windows.Forms.ComboBox cbProfilerTemplate;
		private System.Windows.Forms.Label laProfilerTemplate;
		private System.Windows.Forms.CheckBox ckProfiler;
		private System.Windows.Forms.ComboBox cbProfilerMaxFileSize;
		private System.Windows.Forms.Label laProfilerMaxFileSize;
		private System.Windows.Forms.ComboBox cbProfilerInterval;
		private System.Windows.Forms.Label laProfilerInterval;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.CheckBox ckASProfiler;
		private System.Windows.Forms.TreeView tvASProfiler;
		private System.Windows.Forms.Label laASProfilerMaxFileSize;
		private System.Windows.Forms.ComboBox cbASProfilerMaxFileSize;
		private System.Windows.Forms.TabPage tp2k8;
		private System.ComponentModel.IContainer components;

		public fmPssdiagConfig()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		string[] Args;
		int _iVer=-1;

		static public fmPssdiagConfig ConfigForm=null;

		public fmPssdiagConfig(string[] args)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			InternalConfig=((bool)(configurationAppSettings.GetValue("UserMode", typeof(bool)))); 

			Args=args;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            this.components = new System.ComponentModel.Container();
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmPssdiagConfig));
            this.paTop = new System.Windows.Forms.Panel();
            this.edCaseNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.paTopLeft = new System.Windows.Forms.Panel();
            this.edAppName = new System.Windows.Forms.TextBox();
            this.laAppName = new System.Windows.Forms.Label();
            this.edTargetMachine = new System.Windows.Forms.TextBox();
            this.laTargetMachine = new System.Windows.Forms.Label();
            this.tbMain = new System.Windows.Forms.ToolBar();
            this.btOpen = new System.Windows.Forms.ToolBarButton();
            this.btMerge = new System.Windows.Forms.ToolBarButton();
            this.btSave = new System.Windows.Forms.ToolBarButton();
            this.btAnalyze = new System.Windows.Forms.ToolBarButton();
            this.cmAnalyze = new System.Windows.Forms.ContextMenu();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton7 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton8 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton9 = new System.Windows.Forms.ToolBarButton();
            this.btStart = new System.Windows.Forms.ToolBarButton();
            this.btStop = new System.Windows.Forms.ToolBarButton();
            this.imGlyphs = new System.Windows.Forms.ImageList(this.components);
            this.spLeft = new System.Windows.Forms.Splitter();
            this.paBottom = new System.Windows.Forms.Panel();
            this.tcInstructions = new System.Windows.Forms.TabControl();
            this.tpInstructions = new System.Windows.Forms.TabPage();
            this.reInstructions = new System.Windows.Forms.RichTextBox();
            this.tpOutput = new System.Windows.Forms.TabPage();
            this.reStrings = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.lvOutput = new System.Windows.Forms.ListView();
            this.chType = new System.Windows.Forms.ColumnHeader();
            this.chMsg = new System.Windows.Forms.ColumnHeader();
            this.cmOutput = new System.Windows.Forms.ContextMenu();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.spBottom = new System.Windows.Forms.Splitter();
            this.tcVersion = new System.Windows.Forms.TabControl();
            this.tp70 = new System.Windows.Forms.TabPage();
            this.tp2K = new System.Windows.Forms.TabPage();
            this.tp2K5 = new System.Windows.Forms.TabPage();
            this.tp2k8 = new System.Windows.Forms.TabPage();
            this.paClient = new System.Windows.Forms.Panel();
            this.rgCustom = new System.Windows.Forms.GroupBox();
            this.lvCustomGroups = new System.Windows.Forms.ListView();
            this.colGroup = new System.Windows.Forms.ColumnHeader();
            this.cmCustomDiag = new System.Windows.Forms.ContextMenu();
            this.miDetails = new System.Windows.Forms.MenuItem();
            this.tbCustomGroups = new System.Windows.Forms.ToolBar();
            this.btUp = new System.Windows.Forms.ToolBarButton();
            this.btDown = new System.Windows.Forms.ToolBarButton();
            this.splitter5 = new System.Windows.Forms.Splitter();
            this.paClientRightTop = new System.Windows.Forms.Panel();
            this.rgInstanceDiagnostics = new System.Windows.Forms.GroupBox();
            this.tcTrace = new System.Windows.Forms.TabControl();
            this.tpDatabase = new System.Windows.Forms.TabPage();
            this.tvProfiler = new System.Windows.Forms.TreeView();
            this.cmTrace = new System.Windows.Forms.ContextMenu();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbProfilerMaxFileSize = new System.Windows.Forms.ComboBox();
            this.cbProfilerTemplate = new System.Windows.Forms.ComboBox();
            this.laProfilerTemplate = new System.Windows.Forms.Label();
            this.ckProfiler = new System.Windows.Forms.CheckBox();
            this.laProfilerMaxFileSize = new System.Windows.Forms.Label();
            this.laProfilerInterval = new System.Windows.Forms.Label();
            this.cbProfilerInterval = new System.Windows.Forms.ComboBox();
            this.tpAS = new System.Windows.Forms.TabPage();
            this.tvASProfiler = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ckASProfiler = new System.Windows.Forms.CheckBox();
            this.laASProfilerMaxFileSize = new System.Windows.Forms.Label();
            this.cbASProfilerMaxFileSize = new System.Windows.Forms.ComboBox();
            this.paInstanceTop = new System.Windows.Forms.Panel();
            this.cbBSInterval = new System.Windows.Forms.ComboBox();
            this.laBSInterval = new System.Windows.Forms.Label();
            this.ckBSFast = new System.Windows.Forms.CheckBox();
            this.ckBSLatch = new System.Windows.Forms.CheckBox();
            this.ckBlocker = new System.Windows.Forms.CheckBox();
            this.ckSDShutdown = new System.Windows.Forms.CheckBox();
            this.ckSDStartup = new System.Windows.Forms.CheckBox();
            this.ckSqldiag = new System.Windows.Forms.CheckBox();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.paClientLeft = new System.Windows.Forms.Panel();
            this.rgMachineDiagnostics = new System.Windows.Forms.GroupBox();
            this.tvPM = new System.Windows.Forms.TreeView();
            this.paPMTop = new System.Windows.Forms.Panel();
            this.cbPMInterval = new System.Windows.Forms.ComboBox();
            this.laPMInterval = new System.Windows.Forms.Label();
            this.cbPMMaxFileSize = new System.Windows.Forms.ComboBox();
            this.laPMMaxFileSize = new System.Windows.Forms.Label();
            this.ckPerfmon = new System.Windows.Forms.CheckBox();
            this.ckEventLogsShutdown = new System.Windows.Forms.CheckBox();
            this.ckEventLogsStartup = new System.Windows.Forms.CheckBox();
            this.ckEventLogs = new System.Windows.Forms.CheckBox();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.rgConnection = new System.Windows.Forms.GroupBox();
            this.rgAuth = new System.Windows.Forms.GroupBox();
            this.edLogin = new System.Windows.Forms.TextBox();
            this.laLogin = new System.Windows.Forms.Label();
            this.rbSSAuth = new System.Windows.Forms.RadioButton();
            this.rbWindowsAuth = new System.Windows.Forms.RadioButton();
            this.edInstance = new System.Windows.Forms.TextBox();
            this.edMachine = new System.Windows.Forms.TextBox();
            this.cbInstance = new System.Windows.Forms.ComboBox();
            this.btAddInstance = new System.Windows.Forms.Button();
            this.btDeleteInstance = new System.Windows.Forms.Button();
            this.btAddMachine = new System.Windows.Forms.Button();
            this.btDeleteMachine = new System.Windows.Forms.Button();
            this.cbMachine = new System.Windows.Forms.ComboBox();
            this.laInstance = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.od_Cfg = new System.Windows.Forms.OpenFileDialog();
            this.sd_Cfg = new System.Windows.Forms.SaveFileDialog();
            this.scPssdiag = new System.ServiceProcess.ServiceController();
            this.tmPoll = new System.Timers.Timer();
            this.evPssdiag = new System.Diagnostics.EventLog();
            this.tmOutput = new System.Timers.Timer();
            this.niPssdiag = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmNotify = new System.Windows.Forms.ContextMenu();
            this.miStart = new System.Windows.Forms.MenuItem();
            this.miStop = new System.Windows.Forms.MenuItem();
            this.miExit = new System.Windows.Forms.MenuItem();
            this.dataGridBoolColumn3 = new System.Windows.Forms.DataGridBoolColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.dgSummary = new System.Windows.Forms.DataGrid();
            this.btSummaryUp = new System.Windows.Forms.ToolBarButton();
            this.btSummaryDown = new System.Windows.Forms.ToolBarButton();
            this.toolBar2 = new System.Windows.Forms.ToolBar();
            this.dgDetails = new System.Windows.Forms.DataGrid();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.toolBar3 = new System.Windows.Forms.ToolBar();
            this.imPlat = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.paPlat = new System.Windows.Forms.Panel();
            this.paPlatClient = new System.Windows.Forms.Panel();
            this.lbCfgs = new System.Windows.Forms.ListBox();
            this.paLeftTop = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.tcPlat = new System.Windows.Forms.TabControl();
            this.tp32 = new System.Windows.Forms.TabPage();
            this.tpIA64 = new System.Windows.Forms.TabPage();
            this.tpX64 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.paTop.SuspendLayout();
            this.paTopLeft.SuspendLayout();
            this.paBottom.SuspendLayout();
            this.tcInstructions.SuspendLayout();
            this.tpInstructions.SuspendLayout();
            this.tpOutput.SuspendLayout();
            this.tcVersion.SuspendLayout();
            this.paClient.SuspendLayout();
            this.rgCustom.SuspendLayout();
            this.paClientRightTop.SuspendLayout();
            this.rgInstanceDiagnostics.SuspendLayout();
            this.tcTrace.SuspendLayout();
            this.tpDatabase.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tpAS.SuspendLayout();
            this.panel2.SuspendLayout();
            this.paInstanceTop.SuspendLayout();
            this.paClientLeft.SuspendLayout();
            this.rgMachineDiagnostics.SuspendLayout();
            this.paPMTop.SuspendLayout();
            this.rgConnection.SuspendLayout();
            this.rgAuth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmPoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evPssdiag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetails)).BeginInit();
            this.paPlat.SuspendLayout();
            this.paPlatClient.SuspendLayout();
            this.paLeftTop.SuspendLayout();
            this.tcPlat.SuspendLayout();
            this.SuspendLayout();
            // 
            // paTop
            // 
            this.paTop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.paTop.Controls.Add(this.edCaseNumber);
            this.paTop.Controls.Add(this.label1);
            this.paTop.Controls.Add(this.paTopLeft);
            this.paTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paTop.Location = new System.Drawing.Point(0, 0);
            this.paTop.Name = "paTop";
            this.paTop.Size = new System.Drawing.Size(896, 48);
            this.paTop.TabIndex = 0;
            this.paTop.TabStop = true;
            // 
            // edCaseNumber
            // 
            this.edCaseNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edCaseNumber.Location = new System.Drawing.Point(788, 14);
            this.edCaseNumber.MaxLength = 20;
            this.edCaseNumber.Name = "edCaseNumber";
            this.edCaseNumber.Size = new System.Drawing.Size(102, 20);
            this.edCaseNumber.TabIndex = 1;
            this.edCaseNumber.Visible = ((bool)(configurationAppSettings.GetValue("UserMode", typeof(bool))));
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(759, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Case";
            this.label1.Visible = ((bool)(configurationAppSettings.GetValue("UserMode", typeof(bool))));
            // 
            // paTopLeft
            // 
            this.paTopLeft.Controls.Add(this.edAppName);
            this.paTopLeft.Controls.Add(this.laAppName);
            this.paTopLeft.Controls.Add(this.edTargetMachine);
            this.paTopLeft.Controls.Add(this.laTargetMachine);
            this.paTopLeft.Controls.Add(this.tbMain);
            this.paTopLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.paTopLeft.Location = new System.Drawing.Point(0, 0);
            this.paTopLeft.Name = "paTopLeft";
            this.paTopLeft.Size = new System.Drawing.Size(632, 44);
            this.paTopLeft.TabIndex = 1;
            // 
            // edAppName
            // 
            this.edAppName.Enabled = false;
            this.edAppName.Location = new System.Drawing.Point(528, 14);
            this.edAppName.MaxLength = 128;
            this.edAppName.Name = "edAppName";
            this.edAppName.ReadOnly = true;
            this.edAppName.Size = new System.Drawing.Size(88, 20);
            this.edAppName.TabIndex = 4;
            // 
            // laAppName
            // 
            this.laAppName.Location = new System.Drawing.Point(472, 16);
            this.laAppName.Name = "laAppName";
            this.laAppName.Size = new System.Drawing.Size(62, 16);
            this.laAppName.TabIndex = 3;
            this.laAppName.Text = "AppName";
            // 
            // edTargetMachine
            // 
            this.edTargetMachine.Enabled = false;
            this.edTargetMachine.Location = new System.Drawing.Point(368, 14);
            this.edTargetMachine.MaxLength = 128;
            this.edTargetMachine.Name = "edTargetMachine";
            this.edTargetMachine.Size = new System.Drawing.Size(98, 20);
            this.edTargetMachine.TabIndex = 2;
            // 
            // laTargetMachine
            // 
            this.laTargetMachine.Location = new System.Drawing.Point(320, 16);
            this.laTargetMachine.Name = "laTargetMachine";
            this.laTargetMachine.Size = new System.Drawing.Size(48, 16);
            this.laTargetMachine.TabIndex = 1;
            this.laTargetMachine.Text = "Machine";
            // 
            // tbMain
            // 
            this.tbMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.btOpen,
            this.btMerge,
            this.btSave,
            this.btAnalyze,
            this.toolBarButton3,
            this.toolBarButton4,
            this.toolBarButton5,
            this.toolBarButton6,
            this.toolBarButton7,
            this.toolBarButton8,
            this.toolBarButton9,
            this.btStart,
            this.btStop});
            this.tbMain.DropDownArrows = true;
            this.tbMain.ImageList = this.imGlyphs;
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.ShowToolTips = true;
            this.tbMain.Size = new System.Drawing.Size(632, 42);
            this.tbMain.TabIndex = 0;
            this.tbMain.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbMain_ButtonClick);
            // 
            // btOpen
            // 
            this.btOpen.ImageIndex = 0;
            this.btOpen.Name = "btOpen";
            this.btOpen.Text = "Open";
            // 
            // btMerge
            // 
            this.btMerge.ImageIndex = 5;
            this.btMerge.Name = "btMerge";
            this.btMerge.Text = "Merge";
            this.btMerge.Visible = false;
            // 
            // btSave
            // 
            this.btSave.ImageIndex = 1;
            this.btSave.Name = "btSave";
            this.btSave.Text = "Save";
            // 
            // btAnalyze
            // 
            this.btAnalyze.DropDownMenu = this.cmAnalyze;
            this.btAnalyze.ImageIndex = 2;
            this.btAnalyze.Name = "btAnalyze";
            this.btAnalyze.Text = "Analyze";
            // 
            // cmAnalyze
            // 
            this.cmAnalyze.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem6,
            this.menuItem1,
            this.menuItem2,
            this.menuItem4,
            this.menuItem3});
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 0;
            this.menuItem6.Text = "SQL Nexus";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 1;
            this.menuItem1.Text = "&SQLDiag Viewer";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.Text = "S&peedSearch";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            this.menuItem4.Text = "&Ostress GUI";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 4;
            this.menuItem3.Text = "RowsetImport";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButton4
            // 
            this.toolBarButton4.Name = "toolBarButton4";
            this.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButton5
            // 
            this.toolBarButton5.Name = "toolBarButton5";
            this.toolBarButton5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButton6
            // 
            this.toolBarButton6.Name = "toolBarButton6";
            this.toolBarButton6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButton7
            // 
            this.toolBarButton7.Name = "toolBarButton7";
            this.toolBarButton7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButton8
            // 
            this.toolBarButton8.Name = "toolBarButton8";
            this.toolBarButton8.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButton9
            // 
            this.toolBarButton9.Name = "toolBarButton9";
            this.toolBarButton9.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // btStart
            // 
            this.btStart.Enabled = false;
            this.btStart.ImageIndex = 8;
            this.btStart.Name = "btStart";
            this.btStart.Text = "Start";
            // 
            // btStop
            // 
            this.btStop.Enabled = false;
            this.btStop.ImageIndex = 9;
            this.btStop.Name = "btStop";
            this.btStop.Text = "Stop";
            // 
            // imGlyphs
            // 
            this.imGlyphs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imGlyphs.ImageStream")));
            this.imGlyphs.TransparentColor = System.Drawing.SystemColors.Window;
            this.imGlyphs.Images.SetKeyName(0, "");
            this.imGlyphs.Images.SetKeyName(1, "");
            this.imGlyphs.Images.SetKeyName(2, "");
            this.imGlyphs.Images.SetKeyName(3, "");
            this.imGlyphs.Images.SetKeyName(4, "");
            this.imGlyphs.Images.SetKeyName(5, "");
            this.imGlyphs.Images.SetKeyName(6, "");
            this.imGlyphs.Images.SetKeyName(7, "");
            this.imGlyphs.Images.SetKeyName(8, "");
            this.imGlyphs.Images.SetKeyName(9, "");
            this.imGlyphs.Images.SetKeyName(10, "");
            this.imGlyphs.Images.SetKeyName(11, "");
            this.imGlyphs.Images.SetKeyName(12, "");
            // 
            // spLeft
            // 
            this.spLeft.Location = new System.Drawing.Point(90, 48);
            this.spLeft.Name = "spLeft";
            this.spLeft.Size = new System.Drawing.Size(3, 515);
            this.spLeft.TabIndex = 0;
            this.spLeft.TabStop = false;
            // 
            // paBottom
            // 
            this.paBottom.Controls.Add(this.tcInstructions);
            this.paBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.paBottom.Location = new System.Drawing.Point(0, 566);
            this.paBottom.Name = "paBottom";
            this.paBottom.Size = new System.Drawing.Size(896, 160);
            this.paBottom.TabIndex = 3;
            // 
            // tcInstructions
            // 
            this.tcInstructions.Controls.Add(this.tpInstructions);
            this.tcInstructions.Controls.Add(this.tpOutput);
            this.tcInstructions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcInstructions.Location = new System.Drawing.Point(0, 0);
            this.tcInstructions.Name = "tcInstructions";
            this.tcInstructions.SelectedIndex = 0;
            this.tcInstructions.Size = new System.Drawing.Size(896, 160);
            this.tcInstructions.TabIndex = 0;
            // 
            // tpInstructions
            // 
            this.tpInstructions.Controls.Add(this.reInstructions);
            this.tpInstructions.Location = new System.Drawing.Point(4, 22);
            this.tpInstructions.Name = "tpInstructions";
            this.tpInstructions.Size = new System.Drawing.Size(888, 134);
            this.tpInstructions.TabIndex = 0;
            this.tpInstructions.Text = "Instructions";
            // 
            // reInstructions
            // 
            this.reInstructions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.reInstructions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reInstructions.Location = new System.Drawing.Point(0, 0);
            this.reInstructions.Name = "reInstructions";
            this.reInstructions.ReadOnly = true;
            this.reInstructions.Size = new System.Drawing.Size(888, 134);
            this.reInstructions.TabIndex = 0;
            this.reInstructions.Text = "";
            // 
            // tpOutput
            // 
            this.tpOutput.Controls.Add(this.reStrings);
            this.tpOutput.Controls.Add(this.splitter1);
            this.tpOutput.Controls.Add(this.lvOutput);
            this.tpOutput.Location = new System.Drawing.Point(4, 22);
            this.tpOutput.Name = "tpOutput";
            this.tpOutput.Size = new System.Drawing.Size(888, 134);
            this.tpOutput.TabIndex = 1;
            this.tpOutput.Text = "Output";
            this.tpOutput.Visible = false;
            // 
            // reStrings
            // 
            this.reStrings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reStrings.Location = new System.Drawing.Point(0, 75);
            this.reStrings.Name = "reStrings";
            this.reStrings.Size = new System.Drawing.Size(888, 59);
            this.reStrings.TabIndex = 2;
            this.reStrings.Text = "";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 72);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(888, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // lvOutput
            // 
            this.lvOutput.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chType,
            this.chMsg});
            this.lvOutput.ContextMenu = this.cmOutput;
            this.lvOutput.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvOutput.FullRowSelect = true;
            this.lvOutput.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvOutput.HideSelection = false;
            this.lvOutput.Location = new System.Drawing.Point(0, 0);
            this.lvOutput.MultiSelect = false;
            this.lvOutput.Name = "lvOutput";
            this.lvOutput.Size = new System.Drawing.Size(888, 72);
            this.lvOutput.SmallImageList = this.imGlyphs;
            this.lvOutput.TabIndex = 0;
            this.lvOutput.UseCompatibleStateImageBehavior = false;
            this.lvOutput.View = System.Windows.Forms.View.Details;
            this.lvOutput.SelectedIndexChanged += new System.EventHandler(this.lvOutput_SelectedIndexChanged);
            // 
            // chType
            // 
            this.chType.Text = "Type";
            this.chType.Width = 80;
            // 
            // chMsg
            // 
            this.chMsg.Text = "Message";
            this.chMsg.Width = 1024;
            // 
            // cmOutput
            // 
            this.cmOutput.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem5});
            this.cmOutput.Popup += new System.EventHandler(this.cmOutput_Popup);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 0;
            this.menuItem5.Text = "&Update";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // spBottom
            // 
            this.spBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.spBottom.Location = new System.Drawing.Point(0, 563);
            this.spBottom.Name = "spBottom";
            this.spBottom.Size = new System.Drawing.Size(896, 3);
            this.spBottom.TabIndex = 4;
            this.spBottom.TabStop = false;
            // 
            // tcVersion
            // 
            this.tcVersion.Controls.Add(this.tp70);
            this.tcVersion.Controls.Add(this.tp2K);
            this.tcVersion.Controls.Add(this.tp2K5);
            this.tcVersion.Controls.Add(this.tp2k8);
            this.tcVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcVersion.ImageList = this.imGlyphs;
            this.tcVersion.Location = new System.Drawing.Point(93, 48);
            this.tcVersion.Name = "tcVersion";
            this.tcVersion.SelectedIndex = 3;
            this.tcVersion.Size = new System.Drawing.Size(803, 24);
            this.tcVersion.TabIndex = 1;
            this.tcVersion.Visible = ((bool)(configurationAppSettings.GetValue("FullConfig", typeof(bool))));
            this.tcVersion.Click += new System.EventHandler(this.tcVersion_Click);
            this.tcVersion.Validating += new System.ComponentModel.CancelEventHandler(this.tcVersion_Validating);
            this.tcVersion.SelectedIndexChanged += new System.EventHandler(this.tcVersion_SelectedIndexChanged);
            // 
            // tp70
            // 
            this.tp70.BackColor = System.Drawing.SystemColors.Control;
            this.tp70.Location = new System.Drawing.Point(4, 23);
            this.tp70.Name = "tp70";
            this.tp70.Size = new System.Drawing.Size(795, 0);
            this.tp70.TabIndex = 0;
            this.tp70.Tag = "0";
            this.tp70.Text = "SQL Server 7.0";
            // 
            // tp2K
            // 
            this.tp2K.Location = new System.Drawing.Point(4, 23);
            this.tp2K.Name = "tp2K";
            this.tp2K.Size = new System.Drawing.Size(795, 0);
            this.tp2K.TabIndex = 1;
            this.tp2K.Tag = "1";
            this.tp2K.Text = "SQL Server 2000";
            // 
            // tp2K5
            // 
            this.tp2K5.Location = new System.Drawing.Point(4, 23);
            this.tp2K5.Name = "tp2K5";
            this.tp2K5.Size = new System.Drawing.Size(795, 0);
            this.tp2K5.TabIndex = 2;
            this.tp2K5.Tag = "2";
            this.tp2K5.Text = "SQL Server 2005";
            this.tp2K5.Leave += new System.EventHandler(this.tp2K5_Leave);
            // 
            // tp2k8
            // 
            this.tp2k8.Location = new System.Drawing.Point(4, 23);
            this.tp2k8.Name = "tp2k8";
            this.tp2k8.Size = new System.Drawing.Size(795, 0);
            this.tp2k8.TabIndex = 3;
            this.tp2k8.Text = "SQL Server 2008";
            // 
            // paClient
            // 
            this.paClient.Controls.Add(this.rgCustom);
            this.paClient.Controls.Add(this.splitter5);
            this.paClient.Controls.Add(this.paClientRightTop);
            this.paClient.Controls.Add(this.splitter3);
            this.paClient.Controls.Add(this.paClientLeft);
            this.paClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paClient.Location = new System.Drawing.Point(93, 72);
            this.paClient.Name = "paClient";
            this.paClient.Size = new System.Drawing.Size(803, 491);
            this.paClient.TabIndex = 2;
            // 
            // rgCustom
            // 
            this.rgCustom.Controls.Add(this.lvCustomGroups);
            this.rgCustom.Controls.Add(this.tbCustomGroups);
            this.rgCustom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgCustom.Location = new System.Drawing.Point(387, 243);
            this.rgCustom.Name = "rgCustom";
            this.rgCustom.Size = new System.Drawing.Size(416, 248);
            this.rgCustom.TabIndex = 2;
            this.rgCustom.TabStop = false;
            this.rgCustom.Text = "Custom Diagnostics";
            // 
            // lvCustomGroups
            // 
            this.lvCustomGroups.CheckBoxes = true;
            this.lvCustomGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colGroup});
            this.lvCustomGroups.ContextMenu = this.cmCustomDiag;
            this.lvCustomGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCustomGroups.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvCustomGroups.HideSelection = false;
            this.lvCustomGroups.Location = new System.Drawing.Point(3, 42);
            this.lvCustomGroups.MultiSelect = false;
            this.lvCustomGroups.Name = "lvCustomGroups";
            this.lvCustomGroups.Size = new System.Drawing.Size(410, 203);
            this.lvCustomGroups.TabIndex = 1;
            this.lvCustomGroups.UseCompatibleStateImageBehavior = false;
            this.lvCustomGroups.View = System.Windows.Forms.View.Details;
            this.lvCustomGroups.SelectedIndexChanged += new System.EventHandler(this.lvCustomGroups_SelectedIndexChanged);
            // 
            // colGroup
            // 
            this.colGroup.Text = "Group";
            this.colGroup.Width = 397;
            // 
            // cmCustomDiag
            // 
            this.cmCustomDiag.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miDetails});
            // 
            // miDetails
            // 
            this.miDetails.Index = 0;
            this.miDetails.Text = "&Details";
            this.miDetails.Click += new System.EventHandler(this.miDetails_Click);
            // 
            // tbCustomGroups
            // 
            this.tbCustomGroups.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.btUp,
            this.btDown});
            this.tbCustomGroups.Divider = false;
            this.tbCustomGroups.DropDownArrows = true;
            this.tbCustomGroups.ImageList = this.imGlyphs;
            this.tbCustomGroups.Location = new System.Drawing.Point(3, 16);
            this.tbCustomGroups.Name = "tbCustomGroups";
            this.tbCustomGroups.ShowToolTips = true;
            this.tbCustomGroups.Size = new System.Drawing.Size(410, 26);
            this.tbCustomGroups.TabIndex = 0;
            this.tbCustomGroups.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbCustomGroups_ButtonClick);
            // 
            // btUp
            // 
            this.btUp.ImageIndex = 3;
            this.btUp.Name = "btUp";
            // 
            // btDown
            // 
            this.btDown.ImageIndex = 4;
            this.btDown.Name = "btDown";
            // 
            // splitter5
            // 
            this.splitter5.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter5.Location = new System.Drawing.Point(387, 240);
            this.splitter5.Name = "splitter5";
            this.splitter5.Size = new System.Drawing.Size(416, 3);
            this.splitter5.TabIndex = 3;
            this.splitter5.TabStop = false;
            this.splitter5.Visible = ((bool)(configurationAppSettings.GetValue("FullConfig", typeof(bool))));
            // 
            // paClientRightTop
            // 
            this.paClientRightTop.Controls.Add(this.rgInstanceDiagnostics);
            this.paClientRightTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paClientRightTop.Location = new System.Drawing.Point(387, 0);
            this.paClientRightTop.Name = "paClientRightTop";
            this.paClientRightTop.Size = new System.Drawing.Size(416, 240);
            this.paClientRightTop.TabIndex = 1;
            this.paClientRightTop.Visible = ((bool)(configurationAppSettings.GetValue("FullConfig", typeof(bool))));
            // 
            // rgInstanceDiagnostics
            // 
            this.rgInstanceDiagnostics.Controls.Add(this.tcTrace);
            this.rgInstanceDiagnostics.Controls.Add(this.paInstanceTop);
            this.rgInstanceDiagnostics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgInstanceDiagnostics.Location = new System.Drawing.Point(0, 0);
            this.rgInstanceDiagnostics.Name = "rgInstanceDiagnostics";
            this.rgInstanceDiagnostics.Size = new System.Drawing.Size(416, 240);
            this.rgInstanceDiagnostics.TabIndex = 0;
            this.rgInstanceDiagnostics.TabStop = false;
            this.rgInstanceDiagnostics.Text = "Instance-specific Diagnostics";
            // 
            // tcTrace
            // 
            this.tcTrace.Controls.Add(this.tpDatabase);
            this.tcTrace.Controls.Add(this.tpAS);
            this.tcTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcTrace.Location = new System.Drawing.Point(3, 71);
            this.tcTrace.Multiline = true;
            this.tcTrace.Name = "tcTrace";
            this.tcTrace.SelectedIndex = 0;
            this.tcTrace.Size = new System.Drawing.Size(410, 166);
            this.tcTrace.TabIndex = 2;
            this.tcTrace.SelectedIndexChanged += new System.EventHandler(this.tcTrace_SelectedIndexChanged);
            // 
            // tpDatabase
            // 
            this.tpDatabase.Controls.Add(this.tvProfiler);
            this.tpDatabase.Controls.Add(this.panel1);
            this.tpDatabase.Location = new System.Drawing.Point(4, 22);
            this.tpDatabase.Name = "tpDatabase";
            this.tpDatabase.Size = new System.Drawing.Size(402, 140);
            this.tpDatabase.TabIndex = 0;
            this.tpDatabase.Text = "Database Engine";
            // 
            // tvProfiler
            // 
            this.tvProfiler.CheckBoxes = true;
            this.tvProfiler.ContextMenu = this.cmTrace;
            this.tvProfiler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvProfiler.Location = new System.Drawing.Point(0, 32);
            this.tvProfiler.Name = "tvProfiler";
            this.tvProfiler.Size = new System.Drawing.Size(402, 108);
            this.tvProfiler.TabIndex = 4;
            this.tvProfiler.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvPM_AfterCheck);
            // 
            // cmTrace
            // 
            this.cmTrace.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem7});
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 0;
            this.menuItem7.Text = "Filters";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbProfilerMaxFileSize);
            this.panel1.Controls.Add(this.cbProfilerTemplate);
            this.panel1.Controls.Add(this.laProfilerTemplate);
            this.panel1.Controls.Add(this.ckProfiler);
            this.panel1.Controls.Add(this.laProfilerMaxFileSize);
            this.panel1.Controls.Add(this.laProfilerInterval);
            this.panel1.Controls.Add(this.cbProfilerInterval);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 32);
            this.panel1.TabIndex = 0;
            // 
            // cbProfilerMaxFileSize
            // 
            this.cbProfilerMaxFileSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfilerMaxFileSize.Items.AddRange(new object[] {
            "None",
            "5",
            "50",
            "100",
            "350",
            "500",
            "1000"});
            this.cbProfilerMaxFileSize.Location = new System.Drawing.Point(345, 6);
            this.cbProfilerMaxFileSize.Name = "cbProfilerMaxFileSize";
            this.cbProfilerMaxFileSize.Size = new System.Drawing.Size(55, 21);
            this.cbProfilerMaxFileSize.TabIndex = 17;
            this.cbProfilerMaxFileSize.Visible = false;
            this.cbProfilerMaxFileSize.SelectedIndexChanged += new System.EventHandler(this.cbProfilerMaxFileSize_SelectedIndexChanged);
            // 
            // cbProfilerTemplate
            // 
            this.cbProfilerTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfilerTemplate.DropDownWidth = 150;
            this.cbProfilerTemplate.ItemHeight = 13;
            this.cbProfilerTemplate.Location = new System.Drawing.Point(119, 6);
            this.cbProfilerTemplate.Name = "cbProfilerTemplate";
            this.cbProfilerTemplate.Size = new System.Drawing.Size(144, 21);
            this.cbProfilerTemplate.Sorted = true;
            this.cbProfilerTemplate.TabIndex = 15;
            this.cbProfilerTemplate.SelectedIndexChanged += new System.EventHandler(this.cbProfilerTemplate_SelectedIndexChanged);
            // 
            // laProfilerTemplate
            // 
            this.laProfilerTemplate.Location = new System.Drawing.Point(67, 10);
            this.laProfilerTemplate.Name = "laProfilerTemplate";
            this.laProfilerTemplate.Size = new System.Drawing.Size(57, 14);
            this.laProfilerTemplate.TabIndex = 14;
            this.laProfilerTemplate.Text = "Template";
            // 
            // ckProfiler
            // 
            this.ckProfiler.Location = new System.Drawing.Point(3, 10);
            this.ckProfiler.Name = "ckProfiler";
            this.ckProfiler.Size = new System.Drawing.Size(64, 14);
            this.ckProfiler.TabIndex = 13;
            this.ckProfiler.Text = "Trace";
            this.ckProfiler.CheckedChanged += new System.EventHandler(this.ckProfiler_CheckedChanged);
            // 
            // laProfilerMaxFileSize
            // 
            this.laProfilerMaxFileSize.Location = new System.Drawing.Point(273, 10);
            this.laProfilerMaxFileSize.Name = "laProfilerMaxFileSize";
            this.laProfilerMaxFileSize.Size = new System.Drawing.Size(72, 14);
            this.laProfilerMaxFileSize.TabIndex = 16;
            this.laProfilerMaxFileSize.Text = "Max file size";
            // 
            // laProfilerInterval
            // 
            this.laProfilerInterval.Location = new System.Drawing.Point(272, 10);
            this.laProfilerInterval.Name = "laProfilerInterval";
            this.laProfilerInterval.Size = new System.Drawing.Size(82, 16);
            this.laProfilerInterval.TabIndex = 18;
            this.laProfilerInterval.Text = "Interval (mins)";
            this.laProfilerInterval.Visible = false;
            // 
            // cbProfilerInterval
            // 
            this.cbProfilerInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProfilerInterval.Items.AddRange(new object[] {
            "5",
            "15",
            "30",
            "60"});
            this.cbProfilerInterval.Location = new System.Drawing.Point(344, 6);
            this.cbProfilerInterval.Name = "cbProfilerInterval";
            this.cbProfilerInterval.Size = new System.Drawing.Size(55, 21);
            this.cbProfilerInterval.TabIndex = 19;
            this.cbProfilerInterval.Visible = false;
            // 
            // tpAS
            // 
            this.tpAS.Controls.Add(this.tvASProfiler);
            this.tpAS.Controls.Add(this.panel2);
            this.tpAS.Location = new System.Drawing.Point(4, 22);
            this.tpAS.Name = "tpAS";
            this.tpAS.Size = new System.Drawing.Size(402, 140);
            this.tpAS.TabIndex = 1;
            this.tpAS.Text = "Analysis Services";
            // 
            // tvASProfiler
            // 
            this.tvASProfiler.CheckBoxes = true;
            this.tvASProfiler.ContextMenu = this.cmTrace;
            this.tvASProfiler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvASProfiler.Location = new System.Drawing.Point(0, 32);
            this.tvASProfiler.Name = "tvASProfiler";
            this.tvASProfiler.Size = new System.Drawing.Size(402, 108);
            this.tvASProfiler.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ckASProfiler);
            this.panel2.Controls.Add(this.laASProfilerMaxFileSize);
            this.panel2.Controls.Add(this.cbASProfilerMaxFileSize);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(402, 32);
            this.panel2.TabIndex = 1;
            // 
            // ckASProfiler
            // 
            this.ckASProfiler.Location = new System.Drawing.Point(3, 10);
            this.ckASProfiler.Name = "ckASProfiler";
            this.ckASProfiler.Size = new System.Drawing.Size(64, 14);
            this.ckASProfiler.TabIndex = 13;
            this.ckASProfiler.Text = "Trace";
            this.ckASProfiler.CheckedChanged += new System.EventHandler(this.ckASProfiler_CheckedChanged);
            // 
            // laASProfilerMaxFileSize
            // 
            this.laASProfilerMaxFileSize.Location = new System.Drawing.Point(273, 10);
            this.laASProfilerMaxFileSize.Name = "laASProfilerMaxFileSize";
            this.laASProfilerMaxFileSize.Size = new System.Drawing.Size(72, 14);
            this.laASProfilerMaxFileSize.TabIndex = 16;
            this.laASProfilerMaxFileSize.Text = "Max file size";
            // 
            // cbASProfilerMaxFileSize
            // 
            this.cbASProfilerMaxFileSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbASProfilerMaxFileSize.Items.AddRange(new object[] {
            "None",
            "5",
            "50",
            "100",
            "350",
            "500",
            "1000"});
            this.cbASProfilerMaxFileSize.Location = new System.Drawing.Point(345, 6);
            this.cbASProfilerMaxFileSize.Name = "cbASProfilerMaxFileSize";
            this.cbASProfilerMaxFileSize.Size = new System.Drawing.Size(55, 21);
            this.cbASProfilerMaxFileSize.TabIndex = 17;
            this.cbASProfilerMaxFileSize.SelectedIndexChanged += new System.EventHandler(this.cbASProfilerMaxFileSize_SelectedIndexChanged);
            // 
            // paInstanceTop
            // 
            this.paInstanceTop.Controls.Add(this.cbBSInterval);
            this.paInstanceTop.Controls.Add(this.laBSInterval);
            this.paInstanceTop.Controls.Add(this.ckBSFast);
            this.paInstanceTop.Controls.Add(this.ckBSLatch);
            this.paInstanceTop.Controls.Add(this.ckBlocker);
            this.paInstanceTop.Controls.Add(this.ckSDShutdown);
            this.paInstanceTop.Controls.Add(this.ckSDStartup);
            this.paInstanceTop.Controls.Add(this.ckSqldiag);
            this.paInstanceTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paInstanceTop.Location = new System.Drawing.Point(3, 16);
            this.paInstanceTop.Name = "paInstanceTop";
            this.paInstanceTop.Size = new System.Drawing.Size(410, 55);
            this.paInstanceTop.TabIndex = 1;
            // 
            // cbBSInterval
            // 
            this.cbBSInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBSInterval.Items.AddRange(new object[] {
            "5",
            "15",
            "30",
            "60"});
            this.cbBSInterval.Location = new System.Drawing.Point(280, 29);
            this.cbBSInterval.Name = "cbBSInterval";
            this.cbBSInterval.Size = new System.Drawing.Size(55, 21);
            this.cbBSInterval.TabIndex = 7;
            this.cbBSInterval.Visible = false;
            this.cbBSInterval.SelectedIndexChanged += new System.EventHandler(this.cbProfilerMaxFileSize_SelectedIndexChanged);
            // 
            // laBSInterval
            // 
            this.laBSInterval.Location = new System.Drawing.Point(206, 32);
            this.laBSInterval.Name = "laBSInterval";
            this.laBSInterval.Size = new System.Drawing.Size(80, 16);
            this.laBSInterval.TabIndex = 6;
            this.laBSInterval.Text = "Interval (secs)";
            this.laBSInterval.Visible = false;
            // 
            // ckBSFast
            // 
            this.ckBSFast.Checked = true;
            this.ckBSFast.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckBSFast.Location = new System.Drawing.Point(152, 31);
            this.ckBSFast.Name = "ckBSFast";
            this.ckBSFast.Size = new System.Drawing.Size(50, 16);
            this.ckBSFast.TabIndex = 5;
            this.ckBSFast.Text = "Fast";
            this.ckBSFast.Visible = false;
            this.ckBSFast.CheckedChanged += new System.EventHandler(this.ckBSLatch_CheckedChanged);
            // 
            // ckBSLatch
            // 
            this.ckBSLatch.Location = new System.Drawing.Point(88, 31);
            this.ckBSLatch.Name = "ckBSLatch";
            this.ckBSLatch.Size = new System.Drawing.Size(56, 16);
            this.ckBSLatch.TabIndex = 4;
            this.ckBSLatch.Text = "Latch";
            this.ckBSLatch.Visible = false;
            this.ckBSLatch.CheckedChanged += new System.EventHandler(this.ckBSLatch_CheckedChanged);
            // 
            // ckBlocker
            // 
            this.ckBlocker.Location = new System.Drawing.Point(4, 31);
            this.ckBlocker.Name = "ckBlocker";
            this.ckBlocker.Size = new System.Drawing.Size(68, 16);
            this.ckBlocker.TabIndex = 3;
            this.ckBlocker.Text = "Blocking";
            this.ckBlocker.Visible = false;
            this.ckBlocker.CheckedChanged += new System.EventHandler(this.ckBlocker_CheckedChanged);
            // 
            // ckSDShutdown
            // 
            this.ckSDShutdown.Checked = true;
            this.ckSDShutdown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckSDShutdown.Location = new System.Drawing.Point(152, 8);
            this.ckSDShutdown.Name = "ckSDShutdown";
            this.ckSDShutdown.Size = new System.Drawing.Size(74, 16);
            this.ckSDShutdown.TabIndex = 2;
            this.ckSDShutdown.Text = "Shutdown";
            this.ckSDShutdown.CheckedChanged += new System.EventHandler(this.ckBSLatch_CheckedChanged);
            // 
            // ckSDStartup
            // 
            this.ckSDStartup.Location = new System.Drawing.Point(88, 8);
            this.ckSDStartup.Name = "ckSDStartup";
            this.ckSDStartup.Size = new System.Drawing.Size(64, 16);
            this.ckSDStartup.TabIndex = 1;
            this.ckSDStartup.Text = "Startup";
            this.ckSDStartup.CheckedChanged += new System.EventHandler(this.ckBSLatch_CheckedChanged);
            // 
            // ckSqldiag
            // 
            this.ckSqldiag.Checked = true;
            this.ckSqldiag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckSqldiag.Location = new System.Drawing.Point(4, 8);
            this.ckSqldiag.Name = "ckSqldiag";
            this.ckSqldiag.Size = new System.Drawing.Size(76, 16);
            this.ckSqldiag.TabIndex = 0;
            this.ckSqldiag.Text = "SQLDIAG";
            this.ckSqldiag.CheckedChanged += new System.EventHandler(this.ckSqldiag_CheckedChanged);
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(384, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 491);
            this.splitter3.TabIndex = 1;
            this.splitter3.TabStop = false;
            // 
            // paClientLeft
            // 
            this.paClientLeft.Controls.Add(this.rgMachineDiagnostics);
            this.paClientLeft.Controls.Add(this.splitter4);
            this.paClientLeft.Controls.Add(this.rgConnection);
            this.paClientLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.paClientLeft.Location = new System.Drawing.Point(0, 0);
            this.paClientLeft.Name = "paClientLeft";
            this.paClientLeft.Size = new System.Drawing.Size(384, 491);
            this.paClientLeft.TabIndex = 0;
            this.paClientLeft.Visible = ((bool)(configurationAppSettings.GetValue("FullConfig", typeof(bool))));
            // 
            // rgMachineDiagnostics
            // 
            this.rgMachineDiagnostics.Controls.Add(this.tvPM);
            this.rgMachineDiagnostics.Controls.Add(this.paPMTop);
            this.rgMachineDiagnostics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgMachineDiagnostics.Location = new System.Drawing.Point(0, 243);
            this.rgMachineDiagnostics.Name = "rgMachineDiagnostics";
            this.rgMachineDiagnostics.Size = new System.Drawing.Size(384, 248);
            this.rgMachineDiagnostics.TabIndex = 1;
            this.rgMachineDiagnostics.TabStop = false;
            this.rgMachineDiagnostics.Text = "Machine-wide Diagnostics";
            // 
            // tvPM
            // 
            this.tvPM.CheckBoxes = true;
            this.tvPM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPM.Location = new System.Drawing.Point(3, 71);
            this.tvPM.Name = "tvPM";
            this.tvPM.Size = new System.Drawing.Size(378, 174);
            this.tvPM.TabIndex = 1;
            this.tvPM.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvPM_AfterCheck);
            // 
            // paPMTop
            // 
            this.paPMTop.Controls.Add(this.cbPMInterval);
            this.paPMTop.Controls.Add(this.laPMInterval);
            this.paPMTop.Controls.Add(this.cbPMMaxFileSize);
            this.paPMTop.Controls.Add(this.laPMMaxFileSize);
            this.paPMTop.Controls.Add(this.ckPerfmon);
            this.paPMTop.Controls.Add(this.ckEventLogsShutdown);
            this.paPMTop.Controls.Add(this.ckEventLogsStartup);
            this.paPMTop.Controls.Add(this.ckEventLogs);
            this.paPMTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paPMTop.Location = new System.Drawing.Point(3, 16);
            this.paPMTop.Name = "paPMTop";
            this.paPMTop.Size = new System.Drawing.Size(378, 55);
            this.paPMTop.TabIndex = 0;
            // 
            // cbPMInterval
            // 
            this.cbPMInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPMInterval.Items.AddRange(new object[] {
            "5",
            "15",
            "30",
            "60"});
            this.cbPMInterval.Location = new System.Drawing.Point(292, 32);
            this.cbPMInterval.Name = "cbPMInterval";
            this.cbPMInterval.Size = new System.Drawing.Size(55, 21);
            this.cbPMInterval.TabIndex = 7;
            this.cbPMInterval.SelectedIndexChanged += new System.EventHandler(this.cbProfilerMaxFileSize_SelectedIndexChanged);
            // 
            // laPMInterval
            // 
            this.laPMInterval.Location = new System.Drawing.Point(219, 34);
            this.laPMInterval.Name = "laPMInterval";
            this.laPMInterval.Size = new System.Drawing.Size(80, 16);
            this.laPMInterval.TabIndex = 6;
            this.laPMInterval.Text = "Interval (secs)";
            // 
            // cbPMMaxFileSize
            // 
            this.cbPMMaxFileSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPMMaxFileSize.Items.AddRange(new object[] {
            "None",
            "50",
            "100",
            "150",
            "200",
            "256",
            "512",
            "1024"});
            this.cbPMMaxFileSize.Location = new System.Drawing.Point(157, 32);
            this.cbPMMaxFileSize.Name = "cbPMMaxFileSize";
            this.cbPMMaxFileSize.Size = new System.Drawing.Size(55, 21);
            this.cbPMMaxFileSize.TabIndex = 5;
            this.cbPMMaxFileSize.SelectedIndexChanged += new System.EventHandler(this.cbProfilerMaxFileSize_SelectedIndexChanged);
            // 
            // laPMMaxFileSize
            // 
            this.laPMMaxFileSize.Location = new System.Drawing.Point(92, 34);
            this.laPMMaxFileSize.Name = "laPMMaxFileSize";
            this.laPMMaxFileSize.Size = new System.Drawing.Size(66, 16);
            this.laPMMaxFileSize.TabIndex = 4;
            this.laPMMaxFileSize.Text = "Max file size";
            // 
            // ckPerfmon
            // 
            this.ckPerfmon.Location = new System.Drawing.Point(4, 32);
            this.ckPerfmon.Name = "ckPerfmon";
            this.ckPerfmon.Size = new System.Drawing.Size(72, 16);
            this.ckPerfmon.TabIndex = 3;
            this.ckPerfmon.Text = "Perfmon";
            this.ckPerfmon.CheckedChanged += new System.EventHandler(this.ckPerfmon_CheckedChanged);
            // 
            // ckEventLogsShutdown
            // 
            this.ckEventLogsShutdown.Checked = true;
            this.ckEventLogsShutdown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckEventLogsShutdown.Location = new System.Drawing.Point(151, 4);
            this.ckEventLogsShutdown.Name = "ckEventLogsShutdown";
            this.ckEventLogsShutdown.Size = new System.Drawing.Size(75, 16);
            this.ckEventLogsShutdown.TabIndex = 2;
            this.ckEventLogsShutdown.Text = "Shutdown";
            this.ckEventLogsShutdown.CheckedChanged += new System.EventHandler(this.ckBSLatch_CheckedChanged);
            // 
            // ckEventLogsStartup
            // 
            this.ckEventLogsStartup.Location = new System.Drawing.Point(88, 4);
            this.ckEventLogsStartup.Name = "ckEventLogsStartup";
            this.ckEventLogsStartup.Size = new System.Drawing.Size(61, 16);
            this.ckEventLogsStartup.TabIndex = 1;
            this.ckEventLogsStartup.Text = "Startup";
            this.ckEventLogsStartup.CheckedChanged += new System.EventHandler(this.ckBSLatch_CheckedChanged);
            // 
            // ckEventLogs
            // 
            this.ckEventLogs.Checked = true;
            this.ckEventLogs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckEventLogs.Location = new System.Drawing.Point(4, 4);
            this.ckEventLogs.Name = "ckEventLogs";
            this.ckEventLogs.Size = new System.Drawing.Size(76, 16);
            this.ckEventLogs.TabIndex = 0;
            this.ckEventLogs.Text = "Event logs";
            this.ckEventLogs.CheckedChanged += new System.EventHandler(this.ckEventLogs_CheckedChanged);
            // 
            // splitter4
            // 
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter4.Location = new System.Drawing.Point(0, 240);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(384, 3);
            this.splitter4.TabIndex = 1;
            this.splitter4.TabStop = false;
            // 
            // rgConnection
            // 
            this.rgConnection.Controls.Add(this.rgAuth);
            this.rgConnection.Controls.Add(this.edInstance);
            this.rgConnection.Controls.Add(this.edMachine);
            this.rgConnection.Controls.Add(this.cbInstance);
            this.rgConnection.Controls.Add(this.btAddInstance);
            this.rgConnection.Controls.Add(this.btDeleteInstance);
            this.rgConnection.Controls.Add(this.btAddMachine);
            this.rgConnection.Controls.Add(this.btDeleteMachine);
            this.rgConnection.Controls.Add(this.cbMachine);
            this.rgConnection.Controls.Add(this.laInstance);
            this.rgConnection.Controls.Add(this.label2);
            this.rgConnection.Dock = System.Windows.Forms.DockStyle.Top;
            this.rgConnection.Location = new System.Drawing.Point(0, 0);
            this.rgConnection.Name = "rgConnection";
            this.rgConnection.Size = new System.Drawing.Size(384, 240);
            this.rgConnection.TabIndex = 0;
            this.rgConnection.TabStop = false;
            this.rgConnection.Text = "Connection Info";
            this.rgConnection.Enter += new System.EventHandler(this.rgConnection_Enter);
            // 
            // rgAuth
            // 
            this.rgAuth.Controls.Add(this.edLogin);
            this.rgAuth.Controls.Add(this.laLogin);
            this.rgAuth.Controls.Add(this.rbSSAuth);
            this.rgAuth.Controls.Add(this.rbWindowsAuth);
            this.rgAuth.Location = new System.Drawing.Point(8, 101);
            this.rgAuth.Name = "rgAuth";
            this.rgAuth.Size = new System.Drawing.Size(288, 115);
            this.rgAuth.TabIndex = 4;
            this.rgAuth.TabStop = false;
            this.rgAuth.Text = "Connect using:";
            // 
            // edLogin
            // 
            this.edLogin.Enabled = false;
            this.edLogin.Location = new System.Drawing.Point(129, 78);
            this.edLogin.MaxLength = 128;
            this.edLogin.Name = "edLogin";
            this.edLogin.Size = new System.Drawing.Size(127, 20);
            this.edLogin.TabIndex = 3;
            this.edLogin.TextChanged += new System.EventHandler(this.edMachine_TextChanged);
            // 
            // laLogin
            // 
            this.laLogin.Enabled = false;
            this.laLogin.Location = new System.Drawing.Point(41, 83);
            this.laLogin.Name = "laLogin";
            this.laLogin.Size = new System.Drawing.Size(69, 16);
            this.laLogin.TabIndex = 2;
            this.laLogin.Text = "Login name";
            // 
            // rbSSAuth
            // 
            this.rbSSAuth.Location = new System.Drawing.Point(24, 50);
            this.rbSSAuth.Name = "rbSSAuth";
            this.rbSSAuth.Size = new System.Drawing.Size(167, 16);
            this.rbSSAuth.TabIndex = 1;
            this.rbSSAuth.Text = "SQL Server authentication";
            this.rbSSAuth.Click += new System.EventHandler(this.rbWindowsAuth_Click);
            // 
            // rbWindowsAuth
            // 
            this.rbWindowsAuth.Checked = true;
            this.rbWindowsAuth.Location = new System.Drawing.Point(24, 21);
            this.rbWindowsAuth.Name = "rbWindowsAuth";
            this.rbWindowsAuth.Size = new System.Drawing.Size(160, 16);
            this.rbWindowsAuth.TabIndex = 0;
            this.rbWindowsAuth.TabStop = true;
            this.rbWindowsAuth.Text = "Windows authentication";
            this.rbWindowsAuth.Click += new System.EventHandler(this.rbWindowsAuth_Click);
            // 
            // edInstance
            // 
            this.edInstance.Location = new System.Drawing.Point(136, 61);
            this.edInstance.MaxLength = 128;
            this.edInstance.Name = "edInstance";
            this.edInstance.Size = new System.Drawing.Size(128, 20);
            this.edInstance.TabIndex = 3;
            this.edInstance.TextChanged += new System.EventHandler(this.edMachine_TextChanged);
            // 
            // edMachine
            // 
            this.edMachine.Enabled = ((bool)(configurationAppSettings.GetValue("UserMode", typeof(bool))));
            this.edMachine.Location = new System.Drawing.Point(136, 32);
            this.edMachine.MaxLength = 128;
            this.edMachine.Name = "edMachine";
            this.edMachine.Size = new System.Drawing.Size(128, 20);
            this.edMachine.TabIndex = 1;
            this.edMachine.TextChanged += new System.EventHandler(this.edMachine_TextChanged);
            // 
            // cbInstance
            // 
            this.cbInstance.DisplayMember = "Machine_Instances.Instances_Instance.name";
            this.cbInstance.Location = new System.Drawing.Point(136, 61);
            this.cbInstance.Name = "cbInstance";
            this.cbInstance.Size = new System.Drawing.Size(144, 21);
            this.cbInstance.TabIndex = 7;
            this.cbInstance.ValueMember = "Machine_Instances.Instances_Instance.name";
            this.cbInstance.Visible = false;
            // 
            // btAddInstance
            // 
            this.btAddInstance.ImageIndex = 7;
            this.btAddInstance.ImageList = this.imGlyphs;
            this.btAddInstance.Location = new System.Drawing.Point(280, 60);
            this.btAddInstance.Name = "btAddInstance";
            this.btAddInstance.Size = new System.Drawing.Size(24, 23);
            this.btAddInstance.TabIndex = 8;
            this.btAddInstance.Visible = false;
            // 
            // btDeleteInstance
            // 
            this.btDeleteInstance.ImageIndex = 6;
            this.btDeleteInstance.ImageList = this.imGlyphs;
            this.btDeleteInstance.Location = new System.Drawing.Point(304, 60);
            this.btDeleteInstance.Name = "btDeleteInstance";
            this.btDeleteInstance.Size = new System.Drawing.Size(24, 23);
            this.btDeleteInstance.TabIndex = 9;
            this.btDeleteInstance.Visible = false;
            // 
            // btAddMachine
            // 
            this.btAddMachine.ImageIndex = 7;
            this.btAddMachine.ImageList = this.imGlyphs;
            this.btAddMachine.Location = new System.Drawing.Point(280, 32);
            this.btAddMachine.Name = "btAddMachine";
            this.btAddMachine.Size = new System.Drawing.Size(24, 23);
            this.btAddMachine.TabIndex = 3;
            this.btAddMachine.Visible = false;
            this.btAddMachine.Click += new System.EventHandler(this.btAddMachine_Click);
            // 
            // btDeleteMachine
            // 
            this.btDeleteMachine.ForeColor = System.Drawing.Color.Coral;
            this.btDeleteMachine.ImageIndex = 6;
            this.btDeleteMachine.ImageList = this.imGlyphs;
            this.btDeleteMachine.Location = new System.Drawing.Point(304, 32);
            this.btDeleteMachine.Name = "btDeleteMachine";
            this.btDeleteMachine.Size = new System.Drawing.Size(24, 23);
            this.btDeleteMachine.TabIndex = 4;
            this.btDeleteMachine.Visible = false;
            this.btDeleteMachine.Click += new System.EventHandler(this.btDeleteMachine_Click);
            // 
            // cbMachine
            // 
            this.cbMachine.DisplayMember = "name";
            this.cbMachine.Location = new System.Drawing.Point(136, 32);
            this.cbMachine.Name = "cbMachine";
            this.cbMachine.Size = new System.Drawing.Size(144, 21);
            this.cbMachine.TabIndex = 2;
            this.cbMachine.ValueMember = "name";
            this.cbMachine.Visible = false;
            // 
            // laInstance
            // 
            this.laInstance.Location = new System.Drawing.Point(48, 63);
            this.laInstance.Name = "laInstance";
            this.laInstance.Size = new System.Drawing.Size(80, 16);
            this.laInstance.TabIndex = 2;
            this.laInstance.Text = "Instance name";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(48, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Machine name";
            // 
            // od_Cfg
            // 
            this.od_Cfg.DefaultExt = "XML";
            this.od_Cfg.Filter = "XML configuration files (*.xml)|*.xml|All files(*.*)|*.*";
            this.od_Cfg.InitialDirectory = ".\\Configurations\\I386";
            this.od_Cfg.RestoreDirectory = true;
            // 
            // sd_Cfg
            // 
            this.sd_Cfg.DefaultExt = "XML";
            this.sd_Cfg.FileName = "PSSDiag.Xml";
            this.sd_Cfg.Filter = "XML configuration files (*.xml)|*.xml|INI configuration files (*.ini)|*.INI|All f" +
                "iles(*.*)|*.*";
            this.sd_Cfg.InitialDirectory = ".\\Build";
            this.sd_Cfg.RestoreDirectory = true;
            // 
            // scPssdiag
            // 
            this.scPssdiag.ServiceName = "PSSDIAG";
            // 
            // tmPoll
            // 
            this.tmPoll.Interval = 1000;
            this.tmPoll.SynchronizingObject = this;
            this.tmPoll.Elapsed += new System.Timers.ElapsedEventHandler(this.tmPoll_Elapsed);
            // 
            // evPssdiag
            // 
            this.evPssdiag.Log = "Application";
            this.evPssdiag.SynchronizingObject = this;
            // 
            // tmOutput
            // 
            this.tmOutput.Interval = 5000;
            this.tmOutput.SynchronizingObject = this;
            this.tmOutput.Elapsed += new System.Timers.ElapsedEventHandler(this.tmOutput_Elapsed);
            // 
            // niPssdiag
            // 
            this.niPssdiag.ContextMenu = this.cmNotify;
            this.niPssdiag.Icon = ((System.Drawing.Icon)(resources.GetObject("niPssdiag.Icon")));
            this.niPssdiag.Text = "Diag Manager";
            this.niPssdiag.Visible = true;
            this.niPssdiag.DoubleClick += new System.EventHandler(this.niPssdiag_DoubleClick);
            // 
            // cmNotify
            // 
            this.cmNotify.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miStart,
            this.miStop,
            this.miExit});
            // 
            // miStart
            // 
            this.miStart.Index = 0;
            this.miStart.Text = "&Start";
            this.miStart.Click += new System.EventHandler(this.miStart_Click);
            // 
            // miStop
            // 
            this.miStop.Index = 1;
            this.miStop.Text = "S&top";
            this.miStop.Click += new System.EventHandler(this.miStop_Click);
            // 
            // miExit
            // 
            this.miExit.Index = 2;
            this.miExit.Text = "&Exit";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // dataGridBoolColumn3
            // 
            this.dataGridBoolColumn3.AllowNull = false;
            this.dataGridBoolColumn3.MappingName = "enabled";
            this.dataGridBoolColumn3.Width = 25;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.MappingName = "name";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 200;
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.ColumnHeadersVisible = false;
            this.dataGridTableStyle3.DataGrid = this.dgSummary;
            this.dataGridTableStyle3.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle3.MappingName = "CustomDiagGroup";
            this.dataGridTableStyle3.RowHeadersVisible = false;
            // 
            // dgSummary
            // 
            this.dgSummary.AllowNavigation = false;
            this.dgSummary.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgSummary.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dgSummary.CaptionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgSummary.CaptionVisible = false;
            this.dgSummary.ColumnHeadersVisible = false;
            this.dgSummary.DataMember = "";
            this.dgSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSummary.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgSummary.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgSummary.Location = new System.Drawing.Point(0, 28);
            this.dgSummary.Name = "dgSummary";
            this.dgSummary.RowHeadersVisible = false;
            this.dgSummary.Size = new System.Drawing.Size(396, 159);
            this.dgSummary.TabIndex = 0;
            // 
            // btSummaryUp
            // 
            this.btSummaryUp.ImageIndex = 3;
            this.btSummaryUp.Name = "btSummaryUp";
            // 
            // btSummaryDown
            // 
            this.btSummaryDown.ImageIndex = 4;
            this.btSummaryDown.Name = "btSummaryDown";
            // 
            // toolBar2
            // 
            this.toolBar2.DropDownArrows = true;
            this.toolBar2.Location = new System.Drawing.Point(0, 0);
            this.toolBar2.Name = "toolBar2";
            this.toolBar2.ShowToolTips = true;
            this.toolBar2.Size = new System.Drawing.Size(396, 42);
            this.toolBar2.TabIndex = 1;
            // 
            // dgDetails
            // 
            this.dgDetails.DataMember = "";
            this.dgDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDetails.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgDetails.Location = new System.Drawing.Point(0, 42);
            this.dgDetails.Name = "dgDetails";
            this.dgDetails.Size = new System.Drawing.Size(396, 238);
            this.dgDetails.TabIndex = 2;
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.ImageIndex = 3;
            this.toolBarButton1.Name = "toolBarButton1";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.ImageIndex = 4;
            this.toolBarButton2.Name = "toolBarButton2";
            // 
            // toolBar3
            // 
            this.toolBar3.DropDownArrows = true;
            this.toolBar3.Location = new System.Drawing.Point(0, 0);
            this.toolBar3.Name = "toolBar3";
            this.toolBar3.ShowToolTips = true;
            this.toolBar3.Size = new System.Drawing.Size(396, 42);
            this.toolBar3.TabIndex = 1;
            // 
            // imPlat
            // 
            this.imPlat.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imPlat.ImageStream")));
            this.imPlat.TransparentColor = System.Drawing.Color.Transparent;
            this.imPlat.Images.SetKeyName(0, "");
            this.imPlat.Images.SetKeyName(1, "");
            this.imPlat.Images.SetKeyName(2, "");
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // paPlat
            // 
            this.paPlat.Controls.Add(this.paPlatClient);
            this.paPlat.Controls.Add(this.tcPlat);
            this.paPlat.Controls.Add(this.label3);
            this.paPlat.Dock = System.Windows.Forms.DockStyle.Left;
            this.paPlat.Location = new System.Drawing.Point(0, 48);
            this.paPlat.Name = "paPlat";
            this.paPlat.Size = new System.Drawing.Size(90, 515);
            this.paPlat.TabIndex = 5;
            // 
            // paPlatClient
            // 
            this.paPlatClient.Controls.Add(this.lbCfgs);
            this.paPlatClient.Controls.Add(this.paLeftTop);
            this.paPlatClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paPlatClient.Location = new System.Drawing.Point(0, 285);
            this.paPlatClient.Name = "paPlatClient";
            this.paPlatClient.Size = new System.Drawing.Size(90, 230);
            this.paPlatClient.TabIndex = 8;
            // 
            // lbCfgs
            // 
            this.lbCfgs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCfgs.Location = new System.Drawing.Point(0, 24);
            this.lbCfgs.Name = "lbCfgs";
            this.lbCfgs.Size = new System.Drawing.Size(90, 199);
            this.lbCfgs.Sorted = true;
            this.lbCfgs.TabIndex = 1;
            this.lbCfgs.SelectedIndexChanged += new System.EventHandler(this.lbCfgs_SelectedIndexChanged);
            this.lbCfgs.Click += new System.EventHandler(this.lbCfgs_Click);
            // 
            // paLeftTop
            // 
            this.paLeftTop.Controls.Add(this.label9);
            this.paLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paLeftTop.Location = new System.Drawing.Point(0, 0);
            this.paLeftTop.Name = "paLeftTop";
            this.paLeftTop.Size = new System.Drawing.Size(90, 24);
            this.paLeftTop.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 23);
            this.label9.TabIndex = 0;
            this.label9.Text = "Issue type";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tcPlat
            // 
            this.tcPlat.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tcPlat.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tcPlat.Controls.Add(this.tp32);
            this.tcPlat.Controls.Add(this.tpIA64);
            this.tcPlat.Controls.Add(this.tpX64);
            this.tcPlat.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcPlat.ImageList = this.imPlat;
            this.tcPlat.ItemSize = new System.Drawing.Size(90, 90);
            this.tcPlat.Location = new System.Drawing.Point(0, 23);
            this.tcPlat.Multiline = true;
            this.tcPlat.Name = "tcPlat";
            this.tcPlat.SelectedIndex = 0;
            this.tcPlat.ShowToolTips = true;
            this.tcPlat.Size = new System.Drawing.Size(90, 262);
            this.tcPlat.TabIndex = 6;
            this.tcPlat.Visible = ((bool)(configurationAppSettings.GetValue("UserMode", typeof(bool))));
            this.tcPlat.SelectedIndexChanged += new System.EventHandler(this.tcPlat_SelectedIndexChanged);
            // 
            // tp32
            // 
            this.tp32.ImageIndex = 0;
            this.tp32.Location = new System.Drawing.Point(256, 4);
            this.tp32.Name = "tp32";
            this.tp32.Size = new System.Drawing.Size(0, 254);
            this.tp32.TabIndex = 0;
            this.tp32.ToolTipText = "I386";
            // 
            // tpIA64
            // 
            this.tpIA64.ImageIndex = 1;
            this.tpIA64.Location = new System.Drawing.Point(256, 4);
            this.tpIA64.Name = "tpIA64";
            this.tpIA64.Size = new System.Drawing.Size(0, 254);
            this.tpIA64.TabIndex = 1;
            this.tpIA64.ToolTipText = "IA64";
            this.tpIA64.Visible = false;
            // 
            // tpX64
            // 
            this.tpX64.ImageIndex = 2;
            this.tpX64.Location = new System.Drawing.Point(256, 4);
            this.tpX64.Name = "tpX64";
            this.tpX64.Size = new System.Drawing.Size(0, 254);
            this.tpX64.TabIndex = 2;
            this.tpX64.ToolTipText = "X64";
            this.tpX64.Visible = false;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Platform";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fmPssdiagConfig
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(896, 726);
            this.Controls.Add(this.paClient);
            this.Controls.Add(this.tcVersion);
            this.Controls.Add(this.spLeft);
            this.Controls.Add(this.paPlat);
            this.Controls.Add(this.spBottom);
            this.Controls.Add(this.paBottom);
            this.Controls.Add(this.paTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmPssdiagConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diag Manager";
            this.Load += new System.EventHandler(this.fmPssdiagConfig_Load);
            this.Closed += new System.EventHandler(this.fmPssdiagConfig_Closed);
            this.Activated += new System.EventHandler(this.fmPssdiagConfig_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.fmPssdiagConfig_Closing);
            this.Resize += new System.EventHandler(this.fmPssdiagConfig_Resize);
            this.paTop.ResumeLayout(false);
            this.paTop.PerformLayout();
            this.paTopLeft.ResumeLayout(false);
            this.paTopLeft.PerformLayout();
            this.paBottom.ResumeLayout(false);
            this.tcInstructions.ResumeLayout(false);
            this.tpInstructions.ResumeLayout(false);
            this.tpOutput.ResumeLayout(false);
            this.tcVersion.ResumeLayout(false);
            this.paClient.ResumeLayout(false);
            this.rgCustom.ResumeLayout(false);
            this.rgCustom.PerformLayout();
            this.paClientRightTop.ResumeLayout(false);
            this.rgInstanceDiagnostics.ResumeLayout(false);
            this.tcTrace.ResumeLayout(false);
            this.tpDatabase.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tpAS.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.paInstanceTop.ResumeLayout(false);
            this.paClientLeft.ResumeLayout(false);
            this.rgMachineDiagnostics.ResumeLayout(false);
            this.paPMTop.ResumeLayout(false);
            this.rgConnection.ResumeLayout(false);
            this.rgConnection.PerformLayout();
            this.rgAuth.ResumeLayout(false);
            this.rgAuth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmPoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evPssdiag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetails)).EndInit();
            this.paPlat.ResumeLayout(false);
            this.paPlatClient.ResumeLayout(false);
            this.paLeftTop.ResumeLayout(false);
            this.tcPlat.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


		const int MIN_SSVER=7;
#if BUILD64
		string EXE_NAME="pssdiag64.exe";
#else
		string EXE_NAME="pssdiag.exe";
#endif
		const string DEFAULT_SERVICE="PSSDIAG";
		const string DEFAULT_SERVICE2="SQLDIAG";

		Color[] DisabledEnabled = new Color[2] {System.Drawing.SystemColors.ScrollBar,System.Drawing.SystemColors.Window};

		string CollectorName;
		bool InternalConfig;
		bool ViewOutputOnly=false;
		bool bInitialized=false;
		fmTraceFilters FilterForm=null;
		
		DateTime StartTime;

		private bool fModified;
        
		public bool Modified
		{
			get
			{
				return fModified;
			}
			set
			{
				fModified=value;
			}
		}

		public XmlDocument m_ConfigDoc=null;

		private string strConfigFile;

		public string ConfigFile
		{
			get 
			{
				return strConfigFile;
			}
			set 
			{
				strConfigFile=ConfigPath+value;

				//Supply a default extension
				if (-1==strConfigFile.IndexOf(".XML"))
					strConfigFile+=".XML";

				//Load the file
				LoadCfg(strConfigFile);
			}
		}

		private string strConfigPath;

		public string ConfigPath
		{
			get 
			{
				return strConfigPath;
			}
			set 
			{
				strConfigPath=value;

				//Populate the cfg list
				UpdateCfgTemplates();
			}
		}

		private string strTracePath;

		public string TracePath 
		{
			get {
				return strTracePath;
			}
			set 
			{
				strTracePath=Application.StartupPath+"\\TraceTemplates\\"+value+"\\";

				//Populate the template combobox
				UpdateTraceTemplates();
			}
		}

		private string strPerfmonPath;

		public string PerfmonPath 
		{
			get 
			{
				return strPerfmonPath;
			}
			set 
			{
				strPerfmonPath=Application.StartupPath+"\\PerfmonTemplates\\"+value+"\\";

				LoadPerfmonTemplates();
			}
		}

		private string GetProcTypeText()
		{
			if (!InternalConfig) 
			{
				string ProcArc=System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
				if (string.Compare(ProcArc,"X86",true,CultureInfo.InvariantCulture)==0)
				{
					return "I386";
				}
				else 
				{
					return ProcArc;
				}

			}
			else 
				return tcPlat.SelectedTab.ToolTipText;
		}

		private void UpdateCfgTemplates()
		{
            Globals.PVTracker.PreviousTemplateIndex = lbCfgs.SelectedIndex;
			lbCfgs.Items.Clear();
			string[] Cfgs=Directory.GetFiles(ConfigPath,"*.XML");
			foreach (string f in Cfgs) 
			{
				lbCfgs.Items.Add(Path.GetFileNameWithoutExtension(f));
			}
			string defaultCfgPath=Application.StartupPath+@"\Configurations\"+GetProcTypeText()+@"\";
            if ((0 == lbCfgs.Items.Count) && (0 != string.Compare(defaultCfgPath, ConfigPath, true, CultureInfo.InvariantCulture)))
            {
                //If there are no cfg files in the destination, try again with 
                //the default cfg location.  
                ConfigPath = defaultCfgPath;
            }
            else
            {
                //default to 2008
                lbCfgs.SelectedIndex = 1; // Globals.PVTracker.TemplateIndex;
                
                
            }

            lbCfgs.SelectedIndex =  Globals.PVTracker.TemplateIndex;

            

            
		}

		private void PopulateTree(TreeView tv, XmlNode topnode)
		{
			foreach (XmlNode node in topnode.ChildNodes) 
			{
				TreeNode tnode=tv.Nodes.Add(node.Attributes["name"].Value);
				if (null!=node.Attributes["enabled"])
					tnode.Checked=Convert.ToBoolean(node.Attributes["enabled"].Value);
				else 
				{
					tnode.Checked=true;
					tnode.BackColor=DisabledEnabled[0];
				}
				if (node.HasChildNodes) 
				{
					foreach (XmlNode childnode in node.ChildNodes) 
					{
						TreeNode childtnode=tnode.Nodes.Add(childnode.Attributes["name"].Value);
						childtnode.Checked=Convert.ToBoolean(childnode.Attributes["enabled"].Value);
						if (null!=childnode.Attributes["id"])
							childtnode.Tag=Convert.ToInt32(childnode.Attributes["id"].Value);
					}
				}
					
			}
		}

		private string FlattenTree(XmlNode topnode)
		{
			string res="";
			string nodeName;

			foreach (XmlNode node in topnode.ChildNodes) 
			{
				if (null!=node.Attributes["enabled"])
					nodeName=node.Attributes["name"].Value+",";
				else 
				{
					nodeName="";
				}
				if (node.HasChildNodes) 
				{
					foreach (XmlNode childnode in node.ChildNodes) 
					{
						if (Convert.ToBoolean(childnode.Attributes["enabled"].Value)) 
						{
							if (null!=childnode.Attributes["id"])
								res+=Convert.ToInt32(childnode.Attributes["id"].Value)+",";
						}
					}
				}
				else
					res+=nodeName;
					
			}
			return res.Substring(0,res.Length-1);  //Remove last comma
		}



		private bool UpdateUIFromDoc()
		{
			bool bRes=false;
			try 
			{

				Modified=false;

				//Version
                
				tcVersion.SelectedIndex=Convert.ToInt32(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"].Attributes["ssver"].Value)-MIN_SSVER;

                int sqlver = Convert.ToInt32(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"].Attributes["ssver"].Value);
                


                bool ASProfilerEnabled = Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ASProfilerCollector"].Attributes["enabled"].Value);
                if (ASProfilerEnabled == true)
                {
                    tcTrace.SelectedIndex = (int)TraceTab.AnalysisService;
                }
                else
                {
                    tcTrace.SelectedIndex = (int)TraceTab.SQL;
                }
				//Case

				edCaseNumber.Text=m_ConfigDoc["dsConfig"]["Collection"].Attributes["casenumber"].Value;

				//Machine
				edMachine.Text=m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"].Attributes["name"].Value;

				//Instance
				edInstance.Text=m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"].Attributes["name"].Value;

				//Authentication
				rbWindowsAuth.Checked=Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"].Attributes["windowsauth"].Value);
				if (m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"].HasAttribute("user"))
					edLogin.Text=m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"].Attributes["user"].Value;

				rbSSAuth.Checked=(!rbWindowsAuth.Checked);
				UpdateAuthControls();

				//Eventlogs
				ckEventLogs.Checked=Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["MachineCollectors"]["EventlogCollector"].Attributes["enabled"].Value);
				ckEventLogsStartup.Checked=Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["MachineCollectors"]["EventlogCollector"].Attributes["startup"].Value);
				ckEventLogsShutdown.Checked=Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["MachineCollectors"]["EventlogCollector"].Attributes["shutdown"].Value);

				//Perfmon
				ckPerfmon.Checked=Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["MachineCollectors"]["PerfmonCollector"].Attributes["enabled"].Value);
				string temp=m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["MachineCollectors"]["PerfmonCollector"].Attributes["maxfilesize"].Value;
				cbPMMaxFileSize.SelectedItem=(temp=="-1"?"None":temp);
				cbPMInterval.SelectedItem=m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["MachineCollectors"]["PerfmonCollector"].Attributes["pollinginterval"].Value;

				if (0!=m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["MachineCollectors"]["PerfmonCollector"]["PerfmonCounters"].ChildNodes.Count) 
				{
					tvPM.BeginUpdate();
					try
					{
						tvPM.Nodes.Clear();
						PopulateTree(tvPM,m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["MachineCollectors"]["PerfmonCollector"]["PerfmonCounters"]);
					}
					finally
					{
						tvPM.EndUpdate();
					}
				}

				//SQLDIAG
				ckSqldiag.Checked=Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["SqldiagCollector"].Attributes["enabled"].Value);
				ckSDStartup.Checked=Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["SqldiagCollector"].Attributes["startup"].Value);
				ckSDShutdown.Checked=Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["SqldiagCollector"].Attributes["shutdown"].Value);

				//Blocking
				ckBlocker.Checked=Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["BlockingCollector"].Attributes["enabled"].Value);
				if (m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["BlockingCollector"].HasAttribute("fast"))
					ckBSFast.Checked=Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["BlockingCollector"].Attributes["fast"].Value);
				else
					ckBSFast.Checked=true;
				if (m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["BlockingCollector"].HasAttribute("latch"))
					ckBSLatch.Checked=Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["BlockingCollector"].Attributes["latch"].Value);
				else
					ckBSLatch.Checked=false;
				if (m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["BlockingCollector"].HasAttribute("pollinginterval"))
					cbBSInterval.SelectedItem=m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["BlockingCollector"].Attributes["pollinginterval"].Value;
				else
					cbBSInterval.SelectedItem=cbBSInterval.Items[0];

				//Profiler
				ckProfiler.Checked=Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ProfilerCollector"].Attributes["enabled"].Value);
				cbProfilerTemplate.SelectedItem=m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ProfilerCollector"].Attributes["template"].Value;
				temp=m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ProfilerCollector"].Attributes["maxfilesize"].Value;
				cbProfilerMaxFileSize.SelectedItem=(temp=="-1"?"None":temp);
				cbProfilerInterval.SelectedItem=m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ProfilerCollector"].Attributes["pollinginterval"].Value;

				tvProfiler.BeginUpdate();
				try
				{
					tvProfiler.Nodes.Clear();
					PopulateTree(tvProfiler,m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ProfilerCollector"]["Events"]);
				}
				finally
				{
					tvProfiler.EndUpdate();
				}

				//CustomGroups
				XmlNode xnodeASTrc = m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ASProfilerCollector"];
				if (null==xnodeASTrc)
				{
					//Old format config file without a ASProfilerCollector element. Create one. 
					//Default: <ASProfilerCollector enabled="false" maxfilesize="350"> <Events/> </ASProfilerCollector>
					xnodeASTrc = m_ConfigDoc.CreateElement("ASProfilerCollector"); 
					m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"].AppendChild (xnodeASTrc);
					XmlAttribute newAttr = xnodeASTrc.OwnerDocument.CreateAttribute("enabled");
					newAttr.Value = "false";
					xnodeASTrc.Attributes.SetNamedItem (newAttr);
					XmlAttribute newAttr2 = xnodeASTrc.OwnerDocument.CreateAttribute("maxfilesize");
					newAttr2.Value = "350";
					xnodeASTrc.Attributes.SetNamedItem (newAttr2);
					XmlNode xnodeASTrcEvents = m_ConfigDoc.CreateElement("Events"); 
					m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ASProfilerCollector"].AppendChild (xnodeASTrcEvents);
				}
				ckASProfiler.Checked=Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ASProfilerCollector"].Attributes["enabled"].Value);
				temp=m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ASProfilerCollector"].Attributes["maxfilesize"].Value;
				cbASProfilerMaxFileSize.SelectedItem=(temp=="-1"?"None":temp);

				
			tvASProfiler.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvPM_AfterCheck);
				tvASProfiler.BeginUpdate();
				try
				{
					tvASProfiler.Nodes.Clear();
					PopulateTree(tvASProfiler,m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ASProfilerCollector"]["Events"]);
				}
				finally
				{
				
					tvASProfiler.EndUpdate();
					tvASProfiler.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvPM_AfterCheck);
				}


				lvCustomGroups.BeginUpdate();
				try
				{
					lvCustomGroups.Items.Clear();
					if (null!=m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["CustomDiagnostics"])
					{
						foreach (XmlNode node in m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["CustomDiagnostics"]) 
						{
							if (("CustomGroup"!=node.Name) || (node.Attributes["name"].Value=="AS")) //Ignore non-group elements (diags) and AS groups
								continue;
							ListViewItem lvi=lvCustomGroups.Items.Add(node.Attributes["name"].Value);
							lvi.Checked=Convert.ToBoolean(node.Attributes["enabled"].Value);
						}
					}
					PopulateCustomGroups();
				}
				finally
				{
					lvCustomGroups.EndUpdate();
				}

				//Set modified flag
				Modified=false;

				bRes=true;

				UpdateDeleteButton();

			}
			catch (Exception e)
			{
				//Eat any exceptions during the load
				MessageBox.Show("Error updating UI.  Message:  "+e.Message);
			}
			return bRes;
		}

		//Wrap a string in backquotes if it contains spaces -- used with INI files
		string BackQuote(string input)
		{
			if (-1==input.IndexOf(" "))
				return input;
			else
				return "`"+input+"`";
		}

		[DllImport("kernel32.dll")]
		public static extern int WritePrivateProfileString(
										  string AppName,
										  string KeyName,
										  string Value,
										  string FileName
										  );


		private void SaveXML2000(string FileName)
		{
			String dir = Path.GetDirectoryName (FileName);
			String file = Path.GetFileNameWithoutExtension (FileName);
			String xmlFileName = dir + @"\##"+file + ".xml";
			m_ConfigDoc.Save(xmlFileName);
		}
		private bool SaveINICfg(string FileName)
		{
			bool bRes=false;
			try 
			{
				//Always refresh the XML m_ConfigDoc first since we convert it to INI behind the scenes
				UpdateDocFromUI();
				SaveXML2000(FileName);
				//Erase the old INI file since we will completely rewrite it (we don't support writing multiple sections with this version)
				File.Delete(FileName);
				
				string Machine=m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"].Attributes["name"].Value;

				//SetupVer
				WritePrivateProfileString(Machine,"SetupVer",Application.ProductVersion,FileName);

				//Case
				WritePrivateProfileString(Machine,"CaseNumber",m_ConfigDoc["dsConfig"]["Collection"].Attributes["casenumber"].Value,FileName);
				WritePrivateProfileString(Machine,"Instance",m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"].Attributes["name"].Value,FileName);
				WritePrivateProfileString(Machine,"SSVer",m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"].Attributes["ssver"].Value,FileName);

				//Auth
				WritePrivateProfileString(Machine,"WindowsAuth",Convert.ToInt32(Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"].Attributes["windowsauth"].Value)).ToString(),FileName);
				string temp;
				if (m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"].HasAttribute("user"))
					temp=m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"].Attributes["user"].Value;
				else
					temp="";
					WritePrivateProfileString(Machine,"Username",temp,FileName);

				//SQLDIAG
				WritePrivateProfileString(Machine,"SqlDiag",Convert.ToInt32(Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["SqldiagCollector"].Attributes["enabled"].Value)).ToString(),FileName);
				WritePrivateProfileString(Machine,"SqlDiagStartup",Convert.ToInt32(Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["SqldiagCollector"].Attributes["startup"].Value)).ToString(),FileName);
				WritePrivateProfileString(Machine,"SqlDiagShutdown",Convert.ToInt32(Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["SqldiagCollector"].Attributes["shutdown"].Value)).ToString(),FileName);

				//Eventlogs
				WritePrivateProfileString(Machine,"EventLogs",Convert.ToInt32(Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["MachineCollectors"]["EventlogCollector"].Attributes["enabled"].Value)).ToString(),FileName);
				WritePrivateProfileString(Machine,"EventLogsStartup",Convert.ToInt32(Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["MachineCollectors"]["EventlogCollector"].Attributes["startup"].Value)).ToString(),FileName);
				WritePrivateProfileString(Machine,"EventLogsShutdown",Convert.ToInt32(Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["MachineCollectors"]["EventlogCollector"].Attributes["shutdown"].Value)).ToString(),FileName);

				//Profiler
				WritePrivateProfileString(Machine,"Profiler",Convert.ToInt32(Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ProfilerCollector"].Attributes["enabled"].Value)).ToString(),FileName);
				WritePrivateProfileString(Machine,"ProfilerTemplate",m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ProfilerCollector"].Attributes["template"].Value,FileName);
				WritePrivateProfileString(Machine,"MaxTraceFileSize",m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ProfilerCollector"].Attributes["maxfilesize"].Value,FileName);
				WritePrivateProfileString(Machine,"ProfilerPollingInterval",m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ProfilerCollector"].Attributes["pollinginterval"].Value,FileName);
				WritePrivateProfileString(Machine,"ProfilerEvents",FlattenTree(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ProfilerCollector"]["Events"]),FileName);

				//Blocking script
				WritePrivateProfileString(Machine,"BlockingScript",Convert.ToInt32(Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["BlockingCollector"].Attributes["enabled"].Value)).ToString(),FileName);
				if (m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["BlockingCollector"].HasAttribute("fast"))
					WritePrivateProfileString(Machine,"BlockerFast",Convert.ToInt32(Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["BlockingCollector"].Attributes["fast"].Value)).ToString(),FileName);
				else
					WritePrivateProfileString(Machine,"BlockerFast","1".ToString(),FileName);

				if (m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["BlockingCollector"].HasAttribute("latch"))
					WritePrivateProfileString(Machine,"BlockerLatch",Convert.ToInt32(Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["BlockingCollector"].Attributes["latch"].Value)).ToString(),FileName);
				else
					WritePrivateProfileString(Machine,"BlockerLatch","0".ToString(),FileName);

				if (m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["BlockingCollector"].HasAttribute("pollinginterval"))
					WritePrivateProfileString(Machine,"BlockingPollingInterval",m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["BlockingCollector"].Attributes["pollinginterval"].Value,FileName);
				else
					WritePrivateProfileString(Machine,"BlockingPollingInterval","5",FileName);

				//Perfmon
				WritePrivateProfileString(Machine,"Perfmon",Convert.ToInt32(Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["MachineCollectors"]["PerfmonCollector"].Attributes["enabled"].Value)).ToString(),FileName);
				WritePrivateProfileString(Machine,"MaxPerfmonLogSize",m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["MachineCollectors"]["PerfmonCollector"].Attributes["maxfilesize"].Value,FileName);
				WritePrivateProfileString(Machine,"PerfmonPollingInterval",m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["MachineCollectors"]["PerfmonCollector"].Attributes["pollinginterval"].Value,FileName);

				int i=0;
				int j=0;
				foreach (XmlNode node in m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["CustomDiagnostics"]) 
				{
					if (!Convert.ToBoolean(node.Attributes["enabled"].Value)) 
						continue;  //Skip disabled groups/tasks

					if ("CustomGroup"==node.Name)
						WritePrivateProfileString(Machine,string.Format("CustomDiagnosticGroup{0}",i++),node.Attributes["name"].Value,FileName);
					else 
					{
						WritePrivateProfileString(Machine,string.Format("CustomDiagnostic{0}",j++),string.Format("{0},{1},{2},{3},{4},{5}",
							BackQuote(node.Attributes["groupname"].Value),
							BackQuote(node.Attributes["taskname"].Value),
							node.Attributes["type"].Value,
							node.Attributes["point"].Value,
							node.Attributes["wait"].Value,
							BackQuote(node.Attributes["cmd"].Value)
							),FileName);
					}
				}


				i=0;
				foreach (XmlNode node in m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["MachineCollectors"]["PerfmonCollector"]["PerfmonCounters"]) 
				{
					string objectName=node.Attributes["name"].Value;
					if (node.HasChildNodes) 
					{
						foreach (XmlNode childnode in node.ChildNodes) 
						{
							if (!Convert.ToBoolean(childnode.Attributes["enabled"].Value)) 
								continue;  //Skip disabled counters

							WritePrivateProfileString(Machine,string.Format("Counter{0}",i++),"+"+objectName+childnode.Attributes["name"].Value,FileName);
						}
					}
						
				}

				//Set modified flag
				Modified=false;

				bRes=true;

			}
			catch (Exception e)
			{
				//Eat any exceptions during the load
				MessageBox.Show("Error writing INI.  Message:  "+e.Message);
			}
			return bRes;
		}

		public bool LoadCfg(string FileName)
		{
			bool bRes=false;
			try 
			{
				XmlDocument tempDoc=new XmlDocument();
				tempDoc.Load(FileName);
				m_ConfigDoc=tempDoc;
				UpdateUIFromDoc();
				bRes=true;

			}
			catch (Exception e)
			{
				//Eat any exceptions during the load
				MessageBox.Show("Error loading configuration file.  Message:  "+e.Message);
			}
			return bRes;
		}

		private void PersistNodes(TreeNodeCollection nodes, XmlNode xnode, string childnodename)
		{
			foreach (TreeNode node in nodes) 
			{
				XmlNode childxnode=xnode.OwnerDocument.CreateElement(childnodename);

				XmlAttribute newAttr = xnode.OwnerDocument.CreateAttribute("name");
				newAttr.Value = node.Text;
				childxnode.Attributes.SetNamedItem(newAttr);

				if (DisabledEnabled[0]!=node.BackColor) 
				{
					XmlAttribute newAttr2 = xnode.OwnerDocument.CreateAttribute("enabled");
					newAttr2.Value = node.Checked.ToString().ToLower();
					childxnode.Attributes.SetNamedItem(newAttr2);
				}
				if ("Event"==childnodename) //Hack to set the id column of trace events
				{
					XmlAttribute newAttr3 = xnode.OwnerDocument.CreateAttribute("id");
					newAttr3.Value = Convert.ToInt32(node.Tag).ToString();
					childxnode.Attributes.SetNamedItem(newAttr3);
				}
				xnode.AppendChild(childxnode);
				if (0!=node.Nodes.Count) 
				{
					if ("PerfmonObject"==childnodename)
						PersistNodes(node.Nodes,childxnode,"PerfmonCounter");
					else
						PersistNodes(node.Nodes,childxnode,"Event");
				}
			}
		}

		private int FilterColumnToId(string columnname)
		{
			if (0==string.Compare(columnname,"ApplicationName",true)) return	10;
			if (0==string.Compare(columnname,"ClientProcessID",true)) return	9;
			if (0==string.Compare(columnname,"CPU",true)) return	18;
			if (0==string.Compare(columnname,"DatabaseID",true)) return	3;
			if (0==string.Compare(columnname,"DatabaseName",true)) return 35;
			if (0==string.Compare(columnname,"DBUserName",true)) return 40;
			if (0==string.Compare(columnname,"Duration",true)) return 13;
			if (0==string.Compare(columnname,"Error",true)) return 	31;
			if (0==string.Compare(columnname,"EventSubClass",true)) return 21;
			if (0==string.Compare(columnname,"HostName",true)) return 8;
			if (0==string.Compare(columnname,"IndexID",true)) return 24;
			if (0==string.Compare(columnname,"IntegerData",true)) return 25;
			if (0==string.Compare(columnname,"LoginName",true)) return 11;
			if (0==string.Compare(columnname,"NTUserName",true)) return 6;
			if (0==string.Compare(columnname,"ObjectID",true)) return 22;
			if (0==string.Compare(columnname,"ObjectName",true)) return 34;
			if (0==string.Compare(columnname,"Reads",true)) return 	16;
			if (0==string.Compare(columnname,"Severity",true)) return 20;
			if (0==string.Compare(columnname,"SPID",true)) return 	12;
			if (0==string.Compare(columnname,"TextData",true)) return 1;
			if (0==string.Compare(columnname,"Writes",true)) return 17;
			return -1;
		}

		private int OperatorToId(string operatorname)
		{
			string[] Operators = new string[8] {"Equal","Not Equal","Greater Than","Less Than","Greater Than or Equal","Less Than or Equal","LIKE","NOT LIKE"};
			for (int i=0; i<=Operators.GetUpperBound(0); i++)
				if (0==string.Compare(operatorname,Operators[i],true)) return i;
			return -1;
		}

		private int LogicalOperatorToId(string operatorname)
		{
			string[] Operators = new string[2] {"And","Or"};
			for (int i=0; i<=Operators.GetUpperBound(0); i++)
				if (0==string.Compare(operatorname,Operators[i],true)) return i;
			return -1;
		}

		private void AddFilterParam(XmlNode onode, XmlNode pnode,string paramname, string paramvalue)
		{
			XmlNode childxnode=onode.OwnerDocument.CreateElement("Parameter");

			XmlAttribute newAttr = onode.OwnerDocument.CreateAttribute("name");
			newAttr.Value = paramname;
			childxnode.Attributes.SetNamedItem(newAttr);

			newAttr = onode.OwnerDocument.CreateAttribute("value");
			newAttr.Value = paramvalue;
			childxnode.Attributes.SetNamedItem(newAttr);
			pnode.AppendChild(childxnode);
		}

		private void PersistFilters(XmlNode xnode)
		{
			try
			{
				if ((null==FilterForm) || (0==FilterForm.dsFilters.Tables["Filter"].Rows.Count))
					return;
			}
			catch
			{
				return;
			}
			XmlNode pnode=null;
			try
			{
				pnode=xnode["Parameters"];
				pnode.InnerText="";
			}
			catch
			{
				pnode=xnode.OwnerDocument.CreateElement("Parameters");
			}
			
			if (null==pnode)  //Error creating node
				return;
			int i = 0;
			foreach (DataRow row in FilterForm.dsFilters.Tables["Filter"].Rows) 
			{
				int colId=FilterColumnToId(row["column"].ToString());
				int opId=OperatorToId(row["operator"].ToString());
				int logOpId=LogicalOperatorToId(row["logicaloperator"].ToString());

				if ((-1==colId) || (-1==opId) || (-1==logOpId))
					continue;  //Invalid col, op, or logop

				AddFilterParam(xnode, pnode,((0==i)?",":"")+string.Format("@F{0}Col",i),colId.ToString());
				AddFilterParam(xnode, pnode,string.Format("@F{0}Op",i),opId.ToString());
				AddFilterParam(xnode, pnode,string.Format("@F{0}Filt",i),"\'"+row["filter"].ToString()+"\'");
				AddFilterParam(xnode, pnode,string.Format("@F{0}LogOp",i),logOpId.ToString());
				i++;
				if (i>=5)  //Cap the number of filters at 5
					break;
			}
			xnode.AppendChild(pnode);
		}


		private bool StreamNodeToRegistry(RegistryKey rk, XmlNode node)
		{
			RegistryKey rksub;
			XmlAttribute nameAttr=node.Attributes["name"];
			if (nameAttr!=null) 
			{
				string val=nameAttr.Value;
				bool bHadSlash=false;
				if (nameAttr.Value[0]=='\\') 
				{
					val=val.Substring(1);		//Trim off leading \
					bHadSlash=true;
				}
				rksub=rk.CreateSubKey(val);  
				rksub.SetValue("name",node.LocalName);
				if (bHadSlash)				   //Preserve whether we trimmed the \ so that we can add it back in when loading
					rksub.SetValue("hadslash","true");
			}
			else
				rksub=rk.CreateSubKey(node.LocalName);
			foreach (XmlAttribute attr in node.Attributes) 
			{
				if ((nameAttr==null) || (nameAttr.LocalName!=attr.LocalName))
					rksub.SetValue(attr.LocalName,attr.Value);
			}
			if (node.HasChildNodes) 
			{
					foreach (XmlNode childnode in node.ChildNodes) 
					{
						if (childnode.NodeType==XmlNodeType.Element) 
						{
							StreamNodeToRegistry(rksub,childnode);
						}
					}
					
			}

			return true;
		}

		private bool StreamDocToRegistry()
		{
			string strMachine=edMachine.Text=="."?"":edMachine.Text;
			RegistryKey rk=RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine,strMachine);
			rk=rk.CreateSubKey("Software\\Microsoft\\SQLDiagEx\\"+edAppName.Text+"\\Configuration");
			foreach (XmlNode node in m_ConfigDoc["dsConfig"].ChildNodes) 
			{
				if ((node.NodeType==XmlNodeType.Element) || (node.NodeType==XmlNodeType.Attribute)) 
				{
					StreamNodeToRegistry(rk, node);
				}
			}
			return true;

		}

		private bool SaveRegistryCfg()
		{
			bool bRes=false;
			try
			{
				UpdateDocFromUI();

				string strMachine=edMachine.Text=="."?"":edMachine.Text;
				RegistryKey rk=RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine,strMachine);
				rk=rk.CreateSubKey("Software\\Microsoft\\SQLDiagEx\\"+edAppName.Text);
				rk.SetValue("Configuration",m_ConfigDoc.InnerXml);

				Modified=false;

				bRes=true;
			}
			catch (Exception e)
			{
				MessageBox.Show("Error saving configuration to the registry.  Message:  "+e.Message);
			}
			return bRes;
		}

		private bool LoadRegistryCfg()
		{
			bool bRes=false;
			string strMachine=edMachine.Text=="."?"":edMachine.Text;
			RegistryKey rk=RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine,strMachine);
			try
			{
				rk=rk.OpenSubKey("Software\\Microsoft\\SQLDiagEx\\"+edAppName.Text);
				string strCfg=(string)rk.GetValue("Configuration");
				m_ConfigDoc.InnerXml=strCfg;
				UpdateUIFromDoc();
				bRes=true;
			}
			catch(Exception ex)
			{
				//We don't care if the key isn't there -- ignore any errors reading the registry
				Debug.WriteLine(ex.Message);
                Logger.LogInfo("LoadRegistryCfg");
                Logger.LogException(ex);
			}
			return bRes;
		}

		private bool AddCustomDiagFile(string fName, XmlNode topNode, ref ArrayList vars)
		{
			bool bRes=false;

			if (File.Exists(fName)) 
			{

				XmlDocument customDoc=new XmlDocument();
				customDoc.Load(fName);

				foreach (XmlNode node in customDoc["CustomTasks"]) 
				{
					if (0==string.Compare("Group",node.Attributes["type"].Value,true,CultureInfo.InvariantCulture))
						AddCustomDiagFile(string.Format(@"{0}\CustomDiagnostics\{1}\CustomDiag.XML",Application.StartupPath,node.Attributes["cmd"].Value),topNode,ref vars);
					else 
					{
						XmlNode tmpNode=topNode.OwnerDocument.ImportNode(node,false);
						topNode.AppendChild(tmpNode);
						foreach (XmlNode childNode in node) 
						{
							CVariable var = new CVariable(childNode.Attributes["prompt"].Value,
								childNode.Attributes["name"].Value,
								childNode.Attributes["datatype"].Value,
								childNode.Attributes["default"].Value);
							vars.Add(var);
						}
					}
				}
				bRes=true;
			}
			return bRes;
		}

		private bool UpdateDocFromUI()
		{
			bool bRes=false;
			try
			{
				//Case
				m_ConfigDoc["dsConfig"]["Collection"].Attributes["casenumber"].Value=edCaseNumber.Text;

				//Machine
				m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"].Attributes["name"].Value=edMachine.Text;

				//Instance
				m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"].Attributes["name"].Value=(""==edInstance.Text.Trim()?"(Default)":edInstance.Text);

				//Version
				m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"].Attributes["ssver"].Value=(tcVersion.SelectedIndex+MIN_SSVER).ToString();

				//Authentication
				m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"].Attributes["windowsauth"].Value=rbWindowsAuth.Checked.ToString().ToLower();

				//Username
				XmlAttribute newAttr = m_ConfigDoc.CreateAttribute("user");
				newAttr.Value = edLogin.Text;
				m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"].Attributes.SetNamedItem(newAttr);

				//Eventlogs
				m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["MachineCollectors"]["EventlogCollector"].Attributes["enabled"].Value=ckEventLogs.Checked.ToString().ToLower();
				m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["MachineCollectors"]["EventlogCollector"].Attributes["startup"].Value=ckEventLogsStartup.Checked.ToString().ToLower();
				m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["MachineCollectors"]["EventlogCollector"].Attributes["shutdown"].Value=ckEventLogsShutdown.Checked.ToString().ToLower();

				//Perfmon
				m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["MachineCollectors"]["PerfmonCollector"].Attributes["enabled"].Value=ckPerfmon.Checked.ToString().ToLower();
				m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["MachineCollectors"]["PerfmonCollector"].Attributes["maxfilesize"].Value=(cbPMMaxFileSize.SelectedIndex==0?-1:cbPMMaxFileSize.SelectedItem).ToString();
				m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["MachineCollectors"]["PerfmonCollector"].Attributes["pollinginterval"].Value=cbPMInterval.SelectedItem.ToString();

				m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["MachineCollectors"]["PerfmonCollector"]["PerfmonCounters"].InnerXml="";
				PersistNodes(tvPM.Nodes,m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["MachineCollectors"]["PerfmonCollector"]["PerfmonCounters"],"PerfmonObject");

				//SQLDIAG
				m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["SqldiagCollector"].Attributes["enabled"].Value=ckSqldiag.Checked.ToString().ToLower();
				m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["SqldiagCollector"].Attributes["startup"].Value=ckSDStartup.Checked.ToString().ToLower();
				m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["SqldiagCollector"].Attributes["shutdown"].Value=ckSDShutdown.Checked.ToString().ToLower();

				//Blocking
				m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["BlockingCollector"].Attributes["enabled"].Value=ckBlocker.Checked.ToString().ToLower();
				if (m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["BlockingCollector"].HasAttribute("fast"))
					m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["BlockingCollector"].Attributes["fast"].Value=ckBSFast.Checked.ToString().ToLower();
				if (m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["BlockingCollector"].HasAttribute("latch"))
					m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["BlockingCollector"].Attributes["latch"].Value=ckBSLatch.Checked.ToString().ToLower();
				if (m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["BlockingCollector"].HasAttribute("pollinginterval"))
					m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["BlockingCollector"].Attributes["pollinginterval"].Value=cbBSInterval.SelectedItem.ToString();

				//Profiler
				m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ProfilerCollector"].Attributes["enabled"].Value=ckProfiler.Checked.ToString().ToLower();
				m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ProfilerCollector"].Attributes["template"].Value=cbProfilerTemplate.SelectedItem.ToString();
				m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ProfilerCollector"].Attributes["maxfilesize"].Value=(cbProfilerMaxFileSize.SelectedIndex==0?-1:cbProfilerMaxFileSize.SelectedItem).ToString();
				m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ProfilerCollector"].Attributes["pollinginterval"].Value=cbProfilerInterval.SelectedItem.ToString();

				m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ProfilerCollector"]["Events"].InnerXml="";
				PersistNodes(tvProfiler.Nodes,m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ProfilerCollector"]["Events"],"EventType");
				PersistFilters(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ProfilerCollector"]);

				//AS Profiler
				m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ASProfilerCollector"].Attributes["enabled"].Value=ckASProfiler.Checked.ToString().ToLower();
				m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ASProfilerCollector"].Attributes["maxfilesize"].Value=(cbASProfilerMaxFileSize.SelectedIndex==0?-1:cbASProfilerMaxFileSize.SelectedItem).ToString();
				m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ASProfilerCollector"]["Events"].InnerXml="";
				PersistNodes(tvASProfiler.Nodes,m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ASProfilerCollector"]["Events"],"EventType");


				//CustomGroups
				XmlNode xnode = m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["CustomDiagnostics"];

				//Delete all children
				if (null!=xnode)
					xnode.InnerXml="";
				else 
				{
					//Old format didn't have a CustomDiagnostics element
					xnode = m_ConfigDoc.CreateElement("CustomDiagnostics");
					m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"].AppendChild(xnode);
				}

				//Special handling for AS trace
				if (Convert.ToBoolean(m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ASProfilerCollector"].Attributes["enabled"].Value))
				{
					//xnode.InnerXml="<CustomTask enabled=\"true\" groupname=\"AS\" taskname=\"Trace Start\" type=\"Utility\" point=\"Startup\" wait=\"Yes\" cmd=\"ASTrace START &quot;%server%\\%olapinstance%&quot; %appname% &quot;%cfgfile%&quot; "+ 
                    xnode.InnerXml = "<CustomTask enabled=\"true\" groupname=\"AS\" taskname=\"Trace Start\" type=\"Utility\" point=\"Startup\" wait=\"NO\" cmd=\"ASTrace START &quot;%server_instance%&quot; %appname% &quot;%cfgfile%&quot; " +
                        ///*m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ASProfilerCollector"].Attributes["maxfilesize"].Value+ " &quot;%output_path%%server%_%olapinstance%_sp_trace_as.trc&quot;*/ " &gt; &quot;%internal_output_name%_AS.start.log&quot; 2&gt;&amp;1\" />";
                        m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["ASProfilerCollector"].Attributes["maxfilesize"].Value + " &quot;%output_path%%server%_%instance%_sp_trace_as.trc&quot; &gt; &quot;%internal_output_name%_AS.start.log&quot; 2&gt;&amp;1\" />";
                    xnode.InnerXml += "<CustomTask enabled=\"true\" groupname=\"AS\" taskname=\"Trace Stop\" type=\"Utility\" point=\"Shutdown\" wait=\"Yes\" cmd=\"ASTrace STOP &quot;%server_instance%&quot; %appname% &gt; &quot;%internal_output_name%_AS.stop.log&quot; 2&gt;&amp;1\" />";
				}

				ArrayList vars = new ArrayList();
				foreach (ListViewItem lvi in lvCustomGroups.Items) 
				{
					if (!lvi.Checked)
						continue;		//Skip unselected

					XmlNode childxnode=xnode.OwnerDocument.CreateElement("CustomGroup");

					XmlAttribute newAttr2 = xnode.OwnerDocument.CreateAttribute("name");
					newAttr2.Value = lvi.Text;
					childxnode.Attributes.SetNamedItem(newAttr2);

					XmlAttribute newAttr3 = xnode.OwnerDocument.CreateAttribute("enabled");
					newAttr3.Value = lvi.Checked.ToString().ToLower();
					childxnode.Attributes.SetNamedItem(newAttr3);

					xnode.AppendChild(childxnode);

					//Get custom tasks from external customdiag.xml m_ConfigDoc
					AddCustomDiagFile(string.Format(@"{0}\CustomDiagnostics\{1}\CustomDiag.XML",Application.StartupPath,lvi.Text),xnode,ref vars);


//					if (0!=node.Nodes.Count) 
//					{
//						if ("PerfmonObject"==childnodename)
//							PersistNodes(node.Nodes,childxnode,"PerfmonCounter");
//						else
//							PersistNodes(node.Nodes,childxnode,"Event");
//					}
				}

				Hashtable ht = null;
				if (!fmParameters.GetParameters(vars, ref ht))
					return false;

				if (null!=ht) 
				{
					foreach (XmlNode node in m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"]["Collectors"]["CustomDiagnostics"]) 
					{
						if (!Convert.ToBoolean(node.Attributes["enabled"].Value)) 
							continue;  //Skip disabled groups/tasks

						if ("CustomGroup"==node.Name)
							continue;  //Skip groups
						else 
						{
							//Replace all variable references with their values
							foreach (DictionaryEntry de in ht) 
							{
								node.Attributes["cmd"].Value=node.Attributes["cmd"].Value.Replace(de.Key.ToString(),de.Value.ToString());
                                Logger.LogInfo("NodeAttribute: " + node.Attributes["cmd"].Value);
								Debug.WriteLine(node.Attributes["cmd"].Value);
							}
						}
					}
				}


				bRes=true;

			}
			catch (Exception e)
			{
				MessageBox.Show("Error updating configuration from UI.  Message:  "+e.Message);
			}
			return bRes;

		}

		private void SetComments()
		{
			String Comments = 
					String.Format(
						"<ConfigMgrVer>{0}</ConfigMgrVer> " + 
						"<IntendedPlatform>{1} </IntendedPlatform>" + 
						"<ConfigProducingMachine>{2}</ConfigProducingMachine>" + 
						"<User>{3}</User>" + 
						"<timestamp>{4} </timestamp>",
						 Application.ProductVersion ,
						 getPlatform(),
						 Environment.MachineName.Substring (0, 3) + "..." + Environment.MachineName.Substring ( Environment.MachineName.Length -2, 2),
						 Environment.UserName,
						DateTime.Now);
			
			if (m_ConfigDoc["DiagMgrInfo"] == null)
			{
				XmlElement el = m_ConfigDoc.CreateElement("DiagMgrInfo");
				el.InnerXml = Comments;
				m_ConfigDoc.DocumentElement.InsertBefore(el, m_ConfigDoc.DocumentElement.FirstChild);
			}
			else
				m_ConfigDoc["DiagMgrInfo"].InnerXml = Comments;
							

		}

		private String getPlatform()
		{
			
			String Platform;
			switch (			tcPlat.SelectedIndex )
			{
				case 0:
					Platform="I386";
					break;
				case 1:
					Platform="IA64";
					break;
				case 2:
					Platform ="x64/AMD64";
					break;
				default:
					throw new ArgumentException ("invalide platform selected");
					

			}
			return Platform ;

		}
		public bool SaveXMLCfg(string FileName)
		{
			bool bRes=false;
			try
			{

				UpdateDocFromUI();
                m_ConfigDoc["dsConfig"]["Collection"].Attributes["setupver"].Value = Application.ProductVersion.ToString();
				SetComments();

                if (m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"].Attributes["ssver"].Value == "10")
                {

                    fmChoice sqlver = new fmChoice("Please chooise between SQL Server 2008 and SQL Server 2008 R2", "SQL Server 2008", "SQL Server 2008 R2");

                    if (DialogResult.OK == sqlver.ShowDialog())
                    {
                        if (sqlver.Choice == 2)
                        {

                            m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"].Attributes["ssver"].Value = "10.50";

                            


                        }

                    }
                    else
                    {
                        return false;
                    }
                }


				m_ConfigDoc.Save(FileName);

				//Set modified flag
				Modified=false;

				bRes=true;

			}
			catch (Exception e)
			{
				//Eat any exceptions during the save
				MessageBox.Show("Error saving configuration file.  Message:  "+e.Message);
			}
			return bRes;

		}

		private void UpdateTraceTemplates()
		{
			cbProfilerTemplate.BeginUpdate();
			try
			{
				cbProfilerTemplate.Items.Clear();
				string[] Templates=Directory.GetFiles(TracePath,"*.XML");
				foreach (string Template in Templates) 
				{
					cbProfilerTemplate.Items.Add(Path.GetFileName(Template));
				}
//				cbProfilerTemplate.SelectedIndex=0;
			}
			finally
			{
				cbProfilerTemplate.EndUpdate();
			}
		
		}

		private bool RegValExists(string strKey)
		{
			bool bRes=false;
			string strMachine=edMachine.Text=="."?"":edMachine.Text;
			RegistryKey rk=RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine,strMachine);
			try
			{
				rk=rk.OpenSubKey("Software\\Microsoft\\SQLDiagEx\\"+edAppName.Text,true);
				string strVal=(string)rk.GetValue(strKey);
				bRes=true;
			}
			catch(Exception ex)
			{

                Logger.LogError("Error checking for registry value:");
                Logger.LogException(ex);
                Debug.WriteLine("Error checking for registry value: "+ex.Message);

			}
			return bRes;
		}


		private bool CheckAndRegisterService(bool bSQLDiagInst, string AppName)
		{
			bool bRes=false;
			try
			{
				if (!UpdateButtonsStatus()) 
				{

					if (!bSQLDiagInst) 
					{
						string ProcArc=System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
						if (string.Compare(ProcArc,"X86",true,CultureInfo.InvariantCulture)==0)
							CollectorName=Application.StartupPath+"\\pristine\\pre_yukon\\i386\\pssdiag.exe";
						else 
							CollectorName=Application.StartupPath+"\\pristine\\pre_yukon\\"+ProcArc+"\\pssdiag.exe";
					}
					else
						CollectorName="SQLDIAG.EXE";

					string AppParam;
					if ((0==string.Compare(AppName.Trim(),DEFAULT_SERVICE,true,CultureInfo.InvariantCulture)) || 
						(0==string.Compare(AppName.Trim(),DEFAULT_SERVICE2,true,CultureInfo.InvariantCulture))) 
					{
						AppParam="";
					}
					else
						AppParam=" /A"+AppName;

					ProcessStartInfo si=new ProcessStartInfo(CollectorName,"/R /I REG: /O \""+Application.StartupPath+"\\Output\""+AppParam);
					si.WindowStyle=ProcessWindowStyle.Hidden;
					Process p=Process.Start(si);
					if (null!=p)
						p.WaitForExit();

				}
				bRes=UpdateButtonsStatus();
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error registering service: "+ex.Message);
			}
			return bRes;
		}

		private void SetDefaultCfgPath()
		{
			if (!ViewOutputOnly)
			{
				//Set the default config path and populate the list (this causes the default cfg to be loaded)
				ConfigPath=Application.StartupPath+@"\Configurations\"+GetProcTypeText()+@"\";

				//Load the cfg data from the registry if it's there
				LoadRegistryCfg();
			}
		}

		private void Initialize(bool bSQLDiagInst, string AppName)
		{
			StartTime=DateTime.Now;
			if (UpdateButtonsStatus()) 
			{
				if (btStart.Enabled) 
				{
					CheckAndRegisterService(bSQLDiagInst, AppName);
				}
			}
			else //if not able to update button status, service may not be registered
			{
				CheckAndRegisterService(bSQLDiagInst, AppName);
			}

			tmPoll.Enabled=true;

			//Set modified flag
			Modified=false;

			//Load instructions m_ConfigDoc
			bool bLoaded=false;
			while (!bLoaded)
			{
				try 
				{
//					reInstructions.LoadFile("instructions.rtf");
					bLoaded=true;
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			};

			//Set visibility based on UserMode config value
			edMachine.Visible=(!cbMachine.Visible);
			edInstance.Visible=(!cbInstance.Visible);
////			tcInstructions.Visible=(!tcCustom.Visible);

			//Visibility of tcVersion and tcCustom are set
			//via the appconfig file's FullConfig and UserMode 
			//switches, respectively

//			//MS internal configuration options enabled
//			if (InternalConfig) 
//			{
//				TabPage tp = new TabPage("SQL Server 2005");
//				tcVersion.TabPages.Add(tp);
//				paLeft.Width=136;
//				paBottom.Height=40;
//				Width+=(paLeft.Width+spLeft.Width);
//				Height+=(paBottom.Height+spBottom.Height);
//
//				//Re-center form
//				Left-=(paLeft.Width+spLeft.Width)/2;
//				Top-=(paBottom.Height+spBottom.Height)/2;
//			}

			//GUI used as controller/configurator/output viewer for exterally-available PSSDiag.exe only
			if (!ViewOutputOnly)
			{
				//Default to 2008
				tcVersion.SelectedIndex=3;
                

				//Don't show the "secondary" machine edit box and its label
				//because the primary ones are visible
				edTargetMachine.Visible=false;
				laTargetMachine.Visible=false;
				this.edMachine.Validated += new System.EventHandler(this.edTargetMachine_Validated);

				SetDefaultCfgPath();

			}
			else //GUI used only as controller/output viewer for internal PSSDiag.exe
			{
				//Primary machine edit box and its label are hidden
				//so show secondary ones in the toolbar
				edTargetMachine.Visible=true;
				laTargetMachine.Visible=true;
				lvOutput.Height=Convert.ToInt32(Convert.ToDouble(Height) / 1.5);
				this.edTargetMachine.Validated += new System.EventHandler(this.edTargetMachine_Validated);
			}

		}

		bool CheckVersion()
		{
			try
			{
				// Handle startup auto-upgrade tasks. See "PSSDiag Auto Update.doc" spec for details. 
				// A setup.cmd in the UpgradeStaging directory means that auto-update has copied a 
				// full installation package to the local drive for a major upgrade. 
				//
				// For shutdown auto-update work, see fmPssdiagConfig_Closing(). 
				string SetupCmd = Path.GetDirectoryName(Application.ExecutablePath) + "\\UpgradeStaging\\setup.cmd";
                if (File.Exists(SetupCmd))
                {
                    DialogResult res = MessageBox.Show("An application update is available. Install the update now?", "PSSDiag AutoUpdate", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        MessageBox.Show("Please restart DiagConfig.exe when setup completes.", "PSSDiag AutoUpdate", MessageBoxButtons.OK);
                        fmPssdiagConfig.LaunchApp("/C \"" + SetupCmd + "\"", Path.GetDirectoryName(SetupCmd), false, false);
                        // Exit without waiting so that setup.exe can replace diagconfig.exe. 
                        return false;
                    }
                }
                else
                {
                    Logger.LogMessage("setupcmd doesn't exsit at " + SetupCmd, LogLevel.WARNING);
                }
			}
			catch(Exception ex)
			{
				//Eat any exceptions -- we don't want a failure in background auto-update to 
				//cause a bad user experience 
                Logger.LogException(ex);
				//Debug.WriteLine(ex.ToString());
			}
			return true;
		}


		private void fmPssdiagConfig_Load(object sender, System.EventArgs e)
		{

#if BUILD64
			this.Text+=" (64-bit) "+Application.ProductVersion;
#else
			this.Text+=" "+Application.ProductVersion;
#endif
			ConfigForm=this;

            Globals.PVTracker = new PlatVersionTracker(tcPlat, tcVersion, tcTrace, lbCfgs);
            

			if (!CheckVersion())
				Application.Exit();

			btStart.Visible=!InternalConfig;
			btStop.Visible=!InternalConfig;
			laTargetMachine.Visible=!InternalConfig;
			edTargetMachine.Visible=!InternalConfig;
			laAppName.Visible=!InternalConfig;
			edAppName.Visible=!InternalConfig;
			niPssdiag.Visible=!InternalConfig;
			
			if (!btStop.Visible)
				tcInstructions.TabPages.Remove(tpOutput);
            
            Logger.LogMessage("Main form started", LogLevel.INFO);
			if (!InternalConfig)  //End user mode 
			{
				try
				{
					fmConnect fmC = new fmConnect();
					if (!bInitialized) 
					{
						bool bValidMachine=false;
						while (!bValidMachine) 
						{
							DialogResult dRes=fmC.ShowDialog();
							if (((Args.Length>1) && (""!=Args[0])) || (DialogResult.OK==dRes))
							{
								if ((Args.Length>1) && (""!=Args[0])) 
								{
									fmC.edMachine.Text=Args[0];
									fmC.edAppName.Text=Args[1];
									Args[0]="";  //If we fail to connect, we want to bring up the dialog on the next iteration
								}
								edTargetMachine.Text=fmC.edMachine.Text;
								edAppName.Text=fmC.edAppName.Text;
								if ((-1==edAppName.Text.IndexOf("$")) && 
									(0!=string.Compare(edAppName.Text.Trim(),DEFAULT_SERVICE,true,CultureInfo.InvariantCulture)) && 
									(0!=string.Compare(edAppName.Text.Trim(),DEFAULT_SERVICE2,true,CultureInfo.InvariantCulture)))
									edAppName.Text="DIAG$"+edAppName.Text;
							}
							if ((dRes!=DialogResult.OK) || (""==edTargetMachine.Text))
							{
								throw new Exception("Cancel");
								edMachine.Text=".";
								edTargetMachine.Text=".";
								evPssdiag.MachineName=".";
							}
							try
							{
								evPssdiag.MachineName=edTargetMachine.Text;
								int i=evPssdiag.Entries.Count;
								scPssdiag.ServiceName=edAppName.Text;
								bValidMachine=true;
							}
							catch (Exception ex)
							{
								MessageBox.Show("Error connecting to target machine: "+edTargetMachine.Text+".  Message: "+ex.Message,"Connection Error");
								bValidMachine=false;
							}
						}
						edMachine.Text=edTargetMachine.Text;
						//				bool bLocalMachine=((edTargetMachine.Text==".") || (edTargetMachine.Text.ToLower()==System.Environment.MachineName.ToLower()));
						//				laMachineWarning.Visible=((tcVersion.Visible) && (!bLocalMachine));
						//				ViewOutputOnly=((!tcVersion.Visible) || (!bLocalMachine));
						//				laMachineWarning.Visible=(tcVersion.Visible);
						//						ViewOutputOnly=(!tcVersion.Visible);
						//						paClientLeft.Visible=(!ViewOutputOnly);
						//						paClientRightTop.Visible=(!ViewOutputOnly);
						//						tcVersion.Visible=(!ViewOutputOnly);
						//				btOpen.Visible=(!ViewOutputOnly);
						//				btSave.Visible=(!ViewOutputOnly);
						UpdateMachineName();
						Initialize(fmC.rbSQLDIAG.Checked, fmC.edAppName.Text);
						edMachine.Text=edTargetMachine.Text;
                        //Globals.PVTracker.FixupControls();
                        //this.Update();
                        lbCfgs.SelectedIndex = 2;
						bInitialized=true;
					}
				}
				catch(Exception ex)
				{
					if (ex.Message=="Cancel") 
					{
						Application.Exit();
					}
					else 
					{
						MessageBox.Show(ex.Message);
					}
				}
			}
			else 
			{
				edMachine.Text=".";
				edInstance.Text="*";
				Modified=false;

				//Set the default config path and populate the list (this causes the default cfg to be loaded)
				ConfigPath=Application.StartupPath+@"\Configurations\"+GetProcTypeText()+@"\";
			}
            //this.WindowState = FormWindowState.Maximized;
		}

		private void PopulateCustomGroups()
		{
			//Filter groups based on selected plat version 
			string PrefPlat=GetProcTypeText()+" only";
			string[] dirs= Directory.GetDirectories(Application.StartupPath+@"\CustomDiagnostics","*.*");
			Array.Sort(dirs);
			foreach (string dir in dirs) 
			{
				string dirName=Path.GetFileName(dir);
				bool bFound=false;
				foreach (ListViewItem lvi in lvCustomGroups.Items)
					if (0==string.Compare(lvi.Text,dirName,true,CultureInfo.InvariantCulture)) 
					{
						bFound=true;
						break;
					}
				if ((!bFound) && ((-1==dirName.IndexOf("only)")) || (-1!=dirName.IndexOf(PrefPlat))))
				{	
					if (!IsHiddenFolder(dirName))
						lvCustomGroups.Items.Add(dirName);
					
				}
			}
		}
		private bool IsHiddenFolder(String folderName)
		{
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			String HiddenFolderString = (string) configurationAppSettings.GetValue("HiddenFolders", typeof(string));
			if (HiddenFolderString == null)
				return false;
			String [] folders = HiddenFolderString.Split(new char [] {';'});
			foreach (string s in folders)
			{
				if (s.ToUpper() == folderName.ToUpper())
					return true;
			}
			return false;
		}

		public static Process LaunchApp(string Cmd, string Params, string Dir, bool bWait, bool HideWindow)
		{
			ProcessStartInfo pi = new ProcessStartInfo(Cmd, Params);
			Debug.WriteLine ("[" + Dir + "] " + Cmd + " " + Params);
            Logger.LogInfo ("Starting App " + "[" + Dir + "] " + Cmd + " " + Params);
			pi.WorkingDirectory = Dir;
			if (HideWindow)
			{
				pi.WindowStyle = ProcessWindowStyle.Hidden;
				pi.CreateNoWindow=true;
			} 
			else
			{
				pi.WindowStyle = ProcessWindowStyle.Normal;
				pi.CreateNoWindow=false;
			}
			Process p = Process.Start(pi);
			if (bWait)
				p.WaitForExit();
			return p;
		}

		public static Process LaunchApp(string Cmd, string Params, string Dir, bool bWait)
		{
			return LaunchApp (Cmd, Params, Dir, bWait, true);
		}
		public static Process LaunchApp(string Cmd, string Params, string Dir)
		{
			return LaunchApp(Cmd, Params, Dir, true);
		}

		public static Process LaunchApp(string Params, string Dir, bool bWait, bool HideWindow)
		{
			string ComSpec = System.Environment.SystemDirectory+"\\cmd.exe";
			return LaunchApp(ComSpec, Params, Dir, bWait, HideWindow);
		}

		public static Process LaunchApp(string Params, string Dir, bool bWait)
		{
			string ComSpec = System.Environment.SystemDirectory+"\\cmd.exe";
			return LaunchApp(ComSpec, Params, Dir, bWait);
		}
		public static Process LaunchApp(string Cmd, string Params)
		{
			return LaunchApp(Cmd,Params,Application.StartupPath,true);
		}

		public static Process LaunchApp(string Params)
		{
			string ComSpec = System.Environment.SystemDirectory+"\\cmd.exe";
			return LaunchApp(ComSpec,Params,Application.StartupPath,true);
		}

		public static Process LaunchApp(string Params, bool bWait, bool HideWindow)
		{
			string ComSpec = System.Environment.SystemDirectory+"\\cmd.exe";
			return LaunchApp(ComSpec,Params,Application.StartupPath,bWait,HideWindow);
		}

		public static Process LaunchApp(string Params, bool bWait)
		{
			string ComSpec = System.Environment.SystemDirectory+"\\cmd.exe";
			return LaunchApp(ComSpec,Params,Application.StartupPath,bWait);
		}

		private bool SaveCfgFile(string CfgFile)
		{
			if (0==string.Compare(".XML",Path.GetExtension(CfgFile),true,CultureInfo.InvariantCulture)) 
			{
				if (SaveXMLCfg(CfgFile)) 
				{
					od_Cfg.FileName=CfgFile;
					return true;
				}
				else
					return false;
			}
			else if (0==string.Compare(".INI",Path.GetExtension(CfgFile),true,CultureInfo.InvariantCulture)) 
			{
				if (SaveINICfg(CfgFile)) 
				{
					od_Cfg.FileName=CfgFile;
					return true;
				}
				else
					return false;
			}
			return false;
		}

		public void InitializeBuildFolder() 
		{
			string ssver=(tcVersion.SelectedIndex+MIN_SSVER).ToString();

			//Clear out the build folder and copy over the pristine folder
			if (null==LaunchApp("/Cinitbld.cmd "+ssver+" "+GetProcTypeText()+">initbld.log 2>&1")) 
				MessageBox.Show("Error initializing Build folder.");
		}

		private void CopyCustomDiag(string Source, string Target)
		{
			string ssver=m_ConfigDoc["dsConfig"]["Collection"]["Machines"]["Machine"]["Instances"]["Instance"].Attributes["ssver"].Value;

			if (null==LaunchApp("/CXCOPY \""+Source+"*.*\" \""+Target+"\" /E /Y"))
				MessageBox.Show("Error copying custom diagnostic files");

			if (File.Exists(Source+"BUILD.CMD")) 
			{
				if (null==LaunchApp("/CBUILD.CMD \""+Target+"\" "+ssver+" "+GetProcTypeText(),Source,true))
					throw new Exception("Error running custom build CMD file");
			}

			if (File.Exists(Source+"OPTIONALBUILD.CMD")) 
			{
                if (null == LaunchApp("/COPTIONALBUILD.CMD \"" + Target + "\" " + ssver + " " + GetProcTypeText(), Source, true))
                {
                    string error = "Error running custom optional build CMD file.";
                    error += "source: " + Source + "\t target: " + Target;
                    Debug.WriteLine("Error running custom optional build CMD file");
                    Logger.LogError(error);

                }
			}
		}


		private void CopyCustomDiagGroups(string GroupName)
		{
			string docName=Application.StartupPath+@"\CustomDiagnostics\"+GroupName+@"\CustomDiag.XML";
			if (!File.Exists(docName))
				return;
			XmlDocument gDoc = new XmlDocument();
			gDoc.Load(docName);
			foreach (XmlNode node in gDoc["CustomTasks"]) 
			{
				if (0==string.Compare("Group",node.Attributes["type"].Value,true,CultureInfo.InvariantCulture)) 
				{
					CopyCustomDiag(Application.StartupPath+@"\CustomDiagnostics\"+node.Attributes["cmd"].Value+"\\",Application.StartupPath+@"\BUILD\");
					CopyCustomDiagGroups(node.Attributes["cmd"].Value);
				}
			}
		}


		private void CopyCustomDiags()
		{
			foreach (ListViewItem lvi in lvCustomGroups.Items)
			{
				if (lvi.Checked) 
				{
					CopyCustomDiag(Application.StartupPath+@"\CustomDiagnostics\"+lvi.Text+"\\",Application.StartupPath+@"\BUILD");
					CopyCustomDiagGroups(lvi.Text);
				}
			

				if (ckASProfiler.Checked)
				{
					//CopyCustomDiag(Application.StartupPath+@"\CustomDiagnostics\AS\",Application.StartupPath+@"\BUILD");
					//commenting this out because we don't want an as folder there to confuse people
					//CopyCustomDiagGroups("AS");
				}
			}
		}

		private void DeleteBuildFiles(string Target)
		{
			LaunchApp("/CDEL \""+Target+"BUILD.CMD\" /Q");

			LaunchApp("/CDEL \""+Target+"OPTIONALBUILD.CMD\" /Q");

			LaunchApp("/CDEL \""+Target+"*customdiag.XML\" /Q");

			LaunchApp("/CDEL \""+Target+"*customdiag.ini\" /Q");

			LaunchApp("/CDEL \""+Target+"readme.rtf\" /Q");
		}

		private void BuildPSSDExe(string BasePath, string ExeFile)
		{
            
            
            if (Globals.UseCabarc() == true)
            {

                if (null == LaunchApp("/CCRPSSD.CMD \"" + BasePath + "\" \"" + ExeFile + "\" >> initbld.log 2>&1"))
                    MessageBox.Show(string.Format("Error adding the files in {0} to the self-extracting file {1}", BasePath, ExeFile));
                else
                    MessageBox.Show(string.Format("The files in {0} were compressed and added to the self-extracting file {1}", BasePath, ExeFile));
            }
            else
            {
                BuildCabUsingMakeCab(BasePath, ExeFile);
                MessageBox.Show (string.Format ("The files in {0} were compressed and added to file {1}", BasePath, ExeFile));
            }
		}
        private void BuildCabUsingMakeCab(string BasePath, string ExeFile)
        {
            String DestDir = Path.GetDirectoryName(ExeFile);
            String DestFile = Path.GetFileName(ExeFile);
            Makecab cab = new Makecab(BasePath, DestDir, DestFile);
            cab.CabFiles();

        }

		private void CreateEmail(string ExeFile)
		{
            return;
            /*
			try
			{
				Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();

				object FileName=Application.StartupPath+@"\docs\PSSDIAG Instructions.Doc";
				if (File.Exists((string)FileName)) 
				{

					if (File.Exists(ExeFile))
					{
						app.Visible=true;
						object m=Missing.Value;
						app.Documents.Open(ref FileName,ref m,ref m,ref m,ref m,
							ref m,ref m,ref m,ref m,ref m,
							ref m,ref m,ref m,ref m,
							ref m,ref m);
						app.ActiveWindow.EnvelopeVisible=true;
						object bFalse = false;
						object bTrue = true;
						app.Selection.InsertFile(ExeFile,ref m,ref bFalse,ref bFalse,ref bTrue);
					}
					else
					{
						MessageBox.Show(string.Format("Self-extracting CAB file {0} cannot be found",ExeFile));
						return;
					}
				}
				else
				{
					MessageBox.Show(string.Format("Email instructions document {0} cannot be found",FileName));
					return;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
             */
		}

		public bool CreateExe(string ExeFile, string SourcePath, bool bCreateEmail)
		{
			//Copy files from custom diag folders
			CopyCustomDiags();

			//Get rid of build files that were copied during the build process
			//such as build.cmd and readme.rtf
			DeleteBuildFiles(Application.StartupPath+@"\Build\");

			ExeFile=Path.GetFullPath(ExeFile);

			BuildPSSDExe(SourcePath,ExeFile);

			//Create the user email if requested
			if (bCreateEmail) 
				CreateEmail(ExeFile);

			return true;
		}

		private bool Save()
		{
			bool bRes=false;
			string CfgFile=(tcVersion.SelectedIndex<2?@".\Build\PSSDiag.INI":@".\Build\PSSDiag.XML");
			bool bCreateExe=true;
			string ExeFile="";
			bool bCreateEmail=true;

			if (!InternalConfig) //End user mode
			{
				if (DialogResult.OK==sd_Cfg.ShowDialog()) 
				{
					bRes=SaveCfgFile(CfgFile);
				}
			}
			else 
			{

				if (fmSave.GetSaveFiles(ref CfgFile,ref bCreateExe,ref ExeFile,ref bCreateEmail)) 
				{
					Cursor=Cursors.WaitCursor;
					try
					{
						ExeFile=Path.GetFullPath(ExeFile);

						if (bCreateExe)
							InitializeBuildFolder();

						bRes=SaveCfgFile(CfgFile);

						//Write the CAB if requested
						if (bCreateExe) 
						{
							CreateExe(ExeFile,Path.GetDirectoryName(CfgFile),bCreateEmail);
						}
					}
					finally
					{
						Cursor=Cursors.Default;
					}
				}
			}
			return bRes;
		}

		private void ClearOutputLog()
		{
			lvOutput.Items.Clear();
			reStrings.Clear();
		}

		private bool GetStartupParams()
		{
			bool bRes=false;
			string strMachine=edMachine.Text=="."?"":edMachine.Text;
			string strParams="";
			RegistryKey rk=RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine,strMachine);
			try
			{
				rk=rk.OpenSubKey("Software\\Microsoft\\SQLDiagEx\\"+edAppName.Text,true);
				strParams=fmInputBox.GetString("Service Startup Parameters",
											   "Please enter the command line parameters for the service:",
											   (string)rk.GetValue("StartupParameters"));
				if (strParams.Length!=0) 
				{
					rk.SetValue("StartupParameters",strParams);
					bRes=true;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error getting/setting service startup parameters: "+ex.Message);
			}
			return bRes;
		}

		private void StartService()
		{
			try
			{
				UpdateMachineName();
				if (DialogResult.OK!=fmStartupParams.GetStartupParams(edMachine.Text,edAppName.Text,ckProfiler.Checked)) 
					return;
				if (!ViewOutputOnly)
					SaveRegistryCfg();
//					SaveCfg(Application.StartupPath+"\\Bin\\pssdiag.xml");

				SetButtonsStatus(false);

				ClearOutputLog();

				//Zero the second and ms to work around weird timing issue on the local box
				//For the remote box, this will only be as accurate as the time sync between 
				//the boxes
				StartTime=new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0, 0);
				scPssdiag.Start();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error starting service: "+ex.Message);
				SetButtonsStatus(false);
			}
		}

		private void StopService()
		{
			try
			{
				UpdateMachineName();
				SetButtonsStatus(false);
				scPssdiag.Pause();
				Cursor=Cursors.WaitCursor;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message,"Error stopping service");
				SetButtonsStatus(false);
			}
		}

		private void tbMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{

			if (e.Button==btOpen) 
			{

				if (Modified) 
				{
					DialogResult dr=MessageBox.Show("Save current configuration?","Save",MessageBoxButtons.YesNoCancel);
					switch (dr) 
					{
						case DialogResult.Yes :
						{
							if (InternalConfig) 
							{
								if (!Save())
									return;
							}
							else 
							{
								if (!SaveRegistryCfg())
									return;
							}
							break;
						}
						case DialogResult.Cancel :
						{
							return;
							
						}
					}
				}

				if (od_Cfg.ShowDialog()==System.Windows.Forms.DialogResult.OK) 
				{
					if (LoadCfg(od_Cfg.FileName))
						sd_Cfg.FileName=od_Cfg.FileName;
				}
			}
			else if (e.Button==btSave) 
			{
				Save();
			}
			else if (e.Button==btMerge)
			{
			    	//				if (od_Cfg.ShowDialog()==System.Windows.Forms.DialogResult.OK) 
				//					MergeCfg(od_Cfg.FileName);
			}
			else if (e.Button==btStart)
			{
				StartService();
			}
			else if (e.Button==btStop)
			{
				StopService();
			}
			else if (e.Button==btAnalyze) 
			{

                Process.Start("http://sqlnexus.codeplex.com/");
                //				Process.
                //fmMain f = new fmMain(m_ConfigDoc);			
//				f.ShowDialog();
			}
		}

		private void UpdateAuthControls()
		{
			edLogin.Enabled=(rbSSAuth.Checked);
			laLogin.Enabled=(rbSSAuth.Checked);
		}

		private void rbWindowsAuth_Click(object sender, System.EventArgs e)
		{
			//Set modified flag
			Modified=true;

			UpdateAuthControls();
		}

		private void UpdateProfilerIntervalCB()
		{
			cbProfilerInterval.Visible=(tcVersion.SelectedIndex==0);  //SS 7.0
			laProfilerInterval.Visible=cbProfilerInterval.Visible;
			cbProfilerMaxFileSize.Visible=(!cbProfilerInterval.Visible);
			laProfilerMaxFileSize.Visible=cbProfilerMaxFileSize.Visible;
		}

		bool _bVerPrompted=false;
		bool _bPlatPrompted=false;
		bool _bCfgPrompted=false;

		private void tcVersion_SelectedIndexChanged(object sender, System.EventArgs e)
		{

            
            if (tcVersion.SelectedTab == tp70 || tcVersion.SelectedTab == tp2K)
            {
                MessageBox.Show("This release does not support SQL Server 2000 and 7.0 anymore.  Please use an older version of pssdiag which can be downloaded from http://support.microsoft.com/kb/830232 for SQL Server 2000 or 7.0");
                tcVersion.SelectedTab = tp2k8;
               // return;
            }
				if (
					(-1!=_iVer) &&  //Haven't yet set cache var
					(
					((tpX64==tcPlat.SelectedTab) && (tp2K5!=tcVersion.SelectedTab && tp2k8!=tcVersion.SelectedTab)) ||
					((tpIA64==tcPlat.SelectedTab) && (tp70==tcVersion.SelectedTab)) ||
					((Modified) && (!_bVerPrompted) && (DialogResult.Yes!=MessageBox.Show(@"Changing the target SQL Server version may cause pending changes to be lost.  Change anyway?","Pending Changes",MessageBoxButtons.YesNoCancel)))
					)
					) 
				{
					_bVerPrompted=true;
					tcVersion.SelectedIndex=_iVer;
					return;
				}
				else 
				{
					_bVerPrompted=false;
					if (_iVer!=tcVersion.SelectedIndex)
						_iVer=tcVersion.SelectedIndex;
					else
						return;
				}

				//tcTrace.SelectedIndex=0;
			try
			{

				//Set modified flag
				////				Modified=true;

				if (!ViewOutputOnly) 
				{
					//Set the trace path and populate the trace template list
					TracePath=(tcVersion.SelectedIndex+MIN_SSVER).ToString();

					//Assume there are trace template and pick the first one
					cbProfilerTemplate.SelectedIndex=0;

					//Set the perfmon path and load the templates
					PerfmonPath=(tcVersion.SelectedIndex+MIN_SSVER).ToString();

					//Instance only available on 8.0 and later
					edInstance.Enabled=(tcVersion.SelectedIndex!=0);

					//Blocking script interval not avail on 9.0 and later
					ckBlocker.Visible= (tcVersion.SelectedIndex==0 || tcVersion.SelectedIndex==1);
                    laBSInterval.Visible = (tcVersion.SelectedIndex == 0 || tcVersion.SelectedIndex == 1);
                    cbBSInterval.Visible = (tcVersion.SelectedIndex == 0 || tcVersion.SelectedIndex == 1);
                    ckBSFast.Visible = (tcVersion.SelectedIndex == 0 || tcVersion.SelectedIndex == 1);
                    ckBSLatch.Visible = (tcVersion.SelectedIndex == 0 || tcVersion.SelectedIndex == 1);

					//Default to no blocking script on Yukon and later
                    ckBlocker.Checked = (tcVersion.SelectedIndex == 0 || tcVersion.SelectedIndex == 1);

					//Select the last item in the list (only used for 7.0)
					cbProfilerInterval.SelectedIndex=cbProfilerInterval.Items.Count-1;

					UpdateProfilerIntervalCB();
				}

                Globals.PVTracker.OnVersionChanged();
                
               

                /*
                if (tp2k8 == tcVersion.SelectedTab)
                {
                    lbCfgs.SelectedIndex = 1;
                }
                else if (tp2K5 == tcVersion.SelectedTab || tp2K == tcVersion.SelectedTab)
                {
                    lbCfgs.SelectedIndex = 0;
                }*/


			}
			finally
			{
				Modified=false;
			}

		}

		private void ckEventLogs_CheckedChanged(object sender, System.EventArgs e)
		{
			//Set modified flag
			Modified=true;

			ckEventLogsStartup.Enabled=ckEventLogs.Checked;
			ckEventLogsShutdown.Enabled=ckEventLogs.Checked;
		}

		private void ckPerfmon_CheckedChanged(object sender, System.EventArgs e)
		{
			//Set modified flag
			Modified=true;

			cbPMMaxFileSize.Enabled=ckPerfmon.Checked;
			cbPMInterval.Enabled=ckPerfmon.Checked;
			laPMMaxFileSize.Enabled=ckPerfmon.Checked;
			laPMInterval.Enabled=ckPerfmon.Checked;
			tvPM.Enabled=ckPerfmon.Checked;
		}

		private void ckSqldiag_CheckedChanged(object sender, System.EventArgs e)
		{
			//Set modified flag
			Modified=true;

			ckSDStartup.Enabled=ckSqldiag.Checked;
			ckSDShutdown.Enabled=ckSqldiag.Checked;
		}

		private void ckBlocker_CheckedChanged(object sender, System.EventArgs e)
		{
			//Set modified flag
			Modified=true;

			ckBSLatch.Enabled=ckBlocker.Checked;
			ckBSFast.Enabled=ckBlocker.Checked;
			cbBSInterval.Enabled=ckBlocker.Checked;
			laBSInterval.Enabled=ckBlocker.Checked;
		}

		private void ckProfiler_CheckedChanged(object sender, System.EventArgs e)
		{
			//Set modified flag
			Modified=true;

			cbProfilerMaxFileSize.Enabled=ckProfiler.Checked;
			cbProfilerTemplate.Enabled=ckProfiler.Checked;
			cbProfilerInterval.Enabled=ckProfiler.Checked;
			cbProfilerMaxFileSize.Enabled=ckProfiler.Checked;
			laProfilerMaxFileSize.Enabled=ckProfiler.Checked;
			laProfilerInterval.Enabled=ckProfiler.Checked;
			laProfilerTemplate.Enabled=ckProfiler.Checked;
			tvProfiler.Enabled=ckProfiler.Checked;
		}

		int _iCfg=0;

		private void lbCfgs_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*
            if (
				(Modified) && 
				(!_bCfgPrompted) &&
				(DialogResult.Yes!=MessageBox.Show(@"Changing the issue type may cause pending changes to be lost.  Change anyway?","Pending Changes",MessageBoxButtons.YesNoCancel))
				)
			{
				_bCfgPrompted=true;
				lbCfgs.SelectedIndex=_iCfg;
				return;
			}
			else 
			{
				bool bWasPrompted=_bCfgPrompted;
				_bCfgPrompted=false;
				_iCfg=lbCfgs.SelectedIndex;
				if (bWasPrompted)
					return;
			}*/

            
            //lbCfgs.SelectedIndex = Globals.PVTracker.DefaultSqlTemplate;

            
            lbCfgs.Update();

			ConfigFile=lbCfgs.Items[lbCfgs.SelectedIndex].ToString().ToUpper();
			string fName=ConfigPath+Path.GetFileNameWithoutExtension(ConfigFile)+(InternalConfig?"":"_CustomerReady")+".RTF";
			if (File.Exists(fName))
				reInstructions.LoadFile(fName);
            Globals.PVTracker.OnDefaultTemplateChanged();
		}

		private void LoadTraceTemplate(string FileName)
		{
			try
			{
				//Clear filters
				if (null!=FilterForm)
					FilterForm.dsFilters.Clear();

				//Turn off the handler to prevent recursion
				tvProfiler.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvPM_AfterCheck);

				//Don't update the control while we load
				tvProfiler.BeginUpdate();
				try
				{
					tvProfiler.Nodes.Clear();
					XmlDocument m_ConfigDoc=new XmlDocument();
					m_ConfigDoc.Load(TracePath+FileName);
					PopulateTree(tvProfiler,m_ConfigDoc["dsProfiler"]["ProfilerCollector"]["Events"]);
				}
				finally
				{
					tvProfiler.EndUpdate();
					tvProfiler.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvPM_AfterCheck);
				}
			}
			catch (Exception e)
			{
				//Eat any exceptions during the load
				MessageBox.Show("Error loading trace template.  Message:  "+e.Message);
			}
		}

		private void cbProfilerTemplate_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			LoadTraceTemplate(((ComboBox)sender).Items[((ComboBox)sender).SelectedIndex].ToString());
		}

		private void UpdateDeleteButton()
		{
		}

		private void btDeleteMachine_Click(object sender, System.EventArgs e)
		{

		}

		private void btAddMachine_Click(object sender, System.EventArgs e)
		{
			string Machine=fmInputBox.GetString("Machine name","Please supply a new machine name","");
			if (0!=Machine.Length) {
				////
				cbMachine.SelectedValue=Machine;
			}
		}

		private void LoadPerfmonTemplate(string FileName)
		{
			try
			{
				XmlDocument m_ConfigDoc=new XmlDocument();
				m_ConfigDoc.Load(PerfmonPath+FileName);
				PopulateTree(tvPM,m_ConfigDoc["dsPerfmon"]["PerfmonCollector"]["PerfmonCounters"]);
			}
			catch (Exception e)
			{
				//Eat any exceptions during the load
				MessageBox.Show("Error loading perfmon template.  Message:  "+e.Message);
			}
		}

		private void LoadPerfmonTemplates()
		{

			//Remove handler to prevent recursion
			tvPM.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvPM_AfterCheck);

			//Don't update the control while we load
			tvPM.BeginUpdate();
			try
			{
				tvPM.Nodes.Clear();
				string[] Cfgs=Directory.GetFiles(PerfmonPath,"*.XML");
				foreach (string f in Cfgs) 
				{
					LoadPerfmonTemplate(Path.GetFileName(f));
				}
			}
			finally
			{
				tvPM.EndUpdate();
				tvPM.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvPM_AfterCheck);
			}
		}

		private void reInstructions_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(e.LinkText);
		}

		private void fmPssdiagConfig_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			DialogResult dr;
			if ((!btStart.Enabled) && (btStop.Enabled))
			{
				dr=MessageBox.Show("The collection process is still running.  Are you sure you want to exit?","Confirmation",MessageBoxButtons.YesNo);
				if (DialogResult.No==dr) 
				{
					e.Cancel=true;
					return;
				}
			}
			if ((!ViewOutputOnly) && (Modified))
			{
				dr=MessageBox.Show("Save current configuration?","Save",MessageBoxButtons.YesNoCancel);
				switch (dr) 
				{
					case DialogResult.Yes :
					{
						if (InternalConfig) 
						{
							e.Cancel=(!Save());
						}
						else 
						{
							e.Cancel=(!SaveRegistryCfg());
						}
						break;
					}
					case DialogResult.Cancel :
					{
						e.Cancel=true;
						break;
					}
				}
			}

			// Start shutdown auto-upgrade. See "PSSDiag Auto Update.doc" spec for details. 
			// Kick off .\UpgradeStaging\autoupdate1.cmd before closing to do background auto-update 
			// tasks after DiagConfig.exe has exited.  
			// 
			// For startup auto-update work, see CheckVersion().  
			try
			{
                string ProductVerNoBuildNo = Application.ProductVersion.Substring(0, Application.ProductVersion.LastIndexOf("."));
				// Sample command: 
				//    "C:\PSSDIAG\UpgradeStaging\autoupdate1.cmd" 9.0.1.130 "C:\PSSDIAG" > "C:\PSSDIAG\UpgradeStaging\autoupdate.log"
				string SetupCmd = "\"" + Path.GetDirectoryName(Application.ExecutablePath) + @"\UpgradeStaging\autoupdate10.cmd" + "\"";
                SetupCmd = SetupCmd + " " + ProductVerNoBuildNo + " \"" + Path.GetDirectoryName(Application.ExecutablePath) + "\"";
				SetupCmd = SetupCmd + " > \"" + Path.GetDirectoryName(Application.ExecutablePath) + @"\UpgradeStaging\autoupdate.log" + "\"" + @" 2>&1";
				// Launch autoupdate1.cmd and exit without waiting so that update can replace diagconfig.exe. 

                string CommandToLaunch = "/C \"" + SetupCmd + "\"" + "," + Path.GetDirectoryName(Application.ExecutablePath) + @"\UpgradeStaging";
                Logger.LogInfo("Auto Update Command");

                Logger.LogInfo(CommandToLaunch);
                Logger.LogInfo("\n");
				fmPssdiagConfig.LaunchApp (CommandToLaunch,Path.GetDirectoryName(Application.ExecutablePath),  false, true);
			}
			catch(Exception ex)
			{
				//Eat any exceptions -- we don't want a failure in background auto-update to 
				//cause a bad user experience 
				//Debug.WriteLine(ex.ToString());
                Logger.LogException(ex);
			}
		}

		private void tvPM_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			//Set modified flag
			Modified=true;

			//Remove handler to prevent recursion
			e.Node.TreeView.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvPM_AfterCheck);
			try
			{
				//Child node -- check/uncheck parent as appropriate
				if ((0==e.Node.Nodes.Count) && (null!=e.Node.Parent))
				{
					TreeNode parent=e.Node.Parent;
					int iCheckedCount=0;
					foreach (TreeNode node in parent.Nodes)
						if (node.Checked) iCheckedCount++;
					//All children unchecked
					if (0==iCheckedCount) 
					{
						parent.Checked=false;
						parent.BackColor=DisabledEnabled[1];
					}
					else //Some or all children checked
					{
						parent.BackColor=DisabledEnabled[Convert.ToInt32(parent.Nodes.Count==iCheckedCount)];
						parent.Checked=true;
					}
				}
				else //Parent node -- check/uncheck all children
				{
					e.Node.BackColor=DisabledEnabled[1];
					foreach (TreeNode node in e.Node.Nodes)
						node.Checked=e.Node.Checked;
				}
			}
			finally 
			{
				e.Node.TreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvPM_AfterCheck);
			}
		}

		private void SetButtonsStatus(bool bStatus)
		{
			btStart.Enabled=bStatus;
			btStop.Enabled=bStatus;
		}

		private bool UpdateButtonsStatus()
		{
			bool bRes=false;
			try
			{
				scPssdiag.Refresh();
				btStart.Enabled=(ServiceControllerStatus.Stopped==scPssdiag.Status);
				btStop.Enabled=((!btStart.Enabled) && (ServiceControllerStatus.Running==scPssdiag.Status));
				bRes=true;
			}
			catch(Exception ex)
			{
				Debug.WriteLine(ex.Message);
                Logger.LogException(ex);
				SetButtonsStatus(false);
			}
			miStart.Enabled=btStart.Enabled;
			miStop.Enabled=btStop.Enabled;
			return bRes;
		}

		private void edMachine_TextChanged(object sender, System.EventArgs e)
		{
			//Set modified flag
			Modified=true;
		}

		private void ckBSLatch_CheckedChanged(object sender, System.EventArgs e)
		{
			//Set modified flag
			Modified=true;
		}

		private void cbProfilerMaxFileSize_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//Set modified flag
			Modified=true;
		}

		private void AddEventLogEntry(EventLogEntry ev)
		{
			bool bFound=false;
			foreach (ListViewItem lvi in lvOutput.Items) 
			{
				if (((eventlogdata)lvi.Tag).LogIndex==ev.Index) 
				{
					bFound=true;
					break;
				}
			}
			if (bFound)
				return;
			string[] subitems=new string[5];
			subitems[0]=ev.EntryType.ToString();
			subitems[1]=ev.Message.TrimEnd();
			ListViewItem newItem=new ListViewItem(subitems);
			eventlogdata ed=new eventlogdata();
			ed.LogIndex=ev.Index;
			ed.Details=ev.ReplacementStrings;
			newItem.Tag=ed;
			switch (ev.EntryType)
			{
				case EventLogEntryType.Error : 
				{
					newItem.ImageIndex=12;
					break;
				}
				case EventLogEntryType.Warning : 
				{
					newItem.ImageIndex=11;
					break;
				}
				default: 
				{
					newItem.ImageIndex=10;
					break;
				}
			}
			lvOutput.Items.Add(newItem);
			newItem.Selected=true;
			lvOutput.EnsureVisible(newItem.Index);
		}

		private void UpdateEventLog()
		{
			tcInstructions.Cursor=Cursors.WaitCursor;
			lvOutput.BeginUpdate();
			try
			{
				foreach (EventLogEntry ev in evPssdiag.Entries)
					if ((edAppName.Text==ev.Source) && (ev.TimeWritten>=StartTime))
						AddEventLogEntry(ev);
			}
			finally
			{
				tcInstructions.Cursor=Cursors.Default;
				lvOutput.EndUpdate();
			}

		}

		private void tmPoll_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			try
			{
				tmPoll.Enabled=false;
				try
				{
					UpdateButtonsStatus();
					if (btStop.Enabled) 
					{
						if (!tmOutput.Enabled)
							tmOutput.Enabled=true;
						tcInstructions.SelectedIndex=1;
						paClient.Enabled=false;
						paPlat.Enabled=false;
						
						tcVersion.Enabled=false;
						btOpen.Enabled=false;
						btSave.Enabled=false;
					}
					else if (btStart.Enabled) 
					{
						if (tmOutput.Enabled) 
						{
							tmOutput.Enabled=false;
							UpdateEventLog();  //Refresh one last time
						}
						Cursor=Cursors.Default;
						paClient.Enabled=true;
						paPlat.Enabled=true;
						tcVersion.Enabled=true;
						btOpen.Enabled=true;
						btSave.Enabled=true;
					}
				}
				finally
				{
					tmPoll.Enabled=true;;
				}
			}
			catch(Exception ex)
			{
				//If we get some exception while controlling the service, 
				//stop polling it
				Debug.WriteLine(ex.Message);
                Logger.LogException(ex);
				tmPoll.Enabled=false;
				btStart.Enabled=false;
				btStop.Enabled=false;
			}
		}

		private bool DeregisterService()
		{
			bool bRes=false;
			try
			{
				//If the service isn't running, unregister it on exit
				ProcessStartInfo si=new ProcessStartInfo("PSSDIAG.EXE","/U");
				si.WindowStyle=ProcessWindowStyle.Hidden;
				Process p=Process.Start(si);
				if (null!=p)
					p.WaitForExit();

				bRes=true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error deregistering service: "+ex.Message);
			}
			return bRes;
		}

		private void fmPssdiagConfig_Closed(object sender, System.EventArgs e)
		{
			try
			{
				UpdateButtonsStatus();
				if (btStart.Enabled) 
				{
//					DeregisterService();
				}
			}
			catch(Exception ex)
			{
				//Eat any exceptions
				Debug.WriteLine(ex.Message);
                Logger.LogException(ex);
			}
		}

		private void lvOutput_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (0==lvOutput.SelectedIndices.Count) 
			{
				reStrings.Clear();
				return;
			}
			reStrings.Lines=((eventlogdata)lvOutput.SelectedItems[0].Tag).Details;
		}

		private void tmOutput_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			tmOutput.Enabled=false;
			try
			{
				UpdateEventLog();
			}
			finally
			{
				tmOutput.Enabled=true;
			}
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			UpdateEventLog();
		}

		private void fmPssdiagConfig_Resize(object sender, System.EventArgs e)
		{
		}

		private void miStart_Click(object sender, System.EventArgs e)
		{
			StartService();		
		}

		private void miStop_Click(object sender, System.EventArgs e)
		{
			StopService();
		}

		private void miExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void niPssdiag_DoubleClick(object sender, System.EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized)
				WindowState = FormWindowState.Normal;

			// Activate the form.
			Activate();
		}

		private void UpdateMachineName()
		{
			try
			{
				ClearOutputLog();
				if (!ViewOutputOnly)
					evPssdiag.MachineName=edMachine.Text;
				else
					evPssdiag.MachineName=edTargetMachine.Text;

				scPssdiag.MachineName=evPssdiag.MachineName;
				UpdateButtonsStatus();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void edTargetMachine_Validated(object sender, System.EventArgs e)
		{
			UpdateMachineName();
		}

		private void fmPssdiagConfig_Activated(object sender, System.EventArgs e)
		{
		}

		private void tbCustomGroups_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (btUp==e.Button) 
			{
				if (0==lvCustomGroups.SelectedItems.Count)
					return; //None selected
				if (0==lvCustomGroups.SelectedItems[0].Index)
					return;  //already at top
				bool prevChecked= lvCustomGroups.Items[lvCustomGroups.SelectedItems[0].Index-1].Checked;
				string prevName=lvCustomGroups.Items[lvCustomGroups.SelectedItems[0].Index-1].Text;

				lvCustomGroups.Items[lvCustomGroups.SelectedItems[0].Index-1].Checked=lvCustomGroups.SelectedItems[0].Checked;
				lvCustomGroups.Items[lvCustomGroups.SelectedItems[0].Index-1].Text=lvCustomGroups.SelectedItems[0].Text;
				lvCustomGroups.Items[lvCustomGroups.SelectedItems[0].Index].Checked=prevChecked;
				lvCustomGroups.Items[lvCustomGroups.SelectedItems[0].Index].Text=prevName;
				lvCustomGroups.Items[lvCustomGroups.SelectedItems[0].Index-1].Selected=true;
				lvCustomGroups.EnsureVisible(lvCustomGroups.SelectedItems[0].Index);
			}
			else if (btDown==e.Button) 
			{
				if (0==lvCustomGroups.SelectedItems.Count)
					return; //None selected
				if (lvCustomGroups.Items.Count-1==lvCustomGroups.SelectedItems[0].Index)
					return;  //already at bottom

				bool nextChecked= lvCustomGroups.Items[lvCustomGroups.SelectedItems[0].Index+1].Checked;
				string nextName=lvCustomGroups.Items[lvCustomGroups.SelectedItems[0].Index+1].Text;

				lvCustomGroups.Items[lvCustomGroups.SelectedItems[0].Index+1].Checked=lvCustomGroups.SelectedItems[0].Checked;
				lvCustomGroups.Items[lvCustomGroups.SelectedItems[0].Index+1].Text=lvCustomGroups.SelectedItems[0].Text;
				lvCustomGroups.Items[lvCustomGroups.SelectedItems[0].Index].Checked=nextChecked;
				lvCustomGroups.Items[lvCustomGroups.SelectedItems[0].Index].Text=nextName;
				lvCustomGroups.Items[lvCustomGroups.SelectedItems[0].Index+1].Selected=true;
				lvCustomGroups.EnsureVisible(lvCustomGroups.SelectedItems[0].Index);
			}
		}

		private void lvCustomGroups_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (0==lvCustomGroups.SelectedItems.Count)
				return;
			string fName=Application.StartupPath+@"\CustomDiagnostics\"+lvCustomGroups.SelectedItems[0].Text+@"\Readme.RTF";
			if (File.Exists(fName))
				reInstructions.LoadFile(fName);
			else
				reInstructions.Text="";
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
//			fmMain f = new fmMain();			
//			f.Show();
			Process.Start("SQL Nexus.appref-ms");
		}

		private void cmOutput_Popup(object sender, System.EventArgs e)
		{
		
		}

		private void miDetails_Click(object sender, System.EventArgs e)
		{
			if (0==lvCustomGroups.SelectedItems.Count)
				return;
			fmCustomTasks.GetTasks(lvCustomGroups.SelectedItems[0].Text);
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			Process.Start("SQLDiagAnalyzer.exe");
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			Process.Start("SpeedSearch.exe");
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			Process.Start("RowsetImport.exe");
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			Process.Start("Ostress_GUI.exe");
		}

		int _iPlat=0;

		private void tcPlat_SelectedIndexChanged(object sender, System.EventArgs e)
		{

				if (
					(Modified) && 
					(!_bPlatPrompted) &&
					(DialogResult.Yes!=MessageBox.Show(@"Changing the target platform may cause pending changes to be lost.  Change anyway?","Pending Changes",MessageBoxButtons.YesNoCancel))
					)
				{
					_bPlatPrompted=true;
					tcPlat.SelectedIndex=_iPlat;
					return;
				}
				else 
				{
					bool bWasPrompted=_bPlatPrompted;
					_bPlatPrompted=false;
					_iPlat=tcPlat.SelectedIndex;
					if (bWasPrompted)
						return;
				}

			try
			{
                /*
				if (tpX64==tcPlat.SelectedTab) 
				{
					tp70.ImageIndex=12;
					tp2K.ImageIndex=12;
				} 
				else if (tpIA64==tcPlat.SelectedTab)
				{
					tp70.ImageIndex=12;
					tp2K.ImageIndex=-1;
				}
				else 
				{
					tp70.ImageIndex=-1;
					tp2K.ImageIndex=-1;
				}


                // this is used to change default templates
                if (tp2k8 == tcVersion.SelectedTab)
                {
                    lbCfgs.SelectedIndex = 1;
                }
                else
                {
                    lbCfgs.SelectedIndex = 0;
                }
                lbCfgs.Update();
                 */

				SetDefaultCfgPath();
			}
			finally
			{
				Modified=false;
			}
		}

		private void tcVersion_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
		}

		private void tcVersion_Click(object sender, System.EventArgs e)
		{
		}

		private void tp2K5_Leave(object sender, System.EventArgs e)
		{
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			if (null==FilterForm)
				FilterForm = new fmTraceFilters();
			FilterForm.ShowDialog();
		}

		private void ckASProfiler_CheckedChanged(object sender, System.EventArgs e)
		{
			//Set modified flag
			Modified=true;

			cbASProfilerMaxFileSize.Enabled=ckASProfiler.Checked;
			laASProfilerMaxFileSize.Enabled=ckASProfiler.Checked;
			tvASProfiler.Enabled=ckASProfiler.Checked;
		
		}

		private void tcTrace_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
            /*if ((tp2K5!=tcVersion.SelectedTab)  && (1==tcTrace.SelectedIndex))
			{
				tcTrace.SelectedIndex=0;
				return;
			}*/



			// Auto-check the AS trace checkbox if the user visits the AS trace tab page
			if (1==tcTrace.SelectedIndex)
			{
				ckASProfiler.Checked = true;
             

			}
            Globals.PVTracker.OnTraceTabChanged();
		}

		private void cbASProfilerMaxFileSize_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Modified=true;
		}

        private void rgConnection_Enter(object sender, EventArgs e)
        {

        }

        private void lbCfgs_Click(object sender, EventArgs e)
        {
            Globals.PVTracker.TemplateClicked = true;
        }

	}
}



