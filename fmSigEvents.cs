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
using SQLAnalyzerInterfaces;
using System.Data;
using Xceed.Grid;

namespace SQLAnalyzer
{
	/// <summary>
	/// Summary description for fmSigEvents.
	/// </summary>
	public class fmSigEvents : System.Windows.Forms.Form, IAnalysisConsumer, IEventPublisher
	{
		private System.Windows.Forms.ContextMenu cmEvents;
		private System.Windows.Forms.MenuItem miCopy;
		private Xceed.Grid.GridControl gdEvents;
		private Xceed.Grid.DataRow dataRowTemplate1;
		private Xceed.Grid.GroupByRow groupByRow1;
		private Xceed.Grid.ColumnManagerRow columnManagerRow1;
		private System.Windows.Forms.Splitter splitter1;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ImageList imGlyphs;
		private System.Windows.Forms.TabControl tcDetails;
		private System.Windows.Forms.TabPage tpDetails;
		private System.Windows.Forms.TabPage tpFiltering;
		private System.Windows.Forms.RichTextBox rtDetails;
		internal System.Windows.Forms.Button btnDown;
		internal System.Windows.Forms.Button btnUp;
		internal System.Windows.Forms.Button btnFirst;
		internal System.Windows.Forms.Button btnLast;
		internal System.Windows.Forms.Label lblTextSearched;
		internal Xceed.Grid.Editors.GridMaskedTextBox mtxtbSearch;
		internal System.Windows.Forms.ComboBox cbSearch;
		internal System.Windows.Forms.Label lblSearch;
		internal System.Windows.Forms.Button btnSearch;
		internal System.Windows.Forms.Button btnReset;
		internal System.Windows.Forms.Button btnFilter;

		private ArrayList m_Events;

		public fmSigEvents()
		{

			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_Events=new ArrayList();
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(fmSigEvents));
			this.cmEvents = new System.Windows.Forms.ContextMenu();
			this.miCopy = new System.Windows.Forms.MenuItem();
			this.gdEvents = new Xceed.Grid.GridControl();
			this.dataRowTemplate1 = new Xceed.Grid.DataRow();
			this.groupByRow1 = new Xceed.Grid.GroupByRow();
			this.columnManagerRow1 = new Xceed.Grid.ColumnManagerRow();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.imGlyphs = new System.Windows.Forms.ImageList(this.components);
			this.tcDetails = new System.Windows.Forms.TabControl();
			this.tpDetails = new System.Windows.Forms.TabPage();
			this.rtDetails = new System.Windows.Forms.RichTextBox();
			this.tpFiltering = new System.Windows.Forms.TabPage();
			this.btnDown = new System.Windows.Forms.Button();
			this.btnUp = new System.Windows.Forms.Button();
			this.btnFirst = new System.Windows.Forms.Button();
			this.btnLast = new System.Windows.Forms.Button();
			this.lblTextSearched = new System.Windows.Forms.Label();
			this.mtxtbSearch = new Xceed.Grid.Editors.GridMaskedTextBox();
			this.cbSearch = new System.Windows.Forms.ComboBox();
			this.lblSearch = new System.Windows.Forms.Label();
			this.btnSearch = new System.Windows.Forms.Button();
			this.btnReset = new System.Windows.Forms.Button();
			this.btnFilter = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.gdEvents)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataRowTemplate1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.columnManagerRow1)).BeginInit();
			this.tcDetails.SuspendLayout();
			this.tpDetails.SuspendLayout();
			this.tpFiltering.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmEvents
			// 
			this.cmEvents.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.miCopy});
			this.cmEvents.Popup += new System.EventHandler(this.cmEvents_Popup);
			// 
			// miCopy
			// 
			this.miCopy.Index = 0;
			this.miCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
			this.miCopy.Text = "&Copy to Clipboard";
			this.miCopy.Click += new System.EventHandler(this.miCopy_Click);
			// 
			// gdEvents
			// 
			this.gdEvents.AllowCellNavigation = true;
			this.gdEvents.ContextMenu = this.cmEvents;
			this.gdEvents.DataMember = null;
			this.gdEvents.DataRowTemplate = this.dataRowTemplate1;
			this.gdEvents.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gdEvents.FixedHeaderRows.Add(this.groupByRow1);
			this.gdEvents.FixedHeaderRows.Add(this.columnManagerRow1);
			this.gdEvents.GridLineColor = System.Drawing.Color.Transparent;
			this.gdEvents.HideSelection = true;
			this.gdEvents.Location = new System.Drawing.Point(0, 0);
			this.gdEvents.Name = "gdEvents";
			this.gdEvents.ReadOnly = true;
			// 
			// gdEvents.RowSelectorPane
			// 
			this.gdEvents.RowSelectorPane.Visible = true;
			this.gdEvents.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.gdEvents.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.gdEvents.Size = new System.Drawing.Size(928, 267);
			this.gdEvents.TabIndex = 7;
			this.gdEvents.Click += new System.EventHandler(this.gdEvents_Click);
			this.gdEvents.QueryGroupKeys += new Xceed.Grid.QueryGroupKeysEventHandler(this.grid_QueryGroupKeys);
			this.gdEvents.GroupAdded += new Xceed.Grid.GroupAddedEventHandler(this.grid_GroupAdded);
			this.gdEvents.CurrentRowChanged += new System.EventHandler(this.gdEvents_CurrentRowChanged);
			this.gdEvents.GroupingUpdated += new System.EventHandler(this.grid_GroupingUpdated);
			this.gdEvents.DoubleClick += new System.EventHandler(this.gdEvents_DoubleClick);
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter1.Location = new System.Drawing.Point(0, 267);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(928, 3);
			this.splitter1.TabIndex = 8;
			this.splitter1.TabStop = false;
			// 
			// imGlyphs
			// 
			this.imGlyphs.ImageSize = new System.Drawing.Size(16, 16);
			this.imGlyphs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imGlyphs.ImageStream")));
			this.imGlyphs.TransparentColor = System.Drawing.SystemColors.Window;
			// 
			// tcDetails
			// 
			this.tcDetails.Controls.Add(this.tpDetails);
			this.tcDetails.Controls.Add(this.tpFiltering);
			this.tcDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tcDetails.Location = new System.Drawing.Point(0, 270);
			this.tcDetails.Name = "tcDetails";
			this.tcDetails.SelectedIndex = 0;
			this.tcDetails.Size = new System.Drawing.Size(928, 136);
			this.tcDetails.TabIndex = 9;
			// 
			// tpDetails
			// 
			this.tpDetails.Controls.Add(this.rtDetails);
			this.tpDetails.Location = new System.Drawing.Point(4, 22);
			this.tpDetails.Name = "tpDetails";
			this.tpDetails.Size = new System.Drawing.Size(920, 110);
			this.tpDetails.TabIndex = 0;
			this.tpDetails.Text = "Details";
			// 
			// rtDetails
			// 
			this.rtDetails.ContextMenu = this.cmEvents;
			this.rtDetails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtDetails.HideSelection = false;
			this.rtDetails.Location = new System.Drawing.Point(0, 0);
			this.rtDetails.Name = "rtDetails";
			this.rtDetails.ReadOnly = true;
			this.rtDetails.Size = new System.Drawing.Size(920, 110);
			this.rtDetails.TabIndex = 7;
			this.rtDetails.Text = "";
			// 
			// tpFiltering
			// 
			this.tpFiltering.Controls.Add(this.btnDown);
			this.tpFiltering.Controls.Add(this.btnUp);
			this.tpFiltering.Controls.Add(this.btnFirst);
			this.tpFiltering.Controls.Add(this.btnLast);
			this.tpFiltering.Controls.Add(this.lblTextSearched);
			this.tpFiltering.Controls.Add(this.mtxtbSearch);
			this.tpFiltering.Controls.Add(this.cbSearch);
			this.tpFiltering.Controls.Add(this.lblSearch);
			this.tpFiltering.Controls.Add(this.btnSearch);
			this.tpFiltering.Controls.Add(this.btnReset);
			this.tpFiltering.Controls.Add(this.btnFilter);
			this.tpFiltering.Location = new System.Drawing.Point(4, 22);
			this.tpFiltering.Name = "tpFiltering";
			this.tpFiltering.Size = new System.Drawing.Size(920, 110);
			this.tpFiltering.TabIndex = 1;
			this.tpFiltering.Text = "Search/Filter";
			// 
			// btnDown
			// 
			this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnDown.Location = new System.Drawing.Point(152, 72);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(26, 24);
			this.btnDown.TabIndex = 26;
			this.btnDown.Text = ">>";
			this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
			// 
			// btnUp
			// 
			this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnUp.Location = new System.Drawing.Point(120, 72);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(26, 24);
			this.btnUp.TabIndex = 25;
			this.btnUp.Text = "<<";
			this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
			// 
			// btnFirst
			// 
			this.btnFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnFirst.Location = new System.Drawing.Point(88, 72);
			this.btnFirst.Name = "btnFirst";
			this.btnFirst.Size = new System.Drawing.Size(26, 24);
			this.btnFirst.TabIndex = 24;
			this.btnFirst.Text = "[<";
			this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
			// 
			// btnLast
			// 
			this.btnLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnLast.Location = new System.Drawing.Point(184, 72);
			this.btnLast.Name = "btnLast";
			this.btnLast.Size = new System.Drawing.Size(26, 24);
			this.btnLast.TabIndex = 27;
			this.btnLast.Text = ">]";
			this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
			// 
			// lblTextSearched
			// 
			this.lblTextSearched.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblTextSearched.Location = new System.Drawing.Point(24, 40);
			this.lblTextSearched.Name = "lblTextSearched";
			this.lblTextSearched.Size = new System.Drawing.Size(80, 23);
			this.lblTextSearched.TabIndex = 19;
			this.lblTextSearched.Text = "Text to search:";
			this.lblTextSearched.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// mtxtbSearch
			// 
			this.mtxtbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.mtxtbSearch.AutoSize = false;
			this.mtxtbSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.mtxtbSearch.Location = new System.Drawing.Point(120, 40);
			this.mtxtbSearch.Mask = ">@@@@@";
			this.mtxtbSearch.Name = "mtxtbSearch";
			this.mtxtbSearch.Size = new System.Drawing.Size(176, 20);
			this.mtxtbSearch.TabIndex = 20;
			// 
			// cbSearch
			// 
			this.cbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSearch.Location = new System.Drawing.Point(120, 8);
			this.cbSearch.Name = "cbSearch";
			this.cbSearch.Size = new System.Drawing.Size(176, 20);
			this.cbSearch.TabIndex = 18;
			this.cbSearch.SelectedIndexChanged += new System.EventHandler(this.cbSearch_SelectedIndexChanged);
			// 
			// lblSearch
			// 
			this.lblSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblSearch.Location = new System.Drawing.Point(24, 8);
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.Size = new System.Drawing.Size(80, 23);
			this.lblSearch.TabIndex = 17;
			this.lblSearch.Text = "Search criteria:";
			this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnSearch
			// 
			this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSearch.Location = new System.Drawing.Point(304, 40);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(48, 24);
			this.btnSearch.TabIndex = 21;
			this.btnSearch.Text = "Search";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// btnReset
			// 
			this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnReset.Location = new System.Drawing.Point(24, 72);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(48, 24);
			this.btnReset.TabIndex = 22;
			this.btnReset.Text = "Reset";
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnFilter
			// 
			this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnFilter.Location = new System.Drawing.Point(232, 72);
			this.btnFilter.Name = "btnFilter";
			this.btnFilter.Size = new System.Drawing.Size(120, 24);
			this.btnFilter.TabIndex = 23;
			this.btnFilter.Text = "Filter Search Results";
			this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
			// 
			// fmSigEvents
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(928, 406);
			this.Controls.Add(this.gdEvents);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.tcDetails);
			this.Name = "fmSigEvents";
			this.Text = "Significant Events";
			this.Load += new System.EventHandler(this.fmSigEvents_Load);
			((System.ComponentModel.ISupportInitialize)(this.gdEvents)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataRowTemplate1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.columnManagerRow1)).EndInit();
			this.tcDetails.ResumeLayout(false);
			this.tpDetails.ResumeLayout(false);
			this.tpFiltering.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void AnalysisComplete(CAnalysis Analysis)
		{
			foreach (CEvent evt in Analysis.Events) 
			{
				m_Events.Add(evt);
			}
		}
		public void PublishEvent(CEvent evt)
		{
			if (evt.Display)
			{
				Xceed.Grid.DataRow dataRow = gdEvents.DataRows.AddNew();
				switch (evt.Type)
				{
					case EventType.Error : 
					{
						dataRow.Cells[ "Icon" ].Value=imGlyphs.Images[12];
						break;
					}
					case EventType.Warning: 
					{
						dataRow.Cells[ "Icon" ].Value=imGlyphs.Images[11];
						break;
					}
					default:
					{
						dataRow.Cells[ "Icon" ].Value=imGlyphs.Images[10];
						break;
					}
				}

				dataRow.Cells[ "Start" ].Value =(DateTime.MinValue==evt.StartTime)?"":evt.StartTime.ToString("yyyy/MM/dd")+" "+evt.StartTime.ToString("HH:mm:ss");
				dataRow.Cells[ "End" ].Value =(DateTime.MinValue==evt.EndTime)?"":evt.EndTime.ToString("yyyy/MM/dd")+" "+evt.EndTime.ToString("HH:mm:ss");
				if (DateTime.MinValue!=evt.EndTime)
				{
					TimeSpan ts=(evt.EndTime.Subtract(evt.StartTime));
					dataRow.Cells[ "Duration" ].Value =string.Format("{0}h {1}m {2}s",ts.Hours,ts.Minutes,ts.Seconds);
				}
				else
				{
					dataRow.Cells[ "Duration" ].Value="";
				}
				dataRow.Cells[ "Type" ].Value=evt.Type.ToString();
				dataRow.Cells[ "Category" ].Value=evt.Category;
				dataRow.Cells[ "Analyzer" ].Value=evt.Analysis.Analyzer.Name;
				dataRow.Cells[ "Message" ].Value=evt.Text;
				dataRow.Tag=evt;
				dataRow.EndEdit();


				//				newItem.Selected=true;
				//				lvOutput.EnsureVisible(newItem.Index);
			}
			return;
		}

		public void UnPublishEvent(CEvent evt)
		{
			foreach (Xceed.Grid.DataRow row in gdEvents.DataRows)
			{
				if (row.Tag==evt) 
				{
					row.Remove();
					break;
				}
			}
		}

		public void PublishAllEvents()
		{

			UnPublishAllEvents();
			foreach (CEvent evt in m_Events)
				PublishEvent(evt);

 
		}

		public void UnPublishAllEvents()
		{
			gdEvents.DataRows.Clear();
			rtDetails.Text="";
		}

		private void miCopy_Click(object sender, System.EventArgs e)
		{
			if (0==gdEvents.SelectedRows.Count)
				return;
			string ctext="";
			if (!rtDetails.Focused) 
			{
				CEvent evt=(gdEvents.SelectedRows[0].Tag as CEvent);
				ctext=evt.SerializedText+"\r\n"+evt.GetDetails();
			}
			else if (null!=rtDetails.SelectedText)
				ctext=rtDetails.SelectedText;

			if (""!=ctext)
				Clipboard.SetDataObject(ctext);
		}

		private void cmEvents_Popup(object sender, System.EventArgs e)
		{
			miCopy.Enabled=(0!=gdEvents.SelectedRows.Count);
		}

		private void fmSigEvents_Load(object sender, System.EventArgs e)
		{
			Column coIcon = new Column( "Icon", typeof( Bitmap ) );
			coIcon.Width=17;
			coIcon.MaxWidth=17;
			coIcon.Title="";
			
			Column coStart = new Column( "Start", typeof( string ) );
			coStart.Width=112;
			Column coEnd = new Column( "End", typeof( string ) );
			coEnd.Width=112;
			Column coDuration = new Column( "Duration", typeof( string ) );
			coDuration.Width=65;
			Column coType = new Column( "Type", typeof( string ) );
			coType.Width=75;
			Column coCategory = new Column( "Category", typeof( string ) );
			coCategory.Width=65;
			Column coAnalyzer = new Column( "Analyzer", typeof( string ) );
			coAnalyzer.Width=100;
			Column coMessage = new Column( "Message", typeof( string ) );
			coMessage.Width=365;

			gdEvents.Columns.Add( coIcon );
			gdEvents.Columns.Add( coStart );
			gdEvents.Columns.Add( coEnd );
			gdEvents.Columns.Add( coDuration );
			gdEvents.Columns.Add( coType );
			gdEvents.Columns.Add( coCategory );
			gdEvents.Columns.Add( coAnalyzer );
			gdEvents.Columns.Add( coMessage );

			gdEvents.Columns[ "Start" ].SortDirection = SortDirection.Ascending;

			foreach( DataCell cell in gdEvents.DataRowTemplate.Cells )
			{
				cell.DoubleClick += new System.EventHandler(this.gdEvents_DoubleClick);
				cell.Click+= new System.EventHandler(this.gdEvents_Click);
			}

			// Use the FieldName property of each column in the grid to populate the two
			// combo boxes.
			foreach( Column column in gdEvents.Columns )
			{
				if (column.FieldName=="Icon")
					continue;
				this.cbSearch.Items.Add( column.FieldName );

				if( column.DataType == typeof( DateTime ) )
				{
					// The search entry text box is assuming the date format YYYY/MM/DD. We make
					// sure that each column that is a date will have this format by using the
					// FormatSpecifier property.
					// This format allows the user to search only the year or only the year and 
					// the month.
					column.FormatSpecifier = @"yyyy\/MM\/dd hh:mm:ss";
				}
			}
      
			this.cbSearch.Text = ( string )this.cbSearch.Items[ 0 ];

			this.mtxtbSearch.BorderStyle = BorderStyle.Fixed3D;

			this.btnFilter.Enabled = false;

		}

		private void gdEvents_DoubleClick(object sender, System.EventArgs e)
		{
			if (0!=gdEvents.SelectedRows.Count)
			{
				CEvent evt = (CEvent)gdEvents.SelectedRows[0].Tag;
				evt.DrillThrough();
			}
		}

		private void ShowDetails()
		{
			if (0!=gdEvents.SelectedRows.Count)
			{
				IAnalysisHost Host = (this.MdiParent as IAnalysisHost);
				CEvent evt = (CEvent)gdEvents.SelectedRows[0].Tag;
				rtDetails.Text=evt.GetDetails();
				Host.ClearAllEvents();
				Host.PlotEvent(evt);
			}
		}

		private void gdEvents_CurrentRowChanged(object sender, System.EventArgs e)
		{
			ShowDetails();
		}

		private void gdEvents_Click(object sender, System.EventArgs e)
		{
			ShowDetails();
		}

		#region Search and Filter routines

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			// Reset the back color of each row that was found in the previous search, if any.
			foreach( Xceed.Grid.DataRow dataRow in m_foundRows )
			{
				dataRow.ResetBackColor();

				// We must not forget the parent groups of the data row for which their 
				// GroupManagerRow's BackColor has been modified.
				Group parentGroup = dataRow.ParentGroup as Group;
        
				while( parentGroup != null )
				{
					parentGroup.Collapse();
					parentGroup.HeaderRows[ 0 ].ResetBackColor();
					parentGroup = parentGroup.ParentGroup as Group;
				}
			}

			m_foundRows.Clear();

			if( this.mtxtbSearch.RawText.Length > 0 )
			{
				string searchString = this.mtxtbSearch.RawText.ToUpper();
				string searchCriteria = ( string )this.cbSearch.SelectedItem;

				// If the searched column is of type DateTime, we have to add the mask literals
				// for the search to be meaningful.
				if (
//					(gdEvents.Columns[ searchCriteria ].DataType == typeof( DateTime )) || 
					(searchCriteria=="Start") || (searchCriteria=="End") )
				{
//					searchString = searchString.Insert( 0, "20" );
					if( searchString.Length > 4 )
						searchString = searchString.Insert( 4, "/" );
					if( searchString.Length > 7 )
						searchString = searchString.Insert( 7, "/" );
				}

				// Iterates each data rows of the grid and check if the searched string applies to it.
				foreach( Xceed.Grid.DataRow dataRow in gdEvents.DataRows )
				{
					// We compare the specified string with the GetTextToPaint() of the Cell to 
					// make sure that the search will apply on what's displayed in the grid 
					// (can make a difference with date values for instance).
					if( dataRow.Cells[ searchCriteria ].GetTextToPaint().ToUpper().StartsWith( searchString ) )
					{
						// Make sure that each parent group of the found data row are expanded.
						if( ( dataRow.ParentGroup != null ) && dataRow.ParentGroup.Collapsed )
						{
							Group parentGroup = dataRow.ParentGroup as Group;
              
							while( parentGroup != null )
							{
								parentGroup.Expand();
								parentGroup = parentGroup.ParentGroup as Group;
							}
						}

						// Highlight the found data row by changing its back color
						dataRow.BackColor = Color.AliceBlue;
						// Highlight the found data row's parent groups by changing their
						// GroupManagerRow's back color.
						this.TagGroups( dataRow );
						m_foundRows.Add( dataRow );
					}
				}

				// Add a text row in the grid fixed footers displaying the number of rows found.
				TextRow searchResultsRow = new TextRow( m_foundRows.Count.ToString() + " item" + ( ( m_foundRows.Count == 1 ) ? "" : "s" ) + " found." );
				searchResultsRow.Font = new Font( "Verdana", 9, FontStyle.Bold | FontStyle.Italic ); 
				searchResultsRow.Height = searchResultsRow.Height + 10;
				searchResultsRow.ForeColor = Color.AliceBlue;
				searchResultsRow.BackColor = Color.LightSteelBlue;
				searchResultsRow.CanBeSelected = false;
				searchResultsRow.CanBeCurrent = false;
				searchResultsRow.VerticalAlignment = VerticalAlignment.Center;

				gdEvents.FixedFooterRows.Clear();
				gdEvents.FixedFooterRows.Add( searchResultsRow );

				if( m_foundRows.Count > 0 )
					this.btnFilter.Enabled = true;
			}
			else
			{
				gdEvents.FixedFooterRows.Clear();
				this.btnFilter.Enabled = false;
			}
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			this.groupByRow1.Visible=true;
			gdEvents.Columns["Icon"].Visible=true;

			// Reset the back color of each row that was found in the previous search, if any.
			foreach( Xceed.Grid.DataRow dataRow in m_foundRows )
			{
				dataRow.ResetBackColor();

				// We must not forget the parent groups of the data row for which their 
				// GroupManagerRow's BackColor has been modified.
				Group parentGroup = dataRow.ParentGroup as Group;

				while( parentGroup != null )
				{
					if( parentGroup.HeaderRows.Count > 0 )
						parentGroup.HeaderRows[ 0 ].ResetBackColor();

					parentGroup = parentGroup.ParentGroup as Group;
				}
			}

			m_foundRows.Clear();
			// Remove the text row in the grid fixed footers displaying the number of rows
			// found.
			gdEvents.FixedFooterRows.Clear();
			this.mtxtbSearch.RawText = string.Empty;

			if( m_filtered )
			{
				// Remove the group template used to filter the found data rows.
				gdEvents.GroupTemplates.RemoveAt( 0 );

				// The m_filtered indicator being checked in the GroupingUpdated event handler, 
				// we have to set it before the call to UpdateGrouping.
				m_filtered = false;

				gdEvents.UpdateGrouping();

				this.btnFilter.Text = "Filter Search Results";

				this.btnSearch.Enabled      = true;
			}

			this.btnFilter.Enabled = false;
		}

		private void cbSearch_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.mtxtbSearch.RawText = string.Empty;

			switch( ( string )this.cbSearch.SelectedItem )
			{
				case "Start" :
				case "End" :
					this.mtxtbSearch.Mask = @"9999/99/99 99:99:99";
					break;
				default :
					this.mtxtbSearch.Mask = string.Empty;
					break;
			}
		}

		private void TagGroups( Xceed.Grid.DataRow foundDataRow )
		{
			// Make sure that each foundDataRow's parent groups have their GroupManagerRow's
			// BackColor set to the chosen highlight color.
			Group parentGroup = foundDataRow.ParentGroup as Group;
			Color color = Color.LightSteelBlue;
      
			while( parentGroup != null )
			{
				if( parentGroup.HeaderRows.Count > 0 )
				{
					if( parentGroup.HeaderRows[ 0 ].BackColor != color )
					{
						parentGroup.HeaderRows[ 0 ].BackColor = color;
					}
					else
					{
						// The group is already tagged. That means that all its parent groups are
						// tagged too. We exit immediately.
						break;
					}
				}

				parentGroup = parentGroup.ParentGroup as Group;
			}
		}

		private void SelectDataRow( Xceed.Grid.DataRow dataRow )
		{
			// Make sure the specified dataRow is visible to the user. This HAS to be called
			// before the CurrentRow is changed because the CurrentRow can only be set to a row
			// that is Visible = true and, if there are grouping, in an expanded group.
			// BringIntoView will expand all the groups necessary to make the row visible.
			dataRow.BringIntoView();

			// Set the specified dataRow as the current one so that its row selector show the
			// arrow glyph.
			gdEvents.CurrentRow = dataRow;
      
			// Set the specified dataRow as the selected one.
			gdEvents.SelectedRows.Clear();
			gdEvents.SelectedRows.Add( dataRow );
		}

		private void btnFilter_Click(object sender, System.EventArgs e)
		{
			if( m_filtered )
			{
				// The following line removes the filtering group which was placed at position 0 in the 
				// gdEvents.GroupTemplates list.
				gdEvents.GroupTemplates.RemoveAt( 0 );

				this.btnFilter.Text = "Filter Search Results";

				this.groupByRow1.Visible=true;
				gdEvents.Columns["Icon"].Visible=true;
			}
			else
			{
				// Create a filtering group that has no header/footer rows and that has its 
				// margin not visible. In effect, the filter groups have no visual representation.
				// They are only use to show (expand) or hide (collapse) their inner data rows.
				Group filter = new Group();
				filter.SideMargin.Visible = false;

				// The following line inserts the filtering group at position 0 in the 
				// gdEvents.GroupTemplates list.
				gdEvents.GroupTemplates.Insert( 0, filter );

				this.btnFilter.Text = "Show All Rows";

				this.groupByRow1.Visible=false;

				gdEvents.Columns["Icon"].Visible=false;

			}

			m_filtered = !m_filtered;

			// This call will iterate each data row and assign a group to each one. For more 
			// details, see the grid_QueryGroupKeys and 
			// grid_GroupingUpdated event handler.
			gdEvents.UpdateGrouping();

			// Button btnSearch is disabled when the elements contained in the grid are filtered.
			this.btnSearch.Enabled      = !m_filtered;

			gdEvents.Columns["Icon"].Width=17;

		}

		private void grid_QueryGroupKeys( object sender, QueryGroupKeysEventArgs e )
		{
			// The QueryGroupKeys event is used for filtering. This event handler groups the 
			// datarows manually by setting the first group key according to the datarow's 
			// presence in the foundRows list. We know that the first group key ( e.GroupKey[ 0 ] ) 
			// is the filtering group because we previously inserted the filtering group template 
			// at position 0 in the grid's group templates collection.
			if( m_filtered )
				e.GroupKeys[ 0 ] = m_foundRows.Contains( e.DataRow );
		}

		private void grid_GroupAdded( object sender, GroupAddedEventArgs e )
		{
			// The GroupAdded event is used for filtering. This event handler is in charge of
			// collapsing the instance of the filtering group that contains rejected rows and
			// expanding the instance of the filtering group that contains found rows.
			// Since the filtering groups do not have a visual representation (no margin, 
			// no header/footer rows), the collapsed group and all its content will not appear 
			// in the gdEvents.
			if( ( this.m_filtered ) && ( e.Group.Level == 0 ) )
				e.Group.Collapsed = !( ( bool )e.Group.Key );
		}

		private void grid_GroupingUpdated( object sender, EventArgs e )
		{
			// The GroupingUpdated event is called whenever the grid's groupings are updated. 
			// This event handler "tags" the groups (their GroupManagerRow, to be more precise) 
			// that contain datarows that answer the search criteria.
			foreach( Xceed.Grid.DataRow dataRow in m_foundRows )
				this.TagGroups( dataRow );
		}

		private void btnFirst_Click(object sender, System.EventArgs e)
		{
			// Extract the list of data rows in the grid in their displayed order.
			Xceed.Grid.Collections.ReadOnlyDataRowList dataRows = gdEvents.GetSortedDataRows( true );
      
			// Suppose the first data row of the sorted data rows collection will be the one
			// (it will be for sure if there is no active search).
			Xceed.Grid.DataRow firstTaggedDataRow = dataRows[ 0 ];

			if( m_foundRows.Count > 0 )
			{
				foreach( Xceed.Grid.DataRow dataRow in dataRows )
				{
					if( m_foundRows.Contains( dataRow ) )
					{
						firstTaggedDataRow = dataRow;
						break;
					}
				}
			}

			this.SelectDataRow( firstTaggedDataRow );
		}

		private void btnLast_Click(object sender, System.EventArgs e)
		{
			// Extract the list of data rows in the grid in their displayed order.
			Xceed.Grid.Collections.ReadOnlyDataRowList dataRows = gdEvents.GetSortedDataRows( true );

			int rowCount = dataRows.Count;

			// Suppose the first data row of the sorted data rows collection will be the one
			// (it will be for sure if there is no active search).
			Xceed.Grid.DataRow lastTaggedDataRow = dataRows[ rowCount - 1 ];

			if( m_foundRows.Count > 0 )
			{
				for( int i = rowCount - 1; i >= 0; i-- )
				{
					if( m_foundRows.Contains( dataRows[ i ] ) )
					{
						lastTaggedDataRow = dataRows[ i ];
						break;
					}
				}
			}

			this.SelectDataRow( lastTaggedDataRow );
		}

		private void btnUp_Click(object sender, System.EventArgs e)
		{
			// Extract the list of data rows in the grid in their displayed order.
			Xceed.Grid.Collections.ReadOnlyDataRowList dataRows = gdEvents.GetSortedDataRows( true );

			int currentIndex = 0;
      
			if( gdEvents.CurrentRow is Xceed.Grid.DataRow )
				currentIndex = dataRows.IndexOf( ( Xceed.Grid.DataRow )gdEvents.CurrentRow );

			Xceed.Grid.DataRow previousTaggedDataRow = dataRows[ currentIndex ];

			if( m_foundRows.Count > 0 )
			{
				for( int i = currentIndex - 1; i >= 0; i-- )
				{
					if( m_foundRows.Contains( dataRows[ i ] ) )
					{
						previousTaggedDataRow = dataRows[ i ];
						break;
					}
				}
			}
			else
			{
				if( currentIndex > 0 )
					previousTaggedDataRow = dataRows[ currentIndex - 1 ];
			}

			this.SelectDataRow( previousTaggedDataRow );
		}

		private void btnDown_Click(object sender, System.EventArgs e)
		{
			Xceed.Grid.Collections.ReadOnlyDataRowList dataRows = gdEvents.GetSortedDataRows( true );

			int currentIndex = 0;
        
			if( gdEvents.CurrentRow is Xceed.Grid.DataRow )
				currentIndex = dataRows.IndexOf( ( Xceed.Grid.DataRow )gdEvents.CurrentRow );

			Xceed.Grid.DataRow nextTaggedDataRow = dataRows[ currentIndex ];
 
			if( m_foundRows.Count > 0 )
			{
				for( int i = currentIndex + 1; i < dataRows.Count; i++ )
				{
					if( m_foundRows.Contains( dataRows[ i ] ) )
					{
						nextTaggedDataRow = dataRows[ i ];
						break;
					}
				}
			}
			else
			{
				if( currentIndex < dataRows.Count - 1 )
					nextTaggedDataRow = dataRows[ currentIndex + 1 ];
			}

			this.SelectDataRow( nextTaggedDataRow );
		}

		private bool m_filtered = false;
		private ArrayList m_foundRows = new ArrayList();
		#endregion
	}
}
