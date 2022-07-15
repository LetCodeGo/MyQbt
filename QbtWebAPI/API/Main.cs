using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using QbtWebAPI.JSON;
using System.IO;
using QbtWebAPI.Enums;
using Newtonsoft.Json.Linq;
using QbtWebAPI.Data;

namespace QbtWebAPI
{
    /// <summary>
    /// Communicator for qBittorrent WebUI API.
    /// </summary>
    public static partial class API
    {
        private static HttpClient client;

        /// <summary>
        /// Fires when qBittorrent becomes unreachable.
        /// </summary>
        public static event EventHandler Disconnected;

        private static string ApiVersion;

        /// <summary>
        /// Initializes the API.
        /// </summary>
        /// <param name="baseAddress">Host address.</param>
        /// <param name="timeout">Time before timeout.</param>
        public static void Initialize(string baseAddress, int timeout = 100)
        {
            if (client != null)
                client.Dispose();
            client = new HttpClient();
            baseAddress = baseAddress.Replace("\\", "/");
            if (baseAddress[baseAddress.Length - 1] != '/')
                baseAddress += "/";

            Uri.TryCreate(baseAddress, UriKind.Absolute, out Uri uri);

            if (uri == null)
                throw new UriFormatException("Format of base address is invalid!");

            client.BaseAddress = new Uri(baseAddress);
            client.Timeout = TimeSpan.FromSeconds(timeout);
        }

        /// <summary>
        /// Logs in to qBittorrent.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <returns>True if successful, false if wrong username/password, null if unreachable.</returns>
        public static async Task<bool?> Login(string username, string password)
        {
            var content = ToStringContent("username=" + username + "&password=" + password);
            var reply = await Post(client, "/api/v2/auth/login", content);

            if (reply == null)
                return null;

            var result = await reply.Content.ReadAsStringAsync();

            if (result == "Ok.")
            {
                ApiVersion = await GetApiVersion();

                //client.DefaultRequestHeaders.Authorization =
                //    new System.Net.Http.Headers.AuthenticationHeaderValue(
                //    "Basic", Convert.ToBase64String(
                //        Encoding.UTF8.GetBytes(username + ":" + password)));

                //var cookies = reply.Headers.GetValues("Set-Cookie");
                //if (cookies != null)
                //{
                //    string SID = null;
                //    bool breakFlag = false;
                //    foreach (string cookie in cookies)
                //    {
                //        string[] kvs = cookie.Split(new char[] { ';' },
                //            StringSplitOptions.RemoveEmptyEntries);
                //        foreach (string kv in kvs)
                //        {
                //            string[] vv = kv.Trim().Split(new char[] { '=' });
                //            if (vv.Length == 2 && vv[0] == "SID")
                //            { SID = vv[1]; breakFlag = true; break; }
                //        }
                //        if (breakFlag) break;
                //    }
                //    if (SID != null)
                //        client.DefaultRequestHeaders.Add("Cookie", string.Format("SID={0};", SID));
                //}

                return true;
            }
            else throw new Exception("Login Failed");
        }

        /// <summary>
        /// Logs out of qBittorrent.
        /// </summary>
        /// <returns></returns>
        public static async Task Logout()
        {
            await Post(client, "/api/v2/auth/logout");
        }

        /// <summary>
		/// Gets qBittorrent version.
		/// </summary>
		/// <returns>qBittorrent version.</returns>
		public static async Task<string> GetQbittorrentVersion()
        {
            var reply = await Post(client, "/api/v2/app/version");
            return await reply.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Gets API version.
        /// </summary>
        /// <returns>API version.</returns>
        public static async Task<string> GetApiVersion()
        {
            var reply = await Post(client, "/api/v2/app/webapiVersion");
            return await reply.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Gets Build Info (api >= 2.3.0 qBittorrent >= v4.2.0)
        /// </summary>
        /// <returns></returns>
        public static async Task<BuildInfo> GetBuildInfo()
        {
            var reply = await Post(client, "/api/v2/app/buildInfo");
            return new BuildInfo(
                JsonConvert.DeserializeObject<BuildInfoJSON>(
                    await reply.Content.ReadAsStringAsync()));
        }

        /// <summary>
        /// Shuts down qBittorrent.
        /// </summary>
        /// <returns></returns>
        public static async Task ShutdownQbittorrent()
        {
            await Post(client, "/api/v2/app/shutdown");
        }

        /// <summary>
		/// Gets qBittorrent preferences.
		/// </summary>
		/// <returns>qBittorrent preferences.</returns>
		public static async Task<Preferences> GetPreferences()
        {
            HttpResponseMessage reply = await Post(client, "/api/v2/app/preferences");

            if (reply == null)
                return null;

            var result = await reply.Content.ReadAsStringAsync();
            if (result == "")
                return null;

            return new Preferences(JsonConvert.DeserializeObject<PreferencesJSON>(await reply.Content.ReadAsStringAsync()));
        }

        /// <summary>
		/// Sets qBittorrent preferences.
		/// </summary>
		/// <param name="preferences">qBittorrent preferences.</param>
		public static async Task SetPreferences(Preferences preferences)
        {
            var jsonObject = JsonConvert.SerializeObject(new PreferencesJSON(preferences),
                                                        Formatting.None,
                                                        new JsonSerializerSettings
                                                        {
                                                            NullValueHandling = NullValueHandling.Ignore
                                                        });
            var content = ToStringContent("json=" + jsonObject);
            await Post(client, "/api/v2/app/setPreferences", content);
        }

        public static async Task<string> GetDefaultSavePath()
        {
            var reply = await Post(client, "/api/v2/app/defaultSavePath");
            return await reply.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Set Default Save Path
        /// </summary>
        /// <param name="defaultSavePath"></param>
        /// <returns></returns>
        public static async Task SetDefaultSavePath(string defaultSavePath)
        {
            defaultSavePath = string.Join(@"\\",
                defaultSavePath.Split(
                    new char[] { '/', '\\' },
                    StringSplitOptions.RemoveEmptyEntries)) + @"\\";
            string str = string.Format("json={{\"save_path\":\"{0}\"}}", defaultSavePath);
            var content = ToStringContent(str);
            var reply = await Post(client, "/api/v2/app/setPreferences", content);
        }

        /// <summary>
        /// Gets log entries of given states.
        /// </summary>
        /// <param name="normal">Include normal messages.</param>
        /// <param name="info">Include info messages.</param>
        /// <param name="warning">Include warning messages.</param>
        /// <param name="critical">Include critical messages.</param>
        /// <param name="last_known_id">Exclude log entries with id less or equal to this.</param>
        /// <returns>List of log entries.</returns>
        public static async Task<List<Log>> GetLog(bool normal = true, bool info = true, bool warning = true,
                                                bool critical = true, int last_known_id = -1)
        {
            HttpResponseMessage reply = await Post(client, "/api/v2/log/main?normal=" + normal.ToString()
                                                    + "&info=" + info.ToString() + "&warning=" + warning.ToString()
                                                    + "&critical=" + critical.ToString() + "&last_known_id=" + last_known_id);

            if (reply == null)
                return null;

            var result = await reply.Content.ReadAsStringAsync();
            if (result == "")
                return null;

            var logJSONs = JsonConvert.DeserializeObject<List<LogJSON>>(await reply.Content.ReadAsStringAsync());
            var logs = new List<Log>();

            foreach (var e in logJSONs)
                logs.Add(new Log(e));

            return logs;
        }

        /// <summary>
        /// Gets a list of torrents, filtering optional.
        /// </summary>
        /// <param name="filter">Filter by status.</param>
        /// <param name="category">Filter by category. Empty string is no category.</param>
        /// <param name="sort">Sort by given key.</param>
        /// <param name="reverse">True if reverse sorted.</param>
        /// <param name="limit">Maximum number of torrents returned.</param>
        /// <param name="offset">Set offset (if less than 0, offset from end).</param>
        /// <returns>List of torrents.</returns>
        public static async Task<List<Torrent>> GetTorrents(Status filter = Status.All,
                                                     string category = null,
                                                     Key sort = Key.Name,
                                                     bool reverse = false,
                                                     int? limit = null,
                                                     int? offset = null)
        {
            HttpResponseMessage reply;
            var parameters = "?";

            parameters += "filter=" + filter.ToString().ToLower() + "&";

            if (category != null)
                parameters += "category=" + category + "&";

            parameters += "sort=" + sort.ToString().ToLower() + "&";

            parameters += "reverse=" + reverse.ToString().ToLower() + "&";

            if (limit != null)
                parameters += "limit=" + limit + "&";

            if (offset != null)
                parameters += "offset=" + offset + "&";

            parameters = parameters.Remove(parameters.Length - 1);
            reply = await Post(client, "/api/v2/torrents/info" + parameters);

            if (reply == null)
                return null;

            var result = await reply.Content.ReadAsStringAsync();
            if (result == "")
                return null;

            var torrentsJSON = JsonConvert.DeserializeObject<List<TorrentJSON>>(await reply.Content.ReadAsStringAsync());
            var torrents = new List<Torrent>();

            foreach (TorrentJSON t in torrentsJSON)
                torrents.Add(new Torrent(t));

            return torrents;
        }

        /// <summary>
        /// Gets properties of a torrent.
        /// </summary>
        /// <param name="hash">Torrent hash.</param>
        /// <returns>Torrent properties.</returns>
        public static async Task<TorrentProperties> GetTorrentProperties(string hash)
        {
            HttpResponseMessage reply = await Post(client, "/api/v2/torrents/properties/" + hash);

            if (reply == null)
                return null;

            var result = await reply.Content.ReadAsStringAsync();
            if (result == "")
                return null;

            return new TorrentProperties(JsonConvert.DeserializeObject<TorrentPropertiesJSON>(await reply.Content.ReadAsStringAsync()));
        }



        /// <summary>
        /// Gets all trackers of a torrent.
        /// </summary>
        /// <param name="hash">Torrent hash.</param>
        /// <returns>List of trackers.</returns>
        public static async Task<List<Tracker>> GetTorrentTrackers(string hash)
        {
            HttpResponseMessage reply = await Post(client, "/api/v2/torrents/trackers/" + hash);

            if (reply == null)
                return null;

            var result = await reply.Content.ReadAsStringAsync();
            if (result == "")
                return null;

            var js = JsonConvert.DeserializeObject<List<TrackerJSON>>(await reply.Content.ReadAsStringAsync());
            var trackers = new List<Tracker>();
            foreach (var e in js)
            {
                trackers.Add(new Tracker(e));
            }

            return trackers;
        }

        /// <summary>
        /// Gets all the web seeds of a torrent.
        /// </summary>
        /// <param name="hash">Torrent hash.</param>
        /// <returns>List of web seeds.</returns>
        public static async Task<List<Uri>> GetTorrentWebSeeds(string hash)
        {
            HttpResponseMessage reply = await Post(client, "/api/v2/torrents/webseeds/" + hash);

            if (reply == null)
                return null;

            var result = await reply.Content.ReadAsStringAsync();
            if (result == "")
                return null;

            var torrentWebSeeds = JsonConvert.DeserializeObject<List<TorrentWebSeedJSON>>(await reply.Content.ReadAsStringAsync());
            var urls = new List<Uri>();
            foreach (TorrentWebSeedJSON torrentWebSeed in torrentWebSeeds)
                urls.Add(torrentWebSeed.Url);

            return urls;
        }

        /// <summary>
        /// Gets the contents of a torrent.
        /// </summary>
        /// <param name="hash">Torrent hash,</param>
        /// <returns>Torrent contents.</returns>
        public static async Task<List<TorrentContents>> GetTorrentContents(string hash)
        {
            HttpResponseMessage reply = await Post(client, "/api/v2/torrents/files/" + hash);

            if (reply == null)
                return null;

            var result = await reply.Content.ReadAsStringAsync();
            if (result == "")
                return null;

            var array = JsonConvert.DeserializeObject<TorrentContents[]>(await reply.Content.ReadAsStringAsync());
            return new List<TorrentContents>(array);
        }

        /// <summary>
        /// Gets states of torrent pieces.
        /// </summary>
        /// <param name="hash">Torrent hash.</param>
        /// <returns>States of torrent pieces.</returns>
        public static async Task<List<PieceState>> GetTorrentPiecesStates(string hash)
        {
            HttpResponseMessage reply = await Post(client, "/api/v2/torrents/pieceStates/" + hash);

            if (reply == null)
                return null;

            var result = await reply.Content.ReadAsStringAsync();
            if (result == "")
                return null;

            var array = JsonConvert.DeserializeObject<PieceState[]>(await reply.Content.ReadAsStringAsync());
            return new List<PieceState>(array);
        }

        /// <summary>
        /// Gets hashes of all pieces of a torrent.
        /// </summary>
        /// <param name="hash">Torrent hash.</param>
        /// <returns>Hashes of all pieces of a torrent.</returns>
        public static async Task<List<string>> GetTorrentPiecesHashes(string hash)
        {
            HttpResponseMessage reply = await Post(client, "/api/v2/torrents/pieceHashes/" + hash);
            if (reply == null)
                return null;

            var result = await reply.Content.ReadAsStringAsync();
            if (result == "")
                return null;

            var array = JsonConvert.DeserializeObject<string[]>(await reply.Content.ReadAsStringAsync());

            return new List<string>(array);
        }

        /// <summary>
        /// Gets info you usually see in qBittorrent status bar.
        /// </summary>
        /// <returns>Info you usually see in qBittorrent status bar.</returns>
        public static async Task<TransferInfo> GetTransferInfo()
        {
            HttpResponseMessage reply = await Post(client, "/api/v2/transfer/info");

            if (reply == null)
                return null;

            var result = await reply.Content.ReadAsStringAsync();
            if (result == "")
                return null;

            return JsonConvert.DeserializeObject<TransferInfo>(await reply.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Gets changes since last request.
        /// </summary>
        /// <param name="rid">Requst ID.</param>
        /// <returns>Changes since last request.</returns>
        public static async Task<PartialData> GetPartialData(int rid = 0)
        {
            HttpResponseMessage reply = await Post(client, "/api/v2/sync/maindata?rid=" + rid);

            if (reply == null)
                return null;

            var result = await reply.Content.ReadAsStringAsync();
            if (result == "")
                return null;

            return new PartialData(JsonConvert.DeserializeObject<PartialDataJSON>(await reply.Content.ReadAsStringAsync()));
        }

        /// <summary>
        /// Downloads from URL.
        /// </summary>
        /// <param name="urls">List of URLs.</param>
        /// <param name="savePath">Download folder.</param>
        /// <param name="cookie">Coookie sent to download the .torrent file..</param>
        /// <param name="category">Category for the torrent.</param>
        /// <param name="skipChecking">Skip hash check.</param>
        /// <param name="paused">Add torrents in the paused state.</param>
        /// <param name="rootFolder">Create the root folder.</param>
        /// <param name="rename">Rename torrent.</param>
        /// <param name="upLimit">Set torrent upload speed limit in bytes/second.</param>
        /// <param name="dlLimit">Set torrent download speed limit in bytes/second.</param>
        /// <param name="squentialDownload">Enable sequential download.</param>
        /// <param name="firstLastPiecePrio">Prioritize download first last piece.</param>
        public static async Task DownloadFromUrl(List<Uri> urls, string savePath = null, string cookie = null, string category = null,
                                            bool? skipChecking = null, bool? paused = null, bool? rootFolder = null,
                                            string rename = null, int? upLimit = null, int? dlLimit = null,
                                            string squentialDownload = null, bool? firstLastPiecePrio = null)
        {
            var form = new MultipartFormDataContent();
            form.Add(new StringContent(ListToString(urls, '\n')), "urls");

            if (savePath != null)
                form.Add(new StringContent(savePath), "savepath");

            if (cookie != null)
                form.Add(new StringContent(cookie), "cookie");

            if (category != null)
                form.Add(new StringContent(category), "category");

            if (skipChecking != null)
                form.Add(new StringContent(skipChecking.ToString().ToLower()), "skip_checking");

            if (paused != null)
                form.Add(new StringContent(paused.ToString().ToLower()), "paused");

            if (rootFolder != null)
                form.Add(new StringContent(rootFolder.ToString().ToLower()), "root_folder");

            if (rename != null)
                form.Add(new StringContent(rename), "rename");

            if (upLimit != null)
                form.Add(new StringContent(upLimit.ToString()), "upLimit");

            if (dlLimit != null)
                form.Add(new StringContent(dlLimit.ToString()), "dlLimit");

            if (squentialDownload != null)
                form.Add(new StringContent(squentialDownload), "squentialDownload");

            if (firstLastPiecePrio != null)
                form.Add(new StringContent(firstLastPiecePrio.ToString().ToLower()), "firstLastPiecePrio");

            await Post(client, "/api/v2/torrents/add", form);
        }

        /// <summary>
        /// Downloads from disk.
        /// </summary>
        /// <param name="filePaths">List of URLs.</param>
        /// <param name="savePath">Download folder.</param>
        /// <param name="cookie">Coookie sent to download the .torrent file..</param>
        /// <param name="category">Category for the torrent.</param>
        /// <param name="skipChecking">Skip hash check.</param>
        /// <param name="paused">Add torrents in the paused state.</param>
        /// <param name="rootFolder">Create the root folder.</param>
        /// <param name="rename">Rename torrent.</param>
        /// <param name="upLimit">Set torrent upload speed limit in bytes/second.</param>
        /// <param name="dlLimit">Set torrent download speed limit in bytes/second.</param>
        /// <param name="squentialDownload">Enable sequential download.</param>
        /// <param name="firstLastPiecePrio">Prioritize download first last piece.</param>
        public static async Task DownloadFromDisk(List<string> filePaths, string savePath = null, string cookie = null, string category = null,
                                            bool? skipChecking = null, bool? paused = null, bool? rootFolder = null,
                                            string rename = null, int? upLimit = null, int? dlLimit = null,
                                            string squentialDownload = null, bool? firstLastPiecePrio = null)
        {
            var form = new MultipartFormDataContent();

            foreach (string filePath in filePaths)
            {
                string filename = Path.GetFileName(filePath);
                var content = File.ReadAllBytes(filePath);

                ByteArrayContent byteArrayContent = new ByteArrayContent(content);
                byteArrayContent.Headers.ContentType =
                    new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-bittorrent");

                form.Add(byteArrayContent, "torrents", filename);
            }

            if (savePath != null)
                form.Add(new StringContent(savePath), "savepath");

            if (cookie != null)
                form.Add(new StringContent(cookie), "cookie");

            if (category != null)
                form.Add(new StringContent(category), "category");

            if (skipChecking != null)
                form.Add(new StringContent(skipChecking.ToString().ToLower()), "skip_checking");

            if (paused != null)
                form.Add(new StringContent(paused.ToString().ToLower()), "paused");

            if (rootFolder != null)
            {
                if (string.Compare(ApiVersion, "2.7") >= 0)
                {
                    string contentLayout = Convert.ToBoolean(rootFolder) ? "Original" : "NoSubfolder";
                    form.Add(new StringContent(contentLayout), "contentLayout");
                }
                else
                {
                    form.Add(new StringContent(rootFolder.ToString().ToLower()), "root_folder");
                }
            }

            if (rename != null)
                form.Add(new StringContent(rename), "rename");

            if (upLimit != null)
                form.Add(new StringContent(upLimit.ToString()), "upLimit");

            if (dlLimit != null)
                form.Add(new StringContent(dlLimit.ToString()), "dlLimit");

            if (squentialDownload != null)
                form.Add(new StringContent(squentialDownload), "squentialDownload");

            if (firstLastPiecePrio != null)
                form.Add(new StringContent(firstLastPiecePrio.ToString().ToLower()), "firstLastPiecePrio");

            await Post(client, "/api/v2/torrents/add", form);
        }

        /// <summary>
        /// Adds trackers to torrent.
        /// </summary>
        /// <param name="hash">Torrent hash.</param>
        /// <param name="trackers">Trackers to be added.</param>
        public static async Task AddTrackers(string hash, List<Uri> trackers)
        {
            var content = ToStringContent("hash=" + hash + "&urls=" + ListToString(trackers, '\n'));
            await Post(client, "/api/v2/torrents/addTrackers", content);
        }

        public static async Task PauseTorrents(List<string> hashList)
        {
            var content = ToStringContent("hashes=" + string.Join("|", hashList));
            await Post(client, "/api/v2/torrents/pause", content);
        }

        /// <summary>
        /// Pauses all torrents.
        /// </summary>
        public static async Task PauseAll()
        {
            await Post(client, "/command/pauseAll");
        }

        public static async Task ResumeTorrents(List<string> hashList)
        {
            var content = ToStringContent("hashes=" + string.Join("|", hashList));
            await Post(client, "/api/v2/torrents/resume", content);
        }

        /// <summary>
        /// Resumes all torrents.
        /// </summary>
        public static async Task ResumeAll()
        {
            await Post(client, "/command/resumeAll");
        }

        /// <summary>
        /// Deletes torrents.
        /// </summary>
        /// <param name="hashes">Hashes of torrents to be deleted.</param>
        /// <param name="deleteData">Delete downloaded data.</param>
        public static async Task DeleteTorrents(List<string> hashes, bool deleteData = false)
        {
            var content = ToStringContent(
                "hashes=" + ListToString(hashes, '|') +
                "&deleteFiles=" + (deleteData ? "true" : "false"));

            await Post(client, "/api/v2/torrents/delete", content);
        }

        /// <summary>
        /// Rechecks torrent.
        /// </summary>
        /// <param name="hash">Torrent hash.</param>
        public static async Task RecheckTorrents(List<string> hashList)
        {
            var content = ToStringContent("hashes=" + string.Join("|", hashList));
            await Post(client, "/api/v2/torrents/recheck", content);
        }

        /// <summary>
        /// Increases priority of torrents. Torrent Queing needs to be enabled.
        /// </summary>
        /// <param name="hashes">Torrent hashes.</param>
        public static async Task IncreaseTorrentPriority(List<string> hashes)
        {
            var content = ToStringContent("hashes=" + ListToString(hashes, '|'));
            await Post(client, "/api/v2/torrents/increasePrio", content);
        }

        /// <summary>
        /// Decreases priority of torrents. Torrent Queing needs to be enabled.
        /// </summary>
        /// <param name="hashes">Torrent hashes.</param>
        public static async Task DecreaseTorrentPriority(List<string> hashes)
        {
            var content = ToStringContent("hashes=" + ListToString(hashes, '|'));
            await Post(client, "/api/v2/torrents/decreasePrio", content);
        }

        /// <summary>
        /// Sets maximum priority of torrents. Torrent Queing needs to be enabled.
        /// </summary>
        /// <param name="hashes">Torrent hashes.</param>
        public static async Task MaxTorrentPriority(List<string> hashes)
        {
            var content = ToStringContent("hashes=" + ListToString(hashes, '|'));
            await Post(client, "/api/v2/torrents/topPrio", content);
        }

        /// <summary>
        /// Sets minimum priority of torrents. Torrent Queing needs to be enabled.
        /// </summary>
        /// <param name="hashes">Torrent hashes.</param>
        public static async Task MinTorrentPriority(List<string> hashes)
        {
            var content = ToStringContent("hashes=" + ListToString(hashes, '|'));
            await Post(client, "/api/v2/torrents/bottomPrio", content);
        }

        /// <summary>
        /// Sets file priority.
        /// </summary>
        /// <param name="hash">Torren hashes.</param>
        /// <param name="fileId">File id.</param>
        /// <param name="priority">File priority.</param>
        /// <returns></returns>
        public static async Task SetFilePriority(string hash, int fileId, Priority priority)
        {
            var content = ToStringContent("hash=" + hash + "&id=" + fileId.ToString() + "&priority=" + ((int)priority).ToString());
            await Post(client, "/api/v2/torrents/filePrio", content);
        }

        /// <summary>
        /// Gets global download speed limit.
        /// </summary>
        /// <returns>Global download speed limit in bytes/second; this value will be zero if no limit is applied.</returns>
        public static async Task<int> GetGlobalDownloadSpeedLimit()
        {
            HttpResponseMessage reply = await Post(client, "/api/v2/transfer/downloadLimit");

            return Int32.Parse(await reply.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Sets global download speed limit.
        /// </summary>
        /// <param name="limit">Global download speed limit in bytes/second.</param>
        public static async Task SetGlobalDownloadSpeedLimit(long limit)
        {
            var content = ToStringContent("limit=" + limit.ToString());
            await Post(client, "/api/v2/transfer/setDownloadLimit", content);
        }

        /// <summary>
        /// Getg global upload speed limit.
        /// </summary>
        /// <returns>Global upload speed limit in bytes/second; this value will be zero if no limit is applied.</returns>
        public static async Task<int> GetGlobalUploadSpeedLimit()
        {
            HttpResponseMessage reply = await Post(client, "/api/v2/transfer/uploadLimit");

            return Int32.Parse(await reply.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Sets global upload speed limit.
        /// </summary>
        /// <param name="limit">Global upload speed limit in bytes/second.</param>
        public static async Task SetGlobalUploadSpeedLimit(long limit)
        {
            var content = ToStringContent("limit=" + limit.ToString());
            await Post(client, "/api/v2/transfer/setUploadLimit", content);
        }

        /// <summary>
        /// Get download speed limit of torrents.
        /// </summary>
        /// <returns>Download speed limit of torrents in bytes/second.</returns>
        public static async Task<List<KeyValuePair<string, int>>> GetTorrentDownloadSpeedLimit(List<string> hashes)
        {
            var content = ToStringContent("hashes=" + ListToString(hashes, '|'));
            var reply = await Post(client, "/api/v2/torrents/downloadLimit", content);
            var objectList = JsonConvert.DeserializeObject<object>(await reply.Content.ReadAsStringAsync());

            var torrentDlLimits = new List<KeyValuePair<string, int>>();
            var properties = (objectList as ICollection).GetEnumerator();
            while (properties.MoveNext())
            {
                JProperty property = (JProperty)properties.Current;
                torrentDlLimits.Add(new KeyValuePair<string, int>(property.Name, (int)property.Value));
            }

            return torrentDlLimits;
        }

        /// <summary>
        /// Sets download speed limit of torrents.
        /// </summary>
        /// <param name="hashes">Torrent hashes.</param>
        /// <param name="limit">Download speed limit of torrents in bytes/second.</param>
        public static async Task SetTorrentDownloadSpeedLimit(List<string> hashes, int limit)
        {
            var content = ToStringContent("hashes=" + ListToString(hashes, '|') + "&limit=" + limit.ToString());
            await Post(client, "/api/v2/torrents/setDownloadLimit", content);
        }

        /// <summary>
        /// Gets upload speed limit of torrents.
        /// </summary>
        /// <returns>Upload speed limit of torrents in bytes/second.</returns>
        public static async Task<List<KeyValuePair<string, int>>> GetTorrentUploadSpeedLimit(List<string> hashes)
        {
            var content = ToStringContent("hashes=" + ListToString(hashes, '|'));
            var reply = await Post(client, "/api/v2/torrents/uploadLimit", content);
            var objectList = JsonConvert.DeserializeObject<object>(await reply.Content.ReadAsStringAsync());

            var torrentUpLimits = new List<KeyValuePair<string, int>>();
            var properties = (objectList as ICollection).GetEnumerator();
            while (properties.MoveNext())
            {
                JProperty property = (JProperty)properties.Current;
                torrentUpLimits.Add(new KeyValuePair<string, int>(property.Name, (int)property.Value));
            }

            return torrentUpLimits;
        }

        /// <summary>
        /// Sets upload speed limit of torrents.
        /// </summary>
        /// <param name="hashes">Torrent hashes.</param>
        /// <param name="limit">Upload speed limit of torrents.</param>
        public static async Task SetTorrentUploadSpeedLimit(List<string> hashes, int limit)
        {
            var content = ToStringContent("hashes=" + ListToString(hashes, '|') + "&limit=" + limit.ToString());
            await Post(client, "/api/v2/torrents/setUploadLimit", content);
        }

        /// <summary>
        /// Sets location of torrents.
        /// </summary>
        /// <param name="hashes">Torrent hashes.</param>
        /// <param name="location">Torrent location.</param>
        public static async Task SetTorrentsLocation(List<string> hashes, string location)
        {
            var content = ToStringContent("hashes=" + ListToString(hashes, '|') + "&location=" + location);
            await Post(client, "/api/v2/torrents/setLocation", content);
        }

        /// <summary>
        /// Sets name of torrents.
        /// </summary>
        /// <param name="hash">Torrent hash.</param>
        /// <param name="name">Torrent name.</param>
        public static async Task SetTorrentName(string hash, string name)
        {
            var content = ToStringContent("hash=" + hash + "&name=" + name);
            await Post(client, "/api/v2/torrents/rename", content);
        }

        /// <summary>
        /// Get all category string.
        /// </summary>
        /// <returns></returns>
        public static async Task<List<string>> GetAllCategoryString()
        {
            var reply = await Post(client, "/api/v2/torrents/categories");
            JObject allCategoriesJSON = (JObject)JsonConvert.DeserializeObject(
                await reply.Content.ReadAsStringAsync());

            List<string> categoryStringList = new List<string>();
            foreach (JToken jt in allCategoriesJSON.Children())
            {
                categoryStringList.Add(jt.Path);
            }

            return categoryStringList;
        }

        /// <summary>
        /// Sets category of torrents.
        /// </summary>
        /// <param name="hashes">Torrent hashes.</param>
        /// <param name="categoryName">Name of category.</param>
        public static async Task SetTorrentCategory(List<string> hashes, string categoryName)
        {
            var content = ToStringContent("hashes=" + ListToString(hashes, '|') + "&category=" + categoryName);
            await Post(client, "/api/v2/torrents/setCategory", content);
        }

        /// <summary>
        /// Adds new category.
        /// </summary>
        /// <param name="categoryName">Category name.</param>
        /// <returns></returns>
        public static async Task AddNewCategory(string categoryName)
        {
            var content = ToStringContent("category=" + categoryName);
            await Post(client, "/command/setCategory", content);
        }

        /// <summary>
        /// Removes category.
        /// </summary>
        /// <param name="categoryNames">Category name.</param>
        /// <returns></returns>
        public static async Task RemoveCategories(List<string> categoryNames)
        {
            var content = ToStringContent("categories=" + ListToString(categoryNames, '\n'));
            await Post(client, "/command/removeCategories", content);
        }

        /// <summary>
        /// Sets automatic torrent management.
        /// </summary>
        /// <param name="hashes">Torrent hashes.</param>
        /// <param name="autoTorrentMgmt">Automatic torrent management.</param>
        /// <returns></returns>
        public static async Task SetAutoTorrentMgmt(List<string> hashes, bool autoTorrentMgmt)
        {
            var content = ToStringContent("hashes=" + ListToString(hashes, '|') + "&enable=" + autoTorrentMgmt.ToString().ToLower());
            await Post(client, "/command/setAutoTMM", content);
        }



        /// <summary>
        /// Gets the state of the alternative speed limits.
        /// </summary>
        /// <returns>True if alternative speed limits is enabled.</returns>
        public static async Task<bool> IsAltSpeedLimitsEnabled()
        {
            HttpResponseMessage reply = await Post(client, "/command/alternativeSpeedLimitsEnabled");

            if (Int32.Parse(await reply.Content.ReadAsStringAsync()) == 1)
                return true;

            return false;
        }

        /// <summary>
        /// Toggles the state of the alternative speed limits.
        /// </summary>
        public static async Task ToggleAltSpeedLimits()
        {
            await Post(client, "/command/toggleAlternativeSpeedLimits");
        }

        /// <summary>
        /// Toggles sequential download.
        /// </summary>
        /// <param name="hashes">Torrent hashes.</param>
        public static async Task ToggleSequentialDownload(List<string> hashes)
        {
            var content = ToStringContent("hashes=" + ListToString(hashes, '|'));
            await Post(client, "/command/toggleSequentialDownload", content);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hashes"></param>
        /// <returns></returns>
        public static async Task ToggleFirstLastPiecePrio(List<string> hashes)
        {
            var content = ToStringContent("hashes=" + ListToString(hashes, '|'));
            await Post(client, "/command/toggleFirstLastPiecePrio", content);
        }

        /// <summary>
        /// Sets first/last piece priority of torrents.
        /// </summary>
        /// <param name="hashes">Torrent hashes.</param>
        /// <param name="activate">Whether to activate first/last piece priority of torrents.</param>
        public static async Task SetForceStart(List<string> hashes, bool activate)
        {
            var content = ToStringContent("hashes=" + ListToString(hashes, '|') + "&value=" + activate.ToString().ToLower());
            await Post(client, "/command/setForceStart", content);
        }

        /// <summary>
        /// Sets super seeding of torrents.
        /// </summary>
        /// <param name="hashes">Torrent hashes.</param>
        /// <param name="activate">Whether to activate super seeding of torrents.</param>
        /// <returns></returns>
        public static async Task SetSuperSeeding(List<string> hashes, bool activate)
        {
            var content = ToStringContent("hashes=" + ListToString(hashes, '|') + "&value=" + activate.ToString().ToLower());
            await Post(client, "/command/setSuperSeeding", content);
        }

        private static void RaiseDisconnectedEvent()
        {
            Disconnected?.Invoke(typeof(API), EventArgs.Empty);
        }
    }
}
