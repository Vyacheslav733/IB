using System;
using System.Windows.Forms;

namespace lab1.UI
{
    internal sealed partial class PolicyDialog : Form
    {
        public PolicyDialog()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        public static bool Show(
            IWin32Window owner,
            int currentMinLength,
            int currentExpiryMonths,
            bool currentPolicyOn,
            out int newMinLength,
            out int newExpiryMonths,
            out bool newPolicyOn)
        {
            using var dlg = new PolicyDialog();
            
            dlg.numMin.Value = Clamp(currentMinLength, (int)dlg.numMin.Minimum, (int)dlg.numMin.Maximum);
            dlg.numExp.Value = Clamp(currentExpiryMonths, (int)dlg.numExp.Minimum, (int)dlg.numExp.Maximum);
            dlg.chkPolicy.Checked = currentPolicyOn;

            if (dlg.ShowDialog(owner) == DialogResult.OK)
            {
                newMinLength = (int)dlg.numMin.Value;
                newExpiryMonths = (int)dlg.numExp.Value;
                newPolicyOn = dlg.chkPolicy.Checked;
                return true;
            }

            newMinLength = currentMinLength;
            newExpiryMonths = currentExpiryMonths;
            newPolicyOn = currentPolicyOn;
            return false;
        }

        private static int Clamp(int v, int min, int max)
            => v < min ? min : (v > max ? max : v);
    }
}
