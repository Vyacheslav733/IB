using lab2.Crypto;
using System.ComponentModel;

namespace lab2.UI
{
    public partial class FormAlgorithm : Form
    {
        private BackgroundWorker? backgroundWorker;

        public FormAlgorithm()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
        }

        private void InitializeBackgroundWorker()
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Выберите файл для вычисления хэша";
                openFileDialog.Filter = "Все файлы (*.*)|*.*";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileInfo = new FileInfo(openFileDialog.FileName);
                    if (fileInfo.Length >= 1024)
                    {
                        filePathTextBox.Text = openFileDialog.FileName;
                        calculateHashButton.Enabled = true;
                        hashResultTextBox.Clear();
                        progressBar.Value = 0;
                        statusLabel.Text = "Файл выбран. Нажмите 'Вычислить хэш'";
                        statusLabel.ForeColor = Color.FromArgb(40, 167, 69);
                    }
                    else
                    {
                        statusLabel.Text = "Ошибка: файл должен быть не менее 1 КБ";
                        statusLabel.ForeColor = Color.FromArgb(220, 53, 69);
                        calculateHashButton.Enabled = false;
                    }
                }
            }
        }

        private void CalculateHashButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(filePathTextBox.Text) ||
                !File.Exists(filePathTextBox.Text))
            {
                statusLabel.Text = "Ошибка: файл не выбран или не существует";
                statusLabel.ForeColor = Color.FromArgb(220, 53, 69);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                calculateHashButton.Enabled = false;
                selectFileButton.Enabled = false;
                progressBar.Visible = true;
                progressBar.Value = 0;
                statusLabel.Text = "Вычисление хэша...";
                statusLabel.ForeColor = Color.FromArgb(255, 193, 7);

                cancelButton.Visible = true;

                // Запускаем вычисление в фоновом потоке
                backgroundWorker?.RunWorkerAsync(filePathTextBox.Text);
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка: {ex.Message}");
            }
        }

        private void BackgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            string? filePath = e.Argument as string;
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("Путь к файлу не может быть пустым");
            }

            var md5Calculator = new Md5();

            try
            {
                // Вычисляем хэш с отслеживанием прогресса
                string hash = md5Calculator.ComputeFileHashWithProgress(filePath,
                    progress => backgroundWorker?.ReportProgress(progress),
                    backgroundWorker);
                e.Result = hash;
            }
            catch (OperationCanceledException)
            {
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        private void BackgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            statusLabel.Text = $"Вычисление хэша... {e.ProgressPercentage}%";
        }

        private void BackgroundWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            calculateHashButton.Enabled = true;
            selectFileButton.Enabled = true;

            cancelButton.Visible = false;
            cancelButton.Enabled = true;

            if (e.Error != null)
            {
                ShowError($"Ошибка: {e.Error.Message}");
            }
            else if (e.Cancelled)
            {
                ShowError("Операция отменена");
            }
            else if (e.Result is Exception ex)
            {
                ShowError($"Ошибка: {ex.Message}");
            }
            else
            {
                string? hash = e.Result as string;
                hashResultTextBox.Text = hash ?? string.Empty;
                progressBar.Value = 100;
                statusLabel.Text = "Хэш успешно вычислен";
                statusLabel.ForeColor = Color.FromArgb(40, 167, 69);

                // Через 2 секунды скрываем прогресс-бар
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 2000;
                timer.Tick += (s, args) =>
                {
                    progressBar.Visible = false;
                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start();
            }
        }

        private void ShowError(string message)
        {
            statusLabel.Text = message;
            statusLabel.ForeColor = Color.FromArgb(220, 53, 69);
            hashResultTextBox.Clear();
            progressBar.Visible = false;

            cancelButton.Visible = false;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker?.IsBusy == true)
            {
                backgroundWorker.CancelAsync();
                statusLabel.Text = "Отмена операции...";
                statusLabel.ForeColor = Color.FromArgb(255, 193, 7);

                cancelButton.Enabled = false;
            }
        }
    }
}