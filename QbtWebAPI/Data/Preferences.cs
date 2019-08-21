using System;
using System.Collections.Generic;
using QbtWebAPI.Enums;

namespace QbtWebAPI.Data
{
	/// <summary>
	/// Preferences.
	/// </summary>
	public class Preferences
	{
		/// <summary>
		/// Trackers to be added to new torrents.
		/// </summary>
		public List<Uri> Add_Trackers { get; set; }
		/// <summary>
		/// Automatically add trackers to new torrents.
		/// </summary>
		public bool? Add_Trackers_Enabled { get; set; }
		/// <summary>
		/// Alternative global download speed limit in KiB/s.
		/// </summary>
		public long? Alt_Dl_Limit { get; set; }
		/// <summary>
		/// Alternative global upload speed limit in KiB/s.
		/// </summary>
		public long? Alt_Up_Limit { get; set; }
		/// <summary>
		/// If true anonymous mode will be enabled.
		/// </summary>
		public bool? Anonymous_Mode { get; set; }
		/// <summary>
		/// True if external program should be run after torrent has finished downloading.
		/// </summary>
		public bool? Autorun_Enabled { get; set; }
		/// <summary>
		/// Program path/name/arguments to run if autorun_enabled is enabled; 
		/// path is separated by slashes; you can use %f and %n arguments, 
		/// which will be expanded by qBittorent as path_to_torrent_file and torrent_name 
		/// (from the GUI; not the .torrent file name) respectively.
		/// </summary>
		public string Autorun_Program { get; set; }
		/// <summary>
		/// True if authentication challenge for loopback address (127.0.0.1) should be disabled.
		/// </summary>
		public bool? Bypass_Local_Auth { get; set; }
		/// <summary>
		/// True if DHT is enabled.
		/// </summary>
		public bool? Dht { get; set; }
		/// <summary>
		/// True if DHT port should match TCP port
		/// </summary>
		public bool? DhtSameAsBT { get; set; }
		/// <summary>
		/// DHT port if dhtSameAsBT is false.
		/// </summary>
		public bool? Dht_Port { get; set; }
		/// <summary>
		/// Global download speed limit in KiB/s; -1 means no limit is applied.
		/// </summary>
		public long? Dl_Limit { get; set; }
		/// <summary>
		/// If true torrents w/o any activity (stalled ones) will not be counted towards max_active_* limits.
		/// </summary>
		public bool? Dont_Count_Slow_Torrents { get; set; }
		/// <summary>
		/// Your DDNS domain name.
		/// </summary>
		public string Dyndns_Domain { get; set; }
		/// <summary>
		/// True if server DNS should be updated dynamically.
		/// </summary>
		public bool? Dyndns_Enabled { get; set; }
		/// <summary>
		/// Password for DDNS service.
		/// </summary>
		public string Dyndns_Password { get; set; }
		/// <summary>
		/// DDNS service.
		/// </summary>
		public DynDnsService? Dyndns_Service { get; set; }
		/// <summary>
		/// Username for DDNS service.
		/// </summary>
		public string Dyndns_Username { get; set; }
		/// <summary>
		/// True if uTP protocol should be enabled.
		/// </summary>
		public bool? Enable_Utp { get; set; }
		/// <summary>
		/// Encryption.
		/// </summary>
		public Encryption? Encryption { get; set; }
		/// <summary>
		/// Path to directory to copy .torrent files if export_dir_enabled is enabled; path is separated by slashes.
		/// </summary>
		public string Export_Dir { get; set; }
		/// <summary>
		/// Path to directory to copy .torrent files if export_dir_enabled is enabled; path is separated by slashes.
		/// </summary>
		public string Export_Dir_Finished { get; set; }
		/// <summary>
		/// True if the connections not supported by the proxy are disabled
		/// </summary>
		public bool? Force_Proxy { get; set; }
		/// <summary>
		/// If true .!qB extension will be appended to incomplete files.
		/// </summary>
		public bool? Incomplete_Files_Ext { get; set; }
		/// <summary>
		/// True if external IP filter should be enabled.
		/// </summary>
		public bool? Ip_Filter_Enabled { get; set; }
		/// <summary>
		/// Path to IP filter file (.dat, .p2p, .p2b files are supported); path is separated by slashes.
		/// </summary>
		public string Ip_Filter_Path { get; set; }
		/// <summary>
		/// True if IP filters are applied to trackers.
		/// </summary>
		public bool? Ip_Filter_Trackers { get; set; }
		/// <summary>
		/// True if [du]l_limit should be applied to estimated TCP overhead (service data: e.g. packet headers).
		/// </summary>
		public bool? Limit_Tcp_Overhead { get; set; }
		/// <summary>
		/// True if [du]l_limit should be applied to uTP connections.
		/// </summary>
		public bool? Limit_Utp_Rate { get; set; }
		/// <summary>
		/// Port for incoming connections.
		/// </summary>
		public int? Listen_Port { get; set; }
		/// <summary>
		/// Currently selected language.
		/// </summary>
		public Locale? Locale { get; set; }
		/// <summary>
		/// True if LSD is enabled.
		/// </summary>
		public bool? Lsd { get; set; }
		/// <summary>
		/// True if smtp server requires authentication
		/// </summary>
		public bool? Mail_Notification_Auth_Enabled { get; set; }
		/// <summary>
		/// e-mail to send notifications to.
		/// </summary>
		public string Mail_Notification_Email { get; set; }
		/// <summary>
		/// True if e-mail notification should be enabled.
		/// </summary>
		public bool? Mail_Notification_Enabled { get; set; }
		/// <summary>
		/// Password for smtp authentication.
		/// </summary>
		public string Mail_Notification_Password { get; set; }
		/// <summary>
		/// smtp server for e-mail notifications.
		/// </summary>
		public string Mail_Notification_Smtp { get; set; }
		/// <summary>
		/// True if smtp server requires SSL connection.
		/// </summary>
		public bool? Mail_Notification_Ssl_Enabled { get; set; }
		/// <summary>
		/// Username for smtp authentication.
		/// </summary>
		public string Mail_Notification_Username { get; set; }
		/// <summary>
		/// Maximum number of active simultaneous downloads.
		/// </summary>
		public int? Max_Active_Downloads { get; set; }
		/// <summary>
		/// Maximum number of active simultaneous downloads and uploads.
		/// </summary>
		public int? Max_Active_Torrents { get; set; }
		/// <summary>
		/// Maximum number of active simultaneous uploads.
		/// </summary>
		public int? Max_Active_Uploads { get; set; }
		/// <summary>
		/// Maximum global number of simultaneous connections.
		/// </summary>
		public int? Max_Connec { get; set; }
		/// <summary>
		/// Maximum number of simultaneous connections per torrent.
		/// </summary>
		public int? Max_Connec_Per_Torrent { get; set; }
		/// <summary>
		/// Get the global share ratio limit.
		/// </summary>
		public float? Max_Ratio { get; set; }
		/// <summary>
		/// Action performed when a torrent reaches the maximum share ratio.
		/// </summary>
		public MaxRatioAction? Max_Ratio_Action { get; set; }
		/// <summary>
		/// True if share ratio limit is enabled.
		/// </summary>
		public bool? Max_Ratio_Enabled { get; set; }
		/// <summary>
		/// Maximum number of upload slots.
		/// </summary>
		public int? Max_Uploads { get; set; }
		/// <summary>
		/// Maximum number of upload slots per torrent.
		/// </summary>
		public int? Max_Uploads_Per_Torrent { get; set; }
		/// <summary>
		/// True if PeX is enabled.
		/// </summary>
		public bool? Pex { get; set; }
		/// <summary>
		/// True if file preallocation should take place, otherwise sparse files are used.
		/// </summary>
		public bool? Preallocate_All { get; set; }
		/// <summary>
		/// True proxy requires authentication; doesn't apply to SOCKS4 proxies.
		/// </summary>
		public bool? Proxy_Auth_Enabled { get; set; }
		/// <summary>
		/// Proxy IP address or domain name.
		/// </summary>
		public string Proxy_Ip { get; set; }
		/// <summary>
		/// Password for proxy authentication.
		/// </summary>
		public string Proxy_Password { get; set; }
		/// <summary>
		/// True if peer and web seed connections should be proxified.
		/// </summary>
		public bool? Proxy_Peer_Connections { get; set; }
		/// <summary>
		/// Proxy port.
		/// </summary>
		public int? Proxy_Port { get; set; }
		/// <summary>
		/// Proxy type.
		/// </summary>
		public ProxyType? Proxy_type { get; set; }
		/// <summary>
		/// Username for proxy authentication.
		/// </summary>
		public string Proxy_Username { get; set; }
		/// <summary>
		/// True if torrent queuing is enabled.
		/// </summary>
		public bool? Queueing_Enabled { get; set; }
		/// <summary>
		/// True if the port is randomly selected.
		/// </summary>
		public bool? Random_Port { get; set; }
		/// <summary>
		/// Default save path for torrents, separated by slashes.
		/// </summary>
		public string Save_Path { get; set; }
		/// <summary>
		/// List of watch folders, true if torrents gets added automatically.
		/// </summary>
		public Dictionary<string, bool> Scan_Dirs { get; set; }
		/// <summary>
		/// Scheduler starting time.
		/// </summary>
		public Time Schedule_From { get; set; }
		/// <summary>
		/// Scheduler ending time.
		/// </summary>
		public Time Schedule_To { get; set; }
		/// <summary>
		/// Scheduler days.
		/// </summary>
		public SchedulerDay? Scheduler_Days { get; set; }
		/// <summary>
		/// True if alternative limits should be applied according to schedule.
		/// </summary>
		public bool? Scheduler_Enabled { get; set; }
		/// <summary>
		/// SSL certificate contents (this is a not a path).
		/// </summary>
		public string Ssl_Cert { get; set; }
		/// <summary>
		/// SSL keyfile contents (this is a not a path).
		/// </summary>
		public string Ssl_Key { get; set; }
		/// <summary>
		/// Path for incomplete torrents, separated by slashes.
		/// </summary>
		public string Temp_Path { get; set; }
		/// <summary>
		/// True if folder for incomplete torrents is enabled.
		/// </summary>
		public bool? Temp_Path_Enabled { get; set; }
		/// <summary>
		/// Global upload speed limit in KiB/s; -1 means no limit is applied
		/// </summary>
		public long? Up_Limit { get; set; }
		/// <summary>
		/// True if UPnP/NAT-PMP is enabled.
		/// </summary>
		public bool? Upnp { get; set; }
		/// <summary>
		/// True if WebUI HTTPS access is enabled.
		/// </summary>
		public bool? Use_Https { get; set; }
		/// <summary>
		/// WebUI domain list.
		/// </summary>
		public string Web_Ui_Domain_List { get; set; }
		/// <summary>
		/// MD5 hash of WebUI password.
		/// </summary>
		public string Web_Ui_Password { get; set; }
		/// <summary>
		/// WebUI port.
		/// </summary>
		public int? Web_Ui_Port { get; set; }
		/// <summary>
		/// True if UPnP is used for the WebUI port.
		/// </summary>
		public bool? Web_Ui_Upnp { get; set; }
		/// <summary>
		/// WebUI username.
		/// </summary>
		public string Web_Ui_Username { get; set; }

		/// <summary>
		///  Initializes a new instance of the <see cref="Preferences"/> class.
		/// </summary>
		public Preferences() { }

		internal Preferences(JSON.PreferencesJSON p)
		{
			Add_Trackers = new List<Uri>();
			if (p.add_trackers != "")
			{
				var strings = p.add_trackers.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
				foreach (var e in strings)
				{
					try { Add_Trackers.Add(new Uri(e)); }
					catch { }
				}
			}
			Add_Trackers_Enabled = p.add_trackers_enabled;
			Alt_Dl_Limit = p.alt_dl_limit;
			Alt_Up_Limit = p.alt_up_limit;
			Anonymous_Mode = p.anonymous_mode;
			Autorun_Enabled = p.autorun_enabled;
			Autorun_Program = p.autorun_program;
			Bypass_Local_Auth = p.bypass_local_auth;
			Dht = p.dht;
			DhtSameAsBT = p.dhtSameAsBT;
			Dht_Port = p.dht_port;
			Dl_Limit = p.dl_limit;
			Dont_Count_Slow_Torrents = p.dont_count_slow_torrents;
			Dyndns_Domain = p.dyndns_domain;
			Dyndns_Enabled = p.dyndns_enabled;
			Dyndns_Password = p.dyndns_password;
			Dyndns_Service = (DynDnsService)p.dyndns_service;
			Dyndns_Username = p.dyndns_username;
			Enable_Utp = p.enable_utp;
			Encryption = (Encryption)p.encryption;
			Export_Dir = p.export_dir;
			Export_Dir_Finished = p.export_dir_fin;
			Force_Proxy = p.force_proxy;
			Incomplete_Files_Ext = p.incomplete_files_ext;
			Ip_Filter_Enabled = p.ip_filter_enabled;
			Ip_Filter_Path = p.ip_filter_path;
			Ip_Filter_Trackers = p.ip_filter_trackers;
			Limit_Tcp_Overhead = p.limit_tcp_overhead;
			Limit_Utp_Rate = p.limit_utp_rate;
			Listen_Port = p.listen_port;
			Locale = (Locale)Enum.Parse(typeof(Locale), p.locale, true);
			Lsd = p.lsd;
			Mail_Notification_Auth_Enabled = p.mail_notification_auth_enabled;
			Mail_Notification_Email = p.mail_notification_email;
			Mail_Notification_Enabled = p.mail_notification_enabled;
			Mail_Notification_Password = p.mail_notification_password;
			Mail_Notification_Smtp = p.mail_notification_smtp;
			Mail_Notification_Ssl_Enabled = p.mail_notification_ssl_enabled;
			Mail_Notification_Username = p.mail_notification_username;
			Max_Active_Downloads = p.max_active_downloads;
			Max_Active_Torrents = p.max_active_torrents;
			Max_Active_Uploads = p.max_active_uploads;
			Max_Connec = p.max_connec;
			Max_Connec_Per_Torrent = p.max_connec_per_torrent;
			Max_Ratio = p.max_ratio;
			Max_Ratio_Action = (MaxRatioAction)p.max_ratio_act;
			Max_Ratio_Enabled = p.max_ratio_enabled;
			Max_Uploads = p.max_uploads;
			Max_Uploads_Per_Torrent = p.max_uploads_per_torrent;
			Pex = p.pex;
			Preallocate_All = p.preallocate_all;
			Proxy_Auth_Enabled = p.proxy_auth_enabled;
			Proxy_Ip = p.proxy_ip;
			Proxy_Password = p.proxy_password;
			Proxy_Peer_Connections = p.proxy_peer_connections;
			Proxy_Port = p.proxy_port;
			Proxy_type = (ProxyType)p.proxy_type;
			Proxy_Username = p.proxy_username;
			Queueing_Enabled = p.queueing_enabled;
			Random_Port = p.random_port;
			Save_Path = p.save_path;
			Scan_Dirs = new Dictionary<string, bool>();
			if (p.scan_dirs != null)
				foreach (var e in p.scan_dirs)
					Scan_Dirs.Add(e.Key, (e.Value == 1));
			Schedule_From = new Time((int)p.schedule_from_hour, (int)p.schedule_from_min);
			Schedule_To = new Time((int)p.schedule_to_hour, (int)p.schedule_to_min);
			Scheduler_Days = (SchedulerDay)p.scheduler_days;
			Scheduler_Enabled = p.scheduler_enabled;
			Ssl_Cert = p.ssl_cert;
			Ssl_Key = p.ssl_key;
			Temp_Path = p.temp_path;
			Temp_Path_Enabled = p.temp_path_enabled;
			Up_Limit = p.up_limit;
			Upnp = p.upnp;
			Use_Https = p.use_https;
			Web_Ui_Domain_List = p.web_ui_domain_list;
			Web_Ui_Password = p.web_ui_password;
			Web_Ui_Port = p.web_ui_port;
			Web_Ui_Upnp = p.web_ui_upnp;
			Web_Ui_Username = p.web_ui_username;
		}
	}
}
