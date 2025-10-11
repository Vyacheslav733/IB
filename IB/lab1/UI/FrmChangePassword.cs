using System;
using System.Windows.Forms;
using lab1.Crypto;
using lab1.Domain;
using lab1.Policies;
using lab1.Storage;

namespace lab1.UI
{
    public partial class FrmChangePassword : Form
    {
        private readonly Database _db;
        private readonly EncryptedSqliteStore _store;
        private readonly UserAccount _user;

        public FrmChangePassword(Database db, EncryptedSqliteStore store, UserAccount user)
        {
            _db = db;
            _store = store;
            _user = user;

            InitializeComponent();

            this.Load += (_, __) =>
            {
                if (string.IsNullOrEmpty(_user.PasswordHash))
                    lblOld.Text = "Старый пароль (не задан):";
            };
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            var oldPwd = tbOld.Text ?? string.Empty;
            var newPwd = tbNew.Text ?? string.Empty;
            var repPwd = tbRep.Text ?? string.Empty;

            if (!string.IsNullOrEmpty(_user.PasswordHash))
            {
                var oldHash = PasswordHasher.Hash(oldPwd);
                if (!string.Equals(oldHash, _user.PasswordHash, StringComparison.Ordinal))
                {
                    MessageBox.Show(this, "Старый пароль неверен.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbOld.Focus();
                    return;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(oldPwd))
                {
                    MessageBox.Show(this, "Старый пароль ещё не задан. Оставьте поле пустым.", "Подсказка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbOld.Focus();
                    return;
                }
            }

            if (!string.Equals(newPwd, repPwd, StringComparison.Ordinal))
            {
                MessageBox.Show(this, "Подтверждение пароля не совпадает.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbRep.Focus();
                return;
            }

            var (ok, err) = PasswordPolicy.ValidateAll(newPwd, _user);
            if (!ok)
            {
                MessageBox.Show(this, err, "Пароль не соответствует требованиям",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbNew.Focus();
                return;
            }

            _user.PasswordHash = PasswordHasher.Hash(newPwd);
            _user.PasswordSetAt = DateTime.UtcNow;
            _store.Save(_db);

            MessageBox.Show(this, "Пароль успешно изменён.", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
