namespace lab3.UI
{
    partial class FormAlgorithm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel mainPanel;
        private Panel headerPanel;
        private Label headerLabel;
        private Panel contentPanel;
        private Label inputFileLabel;
        private TextBox inputFilePathTextBox;
        private Button selectInputFileButton;
        private Label outputFileLabel;
        private TextBox outputFilePathTextBox;
        private Button selectOutputFileButton;
        private Label keyLabel;
        private TextBox keyTextBox;
        private Label keyStatusLabel;
        private Button encryptButton;
        private Button decryptButton;
        private Panel statusPanel;
        private Label statusLabel;
        private ProgressBar progressBar;
        private Button selectKeyFileButton;
        private CheckBox showKeyCheckBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.statusPanel = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.statusLabel = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.showKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.selectKeyFileButton = new System.Windows.Forms.Button();
            this.decryptButton = new System.Windows.Forms.Button();
            this.encryptButton = new System.Windows.Forms.Button();
            this.keyStatusLabel = new System.Windows.Forms.Label();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.keyLabel = new System.Windows.Forms.Label();
            this.selectOutputFileButton = new System.Windows.Forms.Button();
            this.outputFilePathTextBox = new System.Windows.Forms.TextBox();
            this.outputFileLabel = new System.Windows.Forms.Label();
            this.selectInputFileButton = new System.Windows.Forms.Button();
            this.inputFilePathTextBox = new System.Windows.Forms.TextBox();
            this.inputFileLabel = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.headerLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.statusPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Controls.Add(this.statusPanel);
            this.mainPanel.Controls.Add(this.contentPanel);
            this.mainPanel.Controls.Add(this.headerPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(700, 500);
            this.mainPanel.TabIndex = 0;
            // 
            // statusPanel
            // 
            this.statusPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.statusPanel.Controls.Add(this.progressBar);
            this.statusPanel.Controls.Add(this.statusLabel);
            this.statusPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusPanel.Location = new System.Drawing.Point(0, 460);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(700, 40);
            this.statusPanel.TabIndex = 2;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(200, 10);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(480, 20);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 1;
            this.progressBar.Visible = false;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.statusLabel.Location = new System.Drawing.Point(30, 12);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(88, 15);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Готов к работе";
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.Controls.Add(this.showKeyCheckBox);
            this.contentPanel.Controls.Add(this.selectKeyFileButton);
            this.contentPanel.Controls.Add(this.decryptButton);
            this.contentPanel.Controls.Add(this.encryptButton);
            this.contentPanel.Controls.Add(this.keyStatusLabel);
            this.contentPanel.Controls.Add(this.keyTextBox);
            this.contentPanel.Controls.Add(this.keyLabel);
            this.contentPanel.Controls.Add(this.selectOutputFileButton);
            this.contentPanel.Controls.Add(this.outputFilePathTextBox);
            this.contentPanel.Controls.Add(this.outputFileLabel);
            this.contentPanel.Controls.Add(this.selectInputFileButton);
            this.contentPanel.Controls.Add(this.inputFilePathTextBox);
            this.contentPanel.Controls.Add(this.inputFileLabel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 80);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(30);
            this.contentPanel.Size = new System.Drawing.Size(700, 380);
            this.contentPanel.TabIndex = 1;
            // 
            // showKeyCheckBox
            // 
            this.showKeyCheckBox.AutoSize = true;
            this.showKeyCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.showKeyCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.showKeyCheckBox.Location = new System.Drawing.Point(440, 250);
            this.showKeyCheckBox.Name = "showKeyCheckBox";
            this.showKeyCheckBox.Size = new System.Drawing.Size(109, 19);
            this.showKeyCheckBox.TabIndex = 12;
            this.showKeyCheckBox.Text = "Показать ключ";
            this.showKeyCheckBox.UseVisualStyleBackColor = true;
            this.showKeyCheckBox.CheckedChanged += new System.EventHandler(this.ShowKeyCheckBox_CheckedChanged);
            // 
            // selectKeyFileButton
            // 
            this.selectKeyFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.selectKeyFileButton.FlatAppearance.BorderSize = 0;
            this.selectKeyFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectKeyFileButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.selectKeyFileButton.ForeColor = System.Drawing.Color.White;
            this.selectKeyFileButton.Location = new System.Drawing.Point(440, 220);
            this.selectKeyFileButton.Name = "selectKeyFileButton";
            this.selectKeyFileButton.Size = new System.Drawing.Size(100, 25);
            this.selectKeyFileButton.TabIndex = 11;
            this.selectKeyFileButton.Text = "Из файла...";
            this.selectKeyFileButton.UseVisualStyleBackColor = false;
            this.selectKeyFileButton.Click += new System.EventHandler(this.SelectKeyFileButton_Click);
            // 
            // decryptButton
            // 
            this.decryptButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.decryptButton.Enabled = false;
            this.decryptButton.FlatAppearance.BorderSize = 0;
            this.decryptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.decryptButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.decryptButton.ForeColor = System.Drawing.Color.White;
            this.decryptButton.Location = new System.Drawing.Point(200, 320);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(150, 40);
            this.decryptButton.TabIndex = 10;
            this.decryptButton.Text = "Расшифровать";
            this.decryptButton.UseVisualStyleBackColor = false;
            this.decryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // encryptButton
            // 
            this.encryptButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.encryptButton.Enabled = false;
            this.encryptButton.FlatAppearance.BorderSize = 0;
            this.encryptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.encryptButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.encryptButton.ForeColor = System.Drawing.Color.White;
            this.encryptButton.Location = new System.Drawing.Point(30, 320);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(150, 40);
            this.encryptButton.TabIndex = 9;
            this.encryptButton.Text = "Зашифровать";
            this.encryptButton.UseVisualStyleBackColor = false;
            this.encryptButton.Click += new System.EventHandler(this.EncryptButton_Click);
            // 
            // keyStatusLabel
            // 
            this.keyStatusLabel.AutoSize = true;
            this.keyStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.keyStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.keyStatusLabel.Location = new System.Drawing.Point(30, 250);
            this.keyStatusLabel.Name = "keyStatusLabel";
            this.keyStatusLabel.Size = new System.Drawing.Size(85, 15);
            this.keyStatusLabel.TabIndex = 8;
            this.keyStatusLabel.Text = "Ключ: 0/8 байт";
            // 
            // keyTextBox
            // 
            this.keyTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.keyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.keyTextBox.Location = new System.Drawing.Point(30, 220);
            this.keyTextBox.MaxLength = 8;
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.PasswordChar = '*';
            this.keyTextBox.Size = new System.Drawing.Size(400, 25);
            this.keyTextBox.TabIndex = 7;
            this.keyTextBox.TextChanged += new System.EventHandler(this.KeyTextBox_TextChanged);
            // 
            // keyLabel
            // 
            this.keyLabel.AutoSize = true;
            this.keyLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.keyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.keyLabel.Location = new System.Drawing.Point(30, 190);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(349, 20);
            this.keyLabel.TabIndex = 6;
            this.keyLabel.Text = "Ключ (ровно 8 символов, 8 байт в кодировке UTF-8):";
            // 
            // selectOutputFileButton
            // 
            this.selectOutputFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.selectOutputFileButton.FlatAppearance.BorderSize = 0;
            this.selectOutputFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectOutputFileButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.selectOutputFileButton.ForeColor = System.Drawing.Color.White;
            this.selectOutputFileButton.Location = new System.Drawing.Point(440, 135);
            this.selectOutputFileButton.Name = "selectOutputFileButton";
            this.selectOutputFileButton.Size = new System.Drawing.Size(100, 30);
            this.selectOutputFileButton.TabIndex = 5;
            this.selectOutputFileButton.Text = "Обзор...";
            this.selectOutputFileButton.UseVisualStyleBackColor = false;
            this.selectOutputFileButton.Click += new System.EventHandler(this.SelectOutputFileButton_Click);
            // 
            // outputFilePathTextBox
            // 
            this.outputFilePathTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.outputFilePathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputFilePathTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.outputFilePathTextBox.Location = new System.Drawing.Point(30, 135);
            this.outputFilePathTextBox.Name = "outputFilePathTextBox";
            this.outputFilePathTextBox.ReadOnly = true;
            this.outputFilePathTextBox.Size = new System.Drawing.Size(400, 25);
            this.outputFilePathTextBox.TabIndex = 4;
            // 
            // outputFileLabel
            // 
            this.outputFileLabel.AutoSize = true;
            this.outputFileLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.outputFileLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.outputFileLabel.Location = new System.Drawing.Point(30, 105);
            this.outputFileLabel.Name = "outputFileLabel";
            this.outputFileLabel.Size = new System.Drawing.Size(126, 20);
            this.outputFileLabel.TabIndex = 3;
            this.outputFileLabel.Text = "Файл назначения:";
            // 
            // selectInputFileButton
            // 
            this.selectInputFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.selectInputFileButton.FlatAppearance.BorderSize = 0;
            this.selectInputFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectInputFileButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.selectInputFileButton.ForeColor = System.Drawing.Color.White;
            this.selectInputFileButton.Location = new System.Drawing.Point(440, 65);
            this.selectInputFileButton.Name = "selectInputFileButton";
            this.selectInputFileButton.Size = new System.Drawing.Size(100, 30);
            this.selectInputFileButton.TabIndex = 2;
            this.selectInputFileButton.Text = "Обзор...";
            this.selectInputFileButton.UseVisualStyleBackColor = false;
            this.selectInputFileButton.Click += new System.EventHandler(this.SelectInputFileButton_Click);
            // 
            // inputFilePathTextBox
            // 
            this.inputFilePathTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.inputFilePathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputFilePathTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.inputFilePathTextBox.Location = new System.Drawing.Point(30, 65);
            this.inputFilePathTextBox.Name = "inputFilePathTextBox";
            this.inputFilePathTextBox.ReadOnly = true;
            this.inputFilePathTextBox.Size = new System.Drawing.Size(400, 25);
            this.inputFilePathTextBox.TabIndex = 1;
            // 
            // inputFileLabel
            // 
            this.inputFileLabel.AutoSize = true;
            this.inputFileLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.inputFileLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.inputFileLabel.Location = new System.Drawing.Point(30, 35);
            this.inputFileLabel.Name = "inputFileLabel";
            this.inputFileLabel.Size = new System.Drawing.Size(103, 20);
            this.inputFileLabel.TabIndex = 0;
            this.inputFileLabel.Text = "Исходный файл:";
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.headerPanel.Controls.Add(this.headerLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(700, 80);
            this.headerPanel.TabIndex = 0;
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.headerLabel.ForeColor = System.Drawing.Color.White;
            this.headerLabel.Location = new System.Drawing.Point(30, 25);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(262, 30);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Алгоритм DES в режиме CFB";
            // 
            // FormAlgorithm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "FormAlgorithm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Алгоритм DES-CFB";
            this.mainPanel.ResumeLayout(false);
            this.statusPanel.ResumeLayout(false);
            this.statusPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}