namespace lab2.UI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void AlgorithmMenuItem_Click(object sender, EventArgs e)
        {
            var algorithmForm = new FormAlgorithm();
            algorithmForm.Show();
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            using (var aboutForm = new FormAbout())
            {
                aboutForm.ShowDialog(this);
            }
        }

        private void AlgorithmInfoMenuItem_Click(object sender, EventArgs e)
        {
            using (var algorithmInfoForm = new FormAlgorithmInfo())
            {
                algorithmInfoForm.ShowDialog(this);
            }
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
