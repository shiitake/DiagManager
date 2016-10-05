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
using System.Diagnostics;
using dotnetCHARTING.WinForms;
using System.Xml;

namespace SQLAnalyzer
{
	/// <summary>
	/// Summary description for fmTL.
	/// </summary>
	public class fmTL : System.Windows.Forms.Form, IAnalysisConsumer, IEventPlotter, ITrendPlotter
	{
		private System.Windows.Forms.StatusBar sbStatus;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem miAutoScaleBreak;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem miLogScale;
		private System.Windows.Forms.MenuItem miAreaChart;
		private System.Windows.Forms.MenuItem miTransparency;
		private System.Windows.Forms.MenuItem miTranPerc0;
		private System.Windows.Forms.MenuItem miTranPerc20;
		private System.Windows.Forms.MenuItem miTranPerc40;
		private System.Windows.Forms.MenuItem miTranPerc60;
		private System.Windows.Forms.MenuItem miTranPerc80;
		private System.Windows.Forms.TabControl tcChart;
		private System.Windows.Forms.TabPage tpChart;
		private System.Windows.Forms.TabPage tpSeriesOptions;
		public dotnetCHARTING.WinForms.Chart chChart;
		private System.Windows.Forms.ListView lvSeries;
		private System.Windows.Forms.ColumnHeader chSeries;
		private System.Windows.Forms.ContextMenu cmSeries;
		private System.Windows.Forms.MenuItem miSelectAll;
		private System.Windows.Forms.MenuItem miSelectNone;
		private System.Windows.Forms.ColumnHeader chColor;
		private System.Windows.Forms.ColumnHeader chMarker;
		private System.Windows.Forms.ColumnHeader chWidth;
		private System.Windows.Forms.ColumnHeader chScale;
		private System.Windows.Forms.ContextMenu cmChart;
		private System.Windows.Forms.MenuItem miHide;
		private System.Windows.Forms.MenuItem miCropLeft;
		private System.Windows.Forms.MenuItem miCropRight;
		private System.Windows.Forms.MenuItem miUncropLeft;
		private System.Windows.Forms.MenuItem miUncropRight;
		private System.Windows.Forms.MenuItem miUncropAll;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem miDays;
		private System.Windows.Forms.MenuItem miHours;
		private System.Windows.Forms.MenuItem miMinutes;
		private System.Windows.Forms.MenuItem miSeconds;
		private System.Windows.Forms.MenuItem miOne;
		private System.Windows.Forms.MenuItem miTwo;
		private System.Windows.Forms.MenuItem miThree;
		private System.Windows.Forms.MenuItem miFour;
		private System.Windows.Forms.MenuItem miFive;
		private System.Windows.Forms.MenuItem miTen;
		private System.Windows.Forms.MenuItem miThirty;
		private System.Windows.Forms.MenuItem miSeven;
		private System.Windows.Forms.MenuItem miXAxisInterval;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public fmTL()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		XmlDocument m_ConfigDoc=null;
		public fmTL(XmlDocument ConfigDoc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			if (null!=ConfigDoc["dsConfig"]["Analysis"])
				m_ConfigDoc = ConfigDoc;

		}


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			dotnetCHARTING.WinForms.LegendBox legendBox1 = new dotnetCHARTING.WinForms.LegendBox();
			dotnetCHARTING.WinForms.LegendEntry legendEntry1 = new dotnetCHARTING.WinForms.LegendEntry();
			dotnetCHARTING.WinForms.LegendEntry legendEntry2 = new dotnetCHARTING.WinForms.LegendEntry();
			dotnetCHARTING.WinForms.ChartArea chartArea1 = new dotnetCHARTING.WinForms.ChartArea();
			dotnetCHARTING.WinForms.Element element1 = new dotnetCHARTING.WinForms.Element();
			dotnetCHARTING.WinForms.LegendEntry legendEntry3 = new dotnetCHARTING.WinForms.LegendEntry();
			dotnetCHARTING.WinForms.Series series1 = new dotnetCHARTING.WinForms.Series();
			dotnetCHARTING.WinForms.LegendEntry legendEntry4 = new dotnetCHARTING.WinForms.LegendEntry();
			this.sbStatus = new System.Windows.Forms.StatusBar();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.miAutoScaleBreak = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.miLogScale = new System.Windows.Forms.MenuItem();
			this.miAreaChart = new System.Windows.Forms.MenuItem();
			this.miTransparency = new System.Windows.Forms.MenuItem();
			this.miTranPerc0 = new System.Windows.Forms.MenuItem();
			this.miTranPerc20 = new System.Windows.Forms.MenuItem();
			this.miTranPerc40 = new System.Windows.Forms.MenuItem();
			this.miTranPerc60 = new System.Windows.Forms.MenuItem();
			this.miTranPerc80 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.miDays = new System.Windows.Forms.MenuItem();
			this.miHours = new System.Windows.Forms.MenuItem();
			this.miMinutes = new System.Windows.Forms.MenuItem();
			this.miSeconds = new System.Windows.Forms.MenuItem();
			this.miXAxisInterval = new System.Windows.Forms.MenuItem();
			this.miOne = new System.Windows.Forms.MenuItem();
			this.miTwo = new System.Windows.Forms.MenuItem();
			this.miThree = new System.Windows.Forms.MenuItem();
			this.miFour = new System.Windows.Forms.MenuItem();
			this.miFive = new System.Windows.Forms.MenuItem();
			this.miSeven = new System.Windows.Forms.MenuItem();
			this.miTen = new System.Windows.Forms.MenuItem();
			this.miThirty = new System.Windows.Forms.MenuItem();
			this.tcChart = new System.Windows.Forms.TabControl();
			this.tpChart = new System.Windows.Forms.TabPage();
			this.chChart = new dotnetCHARTING.WinForms.Chart();
			this.cmChart = new System.Windows.Forms.ContextMenu();
			this.miHide = new System.Windows.Forms.MenuItem();
			this.miCropLeft = new System.Windows.Forms.MenuItem();
			this.miUncropLeft = new System.Windows.Forms.MenuItem();
			this.miCropRight = new System.Windows.Forms.MenuItem();
			this.miUncropRight = new System.Windows.Forms.MenuItem();
			this.miUncropAll = new System.Windows.Forms.MenuItem();
			this.tpSeriesOptions = new System.Windows.Forms.TabPage();
			this.lvSeries = new System.Windows.Forms.ListView();
			this.chSeries = new System.Windows.Forms.ColumnHeader();
			this.chColor = new System.Windows.Forms.ColumnHeader();
			this.chWidth = new System.Windows.Forms.ColumnHeader();
			this.chScale = new System.Windows.Forms.ColumnHeader();
			this.chMarker = new System.Windows.Forms.ColumnHeader();
			this.cmSeries = new System.Windows.Forms.ContextMenu();
			this.miSelectAll = new System.Windows.Forms.MenuItem();
			this.miSelectNone = new System.Windows.Forms.MenuItem();
			this.tcChart.SuspendLayout();
			this.tpChart.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chChart)).BeginInit();
			this.tpSeriesOptions.SuspendLayout();
			this.SuspendLayout();
			// 
			// sbStatus
			// 
			this.sbStatus.Location = new System.Drawing.Point(0, 632);
			this.sbStatus.Name = "sbStatus";
			this.sbStatus.Size = new System.Drawing.Size(800, 22);
			this.sbStatus.TabIndex = 1;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.miAutoScaleBreak,
																					  this.menuItem2,
																					  this.miLogScale,
																					  this.miAreaChart,
																					  this.miTransparency,
																					  this.menuItem3,
																					  this.miXAxisInterval});
			this.menuItem1.Text = "&Chart";
			// 
			// miAutoScaleBreak
			// 
			this.miAutoScaleBreak.Index = 0;
			this.miAutoScaleBreak.Text = "Auto scale break";
			this.miAutoScaleBreak.Click += new System.EventHandler(this.miAutoScaleBreak_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "3-D";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// miLogScale
			// 
			this.miLogScale.Checked = true;
			this.miLogScale.Index = 2;
			this.miLogScale.Text = "Logarithmic scale";
			this.miLogScale.Click += new System.EventHandler(this.miLogScale_Click);
			// 
			// miAreaChart
			// 
			this.miAreaChart.Index = 3;
			this.miAreaChart.Text = "Area chart";
			this.miAreaChart.Click += new System.EventHandler(this.miAreaChart_Click);
			// 
			// miTransparency
			// 
			this.miTransparency.Index = 4;
			this.miTransparency.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						   this.miTranPerc0,
																						   this.miTranPerc20,
																						   this.miTranPerc40,
																						   this.miTranPerc60,
																						   this.miTranPerc80});
			this.miTransparency.Text = "Transparency";
			// 
			// miTranPerc0
			// 
			this.miTranPerc0.Checked = true;
			this.miTranPerc0.Index = 0;
			this.miTranPerc0.RadioCheck = true;
			this.miTranPerc0.Text = "0%";
			this.miTranPerc0.Click += new System.EventHandler(this.miTranPerc0_Click);
			// 
			// miTranPerc20
			// 
			this.miTranPerc20.Index = 1;
			this.miTranPerc20.RadioCheck = true;
			this.miTranPerc20.Text = "20%";
			this.miTranPerc20.Click += new System.EventHandler(this.miTranPerc0_Click);
			// 
			// miTranPerc40
			// 
			this.miTranPerc40.Index = 2;
			this.miTranPerc40.RadioCheck = true;
			this.miTranPerc40.Text = "40%";
			this.miTranPerc40.Click += new System.EventHandler(this.miTranPerc0_Click);
			// 
			// miTranPerc60
			// 
			this.miTranPerc60.Index = 3;
			this.miTranPerc60.RadioCheck = true;
			this.miTranPerc60.Text = "60%";
			this.miTranPerc60.Click += new System.EventHandler(this.miTranPerc0_Click);
			// 
			// miTranPerc80
			// 
			this.miTranPerc80.Index = 4;
			this.miTranPerc80.RadioCheck = true;
			this.miTranPerc80.Text = "80%";
			this.miTranPerc80.Click += new System.EventHandler(this.miTranPerc0_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 5;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.miDays,
																					  this.miHours,
																					  this.miMinutes,
																					  this.miSeconds});
			this.menuItem3.Text = "Time unit";
			// 
			// miDays
			// 
			this.miDays.Index = 0;
			this.miDays.RadioCheck = true;
			this.miDays.Text = "Days";
			this.miDays.Click += new System.EventHandler(this.miDays_Click);
			// 
			// miHours
			// 
			this.miHours.Index = 1;
			this.miHours.RadioCheck = true;
			this.miHours.Text = "Hours";
			this.miHours.Click += new System.EventHandler(this.miHours_Click);
			// 
			// miMinutes
			// 
			this.miMinutes.Index = 2;
			this.miMinutes.RadioCheck = true;
			this.miMinutes.Text = "Minutes";
			this.miMinutes.Click += new System.EventHandler(this.miMinutes_Click);
			// 
			// miSeconds
			// 
			this.miSeconds.Checked = true;
			this.miSeconds.Index = 3;
			this.miSeconds.RadioCheck = true;
			this.miSeconds.Text = "Seconds";
			this.miSeconds.Click += new System.EventHandler(this.miSeconds_Click);
			// 
			// miXAxisInterval
			// 
			this.miXAxisInterval.Index = 6;
			this.miXAxisInterval.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.miOne,
																							this.miTwo,
																							this.miThree,
																							this.miFour,
																							this.miFive,
																							this.miSeven,
																							this.miTen,
																							this.miThirty});
			this.miXAxisInterval.Text = "X-Axis interval";
			// 
			// miOne
			// 
			this.miOne.Index = 0;
			this.miOne.RadioCheck = true;
			this.miOne.Text = "1";
			this.miOne.Click += new System.EventHandler(this.miOne_Click);
			// 
			// miTwo
			// 
			this.miTwo.Index = 1;
			this.miTwo.RadioCheck = true;
			this.miTwo.Text = "2";
			this.miTwo.Click += new System.EventHandler(this.miOne_Click);
			// 
			// miThree
			// 
			this.miThree.Index = 2;
			this.miThree.RadioCheck = true;
			this.miThree.Text = "3";
			this.miThree.Click += new System.EventHandler(this.miOne_Click);
			// 
			// miFour
			// 
			this.miFour.Index = 3;
			this.miFour.RadioCheck = true;
			this.miFour.Text = "4";
			this.miFour.Click += new System.EventHandler(this.miOne_Click);
			// 
			// miFive
			// 
			this.miFive.Checked = true;
			this.miFive.Index = 4;
			this.miFive.RadioCheck = true;
			this.miFive.Text = "5";
			this.miFive.Click += new System.EventHandler(this.miOne_Click);
			// 
			// miSeven
			// 
			this.miSeven.Index = 5;
			this.miSeven.RadioCheck = true;
			this.miSeven.Text = "7";
			this.miSeven.Click += new System.EventHandler(this.miOne_Click);
			// 
			// miTen
			// 
			this.miTen.Index = 6;
			this.miTen.RadioCheck = true;
			this.miTen.Text = "10";
			this.miTen.Click += new System.EventHandler(this.miOne_Click);
			// 
			// miThirty
			// 
			this.miThirty.Index = 7;
			this.miThirty.RadioCheck = true;
			this.miThirty.Text = "30";
			this.miThirty.Click += new System.EventHandler(this.miOne_Click);
			// 
			// tcChart
			// 
			this.tcChart.Controls.Add(this.tpChart);
			this.tcChart.Controls.Add(this.tpSeriesOptions);
			this.tcChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcChart.Location = new System.Drawing.Point(0, 0);
			this.tcChart.Name = "tcChart";
			this.tcChart.SelectedIndex = 0;
			this.tcChart.Size = new System.Drawing.Size(800, 632);
			this.tcChart.TabIndex = 2;
			this.tcChart.SelectedIndexChanged += new System.EventHandler(this.tcChart_SelectedIndexChanged);
			// 
			// tpChart
			// 
			this.tpChart.Controls.Add(this.chChart);
			this.tpChart.Location = new System.Drawing.Point(4, 22);
			this.tpChart.Name = "tpChart";
			this.tpChart.Size = new System.Drawing.Size(792, 606);
			this.tpChart.TabIndex = 0;
			this.tpChart.Text = "Chart";
			// 
			// chChart
			// 
			this.chChart.Application = "";
			this.chChart.Background.Color = System.Drawing.Color.White;
			this.chChart.ContextMenu = this.cmChart;
			this.chChart.DefaultCultureName = "";
			this.chChart.Dock = System.Windows.Forms.DockStyle.Fill;
			legendBox1.CornerBottomRight = dotnetCHARTING.WinForms.BoxCorner.Cut;
			legendBox1.DefaultEntry = legendEntry1;
			legendEntry2.Name = "Name";
			legendEntry2.SortOrder = -1;
			legendEntry2.Value = "Value";
			legendEntry2.Visible = false;
			legendBox1.HeaderEntry = legendEntry2;
			legendBox1.Padding = 4;
			legendBox1.Position = dotnetCHARTING.WinForms.LegendBoxPosition.Top;
			legendBox1.Visible = true;
			this.chChart.LegendBox = legendBox1;
			this.chChart.Location = new System.Drawing.Point(0, 0);
			this.chChart.Name = "chChart";
			this.chChart.NoDataLabel.Text = "No Data";
			this.chChart.Size = new System.Drawing.Size(792, 606);
			this.chChart.StartDateOfYear = new System.DateTime(((long)(0)));
			this.chChart.TabIndex = 1;
			this.chChart.TempDirectory = "C:\\DOCUME~1\\KENNET~1.NOR\\LOCALS~1\\Temp\\";
			this.chChart.TitleBox.Position = dotnetCHARTING.WinForms.TitleBoxPosition.Left;
			this.chChart.TitleBox.Visible = true;
			this.chChart.ToolTipTemplate = "";
			element1.LegendEntry = legendEntry3;
			element1.XAxisTick = null;
			element1.YAxisTick = null;
			chartArea1.DefaultElement = element1;
			element1.LegendEntry = legendEntry3;
			element1.XAxisTick = null;
			element1.YAxisTick = null;
			series1.DefaultElement = element1;
			series1.LegendEntry = legendEntry4;
			series1.Type = dotnetCHARTING.WinForms.SeriesType.Column;
			chartArea1.DefaultSeries = series1;
			chartArea1.LegendBox = null;
			chartArea1.StartDateOfYear = new System.DateTime(((long)(0)));
			this.chChart.VolumeArea = chartArea1;
			this.chChart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chChart_MouseUp);
			// 
			// cmChart
			// 
			this.cmChart.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.miHide,
																					this.miCropLeft,
																					this.miUncropLeft,
																					this.miCropRight,
																					this.miUncropRight,
																					this.miUncropAll});
			this.cmChart.Popup += new System.EventHandler(this.cmChart_Popup);
			// 
			// miHide
			// 
			this.miHide.Index = 0;
			this.miHide.Text = "Hide";
			this.miHide.Click += new System.EventHandler(this.miHide_Click);
			// 
			// miCropLeft
			// 
			this.miCropLeft.Index = 1;
			this.miCropLeft.Text = "Zoom in left";
			this.miCropLeft.Click += new System.EventHandler(this.miCropLeft_Click);
			// 
			// miUncropLeft
			// 
			this.miUncropLeft.Enabled = false;
			this.miUncropLeft.Index = 2;
			this.miUncropLeft.Text = "Unzoom left";
			this.miUncropLeft.Click += new System.EventHandler(this.miUncropLeft_Click);
			// 
			// miCropRight
			// 
			this.miCropRight.Index = 3;
			this.miCropRight.Text = "Zoom in right";
			this.miCropRight.Click += new System.EventHandler(this.miCropRight_Click);
			// 
			// miUncropRight
			// 
			this.miUncropRight.Enabled = false;
			this.miUncropRight.Index = 4;
			this.miUncropRight.Text = "Unzoom right";
			this.miUncropRight.Click += new System.EventHandler(this.miUncropRight_Click);
			// 
			// miUncropAll
			// 
			this.miUncropAll.Enabled = false;
			this.miUncropAll.Index = 5;
			this.miUncropAll.Text = "Unzoom all";
			this.miUncropAll.Click += new System.EventHandler(this.miUncropAll_Click);
			// 
			// tpSeriesOptions
			// 
			this.tpSeriesOptions.Controls.Add(this.lvSeries);
			this.tpSeriesOptions.Location = new System.Drawing.Point(4, 22);
			this.tpSeriesOptions.Name = "tpSeriesOptions";
			this.tpSeriesOptions.Size = new System.Drawing.Size(792, 606);
			this.tpSeriesOptions.TabIndex = 1;
			this.tpSeriesOptions.Text = "Series Options";
			// 
			// lvSeries
			// 
			this.lvSeries.CheckBoxes = true;
			this.lvSeries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					   this.chSeries,
																					   this.chColor,
																					   this.chWidth,
																					   this.chScale,
																					   this.chMarker});
			this.lvSeries.ContextMenu = this.cmSeries;
			this.lvSeries.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvSeries.Location = new System.Drawing.Point(0, 0);
			this.lvSeries.Name = "lvSeries";
			this.lvSeries.Size = new System.Drawing.Size(792, 606);
			this.lvSeries.TabIndex = 0;
			this.lvSeries.View = System.Windows.Forms.View.Details;
			// 
			// chSeries
			// 
			this.chSeries.Text = "Series";
			this.chSeries.Width = 338;
			// 
			// chColor
			// 
			this.chColor.Text = "Color";
			// 
			// chWidth
			// 
			this.chWidth.Text = "Width";
			// 
			// chScale
			// 
			this.chScale.Text = "Scale";
			// 
			// chMarker
			// 
			this.chMarker.Text = "Marker";
			// 
			// cmSeries
			// 
			this.cmSeries.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.miSelectAll,
																					 this.miSelectNone});
			// 
			// miSelectAll
			// 
			this.miSelectAll.Index = 0;
			this.miSelectAll.Text = "Select &All";
			this.miSelectAll.Click += new System.EventHandler(this.miSelectAll_Click);
			// 
			// miSelectNone
			// 
			this.miSelectNone.Index = 1;
			this.miSelectNone.Text = "&Unselect All";
			this.miSelectNone.Click += new System.EventHandler(this.miSelectNone_Click);
			// 
			// fmTL
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(800, 654);
			this.Controls.Add(this.tcChart);
			this.Controls.Add(this.sbStatus);
			this.Menu = this.mainMenu1;
			this.Name = "fmTL";
			this.Text = "Timeline";
			this.Resize += new System.EventHandler(this.fmTL_Resize);
			this.Load += new System.EventHandler(this.fmTL_Load);
			this.tcChart.ResumeLayout(false);
			this.tpChart.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chChart)).EndInit();
			this.tpSeriesOptions.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		Color[] SeriesColors = new Color[] {Color.Maroon, 
											   Color.Blue,
											   Color.Green,
											   Color.Orange,
											   Color.ForestGreen,
											   Color.Purple,
											   Color.Red,
											   Color.Yellow,
											   Color.Navy,
											   Color.Magenta,
											   Color.Black,
											   Color.CadetBlue,
											   Color.Fuchsia,
											   Color.Brown,
											   Color.White,
											   Color.Violet
										   };
		Series AddSeries(CTrend trend, int index)
		{
			ListViewItem itm=null;
			//Check to see if it already exists
			if (null!=lvSeries.Items) 
			{
				foreach (ListViewItem i in lvSeries.Items)
					if (i.Text==trend.Name)
						itm=i;
			}
			if (null==itm) 
			{
				itm = new ListViewItem(trend.Name);
				lvSeries.Items.Add(itm);
				itm.Tag=trend;
			}

			itm.Checked=trend.Display;
			if (!trend.Display)  //Just add the list item for guys who don't want to be displayed
				return null;

			Series s = new Series();
			s.DefaultElement.ToolTip="%YValue";
			s.Name = trend.Name;

			/*
				s.YAxis = new Axis();
				s.YAxis.ScaleRange.ValueLow=1;
				s.YAxis.ScaleRange.ValueHigh=100;
				s.YAxis.Clear();
				*/

//			s.Line = new Line(SeriesColors[index % SeriesColors.Length],1);

			trend.ChartObject = s;

			if (!(trend is CDBTrend))
			{
				foreach (CTrendPoint point in trend.Points)
				{
					TrendElement e = new TrendElement();
					e.TrendPoint=point;
					e.XDateTime = point.Time;
					e.YValue = point.Value;
					s.Elements.Add(e);
				}
			}
			else
			{
				CDBTrend dbt = (trend as CDBTrend);
				s.ConnectionString=dbt.ConnectionString;
				s.SqlStatement=dbt.QueryStr;
			}
			return s;
		}

		public void AnalysisComplete(CAnalysis Analysis)
		{
			// Set the title.
			//			chChart.Title="Analysis";

			// set the x axis clustering
			//						chChart.ChartArea.XAxis.ClusterColumns = true;

			// Set a default transparency
			//			chChart.DefaultSeries.DefaultElement.Transparency = 20;


			// Set the default series type
			chChart.DefaultSeries.EmptyElement.Mode = EmptyElementMode.Ignore;
			chChart.TitleBox.Position = TitleBoxPosition.FullWithLegend;
			chChart.TitleBox.Label.Alignment = StringAlignment.Center;
			chChart.DefaultSeries.Type = SeriesType.Line;
			//			chChart.DefaultSeries.DefaultElement.Transparency = 25;
			//			chChart.DefaultSeries.Line = new Line(Color.Blue,8);

			// Set the x axis label
			chChart.ChartArea.XAxis.Label.Text="Date/Time";

			// Set the y axis label
			chChart.ChartArea.YAxis.Label.Text="";

			chChart.XAxis.TimeInterval =TimeInterval.Seconds;
			chChart.XAxis.TimeIntervalAdvanced.Multiplier = 5;
			chChart.XAxis.Scale = dotnetCHARTING.WinForms.Scale.Time;

			chChart.LegendBox.Template="%icon%name";
			// Set the directory where the images will be stored.
			chChart.TempDirectory="temp";

			SeriesCollection SC = new SeriesCollection();
			CAnalysis TAnalysis=(CAnalysis)Analysis;
			chChart.DefaultSeries.DefaultElement.ToolTip="%YValue";

			chChart.YAxis.Scale=dotnetCHARTING.WinForms.Scale.Logarithmic;

			/*
			System.Windows.Forms.Button btBack;

			btBack = new System.Windows.Forms.Button();
			 
			btBack.Location = new System.Drawing.Point(400,0);
			btBack.Name = "btBack";
			btBack.TabIndex = 0;
			btBack.Text = "Back";

			btBack.Size = new System.Drawing.Size(100, 23);
			
			btBack.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));

			btBack.Click += new System.EventHandler(this.btBack_Click);
			
			chChart.Controls.AddRange(new System.Windows.Forms.Control[] {btBack});
			
			chChart.DrillDownChain="Hours, Minutes,Seconds";
*/

			/*
						foreach (CEvent evt in TAnalysis.Events)
						{
							if (!evt.Display)
								continue;  //Non-display -- skip

							if (DateTime.MinValue==evt.StartTime)
								continue;  //Not time-based -- skip

							if ((DateTime.MinValue!=evt.EndTime) && (!(evt.StartTime.Equals(evt.EndTime))))
							{
								Line ln = new Line();
								AxisMarker am2 = new AxisMarker("Start of "+evt.Text,ln,evt.StartTime);
								chChart.XAxis.Markers.Add(am2);
								am2 = new AxisMarker("End of "+evt.Text,new Line(ln.Color),evt.EndTime);
								chChart.XAxis.Markers.Add(am2);
							}
							else
							{
								AxisMarker am2 = new AxisMarker(evt.Text,new Line(Color.Red),evt.StartTime);
								chChart.XAxis.Markers.Add(am2);
							}
						}
			
			*/

			int i = 0;
			foreach (CTrend trend in TAnalysis.Trends)
			{
				Series s = AddSeries(trend,i++);
				if (null!=s)
					SC.Add(s);
			}
			chChart.SeriesCollection.Add(SC);
			chChart.RefreshChart();
		}

		private void btBack_Click(object sender, System.EventArgs e)
		{

			chChart.DrilldownBack();
			chChart.RefreshChart();
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

		private void fmTL_Resize(object sender, System.EventArgs e)
		{
			chChart.RefreshChart();
		}

		private void chChart_DoubleClick(object sender, System.EventArgs e)
		{
		}

		private void chChart_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button==MouseButtons.Right)
				return;

			Point myP = new Point(e.X, e.Y);
			HitTestInfo obj= ((Chart)sender).HitTest(myP);
			if (!(obj.Object is TrendElement)) 
			{
				return;
			}
			TrendElement elem = (TrendElement)obj.Object;

			if (Control.ModifierKeys == Keys.Control) 
			{
				ZoomLeft(chChart.PointToClient(MousePosition));
			}
			else if (Control.ModifierKeys==Keys.Alt)
			{
				ZoomRight(chChart.PointToClient(MousePosition));
			}
			else 
			{
				if (null!=elem.TrendPoint)
					elem.TrendPoint.DrillThrough();
			}
			
		}

		private void miAutoScaleBreak_Click(object sender, System.EventArgs e)
		{
			(sender as MenuItem).Checked=!(sender as MenuItem).Checked;
			chChart.YAxis.SmartScaleBreak=(sender as MenuItem).Checked;  
			chChart.RefreshChart();
		}

		System.Windows.Forms.ItemCheckEventHandler m_ItemCheck;

		private void fmTL_Load(object sender, System.EventArgs e)
		{
			chChart.Application="44bY0n02TcYPbS9Ewagh4Y6T/Uh80eOyREi6taci8ysUacpvRBHhci54Iy6JVT9hjjpubKlALEutB7U00q44Jg==";
			m_ItemCheck=new System.Windows.Forms.ItemCheckEventHandler(this.lvSeries_ItemCheck);
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			(sender as MenuItem).Checked=!(sender as MenuItem).Checked;
			chChart.Use3D=(sender as MenuItem).Checked;
			chChart.RefreshChart();
		}

		private void miLogScale_Click(object sender, System.EventArgs e)
		{
			(sender as MenuItem).Checked=!(sender as MenuItem).Checked;
			if ((sender as MenuItem).Checked) 
				chChart.YAxis.Scale=dotnetCHARTING.WinForms.Scale.Logarithmic;
			else
				chChart.YAxis.Scale=dotnetCHARTING.WinForms.Scale.Normal;
			chChart.RefreshChart();
		}

		private void miAreaChart_Click(object sender, System.EventArgs e)
		{
			(sender as MenuItem).Checked=!(sender as MenuItem).Checked;
			if ((sender as MenuItem).Checked) 
			{
				chChart.DefaultSeries.Type = SeriesType.AreaLine;
			}
			else 
			{
				chChart.DefaultSeries.Type = SeriesType.Line;
			}
			chChart.RefreshChart();
			
		}

		private void miTranPerc0_Click(object sender, System.EventArgs e)
		{
			foreach (MenuItem m in miTransparency.MenuItems)
				m.Checked=false;
			MenuItem mi=(sender as MenuItem);
			mi.Checked=true;
			string[] tokens=mi.Text.Split("%".ToCharArray());
			int i=int.Parse(tokens[0]);
			chChart.DefaultSeries.DefaultElement.Transparency = i;
			chChart.RefreshChart();
		}

		bool m_bItemCheckHooked=false;

		public bool UnhookItemCheckHandler(bool bUnhookHandler)
		{
			bool bWasHooked=false;
			if ((bUnhookHandler) && (m_bItemCheckHooked)) 
			{
				lvSeries.ItemCheck -= m_ItemCheck;
				m_bItemCheckHooked=false;
				bWasHooked=true;
			}
			return bWasHooked;
		}

		public bool HookItemCheckHandler()
		{
			lvSeries.ItemCheck += m_ItemCheck;
			m_bItemCheckHooked=true;
			return true;
		}

		public virtual void CheckSeriesItem(CTrend trend, bool bUnhookHandler)
		{
			bool bRehook=UnhookItemCheckHandler(bUnhookHandler);

			try
			{
				foreach (ListViewItem itm in lvSeries.Items)
				{
					if (itm.Tag==trend) 
					{
						itm.Checked=true;
						break;
					}
				}
			}
			finally
			{
				if (bRehook)
					HookItemCheckHandler();
			}
		}

		public virtual void CheckSeriesItem(CTrend trend)
		{
			CheckSeriesItem(trend,true);
		}

		public virtual void UnCheckSeriesItem(CTrend trend, bool bUnhookHandler)
		{
			bool bRehook=UnhookItemCheckHandler(bUnhookHandler);


			try
			{
				foreach (ListViewItem itm in lvSeries.Items)
				{
					if (itm.Tag==trend) 
					{
						itm.Checked=false;
						break;
					}
				}
			}
			finally
			{
				if (bRehook)
					HookItemCheckHandler();
			}
		}

		public virtual void UnCheckSeriesItem(CTrend trend)
		{
			UnCheckSeriesItem(trend,true);
		}

		DateTime m_StartDate=new DateTime(9998,12,31);
		DateTime m_EndDate=new DateTime(1753,1,1);
		public virtual void ShowTrend(CTrend trend, bool bUnhookHandler)
		{
			CheckSeriesItem(trend,bUnhookHandler);
			trend.Display=true;
			Series s = chChart.SeriesCollection.GetSeries(trend.Name);
			if (null==s)
				chChart.SeriesCollection.Add(AddSeries(trend,chChart.SeriesCollection.Count));
			CTrendPoints points = (trend.Points as CTrendPoints);
			if (points.StartDate<m_StartDate)
			{
				m_StartDate=points.StartDate;
			}
			if (points.EndDate>m_EndDate)
			{
				m_EndDate=points.EndDate;
			}
			chChart.RefreshChart();
		}
		public virtual void ShowTrend(CTrend trend)
		{
			ShowTrend(trend,true);
		}
		public virtual void HideTrend(CTrend trend, bool bUnhookHandler)
		{
			UnCheckSeriesItem(trend,bUnhookHandler);
			trend.Display=false;
			Series s = chChart.SeriesCollection.GetSeries(trend.Name);
			if (null!=s) 
			{
				chChart.SeriesCollection.Remove(s);
				chChart.RefreshChart();
			}
		}
		public virtual void HideTrend(CTrend trend)
		{
			HideTrend(trend,true);
		}
		public virtual void HideAllTrends()
		{
			m_StartDate=new DateTime(9998,12,31);
			m_EndDate=new DateTime(1753,1,1);
			foreach(ListViewItem itm in lvSeries.Items)
			{
				if (null==itm.Tag) continue;
				HideTrend(((CTrend)itm.Tag));
			}
			chChart.RefreshChart();
		}
		private void lvSeries_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			bool bRehook=UnhookItemCheckHandler(true);
			try
			{
				ListViewItem itm = lvSeries.Items[e.Index];

				CTrend trend = (CTrend)itm.Tag;

				//Event occurs _before_ check is toggled, so logic is reversed
				if (itm.Checked) 
				{
					HideTrend(trend,false);
				}
				else
				{
					ShowTrend(trend,false);
				}
			}
			finally 
			{
				if (bRehook)
					HookItemCheckHandler();
			}
		}

		private void tcChart_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (0==tcChart.SelectedIndex)
				UnhookItemCheckHandler(true);
			else
				HookItemCheckHandler();
		
		}

		private void ToggleAll(ListView lv, bool bState)
		{
			foreach (ListViewItem itm in lv.Items) 
			{
				itm.Checked=bState;
			}
		}

		private void miSelectAll_Click(object sender, System.EventArgs e)
		{
			Debug.Assert(cmSeries.SourceControl is ListView);
			ToggleAll((ListView)cmSeries.SourceControl,true);
		}

		private void miSelectNone_Click(object sender, System.EventArgs e)
		{
			Debug.Assert(cmSeries.SourceControl is ListView);
			ToggleAll((ListView)cmSeries.SourceControl,false);
		}
		public virtual void PlotEvent(CEvent Event) 
		{
			if (!Event.Display)
				return;  //Non-display -- skip

			if (DateTime.MinValue==Event.StartTime)
				return;  //Not time-based -- skip

			if ((DateTime.MinValue!=Event.EndTime) && (!(Event.StartTime.Equals(Event.EndTime))))
			{
				Line ln = new Line();
				AxisMarker am2 = new AxisMarker("Start of "+Event.Text,ln,Event.StartTime);
				chChart.XAxis.Markers.Add(am2);
				am2 = new AxisMarker("End of "+Event.Text,new Line(ln.Color),Event.EndTime);
				chChart.XAxis.Markers.Add(am2);
			}
			else
			{
				AxisMarker am2 = new AxisMarker(Event.Text,new Line(Color.Red),Event.StartTime);
				chChart.XAxis.Markers.Add(am2);
			}
			chChart.RefreshChart();
		}
		public virtual void ClearEvent(CEvent Event) 
		{
			if (!Event.Display)
				return;  //Non-display -- skip

			if (DateTime.MinValue==Event.StartTime)
				return;  //Not time-based -- skip

			if ((DateTime.MinValue!=Event.EndTime) && (!(Event.StartTime.Equals(Event.EndTime))))
			{
				foreach (AxisMarker mk in chChart.XAxis.Markers)
				{
					if (mk.Label.Text=="Start of "+Event.Text)
						chChart.XAxis.Markers.Remove(mk);
					if (mk.Label.Text=="End of "+Event.Text)
						chChart.XAxis.Markers.Remove(mk);
				}
			}
			else
			{
				foreach (AxisMarker mk in chChart.XAxis.Markers)
				{
					if (mk.Label.Text==Event.Text)
						chChart.XAxis.Markers.Remove(mk);
				}
			}
			chChart.RefreshChart();
		}
		public virtual void ClearAllEvents()
		{
			chChart.XAxis.Markers.Clear();
			chChart.RefreshChart();
		}

		Point m_LastPosition;
		private void miHide_Click(object sender, System.EventArgs e)
		{
			HitTestInfo obj= chChart.HitTest(m_LastPosition);
			if ((null==obj) || (!(obj.Object is TrendElement))) 
			{
				return;
			}
			TrendElement elem = (TrendElement)obj.Object;

			HideTrend(elem.TrendPoint.Trend);
		}

		private void cmChart_Popup(object sender, System.EventArgs e)
		{
			m_LastPosition = chChart.PointToClient(MousePosition);
			HitTestInfo obj= chChart.HitTest(m_LastPosition);
			miHide.Enabled=(obj.Object is TrendElement);
		}

		public void UpdateDocFromUI()
		{
			if (null!=m_ConfigDoc)
			{
				m_ConfigDoc["dsConfig"]["Analysis"]["Trends"].InnerText="";
				foreach (ListViewItem itm in lvSeries.Items)
				{
					XmlNode childnode=m_ConfigDoc.CreateElement("Trend");

					XmlAttribute newAttr = m_ConfigDoc.CreateAttribute("name");
					newAttr.Value = itm.Text;
					childnode.Attributes.SetNamedItem(newAttr);

					XmlAttribute newAttr2 = m_ConfigDoc.CreateAttribute("selected");
					newAttr2.Value = itm.Checked.ToString().ToLower();
					childnode.Attributes.SetNamedItem(newAttr2);

					m_ConfigDoc["dsConfig"]["Analysis"]["Trends"].AppendChild(childnode);				

				}

			}
		}

		public void UpdateUIFromDoc()
		{
			if (null!=m_ConfigDoc)
			{
				Application.DoEvents();
				foreach (XmlNode node in m_ConfigDoc["dsConfig"]["Analysis"]["Trends"].ChildNodes)
				{
					string strName=node.Attributes["name"].Value;
					foreach (ListViewItem itm in lvSeries.Items)
					{
						if (itm.Text==strName)  
						{
							if (Convert.ToBoolean(node.Attributes["selected"].Value))
								ShowTrend((CTrend)itm.Tag);
							else
								HideTrend((CTrend)itm.Tag);
						}
					}
				}
			}
		}

		private void ZoomLeft(Point Pos)
		{
			HitTestInfo obj= chChart.HitTest(Pos);
			if ((null==obj) || (!(obj.Object is TrendElement))) 
			{
				return;
			}
			TrendElement elem = (TrendElement)obj.Object;
			chChart.XAxis.ScaleRange = new ScaleRange(elem.TrendPoint.Time,chChart.XAxis.ScaleRange.ValueHigh);
			miUncropLeft.Enabled=true;
			miUncropAll.Enabled=true;
		}

		private void miCropLeft_Click(object sender, System.EventArgs e)
		{
			ZoomLeft(m_LastPosition);
		}

		private void ZoomRight(Point Pos)
		{
			HitTestInfo obj= chChart.HitTest(Pos);
			if ((null==obj) || (!(obj.Object is TrendElement))) 
			{
				return;
			}
			TrendElement elem = (TrendElement)obj.Object;
			chChart.XAxis.ScaleRange = new ScaleRange(chChart.XAxis.ScaleRange.ValueLow,elem.TrendPoint.Time);
			miUncropRight.Enabled=true;
			miUncropAll.Enabled=true;
		}

		private void miCropRight_Click(object sender, System.EventArgs e)
		{
			ZoomRight(m_LastPosition);
		}

		private void miUncropLeft_Click(object sender, System.EventArgs e)
		{
			chChart.XAxis.ScaleRange = new ScaleRange(m_StartDate,chChart.XAxis.ScaleRange.ValueHigh);
			miUncropLeft.Enabled=false;
		}

		private void miUncropRight_Click(object sender, System.EventArgs e)
		{
			chChart.XAxis.ScaleRange = new ScaleRange(chChart.XAxis.ScaleRange.ValueLow,m_EndDate);
			miUncropRight.Enabled=false;
		}

		private void miUncropAll_Click(object sender, System.EventArgs e)
		{
			chChart.XAxis.ScaleRange = new ScaleRange(m_StartDate,m_EndDate);
			chChart.RefreshChart();
			miUncropLeft.Enabled=false;
			miUncropRight.Enabled=false;
			miUncropAll.Enabled=false;
		}

		private void miDays_Click(object sender, System.EventArgs e)
		{
			chChart.XAxis.TimeInterval=TimeInterval.Days;
		}

		private void miHours_Click(object sender, System.EventArgs e)
		{
			chChart.XAxis.TimeInterval=TimeInterval.Hours;
		}

		private void miMinutes_Click(object sender, System.EventArgs e)
		{
			chChart.XAxis.TimeInterval=TimeInterval.Minutes;
		}

		private void miSeconds_Click(object sender, System.EventArgs e)
		{
			chChart.XAxis.TimeInterval=TimeInterval.Seconds;
		}

		private void miOne_Click(object sender, System.EventArgs e)
		{
			foreach (MenuItem mi in this.miXAxisInterval.MenuItems)
				mi.Checked=false;
			MenuItem selItem=(sender as MenuItem);
			selItem.Checked=true;
			chChart.XAxis.TimeIntervalAdvanced.Multiplier=Convert.ToInt32(selItem.Text);
			chChart.RefreshChart();
		}


	}
	class TrendElement : Element
	{
		public CTrendPoint TrendPoint;
	}


}


