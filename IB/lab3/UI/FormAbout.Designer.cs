namespace lab3.UI
{
    partial class FormAbout
    {
        private System.ComponentModel.IContainer components = null;
        private Panel mainPanel;
        private Label titleLabel;
        private Label authorLabel;
        private Label groupLabel;
        private Label variantLabel;
        private Button closeButton;

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
            mainPanel = new Panel();
            closeButton = new Button();
            variantLabel = new Label();
            groupLabel = new Label();
            authorLabel = new Label();
            titleLabel = new Label();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.White;
            mainPanel.Controls.Add(closeButton);
            mainPanel.Controls.Add(variantLabel);
            mainPanel.Controls.Add(groupLabel);
            mainPanel.Controls.Add(authorLabel);
            mainPanel.Controls.Add(titleLabel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(6);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(929, 422);
            mainPanel.TabIndex = 0;
            // 
            // closeButton
            // 
            closeButton.BackColor = Color.FromArgb(0, 122, 204);
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font("Segoe UI", 9F);
            closeButton.ForeColor = Color.White;
            closeButton.Location = new Point(344, 320);
            closeButton.Margin = new Padding(6);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(223, 75);
            closeButton.TabIndex = 5;
            closeButton.Text = "Закрыть";
            closeButton.UseVisualStyleBackColor = false;
            closeButton.Click += CloseButton_Click;
            // 
            // variantLabel
            // 
            variantLabel.AutoSize = true;
            variantLabel.Font = new Font("Segoe UI", 11F);
            variantLabel.ForeColor = Color.FromArgb(64, 64, 64);
            variantLabel.Location = new Point(37, 256);
            variantLabel.Margin = new Padding(6, 0, 6, 0);
            variantLabel.Name = "variantLabel";
            variantLabel.Size = new Size(462, 41);
            variantLabel.TabIndex = 3;
            variantLabel.Text = "Вариант: 10 - Алгоритм DES в режиме CFB";
            // 
            // groupLabel
            // 
            groupLabel.AutoSize = true;
            groupLabel.Font = new Font("Segoe UI", 11F);
            groupLabel.ForeColor = Color.FromArgb(64, 64, 64);
            groupLabel.Location = new Point(37, 203);
            groupLabel.Margin = new Padding(6, 0, 6, 0);
            groupLabel.Name = "groupLabel";
            groupLabel.Size = new Size(249, 41);
            groupLabel.TabIndex = 2;
            groupLabel.Text = "Группа: ПИбд-43";
            // 
            // authorLabel
            // 
            authorLabel.AutoSize = true;
            authorLabel.Font = new Font("Segoe UI", 11F);
            authorLabel.ForeColor = Color.FromArgb(64, 64, 64);
            authorLabel.Location = new Point(37, 149);
            authorLabel.Margin = new Padding(6, 0, 6, 0);
            authorLabel.Name = "authorLabel";
            authorLabel.Size = new Size(530, 41);
            authorLabel.TabIndex = 1;
            authorLabel.Text = "Автор: Иванов Вячеслав Николаевич";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(0, 122, 204);
            titleLabel.Location = new Point(37, 43);
            titleLabel.Margin = new Padding(6, 0, 6, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(580, 65);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Алгоритм DES-CFB";
            // 
            // FormAbout
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(929, 422);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormAbout";
            StartPosition = FormStartPosition.CenterParent;
            Text = "О программе";
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}