using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace MyQbt
{
    public class Helper
    {
        private readonly static long KB = 1024;
        private readonly static long MB = KB * 1024;
        private readonly static long GB = MB * 1024;
        private readonly static long TB = GB * 1024;
        private readonly static long PB = TB * 1024;

        private readonly static string RSAKeyContainerName =
            "qBittorrentOperator_RSA_KCN_{9D8562C6-8970-4B76-886E-FFFBC8FEDA23}";

        public static readonly char[] limitedChars =
            "\\/:*?\"<>|".ToCharArray();
        public static readonly char[] limitedChars1 =
            (new string(limitedChars)).Replace("\\", "").Replace("/", "").ToCharArray();

        public static readonly char[] replaceChars =
            "＼／：＊？“＜＞｜".ToCharArray();
        public static readonly char[] replaceChars1 =
            (new string(replaceChars)).Replace("＼", "").Replace("／", "").ToCharArray();

        public static readonly char[] invalidChars = Path.GetInvalidFileNameChars();
        public static readonly char[] invalidChars1 =
            (new string(invalidChars)).Replace("\\", "").Replace("/", "").ToCharArray();

        public static bool IsPathValid(string path)
        {
            path = string.Join("\\", path.Split(
                new char[] { '/', '\\' },
                StringSplitOptions.RemoveEmptyEntries));
            return ((path[0] >= 'a' && path[0] <= 'z') || (path[0] >= 'A' && path[0] <= 'Z')) &&
                (path[1] == ':') && (path[2] == '\\') &&
                (path.Substring(3).IndexOfAny(invalidChars1) == -1);
        }

        public static bool IsNameValid(string name)
        {
            return (name.IndexOfAny(invalidChars) == -1);
        }

        public static void ReplacePath(ref string path)
        {
            path = string.Join("\\", path.Split(
                new char[] { '/', '\\' },
                StringSplitOptions.RemoveEmptyEntries));
            string strTemp = path.Substring(0, 3);
            path = path.Substring(3);

            for (int i = 0; i < invalidChars1.Length; i++)
            {
                char replaceChar = '_';
                int index = Array.IndexOf<char>(limitedChars1, invalidChars1[i]);
                if (index != -1)
                {
                    replaceChar = replaceChars1[index];
                }
                path = path.Replace(invalidChars1[i], replaceChar);
            }
            path = strTemp + path;
        }

        public static void ReplaceName(ref string name)
        {
            for (int i = 0; i < invalidChars.Length; i++)
            {
                char replaceChar = '_';
                int index = Array.IndexOf<char>(limitedChars, invalidChars[i]);
                if (index != -1)
                {
                    replaceChar = replaceChars[index];
                }
                name = name.Replace(invalidChars[i], replaceChar);
            }
        }

        public static bool CheckPath(ref string path)
        {
            if (IsPathValid(path)) return true;

            DialogResult dg = MessageBox.Show(
                string.Format("\n{0}\n包含无效字符，要替换吗？\n{1}",
                path, string.Format("字符 {0} 替换成对应的 {1}，其余的替换成 _",
                new string(limitedChars), new string(replaceChars))), "提示",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;
            if (dg == DialogResult.Yes)
            {
                ReplacePath(ref path);
                return true;
            }
            else return false;
        }

        public static bool CheckName(ref string name)
        {
            if (IsNameValid(name)) return true;

            DialogResult dg = MessageBox.Show(
                string.Format("\n{0}\n包含无效字符，要替换吗？\n{1}",
                name, string.Format("字符 {0} 替换成对应的 {1}，其余的替换成 _",
                new string(limitedChars), new string(replaceChars))), "提示",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;
            if (dg == DialogResult.Yes)
            {
                ReplaceName(ref name);
                return true;
            }
            else return false;
        }

        /// <summary>
        /// 返回文件占用空间大小
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Int64 CalcSpace(Int64 size)
        {
            return ((Int64)Math.Ceiling(size / 4096.0)) * 4096;
        }

        /// <summary>
        /// 返回用KB、MB、GB、TB表示的大小的字符串，保留两为小数
        /// </summary>
        /// <param name="lSize">字节数</param>
        /// <returns></returns>
        public static String GetSizeString(long lSize)
        {
            if (lSize == 0) return "0 KB";
            else if (lSize < KB) return "1 KB";

            double dSize = (double)lSize;

            if (lSize < MB) return String.Format("{0:F} KB", dSize / KB);
            else if (lSize < GB) return String.Format("{0:F} MB", dSize / MB);
            else if (lSize < TB) return String.Format("{0:F} GB", dSize / GB);
            else if (lSize < PB) return String.Format("{0:F} TB", dSize / TB);
            else return "N/A";
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="expressText"></param>
        /// <returns></returns>
        public static string Encryption(string expressText)
        {
            CspParameters param = new CspParameters();
            // 密匙容器的名称，保持加密解密一致才能解密成功
            param.KeyContainerName = RSAKeyContainerName;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
            {
                // 将要加密的字符串转换为字节数组
                byte[] plainData = Encoding.Default.GetBytes(expressText);
                // 加密
                byte[] encryptdata = rsa.Encrypt(plainData, false);
                // 将加密后的字节数组转换为Base64字符串
                return Convert.ToBase64String(encryptdata);
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public static string Decrypt(string cipherText)
        {
            CspParameters param = new CspParameters();
            param.KeyContainerName = RSAKeyContainerName;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
            {
                byte[] encryptData = Convert.FromBase64String(cipherText);
                byte[] decryptData = rsa.Decrypt(encryptData, false);
                return Encoding.Default.GetString(decryptData);
            }
        }

        public static string GetVirtualPath(string actualPath,
            Dictionary<string, string> actualToVirtualDic)
        {
            if (actualToVirtualDic == null) return actualPath;

            string strTemp = actualPath.ToUpper();

            foreach (KeyValuePair<string, string> kv in actualToVirtualDic)
            {
                int index = strTemp.IndexOf(kv.Key);
                if (index == 0)
                {
                    return kv.Value + strTemp.Substring(kv.Key.Length);
                }
            }

            return actualPath;
        }

        public static bool CanSkipCheck(
            BencodeNET.Torrents.Torrent torrent,
            string virtualSaveFolder, bool hasRootFolder)
        {
            if (torrent.FileMode == BencodeNET.Torrents.TorrentFileMode.Unknown) return false;
            else if (torrent.FileMode == BencodeNET.Torrents.TorrentFileMode.Single)
            {
                string filePath = Path.Combine(virtualSaveFolder, torrent.File.FileName);
                if (File.Exists(filePath))
                {
                    FileInfo fi = new FileInfo(filePath);
                    if (fi.Length != torrent.File.FileSize) return false;
                }
                else return false;
            }
            else
            {
                if (hasRootFolder)
                    virtualSaveFolder = Path.Combine(virtualSaveFolder, torrent.DisplayName);

                foreach (var v in torrent.Files)
                {
                    string filePath = Path.Combine(virtualSaveFolder, v.FullPath);
                    if (File.Exists(filePath))
                    {
                        FileInfo fi = new FileInfo(filePath);
                        if (fi.Length != v.FileSize) return false;
                    }
                    else return false;
                }
            }
            return true;
        }
    }
}
