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
using System.Xml;

namespace SQLAnalyzer
{
	/// <summary>
	/// Summary description for fmAnalysisParent.
	/// </summary>
	public class fmAnalysisParent : System.Windows.Forms.Form, IAnalysisHost
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.TreeView tvContents;
		private System.Windows.Forms.Splitter splContents;
		private System.Windows.Forms.Button btShrink;
		private System.Windows.Forms.Panel paContents;
		private System.Windows.Forms.Splitter splBottom;
		private System.Windows.Forms.TabControl tcSummary;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Button bt_v_Shrink;
		private System.Windows.Forms.ColumnHeader chAnalyzer;
		private System.Windows.Forms.ColumnHeader chResult;
		private System.Windows.Forms.ListView lvSummary;
		private System.Windows.Forms.ImageList imGlyphs;
		private System.Windows.Forms.Panel paSummary;
		private System.Windows.Forms.MenuItem miSaveView;
		private System.Windows.Forms.SaveFileDialog sd_Cfg;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.ContextMenu cmSummary;
		private System.Windows.Forms.MenuItem miCopy;
		private System.ComponentModel.IContainer components;

		public fmAnalysisParent()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		IShowProgress m_ShowProgress;
		XmlDocument m_ConfigDoc=null;
		fmMain m_MainForm;
		public fmAnalysisParent(fmMain MainForm, XmlDocument ConfigDoc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			m_ShowProgress=MainForm;
			m_MainForm=MainForm;
			if (null!=ConfigDoc["dsConfig"]["Analysis"])
				m_ConfigDoc = ConfigDoc;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(fmAnalysisParent));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.miSaveView = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.paContents = new System.Windows.Forms.Panel();
			this.btShrink = new System.Windows.Forms.Button();
			this.tvContents = new System.Windows.Forms.TreeView();
			this.splContents = new System.Windows.Forms.Splitter();
			this.paSummary = new System.Windows.Forms.Panel();
			this.bt_v_Shrink = new System.Windows.Forms.Button();
			this.tcSummary = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.lvSummary = new System.Windows.Forms.ListView();
			this.chAnalyzer = new System.Windows.Forms.ColumnHeader();
			this.chResult = new System.Windows.Forms.ColumnHeader();
			this.cmSummary = new System.Windows.Forms.ContextMenu();
			this.miCopy = new System.Windows.Forms.MenuItem();
			this.imGlyphs = new System.Windows.Forms.ImageList(this.components);
			this.splBottom = new System.Windows.Forms.Splitter();
			this.sd_Cfg = new System.Windows.Forms.SaveFileDialog();
			this.paContents.SuspendLayout();
			this.paSummary.SuspendLayout();
			this.tcSummary.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem2});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.miSaveView});
			this.menuItem1.Text = "&File";
			// 
			// miSaveView
			// 
			this.miSaveView.Index = 0;
			this.miSaveView.Text = "&Save View";
			this.miSaveView.Click += new System.EventHandler(this.miSaveView_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem4,
																					  this.menuItem3,
																					  this.menuItem5,
																					  this.menuItem6});
			this.menuItem2.Text = "&Window";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 0;
			this.menuItem4.Text = "&Cascade";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "Tile &Horizontally";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 2;
			this.menuItem5.Text = "Tile &Vertically";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 3;
			this.menuItem6.Text = "&Default View";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// paContents
			// 
			this.paContents.Controls.Add(this.btShrink);
			this.paContents.Controls.Add(this.tvContents);
			this.paContents.Dock = System.Windows.Forms.DockStyle.Left;
			this.paContents.Location = new System.Drawing.Point(0, 0);
			this.paContents.Name = "paContents";
			this.paContents.Size = new System.Drawing.Size(200, 441);
			this.paContents.TabIndex = 1;
			this.paContents.Resize += new System.EventHandler(this.paContents_Resize);
			// 
			// btShrink
			// 
			this.btShrink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btShrink.BackColor = System.Drawing.SystemColors.Window;
			this.btShrink.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btShrink.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(2)));
			this.btShrink.Location = new System.Drawing.Point(176, 1);
			this.btShrink.Name = "btShrink";
			this.btShrink.Size = new System.Drawing.Size(24, 24);
			this.btShrink.TabIndex = 1;
			this.btShrink.Text = "á";
			this.btShrink.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btShrink.Click += new System.EventHandler(this.btShrink_Click);
			// 
			// tvContents
			// 
			this.tvContents.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvContents.ImageIndex = -1;
			this.tvContents.Location = new System.Drawing.Point(0, 0);
			this.tvContents.Name = "tvContents";
			this.tvContents.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																				   new System.Windows.Forms.TreeNode("Table of Contents")});
			this.tvContents.SelectedImageIndex = -1;
			this.tvContents.Size = new System.Drawing.Size(200, 441);
			this.tvContents.TabIndex = 0;
			this.tvContents.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvContents_AfterSelect);
			// 
			// splContents
			// 
			this.splContents.Location = new System.Drawing.Point(200, 0);
			this.splContents.Name = "splContents";
			this.splContents.Size = new System.Drawing.Size(3, 441);
			this.splContents.TabIndex = 2;
			this.splContents.TabStop = false;
			// 
			// paSummary
			// 
			this.paSummary.BackColor = System.Drawing.SystemColors.Control;
			this.paSummary.Controls.Add(this.bt_v_Shrink);
			this.paSummary.Controls.Add(this.tcSummary);
			this.paSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.paSummary.Location = new System.Drawing.Point(203, 313);
			this.paSummary.Name = "paSummary";
			this.paSummary.Size = new System.Drawing.Size(549, 128);
			this.paSummary.TabIndex = 4;
			this.paSummary.Resize += new System.EventHandler(this.paSummary_Resize);
			// 
			// bt_v_Shrink
			// 
			this.bt_v_Shrink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bt_v_Shrink.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.bt_v_Shrink.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(2)));
			this.bt_v_Shrink.Location = new System.Drawing.Point(521, 1);
			this.bt_v_Shrink.Name = "bt_v_Shrink";
			this.bt_v_Shrink.Size = new System.Drawing.Size(24, 22);
			this.bt_v_Shrink.TabIndex = 0;
			this.bt_v_Shrink.Text = "ä";
			this.bt_v_Shrink.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.bt_v_Shrink.Click += new System.EventHandler(this.bt_v_Shrink_Click);
			// 
			// tcSummary
			// 
			this.tcSummary.Controls.Add(this.tabPage1);
			this.tcSummary.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcSummary.ItemSize = new System.Drawing.Size(55, 22);
			this.tcSummary.Location = new System.Drawing.Point(0, 0);
			this.tcSummary.Name = "tcSummary";
			this.tcSummary.SelectedIndex = 0;
			this.tcSummary.Size = new System.Drawing.Size(549, 128);
			this.tcSummary.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.lvSummary);
			this.tabPage1.Location = new System.Drawing.Point(4, 26);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(541, 98);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Summary";
			// 
			// lvSummary
			// 
			this.lvSummary.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.chAnalyzer,
																						this.chResult});
			this.lvSummary.ContextMenu = this.cmSummary;
			this.lvSummary.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvSummary.HideSelection = false;
			this.lvSummary.Location = new System.Drawing.Point(0, 0);
			this.lvSummary.Name = "lvSummary";
			this.lvSummary.Size = new System.Drawing.Size(541, 98);
			this.lvSummary.SmallImageList = this.imGlyphs;
			this.lvSummary.TabIndex = 2;
			this.lvSummary.View = System.Windows.Forms.View.Details;
			this.lvSummary.SelectedIndexChanged += new System.EventHandler(this.lvSummary_SelectedIndexChanged);
			// 
			// chAnalyzer
			// 
			this.chAnalyzer.Text = "Analyzer";
			this.chAnalyzer.Width = 120;
			// 
			// chResult
			// 
			this.chResult.Text = "Result";
			this.chResult.Width = 400;
			// 
			// cmSummary
			// 
			this.cmSummary.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.miCopy});
			this.cmSummary.Popup += new System.EventHandler(this.cmSummary_Popup);
			// 
			// miCopy
			// 
			this.miCopy.Index = 0;
			this.miCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
			this.miCopy.Text = "&Copy to clipboard";
			this.miCopy.Click += new System.EventHandler(this.miCopy_Click);
			// 
			// imGlyphs
			// 
			this.imGlyphs.ImageSize = new System.Drawing.Size(16, 16);
			this.imGlyphs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imGlyphs.ImageStream")));
			this.imGlyphs.TransparentColor = System.Drawing.SystemColors.Window;
			// 
			// splBottom
			// 
			this.splBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splBottom.Location = new System.Drawing.Point(203, 310);
			this.splBottom.Name = "splBottom";
			this.splBottom.Size = new System.Drawing.Size(549, 3);
			this.splBottom.TabIndex = 5;
			this.splBottom.TabStop = false;
			// 
			// sd_Cfg
			// 
			this.sd_Cfg.DefaultExt = "XML";
			this.sd_Cfg.FileName = "MyConfiguration.xml";
			this.sd_Cfg.Filter = "XML configuration files (*.xml)|*.xml|All files(*.*)|*.*";
			this.sd_Cfg.InitialDirectory = ".\\Configurations";
			this.sd_Cfg.RestoreDirectory = true;
			// 
			// fmAnalysisParent
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(752, 441);
			this.Controls.Add(this.splBottom);
			this.Controls.Add(this.paSummary);
			this.Controls.Add(this.splContents);
			this.Controls.Add(this.paContents);
			this.IsMdiContainer = true;
			this.Menu = this.mainMenu1;
			this.Name = "fmAnalysisParent";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SQL Nexus BETA 1 - Analysis Details";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.fmAnalysisParent_Load);
			this.paContents.ResumeLayout(false);
			this.paSummary.ResumeLayout(false);
			this.tcSummary.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			LayoutMdi(MdiLayout.Cascade);
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			LayoutMdi(MdiLayout.TileVertical);
		}

		ArrayList m_Consumers = new ArrayList();

		#region IAnalysisConsumer Members

		public ArrayList Consumers
		{
			get
			{
				return m_Consumers;
			}
			set
			{
				m_Consumers=value;
			}
		}

		public int FindNode(TreeNodeCollection Nodes, string NodeName)
		{
			int i=-1;
			foreach (TreeNode n in Nodes) 
			{
				if (NodeName==n.Text)
					i=n.Index;
			}
			return i;
		}

		public void RegisterChildForm(Form ChildForm)
		{
			int i=FindNode(tvContents.Nodes[0].Nodes,ChildForm.Text);
			//Don't allow redundant registration
			if (-1==i) 
			{
				ChildForm.MdiParent=this;
				if (ChildForm.Text.Length!=0)
					tvContents.Nodes[0].Nodes.Add(ChildForm.Text);
			}
		}

		public void UnRegisterChildForm(Form ChildForm)
		{
			ChildForm.MdiParent=null;
			int i=FindNode(tvContents.Nodes[0].Nodes,ChildForm.Text);
			if (-1!=i)
				tvContents.Nodes[0].Nodes.RemoveAt(i);
		}

		public void AnalysisComplete(CAnalysis Analysis)
		{
			foreach (IAnalysisConsumer Cons in m_Consumers)
			{
				Cons.AnalysisComplete(Analysis);
			}

			foreach (CSummaryEvent evt in Analysis.SummaryEvents)
			{
				string[] subitems = new string[2];
				subitems[0]=evt.Analysis.Analyzer.Name;
				subitems[1]=evt.Text;
				ListViewItem itm= new ListViewItem(subitems);

				itm.Tag=evt;

				switch (evt.Type)
				{
					case EventType.Error : 
					{
						itm.ImageIndex=12;
						break;
					}
					case EventType.Warning: 
					{
						itm.ImageIndex=11;
						break;
					}
					default:
					{
						itm.ImageIndex=10;
						break;
					}
				}

				lvSummary.Items.Add(itm);

				if (null!=m_ConfigDoc)
				{
					foreach (XmlNode node in m_ConfigDoc["dsConfig"]["Analysis"]["ViewItems"].ChildNodes)
					{
						if ((node.Attributes["name"].Value==itm.Text) && (node.Attributes["text"].Value==itm.SubItems[1].Text)) 
						{
							itm.Selected=true;
							break;
						}
					}

				}
			}

			//Plot any trends saved in the cfg
			m_fmTL.UpdateUIFromDoc();

		}

		#endregion

		public void ShowProgress(ITask Task, string Message, int Count, int Progress, int Ticker)
		{
			m_ShowProgress.ShowProgress(Task, Message, Count, Progress, Ticker);
		}

		fmSigEvents m_fmSigEvents;
		fmTL m_fmTL;
//		fmTLChart m_fmTimeLineGraph;

		int m_ContentsWidth;
		int m_SummaryHeight;

		private void fmAnalysisParent_Load(object sender, System.EventArgs e)
		{
			m_fmSigEvents = new fmSigEvents();
			Consumers.Add(m_fmSigEvents);
			RegisterChildForm(m_fmSigEvents);
			m_fmSigEvents.Show();
			//			m_fmSigEvents.Dock = DockStyle.Bottom;

			m_fmTL = new fmTL(m_ConfigDoc);
			Consumers.Add(m_fmTL);
			RegisterChildForm(m_fmTL);
			m_fmTL.Show();

			tvContents.ExpandAll();

			m_ContentsWidth=paContents.Size.Width;
			m_SummaryHeight=paSummary.Size.Height;
		
		}

		public void PlotEvent(CEvent Event) 
		{
			m_fmTL.PlotEvent(Event);
		}
		public void ClearEvent(CEvent Event) 
		{
			m_fmTL.ClearEvent(Event);
		}
		public void ClearAllEvents()
		{
			m_fmTL.ClearAllEvents();
		}

		private void btShrink_Click(object sender, System.EventArgs e)
		{
			paContents.Resize -= new System.EventHandler(paContents_Resize);
			try
			{
				if (26==paContents.Size.Width) 
				{
					btShrink.Text="á";  // <-
					paContents.Size = new Size(m_ContentsWidth,paContents.Size.Height);
				}
				else 
				{
					btShrink.Text="â";  // ->
					paContents.Size = new Size (26,paContents.Size.Height);
				}
			}
			finally
			{
				paContents.Resize += new System.EventHandler(paContents_Resize);
			}
		}

		private void tvContents_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (null!=tvContents.SelectedNode) 
			{
				foreach (Form f in this.MdiChildren) 
				{
					if (f.Text==tvContents.SelectedNode.Text)
					{
						f.BringToFront();
						break;
					}
				}
			}
		}

		private void bt_v_Shrink_Click(object sender, System.EventArgs e)
		{
			this.paSummary.Resize -= new System.EventHandler(paSummary_Resize);
			try
			{
				if (26==paSummary.Size.Height) 
				{
					bt_v_Shrink.Text="ä";  // ^
					// |
					paSummary.Size = new Size(paSummary.Size.Width,m_SummaryHeight);
				}
				else 
				{						   // |
					bt_v_Shrink.Text="ã";  // v
					paSummary.Size = new Size (paSummary.Size.Width,26);
				}
			}
			finally
			{
				paSummary.Resize += new System.EventHandler(paSummary_Resize);
			}
		}

		private void lvSummary_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (0==lvSummary.SelectedItems.Count)
				return;
			m_fmTL.HideAllTrends();
			m_fmSigEvents.UnPublishAllEvents();
			Application.DoEvents();
			foreach (ListViewItem itm in lvSummary.SelectedItems)
			{
				if (null==itm.Tag) continue;
				if (!itm.Selected) continue;
				CSummaryEvent evt = (itm.Tag as CSummaryEvent);
				foreach (Form f in evt.Forms)
					f.BringToFront();
				foreach (CTrend t in evt.Trends)
					m_fmTL.ShowTrend(t);
				foreach (CEvent ev in evt.Events)
					m_fmSigEvents.PublishEvent(ev);
			}
		}

		private void paContents_Resize(object sender, System.EventArgs e)
		{
			m_ContentsWidth=paContents.Size.Width;
		}

		private void paSummary_Resize(object sender, System.EventArgs e)
		{
			m_SummaryHeight=paSummary.Size.Height;
		}

		private void UpdateDocFromUI()
		{
			m_MainForm.UpdateDocFromUI();
			m_ConfigDoc["dsConfig"]["Analysis"]["ViewItems"].InnerText="";
			foreach (ListViewItem itm in lvSummary.Items)
			{
				if (!itm.Selected)
					continue;

				XmlNode childnode=m_ConfigDoc.CreateElement("ViewItem");

				XmlAttribute newAttr = m_ConfigDoc.CreateAttribute("name");
				newAttr.Value = itm.Text;
				childnode.Attributes.SetNamedItem(newAttr);

				XmlAttribute newAttr2 = m_ConfigDoc.CreateAttribute("type");
				newAttr2.Value = "summaryevent";
				childnode.Attributes.SetNamedItem(newAttr2);

				XmlAttribute newAttr3 = m_ConfigDoc.CreateAttribute("text");
				newAttr3.Value = itm.SubItems[1].Text;
				childnode.Attributes.SetNamedItem(newAttr3);

				m_ConfigDoc["dsConfig"]["Analysis"]["ViewItems"].AppendChild(childnode);				

			}

			//Record any selected trends
			m_fmTL.UpdateDocFromUI();
		}

		private void miSaveView_Click(object sender, System.EventArgs e)
		{
			if (DialogResult.OK==sd_Cfg.ShowDialog()) 
			{
				UpdateDocFromUI();
				PssdiagConfig.fmPssdiagConfig.ConfigForm.SaveXMLCfg(sd_Cfg.FileName);
			}
		}


		private void DefaultLayout()
		{
			foreach (Form f in MdiChildren) 
			{
				f.WindowState = FormWindowState.Minimized;
			}
			m_fmSigEvents.WindowState = FormWindowState.Normal;
			m_fmTL.WindowState = FormWindowState.Normal;

			LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			DefaultLayout();
		}

		private void miCopy_Click(object sender, System.EventArgs e)
		{
			if (0==lvSummary.SelectedItems.Count)
				return;
			CSummaryEvent sevt=(lvSummary.SelectedItems[0].Tag as CSummaryEvent);
			string ctext=sevt.SerializedText+"\r\n"+sevt.GetDetails();
			Clipboard.SetDataObject(ctext);
		}

		private void cmSummary_Popup(object sender, System.EventArgs e)
		{
			miCopy.Enabled=(0!=lvSummary.SelectedItems.Count);
		}

	}
}
