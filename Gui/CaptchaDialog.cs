using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SteamAccCreator.Web;

namespace SteamAccCreator.Gui
{
	public partial class CaptchaDialog : Form
	{
		public CaptchaDialog(HttpHandler httpHandler, ref string _status, bool auto = false)
		{
			this.InitializeComponent();
			this.autox = auto;
			this.httpHandler_0 = httpHandler;
			this.method_0(auto, ref _status);
		}

		private void method_0(bool bool_0, ref string string_0)
		{
			if (!bool_0)
			{
				this.boxCaptcha.Image = this.httpHandler_0.GetCaptchaImageraw();
				return;
			}
			this.ans = this.httpHandler_0.GetCaptchaImage(ref string_0);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string text = "";
			this.method_0(this.autox, ref text);
		}

		private void btnConfirm_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		private void txtCaptcha_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.btnConfirm_Click(sender, e);
			}
		}

		private void txtCaptcha_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.KeyChar = char.ToUpper(e.KeyChar);
		}

		public string[] ans;

		public bool autox;

		private readonly HttpHandler httpHandler_0;
	}
}
