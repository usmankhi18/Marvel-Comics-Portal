using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Cryptography
{
    public class TripleDes
    {
        public static string Encrypt(string PlainText)
        {
            try
            {
                string key = CommonObjects.GetCongifValue(ConfigKeys.TripleDesKey);
                byte[] iv1 = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                byte[] PlainTextArray = UTF8Encoding.UTF8.GetBytes(PlainText);
                byte[] keyArray = MD5.CreateMd5ByteArray(key);
                TripleDESCryptoServiceProvider TripleDes = new TripleDESCryptoServiceProvider();
                TripleDes.Key = keyArray;
                TripleDes.Mode = CipherMode.ECB;
                TripleDes.Padding = PaddingMode.PKCS7;
                TripleDes.IV = iv1;
                ICryptoTransform cTransform = TripleDes.CreateEncryptor();
                byte[] CipherString = cTransform.TransformFinalBlock(PlainTextArray, 0, PlainTextArray.Length);
                TripleDes.Clear();
                return Convert.ToBase64String(CipherString, 0, CipherString.Length);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string Decrypt(string CipherString)
        {
            try
            {
                string key = CommonObjects.GetCongifValue(ConfigKeys.TripleDesKey);
                byte[] iv1 = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                byte[] CipherStringArray = Convert.FromBase64String(CipherString);
                byte[] keyArray = MD5.CreateMd5ByteArray(key);

                TripleDESCryptoServiceProvider TripleDes = new TripleDESCryptoServiceProvider();
                TripleDes.Key = keyArray;
                TripleDes.Mode = CipherMode.ECB;
                TripleDes.Padding = PaddingMode.PKCS7;
                TripleDes.IV = iv1;
                ICryptoTransform cTransform = TripleDes.CreateDecryptor();
                byte[] PlainTextArray = cTransform.TransformFinalBlock(CipherStringArray, 0, CipherStringArray.Length);
                TripleDes.Clear();
                return UTF8Encoding.UTF8.GetString(PlainTextArray);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static byte[] Encrypt(byte[] bytesToEncrypt)
        {
            string key = CommonObjects.GetCongifValue(ConfigKeys.TripleDesKey);
            byte[] iv1 = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Mode = CipherMode.ECB;
            tdes.Key = Encoding.ASCII.GetBytes(key);
            tdes.IV = iv1;
            tdes.Padding = PaddingMode.Zeros;
            byte[] bufferFinalBlock = tdes.CreateEncryptor().TransformFinalBlock(bytesToEncrypt, 0, bytesToEncrypt.Length);
            return bufferFinalBlock;
        }

        public static byte[] Decrypt(byte[] bytesToDecrypt)
        {
            string key = CommonObjects.GetCongifValue(ConfigKeys.TripleDesKey);
            byte[] iv1 = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            TripleDESCryptoServiceProvider TripleDes = new TripleDESCryptoServiceProvider();
            TripleDes.Mode = CipherMode.ECB;
            TripleDes.Key = Encoding.ASCII.GetBytes(key);
            TripleDes.IV = iv1;
            TripleDes.Padding = PaddingMode.Zeros;
            ICryptoTransform cTransform = TripleDes.CreateDecryptor();
            byte[] bufferFinalBlock = cTransform.TransformFinalBlock(bytesToDecrypt, 0, bytesToDecrypt.Length);
            return bufferFinalBlock;
        }
    }
}
