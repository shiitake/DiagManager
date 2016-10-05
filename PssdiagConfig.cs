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
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace PssdiagConfig
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton btOpen;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBarButton btSave;
		private System.Windows.Forms.ToolBarButton btAnalyze;
		private System.Windows.Forms.ContextMenu cmAnalyze;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.Panel paTop;
		private System.Windows.Forms.Panel paTopLeft;
		private System.Windows.Forms.TextBox edCaseNumber;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel paLeft;
		private System.Windows.Forms.Panel paLeftTop;
		private System.Windows.Forms.ListView lvINI;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel paBottom;
		private System.Windows.Forms.RichTextBox reDesc;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.TabControl tcVersion;
		private System.Windows.Forms.TabPage tp70;
		private System.Windows.Forms.TabPage tp2K;
		private System.Windows.Forms.TabPage tp05;
		private System.Windows.Forms.Panel paClient;
		private System.Windows.Forms.Panel paClientLeft;
		private System.Windows.Forms.Splitter splitter3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox edInstance;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox rgAuth;
		private System.Windows.Forms.RadioButton rbWindowsAuth;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox edLogin;
		private System.Windows.Forms.Splitter splitter4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Panel paPMTop;
		private System.Windows.Forms.CheckBox ckEventLogs;
		private System.Windows.Forms.CheckBox ckEventLogsStartup;
		private System.Windows.Forms.CheckBox ckEventLogsShutdown;
		private System.Windows.Forms.CheckBox ckPerfmon;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cbPMMaxFileSize;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TreeView tvPM;
		private System.Windows.Forms.Panel paClientRightTop;
		private System.Windows.Forms.Splitter splitter5;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ComboBox cbPMInterval;
		private System.Windows.Forms.CheckBox ckSqldiag;
		private System.Windows.Forms.CheckBox ckSDShutdown;
		private System.Windows.Forms.CheckBox ckSDStartup;
		private System.Windows.Forms.CheckBox ckBlocker;
		private System.Windows.Forms.CheckBox ckBSShutdown;
		private System.Windows.Forms.CheckBox ckBSStartup;
		private System.Windows.Forms.ComboBox cbBSInterval;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox ckProfiler;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Panel paInstanceTop;
		private System.Windows.Forms.Panel paInstanceClient;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Splitter splitter6;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.GroupBox rgCustom;
		private System.Windows.Forms.TabControl tcCustom;
		private System.Windows.Forms.TabPage tpSummary;
		private System.Windows.Forms.TabPage tpDetails;
		private System.Windows.Forms.ToolBar toolBar2;
		private System.Windows.Forms.ToolBarButton btSummaryUp;
		private System.Windows.Forms.ToolBarButton btSummaryDown;
		private System.Windows.Forms.ToolBar toolBar3;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.DataGrid dgDetails;
		private System.Windows.Forms.CheckedListBox cklSummary;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cbMachine;
		private System.Windows.Forms.Button btDeleteMachine;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.paTop = new System.Windows.Forms.Panel();
			this.paTopLeft = new System.Windows.Forms.Panel();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.btOpen = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btSave = new System.Windows.Forms.ToolBarButton();
			this.btAnalyze = new System.Windows.Forms.ToolBarButton();
			this.cmAnalyze = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.edCaseNumber = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.paLeft = new System.Windows.Forms.Panel();
			this.paLeftTop = new System.Windows.Forms.Panel();
			this.lvINI = new System.Windows.Forms.ListView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.paBottom = new System.Windows.Forms.Panel();
			this.reDesc = new System.Windows.Forms.RichTextBox();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.tcVersion = new System.Windows.Forms.TabControl();
			this.tp70 = new System.Windows.Forms.TabPage();
			this.tp2K = new System.Windows.Forms.TabPage();
			this.tp05 = new System.Windows.Forms.TabPage();
			this.paClient = new System.Windows.Forms.Panel();
			this.paClientLeft = new System.Windows.Forms.Panel();
			this.splitter3 = new System.Windows.Forms.Splitter();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.edInstance = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.rgAuth = new System.Windows.Forms.GroupBox();
			this.rbWindowsAuth = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.label4 = new System.Windows.Forms.Label();
			this.edLogin = new System.Windows.Forms.TextBox();
			this.splitter4 = new System.Windows.Forms.Splitter();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.paPMTop = new System.Windows.Forms.Panel();
			this.ckEventLogs = new System.Windows.Forms.CheckBox();
			this.ckEventLogsStartup = new System.Windows.Forms.CheckBox();
			this.ckEventLogsShutdown = new System.Windows.Forms.CheckBox();
			this.ckPerfmon = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cbPMMaxFileSize = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cbPMInterval = new System.Windows.Forms.ComboBox();
			this.tvPM = new System.Windows.Forms.TreeView();
			this.paClientRightTop = new System.Windows.Forms.Panel();
			this.splitter5 = new System.Windows.Forms.Splitter();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.paInstanceTop = new System.Windows.Forms.Panel();
			this.ckSqldiag = new System.Windows.Forms.CheckBox();
			this.ckSDShutdown = new System.Windows.Forms.CheckBox();
			this.ckSDStartup = new System.Windows.Forms.CheckBox();
			this.ckBlocker = new System.Windows.Forms.CheckBox();
			this.ckBSShutdown = new System.Windows.Forms.CheckBox();
			this.ckBSStartup = new System.Windows.Forms.CheckBox();
			this.cbBSInterval = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.ckProfiler = new System.Windows.Forms.CheckBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.paInstanceClient = new System.Windows.Forms.Panel();
			this.listView1 = new System.Windows.Forms.ListView();
			this.splitter6 = new System.Windows.Forms.Splitter();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.rgCustom = new System.Windows.Forms.GroupBox();
			this.tcCustom = new System.Windows.Forms.TabControl();
			this.tpSummary = new System.Windows.Forms.TabPage();
			this.tpDetails = new System.Windows.Forms.TabPage();
			this.toolBar2 = new System.Windows.Forms.ToolBar();
			this.btSummaryUp = new System.Windows.Forms.ToolBarButton();
			this.btSummaryDown = new System.Windows.Forms.ToolBarButton();
			this.toolBar3 = new System.Windows.Forms.ToolBar();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.dgDetails = new System.Windows.Forms.DataGrid();
			this.cklSummary = new System.Windows.Forms.CheckedListBox();
			this.label9 = new System.Windows.Forms.Label();
			this.cbMachine = new System.Windows.Forms.ComboBox();
			this.btDeleteMachine = new System.Windows.Forms.Button();
			this.paTop.SuspendLayout();
			this.paTopLeft.SuspendLayout();
			this.paLeft.SuspendLayout();
			this.paLeftTop.SuspendLayout();
			this.paBottom.SuspendLayout();
			this.tcVersion.SuspendLayout();
			this.paClient.SuspendLayout();
			this.paClientLeft.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.rgAuth.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.paPMTop.SuspendLayout();
			this.paClientRightTop.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.paInstanceTop.SuspendLayout();
			this.paInstanceClient.SuspendLayout();
			this.rgCustom.SuspendLayout();
			this.tcCustom.SuspendLayout();
			this.tpSummary.SuspendLayout();
			this.tpDetails.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgDetails)).BeginInit();
			this.SuspendLayout();
			// 
			// paTop
			// 
			this.paTop.Controls.Add(this.label1);
			this.paTop.Controls.Add(this.edCaseNumber);
			this.paTop.Controls.Add(this.paTopLeft);
			this.paTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.paTop.Location = new System.Drawing.Point(0, 0);
			this.paTop.Name = "paTop";
			this.paTop.Size = new System.Drawing.Size(1000, 48);
			this.paTop.TabIndex = 0;
			// 
			// paTopLeft
			// 
			this.paTopLeft.Controls.Add(this.toolBar1);
			this.paTopLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.paTopLeft.Location = new System.Drawing.Point(0, 0);
			this.paTopLeft.Name = "paTopLeft";
			this.paTopLeft.Size = new System.Drawing.Size(408, 48);
			this.paTopLeft.TabIndex = 0;
			// 
			// toolBar1
			// 
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.btOpen,
																						this.btSave,
																						this.btAnalyze});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(408, 42);
			this.toolBar1.TabIndex = 0;
			// 
			// btOpen
			// 
			this.btOpen.ImageIndex = 0;
			this.btOpen.Text = "Open";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// btSave
			// 
			this.btSave.ImageIndex = 1;
			this.btSave.Text = "Save";
			// 
			// btAnalyze
			// 
			this.btAnalyze.DropDownMenu = this.cmAnalyze;
			this.btAnalyze.ImageIndex = 2;
			this.btAnalyze.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.btAnalyze.Text = "Analyze";
			// 
			// cmAnalyze
			// 
			this.cmAnalyze.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem2,
																					  this.menuItem3,
																					  this.menuItem4});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "&SQLDiag Analyzer";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "S&peedSearch";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "&Trace Analyzer";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 3;
			this.menuItem4.Text = "&Ostress GUI";
			// 
			// edCaseNumber
			// 
			this.edCaseNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.edCaseNumber.AutoSize = false;
			this.edCaseNumber.Location = new System.Drawing.Point(880, 14);
			this.edCaseNumber.Name = "edCaseNumber";
			this.edCaseNumber.Size = new System.Drawing.Size(112, 20);
			this.edCaseNumber.TabIndex = 1;
			this.edCaseNumber.Text = "";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(840, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Case";
			// 
			// paLeft
			// 
			this.paLeft.Controls.Add(this.lvINI);
			this.paLeft.Controls.Add(this.paLeftTop);
			this.paLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.paLeft.Location = new System.Drawing.Point(0, 48);
			this.paLeft.Name = "paLeft";
			this.paLeft.Size = new System.Drawing.Size(152, 550);
			this.paLeft.TabIndex = 1;
			// 
			// paLeftTop
			// 
			this.paLeftTop.Controls.Add(this.label9);
			this.paLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.paLeftTop.Location = new System.Drawing.Point(0, 0);
			this.paLeftTop.Name = "paLeftTop";
			this.paLeftTop.Size = new System.Drawing.Size(152, 32);
			this.paLeftTop.TabIndex = 0;
			// 
			// lvINI
			// 
			this.lvINI.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvINI.Location = new System.Drawing.Point(0, 32);
			this.lvINI.Name = "lvINI";
			this.lvINI.Size = new System.Drawing.Size(152, 518);
			this.lvINI.TabIndex = 1;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(152, 72);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 523);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// paBottom
			// 
			this.paBottom.Controls.Add(this.reDesc);
			this.paBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.paBottom.Location = new System.Drawing.Point(0, 598);
			this.paBottom.Name = "paBottom";
			this.paBottom.Size = new System.Drawing.Size(1000, 40);
			this.paBottom.TabIndex = 3;
			// 
			// reDesc
			// 
			this.reDesc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.reDesc.Location = new System.Drawing.Point(0, 0);
			this.reDesc.Name = "reDesc";
			this.reDesc.Size = new System.Drawing.Size(1000, 40);
			this.reDesc.TabIndex = 0;
			this.reDesc.Text = "";
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter2.Location = new System.Drawing.Point(152, 595);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(848, 3);
			this.splitter2.TabIndex = 4;
			this.splitter2.TabStop = false;
			// 
			// tcVersion
			// 
			this.tcVersion.Controls.Add(this.tp70);
			this.tcVersion.Controls.Add(this.tp2K);
			this.tcVersion.Controls.Add(this.tp05);
			this.tcVersion.Dock = System.Windows.Forms.DockStyle.Top;
			this.tcVersion.Location = new System.Drawing.Point(152, 48);
			this.tcVersion.Name = "tcVersion";
			this.tcVersion.SelectedIndex = 0;
			this.tcVersion.Size = new System.Drawing.Size(848, 24);
			this.tcVersion.TabIndex = 5;
			// 
			// tp70
			// 
			this.tp70.Location = new System.Drawing.Point(4, 22);
			this.tp70.Name = "tp70";
			this.tp70.Size = new System.Drawing.Size(840, 0);
			this.tp70.TabIndex = 0;
			this.tp70.Text = "SQL Server 7.0";
			// 
			// tp2K
			// 
			this.tp2K.Location = new System.Drawing.Point(4, 22);
			this.tp2K.Name = "tp2K";
			this.tp2K.Size = new System.Drawing.Size(565, 0);
			this.tp2K.TabIndex = 1;
			this.tp2K.Text = "SQL Server 2000";
			// 
			// tp05
			// 
			this.tp05.Location = new System.Drawing.Point(4, 22);
			this.tp05.Name = "tp05";
			this.tp05.Size = new System.Drawing.Size(565, 74);
			this.tp05.TabIndex = 2;
			this.tp05.Text = "SQL Server 2005";
			// 
			// paClient
			// 
			this.paClient.Controls.Add(this.rgCustom);
			this.paClient.Controls.Add(this.splitter5);
			this.paClient.Controls.Add(this.paClientRightTop);
			this.paClient.Controls.Add(this.splitter3);
			this.paClient.Controls.Add(this.paClientLeft);
			this.paClient.Dock = System.Windows.Forms.DockStyle.Fill;
			this.paClient.Location = new System.Drawing.Point(152, 72);
			this.paClient.Name = "paClient";
			this.paClient.Size = new System.Drawing.Size(848, 523);
			this.paClient.TabIndex = 6;
			// 
			// paClientLeft
			// 
			this.paClientLeft.Controls.Add(this.groupBox2);
			this.paClientLeft.Controls.Add(this.splitter4);
			this.paClientLeft.Controls.Add(this.groupBox1);
			this.paClientLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.paClientLeft.Location = new System.Drawing.Point(0, 0);
			this.paClientLeft.Name = "paClientLeft";
			this.paClientLeft.Size = new System.Drawing.Size(392, 523);
			this.paClientLeft.TabIndex = 0;
			// 
			// splitter3
			// 
			this.splitter3.Location = new System.Drawing.Point(392, 0);
			this.splitter3.Name = "splitter3";
			this.splitter3.Size = new System.Drawing.Size(3, 523);
			this.splitter3.TabIndex = 1;
			this.splitter3.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btDeleteMachine);
			this.groupBox1.Controls.Add(this.cbMachine);
			this.groupBox1.Controls.Add(this.rgAuth);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.edInstance);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(392, 240);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Connection Info";
			// 
			// edInstance
			// 
			this.edInstance.Location = new System.Drawing.Point(137, 61);
			this.edInstance.Name = "edInstance";
			this.edInstance.Size = new System.Drawing.Size(127, 20);
			this.edInstance.TabIndex = 1;
			this.edInstance.Text = "*";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(41, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Machine name";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(41, 60);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 23);
			this.label3.TabIndex = 3;
			this.label3.Text = "Instance name";
			// 
			// rgAuth
			// 
			this.rgAuth.Controls.Add(this.edLogin);
			this.rgAuth.Controls.Add(this.label4);
			this.rgAuth.Controls.Add(this.radioButton1);
			this.rgAuth.Controls.Add(this.rbWindowsAuth);
			this.rgAuth.Location = new System.Drawing.Point(8, 101);
			this.rgAuth.Name = "rgAuth";
			this.rgAuth.Size = new System.Drawing.Size(288, 123);
			this.rgAuth.TabIndex = 4;
			this.rgAuth.TabStop = false;
			this.rgAuth.Text = "Connect using:";
			// 
			// rbWindowsAuth
			// 
			this.rbWindowsAuth.Checked = true;
			this.rbWindowsAuth.Location = new System.Drawing.Point(24, 21);
			this.rbWindowsAuth.Name = "rbWindowsAuth";
			this.rbWindowsAuth.Size = new System.Drawing.Size(160, 24);
			this.rbWindowsAuth.TabIndex = 0;
			this.rbWindowsAuth.TabStop = true;
			this.rbWindowsAuth.Text = "Windows authentication";
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(24, 50);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(167, 24);
			this.radioButton1.TabIndex = 1;
			this.radioButton1.Text = "SQL Server authentication";
			// 
			// label4
			// 
			this.label4.Enabled = false;
			this.label4.Location = new System.Drawing.Point(43, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 23);
			this.label4.TabIndex = 2;
			this.label4.Text = "Login name";
			// 
			// edLogin
			// 
			this.edLogin.Enabled = false;
			this.edLogin.Location = new System.Drawing.Point(129, 89);
			this.edLogin.Name = "edLogin";
			this.edLogin.Size = new System.Drawing.Size(127, 20);
			this.edLogin.TabIndex = 3;
			this.edLogin.Text = "";
			// 
			// splitter4
			// 
			this.splitter4.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter4.Location = new System.Drawing.Point(0, 240);
			this.splitter4.Name = "splitter4";
			this.splitter4.Size = new System.Drawing.Size(392, 3);
			this.splitter4.TabIndex = 1;
			this.splitter4.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tvPM);
			this.groupBox2.Controls.Add(this.paPMTop);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 243);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(392, 280);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Machine-wide Diagnostics";
			// 
			// paPMTop
			// 
			this.paPMTop.Controls.Add(this.cbPMInterval);
			this.paPMTop.Controls.Add(this.label6);
			this.paPMTop.Controls.Add(this.cbPMMaxFileSize);
			this.paPMTop.Controls.Add(this.label5);
			this.paPMTop.Controls.Add(this.ckPerfmon);
			this.paPMTop.Controls.Add(this.ckEventLogsShutdown);
			this.paPMTop.Controls.Add(this.ckEventLogsStartup);
			this.paPMTop.Controls.Add(this.ckEventLogs);
			this.paPMTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.paPMTop.Location = new System.Drawing.Point(3, 16);
			this.paPMTop.Name = "paPMTop";
			this.paPMTop.Size = new System.Drawing.Size(386, 60);
			this.paPMTop.TabIndex = 0;
			// 
			// ckEventLogs
			// 
			this.ckEventLogs.Checked = true;
			this.ckEventLogs.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckEventLogs.Location = new System.Drawing.Point(8, 8);
			this.ckEventLogs.Name = "ckEventLogs";
			this.ckEventLogs.Size = new System.Drawing.Size(104, 16);
			this.ckEventLogs.TabIndex = 0;
			this.ckEventLogs.Text = "Event logs";
			// 
			// ckEventLogsStartup
			// 
			this.ckEventLogsStartup.Location = new System.Drawing.Point(120, 8);
			this.ckEventLogsStartup.Name = "ckEventLogsStartup";
			this.ckEventLogsStartup.Size = new System.Drawing.Size(104, 16);
			this.ckEventLogsStartup.TabIndex = 1;
			this.ckEventLogsStartup.Text = "Startup";
			// 
			// ckEventLogsShutdown
			// 
			this.ckEventLogsShutdown.Checked = true;
			this.ckEventLogsShutdown.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckEventLogsShutdown.Location = new System.Drawing.Point(224, 8);
			this.ckEventLogsShutdown.Name = "ckEventLogsShutdown";
			this.ckEventLogsShutdown.Size = new System.Drawing.Size(104, 16);
			this.ckEventLogsShutdown.TabIndex = 2;
			this.ckEventLogsShutdown.Text = "Shutdown";
			// 
			// ckPerfmon
			// 
			this.ckPerfmon.Location = new System.Drawing.Point(8, 31);
			this.ckPerfmon.Name = "ckPerfmon";
			this.ckPerfmon.Size = new System.Drawing.Size(72, 16);
			this.ckPerfmon.TabIndex = 3;
			this.ckPerfmon.Text = "Perfmon";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(88, 31);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(96, 16);
			this.label5.TabIndex = 4;
			this.label5.Text = "Max file size(MB)";
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
			this.cbPMMaxFileSize.Location = new System.Drawing.Point(184, 31);
			this.cbPMMaxFileSize.Name = "cbPMMaxFileSize";
			this.cbPMMaxFileSize.Size = new System.Drawing.Size(48, 21);
			this.cbPMMaxFileSize.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(240, 31);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 23);
			this.label6.TabIndex = 6;
			this.label6.Text = "Interval (secs)";
			// 
			// cbPMInterval
			// 
			this.cbPMInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPMInterval.Items.AddRange(new object[] {
															  "5",
															  "15",
															  "30",
															  "60"});
			this.cbPMInterval.Location = new System.Drawing.Point(328, 31);
			this.cbPMInterval.Name = "cbPMInterval";
			this.cbPMInterval.Size = new System.Drawing.Size(48, 21);
			this.cbPMInterval.TabIndex = 7;
			// 
			// tvPM
			// 
			this.tvPM.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvPM.ImageIndex = -1;
			this.tvPM.Location = new System.Drawing.Point(3, 76);
			this.tvPM.Name = "tvPM";
			this.tvPM.SelectedImageIndex = -1;
			this.tvPM.Size = new System.Drawing.Size(386, 201);
			this.tvPM.TabIndex = 1;
			// 
			// paClientRightTop
			// 
			this.paClientRightTop.Controls.Add(this.groupBox3);
			this.paClientRightTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.paClientRightTop.Location = new System.Drawing.Point(395, 0);
			this.paClientRightTop.Name = "paClientRightTop";
			this.paClientRightTop.Size = new System.Drawing.Size(453, 240);
			this.paClientRightTop.TabIndex = 2;
			// 
			// splitter5
			// 
			this.splitter5.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter5.Location = new System.Drawing.Point(395, 240);
			this.splitter5.Name = "splitter5";
			this.splitter5.Size = new System.Drawing.Size(453, 3);
			this.splitter5.TabIndex = 3;
			this.splitter5.TabStop = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.paInstanceClient);
			this.groupBox3.Controls.Add(this.paInstanceTop);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox3.Location = new System.Drawing.Point(0, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(453, 240);
			this.groupBox3.TabIndex = 0;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Instance-specific Diagnostics";
			// 
			// paInstanceTop
			// 
			this.paInstanceTop.Controls.Add(this.comboBox1);
			this.paInstanceTop.Controls.Add(this.label8);
			this.paInstanceTop.Controls.Add(this.ckProfiler);
			this.paInstanceTop.Controls.Add(this.cbBSInterval);
			this.paInstanceTop.Controls.Add(this.label7);
			this.paInstanceTop.Controls.Add(this.ckBSShutdown);
			this.paInstanceTop.Controls.Add(this.ckBSStartup);
			this.paInstanceTop.Controls.Add(this.ckBlocker);
			this.paInstanceTop.Controls.Add(this.ckSDShutdown);
			this.paInstanceTop.Controls.Add(this.ckSDStartup);
			this.paInstanceTop.Controls.Add(this.ckSqldiag);
			this.paInstanceTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.paInstanceTop.Location = new System.Drawing.Point(3, 16);
			this.paInstanceTop.Name = "paInstanceTop";
			this.paInstanceTop.Size = new System.Drawing.Size(447, 72);
			this.paInstanceTop.TabIndex = 0;
			// 
			// ckSqldiag
			// 
			this.ckSqldiag.Checked = true;
			this.ckSqldiag.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckSqldiag.Location = new System.Drawing.Point(8, 8);
			this.ckSqldiag.Name = "ckSqldiag";
			this.ckSqldiag.Size = new System.Drawing.Size(104, 16);
			this.ckSqldiag.TabIndex = 0;
			this.ckSqldiag.Text = "SQLDIAG";
			// 
			// ckSDShutdown
			// 
			this.ckSDShutdown.Checked = true;
			this.ckSDShutdown.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckSDShutdown.Location = new System.Drawing.Point(216, 8);
			this.ckSDShutdown.Name = "ckSDShutdown";
			this.ckSDShutdown.Size = new System.Drawing.Size(104, 16);
			this.ckSDShutdown.TabIndex = 4;
			this.ckSDShutdown.Text = "Shutdown";
			// 
			// ckSDStartup
			// 
			this.ckSDStartup.Location = new System.Drawing.Point(112, 8);
			this.ckSDStartup.Name = "ckSDStartup";
			this.ckSDStartup.Size = new System.Drawing.Size(104, 16);
			this.ckSDStartup.TabIndex = 3;
			this.ckSDStartup.Text = "Startup";
			// 
			// ckBlocker
			// 
			this.ckBlocker.Location = new System.Drawing.Point(8, 29);
			this.ckBlocker.Name = "ckBlocker";
			this.ckBlocker.Size = new System.Drawing.Size(104, 16);
			this.ckBlocker.TabIndex = 5;
			this.ckBlocker.Text = "Blocking script";
			// 
			// ckBSShutdown
			// 
			this.ckBSShutdown.Checked = true;
			this.ckBSShutdown.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckBSShutdown.Location = new System.Drawing.Point(216, 29);
			this.ckBSShutdown.Name = "ckBSShutdown";
			this.ckBSShutdown.Size = new System.Drawing.Size(104, 16);
			this.ckBSShutdown.TabIndex = 7;
			this.ckBSShutdown.Text = "Shutdown";
			// 
			// ckBSStartup
			// 
			this.ckBSStartup.Location = new System.Drawing.Point(112, 29);
			this.ckBSStartup.Name = "ckBSStartup";
			this.ckBSStartup.Size = new System.Drawing.Size(104, 16);
			this.ckBSStartup.TabIndex = 6;
			this.ckBSStartup.Text = "Startup";
			// 
			// cbBSInterval
			// 
			this.cbBSInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBSInterval.Items.AddRange(new object[] {
															  "5",
															  "15",
															  "30",
															  "60"});
			this.cbBSInterval.Location = new System.Drawing.Point(392, 26);
			this.cbBSInterval.Name = "cbBSInterval";
			this.cbBSInterval.Size = new System.Drawing.Size(48, 21);
			this.cbBSInterval.TabIndex = 9;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(320, 28);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 16);
			this.label7.TabIndex = 8;
			this.label7.Text = "Interval (secs)";
			// 
			// ckProfiler
			// 
			this.ckProfiler.Location = new System.Drawing.Point(8, 50);
			this.ckProfiler.Name = "ckProfiler";
			this.ckProfiler.Size = new System.Drawing.Size(104, 16);
			this.ckProfiler.TabIndex = 10;
			this.ckProfiler.Text = "Profiler Trace";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Items.AddRange(new object[] {
														   "None",
														   "50",
														   "100",
														   "150",
														   "200",
														   "256",
														   "512",
														   "1024"});
			this.comboBox1.Location = new System.Drawing.Point(198, 48);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(48, 21);
			this.comboBox1.TabIndex = 12;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(110, 50);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(98, 16);
			this.label8.TabIndex = 11;
			this.label8.Text = "Max file size(MB)";
			// 
			// paInstanceClient
			// 
			this.paInstanceClient.Controls.Add(this.treeView1);
			this.paInstanceClient.Controls.Add(this.splitter6);
			this.paInstanceClient.Controls.Add(this.listView1);
			this.paInstanceClient.Dock = System.Windows.Forms.DockStyle.Fill;
			this.paInstanceClient.Location = new System.Drawing.Point(3, 88);
			this.paInstanceClient.Name = "paInstanceClient";
			this.paInstanceClient.Size = new System.Drawing.Size(447, 149);
			this.paInstanceClient.TabIndex = 1;
			// 
			// listView1
			// 
			this.listView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(160, 149);
			this.listView1.TabIndex = 0;
			// 
			// splitter6
			// 
			this.splitter6.Location = new System.Drawing.Point(160, 0);
			this.splitter6.Name = "splitter6";
			this.splitter6.Size = new System.Drawing.Size(3, 149);
			this.splitter6.TabIndex = 1;
			this.splitter6.TabStop = false;
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.ImageIndex = -1;
			this.treeView1.Location = new System.Drawing.Point(163, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = -1;
			this.treeView1.Size = new System.Drawing.Size(284, 149);
			this.treeView1.TabIndex = 2;
			// 
			// rgCustom
			// 
			this.rgCustom.Controls.Add(this.tcCustom);
			this.rgCustom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rgCustom.Location = new System.Drawing.Point(395, 243);
			this.rgCustom.Name = "rgCustom";
			this.rgCustom.Size = new System.Drawing.Size(453, 280);
			this.rgCustom.TabIndex = 4;
			this.rgCustom.TabStop = false;
			this.rgCustom.Text = "Custom Diagnostics";
			// 
			// tcCustom
			// 
			this.tcCustom.Controls.Add(this.tpSummary);
			this.tcCustom.Controls.Add(this.tpDetails);
			this.tcCustom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcCustom.Location = new System.Drawing.Point(3, 16);
			this.tcCustom.Name = "tcCustom";
			this.tcCustom.SelectedIndex = 0;
			this.tcCustom.Size = new System.Drawing.Size(447, 261);
			this.tcCustom.TabIndex = 0;
			// 
			// tpSummary
			// 
			this.tpSummary.Controls.Add(this.cklSummary);
			this.tpSummary.Controls.Add(this.toolBar2);
			this.tpSummary.Location = new System.Drawing.Point(4, 22);
			this.tpSummary.Name = "tpSummary";
			this.tpSummary.Size = new System.Drawing.Size(439, 235);
			this.tpSummary.TabIndex = 0;
			this.tpSummary.Text = "Summary";
			// 
			// tpDetails
			// 
			this.tpDetails.Controls.Add(this.dgDetails);
			this.tpDetails.Controls.Add(this.toolBar3);
			this.tpDetails.Location = new System.Drawing.Point(4, 22);
			this.tpDetails.Name = "tpDetails";
			this.tpDetails.Size = new System.Drawing.Size(439, 235);
			this.tpDetails.TabIndex = 1;
			this.tpDetails.Text = "Details";
			// 
			// toolBar2
			// 
			this.toolBar2.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.btSummaryUp,
																						this.btSummaryDown});
			this.toolBar2.DropDownArrows = true;
			this.toolBar2.ImageList = this.imageList1;
			this.toolBar2.Location = new System.Drawing.Point(0, 0);
			this.toolBar2.Name = "toolBar2";
			this.toolBar2.ShowToolTips = true;
			this.toolBar2.Size = new System.Drawing.Size(439, 28);
			this.toolBar2.TabIndex = 0;
			// 
			// btSummaryUp
			// 
			this.btSummaryUp.ImageIndex = 3;
			// 
			// btSummaryDown
			// 
			this.btSummaryDown.ImageIndex = 4;
			// 
			// toolBar3
			// 
			this.toolBar3.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.toolBarButton1,
																						this.toolBarButton2});
			this.toolBar3.DropDownArrows = true;
			this.toolBar3.ImageList = this.imageList1;
			this.toolBar3.Location = new System.Drawing.Point(0, 0);
			this.toolBar3.Name = "toolBar3";
			this.toolBar3.ShowToolTips = true;
			this.toolBar3.Size = new System.Drawing.Size(439, 28);
			this.toolBar3.TabIndex = 1;
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.ImageIndex = 3;
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.ImageIndex = 4;
			// 
			// dgDetails
			// 
			this.dgDetails.DataMember = "";
			this.dgDetails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgDetails.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgDetails.Location = new System.Drawing.Point(0, 28);
			this.dgDetails.Name = "dgDetails";
			this.dgDetails.Size = new System.Drawing.Size(439, 207);
			this.dgDetails.TabIndex = 2;
			// 
			// cklSummary
			// 
			this.cklSummary.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cklSummary.Location = new System.Drawing.Point(0, 28);
			this.cklSummary.Name = "cklSummary";
			this.cklSummary.Size = new System.Drawing.Size(439, 199);
			this.cklSummary.TabIndex = 1;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(24, 8);
			this.label9.Name = "label9";
			this.label9.TabIndex = 0;
			this.label9.Text = "Issue type";
			// 
			// cbMachine
			// 
			this.cbMachine.Location = new System.Drawing.Point(136, 29);
			this.cbMachine.Name = "cbMachine";
			this.cbMachine.Size = new System.Drawing.Size(121, 21);
			this.cbMachine.TabIndex = 5;
			this.cbMachine.Text = ".";
			// 
			// btDeleteMachine
			// 
			this.btDeleteMachine.Location = new System.Drawing.Point(272, 28);
			this.btDeleteMachine.Name = "btDeleteMachine";
			this.btDeleteMachine.TabIndex = 6;
			this.btDeleteMachine.Text = "Delete";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1000, 638);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.paClient);
			this.Controls.Add(this.tcVersion);
			this.Controls.Add(this.splitter2);
			this.Controls.Add(this.paLeft);
			this.Controls.Add(this.paBottom);
			this.Controls.Add(this.paTop);
			this.Name = "Form1";
			this.Text = "PSSDIAG Configuration Creator";
			this.paTop.ResumeLayout(false);
			this.paTopLeft.ResumeLayout(false);
			this.paLeft.ResumeLayout(false);
			this.paLeftTop.ResumeLayout(false);
			this.paBottom.ResumeLayout(false);
			this.tcVersion.ResumeLayout(false);
			this.paClient.ResumeLayout(false);
			this.paClientLeft.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.rgAuth.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.paPMTop.ResumeLayout(false);
			this.paClientRightTop.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.paInstanceTop.ResumeLayout(false);
			this.paInstanceClient.ResumeLayout(false);
			this.rgCustom.ResumeLayout(false);
			this.tcCustom.ResumeLayout(false);
			this.tpSummary.ResumeLayout(false);
			this.tpDetails.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgDetails)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
	}
}
