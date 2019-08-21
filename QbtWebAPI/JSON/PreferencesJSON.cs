using QbtWebAPI.Data;
using System;
using System.Collections.Generic;

namespace QbtWebAPI.JSON
{

	internal class PreferencesJSON
	{
		public string add_trackers { get; set; }
		public bool? add_trackers_enabled { get; set; }
		public long? alt_dl_limit { get; set; }
		public long? alt_up_limit { get; set; }
		public bool? anonymous_mode { get; set; }
		public bool? autorun_enabled { get; set; }
		public string autorun_program { get; set; }
		public bool? bypass_local_auth { get; set; }
		public bool? dht { get; set; }
		public bool? dhtSameAsBT { get; set; }
		public bool? dht_port { get; set; }
		public long? dl_limit { get; set; }
		public bool? dont_count_slow_torrents { get; set; }
		public string[] download_in_scan_dirs { get; set; }
		public string dyndns_domain { get; set; }
		public bool? dyndns_enabled { get; set; }
		public string dyndns_password { get; set; }
		public int? dyndns_service { get; set; }
		public string dyndns_username { get; set; }
		public bool? enable_utp { get; set; }
		public int? encryption { get; set; }
		public string export_dir { get; set; }
		public string export_dir_fin { get; set; }
		public bool? force_proxy { get; set; }
		public bool? incomplete_files_ext { get; set; }
		public bool? ip_filter_enabled { get; set; }
		public string ip_filter_path { get; set; }
		public bool? ip_filter_trackers { get; set; }
		public bool? limit_tcp_overhead { get; set; }
		public bool? limit_utp_rate { get; set; }
		public int? listen_port { get; set; }
		public string locale { get; set; }
		public bool? lsd { get; set; }
		public bool? mail_notification_auth_enabled { get; set; }
		public string mail_notification_email { get; set; }
		public bool? mail_notification_enabled { get; set; }
		public string mail_notification_password { get; set; }
		public string mail_notification_smtp { get; set; }
		public bool? mail_notification_ssl_enabled { get; set; }
		public string mail_notification_username { get; set; }
		public int? max_active_downloads { get; set; }
		public int? max_active_torrents { get; set; }
		public int? max_active_uploads { get; set; }
		public int? max_connec { get; set; }
		public int? max_connec_per_torrent { get; set; }
		public float? max_ratio { get; set; }
		public int? max_ratio_act { get; set; }
		public bool? max_ratio_enabled { get; set; }
		public int? max_uploads { get; set; }
		public int? max_uploads_per_torrent { get; set; }
		public bool? pex { get; set; }
		public bool? preallocate_all { get; set; }
		public bool? proxy_auth_enabled { get; set; }
		public string proxy_ip { get; set; }
		public string proxy_password { get; set; }
		public bool? proxy_peer_connections { get; set; }
		public int? proxy_port { get; set; }
		public int? proxy_type { get; set; }
		public string proxy_username { get; set; }
		public bool? queueing_enabled { get; set; }
		public bool? random_port { get; set; }
		public string save_path { get; set; }
		public Dictionary<string, int> scan_dirs { get; set; }
		public int? schedule_from_hour { get; set; }
		public int? schedule_from_min { get; set; }
		public int? schedule_to_hour { get; set; }
		public int? schedule_to_min { get; set; }
		public int? scheduler_days { get; set; }
		public bool? scheduler_enabled { get; set; }
		public string ssl_cert { get; set; }
		public string ssl_key { get; set; }
		public string temp_path { get; set; }
		public bool? temp_path_enabled { get; set; }
		public long? up_limit { get; set; }
		public bool? upnp { get; set; }
		public bool? use_https { get; set; }
		public string web_ui_domain_list { get; set; }
		public string web_ui_password { get; set; }
		public int? web_ui_port { get; set; }
		public bool? web_ui_upnp { get; set; }
		public string web_ui_username { get; set; }

		public PreferencesJSON() { }

		public PreferencesJSON(Preferences p)
		{
			if (p.Add_Trackers != null)
			{
				add_trackers = "";
				foreach (var e in p.Add_Trackers)
					add_trackers += e.ToString() + "\n";
				add_trackers = add_trackers.Remove(add_trackers.Length - 1);
			}
			add_trackers_enabled = p.Add_Trackers_Enabled;
			alt_dl_limit = p.Alt_Dl_Limit;
			alt_up_limit = p.Alt_Up_Limit;
			anonymous_mode = p.Anonymous_Mode;
			autorun_enabled = p.Autorun_Enabled;
			autorun_program = p.Autorun_Program;
			bypass_local_auth = p.Bypass_Local_Auth;
			dht = p.Dht;
			dhtSameAsBT = p.DhtSameAsBT;
			dht_port = p.Dht_Port;
			dl_limit = p.Dl_Limit;
			dont_count_slow_torrents = p.Dont_Count_Slow_Torrents;
			dyndns_domain = p.Dyndns_Domain;
			dyndns_enabled = p.Dyndns_Enabled;
			dyndns_password = p.Dyndns_Password;
			if (p.Dyndns_Service != null)
				dyndns_service = (int)p.Dyndns_Service;
			dyndns_username = p.Dyndns_Username;
			enable_utp = p.Enable_Utp;
			if (p.Encryption != null)
				encryption = (int)p.Encryption;
			export_dir = p.Export_Dir;
			export_dir_fin = p.Export_Dir_Finished;
			force_proxy = p.Force_Proxy;
			incomplete_files_ext = p.Incomplete_Files_Ext;
			ip_filter_enabled = p.Ip_Filter_Enabled;
			ip_filter_path = p.Ip_Filter_Path;
			ip_filter_trackers = p.Ip_Filter_Trackers;
			limit_tcp_overhead = p.Limit_Tcp_Overhead;
			limit_utp_rate = p.Limit_Utp_Rate;
			listen_port = p.Listen_Port;
			if (p.Locale != null)
				locale = p.Locale.ToString();
			lsd = p.Lsd;
			mail_notification_auth_enabled = p.Mail_Notification_Auth_Enabled;
			mail_notification_email = p.Mail_Notification_Email;
			mail_notification_enabled = p.Mail_Notification_Enabled;
			mail_notification_password = p.Mail_Notification_Password;
			mail_notification_smtp = p.Mail_Notification_Smtp;
			mail_notification_ssl_enabled = p.Mail_Notification_Ssl_Enabled;
			mail_notification_username = p.Mail_Notification_Username;
			max_active_downloads = p.Max_Active_Downloads;
			max_active_torrents = p.Max_Active_Torrents;
			max_active_uploads = p.Max_Active_Uploads;
			max_connec = p.Max_Connec;
			max_connec_per_torrent = p.Max_Connec_Per_Torrent;
			max_ratio = p.Max_Ratio;
			if (p.Max_Ratio_Action != null)
				max_ratio_act = (int)p.Max_Ratio_Action;
			max_ratio_enabled = p.Max_Ratio_Enabled;
			max_uploads = p.Max_Uploads;
			max_uploads_per_torrent = p.Max_Uploads_Per_Torrent;
			pex = p.Pex;
			preallocate_all = p.Preallocate_All;
			proxy_auth_enabled = p.Proxy_Auth_Enabled;
			proxy_ip = p.Proxy_Ip;
			proxy_password = p.Proxy_Password;
			proxy_peer_connections = p.Proxy_Peer_Connections;
			proxy_port = p.Proxy_Port;
			if (p.Proxy_type != null)
				proxy_type = (int)p.Proxy_type;
			proxy_username = p.Proxy_Username;
			queueing_enabled = p.Queueing_Enabled;
			random_port = p.Random_Port;
			save_path = p.Save_Path;
			if (p.Scan_Dirs != null)
			{
				download_in_scan_dirs = new string[p.Scan_Dirs.Count];
				scan_dirs = new Dictionary<string, int>();
				int i = 0;
				foreach (var e in p.Scan_Dirs)
				{
					scan_dirs.Add(e.Key, Convert.ToInt32(e.Key));
					download_in_scan_dirs[i] = e.Key;
					i++;
				}
			}
			if (p.Scheduler_Days != null)
				scheduler_days = (int)p.Scheduler_Days;
			scheduler_enabled = p.Scheduler_Enabled;
			if (p.Schedule_From != null)
			{
				schedule_from_hour = p.Schedule_From.Hours;
				schedule_from_min = p.Schedule_From.Minutes;
			}
			if (p.Schedule_To != null)
			{
				schedule_to_hour = p.Schedule_To.Hours;
				schedule_to_min = p.Schedule_To.Minutes;
			}
			ssl_cert = p.Ssl_Cert;
			ssl_key = p.Ssl_Key;
			temp_path = p.Temp_Path;
			temp_path_enabled = p.Temp_Path_Enabled;
			up_limit = p.Up_Limit;
			upnp = p.Upnp;
			use_https = p.Use_Https;
			web_ui_domain_list = p.Web_Ui_Domain_List;
			web_ui_password = p.Web_Ui_Password;
			web_ui_port = p.Web_Ui_Port;
			web_ui_upnp = p.Web_Ui_Upnp;
			web_ui_username = p.Web_Ui_Username;
		}
	}
}
