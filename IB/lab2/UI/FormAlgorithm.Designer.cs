namespace lab2.UI
{
    partial class FormAlgorithm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel mainPanel;
        private Panel headerPanel;
        private Label headerLabel;
        private Panel contentPanel;
        private Label filePathLabel;
        private TextBox filePathTextBox;
        private Button selectFileButton;
        private Label hashResultLabel;
        private TextBox hashResultTextBox;
        private Button calculateHashButton;
        private Panel statusPanel;
        private Label statusLabel;
        private ProgressBar progressBar;
        private Button cancelButton;

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
            this.cancelButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.statusLabel = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.calculateHashButton = new System.Windows.Forms.Button();
            this.hashResultTextBox = new System.Windows.Forms.TextBox();
            this.hashResultLabel = new System.Windows.Forms.Label();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.filePathLabel = new System.Windows.Forms.Label();
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
            this.statusPanel.Controls.Add(this.cancelButton);
            this.statusPanel.Controls.Add(this.progressBar);
            this.statusPanel.Controls.Add(this.statusLabel);
            this.statusPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusPanel.Location = new System.Drawing.Point(0, 460);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(700, 40);
            this.statusPanel.TabIndex = 2;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cancelButton.ForeColor = System.Drawing.Color.White;
            this.cancelButton.Location = new System.Drawing.Point(600, 8);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(80, 24);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Visible = false;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(200, 10);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(390, 20);
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
            this.contentPanel.Controls.Add(this.calculateHashButton);
            this.contentPanel.Controls.Add(this.hashResultTextBox);
            this.contentPanel.Controls.Add(this.hashResultLabel);
            this.contentPanel.Controls.Add(this.selectFileButton);
            this.contentPanel.Controls.Add(this.filePathTextBox);
            this.contentPanel.Controls.Add(this.filePathLabel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 80);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(30);
            this.contentPanel.Size = new System.Drawing.Size(700, 380);
            this.contentPanel.TabIndex = 1;
            // 
            // calculateHashButton
            // 
            this.calculateHashButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.calculateHashButton.Enabled = false;
            this.calculateHashButton.FlatAppearance.BorderSize = 0;
            this.calculateHashButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.calculateHashButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.calculateHashButton.ForeColor = System.Drawing.Color.White;
            this.calculateHashButton.Location = new System.Drawing.Point(30, 240);
            this.calculateHashButton.Name = "calculateHashButton";
            this.calculateHashButton.Size = new System.Drawing.Size(150, 40);
            this.calculateHashButton.TabIndex = 5;
            this.calculateHashButton.Text = "Вычислить хэш";
            this.calculateHashButton.UseVisualStyleBackColor = false;
            this.calculateHashButton.Click += new System.EventHandler(this.CalculateHashButton_Click);
            // 
            // hashResultTextBox
            // 
            this.hashResultTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.hashResultTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hashResultTextBox.Font = new System.Drawing.Font("Consolas", 10F);
            this.hashResultTextBox.Location = new System.Drawing.Point(30, 160);
            this.hashResultTextBox.Multiline = true;
            this.hashResultTextBox.Name = "hashResultTextBox";
            this.hashResultTextBox.ReadOnly = true;
            this.hashResultTextBox.Size = new System.Drawing.Size(510, 60);
            this.hashResultTextBox.TabIndex = 4;
            // 
            // hashResultLabel
            // 
            this.hashResultLabel.AutoSize = true;
            this.hashResultLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.hashResultLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.hashResultLabel.Location = new System.Drawing.Point(30, 130);
            this.hashResultLabel.Name = "hashResultLabel";
            this.hashResultLabel.Size = new System.Drawing.Size(69, 20);
            this.hashResultLabel.TabIndex = 3;
            this.hashResultLabel.Text = "MD5 хэш:";
            // 
            // selectFileButton
            // 
            this.selectFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.selectFileButton.FlatAppearance.BorderSize = 0;
            this.selectFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectFileButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.selectFileButton.ForeColor = System.Drawing.Color.White;
            this.selectFileButton.Location = new System.Drawing.Point(440, 75);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(100, 30);
            this.selectFileButton.TabIndex = 2;
            this.selectFileButton.Text = "Обзор...";
            this.selectFileButton.UseVisualStyleBackColor = false;
            this.selectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.filePathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filePathTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.filePathTextBox.Location = new System.Drawing.Point(30, 75);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.ReadOnly = true;
            this.filePathTextBox.Size = new System.Drawing.Size(400, 25);
            this.filePathTextBox.TabIndex = 1;
            // 
            // filePathLabel
            // 
            this.filePathLabel.AutoSize = true;
            this.filePathLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.filePathLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.filePathLabel.Location = new System.Drawing.Point(30, 45);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(103, 20);
            this.filePathLabel.TabIndex = 0;
            this.filePathLabel.Text = "Выберите файл:";
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
            this.headerLabel.Size = new System.Drawing.Size(241, 30);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Вычисление MD5 хэша";
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
            this.Text = "Алгоритм MD5";
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