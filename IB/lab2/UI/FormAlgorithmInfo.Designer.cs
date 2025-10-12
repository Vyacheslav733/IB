namespace lab2.UI
{
    partial class FormAlgorithmInfo
    {
        private System.ComponentModel.IContainer components = null;
        private Panel mainPanel;
        private Label titleLabel;
        private Label descriptionLabel;
        private Button closeButton;
        private Panel contentPanel;
        private Label featuresTitleLabel;
        private Label featuresLabel;
        private Label securityLabel;

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
            this.contentPanel = new System.Windows.Forms.Panel();
            this.securityLabel = new System.Windows.Forms.Label();
            this.featuresLabel = new System.Windows.Forms.Label();
            this.featuresTitleLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Controls.Add(this.contentPanel);
            this.mainPanel.Controls.Add(this.closeButton);
            this.mainPanel.Controls.Add(this.titleLabel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(30);
            this.mainPanel.Size = new System.Drawing.Size(700, 600);
            this.mainPanel.TabIndex = 0;
            // 
            // contentPanel
            // 
            this.contentPanel.AutoScroll = true;
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.contentPanel.Controls.Add(this.securityLabel);
            this.contentPanel.Controls.Add(this.featuresLabel);
            this.contentPanel.Controls.Add(this.featuresTitleLabel);
            this.contentPanel.Controls.Add(this.descriptionLabel);
            this.contentPanel.Location = new System.Drawing.Point(30, 80);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(20);
            this.contentPanel.Size = new System.Drawing.Size(640, 400);
            this.contentPanel.TabIndex = 2;
            // 
            // securityLabel
            // 
            this.securityLabel.AutoSize = false;
            this.securityLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.securityLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.securityLabel.Location = new System.Drawing.Point(20, 280);
            this.securityLabel.Name = "securityLabel";
            this.securityLabel.Size = new System.Drawing.Size(600, 80);
            this.securityLabel.TabIndex = 3;
            this.securityLabel.Text = "🔒 Безопасность:\r\n• Уязвим к коллизиям (разным данным с одинаковым хешем)\r\n• Не рекомендуется для криптографических применений\r\n• Подвержен атакам с использованием ра" +
    "дужных таблиц";
            // 
            // featuresLabel
            // 
            this.featuresLabel.AutoSize = false;
            this.featuresLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.featuresLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.featuresLabel.Location = new System.Drawing.Point(20, 180);
            this.featuresLabel.Name = "featuresLabel";
            this.featuresLabel.Size = new System.Drawing.Size(600, 80);
            this.featuresLabel.TabIndex = 2;
            this.featuresLabel.Text = "⚡ Основные характеристики:\r\n• Создает 128-битный хеш (32 шестнадцатеричных символа" +
    ")\r\n• Обрабатывает данные блоками по 512 бит\r\n• Использует 64 раунда преобразован" +
    "ий";
            // 
            // featuresTitleLabel
            // 
            this.featuresTitleLabel.AutoSize = true;
            this.featuresTitleLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.featuresTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.featuresTitleLabel.Location = new System.Drawing.Point(20, 150);
            this.featuresTitleLabel.Name = "featuresTitleLabel";
            this.featuresTitleLabel.Size = new System.Drawing.Size(183, 19);
            this.featuresTitleLabel.TabIndex = 1;
            this.featuresTitleLabel.Text = "Технические особенности";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = false;
            this.descriptionLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.descriptionLabel.Location = new System.Drawing.Point(20, 20);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(600, 120);
            this.descriptionLabel.TabIndex = 0;
            this.descriptionLabel.Text = @"MD5 (Message Digest 5) — это алгоритм хеширования, разработанный профессором Рональдом Ривестом в 1991 году и представленный в 1992 году. Алгоритм предназначен для создания «отпечатков» или дайджестов сообщений фиксированной длины.

Основное применение:
• Проверка целостности данных
• Хранение хешей паролей
• Проверка идентичности файлов

Алгоритм принимает входные данные переменной длины и создает уникальный 128-битный хеш, который представляет собой 32 шестнадцатеричных символа.";
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(290, 500);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(120, 35);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Закрыть";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.titleLabel.Location = new System.Drawing.Point(30, 30);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(294, 32);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Алгоритм MD5 - Обзор";
            // 
            // FormAlgorithmInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 600);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAlgorithmInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Об алгоритме MD5";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}