using System.Windows.Forms;

namespace lab1.UI
{
    partial class FrmAdmin
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip;
        private ToolStripMenuItem helpMenuItem;
        private ToolStripMenuItem aboutMenuItem;
        private SplitContainer split;
        private DataGridView gridUsers;
        private Panel panelRight;
        private Label lblHeader;
        private TableLayoutPanel actions;
        private Button btnAdd, btnBlock, btnPolicy, btnSave, btnChangePassword, btnExit;

        private DataGridViewTextBoxColumn colUser;
        private DataGridViewCheckBoxColumn colBlocked;
        private DataGridViewCheckBoxColumn colPolicy;
        private DataGridViewTextBoxColumn colMin;
        private DataGridViewTextBoxColumn colExpiry;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            menuStrip = new MenuStrip();
            helpMenuItem = new ToolStripMenuItem();
            aboutMenuItem = new ToolStripMenuItem();
            split = new SplitContainer();
            gridUsers = new DataGridView();
            colUser = new DataGridViewTextBoxColumn();
            colBlocked = new DataGridViewCheckBoxColumn();
            colPolicy = new DataGridViewCheckBoxColumn();
            colMin = new DataGridViewTextBoxColumn();
            colExpiry = new DataGridViewTextBoxColumn();
            panelRight = new Panel();
            actions = new TableLayoutPanel();
            btnAdd = new Button();
            btnBlock = new Button();
            btnPolicy = new Button();
            btnSave = new Button();
            btnChangePassword = new Button();
            btnExit = new Button();
            lblHeader = new Label();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)split).BeginInit();
            split.Panel1.SuspendLayout();
            split.Panel2.SuspendLayout();
            split.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridUsers).BeginInit();
            panelRight.SuspendLayout();
            actions.SuspendLayout();
            SuspendLayout();
            //
            // menuStrip
            //
            menuStrip.Items.AddRange(new ToolStripItem[] { helpMenuItem });
            menuStrip.Location = new System.Drawing.Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new System.Drawing.Size(2229, 33);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip";
            //
            // helpMenuItem
            //
            helpMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutMenuItem });
            helpMenuItem.Name = "helpMenuItem";
            helpMenuItem.Size = new System.Drawing.Size(104, 29);
            helpMenuItem.Text = "Справка";
            //
            // aboutMenuItem
            //
            aboutMenuItem.Name = "aboutMenuItem";
            aboutMenuItem.Size = new System.Drawing.Size(220, 34);
            aboutMenuItem.Text = "О программе";
            aboutMenuItem.Click += aboutMenuItem_Click;
            // 
            // split
            // 
            split.Dock = DockStyle.Fill;
            split.Location = new System.Drawing.Point(0, 33);
            split.Margin = new Padding(6, 6, 6, 6);
            split.Name = "split";
            // 
            // split.Panel1
            // 
            split.Panel1.Controls.Add(gridUsers);
            // 
            // split.Panel2
            // 
            split.Panel2.BackColor = System.Drawing.Color.FromArgb(247, 247, 247);
            split.Panel2.Controls.Add(panelRight);
            split.Size = new System.Drawing.Size(2229, 1536);
            split.SplitterDistance = 1448;
            split.SplitterWidth = 7;
            split.TabIndex = 0;
            // 
            // gridUsers
            // 
            gridUsers.AllowUserToAddRows = false;
            gridUsers.AllowUserToDeleteRows = false;
            gridUsers.AllowUserToResizeRows = false;
            gridUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridUsers.BackgroundColor = System.Drawing.Color.White;
            gridUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridUsers.ColumnHeadersHeight = 46;
            gridUsers.Columns.AddRange(new DataGridViewColumn[] { colUser, colBlocked, colPolicy, colMin, colExpiry });
            gridUsers.Dock = DockStyle.Fill;
            gridUsers.EditMode = DataGridViewEditMode.EditProgrammatically;
            gridUsers.EnableHeadersVisualStyles = false;
            gridUsers.Location = new System.Drawing.Point(0, 0);
            gridUsers.Margin = new Padding(6, 6, 6, 6);
            gridUsers.Name = "gridUsers";
            gridUsers.ReadOnly = true;
            gridUsers.RowHeadersVisible = false;
            gridUsers.RowHeadersWidth = 82;
            gridUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridUsers.Size = new System.Drawing.Size(1448, 1536);
            gridUsers.TabIndex = 0;
            // 
            // colUser
            // 
            colUser.HeaderText = "Имя пользователя";
            colUser.MinimumWidth = 10;
            colUser.Name = "colUser";
            colUser.ReadOnly = true;
            // 
            // colBlocked
            // 
            colBlocked.HeaderText = "Блокировка";
            colBlocked.MinimumWidth = 10;
            colBlocked.Name = "colBlocked";
            colBlocked.ReadOnly = true;
            // 
            // colPolicy
            // 
            colPolicy.HeaderText = "Политика";
            colPolicy.MinimumWidth = 10;
            colPolicy.Name = "colPolicy";
            colPolicy.ReadOnly = true;
            // 
            // colMin
            // 
            colMin.HeaderText = "Мин. длина";
            colMin.MinimumWidth = 10;
            colMin.Name = "colMin";
            colMin.ReadOnly = true;
            // 
            // colExpiry
            // 
            colExpiry.HeaderText = "Срок (мес.)";
            colExpiry.MinimumWidth = 10;
            colExpiry.Name = "colExpiry";
            colExpiry.ReadOnly = true;
            // 
            // panelRight
            // 
            panelRight.Controls.Add(actions);
            panelRight.Controls.Add(lblHeader);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new System.Drawing.Point(0, 0);
            panelRight.Margin = new Padding(6, 6, 6, 6);
            panelRight.Name = "panelRight";
            panelRight.Padding = new Padding(45, 51, 45, 51);
            panelRight.Size = new System.Drawing.Size(774, 1536);
            panelRight.TabIndex = 0;
            // 
            // actions
            // 
            actions.AutoSize = true;
            actions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            actions.ColumnCount = 1;
            actions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            actions.Controls.Add(btnAdd, 0, 0);
            actions.Controls.Add(btnBlock, 0, 1);
            actions.Controls.Add(btnPolicy, 0, 2);
            actions.Controls.Add(btnSave, 0, 3);
            actions.Controls.Add(btnChangePassword, 0, 4);
            actions.Controls.Add(btnExit, 0, 5);
            actions.Dock = DockStyle.Top;
            actions.Location = new System.Drawing.Point(45, 136);
            actions.Margin = new Padding(6, 6, 6, 6);
            actions.Name = "actions";
            actions.Padding = new Padding(22, 26, 22, 26);
            actions.RowCount = 6;
            actions.RowStyles.Add(new RowStyle());
            actions.RowStyles.Add(new RowStyle());
            actions.RowStyles.Add(new RowStyle());
            actions.RowStyles.Add(new RowStyle());
            actions.RowStyles.Add(new RowStyle());
            actions.RowStyles.Add(new RowStyle());
            actions.Size = new System.Drawing.Size(684, 532);
            actions.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = System.Drawing.Color.White;
            btnAdd.Dock = DockStyle.Fill;
            btnAdd.Location = new System.Drawing.Point(44, 39);
            btnAdd.Margin = new Padding(22, 13, 22, 13);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(596, 94);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnBlock
            // 
            btnBlock.BackColor = System.Drawing.Color.White;
            btnBlock.Dock = DockStyle.Fill;
            btnBlock.Location = new System.Drawing.Point(44, 159);
            btnBlock.Margin = new Padding(22, 13, 22, 13);
            btnBlock.Name = "btnBlock";
            btnBlock.Size = new System.Drawing.Size(596, 94);
            btnBlock.TabIndex = 1;
            btnBlock.Text = "Блок / Разблок";
            btnBlock.UseVisualStyleBackColor = false;
            btnBlock.Click += btnBlock_Click;
            // 
            // btnPolicy
            // 
            btnPolicy.BackColor = System.Drawing.Color.White;
            btnPolicy.Dock = DockStyle.Fill;
            btnPolicy.Location = new System.Drawing.Point(44, 279);
            btnPolicy.Margin = new Padding(22, 13, 22, 13);
            btnPolicy.Name = "btnPolicy";
            btnPolicy.Size = new System.Drawing.Size(596, 94);
            btnPolicy.TabIndex = 2;
            btnPolicy.Text = "Ограничения";
            btnPolicy.UseVisualStyleBackColor = false;
            btnPolicy.Click += btnPolicy_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = System.Drawing.Color.White;
            btnSave.Dock = DockStyle.Fill;
            btnSave.Location = new System.Drawing.Point(44, 399);
            btnSave.Margin = new Padding(22, 13, 22, 13);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(596, 94);
            btnSave.TabIndex = 3;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            //
            // btnChangePassword
            //
            btnChangePassword.BackColor = System.Drawing.Color.White;
            btnChangePassword.Dock = DockStyle.Fill;
            btnChangePassword.Location = new System.Drawing.Point(44, 519);
            btnChangePassword.Margin = new Padding(22, 13, 22, 13);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new System.Drawing.Size(596, 94);
            btnChangePassword.TabIndex = 4;
            btnChangePassword.Text = "Сменить пароль";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click;
            //
            // btnExit
            //
            btnExit.BackColor = System.Drawing.Color.White;
            btnExit.Dock = DockStyle.Fill;
            btnExit.Location = new System.Drawing.Point(44, 639);
            btnExit.Margin = new Padding(22, 13, 22, 13);
            btnExit.Name = "btnExit";
            btnExit.Size = new System.Drawing.Size(596, 94);
            btnExit.TabIndex = 5;
            btnExit.Text = "Выход";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            lblHeader.Location = new System.Drawing.Point(45, 51);
            lblHeader.Margin = new Padding(6, 0, 6, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new System.Drawing.Size(684, 85);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "Панель администратора";
            lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmAdmin
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(2229, 1536);
            Controls.Add(split);
            Controls.Add(menuStrip);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            Margin = new Padding(6, 6, 6, 6);
            MinimumSize = new System.Drawing.Size(1761, 1072);
            Name = "FrmAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Администрирование";
            MainMenuStrip = menuStrip;
            split.Panel1.ResumeLayout(false);
            split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)split).EndInit();
            split.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridUsers).EndInit();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            actions.ResumeLayout(false);
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
