using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SQLAgain
{
    internal class Utils
    {
        public static string FindExePath(string exe)
        {
            foreach (string test in (Environment.GetEnvironmentVariable("PATH") ?? "").Split(';'))
            {
                string path = test.Trim();
                if (!String.IsNullOrEmpty(path) && File.Exists(path = Path.Combine(path, exe)))
                    return Path.GetFullPath(path);
            }
            return null;
        }
        public static bool CheckPLSQLBlock(string SQLFile)
        {
            string text = ReadFileString(SQLFile);
            string findString;
            int blockStart = 0;
            int blockEnd = 0;
            Console.WriteLine("processing file: " + SQLFile);
            RegexOptions options = RegexOptions.Multiline | RegexOptions.IgnoreCase;
            try
            {
                findString = @"^\s*CREATE .* (FUNCTION|PACKAGE|PROCEDURE|TRIGGER)";
                foreach (Match m in Regex.Matches(text, findString, options))
                { blockStart++; }
                if (blockStart > 0)
                {
                    findString = "^/\r?$";      // https://stackoverflow.com/questions/6596060/how-to-match-begin-or-end-of-a-line-using-cs-regex
                    foreach (Match m in Regex.Matches(text, findString, RegexOptions.Multiline))
                    { blockEnd++; }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            if (blockStart <= blockEnd) { return true; }
            else { return false; }
        }
        public static string ReadFileString(string path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path, Encoding.Default, true))
                    return reader.ReadToEnd();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return "";
            }
        }
        private static readonly string publicKey = "SQLAgain";
        private static readonly string secretKey = "d0it1+*in!";
        public static string Encrypt(string textToEncrypt, bool functionAvailable)
        {
            try
            {
                if (!functionAvailable) return textToEncrypt;
                string ToReturn = "";
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publicKey);
                byte[] secretkeyByte = { };
                secretkeyByte = System.Text.Encoding.UTF8.GetBytes(secretKey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    ToReturn = Convert.ToBase64String(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public static string Decrypt(string textToDecrypt, bool functionAvailable)
        {
            try
            {
                if (string.IsNullOrEmpty(textToDecrypt)) return null;
                if (!functionAvailable) return textToDecrypt;
                string ToReturn = "";
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publicKey);
                byte[] privatekeyByte = { };
                privatekeyByte = System.Text.Encoding.UTF8.GetBytes(secretKey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];
                inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;
                    ToReturn = encoding.GetString(ms.ToArray());
                }
                return ToReturn;
            }
            catch (FormatException)
            {
                return textToDecrypt;   // string was not encrypted - no decryption required
            }
            catch (Exception ae)
            {
                throw new Exception(ae.Message, ae.InnerException);
            }
        }
    }

}
