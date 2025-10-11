namespace lab1.UI
{
    partial class FrmUser
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.TableLayoutPanel layout;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnExit;
        

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip = new System.Windows.Forms.MenuStrip();
            helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            layout = new System.Windows.Forms.TableLayoutPanel();
            lblHeader = new System.Windows.Forms.Label();
            btnChange = new System.Windows.Forms.Button();
            btnExit = new System.Windows.Forms.Button();
            layout.SuspendLayout();
            menuStrip.SuspendLayout();
            SuspendLayout();

            // === menuStrip ===
            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { helpMenuItem });
            menuStrip.Location = new System.Drawing.Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new System.Drawing.Size(420, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip";

            // === helpMenuItem ===
            helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { aboutMenuItem });
            helpMenuItem.Name = "helpMenuItem";
            helpMenuItem.Size = new System.Drawing.Size(65, 20);
            helpMenuItem.Text = "Справка";

            // === aboutMenuItem ===
            aboutMenuItem.Name = "aboutMenuItem";
            aboutMenuItem.Size = new System.Drawing.Size(147, 22);
            aboutMenuItem.Text = "О программе";
            aboutMenuItem.Click += aboutMenuItem_Click;

            // === layout ===
            layout.ColumnCount = 1;
            layout.RowCount = 3;
            layout.Padding = new System.Windows.Forms.Padding(16);
            layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            layout.Dock = System.Windows.Forms.DockStyle.Fill;

            // === header ===
            lblHeader.AutoSize = true;
            lblHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblHeader.Text = "Панель пользователя";
            lblHeader.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);

            // === кнопка смены пароля ===
            btnChange.Text = "Сменить пароль";
            btnChange.Width = 200;
            btnChange.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            btnChange.Click += btnChange_Click;

            // === кнопка выхода ===
            btnExit.Text = "Завершить работу";
            btnExit.Width = 200;
            btnExit.Click += btnExit_Click;

            // === добавить в layout ===
            layout.Controls.Add(lblHeader, 0, 0);
            layout.Controls.Add(btnChange, 0, 1);
            layout.Controls.Add(btnExit, 0, 2);

            // === форма ===
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(420, 200);
            Controls.Add(layout);
            Controls.Add(menuStrip);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Пользователь";
            MainMenuStrip = menuStrip;

            layout.ResumeLayout(false);
            layout.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}