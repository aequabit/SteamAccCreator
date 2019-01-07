using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SteamAccCreator.Gui
{
	public partial class InputDialog : Form
	{
		public InputDialog(string error)
		{
			this.InitializeComponent();
			this.lblError.Text = error;
		}

		private void btnConfirm_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}
	}
}
