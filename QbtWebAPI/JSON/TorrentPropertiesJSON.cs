namespace QbtWebAPI.JSON
{
    internal class TorrentPropertiesJSON
    {
        public string Save_Path { get; set; }
        public long Creation_Date { get; set; }
        public long Piece_Size { get; set; }
        public string Comment { get; set; }
        public long Total_Wasted { get; set; }
        public long Total_Uploaded { get; set; }
        public long Total_Uploaded_Session { get; set; }
        public long Total_Downloaded { get; set; }
        public long Total_Downloaded_Session { get; set; }
        public long Up_Limit { get; set; }
        public long Dl_Limit { get; set; }
        public long Time_Elapsed { get; set; }
        public long Seeding_Time { get; set; }
        public int Nb_Connections { get; set; }
        public int Nb_Connections_Limit { get; set; }
        public float Share_Ratio { get; set; }
        public long Addition_Date { get; set; }
        public long Completion_Date { get; set; }
        public string Created_By { get; set; }
        public long Dl_Speed_Avg { get; set; }
        public long Dl_Speed { get; set; }
        public long Eta { get; set; }
        public int Last_Seen { get; set; }
        public int Peers { get; set; }
        public int Peers_Total { get; set; }
        public int Pieces_Have { get; set; }
        public int Pieces_Num { get; set; }
        public long Reannounce { get; set; }
        public int Seeds { get; set; }
        public int Seeds_Total { get; set; }
        public long Total_Size { get; set; }
        public long Up_Speed_Avg { get; set; }
        public long Up_Speed { get; set; }
    }
}
