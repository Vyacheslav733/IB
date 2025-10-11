using System.Windows.Forms;

namespace lab1.UI
{
    internal sealed partial class PolicyDialog : Form
    {
        private System.ComponentModel.IContainer? components = null;
        private TableLayoutPanel root, layout;
        private Label lblHead, lblMin, lblExp;
        internal NumericUpDown numMin, numExp;
        internal CheckBox chkPolicy;
        private FlowLayoutPanel pnlButtons;
        private Button btnOk, btnCancel;

        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            root = new TableLayoutPanel();
            layout = new TableLayoutPanel();
            lblHead = new Label();
            lblMin = new Label();
            numMin = new NumericUpDown();
            lblExp = new Label();
            numExp = new NumericUpDown();
            chkPolicy = new CheckBox();
            pnlButtons = new FlowLayoutPanel();
            btnOk = new Button();
            btnCancel = new Button();

            root.SuspendLayout();
            layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numExp).BeginInit();
            pnlButtons.SuspendLayout();
            SuspendLayout();

            // root
            root.ColumnCount = 1;
            root.RowCount = 2;
            root.Padding = new Padding(12);
            root.Dock = DockStyle.Fill;
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // layout
            layout.AutoSize = true;
            layout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            layout.ColumnCount = 2;
            layout.ColumnStyles.Add(new ColumnStyle());
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowCount = 4;
            layout.RowStyles.Add(new RowStyle());
            layout.RowStyles.Add(new RowStyle());
            layout.RowStyles.Add(new RowStyle());
            layout.RowStyles.Add(new RowStyle());
            layout.Dock = DockStyle.Top;

            // header
            lblHead.AutoSize = true;
            lblHead.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblHead.Text = "Настройки политики паролей";
            lblHead.Margin = new Padding(0, 0, 0, 10);
            layout.Controls.Add(lblHead, 0, 0);
            layout.SetColumnSpan(lblHead, 2);

            // min
            lblMin.AutoSize = true;
            lblMin.Text = "Мин. длина:";
            lblMin.Margin = new Padding(0, 6, 8, 0);
            layout.Controls.Add(lblMin, 0, 1);

            numMin.Minimum = 0;
            numMin.Maximum = 128;
            numMin.Width = 120;
            layout.Controls.Add(numMin, 1, 1);

            // expiry
            lblExp.AutoSize = true;
            lblExp.Text = "Срок (мес.):";
            lblExp.Margin = new Padding(0, 6, 8, 0);
            layout.Controls.Add(lblExp, 0, 2);

            numExp.Minimum = 0;
            numExp.Maximum = 120;
            numExp.Width = 120;
            layout.Controls.Add(numExp, 1, 2);

            // checkbox
            chkPolicy.AutoSize = true;
            chkPolicy.Text = "Включить правила паролей";
            chkPolicy.Margin = new Padding(0, 10, 0, 0);
            layout.Controls.Add(chkPolicy, 0, 3);
            layout.SetColumnSpan(chkPolicy, 2);

            // buttons
            pnlButtons.FlowDirection = FlowDirection.RightToLeft;
            pnlButtons.AutoSize = true;
            pnlButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlButtons.Anchor = AnchorStyles.Right;

            btnOk.AutoSize = true;
            btnOk.Text = "OK";
            btnOk.Margin = new Padding(8, 0, 0, 0);
            btnOk.Click += btnOk_Click;

            btnCancel.AutoSize = true;
            btnCancel.Text = "Отмена";
            btnCancel.DialogResult = DialogResult.Cancel;

            pnlButtons.Controls.Add(btnOk);
            pnlButtons.Controls.Add(btnCancel);

            // compose
            root.Controls.Add(layout, 0, 0);
            root.Controls.Add(pnlButtons, 0, 1);
            Controls.Add(root);

            // form
            AutoScaleMode = AutoScaleMode.None;
            Font = new System.Drawing.Font("Segoe UI", 10F);
            AcceptButton = btnOk;
            CancelButton = btnCancel;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimumSize = new System.Drawing.Size(460, 280);
            ClientSize = new System.Drawing.Size(520, 300);
            Text = "Ограничения пароля";
            pnlButtons.ResumeLayout(false);
            pnlButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)numExp).EndInit();
            layout.ResumeLayout(false);
            layout.PerformLayout();
            root.ResumeLayout(false);
            root.PerformLayout();
            ResumeLayout(false);
        }
    }
}
