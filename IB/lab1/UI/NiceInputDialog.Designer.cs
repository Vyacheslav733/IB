using System.Windows.Forms;

namespace lab1.UI
{
    internal sealed partial class NiceInputDialog
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel layout;
        private Label lblTitle;
        private TextBox tbInput;
        private FlowLayoutPanel pnlButtons;
        private Button btnOk, btnCancel;

        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            layout = new TableLayoutPanel();
            lblTitle = new Label();
            tbInput = new TextBox();
            pnlButtons = new FlowLayoutPanel();
            btnOk = new Button();
            btnCancel = new Button();

            SuspendLayout();
            layout.SuspendLayout();
            pnlButtons.SuspendLayout();

            // layout
            layout.ColumnCount = 1; layout.RowCount = 3; layout.Padding = new Padding(16);
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.Dock = DockStyle.Fill;
            layout.Controls.Add(lblTitle, 0, 0);
            layout.Controls.Add(tbInput, 0, 1);
            layout.Controls.Add(pnlButtons, 0, 2);

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblTitle.Margin = new Padding(0, 0, 0, 8);

            // tbInput
            tbInput.Dock = DockStyle.Top;
            tbInput.Margin = new Padding(0, 0, 0, 12);
            tbInput.MinimumSize = new System.Drawing.Size(380, 0);

            // buttons
            pnlButtons.FlowDirection = FlowDirection.RightToLeft;
            pnlButtons.AutoSize = true; pnlButtons.Dock = DockStyle.Fill;
            btnOk.Text = "OK"; btnOk.Width = 120; btnOk.Click += btnOk_Click;
            btnCancel.Text = "Отмена"; btnCancel.Width = 120; btnCancel.DialogResult = DialogResult.Cancel;
            pnlButtons.Controls.Add(btnOk); pnlButtons.Controls.Add(btnCancel);

            // form
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Font = new System.Drawing.Font("Segoe UI", 10F);
            Controls.Add(layout);
            AcceptButton = btnOk; CancelButton = btnCancel;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false; MinimizeBox = false;
            ClientSize = new System.Drawing.Size(560, 180);
            Text = "Ввод";

            pnlButtons.ResumeLayout(false);
            layout.ResumeLayout(false); layout.PerformLayout();
            ResumeLayout(false);
        }
    }
}