namespace SteamAccCreator.Gui
{
	public partial class InputDialog : global::System.Windows.Forms.Form
	{
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.lblError = new global::System.Windows.Forms.Label();
			this.txtInfo = new global::System.Windows.Forms.TextBox();
			this.btnConfirm = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.lblError.AutoSize = true;
			this.lblError.Location = new global::System.Drawing.Point(12, 9);
			this.lblError.Name = "lblError";
			this.lblError.Size = new global::System.Drawing.Size(96, 13);
			this.lblError.TabIndex = 0;
			this.lblError.Text = "Example Error Text";
			this.txtInfo.Location = new global::System.Drawing.Point(12, 25);
			this.txtInfo.Name = "txtInfo";
			this.txtInfo.Size = new global::System.Drawing.Size(170, 20);
			this.txtInfo.TabIndex = 1;
			this.btnConfirm.Location = new global::System.Drawing.Point(12, 51);
			this.btnConfirm.Name = "btnConfirm";
			this.btnConfirm.Size = new global::System.Drawing.Size(170, 23);
			this.btnConfirm.TabIndex = 2;
			this.btnConfirm.Text = "Confirm";
			this.btnConfirm.UseVisualStyleBackColor = true;
			this.btnConfirm.Click += new global::System.EventHandler(this.btnConfirm_Click);
			base.AcceptButton = this.btnConfirm;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(194, 81);
			base.Controls.Add(this.btnConfirm);
			base.Controls.Add(this.txtInfo);
			base.Controls.Add(this.lblError);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "InputDialog";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Update Info";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private global::System.ComponentModel.IContainer icontainer_0;

		private global::System.Windows.Forms.Label lblError;

		private global::System.Windows.Forms.Button btnConfirm;

		public global::System.Windows.Forms.TextBox txtInfo;
	}
}
