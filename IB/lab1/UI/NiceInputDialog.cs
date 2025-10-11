using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1.UI
{
    internal sealed partial class NiceInputDialog : Form
    {
        public string ResultText => tbInput.Text;

        public NiceInputDialog(string caption, string title, string defaultValue = "")
        {
            InitializeComponent();
            Text = caption;
            lblTitle.Text = title;
            tbInput.Text = defaultValue;
        }

        public static bool Show(IWin32Window owner, string caption, string title,
                                out string text, string defaultValue = "")
        {
            using var dlg = new NiceInputDialog(caption, title, defaultValue);
            var res = dlg.ShowDialog(owner);
            text = res == DialogResult.OK ? dlg.ResultText : string.Empty;
            return res == DialogResult.OK;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
