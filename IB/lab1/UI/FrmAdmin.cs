using lab1.Domain;
using lab1.Storage;
using System;
using System.Linq;
using System.Windows.Forms;

namespace lab1.UI
{
    public partial class FrmAdmin : Form
    {
        private readonly Database _db;
        private readonly EncryptedSqliteStore _store;
        private readonly string _currentUserName;

        public FrmAdmin(Database db, EncryptedSqliteStore store, string currentUserName)
        {
            _db = db; _store = store;
            _currentUserName = currentUserName;
            InitializeComponent();

            Shown += (_, __) => AdjustSplitter(initial: true);
            SizeChanged += (_, __) => AdjustSplitter();

            RefreshList();
        }

        private void aboutMenuItem_Click(object? sender, EventArgs e)
        {
            using var about = new FrmAbout();
            about.ShowDialog(this);
        }

        private void AdjustSplitter(bool initial = false)
        {
            if (split.Width <= 0) return;
            int desiredRight = 650;
            int minLeft = Math.Max(split.Panel1MinSize, 150);
            if (split.Width - desiredRight < minLeft)
                desiredRight = Math.Max(200, split.Width / 3);

            try
            {
                split.Panel2MinSize = desiredRight;
                int left = Math.Max(minLeft, split.Width - desiredRight);
                int maxLeft = split.Width - split.Panel2MinSize;
                if (left > maxLeft) left = maxLeft;
                if (left < minLeft) left = minLeft;
                if (left >= 0 && left <= split.Width) split.SplitterDistance = left;
            }
            catch { if (!initial) return; }
        }

        private void RefreshList()
        {
            gridUsers.Rows.Clear();

            var users = _db.Users
            .Where(u => !u.UserName.Equals(_currentUserName, StringComparison.Ordinal));

            foreach (var u in users)
            {
                gridUsers.Rows.Add(
                    u.UserName,
                    u.IsBlocked,
                    u.PasswordPolicyOn,
                    u.MinLength,
                    u.ExpiryMonths > 0 ? u.ExpiryMonths.ToString() : "—"
                );
            }

            if (gridUsers.Rows.Count > 0)
                gridUsers.Rows[0].Selected = true;
        }

        private UserAccount? GetCurrentUser()
        {
            return _db.Users.FirstOrDefault(u =>
                u.UserName.Equals(_currentUserName, StringComparison.Ordinal));
        }

        private UserAccount? GetSelectedUser()
        {
            if (gridUsers.CurrentRow == null) return null;
            var name = gridUsers.CurrentRow.Cells[0].Value?.ToString();
            if (string.Equals(name, _currentUserName, StringComparison.Ordinal)) return null;
            return _db.Users.FirstOrDefault(x => x.UserName == name);
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!NiceInputDialog.Show(this, "Добавить пользователя", "Имя пользователя", out var name, "user1"))
                return;

            name = (name ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(name)) return;

            if (_db.Users.Any(x => x.UserName.Equals(name, StringComparison.Ordinal)))
            { MessageBox.Show(this, "Пользователь уже существует", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var list = _db.Users.ToList();
            list.Add(new UserAccount { UserName = name, PasswordHash = string.Empty, PasswordPolicyOn = false, MinLength = 0, ExpiryMonths = 0 });
            _db.Users = list.ToArray();
            RefreshList();
        }

        private void btnBlock_Click(object? sender, EventArgs e)
        {
            var u = GetSelectedUser(); 
            if (u == null) return;

            if (string.Equals(u.UserName, _currentUserName, StringComparison.Ordinal))
            {
                MessageBox.Show(this, "Нельзя блокировать текущего пользователя.", "Блокировка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            u.IsBlocked = !u.IsBlocked;
            RefreshList();
        }

        private void btnPolicy_Click(object? sender, EventArgs e)
        {
            var u = GetSelectedUser(); if (u == null) return;

            if (!PolicyDialog.Show(this, u.MinLength, u.ExpiryMonths, u.PasswordPolicyOn,
                                   out var m, out var exp, out var on)) return;

            u.MinLength = m;
            u.ExpiryMonths = exp;
            u.PasswordPolicyOn = on;
            RefreshList();
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            _store.Save(_db);
            MessageBox.Show(this, "Изменения сохранены.", "База пользователей", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnChangePassword_Click(object? sender, EventArgs e)
        {
            var currentUser = GetCurrentUser();
            if (currentUser == null)
            {
                MessageBox.Show(this, "Текущий пользователь не найден.", "Смена пароля",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using var change = new FrmChangePassword(_db, _store, currentUser);
            change.ShowDialog(this);
        }

        private void btnExit_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
