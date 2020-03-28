using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Transmission.API.RPC.Entity;

namespace MyQbt
{
    public class AddPrefixWithFileName
    {
        /// <summary>
        /// 间隔符是 空格 还是 点
        /// </summary>
        /// <param name="torrentCaption"></param>
        /// <returns></returns>
        private static string AddDotOrBlank(string torrentCaption)
        {
            // 连续的算一个
            int countOfBlank = 0;
            int countOfDot = 0;
            bool blankFlag = false, dotFlag = false;

            torrentCaption.Trim(new char[] { ' ', '.' });
            foreach (char ch in torrentCaption)
            {
                if (ch == ' ')
                {
                    blankFlag = true;
                    if (dotFlag)
                    {
                        countOfDot++;
                        dotFlag = false;
                    }
                }
                else if (ch == '.')
                {
                    dotFlag = true;
                    if (blankFlag)
                    {
                        countOfBlank++;
                        blankFlag = false;
                    }
                }
                else
                {
                    if (dotFlag) countOfDot++;
                    if (blankFlag) countOfBlank++;

                    dotFlag = false;
                    blankFlag = false;
                }
            }

            return (countOfDot > countOfBlank ? "." : " ");
        }

        public static async Task AddTorrent(
            string torrentPath, BencodeNET.Torrents.Torrent bencodeTorrent,
            string saveFolder, bool skipHashCheck,
            bool startTorrent, string category, Config.BTClient btClient,
            bool isWindowsPath,
            Dictionary<string, string> actualToVirtualDic = null,
            Transmission.API.RPC.Client transmissionClient = null)
        {
            if (bencodeTorrent != null)
            {
                string strTitle =
                    bencodeTorrent.FileMode == BencodeNET.Torrents.TorrentFileMode.Single ?
                    Path.GetFileNameWithoutExtension(bencodeTorrent.DisplayName) :
                    bencodeTorrent.DisplayName;

                strTitle = Path.GetFileNameWithoutExtension(torrentPath) +
                    AddDotOrBlank(strTitle) +
                    strTitle;

                string strSaveFolderPath = saveFolder + (isWindowsPath ? "\\" : "/") + strTitle;

                if (Helper.CheckPath(ref strSaveFolderPath, isWindowsPath))
                {
                    if (skipHashCheck)
                    {
                        if (!Helper.CanSkipCheck(
                            bencodeTorrent,
                            Helper.GetVirtualPath(strSaveFolderPath, actualToVirtualDic), false))
                        {
                            throw new Exception("跳过哈希检测失败");
                        }
                    }

                    if (btClient == Config.BTClient.qBittorrent)
                    {
                        await QbtWebAPI.API.DownloadFromDisk(
                            new List<string>() { torrentPath }, strSaveFolderPath,
                            null, string.IsNullOrWhiteSpace(category) ? null : category,
                            skipHashCheck, !startTorrent, false, strTitle, null, null, null, null);
                    }
                    else if (btClient == Config.BTClient.Transmission)
                    {
                        Debug.Assert(transmissionClient != null);
                        var addedTorrent = new NewTorrent
                        {
                            Metainfo = Helper.GetTransmissionTorrentAddMetainfo(torrentPath),
                            DownloadDirectory = (
                                bencodeTorrent.FileMode == BencodeNET.Torrents.TorrentFileMode.Single ?
                                strSaveFolderPath :
                                Helper.GetDirectoryNameDonntChangeDelimiter(strSaveFolderPath)),
                            Paused = (
                                bencodeTorrent.FileMode == BencodeNET.Torrents.TorrentFileMode.Single ?
                                (!startTorrent) : true)
                        };
                        var addedTorrentInfo = transmissionClient.TorrentAdd(addedTorrent);
                        Debug.Assert(addedTorrentInfo != null && addedTorrentInfo.ID != 0);

                        if (bencodeTorrent.FileMode == BencodeNET.Torrents.TorrentFileMode.Multi)
                        {
                            var result = transmissionClient.TorrentRenamePath(
                                addedTorrentInfo.ID,
                                bencodeTorrent.DisplayName,
                                Path.GetFileName(strSaveFolderPath));
                            Debug.Assert(result != null && result.ID != 0);

                            if (startTorrent)
                            {
                                transmissionClient.TorrentStartNow(new object[] { result.ID });
                            }
                        }
                    }
                }
                else throw new Exception("保存路径包含无效字符");
            }
        }
    }
}
