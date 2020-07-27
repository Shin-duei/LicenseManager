
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace LicenseManager
{
    partial class Frame
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxDecryptContent = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxDecryptKeyPath = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.textBoxEncryptKeyPath = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBoxDecryptContent.AllowDrop = true;
            this.textBoxDecryptContent.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.textBoxDecryptContent.Location = new System.Drawing.Point(6, 81);
            this.textBoxDecryptContent.Multiline = true;
            this.textBoxDecryptContent.Name = "textBox1";
            this.textBoxDecryptContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDecryptContent.Size = new System.Drawing.Size(756, 310);
            this.textBoxDecryptContent.TabIndex = 0;
            this.textBoxDecryptContent.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragDrop);
            this.textBoxDecryptContent.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnter);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(7, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(755, 45);
            this.button1.TabIndex = 1;
            this.button1.Text = "Export Encrypt File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonExportEncryptFile_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 426);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBoxDecryptContent);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 397);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Decrypt File";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Decrypted Context:";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(21, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 31);
            this.button2.TabIndex = 4;
            this.button2.Text = "DecryptKey";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonDecryptKey_Click);
            // 
            // textBox2
            // 
            this.textBoxDecryptKeyPath.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.textBoxDecryptKeyPath.Location = new System.Drawing.Point(183, 24);
            this.textBoxDecryptKeyPath.Name = "textBox2";
            this.textBoxDecryptKeyPath.Size = new System.Drawing.Size(446, 30);
            this.textBoxDecryptKeyPath.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.textBoxEncryptKeyPath);
            this.tabPage2.Controls.Add(this.textBoxDecryptKeyPath);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 397);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "RAS Setting";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(21, 70);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 31);
            this.button3.TabIndex = 4;
            this.button3.Text = "EncryptKey";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonEncryptKey_Click);
            // 
            // textBox3
            // 
            this.textBoxEncryptKeyPath.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.textBoxEncryptKeyPath.Location = new System.Drawing.Point(183, 71);
            this.textBoxEncryptKeyPath.Name = "textBox3";
            this.textBoxEncryptKeyPath.Size = new System.Drawing.Size(446, 30);
            this.textBoxEncryptKeyPath.TabIndex = 3;
            // 
            // Frame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frame";
            this.Text = "License Manager";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.Icon = LicenseManager.Properties.Resources.Logo_license_key;

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDecryptContent;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox textBoxDecryptKeyPath;
        private Label label1;
        private Button button3;
        private TextBox textBoxEncryptKeyPath;

    }
}

