using lab3.Crypto;
using System.ComponentModel;
using System.Text;

namespace lab3.UI
{
    public partial class FormAlgorithm : Form
    {
        private BackgroundWorker? backgroundWorker;
        private DES_CFB desCfb;

        public FormAlgorithm()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
            desCfb = new DES_CFB();
            UpdateButtonStates();
        }

        private void InitializeBackgroundWorker()
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

        private void SelectInputFileButton_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Выберите исходный файл";
                openFileDialog.Filter = "Все файлы (*.*)|*.*";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileInfo = new FileInfo(openFileDialog.FileName);
                    if (fileInfo.Length >= 1024)
                    {
                        inputFilePathTextBox.Text = openFileDialog.FileName;
                        UpdateButtonStates();
                        statusLabel.Text = "Исходный файл выбран. Введите ключ и выберите файл назначения";
                        statusLabel.ForeColor = Color.FromArgb(40, 167, 69);
                    }
                    else
                    {
                        statusLabel.Text = "Ошибка: файл должен быть не менее 1 КБ";
                        statusLabel.ForeColor = Color.FromArgb(220, 53, 69);
                    }
                }
            }
        }

        private void SelectOutputFileButton_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Выберите файл назначения";
                saveFileDialog.Filter = "Все файлы (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    outputFilePathTextBox.Text = saveFileDialog.FileName;
                    UpdateButtonStates();
                    statusLabel.Text = "Файл назначения выбран. Готов к работе";
                    statusLabel.ForeColor = Color.FromArgb(40, 167, 69);
                }
            }
        }

        private void SelectKeyFileButton_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Выберите файл с ключом";
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string keyFromFile = File.ReadAllText(openFileDialog.FileName, Encoding.UTF8).Trim();
                        if (keyFromFile.Length == 8)
                        {
                            keyTextBox.Text = keyFromFile;
                            keyTextBox.PasswordChar = '*';
                            UpdateButtonStates();
                            ValidateKey();
                            statusLabel.Text = "Ключ загружен из файла";
                            statusLabel.ForeColor = Color.FromArgb(40, 167, 69);
                        }
                        else
                        {
                            statusLabel.Text = "Ошибка: ключ в файле должен быть длиной 8 символов";
                            statusLabel.ForeColor = Color.FromArgb(220, 53, 69);
                        }
                    }
                    catch (Exception ex)
                    {
                        statusLabel.Text = $"Ошибка чтения файла ключа: {ex.Message}";
                        statusLabel.ForeColor = Color.FromArgb(220, 53, 69);
                    }
                }
            }
        }

        private void KeyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (keyTextBox.PasswordChar == '\0')
            {
                keyTextBox.PasswordChar = '*';
            }

            UpdateButtonStates();
            ValidateKey();
        }

        private void ShowKeyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            keyTextBox.PasswordChar = showKeyCheckBox.Checked ? '\0' : '*';
        }

        private void ValidateKey()
        {
            if (keyTextBox.TextLength == 8)
            {
                keyStatusLabel.Text = "✓ Ключ корректный (8 байт)";
                keyStatusLabel.ForeColor = Color.FromArgb(40, 167, 69);
            }
            else if (keyTextBox.TextLength > 8)
            {
                keyStatusLabel.Text = "✗ Ключ слишком длинный (макс. 8 байт)";
                keyStatusLabel.ForeColor = Color.FromArgb(220, 53, 69);
            }
            else
            {
                keyStatusLabel.Text = $"Ключ: {keyTextBox.TextLength}/8 байт";
                keyStatusLabel.ForeColor = Color.FromArgb(255, 193, 7);
            }
        }

        private void UpdateButtonStates()
        {
            bool hasInputFile = !string.IsNullOrEmpty(inputFilePathTextBox.Text);
            bool hasOutputFile = !string.IsNullOrEmpty(outputFilePathTextBox.Text);
            bool hasValidKey = keyTextBox.TextLength == 8;
            bool operationInProgress = IsOperationInProgress();

            encryptButton.Enabled = hasInputFile && hasOutputFile && hasValidKey && !operationInProgress;
            decryptButton.Enabled = hasInputFile && hasOutputFile && hasValidKey && !operationInProgress;

            selectInputFileButton.Enabled = !operationInProgress;
            selectOutputFileButton.Enabled = !operationInProgress;
            selectKeyFileButton.Enabled = !operationInProgress;
            keyTextBox.Enabled = !operationInProgress;
            showKeyCheckBox.Enabled = !operationInProgress;
        }

        private bool IsOperationInProgress()
        {
            return backgroundWorker?.IsBusy == true;
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            StartOperation(true);
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            StartOperation(false);
        }

        private void StartOperation(bool isEncryption)
        {
            if (string.IsNullOrWhiteSpace(inputFilePathTextBox.Text) || !File.Exists(inputFilePathTextBox.Text))
            {
                ShowError("Ошибка: исходный файл не выбран или не существует");
                return;
            }

            if (string.IsNullOrWhiteSpace(outputFilePathTextBox.Text))
            {
                ShowError("Ошибка: файл назначения не выбран");
                return;
            }

            if (keyTextBox.TextLength != 8)
            {
                ShowError("Ошибка: ключ должен быть длиной ровно 8 байт");
                return;
            }

            try
            {
                this.UseWaitCursor = true;
                UpdateControlStatesForOperation();

                // Сбрасываем прогресс-бар
                progressBar.Visible = true;
                progressBar.Value = 0;

                statusLabel.Text = isEncryption ? "Шифрование..." : "Расшифрование...";
                statusLabel.ForeColor = Color.FromArgb(255, 193, 7);

                var operationData = new OperationData
                {
                    InputFile = inputFilePathTextBox.Text,
                    OutputFile = outputFilePathTextBox.Text,
                    Key = Encoding.UTF8.GetBytes(keyTextBox.Text),
                    IsEncryption = isEncryption,
                    IV = Encoding.UTF8.GetBytes("12345678")
                };

                backgroundWorker?.RunWorkerAsync(operationData);
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка: {ex.Message}");
            }
        }

        private void UpdateControlStatesForOperation()
        {
            encryptButton.Enabled = false;
            decryptButton.Enabled = false;
            selectInputFileButton.Enabled = false;
            selectOutputFileButton.Enabled = false;
            selectKeyFileButton.Enabled = false;
            keyTextBox.Enabled = false;
            showKeyCheckBox.Enabled = false;
        }

        private void BackgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            if (e.Argument is not OperationData data)
                throw new ArgumentException("Неверные данные для операции");

            try
            {
                if (data.IsEncryption)
                {
                    desCfb.EncryptFile(data.InputFile, data.OutputFile, data.Key, data.IV,
                        progress =>
                        {
                            (sender as BackgroundWorker)?.ReportProgress(progress);
                        });
                }
                else
                {
                    desCfb.DecryptFile(data.InputFile, data.OutputFile, data.Key, data.IV,
                        progress =>
                        {
                            (sender as BackgroundWorker)?.ReportProgress(progress);
                        });
                }

                e.Result = data.IsEncryption ? "Шифрование завершено успешно" : "Расшифрование завершено успешно";
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        private void BackgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            statusLabel.Text = $"{statusLabel.Text.Split(':')[0]}: {e.ProgressPercentage}%";
        }

        private void BackgroundWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            this.UseWaitCursor = false;

            UpdateButtonStates();

            if (e.Error != null)
            {
                ShowError($"Ошибка: {e.Error.Message}");
            }
            else if (e.Result is Exception ex)
            {
                ShowError($"Ошибка: {ex.Message}");
            }
            else
            {
                progressBar.Value = 100;
                statusLabel.Text = e.Result as string;
                statusLabel.ForeColor = Color.FromArgb(40, 167, 69);

                var timer = new System.Windows.Forms.Timer();
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
            this.UseWaitCursor = false;

            statusLabel.Text = message;
            statusLabel.ForeColor = Color.FromArgb(220, 53, 69);
            progressBar.Visible = false;

            UpdateButtonStates();
        }

        private class OperationData
        {
            public string InputFile { get; set; } = string.Empty;
            public string OutputFile { get; set; } = string.Empty;
            public byte[] Key { get; set; } = Array.Empty<byte>();
            public byte[] IV { get; set; } = Array.Empty<byte>();
            public bool IsEncryption { get; set; }
        }
    }
}