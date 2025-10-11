using lab1.Domain;
using lab1.Storage;
using System;
using System.Windows.Forms;

namespace lab1.UI
{
    public partial class FrmUser : Form
    {
        private readonly Database _db;
        private readonly EncryptedSqliteStore _store;
        private readonly UserAccount _user;

        public FrmUser(Database db, EncryptedSqliteStore store, UserAccount user)
        {
            _db = db;
            _store = store;
            _user = user;

            InitializeComponent();
            Text = $"Пользователь: {_user.UserName}";
        }

        private void aboutMenuItem_Click(object? sender, EventArgs e)
        {
            using var about = new FrmAbout();
            about.ShowDialog(this);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            using (var ch = new FrmChangePassword(_db, _store, _user))
                ch.ShowDialog(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
