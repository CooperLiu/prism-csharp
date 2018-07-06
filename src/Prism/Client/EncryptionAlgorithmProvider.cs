using System.Security.Cryptography;
using System.Text;

namespace Prism.Client
{
    class EncryptionAlgorithmProvider
    {
        public static string Md5(string plainText, string charset = "UTF-8")
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.GetEncoding(charset).GetBytes(plainText));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("X2"));
            }
            return sBuilder.ToString();
        }
    }
}
