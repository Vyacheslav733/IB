using System;
using System.Linq;
using System.Windows.Forms;
using lab1.Crypto;
using lab1.Domain;
using lab1.Storage;

namespace lab1.UI
{
    public partial class FrmLogin : Form
    {
        private readonly Database _db;
        private readonly EncryptedSqliteStore _store;

        private int _failCount = 0;
        public UserAccount? LoggedInUser { get; private set; }

        public FrmLogin(Database db, EncryptedSqliteStore store)
        {
            _db = db;
            _store = store;
            InitializeComponent();
        }

        private void aboutMenuItem_Click(object? sender, EventArgs e)
        {
            using var about = new FrmAbout();
            about.ShowDialog(this);
        }

        private bool IsPasswordCorrect(UserAccount user, string passwordInput)
        {
            if (string.IsNullOrEmpty(user.PasswordHash))
                return string.IsNullOrEmpty(passwordInput);

            var hash = PasswordHasher.Hash(passwordInput ?? string.Empty);
            return string.Equals(hash, user.PasswordHash, StringComparison.Ordinal);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var userName = (tbUser.Text ?? string.Empty).Trim();
            var pwd = tbPwd.Text ?? string.Empty;
            var confirmPwd = tbConfirmPwd.Text ?? string.Empty;

            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show(this, "Введите имя пользователя.", "Вход",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbUser.Focus();
                return;
            }

            if (pwd != confirmPwd)
            {
                _failCount++;

                if (_failCount >= 3)
                {
                    MessageBox.Show(this,
                        "3 неверных попытки ввода.\nПриложение будет закрыто.",
                        "Вход",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }

                var result = MessageBox.Show(this,
                    $"Пароль и подтверждение не совпадают. Попытка {_failCount} из 3.\n\nПовторить ввод?",
                    "Вход",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    tbPwd.Clear();
                    tbConfirmPwd.Clear();
                    tbPwd.Focus();
                }
                else
                {
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
                return;
            }

            var u = _db.Users.FirstOrDefault(x =>
                x.UserName.Equals(userName, StringComparison.Ordinal));

            if (u == null)
            {
                _failCount++;

                if (_failCount >= 3)
                {
                    MessageBox.Show(this,
                        "3 неверных попытки ввода.\nПриложение будет закрыто.",
                        "Вход",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }

                var result = MessageBox.Show(this,
                    $"Нет такого пользователя. Попытка {_failCount} из 3.\n\nПовторить ввод?",
                    "Вход",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    tbUser.Clear();
                    tbPwd.Clear();
                    tbConfirmPwd.Clear();
                    tbUser.Focus();
                }
                else
                {
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
                return;
            }

            if (u.IsBlocked)
            {
                MessageBox.Show(this, "Аккаунт заблокирован.", "Вход",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsPasswordCorrect(u, pwd))
            {
                _failCount++;

                if (_failCount >= 3)
                {
                    MessageBox.Show(this,
                        "3 неверных попытки ввода пароля.\nПриложение будет закрыто.",
                        "Вход",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }

                var result = MessageBox.Show(this,
                    $"Неверный пароль. Попытка {_failCount} из 3.\n\nПовторить ввод?",
                    "Вход",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    tbPwd.Clear();
                    tbConfirmPwd.Clear();
                    tbPwd.Focus();
                }
                else
                {
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
                return;
            }

            _failCount = 0;

            if (!string.IsNullOrEmpty(u.PasswordHash) &&
                u.ExpiryMonths > 0 &&
                u.PasswordSetAt.AddMonths(u.ExpiryMonths) < DateTime.UtcNow)
            {
                MessageBox.Show(this, "Срок действия пароля истёк — необходимо сменить пароль.", "Вход",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                using var ch = new FrmChangePassword(_db, _store, u);
                if (ch.ShowDialog(this) != DialogResult.OK)
                    return;
            }

            LoggedInUser = u;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}