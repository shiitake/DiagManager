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

namespace PssdiagConfig
{
	/// <summary>
	/// Summary description for fmConnect.
	/// </summary>
	public class fmConnect : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Label laPrompt;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox edMachine;
		public System.Windows.Forms.TextBox edAppName;
		public System.Windows.Forms.RadioButton rbPSSDIAG;
		public System.Windows.Forms.RadioButton rbSQLDIAG;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public fmConnect()
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
			this.btCancel = new System.Windows.Forms.Button();
			this.btOK = new System.Windows.Forms.Button();
			this.edMachine = new System.Windows.Forms.TextBox();
			this.laPrompt = new System.Windows.Forms.Label();
			this.edAppName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.rbPSSDIAG = new System.Windows.Forms.RadioButton();
			this.rbSQLDIAG = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btCancel
			// 
			this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancel.Location = new System.Drawing.Point(208, 258);
			this.btCancel.Name = "btCancel";
			this.btCancel.TabIndex = 5;
			this.btCancel.Text = "Cancel";
			// 
			// btOK
			// 
			this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btOK.Location = new System.Drawing.Point(128, 258);
			this.btOK.Name = "btOK";
			this.btOK.TabIndex = 4;
			this.btOK.Text = "OK";
			// 
			// edMachine
			// 
			this.edMachine.Location = new System.Drawing.Point(9, 48);
			this.edMachine.Name = "edMachine";
			this.edMachine.Size = new System.Drawing.Size(184, 20);
			this.edMachine.TabIndex = 1;
			this.edMachine.Text = ".";
			// 
			// laPrompt
			// 
			this.laPrompt.AutoSize = true;
			this.laPrompt.Location = new System.Drawing.Point(9, 16);
			this.laPrompt.Name = "laPrompt";
			this.laPrompt.Size = new System.Drawing.Size(47, 16);
			this.laPrompt.TabIndex = 0;
			this.laPrompt.Text = "Machine";
			// 
			// edAppName
			// 
			this.edAppName.Location = new System.Drawing.Point(8, 208);
			this.edAppName.Name = "edAppName";
			this.edAppName.Size = new System.Drawing.Size(184, 20);
			this.edAppName.TabIndex = 3;
			this.edAppName.Text = "PSSDIAG";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 95);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Service Type";
			// 
			// rbPSSDIAG
			// 
			this.rbPSSDIAG.Checked = true;
			this.rbPSSDIAG.Location = new System.Drawing.Point(12, 122);
			this.rbPSSDIAG.Name = "rbPSSDIAG";
			this.rbPSSDIAG.TabIndex = 6;
			this.rbPSSDIAG.TabStop = true;
			this.rbPSSDIAG.Text = "PSSDIAG";
			this.rbPSSDIAG.CheckedChanged += new System.EventHandler(this.rbSQLDIAG_CheckedChanged);
			// 
			// rbSQLDIAG
			// 
			this.rbSQLDIAG.Location = new System.Drawing.Point(12, 149);
			this.rbSQLDIAG.Name = "rbSQLDIAG";
			this.rbSQLDIAG.TabIndex = 7;
			this.rbSQLDIAG.Text = "SQLDIAG";
			this.rbSQLDIAG.CheckedChanged += new System.EventHandler(this.rbSQLDIAG_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 187);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "Name";
			// 
			// fmConnect
			// 
			this.AcceptButton = this.btOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btCancel;
			this.ClientSize = new System.Drawing.Size(292, 296);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.rbSQLDIAG);
			this.Controls.Add(this.rbPSSDIAG);
			this.Controls.Add(this.edAppName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.edMachine);
			this.Controls.Add(this.laPrompt);
			this.Controls.Add(this.btCancel);
			this.Controls.Add(this.btOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "fmConnect";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Target Machine";
			this.ResumeLayout(false);

		}
		#endregion

		private void rbSQLDIAG_CheckedChanged(object sender, System.EventArgs e)
		{
			edAppName.Text=(sender as RadioButton).Text;
		}

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			edAppName.Enabled=true;
		}
	}
}
