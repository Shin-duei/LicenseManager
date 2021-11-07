using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LicenseManager
{
    /// <summary>
    /// UI介面
    /// </summary>
    public partial class Frame : Form
    {
        public Frame()
        {
            InitializeComponent();
            SetDefaultKey();
        }
        /// <summary>
        /// 檔案拖拉進物件時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;//调用DragDrop事件 
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// 檔案放下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void DragDrop(object sender, DragEventArgs e)
        {
            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);

            //解密私鑰路徑
            string privateKey = $"{ this.textBoxDecryptKeyPath.Text}";


            var DecryptTxet = RSAKit.Decrypt(File.ReadAllText(filePaths[0]), privateKey);

            this.textBoxDecryptContent.Text = DecryptTxet;
        }

        /// <summary>
        /// 輸出加密文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExportEncryptFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "*.lic|";
            dialog.Title = "Save Encrypted File";

            //預設檔案名稱和副檔名
            dialog.FileName = "License";
            dialog.DefaultExt = "lic";

            //加密公鑰路徑
            string publicKey = $"{ this.textBoxEncryptKeyPath.Text}";

            var EncryptTxet=RSAKit.Encrypt(this.textBoxDecryptContent.Text, publicKey);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(dialog.FileName))
                {
                    sw.WriteLineAsync(EncryptTxet);
                }

                //複製私鑰放到和License一起
                var CopyPrivateKey = Path.Combine(Path.GetDirectoryName(dialog.FileName), RSAKit.privateKeyFileName);
                File.Copy(this.textBoxDecryptKeyPath.Text, CopyPrivateKey, true);
            }     
            MessageBox.Show("儲存完畢","提示");
        }
        /// <summary>
        /// 解密私鑰
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDecryptKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Private key (Decrypt) file select";
            dialog.InitialDirectory = ".\\";
            dialog.Filter = "*.Private|";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.textBoxDecryptKeyPath.Text = dialog.FileName;
            }          
        }

        /// <summary>
        /// 加密公鑰
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEncryptKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Public key (Encrypt) file select";
            dialog.InitialDirectory = ".\\";
            dialog.Filter = "*.Pub|";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.textBoxEncryptKeyPath.Text = dialog.FileName;
            }
        }

        /// <summary>
        /// 預設公鑰及私鑰的位置
        /// </summary>
        private void SetDefaultKey()
        {
            this.textBoxEncryptKeyPath.Text = "RSA.Pub";
            this.textBoxDecryptKeyPath.Text = "RSA.Private";

            if (!File.Exists("RSA.Pub") || !File.Exists("RSA.Private"))
                RSAKit.GenerateKeys();
        }
    }
}
