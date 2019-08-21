namespace QbtWebAPI.JSON
{
    internal class TransferInfoJSON
    {
        public long dl_info_speed { get; set; }
        public long dl_info_data { get; set; }
        public long up_info_speed { get; set; }
        public long up_info_data { get; set; }
        public long dl_rate_limit { get; set; }
        public long up_rate_limit { get; set; }
        public int dht_nodes { get; set; }
        public string connection_status { get; set; }
        public bool queueing { get; set; }
        public bool use_alt_speed_limits { get; set; }
        public long refresh_interval { get; set; }
    }
}
