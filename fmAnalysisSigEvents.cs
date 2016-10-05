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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SQLAnalyzerInterfaces;
using System.Data;

namespace SQLAnalyzer
{
	public class fmAnalysisSigEvents : SQLAnalyzerInterfaces.fmAnalysis, IAnalysisConsumer, IEventPublisher
	{
		private System.Windows.Forms.ImageList imGlyphs;
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ContextMenu cmEvents;
		private System.Windows.Forms.MenuItem miCopy;
		private System.Windows.Forms.RichTextBox rtDetails;
		private System.Windows.Forms.Splitter splitter1;
		private Xceed.Grid.GroupByRow groupByRow1;
		private Xceed.Grid.ColumnManagerRow columnManagerRow1;
		private Xceed.Grid.DataRow dataRowTemplate1;
		private System.Data.DataSet dsEvents;
		private System.Data.DataTable taEvents;
		private System.Data.DataColumn coStart;
		private System.Data.DataColumn coEnd;
		private Xceed.Grid.GridControl gdEvents;
		private System.Data.DataColumn coType;
		private System.Data.DataColumn coCategory;
		private System.Data.DataColumn coAnalyzer;
		private System.Data.DataColumn coMessage;
		private System.Data.DataColumn coDuration;
		private Xceed.Grid.DataBoundColumn colStart;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1Start;
		private Xceed.Grid.DataCell celldataRowTemplate1Start;
		private Xceed.Grid.DataBoundColumn colEnd;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1End;
		private Xceed.Grid.DataCell celldataRowTemplate1End;
		private Xceed.Grid.DataBoundColumn colDuration;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1Duration;
		private Xceed.Grid.DataCell celldataRowTemplate1Duration;
		private Xceed.Grid.DataBoundColumn colType;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1Type;
		private Xceed.Grid.DataCell celldataRowTemplate1Type;
		private Xceed.Grid.DataBoundColumn colCategory;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1Category;
		private Xceed.Grid.DataCell celldataRowTemplate1Category;
		private Xceed.Grid.DataBoundColumn colAnalyzer;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1Analyzer;
		private Xceed.Grid.DataCell celldataRowTemplate1Analyzer;
		private Xceed.Grid.DataBoundColumn colMessage;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1Message;
		private Xceed.Grid.DataCell celldataRowTemplate1Message;

		private ArrayList m_Events;

		public fmAnalysisSigEvents()
		{
			Xceed.Grid.Licenser.LicenseKey = "GRD23-TWMX9-GH9S4-UWCA";

			// This call is required by the Windows Form Designer.
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
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(fmAnalysisSigEvents));
			this.cmEvents = new System.Windows.Forms.ContextMenu();
			this.miCopy = new System.Windows.Forms.MenuItem();
			this.imGlyphs = new System.Windows.Forms.ImageList(this.components);
			this.rtDetails = new System.Windows.Forms.RichTextBox();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.gdEvents = new Xceed.Grid.GridControl();
			this.dataRowTemplate1 = new Xceed.Grid.DataRow();
			this.dsEvents = new System.Data.DataSet();
			this.taEvents = new System.Data.DataTable();
			this.coStart = new System.Data.DataColumn();
			this.coEnd = new System.Data.DataColumn();
			this.coDuration = new System.Data.DataColumn();
			this.coType = new System.Data.DataColumn();
			this.coCategory = new System.Data.DataColumn();
			this.coAnalyzer = new System.Data.DataColumn();
			this.coMessage = new System.Data.DataColumn();
			this.groupByRow1 = new Xceed.Grid.GroupByRow();
			this.columnManagerRow1 = new Xceed.Grid.ColumnManagerRow();
			this.colStart = new Xceed.Grid.DataBoundColumn();
			this.cellcolumnManagerRow1Start = new Xceed.Grid.ColumnManagerCell();
			this.celldataRowTemplate1Start = new Xceed.Grid.DataCell();
			this.colEnd = new Xceed.Grid.DataBoundColumn();
			this.cellcolumnManagerRow1End = new Xceed.Grid.ColumnManagerCell();
			this.celldataRowTemplate1End = new Xceed.Grid.DataCell();
			this.colDuration = new Xceed.Grid.DataBoundColumn();
			this.cellcolumnManagerRow1Duration = new Xceed.Grid.ColumnManagerCell();
			this.celldataRowTemplate1Duration = new Xceed.Grid.DataCell();
			this.colType = new Xceed.Grid.DataBoundColumn();
			this.cellcolumnManagerRow1Type = new Xceed.Grid.ColumnManagerCell();
			this.celldataRowTemplate1Type = new Xceed.Grid.DataCell();
			this.colCategory = new Xceed.Grid.DataBoundColumn();
			this.cellcolumnManagerRow1Category = new Xceed.Grid.ColumnManagerCell();
			this.celldataRowTemplate1Category = new Xceed.Grid.DataCell();
			this.colAnalyzer = new Xceed.Grid.DataBoundColumn();
			this.cellcolumnManagerRow1Analyzer = new Xceed.Grid.ColumnManagerCell();
			this.celldataRowTemplate1Analyzer = new Xceed.Grid.DataCell();
			this.colMessage = new Xceed.Grid.DataBoundColumn();
			this.cellcolumnManagerRow1Message = new Xceed.Grid.ColumnManagerCell();
			this.celldataRowTemplate1Message = new Xceed.Grid.DataCell();
			((System.ComponentModel.ISupportInitialize)(this.gdEvents)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataRowTemplate1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsEvents)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.taEvents)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.columnManagerRow1)).BeginInit();
			this.SuspendLayout();
			// 
			// sbMsg
			// 
			this.sbMsg.Location = new System.Drawing.Point(0, 323);
			this.sbMsg.Name = "sbMsg";
			this.sbMsg.Size = new System.Drawing.Size(920, 22);
			// 
			// tbTop
			// 
			this.tbTop.Name = "tbTop";
			this.tbTop.Size = new System.Drawing.Size(920, 28);
			// 
			// menuItem1
			// 
			this.menuItem1.Visible = false;
			// 
			// ilChild
			// 
			this.ilChild.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilChild.ImageStream")));
			// 
			// cmEvents
			// 
			this.cmEvents.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.miCopy});
			// 
			// miCopy
			// 
			this.miCopy.Index = 0;
			this.miCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
			this.miCopy.Text = "&Copy to Clipboard";
			// 
			// imGlyphs
			// 
			this.imGlyphs.ImageSize = new System.Drawing.Size(16, 16);
			this.imGlyphs.TransparentColor = System.Drawing.SystemColors.Window;
			// 
			// rtDetails
			// 
			this.rtDetails.ContextMenu = this.cmEvents;
			this.rtDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.rtDetails.HideSelection = false;
			this.rtDetails.Location = new System.Drawing.Point(0, 227);
			this.rtDetails.Name = "rtDetails";
			this.rtDetails.ReadOnly = true;
			this.rtDetails.Size = new System.Drawing.Size(920, 96);
			this.rtDetails.TabIndex = 3;
			this.rtDetails.Text = "";
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter1.Location = new System.Drawing.Point(0, 224);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(920, 3);
			this.splitter1.TabIndex = 4;
			this.splitter1.TabStop = false;
			// 
			// gdEvents
			// 
			this.gdEvents.Columns.Add(this.colStart);
			this.gdEvents.Columns.Add(this.colEnd);
			this.gdEvents.Columns.Add(this.colDuration);
			this.gdEvents.Columns.Add(this.colType);
			this.gdEvents.Columns.Add(this.colCategory);
			this.gdEvents.Columns.Add(this.colAnalyzer);
			this.gdEvents.Columns.Add(this.colMessage);
			this.gdEvents.DataMember = "Events";
			this.gdEvents.DataRowTemplate = this.dataRowTemplate1;
			this.gdEvents.DataSource = this.dsEvents;
			this.gdEvents.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gdEvents.FixedHeaderRows.Add(this.groupByRow1);
			this.gdEvents.FixedHeaderRows.Add(this.columnManagerRow1);
			this.gdEvents.Location = new System.Drawing.Point(0, 28);
			this.gdEvents.Name = "gdEvents";
			this.gdEvents.ReadOnly = true;
			this.gdEvents.Size = new System.Drawing.Size(920, 196);
			this.gdEvents.TabIndex = 5;
			// 
			// dataRowTemplate1
			// 
			this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1Start);
			this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1End);
			this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1Duration);
			this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1Type);
			this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1Category);
			this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1Analyzer);
			this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1Message);
			// 
			// dsEvents
			// 
			this.dsEvents.DataSetName = "dsEvents";
			this.dsEvents.Locale = new System.Globalization.CultureInfo("en-US");
			this.dsEvents.Tables.AddRange(new System.Data.DataTable[] {
																		  this.taEvents});
			// 
			// taEvents
			// 
			this.taEvents.Columns.AddRange(new System.Data.DataColumn[] {
																			this.coStart,
																			this.coEnd,
																			this.coDuration,
																			this.coType,
																			this.coCategory,
																			this.coAnalyzer,
																			this.coMessage});
			this.taEvents.TableName = "Events";
			// 
			// coStart
			// 
			this.coStart.Caption = "Start";
			this.coStart.ColumnName = "Start";
			// 
			// coEnd
			// 
			this.coEnd.ColumnName = "End";
			// 
			// coDuration
			// 
			this.coDuration.ColumnName = "Duration";
			// 
			// coType
			// 
			this.coType.ColumnName = "Type";
			// 
			// coCategory
			// 
			this.coCategory.ColumnName = "Category";
			// 
			// coAnalyzer
			// 
			this.coAnalyzer.ColumnName = "Analyzer";
			// 
			// coMessage
			// 
			this.coMessage.ColumnName = "Message";
			// 
			// columnManagerRow1
			// 
			this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1Start);
			this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1End);
			this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1Duration);
			this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1Type);
			this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1Category);
			this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1Analyzer);
			this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1Message);
			// 
			// colStart
			// 
			this.colStart.Title = "Start";
			this.colStart.VisibleIndex = 0;
			this.colStart.Width = 122;
			this.colStart.Initialize("Start");
			this.cellcolumnManagerRow1Start.Initialize("Start");
			this.celldataRowTemplate1Start.Initialize("Start");
			// 
			// colEnd
			// 
			this.colEnd.Title = "End";
			this.colEnd.VisibleIndex = 1;
			this.colEnd.Width = 124;
			this.colEnd.Initialize("End");
			this.cellcolumnManagerRow1End.Initialize("End");
			this.celldataRowTemplate1End.Initialize("End");
			// 
			// colDuration
			// 
			this.colDuration.Title = "Duration";
			this.colDuration.VisibleIndex = 2;
			this.colDuration.Initialize("Duration");
			this.cellcolumnManagerRow1Duration.Initialize("Duration");
			this.celldataRowTemplate1Duration.Initialize("Duration");
			// 
			// colType
			// 
			this.colType.Title = "Type";
			this.colType.VisibleIndex = 3;
			this.colType.Width = 85;
			this.colType.Initialize("Type");
			this.cellcolumnManagerRow1Type.Initialize("Type");
			this.celldataRowTemplate1Type.Initialize("Type");
			// 
			// colCategory
			// 
			this.colCategory.Title = "Category";
			this.colCategory.VisibleIndex = 4;
			this.colCategory.Width = 85;
			this.colCategory.Initialize("Category");
			this.cellcolumnManagerRow1Category.Initialize("Category");
			this.celldataRowTemplate1Category.Initialize("Category");
			// 
			// colAnalyzer
			// 
			this.colAnalyzer.Title = "Analyzer";
			this.colAnalyzer.VisibleIndex = 5;
			this.colAnalyzer.Width = 75;
			this.colAnalyzer.Initialize("Analyzer");
			this.cellcolumnManagerRow1Analyzer.Initialize("Analyzer");
			this.celldataRowTemplate1Analyzer.Initialize("Analyzer");
			// 
			// colMessage
			// 
			this.colMessage.Title = "Message";
			this.colMessage.VisibleIndex = 6;
			this.colMessage.Width = 302;
			this.colMessage.Initialize("Message");
			this.cellcolumnManagerRow1Message.Initialize("Message");
			this.celldataRowTemplate1Message.Initialize("Message");
			// 
			// fmAnalysisSigEvents
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(920, 345);
			this.Controls.Add(this.gdEvents);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.rtDetails);
			this.Name = "fmAnalysisSigEvents";
			this.Text = "Significant Events";
			this.Controls.SetChildIndex(this.sbMsg, 0);
			this.Controls.SetChildIndex(this.tbTop, 0);
			this.Controls.SetChildIndex(this.rtDetails, 0);
			this.Controls.SetChildIndex(this.splitter1, 0);
			this.Controls.SetChildIndex(this.gdEvents, 0);
			((System.ComponentModel.ISupportInitialize)(this.gdEvents)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataRowTemplate1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsEvents)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.taEvents)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.columnManagerRow1)).EndInit();
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
		ArrayList m_PublishedEvents = new ArrayList();

		public void PublishEvent(CEvent evt)
		{
			if (evt.Display)
			{
				DataTable dt = dsEvents.Tables["Events"];
				DataRow row = dt.NewRow();
				row[0]=(DateTime.MinValue==evt.StartTime)?"":evt.StartTime.ToShortDateString()+" "+evt.StartTime.ToString("HH:mm:ss");
				row[1]=(DateTime.MinValue==evt.EndTime)?"":evt.EndTime.ToShortDateString()+" "+evt.EndTime.ToString("HH:mm:ss");
				if (DateTime.MinValue!=evt.EndTime)
				{
					TimeSpan ts=(evt.EndTime.Subtract(evt.StartTime));
					row[2]=string.Format("{0}h {1}m {2}s",ts.Hours,ts.Minutes,ts.Seconds);
				}
				else
				{
					row[2]="";
				}
				row[3]=evt.Type.ToString();
				row[4]=evt.Category;
				row[5]=evt.Analysis.Analyzer.Name;
				row[6]=evt.Text;

				m_PublishedEvents.Add(evt);

//				switch (evt.Type)
//				{
//					case EventType.Error : 
//					{
//						newItem.ImageIndex=12;
//						break;
//					}
//					case EventType.Warning: 
//					{
//						newItem.ImageIndex=11;
//						break;
//					}
//					default:
//					{
//						newItem.ImageIndex=10;
//						break;
//					}
//				}
				dt.Rows.Add(row);
//				newItem.Selected=true;
//				lvOutput.EnsureVisible(newItem.Index);
			}
			return;
		}

		public void UnPublishEvent(CEvent evt)
		{
			int j=-1;
			j=m_PublishedEvents.IndexOf(evt);
			if (-1!=j)
				dsEvents.Tables["Events"].Rows.RemoveAt(j);
		}

		public void PublishAllEvents()
		{
			UnPublishAllEvents();
			foreach (CEvent evt in m_Events)
				PublishEvent(evt);
		}

		public void UnPublishAllEvents()
		{
			dsEvents.Tables["Events"].Rows.Clear();
			m_PublishedEvents.Clear();
		}
	}
}

