using System.Windows.Forms;

namespace lab1.UI
{
    public partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip;
        private ToolStripMenuItem helpMenuItem;
        private ToolStripMenuItem aboutMenuItem;
        private TableLayoutPanel layout;
        private Label lblHeader, lblUser, lblPwd, lblConfirmPwd;
        private TextBox tbUser, tbPwd, tbConfirmPwd;
        private FlowLayoutPanel buttons;
        private Button btnLogin, btnExit;

        protected override void Dispose(bool disposing)
        { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip = new MenuStrip();
            helpMenuItem = new ToolStripMenuItem();
            aboutMenuItem = new ToolStripMenuItem();
            layout = new TableLayoutPanel();
            lblHeader = new Label();
            lblUser = new Label();
            tbUser = new TextBox();
            lblPwd = new Label();
            tbPwd = new TextBox();
            lblConfirmPwd = new Label();
            tbConfirmPwd = new TextBox();
            buttons = new FlowLayoutPanel();
            menuStrip.SuspendLayout();
            btnLogin = new Button();
            btnExit = new Button();

            SuspendLayout();
            layout.SuspendLayout();
            buttons.SuspendLayout();

            // menuStrip
            menuStrip.Items.AddRange(new ToolStripItem[] { helpMenuItem });
            menuStrip.Location = new System.Drawing.Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new System.Drawing.Size(460, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip";

            // helpMenuItem
            helpMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutMenuItem });
            helpMenuItem.Name = "helpMenuItem";
            helpMenuItem.Size = new System.Drawing.Size(65, 20);
            helpMenuItem.Text = "Справка";

            // aboutMenuItem
            aboutMenuItem.Name = "aboutMenuItem";
            aboutMenuItem.Size = new System.Drawing.Size(147, 22);
            aboutMenuItem.Text = "О программе";
            aboutMenuItem.Click += aboutMenuItem_Click;

            // layout
            layout.ColumnCount = 2;
            layout.RowCount = 5; // Увеличили количество строк для нового поля
            layout.Padding = new Padding(16);
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.Dock = DockStyle.Fill;

            layout.Controls.Add(lblHeader, 0, 0);
            layout.SetColumnSpan(lblHeader, 2);
            layout.Controls.Add(lblUser, 0, 1);
            layout.Controls.Add(tbUser, 1, 1);
            layout.Controls.Add(lblPwd, 0, 2);
            layout.Controls.Add(tbPwd, 1, 2);
            layout.Controls.Add(lblConfirmPwd, 0, 3);
            layout.Controls.Add(tbConfirmPwd, 1, 3);
            layout.Controls.Add(buttons, 0, 4);
            layout.SetColumnSpan(buttons, 2);

            // header
            lblHeader.AutoSize = true;
            lblHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblHeader.Text = "Вход в систему";
            lblHeader.Margin = new Padding(0, 0, 0, 8);

            // labels
            lblUser.AutoSize = true;
            lblUser.Text = "Пользователь:";
            lblUser.Margin = new Padding(0, 6, 8, 0);

            lblPwd.AutoSize = true;
            lblPwd.Text = "Пароль:";
            lblPwd.Margin = new Padding(0, 6, 8, 0);

            lblConfirmPwd.AutoSize = true;
            lblConfirmPwd.Text = "Подтверждение:";
            lblConfirmPwd.Margin = new Padding(0, 6, 8, 0);

            // textboxes
            tbUser.Width = 240;
            tbPwd.Width = 240;
            tbPwd.UseSystemPasswordChar = true;
            tbConfirmPwd.Width = 240;
            tbConfirmPwd.UseSystemPasswordChar = true;

            // buttons
            buttons.FlowDirection = FlowDirection.RightToLeft;
            buttons.Dock = DockStyle.Fill;
            buttons.Controls.Add(btnLogin);
            buttons.Controls.Add(btnExit);

            btnLogin.Text = "&Войти";
            btnLogin.Width = 110;
            btnLogin.Click += btnLogin_Click;

            btnExit.Text = "В&ыход";
            btnExit.Width = 110;
            btnExit.Click += btnExit_Click;

            // form
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(460, 250);
            Controls.Add(layout);
            Controls.Add(menuStrip);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Вход";
            AcceptButton = btnLogin;
            CancelButton = btnExit;
            MainMenuStrip = menuStrip;

            buttons.ResumeLayout(false);
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            layout.ResumeLayout(false);
            layout.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}