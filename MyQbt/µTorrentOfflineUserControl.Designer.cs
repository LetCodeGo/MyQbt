namespace MyQbt
{
    partial class µTorrentOfflineUserControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSaveResumeData = new System.Windows.Forms.Button();
            this.btnLoadResumeData = new System.Windows.Forms.Button();
            this.groupBoxAction = new System.Windows.Forms.GroupBox();
            this.btnRemoveInvalidTorrentInfo = new System.Windows.Forms.Button();
            this.btnRemoveTorrent = new System.Windows.Forms.Button();
            this.groupBoxAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveResumeData
            // 
            this.btnSaveResumeData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveResumeData.Location = new System.Drawing.Point(6, 20);
            this.btnSaveResumeData.Name = "btnSaveResumeData";
            this.btnSaveResumeData.Size = new System.Drawing.Size(682, 23);
            this.btnSaveResumeData.TabIndex = 11;
            this.btnSaveResumeData.Text = "保存 resume.dat";
            this.btnSaveResumeData.UseVisualStyleBackColor = true;
            this.btnSaveResumeData.Click += new System.EventHandler(this.BtnSaveResumeData_Click);
            // 
            // btnLoadResumeData
            // 
            this.btnLoadResumeData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadResumeData.Location = new System.Drawing.Point(3, 3);
            this.btnLoadResumeData.Name = "btnLoadResumeData";
            this.btnLoadResumeData.Size = new System.Drawing.Size(694, 23);
            this.btnLoadResumeData.TabIndex = 10;
            this.btnLoadResumeData.Text = "执行任何操作前请先加载 resume.data 文件";
            this.btnLoadResumeData.UseVisualStyleBackColor = true;
            this.btnLoadResumeData.Click += new System.EventHandler(this.BtnLoadResumeData_Click);
            // 
            // groupBoxAction
            // 
            this.groupBoxAction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAction.Controls.Add(this.btnRemoveInvalidTorrentInfo);
            this.groupBoxAction.Controls.Add(this.btnRemoveTorrent);
            this.groupBoxAction.Controls.Add(this.btnSaveResumeData);
            this.groupBoxAction.Location = new System.Drawing.Point(3, 32);
            this.groupBoxAction.Name = "groupBoxAction";
            this.groupBoxAction.Size = new System.Drawing.Size(694, 365);
            this.groupBoxAction.TabIndex = 12;
            this.groupBoxAction.TabStop = false;
            // 
            // btnRemoveInvalidTorrentInfo
            // 
            this.btnRemoveInvalidTorrentInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveInvalidTorrentInfo.Location = new System.Drawing.Point(6, 78);
            this.btnRemoveInvalidTorrentInfo.Name = "btnRemoveInvalidTorrentInfo";
            this.btnRemoveInvalidTorrentInfo.Size = new System.Drawing.Size(682, 23);
            this.btnRemoveInvalidTorrentInfo.TabIndex = 15;
            this.btnRemoveInvalidTorrentInfo.Text = "移除UT中实际数据不存在的种子信息（只是移除了 resume.data 中的信息，种子文件还没删）";
            this.btnRemoveInvalidTorrentInfo.UseVisualStyleBackColor = true;
            this.btnRemoveInvalidTorrentInfo.Click += new System.EventHandler(this.BtnRemoveInvalidTorrentInfo_Click);
            // 
            // btnRemoveTorrent
            // 
            this.btnRemoveTorrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveTorrent.Location = new System.Drawing.Point(6, 136);
            this.btnRemoveTorrent.Name = "btnRemoveTorrent";
            this.btnRemoveTorrent.Size = new System.Drawing.Size(682, 23);
            this.btnRemoveTorrent.TabIndex = 14;
            this.btnRemoveTorrent.Text = "移除指定目录下不关联于UT中的种子（不修改 resume.data）";
            this.btnRemoveTorrent.UseVisualStyleBackColor = true;
            this.btnRemoveTorrent.Click += new System.EventHandler(this.BtnRemoveTorrent_Click);
            // 
            // µTorrentOfflineUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxAction);
            this.Controls.Add(this.btnLoadResumeData);
            this.Name = "µTorrentOfflineUserControl";
            this.Size = new System.Drawing.Size(700, 400);
            this.Load += new System.EventHandler(this.ΜTorrentOfflineUserControl_Load);
            this.groupBoxAction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveResumeData;
        private System.Windows.Forms.Button btnLoadResumeData;
        private System.Windows.Forms.GroupBox groupBoxAction;
        private System.Windows.Forms.Button btnRemoveInvalidTorrentInfo;
        private System.Windows.Forms.Button btnRemoveTorrent;
    }
}
