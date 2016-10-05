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
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using System.Data;
using System.Diagnostics;

namespace PssdiagConfig
{
	/// <summary>
	/// Summary description for fmParameters.
	/// </summary>
	public class fmParameters : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid dgParams;
		private System.Data.DataSet dsParams;
		private System.Data.DataTable taParams;
		private System.Data.DataColumn coPrompt;
		private System.Data.DataColumn coName;
		private System.Data.DataColumn coType;
		private System.Data.DataColumn coValue;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dcolPrompt;
		private System.Windows.Forms.DataGridTextBoxColumn dcolName;
		private System.Windows.Forms.DataGridTextBoxColumn dcolType;
		private System.Windows.Forms.DataGridTextBoxColumn dcolValue;
		private System.Windows.Forms.Panel paBottom;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Button btCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public fmParameters()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public static bool GetParameters(ArrayList Vars, ref System.Collections.Hashtable ht)
		{

			//If no variable entries, bail
			if (0==Vars.Count)
				return true;

			fmParameters fmP = new fmParameters();

			foreach (CVariable var in Vars) 
			{
				if (null==fmP.taParams.Rows.Find(var.m_Name)) 
				{
					DataRow row = fmP.taParams.NewRow();
					row["Prompt"] = var.m_Prompt;
					row["Type"] = var.m_Type;
					row["Name"] = var.m_Name;
					row["Value"] = var.m_Default;
					fmP.taParams.Rows.Add(row);
				}
			}

			if (DialogResult.OK==fmP.ShowDialog()) 
			{
				fmP.taParams.AcceptChanges();
				ht = new System.Collections.Hashtable();
				foreach (DataRow row in fmP.taParams.Rows) 
				{
					ht.Add(row["Name"],row["Value"]);
				}
				return true;
			}
			else 
				return false;
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
			this.dgParams = new System.Windows.Forms.DataGrid();
			this.dsParams = new System.Data.DataSet();
			this.taParams = new System.Data.DataTable();
			this.coPrompt = new System.Data.DataColumn();
			this.coName = new System.Data.DataColumn();
			this.coType = new System.Data.DataColumn();
			this.coValue = new System.Data.DataColumn();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dcolPrompt = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dcolName = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dcolType = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dcolValue = new System.Windows.Forms.DataGridTextBoxColumn();
			this.paBottom = new System.Windows.Forms.Panel();
			this.btCancel = new System.Windows.Forms.Button();
			this.btOK = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgParams)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsParams)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.taParams)).BeginInit();
			this.paBottom.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgParams
			// 
			this.dgParams.DataMember = "Params";
			this.dgParams.DataSource = this.dsParams;
			this.dgParams.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgParams.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgParams.Location = new System.Drawing.Point(0, 0);
			this.dgParams.Name = "dgParams";
			this.dgParams.Size = new System.Drawing.Size(648, 526);
			this.dgParams.TabIndex = 0;
			this.dgParams.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								 this.dataGridTableStyle1});
			// 
			// dsParams
			// 
			this.dsParams.DataSetName = "NewDataSet";
			this.dsParams.Locale = new System.Globalization.CultureInfo("en-US");
			this.dsParams.Tables.AddRange(new System.Data.DataTable[] {
																		  this.taParams});
			// 
			// taParams
			// 
			this.taParams.Columns.AddRange(new System.Data.DataColumn[] {
																			this.coPrompt,
																			this.coName,
																			this.coType,
																			this.coValue});
			this.taParams.Constraints.AddRange(new System.Data.Constraint[] {
																				new System.Data.UniqueConstraint("Constraint1", new string[] {
																																				 "Name"}, true)});
			this.taParams.PrimaryKey = new System.Data.DataColumn[] {
																		this.coName};
			this.taParams.TableName = "Params";
			// 
			// coPrompt
			// 
			this.coPrompt.Caption = "Prompt";
			this.coPrompt.ColumnMapping = System.Data.MappingType.Attribute;
			this.coPrompt.ColumnName = "Prompt";
			this.coPrompt.DefaultValue = "";
			// 
			// coName
			// 
			this.coName.AllowDBNull = false;
			this.coName.Caption = "Name";
			this.coName.ColumnMapping = System.Data.MappingType.Attribute;
			this.coName.ColumnName = "Name";
			// 
			// coType
			// 
			this.coType.Caption = "Type";
			this.coType.ColumnMapping = System.Data.MappingType.Attribute;
			this.coType.ColumnName = "Type";
			this.coType.DefaultValue = "string";
			// 
			// coValue
			// 
			this.coValue.AllowDBNull = false;
			this.coValue.Caption = "Value";
			this.coValue.ColumnMapping = System.Data.MappingType.Attribute;
			this.coValue.ColumnName = "Value";
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dgParams;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dcolPrompt,
																												  this.dcolName,
																												  this.dcolType,
																												  this.dcolValue});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Params";
			// 
			// dcolPrompt
			// 
			this.dcolPrompt.Format = "";
			this.dcolPrompt.FormatInfo = null;
			this.dcolPrompt.HeaderText = "Prompt";
			this.dcolPrompt.MappingName = "Prompt";
			this.dcolPrompt.ReadOnly = true;
			this.dcolPrompt.Width = 300;
			// 
			// dcolName
			// 
			this.dcolName.Format = "";
			this.dcolName.FormatInfo = null;
			this.dcolName.HeaderText = "Name";
			this.dcolName.MappingName = "Name";
			this.dcolName.ReadOnly = true;
			this.dcolName.Width = 75;
			// 
			// dcolType
			// 
			this.dcolType.Format = "";
			this.dcolType.FormatInfo = null;
			this.dcolType.HeaderText = "Type";
			this.dcolType.MappingName = "Type";
			this.dcolType.ReadOnly = true;
			this.dcolType.Width = 75;
			// 
			// dcolValue
			// 
			this.dcolValue.Format = "";
			this.dcolValue.FormatInfo = null;
			this.dcolValue.HeaderText = "Value";
			this.dcolValue.MappingName = "Value";
			this.dcolValue.Width = 150;
			// 
			// paBottom
			// 
			this.paBottom.Controls.Add(this.btCancel);
			this.paBottom.Controls.Add(this.btOK);
			this.paBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.paBottom.Location = new System.Drawing.Point(0, 486);
			this.paBottom.Name = "paBottom";
			this.paBottom.Size = new System.Drawing.Size(648, 40);
			this.paBottom.TabIndex = 1;
			// 
			// btCancel
			// 
			this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancel.Location = new System.Drawing.Point(560, 10);
			this.btCancel.Name = "btCancel";
			this.btCancel.TabIndex = 1;
			this.btCancel.Text = "Cancel";
			// 
			// btOK
			// 
			this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btOK.Location = new System.Drawing.Point(472, 10);
			this.btOK.Name = "btOK";
			this.btOK.TabIndex = 0;
			this.btOK.Text = "OK";
			// 
			// fmParameters
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(648, 526);
			this.Controls.Add(this.paBottom);
			this.Controls.Add(this.dgParams);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "fmParameters";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Variables";
			((System.ComponentModel.ISupportInitialize)(this.dgParams)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsParams)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.taParams)).EndInit();
			this.paBottom.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
	public class CVariable
	{
		public string m_Prompt;
		public string m_Name;
		public string m_Type;
		public string m_Default;
		public CVariable(string Prompt, string Name, string Type, string Default)
		{
			m_Prompt=Prompt;
			m_Name=Name;
			m_Type=Type;
			m_Default=Default;
		}
	}
}
