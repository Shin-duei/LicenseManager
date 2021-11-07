using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LicenseManager
{
    /// <summary>
    /// 加密解密套件
    /// </summary>
    public class RSAKit
    {
        private const int RsaKeySize = 2048;
        public const string publicKeyFileName = "RSA.Pub";
        public const string privateKeyFileName = "RSA.Private";
        public const string LicenseFileName = "License.lic";

        /// <summary>
        ///在給定路徑中生成XML格式的私鑰和公鑰。
        /// </summary>
        public static void GenerateKeys(string path="")
        {
            using (var rsa = new RSACryptoServiceProvider(RsaKeySize))
            {
                try
                {
                    // 獲取私鑰和公鑰。
                    var publicKey = rsa.ToXmlString(false);
                    var privateKey = rsa.ToXmlString(true);

                    // 保存到磁盤
                    File.WriteAllText(Path.Combine(path, publicKeyFileName), publicKey);
                    File.WriteAllText(Path.Combine(path, privateKeyFileName), privateKey);

                    //Console.WriteLine(string.Format("生成的RSA密鑰的路徑: {0}\\ [{1}, {2}]", path, publicKeyFileName, privateKeyFileName));
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }


        /// <summary>
        /// 給訂授權資料夾路徑來加密
        /// </summary>
        /// <param name="licenseDirectory"></param>
        /// <returns></returns>
        public static string Encrypt(string licenseDirectory)
        {
            if (File.Exists(Path.Combine(licenseDirectory, LicenseFileName)))
            {
                var Text = File.ReadAllText(Path.Combine(licenseDirectory, LicenseFileName));

                var pathToPublicKey = Path.Combine(licenseDirectory, publicKeyFileName);

                //string test = "you are welcome!!";

                return Encrypt(Text, pathToPublicKey);
            }
            else
                return null;
        }

        /// <summary>
        /// 用給定路徑的RSA公鑰文件加密純文本。
        /// </summary>
        /// <param name="plainText">要加密的文本</param>
        /// <param name="pathToPublicKey">用於加密的公鑰路徑.</param>
        /// <returns>表示加密數據的64位編碼字符串.</returns>
        public static string Encrypt(string plainText, string pathToPublicKey)
        {
            if (string.IsNullOrEmpty(plainText))
            {
                return string.Empty;
            }

            if (string.IsNullOrWhiteSpace(pathToPublicKey))
            {
                throw new ArgumentException("Invalid Public Key");
            }

            using (var rsaProvider = new RSACryptoServiceProvider())
            {
                var inputBytes = Encoding.UTF8.GetBytes(plainText);//有含义的字符串转化为字节流

                var publicXmlKey = File.ReadAllText(pathToPublicKey);
                rsaProvider.FromXmlString(publicXmlKey);//载入公钥
                int bufferSize = (rsaProvider.KeySize / 8) - 11;//单块最大长度
                var buffer = new byte[bufferSize];
                using (MemoryStream inputStream = new MemoryStream(inputBytes),
                     outputStream = new MemoryStream())
                {
                    while (true)
                    { //分段加密
                        int readSize = inputStream.Read(buffer, 0, bufferSize);
                        if (readSize <= 0)
                        {
                            break;
                        }

                        var temp = new byte[readSize];
                        Array.Copy(buffer, 0, temp, 0, readSize);
                        var encryptedBytes = rsaProvider.Encrypt(temp, false);
                        outputStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                    }
                    return Convert.ToBase64String(outputStream.ToArray());//转化为字节流方便传输
                }
            }
        }
        /// <summary>
        /// 給訂授權資料夾路徑來解密
        /// </summary>
        /// <param name="licenseDirectory"></param>
        /// <returns></returns>
        public static string Decrypt(string licenseDirectory)
        {
            if (File.Exists(Path.Combine(licenseDirectory, LicenseFileName)))
            {
                var encryptedText = File.ReadAllText(Path.Combine(licenseDirectory, LicenseFileName));

                var pathToPrivateKey = Path.Combine(licenseDirectory, privateKeyFileName);

                return Decrypt(encryptedText, pathToPrivateKey);
            }
            else
                return null;

        }


        /// <summary>
        /// Decrypts encrypted text given a RSA private key file path.給定路徑的RSA私鑰文件解密 加密文本
        /// </summary>
        /// <param name="encryptedText">加密的密文</param>
        /// <param name="pathToPrivateKey">用於加密的私鑰路徑.</param>
        /// <returns>未加密數據的字符串</returns>
        public static string Decrypt(string encryptedText, string pathToPrivateKey)
        {
            if (string.IsNullOrEmpty(encryptedText))
            {
                return string.Empty;
            }

            if (string.IsNullOrWhiteSpace(pathToPrivateKey))
            {
                throw new ArgumentException("Invalid Private Key");
            }

            using (var rsaProvider = new RSACryptoServiceProvider())
            {
                try
                {
                    var inputBytes = Convert.FromBase64String(encryptedText);

                    var privateKey = File.ReadAllText(pathToPrivateKey);
                    rsaProvider.FromXmlString(privateKey);
                    int bufferSize = rsaProvider.KeySize / 8;
                    var buffer = new byte[bufferSize];
                    using (MemoryStream inputStream = new MemoryStream(inputBytes),
                         outputStream = new MemoryStream())
                    {
                        while (true)
                        {
                            int readSize = inputStream.Read(buffer, 0, bufferSize);
                            if (readSize <= 0)
                            {
                                break;
                            }

                            var temp = new byte[readSize];
                            Array.Copy(buffer, 0, temp, 0, readSize);
                            var rawBytes = rsaProvider.Decrypt(temp, false);
                            outputStream.Write(rawBytes, 0, rawBytes.Length);
                        }
                        return Encoding.UTF8.GetString(outputStream.ToArray());
                    }
                }
                catch(Exception ex)
                {
                    var d=ex.ToString();
                    return encryptedText;//無法解密就直接傳回原本文檔
                }
               
            }
        }
    }
}
