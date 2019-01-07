namespace SteamAccCreator.Gui
{
	public partial class CaptchaDialog : global::System.Windows.Forms.Form
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
			this.boxCaptcha = new global::System.Windows.Forms.PictureBox();
			this.txtCaptcha = new global::System.Windows.Forms.TextBox();
			this.btnConfirm = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			((global::System.ComponentModel.ISupportInitialize)this.boxCaptcha).BeginInit();
			base.SuspendLayout();
			this.boxCaptcha.Location = new global::System.Drawing.Point(12, 12);
			this.boxCaptcha.Name = "boxCaptcha";
			this.boxCaptcha.Size = new global::System.Drawing.Size(206, 40);
			this.boxCaptcha.TabIndex = 0;
			this.boxCaptcha.TabStop = false;
			this.txtCaptcha.Location = new global::System.Drawing.Point(12, 58);
			this.txtCaptcha.Name = "txtCaptcha";
			this.txtCaptcha.Size = new global::System.Drawing.Size(206, 20);
			this.txtCaptcha.TabIndex = 5;
			this.txtCaptcha.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.txtCaptcha_KeyDown);
			this.txtCaptcha.KeyPress += new global::System.Windows.Forms.KeyPressEventHandler(this.txtCaptcha_KeyPress);
			this.btnConfirm.Location = new global::System.Drawing.Point(93, 84);
			this.btnConfirm.Name = "btnConfirm";
			this.btnConfirm.Size = new global::System.Drawing.Size(125, 23);
			this.btnConfirm.TabIndex = 6;
			this.btnConfirm.Text = "Confirm";
			this.btnConfirm.UseVisualStyleBackColor = true;
			this.btnConfirm.Click += new global::System.EventHandler(this.btnConfirm_Click);
			this.button1.Location = new global::System.Drawing.Point(12, 84);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(75, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "Refresh";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(231, 117);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.btnConfirm);
			base.Controls.Add(this.txtCaptcha);
			base.Controls.Add(this.boxCaptcha);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "CaptchaDialog";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Enter Captcha";
			((global::System.ComponentModel.ISupportInitialize)this.boxCaptcha).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private global::System.ComponentModel.IContainer icontainer_0;

		private global::System.Windows.Forms.Button btnConfirm;

		private global::System.Windows.Forms.Button button1;

		public global::System.Windows.Forms.TextBox txtCaptcha;

		private global::System.Windows.Forms.PictureBox boxCaptcha;
	}
}
