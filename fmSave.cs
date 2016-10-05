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
using System.IO;

namespace PssdiagConfig
{
	/// <summary>
	/// Summary description for fmSave.
	/// </summary>
	public class fmSave : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox edCfgFile;
		private System.Windows.Forms.Button btCfgFile;
		private System.Windows.Forms.ImageList imGlyphs;
		private System.Windows.Forms.SaveFileDialog sd_Cfg;
		private System.Windows.Forms.SaveFileDialog sd_Exe;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.GroupBox rgPackage;
		private System.Windows.Forms.CheckBox ckExeFile;
		private System.Windows.Forms.TextBox edExeFile;
		private System.Windows.Forms.Label laExeFile;
		private System.Windows.Forms.Button btExeFile;
		private System.ComponentModel.IContainer components;

		public fmSave()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmSave));
            this.label1 = new System.Windows.Forms.Label();
            this.edCfgFile = new System.Windows.Forms.TextBox();
            this.btCfgFile = new System.Windows.Forms.Button();
            this.imGlyphs = new System.Windows.Forms.ImageList(this.components);
            this.sd_Cfg = new System.Windows.Forms.SaveFileDialog();
            this.sd_Exe = new System.Windows.Forms.SaveFileDialog();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.rgPackage = new System.Windows.Forms.GroupBox();
            this.ckExeFile = new System.Windows.Forms.CheckBox();
            this.edExeFile = new System.Windows.Forms.TextBox();
            this.laExeFile = new System.Windows.Forms.Label();
            this.btExeFile = new System.Windows.Forms.Button();
            this.rgPackage.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Filename";
            // 
            // edCfgFile
            // 
            this.edCfgFile.Location = new System.Drawing.Point(92, 32);
            this.edCfgFile.Name = "edCfgFile";
            this.edCfgFile.Size = new System.Drawing.Size(248, 20);
            this.edCfgFile.TabIndex = 1;
            this.edCfgFile.Text = ".\\Build\\pssdiag.ini";
            this.edCfgFile.TextChanged += new System.EventHandler(this.edCfgFile_TextChanged);
            // 
            // btCfgFile
            // 
            this.btCfgFile.ImageIndex = 0;
            this.btCfgFile.ImageList = this.imGlyphs;
            this.btCfgFile.Location = new System.Drawing.Point(340, 31);
            this.btCfgFile.Name = "btCfgFile";
            this.btCfgFile.Size = new System.Drawing.Size(32, 23);
            this.btCfgFile.TabIndex = 2;
            this.btCfgFile.Click += new System.EventHandler(this.btCfgFile_Click);
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
            // sd_Cfg
            // 
            this.sd_Cfg.DefaultExt = "INI";
            this.sd_Cfg.FileName = "PSSDiag.Ini";
            this.sd_Cfg.Filter = "XML configuration files (*.xml)|*.xml|INI configuration files (*.ini)|*.INI|All f" +
                "iles(*.*)|*.*";
            this.sd_Cfg.FilterIndex = 2;
            this.sd_Cfg.InitialDirectory = ".\\Build";
            this.sd_Cfg.RestoreDirectory = true;
            // 
            // sd_Exe
            // 
            this.sd_Exe.DefaultExt = "EXE";
            this.sd_Exe.FileName =   (Globals.UseCabarc() == true ? "pssd.exe": "pssd.cab");
            this.sd_Exe.Filter = "Executable files (*.exe)|*.EXE|All files(*.*)|*.*";
            this.sd_Exe.FilterIndex = 2;
            this.sd_Exe.InitialDirectory = ".\\Customer";
            this.sd_Exe.RestoreDirectory = true;
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Location = new System.Drawing.Point(240, 192);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 8;
            this.btOK.Text = "OK";
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(328, 192);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 9;
            this.btCancel.Text = "Cancel";
            // 
            // rgPackage
            // 
            this.rgPackage.Controls.Add(this.ckExeFile);
            this.rgPackage.Controls.Add(this.edExeFile);
            this.rgPackage.Controls.Add(this.laExeFile);
            this.rgPackage.Controls.Add(this.btExeFile);
            this.rgPackage.Location = new System.Drawing.Point(24, 72);
            this.rgPackage.Name = "rgPackage";
            this.rgPackage.Size = new System.Drawing.Size(360, 112);
            this.rgPackage.TabIndex = 10;
            this.rgPackage.TabStop = false;
            // 
            // ckExeFile
            // 
            this.ckExeFile.Checked = true;
            this.ckExeFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckExeFile.Location = new System.Drawing.Point(68, 12);
            this.ckExeFile.Name = "ckExeFile";
            this.ckExeFile.Size = new System.Drawing.Size(192, 24);
            this.ckExeFile.TabIndex = 8;
            this.ckExeFile.Text = string.Format ( "Create{0}CAB file", Globals.UseCabarc() == true? " self-extracting ":" " );
            this.ckExeFile.CheckedChanged += new System.EventHandler(this.ckExeFile_CheckedChanged);
            // 
            // edExeFile
            // 
            this.edExeFile.Location = new System.Drawing.Point(68, 44);
            this.edExeFile.Name = "edExeFile";
            this.edExeFile.Size = new System.Drawing.Size(248, 20);
            this.edExeFile.TabIndex = 10;
            this.edExeFile.Text = (Globals.UseCabarc() == true ? ".\\Customer\\pssd.exe" : ".\\Customer\\pssd.cab");
            // 
            // laExeFile
            // 
            this.laExeFile.AutoSize = true;
            this.laExeFile.Location = new System.Drawing.Point(12, 46);
            this.laExeFile.Name = "laExeFile";
            this.laExeFile.Size = new System.Drawing.Size(49, 13);
            this.laExeFile.TabIndex = 9;
            this.laExeFile.Text = "File&name";
            // 
            // btExeFile
            // 
            this.btExeFile.ImageIndex = 0;
            this.btExeFile.ImageList = this.imGlyphs;
            this.btExeFile.Location = new System.Drawing.Point(316, 43);
            this.btExeFile.Name = "btExeFile";
            this.btExeFile.Size = new System.Drawing.Size(32, 23);
            this.btExeFile.TabIndex = 11;
            this.btExeFile.Click += new System.EventHandler(this.btExeFile_Click);
            // 
            // fmSave
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(416, 224);
            this.Controls.Add(this.rgPackage);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.edCfgFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCfgFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fmSave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Save Configuration";
            this.rgPackage.ResumeLayout(false);
            this.rgPackage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		string DefaultPath;
		public static bool GetSaveFiles(ref string CfgFile, ref bool CreateExe, ref string ExeFile, ref bool CreateEmail)
		{
			bool bRes=false;
			fmSave fmS = new fmSave();
			if (0!=CfgFile.Length) 
			{
				fmS.edCfgFile.Text=CfgFile;
				fmS.DefaultPath=Path.GetFullPath(CfgFile);
				fmS.sd_Cfg.FileName=CfgFile;
				fmS.sd_Cfg.DefaultExt=Path.GetExtension(CfgFile);
				fmS.sd_Cfg.FilterIndex=Math.Abs(string.Compare(fmS.sd_Cfg.DefaultExt,"XML",true))+1;
			}
			fmS.rgPackage.Enabled=true;
			if (DialogResult.OK==fmS.ShowDialog()) 
			{
				CfgFile=fmS.edCfgFile.Text;
				CreateExe=fmS.ckExeFile.Checked;
				ExeFile=fmS.edExeFile.Text;
				//CreateEmail=fmS.ckEmail.Checked;
				bRes=true;
			}
			return bRes;
		}

		private void btCfgFile_Click(object sender, System.EventArgs e)
		{
			if (DialogResult.OK==sd_Cfg.ShowDialog())
				edCfgFile.Text=sd_Cfg.FileName;
		}

		private void btExeFile_Click(object sender, System.EventArgs e)
		{
			if (DialogResult.OK==sd_Exe.ShowDialog())
				edExeFile.Text=sd_Exe.FileName;
		}

		private void ckExeFile_CheckedChanged(object sender, System.EventArgs e)
		{
			laExeFile.Enabled=ckExeFile.Checked;
			edExeFile.Enabled=ckExeFile.Checked;
			btExeFile.Enabled=ckExeFile.Checked;
//			ckEmail.Enabled=ckExeFile.Checked;
		}

		private void edCfgFile_TextChanged(object sender, System.EventArgs e)
		{
			string p = Path.GetFullPath(edCfgFile.Text);
			rgPackage.Enabled=(0==string.Compare(Path.GetDirectoryName(p)+@"\"+Path.GetFileNameWithoutExtension(p),Path.GetDirectoryName(DefaultPath)+@"\"+Path.GetFileNameWithoutExtension(DefaultPath),true));
		}
	}
}
