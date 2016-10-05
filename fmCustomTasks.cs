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
using PssdiagCustomDiagSchema.Namespace;
using System.Diagnostics;
using System.Data;

namespace PssdiagConfig
{
	/// <summary>
	/// Summary description for fmCustomTasks.
	/// </summary>
	public class fmCustomTasks : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel paBottom;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Button btCancel;
		private PssdiagCustomDiagSchema.Namespace.CustomTasks dsCustomTasks;
		public System.Windows.Forms.DataGrid gdCustomTasks;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.ToolBarButton btUp;
		private System.Windows.Forms.ToolBarButton btDown;
		private System.Windows.Forms.ImageList imGlyphs;
		private System.Windows.Forms.ToolBar tbCustomTasks;
		private System.ComponentModel.IContainer components;

		public fmCustomTasks()
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

		private ComboBoxPickerColumn AddTypeCombo()
		{

			ComboBoxPickerColumn combocol = 
				new ComboBoxPickerColumn();
			combocol.MappingName = "type";
			combocol.HeaderText = "Type";
			combocol.Width = 100;
			combocol.NullText = string.Empty;

			combocol._combobox.Items.Add("Utility");
			combocol._combobox.Items.Add("TSQL_Command");
			combocol._combobox.Items.Add("TSQL_Script");
			combocol._combobox.Items.Add("VB_Script");
			combocol._combobox.Items.Add("Copy_File");
			combocol._combobox.Items.Add("Tail_File");
			combocol._combobox.Items.Add("Type_File");
			combocol._combobox.Items.Add("Reg_Query");
			combocol._combobox.Items.Add("Reg_Save");
			combocol._combobox.Items.Add("Group");

			combocol._combobox.SelectedIndex=0;

			return combocol;

		}

		private ComboBoxPickerColumn AddPointCombo()
		{
			ComboBoxPickerColumn ComboBoxPickerColumnStyle = 
				new ComboBoxPickerColumn();
			ComboBoxPickerColumnStyle.MappingName = "point";
			ComboBoxPickerColumnStyle.HeaderText = "Collection Point";
			ComboBoxPickerColumnStyle.Width = 100;
			ComboBoxPickerColumnStyle.NullText = string.Empty;

			ComboBoxPickerColumnStyle._combobox.Items.Add("Startup");
			ComboBoxPickerColumnStyle._combobox.Items.Add("Shutdown");

			ComboBoxPickerColumnStyle._combobox.SelectedIndex=0;

			return ComboBoxPickerColumnStyle;

		}

		private ComboBoxPickerColumn AddWaitCombo()
		{
			ComboBoxPickerColumn ComboBoxPickerColumnStyle = 
				new ComboBoxPickerColumn();
			ComboBoxPickerColumnStyle.MappingName = "wait";
			ComboBoxPickerColumnStyle.HeaderText = "Wait";
			ComboBoxPickerColumnStyle.Width = 100;
			ComboBoxPickerColumnStyle.NullText = string.Empty;

			ComboBoxPickerColumnStyle._combobox.Items.Add("No");
			ComboBoxPickerColumnStyle._combobox.Items.Add("Yes");
			ComboBoxPickerColumnStyle._combobox.Items.Add("OnlyOnShutdown");

			ComboBoxPickerColumnStyle._combobox.SelectedIndex=0;

			return ComboBoxPickerColumnStyle;
		}


		private DataGridTableStyle CreateTableStyle(fmCustomTasks fmTasks) 
		{

			DataGridTableStyle dst = new DataGridTableStyle();
			dst.MappingName = "CustomTask";

			dst.GridColumnStyles.Add(fmTasks.AddBoolColumn("enabled"));
			dst.GridColumnStyles.Add(fmTasks.AddTextColumn("taskname","Name"));

			//			dst.GridColumnStyles.Add(fmTasks.AddTextColumn("type",""));
			dst.GridColumnStyles.Add(fmTasks.AddTextColumn("point",""));
			dst.GridColumnStyles.Add(fmTasks.AddTextColumn("wait",""));


			dst.GridColumnStyles.Add(fmTasks.AddTypeCombo());
			//			dst.GridColumnStyles.Add(fmTasks.AddPointCombo());
			//			dst.GridColumnStyles.Add(fmTasks.AddWaitCombo());

			DataGridTextBoxColumn txtcol = fmTasks.AddTextColumn("cmd","Command");
			txtcol.Width = 400;
			dst.GridColumnStyles.Add(txtcol);

			return dst;

		}


		public static void GetTasks(string groupName)
		{
			string fName=Application.StartupPath+"\\CustomDiagnostics\\"+groupName+"\\CustomDiag.XML";
			fmCustomTasks fmTasks = new fmCustomTasks();
			fmTasks.Text="Custom Tasks in "+fName;
			fmTasks.dsCustomTasks.ReadXml(fName,XmlReadMode.InferSchema);
			fmTasks.dsCustomTasks.Tables["CustomTask"].Columns["groupname"].DefaultValue=groupName;
			fmTasks.dsCustomTasks.Tables["CustomTask"].Columns["enabled"].DefaultValue=true;
			fmTasks.dsCustomTasks.Tables["CustomTask"].Columns["type"].DefaultValue="Utility";
			fmTasks.dsCustomTasks.Tables["CustomTask"].Columns["point"].DefaultValue="Startup";
			fmTasks.dsCustomTasks.Tables["CustomTask"].Columns["wait"].DefaultValue="No";
			fmTasks.dsCustomTasks.Tables["CustomTask"].Columns["pollinginterval"].DefaultValue=0;

			fmTasks.gdCustomTasks.TableStyles["CustomTask"].GridColumnStyles.Add(fmTasks.AddBoolColumn("enabled"));
			DataGridTextBoxColumn txtcol = fmTasks.AddTextColumn("taskname","Name");
			txtcol.Width=150;
			fmTasks.gdCustomTasks.TableStyles["CustomTask"].GridColumnStyles.Add(txtcol);

//			fmTasks.gdCustomTasks.TableStyles["CustomTask"].GridColumnStyles.Add(fmTasks.AddTextColumn("type",""));
//			fmTasks.gdCustomTasks.TableStyles["CustomTask"].GridColumnStyles.Add(fmTasks.AddTextColumn("point",""));
//			fmTasks.gdCustomTasks.TableStyles["CustomTask"].GridColumnStyles.Add(fmTasks.AddTextColumn("wait",""));

			fmTasks.gdCustomTasks.TableStyles["CustomTask"].GridColumnStyles.Add(fmTasks.AddTypeCombo());
			fmTasks.gdCustomTasks.TableStyles["CustomTask"].GridColumnStyles.Add(fmTasks.AddPointCombo());
			fmTasks.gdCustomTasks.TableStyles["CustomTask"].GridColumnStyles.Add(fmTasks.AddWaitCombo());

			txtcol = fmTasks.AddTextColumn("cmd","Command");
			txtcol.Width = 400;
			fmTasks.gdCustomTasks.TableStyles["CustomTask"].GridColumnStyles.Add(txtcol);

			DataGridTextBoxColumn intcol = fmTasks.AddTextColumn("pollinginterval","Polling Interval (secs)");
			intcol.Width = 150;
			fmTasks.gdCustomTasks.TableStyles["CustomTask"].GridColumnStyles.Add(intcol);
			
//			fmTasks.gdCustomTasks.TableStyles.Add( fmTasks.CreateTableStyle(fmTasks) );


			DialogResult dr=fmTasks.ShowDialog();
			if (DialogResult.OK==dr)
			{
				fmTasks.dsCustomTasks.WriteXml(fName, XmlWriteMode.IgnoreSchema);
			}
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(fmCustomTasks));
			this.paBottom = new System.Windows.Forms.Panel();
			this.btCancel = new System.Windows.Forms.Button();
			this.btOK = new System.Windows.Forms.Button();
			this.dsCustomTasks = new PssdiagCustomDiagSchema.Namespace.CustomTasks();
			this.gdCustomTasks = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.tbCustomTasks = new System.Windows.Forms.ToolBar();
			this.btUp = new System.Windows.Forms.ToolBarButton();
			this.btDown = new System.Windows.Forms.ToolBarButton();
			this.imGlyphs = new System.Windows.Forms.ImageList(this.components);
			this.paBottom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dsCustomTasks)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gdCustomTasks)).BeginInit();
			this.SuspendLayout();
			// 
			// paBottom
			// 
			this.paBottom.Controls.Add(this.btCancel);
			this.paBottom.Controls.Add(this.btOK);
			this.paBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.paBottom.Location = new System.Drawing.Point(0, 438);
			this.paBottom.Name = "paBottom";
			this.paBottom.Size = new System.Drawing.Size(1080, 40);
			this.paBottom.TabIndex = 0;
			// 
			// btCancel
			// 
			this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancel.Location = new System.Drawing.Point(992, 8);
			this.btCancel.Name = "btCancel";
			this.btCancel.TabIndex = 1;
			this.btCancel.Text = "Cancel";
			// 
			// btOK
			// 
			this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btOK.Location = new System.Drawing.Point(904, 8);
			this.btOK.Name = "btOK";
			this.btOK.TabIndex = 0;
			this.btOK.Text = "OK";
			this.btOK.Click += new System.EventHandler(this.btOK_Click);
			// 
			// dsCustomTasks
			// 
			this.dsCustomTasks.DataSetName = "CustomTasks";
			this.dsCustomTasks.EnforceConstraints = false;
			this.dsCustomTasks.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// gdCustomTasks
			// 
			this.gdCustomTasks.DataMember = "";
			this.gdCustomTasks.DataSource = this.dsCustomTasks.CustomTask;
			this.gdCustomTasks.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gdCustomTasks.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gdCustomTasks.Location = new System.Drawing.Point(0, 26);
			this.gdCustomTasks.Name = "gdCustomTasks";
			this.gdCustomTasks.Size = new System.Drawing.Size(1080, 412);
			this.gdCustomTasks.TabIndex = 1;
			this.gdCustomTasks.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									  this.dataGridTableStyle1,
																									  this.dataGridTableStyle2});
			this.gdCustomTasks.Navigate += new System.Windows.Forms.NavigateEventHandler(this.gdCustomTasks_Navigate);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.gdCustomTasks;
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "CustomTask";
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.DataGrid = this.gdCustomTasks;
			this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridTextBoxColumn4});
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "Param";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "Name";
			this.dataGridTextBoxColumn1.MappingName = "name";
			this.dataGridTextBoxColumn1.Width = 75;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Prompt";
			this.dataGridTextBoxColumn2.MappingName = "prompt";
			this.dataGridTextBoxColumn2.Width = 300;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "Data Type";
			this.dataGridTextBoxColumn3.MappingName = "datatype";
			this.dataGridTextBoxColumn3.Width = 75;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.HeaderText = "Default";
			this.dataGridTextBoxColumn4.MappingName = "default";
			this.dataGridTextBoxColumn4.Width = 75;
			// 
			// tbCustomTasks
			// 
			this.tbCustomTasks.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																							 this.btUp,
																							 this.btDown});
			this.tbCustomTasks.Divider = false;
			this.tbCustomTasks.DropDownArrows = true;
			this.tbCustomTasks.ImageList = this.imGlyphs;
			this.tbCustomTasks.Location = new System.Drawing.Point(0, 0);
			this.tbCustomTasks.Name = "tbCustomTasks";
			this.tbCustomTasks.ShowToolTips = true;
			this.tbCustomTasks.Size = new System.Drawing.Size(1080, 26);
			this.tbCustomTasks.TabIndex = 2;
			this.tbCustomTasks.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbCustomTasks_ButtonClick);
			// 
			// btUp
			// 
			this.btUp.ImageIndex = 0;
			// 
			// btDown
			// 
			this.btDown.ImageIndex = 1;
			// 
			// imGlyphs
			// 
			this.imGlyphs.ImageSize = new System.Drawing.Size(16, 16);
			this.imGlyphs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imGlyphs.ImageStream")));
			this.imGlyphs.TransparentColor = System.Drawing.SystemColors.Window;
			// 
			// fmCustomTasks
			// 
			this.AcceptButton = this.btOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btCancel;
			this.ClientSize = new System.Drawing.Size(1080, 478);
			this.Controls.Add(this.gdCustomTasks);
			this.Controls.Add(this.tbCustomTasks);
			this.Controls.Add(this.paBottom);
			this.MinimizeBox = false;
			this.Name = "fmCustomTasks";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Custom Tasks";
			this.paBottom.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dsCustomTasks)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gdCustomTasks)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btOK_Click(object sender, System.EventArgs e)
		{
			dsCustomTasks.AcceptChanges();
		}

		private void tbCustomTasks_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (btUp==e.Button) 
			{
				if (dsCustomTasks.Tables["CustomTask"].Rows.Count<2)
					return; //empty or only one row
				int rn = gdCustomTasks.CurrentCell.RowNumber;
				if (0==rn)
					return;  //already at top

				gdCustomTasks.Collapse(-1);
				DataRow drow=dsCustomTasks.Tables["CustomTask"].Rows[rn];
				DataRow prow=dsCustomTasks.Tables["CustomTask"].Rows[rn-1];
				DataRow newrow=dsCustomTasks.Tables["CustomTask"].NewRow();

				//Save off prev values
				newrow["enabled"]=prow["enabled"];
				newrow["groupname"]=prow["groupname"];
				newrow["taskname"]=prow["taskname"];
				newrow["type"]=prow["type"];
				newrow["point"]=prow["point"];
				newrow["wait"]=prow["wait"];
				newrow["cmd"]=prow["cmd"];
				try
				{
					newrow["param"]=prow["param"];
				}
				catch(Exception ex)  //Eat the exception -- param may not be there
				{
					Debug.WriteLine("Exception accessing param subtable: "+ex.Message);
				}

				//Copy cur to prev
				prow["enabled"]=drow["enabled"];
				prow["groupname"]=drow["groupname"];
				prow["taskname"]=drow["taskname"];
				prow["type"]=drow["type"];
				prow["point"]=drow["point"];
				prow["wait"]=drow["wait"];
				prow["cmd"]=drow["cmd"];

				try
				{
					prow["param"]=drow["param"];
				}
				catch(Exception ex)
				{
					Debug.WriteLine("Exception accessing param subtable: "+ex.Message);
				}

				//Copy saved to cur
				drow["enabled"]=newrow["enabled"];
				drow["groupname"]=newrow["groupname"];
				drow["taskname"]=newrow["taskname"];
				drow["type"]=newrow["type"];
				drow["point"]=newrow["point"];
				drow["wait"]=newrow["wait"];
				drow["cmd"]=newrow["cmd"];

				try
				{
					drow["param"]=newrow["param"];
				}
				catch(Exception ex)
				{
					Debug.WriteLine("Exception accessing param subtable: "+ex.Message);
				}
				gdCustomTasks.CurrentCell=new DataGridCell(rn-1,1);

			}
			else if (btDown==e.Button) 
			{
				if (dsCustomTasks.Tables["CustomTask"].Rows.Count<2)
					return; //empty or only one row
				int rn = gdCustomTasks.CurrentCell.RowNumber;
				if (dsCustomTasks.Tables["CustomTask"].Rows.Count-1==rn)
					return;  //already at bottom

				gdCustomTasks.Collapse(-1);
				DataRow drow=dsCustomTasks.Tables["CustomTask"].Rows[rn];
				DataRow nrow=dsCustomTasks.Tables["CustomTask"].Rows[rn+1];
				DataRow newrow=dsCustomTasks.Tables["CustomTask"].NewRow();

				//Save off next values
				newrow["enabled"]=nrow["enabled"];
				newrow["groupname"]=nrow["groupname"];
				newrow["taskname"]=nrow["taskname"];
				newrow["type"]=nrow["type"];
				newrow["point"]=nrow["point"];
				newrow["wait"]=nrow["wait"];
				newrow["cmd"]=nrow["cmd"];
				try
				{
					newrow["param"]=nrow["param"];
				}
				catch(Exception ex)  //Eat the exception -- param may not be there
				{
					Debug.WriteLine("Exception accessing param subtable: "+ex.Message);
				}

				//Copy cur to next
				nrow["enabled"]=drow["enabled"];
				nrow["groupname"]=drow["groupname"];
				nrow["taskname"]=drow["taskname"];
				nrow["type"]=drow["type"];
				nrow["point"]=drow["point"];
				nrow["wait"]=drow["wait"];
				nrow["cmd"]=drow["cmd"];

				try
				{
					nrow["param"]=drow["param"];
				}
				catch(Exception ex)
				{
					Debug.WriteLine("Exception accessing param subtable: "+ex.Message);
				}

				//Copy saved to cur
				drow["enabled"]=newrow["enabled"];
				drow["groupname"]=newrow["groupname"];
				drow["taskname"]=newrow["taskname"];
				drow["type"]=newrow["type"];
				drow["point"]=newrow["point"];
				drow["wait"]=newrow["wait"];
				drow["cmd"]=newrow["cmd"];

				try
				{
					drow["param"]=newrow["param"];
				}
				catch(Exception ex)
				{
					Debug.WriteLine("Exception accessing param subtable: "+ex.Message);
				}
				gdCustomTasks.CurrentCell=new DataGridCell(rn+1,1);
			}
		}

		private void gdCustomTasks_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{
			//Hide the up/down bar because params can't be reordered
			tbCustomTasks.Visible=(!ne.Forward);
		}


	}

	public class DataGridColumnStylePadding 
	{
		
		int m_left;
		int m_right;
		int m_top;
		int m_bottom;

		public int Left 
		{
			get { return m_left; }
			set { m_left = value; }
		}

		public int Right 
		{
			get { return m_right; }
			set { m_right = value; }
		}

		public int Top 
		{
			get { return m_top; }
			set { m_top = value; }
		}

		public int Bottom 
		{
			get { return m_bottom; }
			set { m_bottom = value; }
		}

		public void SetPadding( int padValue ) 
		{
			
			m_left = padValue;
			m_right = padValue;
			m_top = padValue;
			m_bottom = padValue;

		}

		public void SetPadding( int top, int right, int bottom, int left ) 
		{
			UpdatePaddingValues( top, right, bottom, left );
		}

		public DataGridColumnStylePadding( int padValue ) 
		{
			this.SetPadding( padValue );
		}

		public DataGridColumnStylePadding( int top, int right, int bottom, int left ) 
		{
			UpdatePaddingValues( top, right, bottom, left );
		}

		private void UpdatePaddingValues( int top, int right, int bottom, int left ) 
		{

			m_top = top;
			m_right = right;
			m_bottom = bottom;
			m_left = left;
		
		}

	}


	public class DataGridComboBoxColumn : DataGridColumnStyle 
	{
		
		private ComboBox m_comboBox;
		private int m_previouslyEditedCellRow;
		private DataGridColumnStylePadding m_padding;

		public DataGridComboBoxColumn() : base() 
		{
			
			m_comboBox = new ComboBox();
			m_comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			m_comboBox.Visible = false;
			m_comboBox.SizeChanged += new EventHandler( ComboBox_SizeChanged );
			
			this.ControlSize = m_comboBox.Size;
			this.Padding = new DataGridColumnStylePadding( 4, 8, 4, 8 );
			this.Width = this.GetPreferredSize( null, null ).Width;

		}

		public ComboBox ComboBox 
		{
			get { return m_comboBox; }
		}

		public DataGridColumnStylePadding Padding 
		{
			get { return m_padding; }
			set { m_padding = value; }
		}

		public Size ControlSize 
		{
			get { return m_comboBox.Size; }
			set { m_comboBox.Size = value; }
		}

		protected override void Abort(int rowNum) 
		{
						
			// reset combobox
			m_comboBox.Visible = false;
			
		}

		protected override void Edit(CurrencyManager source, int rowNum, Rectangle bounds, bool readOnly, string instantText, bool cellIsVisible) 
		{
	
			Debug.WriteLine( "ComboBox Edit" );

			// get cursor coordinates
			Point p = this.DataGridTableStyle.DataGrid.PointToClient( Cursor.Position );

			// get control bounds
			Rectangle controlBounds = this.GetControlBounds( bounds );

			// get cursor bounds
			Rectangle cursorBounds = new Rectangle( p.X, p.Y, 1, 1 );


			m_comboBox.SelectedIndex = ( int ) this.GetColumnValueAtRow( source, rowNum );
			
			Debug.WriteLine( "SelectedItem: " + m_comboBox.SelectedIndex );
			m_comboBox.Location = new Point( controlBounds.X, controlBounds.Y );
			m_comboBox.Visible = true;

			if ( cursorBounds.IntersectsWith( controlBounds ) ) 
			{
				m_comboBox.DroppedDown = true;
			}

			m_previouslyEditedCellRow = rowNum;
		
		}

		protected override bool Commit( CurrencyManager dataSource, int rowNum ) 
		{
			
			if ( m_previouslyEditedCellRow == rowNum ) 
			{
				this.SetColumnValueAtRow( dataSource, rowNum, m_comboBox.SelectedIndex );
			}

			m_comboBox.Visible = false;
			
			return true;
		
		}

		protected override void SetDataGridInColumn( DataGrid value ) 
		{
			
			base.SetDataGridInColumn( value );

			if ( !value.Controls.Contains( m_comboBox ) ) 
			{
				value.Controls.Add( m_comboBox );
			}

		}
			
		protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight) 
		{
			g.FillRectangle( new SolidBrush( Color.White ), bounds );

			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Near;
			sf.LineAlignment = StringAlignment.Center;

			Rectangle controlBounds = this.GetControlBounds( bounds );
			
			int colValue = ( int ) this.GetColumnValueAtRow( source, rowNum );

			string selectedItem = m_comboBox.Items[ colValue  ].ToString();

			Rectangle textRegion = new Rectangle( 
				controlBounds.X + 1,
				controlBounds.Y + 4,
				controlBounds.Width - 3,
				( int ) g.MeasureString( selectedItem, m_comboBox.Font ).Height );
			
			g.DrawString( selectedItem, m_comboBox.Font, foreBrush, textRegion, sf );
			
			ControlPaint.DrawBorder3D( g, controlBounds, Border3DStyle.Sunken );

			Rectangle buttonBounds = controlBounds;
			buttonBounds.Inflate( -2, -2 );

			ControlPaint.DrawComboButton( 
				g, 
				buttonBounds.X + ( controlBounds.Width - 20 ), 
				buttonBounds.Y, 
				16, 
				17, 
				ButtonState.Normal );

		}

		private void ComboBox_SizeChanged(object sender, EventArgs e) 
		{
			
			this.ControlSize = m_comboBox.Size;
			this.Width = this.GetPreferredSize( null, null ).Width;
			this.Invalidate();

		}

		private Rectangle GetControlBounds( Rectangle cellBounds ) 
		{

			Rectangle controlBounds = new Rectangle( 
				cellBounds.X + this.Padding.Left, 
				cellBounds.Y + this.Padding.Top, 
				this.ControlSize.Width,
				this.ControlSize.Height );

			return controlBounds;

		}

		#region The rest of the DataGridColumnStyle methods

		protected override int GetMinimumHeight() 
		{
			return GetPreferredHeight( null, null );
		}

		protected override int GetPreferredHeight(System.Drawing.Graphics g, object value) 
		{
			return this.ControlSize.Height + this.Padding.Top + this.Padding.Bottom;
		}

		protected override System.Drawing.Size GetPreferredSize(System.Drawing.Graphics g, object value) 
		{
			
			int width = this.ControlSize.Width + this.Padding.Left + this.Padding.Right;
			int height = this.ControlSize.Height + this.Padding.Top + this.Padding.Bottom;

			return new Size( width, height );

		}

		protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, CurrencyManager source, int rowNum) 
		{
			this.Paint( g, bounds, source, rowNum, false );
		}

		protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, CurrencyManager source, int rowNum, bool alignToRight) 
		{
			this.Paint( g, bounds, source, rowNum, Brushes.White, Brushes.Black, false );
		}

		#endregion The rest of the DataGridColumnStyle methods


	}

	#region oldcombo
	public class ComboBoxPickerColumn : DataGridColumnStyle 
	{
		public System.Windows.Forms.ComboBox _combobox = new ComboBox();

		// The isEditing field tracks whether or not the user is
		// editing data with the hosted control.
		private bool isEditing;

		public ComboBoxPickerColumn() : base() 
		{
			_combobox.Visible = false;
			_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
			_combobox.Sorted=false;
		}

		protected override void Abort(int rowNum)
		{
			isEditing = false;
			_combobox.SelectedIndexChanged -= 
				new EventHandler(ComboBoxSelectedIndexChanged);
			Invalidate();
		}

		protected override bool Commit
			(CurrencyManager dataSource, int rowNum) 
		{

			_combobox.Bounds = Rectangle.Empty;
         
			_combobox.SelectedIndexChanged -= 
				new EventHandler(ComboBoxSelectedIndexChanged);

			if (!isEditing)
				return true;

			isEditing = false;

			try 
			{
				string val;
				if ((null!=_combobox.SelectedItem) && (System.DBNull.Value!=_combobox.SelectedItem))
					val = (string) _combobox.SelectedItem;
				else
					val = "";
				SetColumnValueAtRow(dataSource, rowNum, val);
			} 
			catch (Exception) 
			{
				Abort(rowNum);
				return false;
			}

			Invalidate();
			return true;
		}

		protected override void Edit(
			CurrencyManager source, 
			int rowNum,
			Rectangle bounds, 
			bool readOnly,
			string instantText, 
			bool cellIsVisible) 
		{
			object obj=GetColumnValueAtRow(source, rowNum);
			string value;
			if ((null!=obj) && (System.DBNull.Value!=obj))
				value = (string) obj;
			else
				value = "";
			if (cellIsVisible) 
			{
				_combobox.Bounds = new Rectangle
					(bounds.X + 2, bounds.Y + 2, 
					bounds.Width - 4, bounds.Height - 4);
				_combobox.SelectedItem = value;
				_combobox.Visible = true;
				_combobox.SelectedIndexChanged += 
					new EventHandler(ComboBoxSelectedIndexChanged);
			} 
			else 
			{
				_combobox.SelectedItem = value;
				_combobox.Visible = false;
			}

			if (_combobox.Visible)
				DataGridTableStyle.DataGrid.Invalidate(bounds);
		}

		protected override Size GetPreferredSize(
			Graphics g, 
			object value) 
		{
			return new Size(100, _combobox.PreferredHeight + 4);
		}

		protected override int GetMinimumHeight() 
		{
			return _combobox.PreferredHeight + 4;
		}

		protected override int GetPreferredHeight(Graphics g, 
			object value) 
		{
			return _combobox.PreferredHeight + 4;
		}

		protected override void Paint(Graphics g, 
			Rectangle bounds, 
			CurrencyManager source, 
			int rowNum) 
		{
			Paint(g, bounds, source, rowNum, false);
		}
		protected override void Paint(
			Graphics g, 
			Rectangle bounds,
			CurrencyManager source, 
			int rowNum,
			bool alignToRight) 
		{
			Paint(
				g,bounds, 
				source, 
				rowNum, 
				Brushes.Red, 
				Brushes.Blue, 
				alignToRight);
		}
		protected override void Paint(
			Graphics g, 
			Rectangle bounds,
			CurrencyManager source, 
			int rowNum,
			Brush backBrush, 
			Brush foreBrush,
			bool alignToRight) 
		{
			object obj=GetColumnValueAtRow(source, rowNum);
			string val;
			if ((null!=obj) && (System.DBNull.Value!=obj))
				val = (string) obj;
			else
				val="";
				
			Rectangle rect = bounds;
			g.FillRectangle(backBrush,rect);
			rect.Offset(0, 2);
			rect.Height -= 2;
			g.DrawString(val, 
				this.DataGridTableStyle.DataGrid.Font, 
				foreBrush, rect);
		}

		protected override void SetDataGridInColumn(DataGrid value) 
		{
			base.SetDataGridInColumn(value);
			if (_combobox.Parent != null) 
			{
				_combobox.Parent.Controls.Remove 
					(_combobox);
			}
			if (value != null) 
			{
				value.Controls.Add(_combobox);
			}
		}

		private void ComboBoxSelectedIndexChanged(object sender, EventArgs e) 
		{
			this.isEditing = true;
			base.ColumnStartedEditing(_combobox);
		}
	}
	#endregion


}
