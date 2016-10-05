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
	/// Summary description for fmInputBox.
	/// </summary>
	public class fmInputBox : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label laPrompt;
		private System.Windows.Forms.TextBox edValue;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Button btCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public fmInputBox()
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
			this.laPrompt = new System.Windows.Forms.Label();
			this.edValue = new System.Windows.Forms.TextBox();
			this.btOK = new System.Windows.Forms.Button();
			this.btCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// laPrompt
			// 
			this.laPrompt.AutoSize = true;
			this.laPrompt.Location = new System.Drawing.Point(8, 12);
			this.laPrompt.Name = "laPrompt";
			this.laPrompt.Size = new System.Drawing.Size(35, 16);
			this.laPrompt.TabIndex = 0;
			this.laPrompt.Text = "label1";
			// 
			// edValue
			// 
			this.edValue.Location = new System.Drawing.Point(8, 40);
			this.edValue.Name = "edValue";
			this.edValue.Size = new System.Drawing.Size(472, 20);
			this.edValue.TabIndex = 1;
			this.edValue.Text = "";
			// 
			// btOK
			// 
			this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btOK.Location = new System.Drawing.Point(328, 80);
			this.btOK.Name = "btOK";
			this.btOK.TabIndex = 2;
			this.btOK.Text = "OK";
			// 
			// btCancel
			// 
			this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancel.Location = new System.Drawing.Point(408, 80);
			this.btCancel.Name = "btCancel";
			this.btCancel.TabIndex = 3;
			this.btCancel.Text = "Cancel";
			// 
			// fmInputBox
			// 
			this.AcceptButton = this.btOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btCancel;
			this.ClientSize = new System.Drawing.Size(498, 110);
			this.Controls.Add(this.btCancel);
			this.Controls.Add(this.btOK);
			this.Controls.Add(this.edValue);
			this.Controls.Add(this.laPrompt);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "fmInputBox";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "fmInputBox";
			this.ResumeLayout(false);

		}
		#endregion

		public static string GetString(string Caption, string Prompt, string Default)
		{

			fmInputBox fmIB = new fmInputBox();

			fmIB.Text=Caption;
			fmIB.laPrompt.Text=Prompt;
			fmIB.edValue.Text=Default;

			if (fmIB.ShowDialog()==DialogResult.OK)
				return fmIB.edValue.Text;
			else
				return "";

		}

	}
}
