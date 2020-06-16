using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    public static class MD5
    {
        public static string CreateMd5HashStringUpper(string PlainText)
        {
            string sbinary = string.Empty;
            try { byte[] PlainTextArray = CreateMd5ByteArray(PlainText); for (int i = 0; i < PlainTextArray.Length; i++) sbinary += PlainTextArray[i].ToString("X2"); }
            catch (Exception) { throw; }
            return sbinary;
        }

        public static string CreateMd5HashString(string PlainText)
        {
            string sbinary = string.Empty;
            try
            {
                byte[] PlainTextArray = CreateMd5ByteArray(PlainText);
                for (int i = 0; i < PlainTextArray.Length; i++)
                {
                    sbinary += PlainTextArray[i].ToString("X2");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return sbinary;
        }

        public static byte[] CreateMd5ByteArray(string PlainText)
        {
            byte[] PlainTextArray;
            try
            {
                using (MD5CryptoServiceProvider Md5Provider = new MD5CryptoServiceProvider())
                {
                    PlainTextArray = System.Text.Encoding.ASCII.GetBytes(PlainText);
                    PlainTextArray = Md5Provider.ComputeHash(PlainTextArray);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return PlainTextArray;
        }

        public static string CreateMd5Hash(string PlainText)
        {
            byte[] PlainTextArray;
            try
            {
                PlainTextArray = CreateMd5ByteArray(PlainText);

            }
            catch (Exception)
            {
                throw;
            }
            return System.Text.Encoding.ASCII.GetString(PlainTextArray);
        }
    }
}
