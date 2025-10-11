using System.Windows.Forms;
using System;

namespace lab1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            try
            {
                using var store = new Storage.EncryptedSqliteStore("users.authdb");
                var db = store.TryLoadOrCreate();

                using var login = new UI.FrmLogin(db, store);
                if (login.ShowDialog() != DialogResult.OK)
                    return;

                if (login.LoggedInUser?.UserName == "ADMIN")
                {
                    Application.Run(new UI.FrmAdmin(db, store, login.LoggedInUser!.UserName));
                }
                else
                {
                    Application.Run(new UI.FrmUser(db, store, login.LoggedInUser!));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}