namespace SteamAccCreator.Gui
{
	public partial class MainForm : global::System.Windows.Forms.Form
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
			this.txtEmail = new global::System.Windows.Forms.TextBox();
			this.btnCreateAccount = new global::System.Windows.Forms.Button();
			this.lblEmail = new global::System.Windows.Forms.Label();
			this.txtAlias = new global::System.Windows.Forms.TextBox();
			this.txtPass = new global::System.Windows.Forms.TextBox();
			this.lblAlias = new global::System.Windows.Forms.Label();
			this.lblPass = new global::System.Windows.Forms.Label();
			this.nmbrAmountAccounts = new global::System.Windows.Forms.NumericUpDown();
			this.lblAmount = new global::System.Windows.Forms.Label();
			this.chkRandomMail = new global::System.Windows.Forms.CheckBox();
			this.pnlSettings = new global::System.Windows.Forms.GroupBox();
			this.csgo = new global::System.Windows.Forms.CheckBox();
			this.neatpassBox = new global::System.Windows.Forms.CheckBox();
			this.NeatUsername = new global::System.Windows.Forms.CheckBox();
			this.chkWriteIntoFile = new global::System.Windows.Forms.CheckBox();
			this.chkAutoVerifyMail = new global::System.Windows.Forms.CheckBox();
			this.chkRandomAlias = new global::System.Windows.Forms.CheckBox();
			this.chkRandomPass = new global::System.Windows.Forms.CheckBox();
			this.autocap = new global::System.Windows.Forms.CheckBox();
			this.pnlCreation = new global::System.Windows.Forms.GroupBox();
			this.dataAccounts = new global::System.Windows.Forms.DataGridView();
			this.colMail = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colAlias = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colPass = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colStatus = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.comboBox1 = new global::System.Windows.Forms.ComboBox();
			this.button1 = new global::System.Windows.Forms.Button();
			this.checkBox4 = new global::System.Windows.Forms.CheckBox();
			this.checkBox7 = new global::System.Windows.Forms.CheckBox();
			this.openFileDialog_0 = new global::System.Windows.Forms.OpenFileDialog();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.linkLabel1 = new global::System.Windows.Forms.LinkLabel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.SiteLink = new global::System.Windows.Forms.LinkLabel();
			this.button2 = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.textBox2 = new global::System.Windows.Forms.TextBox();
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			this.checkBox1 = new global::System.Windows.Forms.CheckBox();
			((global::System.ComponentModel.ISupportInitialize)this.nmbrAmountAccounts).BeginInit();
			this.pnlSettings.SuspendLayout();
			this.pnlCreation.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataAccounts).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.txtEmail.Location = new global::System.Drawing.Point(94, 19);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new global::System.Drawing.Size(206, 20);
			this.txtEmail.TabIndex = 1;
			this.btnCreateAccount.Location = new global::System.Drawing.Point(94, 97);
			this.btnCreateAccount.Name = "btnCreateAccount";
			this.btnCreateAccount.Size = new global::System.Drawing.Size(206, 23);
			this.btnCreateAccount.TabIndex = 5;
			this.btnCreateAccount.Text = "Create Account";
			this.btnCreateAccount.UseVisualStyleBackColor = true;
			this.btnCreateAccount.Click += new global::System.EventHandler(this.BtnCreateAccount_Click);
			this.lblEmail.AutoSize = true;
			this.lblEmail.Location = new global::System.Drawing.Point(34, 22);
			this.lblEmail.Name = "lblEmail";
			this.lblEmail.Size = new global::System.Drawing.Size(35, 13);
			this.lblEmail.TabIndex = 6;
			this.lblEmail.Text = "Email:";
			this.txtAlias.Location = new global::System.Drawing.Point(94, 45);
			this.txtAlias.Name = "txtAlias";
			this.txtAlias.Size = new global::System.Drawing.Size(206, 20);
			this.txtAlias.TabIndex = 2;
			this.txtPass.Location = new global::System.Drawing.Point(94, 71);
			this.txtPass.Name = "txtPass";
			this.txtPass.PasswordChar = '•';
			this.txtPass.Size = new global::System.Drawing.Size(206, 20);
			this.txtPass.TabIndex = 3;
			this.lblAlias.AutoSize = true;
			this.lblAlias.Location = new global::System.Drawing.Point(34, 48);
			this.lblAlias.Name = "lblAlias";
			this.lblAlias.Size = new global::System.Drawing.Size(32, 13);
			this.lblAlias.TabIndex = 12;
			this.lblAlias.Text = "Alias:";
			this.lblPass.AutoSize = true;
			this.lblPass.Location = new global::System.Drawing.Point(34, 74);
			this.lblPass.Name = "lblPass";
			this.lblPass.Size = new global::System.Drawing.Size(33, 13);
			this.lblPass.TabIndex = 13;
			this.lblPass.Text = "Pass:";
			this.nmbrAmountAccounts.Location = new global::System.Drawing.Point(52, 20);
			this.nmbrAmountAccounts.Name = "nmbrAmountAccounts";
			this.nmbrAmountAccounts.Size = new global::System.Drawing.Size(41, 20);
			this.nmbrAmountAccounts.TabIndex = 14;
			this.nmbrAmountAccounts.ValueChanged += new global::System.EventHandler(this.nmbrAmountAccounts_ValueChanged);
			this.lblAmount.AutoSize = true;
			this.lblAmount.Location = new global::System.Drawing.Point(6, 22);
			this.lblAmount.Name = "lblAmount";
			this.lblAmount.Size = new global::System.Drawing.Size(41, 13);
			this.lblAmount.TabIndex = 15;
			this.lblAmount.Text = "Create:";
			this.chkRandomMail.AutoSize = true;
			this.chkRandomMail.Location = new global::System.Drawing.Point(9, 46);
			this.chkRandomMail.Name = "chkRandomMail";
			this.chkRandomMail.Size = new global::System.Drawing.Size(88, 17);
			this.chkRandomMail.TabIndex = 16;
			this.chkRandomMail.Text = "Random Mail";
			this.chkRandomMail.UseVisualStyleBackColor = true;
			this.chkRandomMail.CheckedChanged += new global::System.EventHandler(this.TrebfLvKk);
			this.pnlSettings.Controls.Add(this.csgo);
			this.pnlSettings.Controls.Add(this.neatpassBox);
			this.pnlSettings.Controls.Add(this.NeatUsername);
			this.pnlSettings.Controls.Add(this.chkWriteIntoFile);
			this.pnlSettings.Controls.Add(this.chkAutoVerifyMail);
			this.pnlSettings.Controls.Add(this.chkRandomAlias);
			this.pnlSettings.Controls.Add(this.chkRandomPass);
			this.pnlSettings.Controls.Add(this.nmbrAmountAccounts);
			this.pnlSettings.Controls.Add(this.chkRandomMail);
			this.pnlSettings.Controls.Add(this.lblAmount);
			this.pnlSettings.Location = new global::System.Drawing.Point(15, 12);
			this.pnlSettings.Name = "pnlSettings";
			this.pnlSettings.Size = new global::System.Drawing.Size(332, 96);
			this.pnlSettings.TabIndex = 17;
			this.pnlSettings.TabStop = false;
			this.pnlSettings.Text = "Settings";
			this.csgo.AccessibleName = "csgo";
			this.csgo.AutoSize = true;
			this.csgo.Location = new global::System.Drawing.Point(232, 19);
			this.csgo.Margin = new global::System.Windows.Forms.Padding(2);
			this.csgo.Name = "csgo";
			this.csgo.Size = new global::System.Drawing.Size(78, 17);
			this.csgo.TabIndex = 24;
			this.csgo.Text = "Add CSGO";
			this.csgo.UseVisualStyleBackColor = true;
			this.csgo.CheckedChanged += new global::System.EventHandler(this.csgo_CheckedChanged);
			this.neatpassBox.AccessibleName = "NeatPass";
			this.neatpassBox.AutoSize = true;
			this.neatpassBox.Checked = true;
			this.neatpassBox.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.neatpassBox.Location = new global::System.Drawing.Point(232, 46);
			this.neatpassBox.Margin = new global::System.Windows.Forms.Padding(2);
			this.neatpassBox.Name = "neatpassBox";
			this.neatpassBox.Size = new global::System.Drawing.Size(98, 17);
			this.neatpassBox.TabIndex = 22;
			this.neatpassBox.Text = "Neat Password";
			this.neatpassBox.UseVisualStyleBackColor = true;
			this.neatpassBox.Visible = false;
			this.neatpassBox.CheckedChanged += new global::System.EventHandler(this.neatpassBox_CheckedChanged);
			this.NeatUsername.AccessibleName = "neatUsername";
			this.NeatUsername.AutoSize = true;
			this.NeatUsername.Checked = true;
			this.NeatUsername.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.NeatUsername.Location = new global::System.Drawing.Point(232, 67);
			this.NeatUsername.Margin = new global::System.Windows.Forms.Padding(2);
			this.NeatUsername.Name = "NeatUsername";
			this.NeatUsername.Size = new global::System.Drawing.Size(100, 17);
			this.NeatUsername.TabIndex = 21;
			this.NeatUsername.Text = "Neat Username";
			this.NeatUsername.UseVisualStyleBackColor = true;
			this.NeatUsername.Visible = false;
			this.NeatUsername.CheckedChanged += new global::System.EventHandler(this.NeatUsername_CheckedChanged);
			this.chkWriteIntoFile.AutoSize = true;
			this.chkWriteIntoFile.Location = new global::System.Drawing.Point(108, 20);
			this.chkWriteIntoFile.Name = "chkWriteIntoFile";
			this.chkWriteIntoFile.Size = new global::System.Drawing.Size(117, 17);
			this.chkWriteIntoFile.TabIndex = 20;
			this.chkWriteIntoFile.Text = "Write Data Into File";
			this.chkWriteIntoFile.UseVisualStyleBackColor = true;
			this.chkWriteIntoFile.CheckedChanged += new global::System.EventHandler(this.chkWriteIntoFile_CheckedChanged);
			this.chkAutoVerifyMail.AutoSize = true;
			this.chkAutoVerifyMail.Enabled = false;
			this.chkAutoVerifyMail.Location = new global::System.Drawing.Point(108, 46);
			this.chkAutoVerifyMail.Name = "chkAutoVerifyMail";
			this.chkAutoVerifyMail.Size = new global::System.Drawing.Size(99, 17);
			this.chkAutoVerifyMail.TabIndex = 19;
			this.chkAutoVerifyMail.Text = "Auto Mail Verify";
			this.chkAutoVerifyMail.UseVisualStyleBackColor = true;
			this.chkAutoVerifyMail.CheckedChanged += new global::System.EventHandler(this.chkAutoVerifyMail_CheckedChanged);
			this.chkRandomAlias.AutoSize = true;
			this.chkRandomAlias.Location = new global::System.Drawing.Point(108, 69);
			this.chkRandomAlias.Name = "chkRandomAlias";
			this.chkRandomAlias.Size = new global::System.Drawing.Size(91, 17);
			this.chkRandomAlias.TabIndex = 18;
			this.chkRandomAlias.Text = "Random Alias";
			this.chkRandomAlias.UseVisualStyleBackColor = true;
			this.chkRandomAlias.CheckedChanged += new global::System.EventHandler(this.chkRandomAlias_CheckedChanged);
			this.chkRandomPass.AutoSize = true;
			this.chkRandomPass.Location = new global::System.Drawing.Point(9, 69);
			this.chkRandomPass.Name = "chkRandomPass";
			this.chkRandomPass.Size = new global::System.Drawing.Size(92, 17);
			this.chkRandomPass.TabIndex = 18;
			this.chkRandomPass.Text = "Random Pass";
			this.chkRandomPass.UseVisualStyleBackColor = true;
			this.chkRandomPass.CheckedChanged += new global::System.EventHandler(this.chkRandomPass_CheckedChanged);
			this.autocap.AccessibleName = "Autocap";
			this.autocap.AutoSize = true;
			this.autocap.Location = new global::System.Drawing.Point(633, 16);
			this.autocap.Margin = new global::System.Windows.Forms.Padding(2);
			this.autocap.Name = "autocap";
			this.autocap.Size = new global::System.Drawing.Size(91, 17);
			this.autocap.TabIndex = 23;
			this.autocap.Text = "Auto Captcha";
			this.autocap.UseVisualStyleBackColor = true;
			this.autocap.Visible = false;
			this.autocap.CheckedChanged += new global::System.EventHandler(this.autocap_CheckedChanged);
			this.pnlCreation.Controls.Add(this.btnCreateAccount);
			this.pnlCreation.Controls.Add(this.lblPass);
			this.pnlCreation.Controls.Add(this.lblAlias);
			this.pnlCreation.Controls.Add(this.txtPass);
			this.pnlCreation.Controls.Add(this.txtEmail);
			this.pnlCreation.Controls.Add(this.txtAlias);
			this.pnlCreation.Controls.Add(this.lblEmail);
			this.pnlCreation.Location = new global::System.Drawing.Point(15, 114);
			this.pnlCreation.Name = "pnlCreation";
			this.pnlCreation.Size = new global::System.Drawing.Size(332, 132);
			this.pnlCreation.TabIndex = 18;
			this.pnlCreation.TabStop = false;
			this.dataAccounts.AllowUserToAddRows = false;
			this.dataAccounts.AllowUserToDeleteRows = false;
			this.dataAccounts.AllowUserToResizeColumns = false;
			this.dataAccounts.AllowUserToResizeRows = false;
			this.dataAccounts.CellBorderStyle = global::System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.dataAccounts.ColumnHeadersBorderStyle = global::System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dataAccounts.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataAccounts.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.colMail,
				this.colAlias,
				this.colPass,
				this.colStatus
			});
			this.dataAccounts.Location = new global::System.Drawing.Point(364, 12);
			this.dataAccounts.MultiSelect = false;
			this.dataAccounts.Name = "dataAccounts";
			this.dataAccounts.ReadOnly = true;
			this.dataAccounts.RowHeadersBorderStyle = global::System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dataAccounts.RowHeadersVisible = false;
			this.dataAccounts.SelectionMode = global::System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataAccounts.Size = new global::System.Drawing.Size(735, 234);
			this.dataAccounts.TabIndex = 19;
			this.colMail.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.colMail.Frozen = true;
			this.colMail.HeaderText = "Mail";
			this.colMail.Name = "colMail";
			this.colMail.ReadOnly = true;
			this.colMail.Resizable = global::System.Windows.Forms.DataGridViewTriState.False;
			this.colMail.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.colMail.Width = 32;
			this.colAlias.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.colAlias.Frozen = true;
			this.colAlias.HeaderText = "Alias";
			this.colAlias.Name = "colAlias";
			this.colAlias.ReadOnly = true;
			this.colAlias.Resizable = global::System.Windows.Forms.DataGridViewTriState.False;
			this.colAlias.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.colAlias.Width = 35;
			this.colPass.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.colPass.Frozen = true;
			this.colPass.HeaderText = "Pass";
			this.colPass.Name = "colPass";
			this.colPass.ReadOnly = true;
			this.colPass.Resizable = global::System.Windows.Forms.DataGridViewTriState.False;
			this.colPass.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.colPass.Width = 36;
			this.colStatus.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colStatus.HeaderText = "Status";
			this.colStatus.Name = "colStatus";
			this.colStatus.ReadOnly = true;
			this.colStatus.Resizable = global::System.Windows.Forms.DataGridViewTriState.False;
			this.colStatus.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.groupBox1.Controls.Add(this.autocap);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.checkBox4);
			this.groupBox1.Controls.Add(this.checkBox7);
			this.groupBox1.Location = new global::System.Drawing.Point(15, 250);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(1084, 39);
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "File Writing";
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[]
			{
				"User:Pass Formatting",
				"Original Formatting"
			});
			this.comboBox1.Location = new global::System.Drawing.Point(390, 11);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new global::System.Drawing.Size(197, 21);
			this.comboBox1.TabIndex = 22;
			this.comboBox1.Text = "User:Pass Formatting";
			this.comboBox1.TextChanged += new global::System.EventHandler(this.comboBox1_TextChanged);
			this.button1.Enabled = false;
			this.button1.Location = new global::System.Drawing.Point(288, 11);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(25, 23);
			this.button1.TabIndex = 20;
			this.button1.Text = "...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.checkBox4.AutoSize = true;
			this.checkBox4.Location = new global::System.Drawing.Point(181, 15);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new global::System.Drawing.Size(106, 17);
			this.checkBox4.TabIndex = 19;
			this.checkBox4.Text = "Custom Directory";
			this.checkBox4.UseVisualStyleBackColor = true;
			this.checkBox4.CheckedChanged += new global::System.EventHandler(this.checkBox4_CheckedChanged);
			this.checkBox7.AutoSize = true;
			this.checkBox7.Location = new global::System.Drawing.Point(57, 15);
			this.checkBox7.Name = "checkBox7";
			this.checkBox7.Size = new global::System.Drawing.Size(79, 17);
			this.checkBox7.TabIndex = 16;
			this.checkBox7.Text = "Write Email";
			this.checkBox7.UseVisualStyleBackColor = true;
			this.checkBox7.CheckedChanged += new global::System.EventHandler(this.checkBox7_CheckedChanged);
			this.openFileDialog_0.FileName = "openFileDialog1";
			this.openFileDialog_0.FileOk += new global::System.ComponentModel.CancelEventHandler(this.openFileDialog_0_FileOk);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.linkLabel1);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.SiteLink);
			this.groupBox2.Controls.Add(this.button2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.textBox2);
			this.groupBox2.Controls.Add(this.textBox1);
			this.groupBox2.Controls.Add(this.checkBox1);
			this.groupBox2.Location = new global::System.Drawing.Point(15, 288);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(1084, 42);
			this.groupBox2.TabIndex = 21;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Proxy Support";
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(909, 25);
			this.label3.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(28, 13);
			this.label3.TabIndex = 31;
			this.label3.Text = "Site:";
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new global::System.Drawing.Point(630, 29);
			this.linkLabel1.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new global::System.Drawing.Size(132, 13);
			this.linkLabel1.TabIndex = 30;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "https://github.com/Scytex";
			this.linkLabel1.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(576, 29);
			this.label2.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(58, 13);
			this.label2.TabIndex = 29;
			this.label2.Text = "Coded by: ";
			this.SiteLink.AutoSize = true;
			this.SiteLink.Location = new global::System.Drawing.Point(935, 25);
			this.SiteLink.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.SiteLink.Name = "SiteLink";
			this.SiteLink.Size = new global::System.Drawing.Size(123, 13);
			this.SiteLink.TabIndex = 28;
			this.SiteLink.TabStop = true;
			this.SiteLink.Text = "https://high-minded.net/";
			this.SiteLink.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SiteLink_LinkClicked);
			this.button2.Location = new global::System.Drawing.Point(390, 15);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(40, 22);
			this.button2.TabIndex = 27;
			this.button2.Text = "Test";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(316, 19);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(59, 13);
			this.label1.TabIndex = 26;
			this.label1.Text = "Working: ?";
			this.textBox2.Enabled = false;
			this.textBox2.Location = new global::System.Drawing.Point(264, 16);
			this.textBox2.MaxLength = 6;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new global::System.Drawing.Size(49, 20);
			this.textBox2.TabIndex = 24;
			this.textBox2.TextChanged += new global::System.EventHandler(this.textBox2_TextChanged);
			this.textBox1.Enabled = false;
			this.textBox1.Location = new global::System.Drawing.Point(150, 16);
			this.textBox1.MaxLength = 15;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new global::System.Drawing.Size(108, 20);
			this.textBox1.TabIndex = 23;
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new global::System.Drawing.Point(57, 18);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new global::System.Drawing.Size(92, 17);
			this.checkBox1.TabIndex = 22;
			this.checkBox1.Text = "Proxy Support";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new global::System.EventHandler(this.checkBox1_CheckedChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			base.ClientSize = new global::System.Drawing.Size(1108, 336);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.dataAccounts);
			base.Controls.Add(this.pnlCreation);
			base.Controls.Add(this.pnlSettings);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.Fixed3D;
			base.Name = "MainForm";
			this.Text = "[v10] Steam Account Creator - Stolen by DedSec1337 - Real coder https://github.com/Scytex/Steam-Account-Creator - Patched & cleaned by xenos ";
			base.Load += new global::System.EventHandler(this.MainForm_Load);
			((global::System.ComponentModel.ISupportInitialize)this.nmbrAmountAccounts).EndInit();
			this.pnlSettings.ResumeLayout(false);
			this.pnlSettings.PerformLayout();
			this.pnlCreation.ResumeLayout(false);
			this.pnlCreation.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dataAccounts).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			base.ResumeLayout(false);
		}

		private global::System.ComponentModel.IContainer icontainer_0;

		private global::System.Windows.Forms.TextBox txtEmail;

		private global::System.Windows.Forms.Button btnCreateAccount;

		private global::System.Windows.Forms.Label lblEmail;

		private global::System.Windows.Forms.TextBox txtAlias;

		private global::System.Windows.Forms.TextBox txtPass;

		private global::System.Windows.Forms.Label lblAlias;

		private global::System.Windows.Forms.Label lblPass;

		private global::System.Windows.Forms.NumericUpDown nmbrAmountAccounts;

		private global::System.Windows.Forms.Label lblAmount;

		private global::System.Windows.Forms.CheckBox chkRandomMail;

		private global::System.Windows.Forms.GroupBox pnlSettings;

		private global::System.Windows.Forms.CheckBox chkWriteIntoFile;

		private global::System.Windows.Forms.CheckBox chkAutoVerifyMail;

		private global::System.Windows.Forms.CheckBox chkRandomAlias;

		private global::System.Windows.Forms.CheckBox chkRandomPass;

		private global::System.Windows.Forms.GroupBox pnlCreation;

		private global::System.Windows.Forms.DataGridView dataAccounts;

		private global::System.Windows.Forms.DataGridViewTextBoxColumn colMail;

		private global::System.Windows.Forms.DataGridViewTextBoxColumn colAlias;

		private global::System.Windows.Forms.DataGridViewTextBoxColumn colPass;

		private global::System.Windows.Forms.DataGridViewTextBoxColumn colStatus;

		private global::System.Windows.Forms.GroupBox groupBox1;

		private global::System.Windows.Forms.Button button1;

		private global::System.Windows.Forms.CheckBox checkBox4;

		private global::System.Windows.Forms.CheckBox checkBox7;

		private global::System.Windows.Forms.OpenFileDialog openFileDialog_0;

		public global::System.Windows.Forms.ComboBox comboBox1;

		private global::System.Windows.Forms.GroupBox groupBox2;

		private global::System.Windows.Forms.TextBox textBox2;

		private global::System.Windows.Forms.TextBox textBox1;

		private global::System.Windows.Forms.CheckBox checkBox1;

		private global::System.Windows.Forms.Label label1;

		private global::System.Windows.Forms.Button button2;

		private global::System.Windows.Forms.LinkLabel SiteLink;

		private global::System.Windows.Forms.CheckBox NeatUsername;

		private global::System.Windows.Forms.CheckBox neatpassBox;

		private global::System.Windows.Forms.Label label3;

		private global::System.Windows.Forms.LinkLabel linkLabel1;

		private global::System.Windows.Forms.Label label2;

		private global::System.Windows.Forms.CheckBox autocap;

		private global::System.Windows.Forms.CheckBox csgo;
	}
}
