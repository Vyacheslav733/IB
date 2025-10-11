using System.Windows.Forms;

namespace lab1.UI
{
    partial class FrmAbout
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblGroup;
        private Label lblName;
        private Label lblVariant;
        private Label lblRestrictions;
        private Label lblEncryption;
        private Label lblSalt;
        private Label lblHash;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            lblGroup = new Label();
            lblName = new Label();
            lblVariant = new Label();
            lblRestrictions = new Label();
            lblEncryption = new Label();
            lblSalt = new Label();
            lblHash = new Label();
            SuspendLayout();

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblTitle.Location = new System.Drawing.Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(320, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Лабораторная работа по криптографии";

            // lblGroup
            lblGroup.AutoSize = true;
            lblGroup.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblGroup.Location = new System.Drawing.Point(20, 45);
            lblGroup.Name = "lblGroup";
            lblGroup.Size = new System.Drawing.Size(150, 19);
            lblGroup.TabIndex = 1;
            lblGroup.Text = "Группа: ПИбд-43";

            // lblName
            lblName.AutoSize = true;
            lblName.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblName.Location = new System.Drawing.Point(20, 70);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(290, 19);
            lblName.TabIndex = 2;
            lblName.Text = "ФИО: Иванов Вячеслав Николаевич";

            // lblVariant
            lblVariant.AutoSize = true;
            lblVariant.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblVariant.Location = new System.Drawing.Point(20, 95);
            lblVariant.Name = "lblVariant";
            lblVariant.Size = new System.Drawing.Size(120, 19);
            lblVariant.TabIndex = 3;
            lblVariant.Text = "Вариант: 10";

            // lblRestrictions
            lblRestrictions.AutoSize = true;
            lblRestrictions.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblRestrictions.Location = new System.Drawing.Point(20, 120);
            lblRestrictions.Name = "lblRestrictions";
            lblRestrictions.Size = new System.Drawing.Size(320, 19);
            lblRestrictions.TabIndex = 4;
            lblRestrictions.Text = "Ограничения: отсутствие подряд расположенных";
            // Вторая строка ограничений
            Label lblRestrictions2 = new Label();
            lblRestrictions2.AutoSize = true;
            lblRestrictions2.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblRestrictions2.Location = new System.Drawing.Point(40, 140);
            lblRestrictions2.Name = "lblRestrictions2";
            lblRestrictions2.Size = new System.Drawing.Size(220, 19);
            lblRestrictions2.TabIndex = 5;
            lblRestrictions2.Text = "одинаковых символов";

            // lblEncryption
            lblEncryption.AutoSize = true;
            lblEncryption.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblEncryption.Location = new System.Drawing.Point(20, 170);
            lblEncryption.Name = "lblEncryption";
            lblEncryption.Size = new System.Drawing.Size(300, 19);
            lblEncryption.TabIndex = 6;
            lblEncryption.Text = "Режим шифрования DES: CBC";

            // lblSalt
            lblSalt.AutoSize = true;
            lblSalt.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblSalt.Location = new System.Drawing.Point(20, 195);
            lblSalt.Name = "lblSalt";
            lblSalt.Size = new System.Drawing.Size(250, 19);
            lblSalt.TabIndex = 7;
            lblSalt.Text = "Добавление случайного значения: Нет";

            // lblHash
            lblHash.AutoSize = true;
            lblHash.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblHash.Location = new System.Drawing.Point(20, 220);
            lblHash.Name = "lblHash";
            lblHash.Size = new System.Drawing.Size(270, 19);
            lblHash.TabIndex = 8;
            lblHash.Text = "Алгоритм хеширования пароля: MD4";

            // FrmAbout
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(400, 270);
            Controls.Add(lblTitle);
            Controls.Add(lblGroup);
            Controls.Add(lblName);
            Controls.Add(lblVariant);
            Controls.Add(lblRestrictions);
            Controls.Add(lblRestrictions2);
            Controls.Add(lblEncryption);
            Controls.Add(lblSalt);
            Controls.Add(lblHash);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAbout";
            StartPosition = FormStartPosition.CenterParent;
            Text = "О программе";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}