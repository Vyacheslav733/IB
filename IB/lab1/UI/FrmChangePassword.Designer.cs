using System.Windows.Forms;

namespace lab1.UI
{
    partial class FrmChangePassword
    {
        private System.ComponentModel.IContainer? components = null;

        private TableLayoutPanel layout;
        private Label lblHeader, lblOld, lblNew, lblRep;
        private TextBox tbOld, tbNew, tbRep;
        private FlowLayoutPanel buttons;
        private Button btnSave, btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            layout = new TableLayoutPanel();
            lblHeader = new Label();
            lblOld = new Label();
            lblNew = new Label();
            lblRep = new Label();
            tbOld = new TextBox();
            tbNew = new TextBox();
            tbRep = new TextBox();
            buttons = new FlowLayoutPanel();
            btnSave = new Button();
            btnCancel = new Button();

            SuspendLayout();

            layout.ColumnCount = 2;
            layout.RowCount = 5;
            layout.Padding = new Padding(16);
            layout.Dock = DockStyle.Fill;

            layout.ColumnStyles.Clear();
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            lblHeader.AutoSize = true;
            lblHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblHeader.Text = "Смена пароля";
            lblHeader.Margin = new Padding(0, 0, 0, 12);
            lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            lblOld.AutoSize = true; lblOld.Text = "Старый пароль:";
            lblNew.AutoSize = true; lblNew.Text = "Новый пароль:";
            lblRep.AutoSize = true; lblRep.Text = "Повторите пароль:";

            foreach (var tb in new[] { tbOld, tbNew, tbRep })
            {
                tb.Dock = DockStyle.Fill;
                tb.Margin = new Padding(0, 4, 0, 4);
                tb.BorderStyle = BorderStyle.FixedSingle;
                tb.UseSystemPasswordChar = true;
            }

            buttons.AutoSize = true;
            buttons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttons.FlowDirection = FlowDirection.RightToLeft;
            buttons.Dock = DockStyle.None;
            buttons.Anchor = AnchorStyles.Right;
            buttons.Padding = new Padding(0, 12, 0, 0);

            btnSave.Text = "Сохранить";
            btnSave.AutoSize = true;
            btnSave.Click += btnSave_Click;

            btnCancel.Text = "Отмена";
            btnCancel.AutoSize = true;
            btnCancel.DialogResult = DialogResult.Cancel;

            buttons.Controls.Add(btnSave);
            buttons.Controls.Add(btnCancel);

            layout.Controls.Add(lblHeader, 0, 0);
            layout.SetColumnSpan(lblHeader, 2);

            layout.Controls.Add(lblOld, 0, 1);
            layout.Controls.Add(tbOld, 1, 1);

            layout.Controls.Add(lblNew, 0, 2);
            layout.Controls.Add(tbNew, 1, 2);

            layout.Controls.Add(lblRep, 0, 3);
            layout.Controls.Add(tbRep, 1, 3);

            layout.Controls.Add(buttons, 0, 4);
            layout.SetColumnSpan(buttons, 2);

            Controls.Add(layout);

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(560, 260);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            Text = "Смена пароля";
            AcceptButton = btnSave;
            CancelButton = btnCancel;

            ResumeLayout(false);
        }
    }
}
