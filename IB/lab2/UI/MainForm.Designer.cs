namespace lab2.UI
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip mainMenu;
        private ToolStripMenuItem fileMenuItem;
        private ToolStripMenuItem helpMenuItem;
        private ToolStripMenuItem aboutMenuItem;
        private ToolStripMenuItem exitMenuItem;
        private ToolStripMenuItem algorithmMenuItem;
        private Panel welcomePanel;
        private Label titleLabel;
        private Label descriptionLabel;
        private Panel featuresPanel;
        private Label featuresLabel;
        private ToolStripMenuItem algorithmInfoMenuItem;

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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algorithmMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algorithmInfoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.welcomePanel = new System.Windows.Forms.Panel();
            this.featuresPanel = new System.Windows.Forms.Panel();
            this.featuresLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.mainMenu.SuspendLayout();
            this.welcomePanel.SuspendLayout();
            this.featuresPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.helpMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(900, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.algorithmMenuItem,
            this.exitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileMenuItem.Text = "Файл";
            // 
            // algorithmMenuItem
            // 
            this.algorithmMenuItem.Name = "algorithmMenuItem";
            this.algorithmMenuItem.Size = new System.Drawing.Size(180, 22);
            this.algorithmMenuItem.Text = "Алгоритм MD5";
            this.algorithmMenuItem.Click += new System.EventHandler(this.AlgorithmMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitMenuItem.Text = "Выход";
            this.exitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.algorithmInfoMenuItem,
            this.aboutMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(65, 20);
            this.helpMenuItem.Text = "Справка";
            // 
            // algorithmInfoMenuItem
            // 
            this.algorithmInfoMenuItem.Name = "algorithmInfoMenuItem";
            this.algorithmInfoMenuItem.Size = new System.Drawing.Size(180, 22);
            this.algorithmInfoMenuItem.Text = "Об алгоритме";
            this.algorithmInfoMenuItem.Click += new System.EventHandler(this.AlgorithmInfoMenuItem_Click);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutMenuItem.Text = "О программе";
            this.aboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // welcomePanel
            // 
            this.welcomePanel.BackColor = System.Drawing.Color.White;
            this.welcomePanel.Controls.Add(this.featuresPanel);
            this.welcomePanel.Controls.Add(this.descriptionLabel);
            this.welcomePanel.Controls.Add(this.titleLabel);
            this.welcomePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.welcomePanel.Location = new System.Drawing.Point(0, 24);
            this.welcomePanel.Name = "welcomePanel";
            this.welcomePanel.Padding = new System.Windows.Forms.Padding(40);
            this.welcomePanel.Size = new System.Drawing.Size(900, 576);
            this.welcomePanel.TabIndex = 1;
            // 
            // featuresPanel
            // 
            this.featuresPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.featuresPanel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.featuresPanel.Controls.Add(this.featuresLabel);
            this.featuresPanel.Location = new System.Drawing.Point(40, 220);
            this.featuresPanel.Name = "featuresPanel";
            this.featuresPanel.Padding = new System.Windows.Forms.Padding(20);
            this.featuresPanel.Size = new System.Drawing.Size(400, 150);
            this.featuresPanel.TabIndex = 2;
            // 
            // featuresLabel
            // 
            this.featuresLabel.AutoSize = true;
            this.featuresLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.featuresLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.featuresLabel.Location = new System.Drawing.Point(20, 20);
            this.featuresLabel.Name = "featuresLabel";
            this.featuresLabel.Size = new System.Drawing.Size(334, 76);
            this.featuresLabel.TabIndex = 0;
            this.featuresLabel.Text = "✓ Поддержка файлов любого формата\n✓ Размер файла от 1 КБ\n✓ Быстрое вычисление хэ" +
    "ша\n✓ Удобный интерфейс";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.descriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.descriptionLabel.Location = new System.Drawing.Point(40, 130);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(527, 63);
            this.descriptionLabel.TabIndex = 1;
            this.descriptionLabel.Text = "Программа для вычисления MD5 хэша файлов\n\nВыберите пункт \'Алгоритм MD5\' в меню \'Ф" +
    "айл\' для начала работы.";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.titleLabel.Location = new System.Drawing.Point(40, 60);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(306, 45);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Калькулятор MD5 Хеша";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.welcomePanel);
            this.Controls.Add(this.mainMenu);
            this.Icon = System.Drawing.SystemIcons.Application;
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Калькулятор MD5 Хеша";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.welcomePanel.ResumeLayout(false);
            this.welcomePanel.PerformLayout();
            this.featuresPanel.ResumeLayout(false);
            this.featuresPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}