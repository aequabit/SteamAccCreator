using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace SteamAccCreator.Gui
{
	public partial class MainForm : Form
	{
		public bool RandomMail { get; private set; }

		public bool UseCsgo { get; private set; }

		public bool RandomAlias { get; private set; }

		public bool Neatusername { get; private set; }

		public bool NeatPassword { get; private set; }

		public bool RandomPass { get; private set; }

		public bool WriteIntoFile { get; private set; }

		public bool UseProxy { get; private set; }

		public bool AutoMailVerify { get; private set; }

		public bool UseCaptchaService { get; private set; }

		public MainForm()
		{
			this.Path = "accounts.txt";
			this.original = true;
			this.InitializeComponent();
		}

		public void BtnCreateAccount_Click(object sender, EventArgs e)
		{
			if (this.checkBox1.Checked)
			{
				this.proxyval = this.textBox1.Text;
				this.proxyport = Convert.ToInt32(this.textBox2.Text);
				this.proxy = true;
			}
			else
			{
				this.proxy = false;
			}
			if (this.checkBox4.Checked)
			{
				if (this.file != null)
				{
					int num = 0;
					while (num < this.nmbrAmountAccounts.Value)
					{
						new Thread(new ThreadStart(new AccountCreator(this, this.txtEmail.Text, this.txtAlias.Text, this.txtPass.Text, this.int_0, this.UseCaptchaService).Run)).Start();
						this.int_0++;
						num++;
					}
				}
				else
				{
					MessageBox.Show("Please Select a File to Edit. :)");
				}
			}
			else
			{
				int num2 = 0;
				while (num2 < this.nmbrAmountAccounts.Value)
				{
					new Thread(new ThreadStart(new AccountCreator(this, this.txtEmail.Text, this.txtAlias.Text, this.txtPass.Text, this.int_0, this.UseCaptchaService).Run)).Start();
					this.int_0++;
					num2++;
				}
			}
			if (this.UseCaptchaService)
			{
				this.UseCaptchaService = false;
				this.autocap.Checked = false;
				this.autocap.Enabled = false;
			}
		}

		public void AddToTable(string mail, string alias, string pass)
		{
			MainForm.Class10 @class = new MainForm.Class10();
			@class.mainForm_0 = this;
			@class.string_0 = mail;
			@class.string_1 = alias;
			@class.string_2 = pass;
			base.BeginInvoke(new Action(@class.method_0));
		}

		public void UpdateStatus(int i, string status)
		{
			MainForm.Class11 @class = new MainForm.Class11();
			@class.mainForm_0 = this;
			@class.int_0 = i;
			@class.string_0 = status;
			base.BeginInvoke(new Action(@class.method_0));
		}

		private void chkAutoVerifyMail_CheckedChanged(object sender, EventArgs e)
		{
			this.AutoMailVerify = this.chkAutoVerifyMail.Checked;
			if (this.AutoMailVerify)
			{
				MessageBox.Show("!Achtung! Der Auto Captcha Resolver connected zu dem Server von DedSec1337. Aber sendet keine Account Informationen mit. Nur das reine Captcha.\n\n\n!Warning! The auto captcha resolver connects to the server from DedSec1337, but is not sending any account details. Only the captcha image.");
			}
		}

		private void chkWriteIntoFile_CheckedChanged(object sender, EventArgs e)
		{
			this.WriteIntoFile = this.chkWriteIntoFile.Checked;
		}

		private void TrebfLvKk(object sender, EventArgs e)
		{
			bool @checked = this.chkRandomMail.Checked;
			this.chkAutoVerifyMail.Enabled = @checked;
			this.chkAutoVerifyMail.Checked = @checked;
			this.RandomMail = @checked;
			this.txtEmail.Enabled = !@checked;
			this.method_0();
		}

		private void chkRandomPass_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.chkRandomPass.Checked;
			this.txtPass.Enabled = !@checked;
			this.RandomPass = @checked;
			this.neatpassBox.Visible = true;
			this.NeatPassword = true;
			this.method_0();
		}

		private void chkRandomAlias_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.chkRandomAlias.Checked;
			this.Neatusername = true;
			this.txtAlias.Enabled = !@checked;
			this.NeatUsername.Visible = @checked;
			this.RandomAlias = @checked;
			this.method_0();
		}

		private void method_0()
		{
			bool flag = this.chkRandomMail.Checked || this.chkRandomPass.Checked || this.chkRandomAlias.Checked;
			this.chkWriteIntoFile.Checked = flag;
			this.chkWriteIntoFile.Enabled = !flag;
		}

		private void checkBox4_CheckedChanged(object sender, EventArgs e)
		{
			if (this.checkBox4.Checked)
			{
				this.button1.Enabled = true;
				this.Path = this.file;
				return;
			}
			this.button1.Enabled = false;
			this.Path = "accounts.txt";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.openFileDialog_0.Filter = "Text File|*.txt";
			this.openFileDialog_0.Title = "Save Files To";
			if (this.openFileDialog_0.ShowDialog() == DialogResult.OK)
			{
				this.file = this.openFileDialog_0.FileName;
			}
		}

		private void checkBox7_CheckedChanged(object sender, EventArgs e)
		{
			if (this.checkBox7.Checked)
			{
				this.istrue = true;
				return;
			}
			this.istrue = false;
		}

		private void openFileDialog_0_FileOk(object sender, CancelEventArgs e)
		{
			this.Path = this.openFileDialog_0.FileName;
			MessageBox.Show(this.Path);
		}

		private void nmbrAmountAccounts_ValueChanged(object sender, EventArgs e)
		{
		}

		private void comboBox1_TextChanged(object sender, EventArgs e)
		{
			if (this.comboBox1.Text != "User:Pass Formatting" && this.comboBox1.Text != "Original Formatting")
			{
				this.comboBox1.Text = "User:Pass Formatting";
			}
			if (this.comboBox1.Text == "User:Pass Formatting")
			{
				this.original = true;
				return;
			}
			if (this.comboBox1.Text == "Original Formatting")
			{
				this.original = false;
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (this.checkBox1.Checked)
			{
				this.textBox1.Enabled = true;
				this.textBox2.Enabled = true;
				return;
			}
			this.textBox1.Enabled = false;
			this.textBox2.Enabled = false;
		}

		public static bool SocketConnect(string host, int port)
		{
			bool result = false;
			try
			{
				Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 200);
				Thread.Sleep(500);
				IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(host), port);
				socket.Connect(remoteEP);
				if (socket.Connected)
				{
					result = true;
				}
				socket.Close();
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (this.checkBox1.Checked && this.textBox1.Text != "" && this.textBox2.Text != "")
			{
				if (MainForm.SocketConnect(this.textBox1.Text, Convert.ToInt32(this.textBox2.Text)))
				{
					this.label1.Text = "Working: True";
					return;
				}
				this.label1.Text = "Working: False";
			}
		}

		private void SiteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://high-minded.net/");
		}

		private void NeatUsername_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.NeatUsername.Checked;
			this.Neatusername = @checked;
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
		}

		private void neatpassBox_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.neatpassBox.Checked;
			this.NeatPassword = @checked;
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://github.com/Scytex");
		}

		private void method_1(object sender, EventArgs e)
		{
		}

		private void autocap_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.autocap.Checked;
			this.UseCaptchaService = @checked;
		}

		private void csgo_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.csgo.Checked;
			this.UseCsgo = @checked;
		}

		[CompilerGenerated]
		private bool bool_0;

		[CompilerGenerated]
		private bool bool_1;

		[CompilerGenerated]
		private bool bool_2;

		[CompilerGenerated]
		private bool bool_3;

		[CompilerGenerated]
		private bool bool_4;

		[CompilerGenerated]
		private bool bool_5;

		[CompilerGenerated]
		private bool bool_6;

		private int int_0;

		public string proxyval;

		public int proxyport;

		public bool proxy;

		public bool istrue;

		public string Path;

		public string file;

		public bool original;

		[CompilerGenerated]
		private sealed class Class10
		{
			internal void method_0()
			{
				this.mainForm_0.dataAccounts.Rows.Add(new DataGridViewRow
				{
					Cells = 
					{
						new DataGridViewTextBoxCell
						{
							Value = this.string_0
						},
						new DataGridViewTextBoxCell
						{
							Value = this.string_1
						},
						new DataGridViewTextBoxCell
						{
							Value = this.string_2
						},
						new DataGridViewTextBoxCell
						{
							Value = "Ready"
						}
					}
				});
			}

			public MainForm mainForm_0;

			public string string_0;

			public string string_1;

			public string string_2;
		}

		[CompilerGenerated]
		private sealed class Class11
		{
			internal void method_0()
			{
				try
				{
					this.mainForm_0.dataAccounts.Rows[this.int_0].Cells[3].Value = this.string_0;
				}
				catch (Exception)
				{
				}
			}

			public MainForm mainForm_0;

			public int int_0;

			public string string_0;
		}
	}
}
