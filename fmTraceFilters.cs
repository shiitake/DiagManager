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
using PssdiagTraceFilterSchema.Namespace;
using System.Diagnostics;
using System.Data;

namespace PssdiagConfig
{
	/// <summary>
	/// Summary description for fmTraceFilters.
	/// </summary>
	public class fmTraceFilters : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel paBottom;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.ImageList imGlyphs;
		public System.Windows.Forms.DataGrid gdFilters;
		public PssdiagTraceFilterSchema.Namespace.Filters dsFilters;
		private System.ComponentModel.IContainer components;

		public fmTraceFilters()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			InitForm();
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

		private DataGridBoolColumn AddBoolColumn(string colName)
		{
			DataGridBoolColumn BoolColumnStyle = 
				new DataGridBoolColumn();
			BoolColumnStyle.MappingName = colName;
			BoolColumnStyle.HeaderText = char.ToUpper(colName[0])+colName.Substring(1);
			BoolColumnStyle.Width = 50;
			BoolColumnStyle.TrueValue = "true";
			BoolColumnStyle.FalseValue = "false";

			return BoolColumnStyle;

		}

		private DataGridTextBoxColumn AddTextColumn(string colName, string headerText)
		{
			DataGridTextBoxColumn TextColumnStyle = 
				new DataGridTextBoxColumn();
			TextColumnStyle.MappingName = colName;
			if (0==headerText.Length)
				TextColumnStyle.HeaderText = char.ToUpper(colName[0])+colName.Substring(1);
			else
				TextColumnStyle.HeaderText = headerText;
			TextColumnStyle.Width = 100;

			TextColumnStyle.NullText = string.Empty;

			return TextColumnStyle;

		}

		private ComboBoxPickerColumn AddColumnNameCombo()
		{

			ComboBoxPickerColumn combocol = 
				new ComboBoxPickerColumn();
			combocol.MappingName = "column";
			combocol.HeaderText = "Column";
			combocol.Width = 150;
			combocol.NullText = string.Empty;

			combocol._combobox.Items.Add("ApplicationName");
			combocol._combobox.Items.Add("ClientProcessID");
			combocol._combobox.Items.Add("CPU");
			combocol._combobox.Items.Add("DatabaseID");
			combocol._combobox.Items.Add("DatabaseName");	
			combocol._combobox.Items.Add("DBUserName");	
			combocol._combobox.Items.Add("Duration");	
			combocol._combobox.Items.Add("Error");	
			combocol._combobox.Items.Add("EventSubClass");
			combocol._combobox.Items.Add("HostName");
			combocol._combobox.Items.Add("IndexID");		
			combocol._combobox.Items.Add("IntegerData");
			combocol._combobox.Items.Add("LoginName");
			combocol._combobox.Items.Add("NTUserName");		
			combocol._combobox.Items.Add("ObjectID");	
			combocol._combobox.Items.Add("ObjectName");		
			combocol._combobox.Items.Add("Reads");	
			combocol._combobox.Items.Add("Severity");		
			combocol._combobox.Items.Add("SPID");	
			combocol._combobox.Items.Add("TextData");
			combocol._combobox.Items.Add("Writes");		

			combocol._combobox.SelectedIndex=0;

			return combocol;

		}

		private ComboBoxPickerColumn AddComparisonOperatorCombo()
		{
			ComboBoxPickerColumn ComboBoxPickerColumnStyle = 
				new ComboBoxPickerColumn();
			ComboBoxPickerColumnStyle.MappingName = "operator";
			ComboBoxPickerColumnStyle.HeaderText = "Comparison Operator";
			ComboBoxPickerColumnStyle.Width = 150;
			ComboBoxPickerColumnStyle.NullText = string.Empty;

			ComboBoxPickerColumnStyle._combobox.Items.Add("Equal");
			ComboBoxPickerColumnStyle._combobox.Items.Add("Not Equal");
			ComboBoxPickerColumnStyle._combobox.Items.Add("Greater Than");
			ComboBoxPickerColumnStyle._combobox.Items.Add("Less Than");
			ComboBoxPickerColumnStyle._combobox.Items.Add("Greater Than or Equal");
			ComboBoxPickerColumnStyle._combobox.Items.Add("Less Than or Equal");
			ComboBoxPickerColumnStyle._combobox.Items.Add("LIKE");
			ComboBoxPickerColumnStyle._combobox.Items.Add("NOT LIKE");

			ComboBoxPickerColumnStyle._combobox.SelectedIndex=0;

			return ComboBoxPickerColumnStyle;

		}

		private ComboBoxPickerColumn AddLogicalOperatorCombo()
		{
			ComboBoxPickerColumn ComboBoxPickerColumnStyle = 
				new ComboBoxPickerColumn();
			ComboBoxPickerColumnStyle.MappingName = "logicaloperator";
			ComboBoxPickerColumnStyle.HeaderText = "Logical Operator";
			ComboBoxPickerColumnStyle.Width = 100;
			ComboBoxPickerColumnStyle.NullText = string.Empty;

			ComboBoxPickerColumnStyle._combobox.Items.Add("And");
			ComboBoxPickerColumnStyle._combobox.Items.Add("Or");

			ComboBoxPickerColumnStyle._combobox.SelectedIndex=0;

			return ComboBoxPickerColumnStyle;

		}

/*
 * 

ApplicationName		10
ClientProcessID		9
CPU					18
DatabaseID			3
DatabaseName		35
DBUserName			40
Duration			13
Error				31
EventSubClass		21
HostName			8
IndexID				24
IntegerData			25
LoginName			11
NTUserName			6
ObjectID			22
ObjectName			34
Reads				16
Severity			20
SPID				12
TextData			1
Writes				17
 
*/


		public void InitForm()
		{
			dsFilters.Tables["Filter"].Columns["column"].DefaultValue="ApplicationName";
			dsFilters.Tables["Filter"].Columns["operator"].DefaultValue="Equal";
			dsFilters.Tables["Filter"].Columns["logicaloperator"].DefaultValue="And";

			gdFilters.TableStyles["Filter"].GridColumnStyles.Add(AddColumnNameCombo());
			gdFilters.TableStyles["Filter"].GridColumnStyles.Add(AddComparisonOperatorCombo());
			DataGridTextBoxColumn txtcol = AddTextColumn("filter","Filter");
			txtcol.Width=150;
			gdFilters.TableStyles["Filter"].GridColumnStyles.Add(txtcol);
			gdFilters.TableStyles["Filter"].GridColumnStyles.Add(AddLogicalOperatorCombo());
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(fmTraceFilters));
			this.paBottom = new System.Windows.Forms.Panel();
			this.btCancel = new System.Windows.Forms.Button();
			this.btOK = new System.Windows.Forms.Button();
			this.gdFilters = new System.Windows.Forms.DataGrid();
			this.dsFilters = new PssdiagTraceFilterSchema.Namespace.Filters();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.imGlyphs = new System.Windows.Forms.ImageList(this.components);
			this.paBottom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gdFilters)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsFilters)).BeginInit();
			this.SuspendLayout();
			// 
			// paBottom
			// 
			this.paBottom.Controls.Add(this.btCancel);
			this.paBottom.Controls.Add(this.btOK);
			this.paBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.paBottom.Location = new System.Drawing.Point(0, 438);
			this.paBottom.Name = "paBottom";
			this.paBottom.Size = new System.Drawing.Size(600, 40);
			this.paBottom.TabIndex = 0;
			// 
			// btCancel
			// 
			this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancel.Location = new System.Drawing.Point(512, 8);
			this.btCancel.Name = "btCancel";
			this.btCancel.TabIndex = 1;
			this.btCancel.Text = "Cancel";
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// btOK
			// 
			this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btOK.Location = new System.Drawing.Point(424, 8);
			this.btOK.Name = "btOK";
			this.btOK.TabIndex = 0;
			this.btOK.Text = "OK";
			this.btOK.Click += new System.EventHandler(this.btOK_Click);
			// 
			// gdFilters
			// 
			this.gdFilters.CaptionText = "Please enter up to 5 trace filters";
			this.gdFilters.DataMember = "";
			this.gdFilters.DataSource = this.dsFilters.Filter;
			this.gdFilters.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gdFilters.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gdFilters.Location = new System.Drawing.Point(0, 0);
			this.gdFilters.Name = "gdFilters";
			this.gdFilters.Size = new System.Drawing.Size(600, 438);
			this.gdFilters.TabIndex = 1;
			this.gdFilters.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			// 
			// dsFilters
			// 
			this.dsFilters.DataSetName = "Filters";
			this.dsFilters.EnforceConstraints = false;
			this.dsFilters.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.gdFilters;
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Filter";
			// 
			// imGlyphs
			// 
			this.imGlyphs.ImageSize = new System.Drawing.Size(16, 16);
			this.imGlyphs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imGlyphs.ImageStream")));
			this.imGlyphs.TransparentColor = System.Drawing.SystemColors.Window;
			// 
			// fmTraceFilters
			// 
			this.AcceptButton = this.btOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btCancel;
			this.ClientSize = new System.Drawing.Size(600, 478);
			this.Controls.Add(this.gdFilters);
			this.Controls.Add(this.paBottom);
			this.MinimizeBox = false;
			this.Name = "fmTraceFilters";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Trace Filters";
			this.paBottom.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gdFilters)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsFilters)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btOK_Click(object sender, System.EventArgs e)
		{
			dsFilters.AcceptChanges();
		}

		private void btCancel_Click(object sender, System.EventArgs e)
		{
			dsFilters.RejectChanges();
		}


	}

}
