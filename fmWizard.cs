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
using System.IO;

namespace PssdiagConfig
{
	/// <summary>
	/// Summary description for fmWizard.
	/// </summary>
	public class fmWizard : System.Windows.Forms.Form
	{
        private System.Windows.Forms.TabControl tcWizard;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel paBottom;
		private System.Windows.Forms.Button btBack;
		private System.Windows.Forms.Button btNext;
		private System.Windows.Forms.TabPage tpSave;
		private System.Windows.Forms.TabPage tpStart;
		private System.Windows.Forms.CheckBox ckEmail;
		private System.Windows.Forms.CheckBox ckExeFile;
		private System.Windows.Forms.TextBox edExeFile;
		private System.Windows.Forms.Label laExeFile;
		private System.Windows.Forms.Button btExeFile;
		private System.Windows.Forms.SaveFileDialog sd_Exe;
		private System.Windows.Forms.ImageList imGlyphs;
		private System.Windows.Forms.TabPage tpFirst;
		private System.Windows.Forms.RadioButton rbAnalysis;
		private System.Windows.Forms.RadioButton rbWizard;
		private System.Windows.Forms.RadioButton rbClassic;
		private System.Windows.Forms.CheckBox ckWizard;
        private WebBrowser brDescrip;
		private System.ComponentModel.IContainer components;

		public fmWizard()
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmWizard));
            this.tcWizard = new System.Windows.Forms.TabControl();
            this.tpStart = new System.Windows.Forms.TabPage();
            this.ckWizard = new System.Windows.Forms.CheckBox();
            this.rbAnalysis = new System.Windows.Forms.RadioButton();
            this.rbWizard = new System.Windows.Forms.RadioButton();
            this.rbClassic = new System.Windows.Forms.RadioButton();
            this.tpFirst = new System.Windows.Forms.TabPage();
            this.tpSave = new System.Windows.Forms.TabPage();
            this.ckEmail = new System.Windows.Forms.CheckBox();
            this.ckExeFile = new System.Windows.Forms.CheckBox();
            this.edExeFile = new System.Windows.Forms.TextBox();
            this.laExeFile = new System.Windows.Forms.Label();
            this.btExeFile = new System.Windows.Forms.Button();
            this.imGlyphs = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.paBottom = new System.Windows.Forms.Panel();
            this.btBack = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.sd_Exe = new System.Windows.Forms.SaveFileDialog();
            this.brDescrip = new System.Windows.Forms.WebBrowser();
            this.tcWizard.SuspendLayout();
            this.tpStart.SuspendLayout();
            this.tpSave.SuspendLayout();
            this.paBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcWizard
            // 
            this.tcWizard.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tcWizard.Controls.Add(this.tpStart);
            this.tcWizard.Controls.Add(this.tpFirst);
            this.tcWizard.Controls.Add(this.tpSave);
            this.tcWizard.ItemSize = new System.Drawing.Size(1, 1);
            this.tcWizard.Location = new System.Drawing.Point(0, 0);
            this.tcWizard.Multiline = true;
            this.tcWizard.Name = "tcWizard";
            this.tcWizard.SelectedIndex = 0;
            this.tcWizard.Size = new System.Drawing.Size(749, 454);
            this.tcWizard.TabIndex = 5;
            // 
            // tpStart
            // 
            this.tpStart.Controls.Add(this.brDescrip);
            this.tpStart.Controls.Add(this.ckWizard);
            this.tpStart.Controls.Add(this.rbAnalysis);
            this.tpStart.Controls.Add(this.rbWizard);
            this.tpStart.Controls.Add(this.rbClassic);
            this.tpStart.Location = new System.Drawing.Point(4, 4);
            this.tpStart.Name = "tpStart";
            this.tpStart.Size = new System.Drawing.Size(740, 446);
            this.tpStart.TabIndex = 1;
            this.tpStart.Text = "Start";
            // 
            // ckWizard
            // 
            this.ckWizard.Checked = ((bool)(configurationAppSettings.GetValue("ckWizard.Checked", typeof(bool))));
            this.ckWizard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckWizard.Location = new System.Drawing.Point(592, 104);
            this.ckWizard.Name = "ckWizard";
            this.ckWizard.Size = new System.Drawing.Size(104, 24);
            this.ckWizard.TabIndex = 36;
            this.ckWizard.Text = "Use wizard";
            this.ckWizard.Visible = false;
            // 
            // rbAnalysis
            // 
            this.rbAnalysis.Location = new System.Drawing.Point(240, 152);
            this.rbAnalysis.Name = "rbAnalysis";
            this.rbAnalysis.Size = new System.Drawing.Size(256, 24);
            this.rbAnalysis.TabIndex = 5;
            this.rbAnalysis.Text = "Post-collection analysis";
            // 
            // rbWizard
            // 
            this.rbWizard.Checked = true;
            this.rbWizard.Location = new System.Drawing.Point(240, 112);
            this.rbWizard.Name = "rbWizard";
            this.rbWizard.Size = new System.Drawing.Size(256, 24);
            this.rbWizard.TabIndex = 4;
            this.rbWizard.TabStop = true;
            this.rbWizard.Text = "Wizard";
            // 
            // rbClassic
            // 
            this.rbClassic.Location = new System.Drawing.Point(240, 72);
            this.rbClassic.Name = "rbClassic";
            this.rbClassic.Size = new System.Drawing.Size(256, 24);
            this.rbClassic.TabIndex = 3;
            this.rbClassic.Text = "Basic diagnostic collection and analysis";
            // 
            // tpFirst
            // 
            this.tpFirst.Location = new System.Drawing.Point(4, 4);
            this.tpFirst.Name = "tpFirst";
            this.tpFirst.Size = new System.Drawing.Size(740, 446);
            this.tpFirst.TabIndex = 2;
            this.tpFirst.Text = "First";
            // 
            // tpSave
            // 
            this.tpSave.AutoScroll = true;
            this.tpSave.Controls.Add(this.ckEmail);
            this.tpSave.Controls.Add(this.ckExeFile);
            this.tpSave.Controls.Add(this.edExeFile);
            this.tpSave.Controls.Add(this.laExeFile);
            this.tpSave.Controls.Add(this.btExeFile);
            this.tpSave.Location = new System.Drawing.Point(4, 4);
            this.tpSave.Name = "tpSave";
            this.tpSave.Size = new System.Drawing.Size(740, 446);
            this.tpSave.TabIndex = 0;
            this.tpSave.Text = "Save";
            // 
            // ckEmail
            // 
            this.ckEmail.Checked = true;
            this.ckEmail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckEmail.Location = new System.Drawing.Point(40, 176);
            this.ckEmail.Name = "ckEmail";
            this.ckEmail.Size = new System.Drawing.Size(560, 24);
            this.ckEmail.TabIndex = 12;
            this.ckEmail.Text = "Create &email to send to customer and attach self-extracting CAB to it";
            // 
            // ckExeFile
            // 
            this.ckExeFile.Checked = true;
            this.ckExeFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckExeFile.Location = new System.Drawing.Point(40, 32);
            this.ckExeFile.Name = "ckExeFile";
            this.ckExeFile.Size = new System.Drawing.Size(600, 24);
            this.ckExeFile.TabIndex = 8;
            this.ckExeFile.Text = "Create self-extracting &CAB file with recommended configuration options selected " +
                "to send to customer";
            this.ckExeFile.CheckedChanged += new System.EventHandler(this.ckExeFile_CheckedChanged);
            // 
            // edExeFile
            // 
            this.edExeFile.Location = new System.Drawing.Point(100, 104);
            this.edExeFile.Name = "edExeFile";
            this.edExeFile.Size = new System.Drawing.Size(248, 20);
            this.edExeFile.TabIndex = 10;
            this.edExeFile.Text =  (Globals.UseCabarc() == true ? ".\\Customer\\pssd.exe": ".\\Customer\\pssd.cab") ;
            // 
            // laExeFile
            // 
            this.laExeFile.AutoSize = true;
            this.laExeFile.Location = new System.Drawing.Point(40, 106);
            this.laExeFile.Name = "laExeFile";
            this.laExeFile.Size = new System.Drawing.Size(49, 13);
            this.laExeFile.TabIndex = 9;
            this.laExeFile.Text = "File&name";
            // 
            // btExeFile
            // 
            this.btExeFile.ImageIndex = 0;
            this.btExeFile.ImageList = this.imGlyphs;
            this.btExeFile.Location = new System.Drawing.Point(348, 104);
            this.btExeFile.Name = "btExeFile";
            this.btExeFile.Size = new System.Drawing.Size(32, 23);
            this.btExeFile.TabIndex = 11;
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
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 411);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(744, 3);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            this.splitter1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter1_SplitterMoved);
            // 
            // paBottom
            // 
            this.paBottom.Controls.Add(this.btBack);
            this.paBottom.Controls.Add(this.btNext);
            this.paBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.paBottom.Location = new System.Drawing.Point(0, 414);
            this.paBottom.Name = "paBottom";
            this.paBottom.Size = new System.Drawing.Size(744, 40);
            this.paBottom.TabIndex = 10;
            // 
            // btBack
            // 
            this.btBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBack.Enabled = false;
            this.btBack.Location = new System.Drawing.Point(584, 8);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 24);
            this.btBack.TabIndex = 7;
            this.btBack.Text = "Back";
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // btNext
            // 
            this.btNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNext.Location = new System.Drawing.Point(664, 8);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(75, 24);
            this.btNext.TabIndex = 6;
            this.btNext.Text = "Next";
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // sd_Exe
            // 
            this.sd_Exe.DefaultExt = "EXE";
            this.sd_Exe.FileName = "pssd.exe";
            this.sd_Exe.Filter = "Executable files (*.exe)|*.EXE|All files(*.*)|*.*";
            this.sd_Exe.FilterIndex = 2;
            this.sd_Exe.InitialDirectory = ".\\Customer";
            this.sd_Exe.RestoreDirectory = true;
            // 
            // brDescrip
            // 
            this.brDescrip.Location = new System.Drawing.Point(8, 240);
            this.brDescrip.MinimumSize = new System.Drawing.Size(20, 20);
            this.brDescrip.Name = "brDescrip";
            this.brDescrip.Size = new System.Drawing.Size(720, 161);
            this.brDescrip.TabIndex = 37;
            // 
            // fmWizard
            // 
            this.AcceptButton = this.btNext;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(744, 454);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.paBottom);
            this.Controls.Add(this.tcWizard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "fmWizard";
            this.Text = "PSSDiag Wizard";
            this.Load += new System.EventHandler(this.fmWizard_Load);
            this.tcWizard.ResumeLayout(false);
            this.tpStart.ResumeLayout(false);
            this.tpSave.ResumeLayout(false);
            this.tpSave.PerformLayout();
            this.paBottom.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void PopulateRadioButtons(XmlNode parentNode)
		{
			TabPage page = tcWizard.SelectedTab;
			page.Controls.Clear();
			int i=10;
			foreach (XmlNode node in parentNode.ChildNodes)
			{
				RadioButton rb = new RadioButton();
				rb.Parent = page;
				rb.Location = new Point(10,i);
				rb.Text = node.Attributes["text"].Value;
				rb.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
				rb.Size = new Size(tcWizard.Size.Width-50,rb.Size.Height);
				rb.Tag = node;
				page.Controls.Add(rb);
				if (null!=node.Attributes["default"])
					rb.Checked=Convert.ToBoolean(node.Attributes["default"].Value);

				i+=rb.Size.Height+5;
			}
		}

		private void LoadDoc(string strFileName)
		{
			XmlDocument doc = new XmlDocument();
			try
			{
				doc.Load(strFileName);
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("Error loading {0}.  Message: {1}",strFileName,ex.Message));
				return;
			}
			PopulateRadioButtons(doc.DocumentElement);
		}

		private void splitter1_SplitterMoved(object sender, System.Windows.Forms.SplitterEventArgs e)
		{
		
		}

		private void radioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			btNext.Enabled=true;
			RadioButton rb = (RadioButton)sender;
			if (rb.Checked)
			{
				XmlNode node = (XmlNode)rb.Tag;
				if (null!=node.Attributes["descrip"])
					brDescrip.Navigate(Application.StartupPath+@"\wizard\"+node.Attributes["descrip"].Value);
				else
					brDescrip.Navigate("about:blank");
			}
		}


		private void CheckMakeNewPage(TabPage page)
		{
			if (page==tcWizard.TabPages[tcWizard.TabCount-1]) 
			{
				TabPage newPage = new TabPage();
				newPage.AutoScroll=true;
				tcWizard.TabPages.Add(newPage);
				tcWizard.SelectedTab=newPage;
				btNext.Enabled=false;
				btBack.Enabled=tcWizard.SelectedIndex!=0;
			}
		}

		private void PopulatePage(XmlNode node)
		{
			if (null!=node.Attributes["file"]) 
				LoadDoc(@"wizard\"+node.Attributes["file"].Value);
			else 
			{
				PopulateRadioButtons(node);
			}
		}

		string m_strCfgFile;

		XmlDocument m_ConfigDoc=null;

		private void btNext_Click(object sender, System.EventArgs e)
		{
			brDescrip.Navigate("about:blank");
			TabPage page = tcWizard.SelectedTab;
			if (page==tpStart) 
			{
				if (rbClassic.Checked) 
				{
					m_fmCfg.ShowDialog();
				}
				else if (rbWizard.Checked) 
				{
					tcWizard.SelectedIndex+=1;
					btBack.Enabled=true;
					btNext.Enabled=false;
					LoadDoc(@"wizard\WizardBase.xml");		
				}
			}
			else if (page==tpSave) 
			{
					if (ckExeFile.Checked) 
					{
						m_fmCfg.InitializeBuildFolder();
						File.Copy(@"wizard\"+m_strCfgFile,Application.StartupPath+@"\Build\pssdiag.xml",true);
						m_fmCfg.CreateExe(edExeFile.Text,Application.StartupPath+@"\Build",ckEmail.Checked);
					}
					tcWizard.TabPages.Remove(tpSave);

					PrunePages();

					CheckMakeNewPage(tcWizard.SelectedTab);

					PopulatePage(tpSave.Tag as XmlNode);

//					btNext.Enabled=false;
			}
			else 
			{
				foreach (Control ctrl in page.Controls)
				{
					RadioButton rb = (RadioButton)ctrl;
					if (rb.Checked)
					{
						XmlNode node = (XmlNode)rb.Tag;

						CheckMakeNewPage(page);

						if (null!=node.Attributes["config"]) 
						{
							m_strCfgFile=node.Attributes["config"].Value;

							if (m_fmCfg.LoadCfg(@"wizard\"+m_strCfgFile))
								m_ConfigDoc=m_fmCfg.m_ConfigDoc;

							tcWizard.TabPages.Add(tpSave);
							tcWizard.SelectedTab=tpSave;
							tpSave.Tag=node;
							btNext.Enabled=true;
							
						}
						else if (null!=node.Attributes["form"]) 
						{
							string formName=node.Attributes["form"].Value;
							if (0==string.Compare(formName,"Analyzer",true)) 
							{
								if (null!=m_ConfigDoc) 
								{
//									fmMain f = new fmMain(m_ConfigDoc);			
//									f.ShowDialog();
								}
							}
							else if (0==string.Compare(formName,"Collect",true)) 
							{
								//TODO:  Add plumbing for cfg form so that cfg is not always reloaded on _Load
								m_fmCfg.ShowDialog();
							}

							btNext.Enabled=false;
							
						}
						else 
						{
							PopulatePage(node);
						}
						break;
					}
				}
			}
		
		}

		private void PrunePages()
		{
			if (tcWizard.SelectedIndex>1) 
			{
				tcWizard.SelectedIndex-=1;
				for (int i=tcWizard.TabCount-1; i>tcWizard.SelectedIndex; i--)
				{
					tcWizard.TabPages.RemoveAt(i);
				}
			}
		}

		private void btBack_Click(object sender, System.EventArgs e)
		{
			brDescrip.Navigate("about:blank");
			if (tcWizard.SelectedTab==tpFirst)
			{
				tcWizard.SelectedIndex-=1;
				btBack.Enabled=false;
			}
			else if (tcWizard.SelectedTab==tpSave)
			{
				tcWizard.TabPages.Remove(tpSave);
				tcWizard.SelectedIndex-=1;
				btNext.Enabled=false;
			}
			else
			{
				PrunePages();
			}
			foreach (Control ctrl in tcWizard.SelectedTab.Controls)
			{
				if (ctrl is RadioButton) 
				{
					if (((RadioButton)ctrl).Checked) 
					{
						btNext.Enabled=true;
						break;
					}
				}
			}
		}

		fmPssdiagConfig m_fmCfg;
		static string[] Args;

		private void fmWizard_Load(object sender, System.EventArgs e)
		{
			tcWizard.TabPages.Remove(tpSave);
			tcWizard.SelectedIndex=0;
			m_fmCfg = new fmPssdiagConfig(Args);
			m_fmCfg.MinimizeBox = false;

			if (!ckWizard.Checked)
			{
				this.rbClassic.Checked=true;
				m_fmCfg.ShowDialog();
				if (Control.ModifierKeys!=Keys.Shift) 
				{
					Application.Exit();
				}
			}
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args) 
		{
			Args=args;

			if (Control.ModifierKeys==Keys.Shift) 
			{
				fmWizard fmWiz = new fmWizard();
				Application.Run(fmWiz);
			}
			else 
			{
				fmPssdiagConfig fmCfg = new fmPssdiagConfig(Args);
				Application.Run(fmCfg);
			}
		}

		private void ckExeFile_CheckedChanged(object sender, System.EventArgs e)
		{
			ckEmail.Enabled=ckExeFile.Checked;
		}

	}
}
