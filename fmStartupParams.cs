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
using System.Xml;
using System.Diagnostics;
using Microsoft.Win32;

namespace PssdiagConfig
{
	/// <summary>
	/// Summary description for fmStartupParams.
	/// </summary>
	public class fmStartupParams : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox edOutputFolder;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox ckEndTimeRelative;
		private System.Windows.Forms.DateTimePicker dtEndTime;
		private System.Windows.Forms.DateTimePicker dtEndDate;
		private System.Windows.Forms.CheckBox ckStartTimeRelative;
		private System.Windows.Forms.DateTimePicker dtStartTime;
		private System.Windows.Forms.DateTimePicker dtStartDate;
		private System.Windows.Forms.CheckBox ckSnapshot;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton rbCompressNone;
		private System.Windows.Forms.RadioButton rbCompressNTFS;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.RadioButton rbGeneric;
		private System.Windows.Forms.RadioButton rbSS;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.CheckBox ckStart;
		private System.Windows.Forms.CheckBox ckEnd;
		private System.Windows.Forms.RadioButton rbRename;
		private System.Windows.Forms.RadioButton rbOverwrite;
		private System.Windows.Forms.RadioButton rbClear;
		private System.Windows.Forms.RadioButton rbCompressZIP;
		private System.Windows.Forms.CheckBox ckContinuous;
		private System.Windows.Forms.Button btBrowse;
		private System.Windows.Forms.FolderBrowserDialog fb_OutputPath;
		private System.Windows.Forms.CheckBox ckIncludeStartDate;
		private System.Windows.Forms.CheckBox ckIncludeEndDate;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public fmStartupParams()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		bool bProfilerEnabled=true;
		string strTargetMachine="";

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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btBrowse = new System.Windows.Forms.Button();
			this.rbClear = new System.Windows.Forms.RadioButton();
			this.rbRename = new System.Windows.Forms.RadioButton();
			this.rbOverwrite = new System.Windows.Forms.RadioButton();
			this.edOutputFolder = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.ckIncludeStartDate = new System.Windows.Forms.CheckBox();
			this.ckIncludeEndDate = new System.Windows.Forms.CheckBox();
			this.ckEnd = new System.Windows.Forms.CheckBox();
			this.ckStart = new System.Windows.Forms.CheckBox();
			this.ckSnapshot = new System.Windows.Forms.CheckBox();
			this.ckContinuous = new System.Windows.Forms.CheckBox();
			this.ckEndTimeRelative = new System.Windows.Forms.CheckBox();
			this.dtEndTime = new System.Windows.Forms.DateTimePicker();
			this.dtEndDate = new System.Windows.Forms.DateTimePicker();
			this.ckStartTimeRelative = new System.Windows.Forms.CheckBox();
			this.dtStartTime = new System.Windows.Forms.DateTimePicker();
			this.dtStartDate = new System.Windows.Forms.DateTimePicker();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.rbCompressZIP = new System.Windows.Forms.RadioButton();
			this.rbCompressNTFS = new System.Windows.Forms.RadioButton();
			this.rbCompressNone = new System.Windows.Forms.RadioButton();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.rbGeneric = new System.Windows.Forms.RadioButton();
			this.rbSS = new System.Windows.Forms.RadioButton();
			this.btOK = new System.Windows.Forms.Button();
			this.btCancel = new System.Windows.Forms.Button();
			this.fb_OutputPath = new System.Windows.Forms.FolderBrowserDialog();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btBrowse);
			this.groupBox1.Controls.Add(this.rbClear);
			this.groupBox1.Controls.Add(this.rbRename);
			this.groupBox1.Controls.Add(this.rbOverwrite);
			this.groupBox1.Controls.Add(this.edOutputFolder);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new System.Drawing.Point(16, 71);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(456, 88);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Output Folder";
			// 
			// btBrowse
			// 
			this.btBrowse.Location = new System.Drawing.Point(416, 22);
			this.btBrowse.Name = "btBrowse";
			this.btBrowse.Size = new System.Drawing.Size(26, 23);
			this.btBrowse.TabIndex = 2;
			this.btBrowse.Text = "...";
			this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
			// 
			// rbClear
			// 
			this.rbClear.Location = new System.Drawing.Point(16, 48);
			this.rbClear.Name = "rbClear";
			this.rbClear.TabIndex = 3;
			this.rbClear.Tag = "N0";
			this.rbClear.Text = "Clear at startup";
			this.rbClear.Visible = false;
			// 
			// rbRename
			// 
			this.rbRename.Location = new System.Drawing.Point(288, 48);
			this.rbRename.Name = "rbRename";
			this.rbRename.Size = new System.Drawing.Size(120, 24);
			this.rbRename.TabIndex = 5;
			this.rbRename.Tag = "N2";
			this.rbRename.Text = "Rename at startup";
			// 
			// rbOverwrite
			// 
			this.rbOverwrite.Checked = true;
			this.rbOverwrite.Location = new System.Drawing.Point(176, 48);
			this.rbOverwrite.Name = "rbOverwrite";
			this.rbOverwrite.Size = new System.Drawing.Size(72, 24);
			this.rbOverwrite.TabIndex = 4;
			this.rbOverwrite.TabStop = true;
			this.rbOverwrite.Tag = "N1";
			this.rbOverwrite.Text = "Overwrite";
			// 
			// edOutputFolder
			// 
			this.edOutputFolder.Location = new System.Drawing.Point(48, 22);
			this.edOutputFolder.Name = "edOutputFolder";
			this.edOutputFolder.Size = new System.Drawing.Size(368, 20);
			this.edOutputFolder.TabIndex = 1;
			this.edOutputFolder.Text = "";
			this.edOutputFolder.Validating += new System.ComponentModel.CancelEventHandler(this.edOutputFolder_Validating);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 24);
			this.label4.Name = "label4";
			this.label4.TabIndex = 0;
			this.label4.Text = "Path";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.ckIncludeStartDate);
			this.groupBox2.Controls.Add(this.ckIncludeEndDate);
			this.groupBox2.Controls.Add(this.ckEnd);
			this.groupBox2.Controls.Add(this.ckStart);
			this.groupBox2.Controls.Add(this.ckSnapshot);
			this.groupBox2.Controls.Add(this.ckContinuous);
			this.groupBox2.Controls.Add(this.ckEndTimeRelative);
			this.groupBox2.Controls.Add(this.dtEndTime);
			this.groupBox2.Controls.Add(this.dtEndDate);
			this.groupBox2.Controls.Add(this.ckStartTimeRelative);
			this.groupBox2.Controls.Add(this.dtStartTime);
			this.groupBox2.Controls.Add(this.dtStartDate);
			this.groupBox2.Location = new System.Drawing.Point(16, 235);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(456, 261);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Scheduling";
			// 
			// ckIncludeStartDate
			// 
			this.ckIncludeStartDate.Enabled = false;
			this.ckIncludeStartDate.Location = new System.Drawing.Point(133, 18);
			this.ckIncludeStartDate.Name = "ckIncludeStartDate";
			this.ckIncludeStartDate.Size = new System.Drawing.Size(104, 16);
			this.ckIncludeStartDate.TabIndex = 1;
			this.ckIncludeStartDate.Text = "Include date";
			this.ckIncludeStartDate.CheckedChanged += new System.EventHandler(this.ckIncludeStartDate_CheckedChanged);
			// 
			// ckIncludeEndDate
			// 
			this.ckIncludeEndDate.Enabled = false;
			this.ckIncludeEndDate.Location = new System.Drawing.Point(133, 72);
			this.ckIncludeEndDate.Name = "ckIncludeEndDate";
			this.ckIncludeEndDate.Size = new System.Drawing.Size(104, 16);
			this.ckIncludeEndDate.TabIndex = 6;
			this.ckIncludeEndDate.Text = "Include date";
			this.ckIncludeEndDate.CheckedChanged += new System.EventHandler(this.ckIncludeEndDate_CheckedChanged);
			// 
			// ckEnd
			// 
			this.ckEnd.Location = new System.Drawing.Point(16, 88);
			this.ckEnd.Name = "ckEnd";
			this.ckEnd.TabIndex = 5;
			this.ckEnd.Tag = "E";
			this.ckEnd.Text = "End Date/Time";
			this.ckEnd.CheckedChanged += new System.EventHandler(this.ckEnd_CheckedChanged);
			// 
			// ckStart
			// 
			this.ckStart.Location = new System.Drawing.Point(16, 35);
			this.ckStart.Name = "ckStart";
			this.ckStart.TabIndex = 0;
			this.ckStart.Tag = "B";
			this.ckStart.Text = "Start Date/Time";
			this.ckStart.CheckedChanged += new System.EventHandler(this.ckStartTime_CheckedChanged);
			// 
			// ckSnapshot
			// 
			this.ckSnapshot.Location = new System.Drawing.Point(16, 224);
			this.ckSnapshot.Name = "ckSnapshot";
			this.ckSnapshot.Size = new System.Drawing.Size(168, 24);
			this.ckSnapshot.TabIndex = 11;
			this.ckSnapshot.Tag = "X";
			this.ckSnapshot.Text = "Collect snapshot and exit";
			this.ckSnapshot.CheckedChanged += new System.EventHandler(this.ckSnapshot_CheckedChanged);
			// 
			// ckContinuous
			// 
			this.ckContinuous.Location = new System.Drawing.Point(16, 200);
			this.ckContinuous.Name = "ckContinuous";
			this.ckContinuous.Size = new System.Drawing.Size(120, 24);
			this.ckContinuous.TabIndex = 10;
			this.ckContinuous.Tag = "L";
			this.ckContinuous.Text = "Run Continuously";
			this.ckContinuous.CheckedChanged += new System.EventHandler(this.ckContinuous_CheckedChanged);
			// 
			// ckEndTimeRelative
			// 
			this.ckEndTimeRelative.Enabled = false;
			this.ckEndTimeRelative.Location = new System.Drawing.Point(341, 88);
			this.ckEndTimeRelative.Name = "ckEndTimeRelative";
			this.ckEndTimeRelative.Size = new System.Drawing.Size(68, 24);
			this.ckEndTimeRelative.TabIndex = 9;
			this.ckEndTimeRelative.Text = "Relative";
			this.ckEndTimeRelative.CheckedChanged += new System.EventHandler(this.ckEndTimeRelative_CheckedChanged);
			// 
			// dtEndTime
			// 
			this.dtEndTime.CustomFormat = "HH:mm:ss";
			this.dtEndTime.Enabled = false;
			this.dtEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dtEndTime.Location = new System.Drawing.Point(237, 90);
			this.dtEndTime.Name = "dtEndTime";
			this.dtEndTime.ShowUpDown = true;
			this.dtEndTime.Size = new System.Drawing.Size(88, 20);
			this.dtEndTime.TabIndex = 8;
			this.dtEndTime.Tag = "";
			// 
			// dtEndDate
			// 
			this.dtEndDate.Enabled = false;
			this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtEndDate.Location = new System.Drawing.Point(133, 90);
			this.dtEndDate.Name = "dtEndDate";
			this.dtEndDate.Size = new System.Drawing.Size(88, 20);
			this.dtEndDate.TabIndex = 7;
			// 
			// ckStartTimeRelative
			// 
			this.ckStartTimeRelative.Enabled = false;
			this.ckStartTimeRelative.Location = new System.Drawing.Point(342, 35);
			this.ckStartTimeRelative.Name = "ckStartTimeRelative";
			this.ckStartTimeRelative.Size = new System.Drawing.Size(68, 24);
			this.ckStartTimeRelative.TabIndex = 4;
			this.ckStartTimeRelative.Text = "Relative";
			this.ckStartTimeRelative.CheckedChanged += new System.EventHandler(this.ckStartTimeRelative_CheckedChanged);
			// 
			// dtStartTime
			// 
			this.dtStartTime.CustomFormat = "HH:mm:ss";
			this.dtStartTime.Enabled = false;
			this.dtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dtStartTime.Location = new System.Drawing.Point(238, 37);
			this.dtStartTime.Name = "dtStartTime";
			this.dtStartTime.ShowUpDown = true;
			this.dtStartTime.Size = new System.Drawing.Size(88, 20);
			this.dtStartTime.TabIndex = 3;
			this.dtStartTime.Tag = "";
			// 
			// dtStartDate
			// 
			this.dtStartDate.Enabled = false;
			this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtStartDate.Location = new System.Drawing.Point(133, 37);
			this.dtStartDate.Name = "dtStartDate";
			this.dtStartDate.Size = new System.Drawing.Size(88, 20);
			this.dtStartDate.TabIndex = 2;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.rbCompressZIP);
			this.groupBox3.Controls.Add(this.rbCompressNTFS);
			this.groupBox3.Controls.Add(this.rbCompressNone);
			this.groupBox3.Location = new System.Drawing.Point(16, 173);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(456, 48);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Compression";
			// 
			// rbCompressZIP
			// 
			this.rbCompressZIP.Location = new System.Drawing.Point(288, 16);
			this.rbCompressZIP.Name = "rbCompressZIP";
			this.rbCompressZIP.TabIndex = 2;
			this.rbCompressZIP.Tag = "C2";
			this.rbCompressZIP.Text = "ZIP";
			// 
			// rbCompressNTFS
			// 
			this.rbCompressNTFS.Location = new System.Drawing.Point(176, 16);
			this.rbCompressNTFS.Name = "rbCompressNTFS";
			this.rbCompressNTFS.TabIndex = 1;
			this.rbCompressNTFS.Tag = "C1";
			this.rbCompressNTFS.Text = "NTFS";
			// 
			// rbCompressNone
			// 
			this.rbCompressNone.Checked = true;
			this.rbCompressNone.Location = new System.Drawing.Point(16, 16);
			this.rbCompressNone.Name = "rbCompressNone";
			this.rbCompressNone.TabIndex = 0;
			this.rbCompressNone.TabStop = true;
			this.rbCompressNone.Tag = "C0";
			this.rbCompressNone.Text = "None";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.rbGeneric);
			this.groupBox4.Controls.Add(this.rbSS);
			this.groupBox4.Location = new System.Drawing.Point(16, 9);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(456, 48);
			this.groupBox4.TabIndex = 0;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Mode";
			// 
			// rbGeneric
			// 
			this.rbGeneric.Location = new System.Drawing.Point(176, 16);
			this.rbGeneric.Name = "rbGeneric";
			this.rbGeneric.TabIndex = 1;
			this.rbGeneric.Tag = "G";
			this.rbGeneric.Text = "Generic";
			// 
			// rbSS
			// 
			this.rbSS.Checked = true;
			this.rbSS.Location = new System.Drawing.Point(16, 16);
			this.rbSS.Name = "rbSS";
			this.rbSS.TabIndex = 0;
			this.rbSS.TabStop = true;
			this.rbSS.Text = "SQL Server";
			// 
			// btOK
			// 
			this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btOK.Location = new System.Drawing.Point(304, 512);
			this.btOK.Name = "btOK";
			this.btOK.TabIndex = 5;
			this.btOK.Text = "OK";
			// 
			// btCancel
			// 
			this.btCancel.CausesValidation = false;
			this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancel.Location = new System.Drawing.Point(392, 512);
			this.btCancel.Name = "btCancel";
			this.btCancel.TabIndex = 6;
			this.btCancel.Text = "Cancel";
			// 
			// fb_OutputPath
			// 
			this.fb_OutputPath.Description = "Output folder path";
			// 
			// fmStartupParams
			// 
			this.AcceptButton = this.btOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btCancel;
			this.ClientSize = new System.Drawing.Size(488, 550);
			this.Controls.Add(this.btCancel);
			this.Controls.Add(this.btOK);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "fmStartupParams";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Startup Parameters";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void ckStartRelative_CheckedChanged(object sender, System.EventArgs e)
		{
			dtStartDate.Enabled=(!ckStartTimeRelative.Checked);
		}

		private void ckEndRelative_CheckedChanged(object sender, System.EventArgs e)
		{
			dtEndDate.Enabled=(!ckEndTimeRelative.Checked);
		}

		private void EnableDisableStartDate()
		{
			dtStartDate.Enabled=((ckIncludeStartDate.Checked) && (ckStart.Checked) && (!ckStartTimeRelative.Checked));
		}

		private void EnableDisableEndDate()
		{
			dtEndDate.Enabled=((ckIncludeEndDate.Checked) && (ckEnd.Checked) && (!ckEndTimeRelative.Checked));
		}

		private void EnableDisableStart()
		{
			ckIncludeStartDate.Enabled=(ckStart.Checked);
			EnableDisableStartDate();
			dtStartTime.Enabled=(ckStart.Checked);
			ckStartTimeRelative.Enabled=(ckStart.Checked);
		}

		private void EnableDisableEnd()
		{
			ckIncludeEndDate.Enabled=(ckEnd.Checked);
			EnableDisableEndDate();
			dtEndTime.Enabled=(ckEnd.Checked);
			ckEndTimeRelative.Enabled=(ckEnd.Checked);
		}

		private void ckSnapshot_CheckedChanged(object sender, System.EventArgs e)
		{
			ckEnd.Enabled=(!ckSnapshot.Checked);
			EnableDisableEnd();
		}

		private void ckStartTime_CheckedChanged(object sender, System.EventArgs e)
		{
			EnableDisableStart();		
		}

		private void ckEnd_CheckedChanged(object sender, System.EventArgs e)
		{
			EnableDisableEnd();
		}

		public static DialogResult GetStartupParams(string strMachineName, string strAppName, bool ProfilerEnabled)
		{
			
			DialogResult result=DialogResult.Cancel;
			fmStartupParams fmSUP = new fmStartupParams();
			fmSUP.bProfilerEnabled=ProfilerEnabled;
			string DEFAULT_PARAMS =	"<?xml version='1.0' ?>" +
									"<Params genericmode=\"false\"" +
									" outputpath=\"\"" +
									" foldermgmt=\"overwrite\"" +
									" compression=\"none\"" +
									" usestart=\"false\"" +
									" usestartdate=\"false\"" +
									" startdate=\""+fmSUP.dtStartDate.Value+"\"" +
									" starttime=\""+fmSUP.dtStartDate.Value+"\"" +
									" startrelative=\"false\"" +
									" useend=\"false\"" +
									" useenddate=\"false\"" +
									" enddate=\""+fmSUP.dtEndDate.Value+"\"" +
									" endtime=\""+fmSUP.dtEndDate.Value+"\"" +
									" endrelative=\"false\"" +
									" snapshot=\"false\"" +
									" usesqldiag=\"false\"" +
									" runcontinuous=\"false\" />";
			string strParams;
			fmSUP.strTargetMachine=strMachineName=="."?"":strMachineName;

			XmlDocument xmlParamDoc = new XmlDocument();
			RegistryKey rk=RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine,fmSUP.strTargetMachine);
			try
			{
				RegistryKey subkey=rk.OpenSubKey("Software\\Microsoft\\SQLDiagEx\\"+strAppName,true);
				if (null!=subkey)
					rk=subkey;
				else //If the key doesn't exist, try to create it
					rk=rk.CreateSubKey("Software\\Microsoft\\SQLDiagEx\\"+strAppName);
						
				try
				{
					xmlParamDoc.LoadXml((string)rk.GetValue("XMLStartupParameters"));
				}
				catch (Exception ex)
				{
					//Eat the exception -- reg value may not be there
					Debug.WriteLine(ex.Message);
					xmlParamDoc.LoadXml(DEFAULT_PARAMS);
				}

				fmSUP.rbGeneric.Checked=Convert.ToBoolean(xmlParamDoc["Params"].Attributes["genericmode"].Value);
				fmSUP.edOutputFolder.Text=xmlParamDoc["Params"].Attributes["outputpath"].Value;
				fmSUP.rbClear.Checked=("clear"==xmlParamDoc["Params"].Attributes["foldermgmt"].Value);
				fmSUP.rbOverwrite.Checked=("overwrite"==xmlParamDoc["Params"].Attributes["foldermgmt"].Value);
				fmSUP.rbRename.Checked=("rename"==xmlParamDoc["Params"].Attributes["foldermgmt"].Value);

				fmSUP.rbCompressNone.Checked=("none"==xmlParamDoc["Params"].Attributes["compression"].Value);
				fmSUP.rbCompressNTFS.Checked=("ntfs"==xmlParamDoc["Params"].Attributes["compression"].Value);
				fmSUP.rbCompressZIP.Checked=("zip"==xmlParamDoc["Params"].Attributes["compression"].Value);

				fmSUP.ckStart.Checked=Convert.ToBoolean(xmlParamDoc["Params"].Attributes["usestart"].Value);
				if (fmSUP.ckStart.Checked) 
				{
					fmSUP.ckIncludeStartDate.Checked=Convert.ToBoolean(xmlParamDoc["Params"].Attributes["usestartdate"].Value);
					fmSUP.dtStartDate.Value=Convert.ToDateTime(xmlParamDoc["Params"].Attributes["startdate"].Value);
					fmSUP.dtStartTime.Value=Convert.ToDateTime(xmlParamDoc["Params"].Attributes["starttime"].Value);
					fmSUP.ckStartTimeRelative.Checked=Convert.ToBoolean(xmlParamDoc["Params"].Attributes["startrelative"].Value);
				}

				fmSUP.ckEnd.Checked=Convert.ToBoolean(xmlParamDoc["Params"].Attributes["useend"].Value);
				if (fmSUP.ckEnd.Checked) 
				{
					fmSUP.ckIncludeEndDate.Checked=Convert.ToBoolean(xmlParamDoc["Params"].Attributes["useenddate"].Value);
					fmSUP.dtEndDate.Value=Convert.ToDateTime(xmlParamDoc["Params"].Attributes["enddate"].Value);
					fmSUP.dtEndTime.Value=Convert.ToDateTime(xmlParamDoc["Params"].Attributes["endtime"].Value);
					fmSUP.ckEndTimeRelative.Checked=Convert.ToBoolean(xmlParamDoc["Params"].Attributes["endrelative"].Value);
				}

				fmSUP.ckSnapshot.Checked=Convert.ToBoolean(xmlParamDoc["Params"].Attributes["snapshot"].Value);
				fmSUP.ckContinuous.Checked=Convert.ToBoolean(xmlParamDoc["Params"].Attributes["runcontinuous"].Value);
//				fmSUP.ckSqldiag.Checked=Convert.ToBoolean(xmlParamDoc["Params"].Attributes["usesqldiag"].Value);

				result=fmSUP.ShowDialog();

				if (DialogResult.OK==result) 
				{
					xmlParamDoc["Params"].Attributes["genericmode"].Value=Convert.ToString(fmSUP.rbGeneric.Checked);
					xmlParamDoc["Params"].Attributes["outputpath"].Value=fmSUP.edOutputFolder.Text;
					if (fmSUP.rbClear.Checked)
						xmlParamDoc["Params"].Attributes["foldermgmt"].Value="clear";
					else if (fmSUP.rbOverwrite.Checked)
						xmlParamDoc["Params"].Attributes["foldermgmt"].Value="overwrite";
					else if (fmSUP.rbRename.Checked)
						xmlParamDoc["Params"].Attributes["foldermgmt"].Value="rename";

					if (fmSUP.rbCompressNone.Checked)
						xmlParamDoc["Params"].Attributes["compression"].Value="none";
					else if (fmSUP.rbCompressNTFS.Checked)
						xmlParamDoc["Params"].Attributes["compression"].Value="ntfs";
					else if (fmSUP.rbCompressZIP.Checked)
						xmlParamDoc["Params"].Attributes["compression"].Value="zip";

					xmlParamDoc["Params"].Attributes["usestart"].Value=Convert.ToString(fmSUP.ckStart.Checked);
					xmlParamDoc["Params"].Attributes["usestartdate"].Value=Convert.ToString(fmSUP.ckIncludeStartDate.Checked);
					xmlParamDoc["Params"].Attributes["startdate"].Value=Convert.ToString(fmSUP.dtStartDate.Value);
					xmlParamDoc["Params"].Attributes["starttime"].Value=Convert.ToString(fmSUP.dtStartTime.Value);
					xmlParamDoc["Params"].Attributes["startrelative"].Value=Convert.ToString(fmSUP.ckStartTimeRelative.Checked);

					xmlParamDoc["Params"].Attributes["useend"].Value=Convert.ToString(fmSUP.ckEnd.Checked);
					xmlParamDoc["Params"].Attributes["useenddate"].Value=Convert.ToString(fmSUP.ckIncludeEndDate.Checked);
					xmlParamDoc["Params"].Attributes["enddate"].Value=Convert.ToString(fmSUP.dtEndDate.Value);
					xmlParamDoc["Params"].Attributes["endtime"].Value=Convert.ToString(fmSUP.dtEndTime.Value);
					xmlParamDoc["Params"].Attributes["endrelative"].Value=Convert.ToString(fmSUP.ckEndTimeRelative.Checked);

					xmlParamDoc["Params"].Attributes["snapshot"].Value=Convert.ToString(fmSUP.ckSnapshot.Checked);
					xmlParamDoc["Params"].Attributes["runcontinuous"].Value=Convert.ToString(fmSUP.ckContinuous.Checked);
//					xmlParamDoc["Params"].Attributes["usesqldiag"].Value=Convert.ToString(fmSUP.ckSqldiag.Checked);

					rk.SetValue("XMLStartupParameters",xmlParamDoc.InnerXml);

					strParams="";
					if (fmSUP.rbGeneric.Checked) strParams+=" /G";
					if (0!=fmSUP.edOutputFolder.Text.Length) 
					{
						if (-1==fmSUP.edOutputFolder.Text.IndexOf(" "))
							strParams+=" /O"+fmSUP.edOutputFolder.Text;
						else
							strParams+=" /O \""+fmSUP.edOutputFolder.Text+"\"";
					}
					if (fmSUP.rbClear.Checked)
						strParams+=" /N0";
					else if (fmSUP.rbOverwrite.Checked)
						strParams+=" /N1";
					else if (fmSUP.rbRename.Checked)
						strParams+=" /N2";

					if (fmSUP.rbCompressNone.Checked)
						strParams+=" /C0";
					else if (fmSUP.rbCompressNTFS.Checked)
						strParams+=" /C1";
					else if (fmSUP.rbCompressZIP.Checked)
						strParams+=" /C2";

					if (fmSUP.ckStart.Checked) 
					{
						if (fmSUP.ckStartTimeRelative.Checked) 
						{
							strParams+=" /B+"+fmSUP.dtStartTime.Value.ToString("HH:mm:ss");
						}
						else 
						{
							if (fmSUP.ckIncludeStartDate.Checked)
								strParams+=" /B"+fmSUP.dtStartDate.Value.ToString("yyyyMMdd")+"_"+fmSUP.dtStartTime.Value.ToString("HH:mm:ss");
							else
								strParams+=" /B"+fmSUP.dtStartTime.Value.ToString("HH:mm:ss");
						}
					}
					if (fmSUP.ckEnd.Checked) 
					{
						if (fmSUP.ckEndTimeRelative.Checked) 
						{
							strParams+=" /E+"+fmSUP.dtEndTime.Value.ToString("HH:mm:ss");
						}
						else 
						{
							if (fmSUP.ckIncludeEndDate.Checked)
								strParams+=" /E"+fmSUP.dtEndDate.Value.ToString("yyyyMMdd")+"_"+fmSUP.dtEndTime.Value.ToString("HH:mm:ss");
							else
								strParams+=" /E"+fmSUP.dtEndTime.Value.ToString("HH:mm:ss");
						}
					}

					if (fmSUP.ckSnapshot.Checked) strParams+=" /X";
					if (fmSUP.ckContinuous.Checked) strParams+=" /L";
					strParams+=" /I REG:";  //Signal to use registry for config info
//					if (fmSUP.ckSqldiag.Checked) strParams+=" /D";

					rk.SetValue("StartupParameters",strParams);
				}

			}
			catch(Exception ex)
			{
				MessageBox.Show("Error getting/setting service startup parameters: "+ex.Message);
			}
			return result;
		}

		private void ckStartTimeRelative_CheckedChanged(object sender, System.EventArgs e)
		{
			EnableDisableStartDate();
			if (ckStartTimeRelative.Checked) 
			{
				dtStartTime.Format=DateTimePickerFormat.Custom;
				ckIncludeStartDate.Checked=false;
			}
			else 
			{
				dtStartTime.Format=DateTimePickerFormat.Time;
			}
		}

		private void ckEndTimeRelative_CheckedChanged(object sender, System.EventArgs e)
		{
			EnableDisableEndDate();
			if (ckEndTimeRelative.Checked) 
			{
				dtEndTime.Format=DateTimePickerFormat.Custom;
				ckIncludeEndDate.Checked=false;
			}
			else 
			{
				dtEndTime.Format=DateTimePickerFormat.Time;
			}
		}

		private void edOutputFolder_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if ((bProfilerEnabled) && (-1!=edOutputFolder.Text.Trim().IndexOf("\\\\")))
			{
				if (DialogResult.Yes!=MessageBox.Show("You should not use UNC paths when collecting Profiler traces.  Are you sure you want to do this?","Warning",MessageBoxButtons.YesNoCancel))
					e.Cancel=true;
			}
		}

		private void btBrowse_Click(object sender, System.EventArgs e)
		{
			if ((strTargetMachine=="") || (strTargetMachine.ToUpper()==System.Environment.MachineName.ToUpper())) 
			{
				if (DialogResult.OK==fb_OutputPath.ShowDialog())
					edOutputFolder.Text=fb_OutputPath.SelectedPath;
			}
			else
				MessageBox.Show("You are currently connected to a remote machine, so folder browsing is disabled.  Please specify a non-UNC (local) path on the remote machine for the output folder.");
			
		}

		private void ckContinuous_CheckedChanged(object sender, System.EventArgs e)
		{
			if (ckContinuous.Checked) 
			{
				ckIncludeStartDate.Checked=false;
				ckIncludeEndDate.Checked=false;
			}
		}

		private void ckIncludeStartDate_CheckedChanged(object sender, System.EventArgs e)
		{
			dtStartDate.Enabled=(ckIncludeStartDate.Checked);
			if (ckIncludeStartDate.Checked)
				ckStartTimeRelative.Checked=false;
		}

		private void ckIncludeEndDate_CheckedChanged(object sender, System.EventArgs e)
		{
			dtEndDate.Enabled=(ckIncludeEndDate.Checked);
			if (ckIncludeEndDate.Checked)
				ckEndTimeRelative.Checked=false;
		}


	}
}
