namespace MyQbt
{
    partial class WinForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cbUrl = new System.Windows.Forms.ComboBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageqBittorrentOnline = new System.Windows.Forms.TabPage();
            this.groupBoxOnlineOther = new System.Windows.Forms.GroupBox();
            this.btnGetCategoryAllTorrentSavePath = new System.Windows.Forms.Button();
            this.groupBoxPathMap = new System.Windows.Forms.GroupBox();
            this.rtbPathMap = new System.Windows.Forms.RichTextBox();
            this.groupBoxAdd = new System.Windows.Forms.GroupBox();
            this.groupBoxQbtSysytem = new System.Windows.Forms.GroupBox();
            this.rbLinux = new System.Windows.Forms.RadioButton();
            this.rbWindows = new System.Windows.Forms.RadioButton();
            this.cbSkipHashCheck = new System.Windows.Forms.CheckBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbStartTorrent = new System.Windows.Forms.CheckBox();
            this.btnAddTorrent = new System.Windows.Forms.Button();
            this.groupBoxAddSaveFolder = new System.Windows.Forms.GroupBox();
            this.cbPathMap = new System.Windows.Forms.CheckBox();
            this.cbSettingSaveFolder = new System.Windows.Forms.ComboBox();
            this.cbSaveFolder = new System.Windows.Forms.ComboBox();
            this.cbSaveDisk = new System.Windows.Forms.ComboBox();
            this.groupBoxAddType = new System.Windows.Forms.GroupBox();
            this.rbKeep = new System.Windows.Forms.RadioButton();
            this.rbManual = new System.Windows.Forms.RadioButton();
            this.rbAddPrefixWithFileName = new System.Windows.Forms.RadioButton();
            this.groupBoxLogin = new System.Windows.Forms.GroupBox();
            this.cbKeepConnectSetting = new System.Windows.Forms.CheckBox();
            this.tabPageqBittorrentOffline = new System.Windows.Forms.TabPage();
            this.groupBoxOfflineOther = new System.Windows.Forms.GroupBox();
            this.btnRemoveNotExistDataFileTorrent = new System.Windows.Forms.Button();
            this.buttonOther = new System.Windows.Forms.Button();
            this.groupBoxTrackers = new System.Windows.Forms.GroupBox();
            this.cbFindCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTrackerFindAndReplace = new System.Windows.Forms.Button();
            this.cbTrackerReplace = new System.Windows.Forms.ComboBox();
            this.cbTrackerFind = new System.Windows.Forms.ComboBox();
            this.groupBoxModifyDisk = new System.Windows.Forms.GroupBox();
            this.cbTorrentNeverStart = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDiskChange = new System.Windows.Forms.Button();
            this.cbDiskTo = new System.Windows.Forms.ComboBox();
            this.cbDiskFrom = new System.Windows.Forms.ComboBox();
            this.tabPageµTorrentOffline = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabPageqBittorrentOnline.SuspendLayout();
            this.groupBoxOnlineOther.SuspendLayout();
            this.groupBoxPathMap.SuspendLayout();
            this.groupBoxAdd.SuspendLayout();
            this.groupBoxQbtSysytem.SuspendLayout();
            this.groupBoxAddSaveFolder.SuspendLayout();
            this.groupBoxAddType.SuspendLayout();
            this.groupBoxLogin.SuspendLayout();
            this.tabPageqBittorrentOffline.SuspendLayout();
            this.groupBoxOfflineOther.SuspendLayout();
            this.groupBoxTrackers.SuspendLayout();
            this.groupBoxModifyDisk.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbUrl
            // 
            this.cbUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbUrl.Location = new System.Drawing.Point(8, 20);
            this.cbUrl.Name = "cbUrl";
            this.cbUrl.Size = new System.Drawing.Size(253, 20);
            this.cbUrl.TabIndex = 0;
            this.cbUrl.Text = "http://127.0.0.1:12305/";
            this.cbUrl.SelectedIndexChanged += new System.EventHandler(this.CbUrl_SelectedIndexChanged);
            // 
            // tbUser
            // 
            this.tbUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUser.Location = new System.Drawing.Point(8, 43);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(253, 21);
            this.tbUser.TabIndex = 1;
            this.tbUser.Text = "admin";
            // 
            // tbPassword
            // 
            this.tbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPassword.Location = new System.Drawing.Point(8, 66);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(253, 21);
            this.tbPassword.TabIndex = 2;
            this.tbPassword.Text = "password";
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.Location = new System.Drawing.Point(110, 91);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(151, 23);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "登陆";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageqBittorrentOnline);
            this.tabControl.Controls.Add(this.tabPageqBittorrentOffline);
            this.tabControl.Controls.Add(this.tabPageµTorrentOffline);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.TabIndex = 4;
            // 
            // tabPageqBittorrentOnline
            // 
            this.tabPageqBittorrentOnline.Controls.Add(this.groupBoxOnlineOther);
            this.tabPageqBittorrentOnline.Controls.Add(this.groupBoxPathMap);
            this.tabPageqBittorrentOnline.Controls.Add(this.groupBoxAdd);
            this.tabPageqBittorrentOnline.Controls.Add(this.groupBoxLogin);
            this.tabPageqBittorrentOnline.Location = new System.Drawing.Point(4, 22);
            this.tabPageqBittorrentOnline.Name = "tabPageqBittorrentOnline";
            this.tabPageqBittorrentOnline.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageqBittorrentOnline.Size = new System.Drawing.Size(792, 424);
            this.tabPageqBittorrentOnline.TabIndex = 0;
            this.tabPageqBittorrentOnline.Text = "qBittorrent 在线";
            this.tabPageqBittorrentOnline.UseVisualStyleBackColor = true;
            // 
            // groupBoxOnlineOther
            // 
            this.groupBoxOnlineOther.Controls.Add(this.btnGetCategoryAllTorrentSavePath);
            this.groupBoxOnlineOther.Location = new System.Drawing.Point(284, 318);
            this.groupBoxOnlineOther.Name = "groupBoxOnlineOther";
            this.groupBoxOnlineOther.Size = new System.Drawing.Size(500, 98);
            this.groupBoxOnlineOther.TabIndex = 7;
            this.groupBoxOnlineOther.TabStop = false;
            this.groupBoxOnlineOther.Text = "其他";
            // 
            // btnGetCategoryAllTorrentSavePath
            // 
            this.btnGetCategoryAllTorrentSavePath.Location = new System.Drawing.Point(12, 20);
            this.btnGetCategoryAllTorrentSavePath.Name = "btnGetCategoryAllTorrentSavePath";
            this.btnGetCategoryAllTorrentSavePath.Size = new System.Drawing.Size(476, 23);
            this.btnGetCategoryAllTorrentSavePath.TabIndex = 5;
            this.btnGetCategoryAllTorrentSavePath.Text = "获取分类下所有种子保存路径";
            this.btnGetCategoryAllTorrentSavePath.UseVisualStyleBackColor = true;
            this.btnGetCategoryAllTorrentSavePath.Click += new System.EventHandler(this.BtnGetCategoryAllTorrentSavePath_Click);
            // 
            // groupBoxPathMap
            // 
            this.groupBoxPathMap.Controls.Add(this.rtbPathMap);
            this.groupBoxPathMap.Location = new System.Drawing.Point(8, 130);
            this.groupBoxPathMap.Name = "groupBoxPathMap";
            this.groupBoxPathMap.Size = new System.Drawing.Size(270, 286);
            this.groupBoxPathMap.TabIndex = 6;
            this.groupBoxPathMap.TabStop = false;
            this.groupBoxPathMap.Text = "路径映射（前为本机路径，后为远程路径）";
            // 
            // rtbPathMap
            // 
            this.rtbPathMap.DetectUrls = false;
            this.rtbPathMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbPathMap.Location = new System.Drawing.Point(3, 17);
            this.rtbPathMap.Name = "rtbPathMap";
            this.rtbPathMap.Size = new System.Drawing.Size(264, 266);
            this.rtbPathMap.TabIndex = 0;
            this.rtbPathMap.Text = "";
            // 
            // groupBoxAdd
            // 
            this.groupBoxAdd.Controls.Add(this.groupBoxQbtSysytem);
            this.groupBoxAdd.Controls.Add(this.cbSkipHashCheck);
            this.groupBoxAdd.Controls.Add(this.cbCategory);
            this.groupBoxAdd.Controls.Add(this.label3);
            this.groupBoxAdd.Controls.Add(this.cbStartTorrent);
            this.groupBoxAdd.Controls.Add(this.btnAddTorrent);
            this.groupBoxAdd.Controls.Add(this.groupBoxAddSaveFolder);
            this.groupBoxAdd.Controls.Add(this.groupBoxAddType);
            this.groupBoxAdd.Location = new System.Drawing.Point(284, 6);
            this.groupBoxAdd.Name = "groupBoxAdd";
            this.groupBoxAdd.Size = new System.Drawing.Size(500, 306);
            this.groupBoxAdd.TabIndex = 5;
            this.groupBoxAdd.TabStop = false;
            this.groupBoxAdd.Text = "添加种子";
            // 
            // groupBoxQbtSysytem
            // 
            this.groupBoxQbtSysytem.Controls.Add(this.rbLinux);
            this.groupBoxQbtSysytem.Controls.Add(this.rbWindows);
            this.groupBoxQbtSysytem.Location = new System.Drawing.Point(6, 16);
            this.groupBoxQbtSysytem.Name = "groupBoxQbtSysytem";
            this.groupBoxQbtSysytem.Size = new System.Drawing.Size(488, 48);
            this.groupBoxQbtSysytem.TabIndex = 9;
            this.groupBoxQbtSysytem.TabStop = false;
            this.groupBoxQbtSysytem.Text = "qBittorrent 所在系统（此项影响对路径的检测判断）";
            // 
            // rbLinux
            // 
            this.rbLinux.AutoSize = true;
            this.rbLinux.Location = new System.Drawing.Point(252, 20);
            this.rbLinux.Name = "rbLinux";
            this.rbLinux.Size = new System.Drawing.Size(185, 16);
            this.rbLinux.TabIndex = 2;
            this.rbLinux.Text = "Linux（路径类似 /mnt/test）";
            this.rbLinux.UseVisualStyleBackColor = true;
            // 
            // rbWindows
            // 
            this.rbWindows.AutoSize = true;
            this.rbWindows.Checked = true;
            this.rbWindows.Location = new System.Drawing.Point(6, 20);
            this.rbWindows.Name = "rbWindows";
            this.rbWindows.Size = new System.Drawing.Size(185, 16);
            this.rbWindows.TabIndex = 0;
            this.rbWindows.TabStop = true;
            this.rbWindows.Text = "Windows（路径类似 C:\\test）";
            this.rbWindows.UseVisualStyleBackColor = true;
            // 
            // cbSkipHashCheck
            // 
            this.cbSkipHashCheck.AutoSize = true;
            this.cbSkipHashCheck.Location = new System.Drawing.Point(12, 224);
            this.cbSkipHashCheck.Name = "cbSkipHashCheck";
            this.cbSkipHashCheck.Size = new System.Drawing.Size(294, 16);
            this.cbSkipHashCheck.TabIndex = 8;
            this.cbSkipHashCheck.Text = "Skip Hask Check（Checked Only On File Exist）";
            this.cbSkipHashCheck.UseVisualStyleBackColor = true;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(72, 246);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(416, 20);
            this.cbCategory.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Category: ";
            // 
            // cbStartTorrent
            // 
            this.cbStartTorrent.AutoSize = true;
            this.cbStartTorrent.Location = new System.Drawing.Point(386, 224);
            this.cbStartTorrent.Name = "cbStartTorrent";
            this.cbStartTorrent.Size = new System.Drawing.Size(102, 16);
            this.cbStartTorrent.TabIndex = 5;
            this.cbStartTorrent.Text = "Start Torrent";
            this.cbStartTorrent.UseVisualStyleBackColor = true;
            // 
            // btnAddTorrent
            // 
            this.btnAddTorrent.Location = new System.Drawing.Point(12, 272);
            this.btnAddTorrent.Name = "btnAddTorrent";
            this.btnAddTorrent.Size = new System.Drawing.Size(476, 23);
            this.btnAddTorrent.TabIndex = 4;
            this.btnAddTorrent.Text = "添加种子";
            this.btnAddTorrent.UseVisualStyleBackColor = true;
            this.btnAddTorrent.Click += new System.EventHandler(this.BtnAddTorrent_Click);
            // 
            // groupBoxAddSaveFolder
            // 
            this.groupBoxAddSaveFolder.Controls.Add(this.cbPathMap);
            this.groupBoxAddSaveFolder.Controls.Add(this.cbSettingSaveFolder);
            this.groupBoxAddSaveFolder.Controls.Add(this.cbSaveFolder);
            this.groupBoxAddSaveFolder.Controls.Add(this.cbSaveDisk);
            this.groupBoxAddSaveFolder.Location = new System.Drawing.Point(6, 121);
            this.groupBoxAddSaveFolder.Name = "groupBoxAddSaveFolder";
            this.groupBoxAddSaveFolder.Size = new System.Drawing.Size(488, 97);
            this.groupBoxAddSaveFolder.TabIndex = 1;
            this.groupBoxAddSaveFolder.TabStop = false;
            this.groupBoxAddSaveFolder.Text = "保存文件夹";
            // 
            // cbPathMap
            // 
            this.cbPathMap.AutoSize = true;
            this.cbPathMap.Location = new System.Drawing.Point(6, 46);
            this.cbPathMap.Name = "cbPathMap";
            this.cbPathMap.Size = new System.Drawing.Size(252, 16);
            this.cbPathMap.TabIndex = 3;
            this.cbPathMap.Text = "磁盘映射（网络磁盘名映射为实际磁盘名）";
            this.cbPathMap.UseVisualStyleBackColor = true;
            // 
            // cbSettingSaveFolder
            // 
            this.cbSettingSaveFolder.Location = new System.Drawing.Point(6, 68);
            this.cbSettingSaveFolder.Name = "cbSettingSaveFolder";
            this.cbSettingSaveFolder.Size = new System.Drawing.Size(476, 20);
            this.cbSettingSaveFolder.TabIndex = 2;
            // 
            // cbSaveFolder
            // 
            this.cbSaveFolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSaveFolder.FormattingEnabled = true;
            this.cbSaveFolder.Location = new System.Drawing.Point(252, 20);
            this.cbSaveFolder.Name = "cbSaveFolder";
            this.cbSaveFolder.Size = new System.Drawing.Size(230, 20);
            this.cbSaveFolder.TabIndex = 1;
            // 
            // cbSaveDisk
            // 
            this.cbSaveDisk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSaveDisk.FormattingEnabled = true;
            this.cbSaveDisk.Location = new System.Drawing.Point(6, 20);
            this.cbSaveDisk.Name = "cbSaveDisk";
            this.cbSaveDisk.Size = new System.Drawing.Size(230, 20);
            this.cbSaveDisk.TabIndex = 0;
            // 
            // groupBoxAddType
            // 
            this.groupBoxAddType.Controls.Add(this.rbKeep);
            this.groupBoxAddType.Controls.Add(this.rbManual);
            this.groupBoxAddType.Controls.Add(this.rbAddPrefixWithFileName);
            this.groupBoxAddType.Location = new System.Drawing.Point(6, 67);
            this.groupBoxAddType.Name = "groupBoxAddType";
            this.groupBoxAddType.Size = new System.Drawing.Size(488, 48);
            this.groupBoxAddType.TabIndex = 0;
            this.groupBoxAddType.TabStop = false;
            this.groupBoxAddType.Text = "方式";
            // 
            // rbKeep
            // 
            this.rbKeep.AutoSize = true;
            this.rbKeep.Location = new System.Drawing.Point(165, 20);
            this.rbKeep.Name = "rbKeep";
            this.rbKeep.Size = new System.Drawing.Size(47, 16);
            this.rbKeep.TabIndex = 2;
            this.rbKeep.Text = "保持";
            this.rbKeep.UseVisualStyleBackColor = true;
            // 
            // rbManual
            // 
            this.rbManual.AutoSize = true;
            this.rbManual.Location = new System.Drawing.Point(252, 20);
            this.rbManual.Name = "rbManual";
            this.rbManual.Size = new System.Drawing.Size(47, 16);
            this.rbManual.TabIndex = 1;
            this.rbManual.Text = "手动";
            this.rbManual.UseVisualStyleBackColor = true;
            // 
            // rbAddPrefixWithFileName
            // 
            this.rbAddPrefixWithFileName.AutoSize = true;
            this.rbAddPrefixWithFileName.Checked = true;
            this.rbAddPrefixWithFileName.Location = new System.Drawing.Point(6, 20);
            this.rbAddPrefixWithFileName.Name = "rbAddPrefixWithFileName";
            this.rbAddPrefixWithFileName.Size = new System.Drawing.Size(119, 16);
            this.rbAddPrefixWithFileName.TabIndex = 0;
            this.rbAddPrefixWithFileName.TabStop = true;
            this.rbAddPrefixWithFileName.Text = "添加文件名作前缀";
            this.rbAddPrefixWithFileName.UseVisualStyleBackColor = true;
            // 
            // groupBoxLogin
            // 
            this.groupBoxLogin.Controls.Add(this.cbKeepConnectSetting);
            this.groupBoxLogin.Controls.Add(this.cbUrl);
            this.groupBoxLogin.Controls.Add(this.btnLogin);
            this.groupBoxLogin.Controls.Add(this.tbUser);
            this.groupBoxLogin.Controls.Add(this.tbPassword);
            this.groupBoxLogin.Location = new System.Drawing.Point(8, 6);
            this.groupBoxLogin.Name = "groupBoxLogin";
            this.groupBoxLogin.Size = new System.Drawing.Size(270, 118);
            this.groupBoxLogin.TabIndex = 4;
            this.groupBoxLogin.TabStop = false;
            this.groupBoxLogin.Text = "登陆";
            // 
            // cbKeepConnectSetting
            // 
            this.cbKeepConnectSetting.AutoSize = true;
            this.cbKeepConnectSetting.Checked = true;
            this.cbKeepConnectSetting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbKeepConnectSetting.Location = new System.Drawing.Point(8, 95);
            this.cbKeepConnectSetting.Name = "cbKeepConnectSetting";
            this.cbKeepConnectSetting.Size = new System.Drawing.Size(96, 16);
            this.cbKeepConnectSetting.TabIndex = 6;
            this.cbKeepConnectSetting.Text = "保存连接设置";
            this.cbKeepConnectSetting.UseVisualStyleBackColor = true;
            // 
            // tabPageqBittorrentOffline
            // 
            this.tabPageqBittorrentOffline.Controls.Add(this.groupBoxOfflineOther);
            this.tabPageqBittorrentOffline.Controls.Add(this.groupBoxTrackers);
            this.tabPageqBittorrentOffline.Controls.Add(this.groupBoxModifyDisk);
            this.tabPageqBittorrentOffline.Location = new System.Drawing.Point(4, 22);
            this.tabPageqBittorrentOffline.Name = "tabPageqBittorrentOffline";
            this.tabPageqBittorrentOffline.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageqBittorrentOffline.Size = new System.Drawing.Size(792, 424);
            this.tabPageqBittorrentOffline.TabIndex = 1;
            this.tabPageqBittorrentOffline.Text = "qBittorrent 离线";
            this.tabPageqBittorrentOffline.UseVisualStyleBackColor = true;
            // 
            // groupBoxOfflineOther
            // 
            this.groupBoxOfflineOther.Controls.Add(this.btnRemoveNotExistDataFileTorrent);
            this.groupBoxOfflineOther.Controls.Add(this.buttonOther);
            this.groupBoxOfflineOther.Location = new System.Drawing.Point(180, 159);
            this.groupBoxOfflineOther.Name = "groupBoxOfflineOther";
            this.groupBoxOfflineOther.Size = new System.Drawing.Size(300, 107);
            this.groupBoxOfflineOther.TabIndex = 3;
            this.groupBoxOfflineOther.TabStop = false;
            this.groupBoxOfflineOther.Text = "其他";
            // 
            // btnRemoveNotExistDataFileTorrent
            // 
            this.btnRemoveNotExistDataFileTorrent.Location = new System.Drawing.Point(6, 19);
            this.btnRemoveNotExistDataFileTorrent.Name = "btnRemoveNotExistDataFileTorrent";
            this.btnRemoveNotExistDataFileTorrent.Size = new System.Drawing.Size(288, 23);
            this.btnRemoveNotExistDataFileTorrent.TabIndex = 0;
            this.btnRemoveNotExistDataFileTorrent.Text = "移除实际数据不存在的种子";
            this.btnRemoveNotExistDataFileTorrent.UseVisualStyleBackColor = true;
            this.btnRemoveNotExistDataFileTorrent.Click += new System.EventHandler(this.BtnRemoveNotExistDataFileTorrent_Click);
            // 
            // buttonOther
            // 
            this.buttonOther.Location = new System.Drawing.Point(6, 72);
            this.buttonOther.Name = "buttonOther";
            this.buttonOther.Size = new System.Drawing.Size(288, 23);
            this.buttonOther.TabIndex = 0;
            this.buttonOther.Text = "其他";
            this.buttonOther.UseVisualStyleBackColor = true;
            this.buttonOther.Click += new System.EventHandler(this.ButtonOther_Click);
            // 
            // groupBoxTrackers
            // 
            this.groupBoxTrackers.Controls.Add(this.cbFindCategory);
            this.groupBoxTrackers.Controls.Add(this.label2);
            this.groupBoxTrackers.Controls.Add(this.btnTrackerFindAndReplace);
            this.groupBoxTrackers.Controls.Add(this.cbTrackerReplace);
            this.groupBoxTrackers.Controls.Add(this.cbTrackerFind);
            this.groupBoxTrackers.Location = new System.Drawing.Point(8, 6);
            this.groupBoxTrackers.Name = "groupBoxTrackers";
            this.groupBoxTrackers.Size = new System.Drawing.Size(472, 138);
            this.groupBoxTrackers.TabIndex = 2;
            this.groupBoxTrackers.TabStop = false;
            this.groupBoxTrackers.Text = "Trackers 查找与替换";
            // 
            // cbFindCategory
            // 
            this.cbFindCategory.Location = new System.Drawing.Point(101, 74);
            this.cbFindCategory.Name = "cbFindCategory";
            this.cbFindCategory.Size = new System.Drawing.Size(365, 20);
            this.cbFindCategory.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "只修改特定分类";
            // 
            // btnTrackerFindAndReplace
            // 
            this.btnTrackerFindAndReplace.Location = new System.Drawing.Point(6, 102);
            this.btnTrackerFindAndReplace.Name = "btnTrackerFindAndReplace";
            this.btnTrackerFindAndReplace.Size = new System.Drawing.Size(460, 23);
            this.btnTrackerFindAndReplace.TabIndex = 2;
            this.btnTrackerFindAndReplace.Text = "Trackers 查找与替换";
            this.btnTrackerFindAndReplace.UseVisualStyleBackColor = true;
            this.btnTrackerFindAndReplace.Click += new System.EventHandler(this.BtnTrackerFindAndReplace_Click);
            // 
            // cbTrackerReplace
            // 
            this.cbTrackerReplace.FormattingEnabled = true;
            this.cbTrackerReplace.Items.AddRange(new object[] {
            "https://"});
            this.cbTrackerReplace.Location = new System.Drawing.Point(6, 47);
            this.cbTrackerReplace.Name = "cbTrackerReplace";
            this.cbTrackerReplace.Size = new System.Drawing.Size(460, 20);
            this.cbTrackerReplace.TabIndex = 1;
            // 
            // cbTrackerFind
            // 
            this.cbTrackerFind.FormattingEnabled = true;
            this.cbTrackerFind.Items.AddRange(new object[] {
            "http://"});
            this.cbTrackerFind.Location = new System.Drawing.Point(6, 20);
            this.cbTrackerFind.Name = "cbTrackerFind";
            this.cbTrackerFind.Size = new System.Drawing.Size(460, 20);
            this.cbTrackerFind.TabIndex = 0;
            // 
            // groupBoxModifyDisk
            // 
            this.groupBoxModifyDisk.Controls.Add(this.cbTorrentNeverStart);
            this.groupBoxModifyDisk.Controls.Add(this.label1);
            this.groupBoxModifyDisk.Controls.Add(this.btnDiskChange);
            this.groupBoxModifyDisk.Controls.Add(this.cbDiskTo);
            this.groupBoxModifyDisk.Controls.Add(this.cbDiskFrom);
            this.groupBoxModifyDisk.Location = new System.Drawing.Point(8, 159);
            this.groupBoxModifyDisk.Name = "groupBoxModifyDisk";
            this.groupBoxModifyDisk.Size = new System.Drawing.Size(166, 107);
            this.groupBoxModifyDisk.TabIndex = 1;
            this.groupBoxModifyDisk.TabStop = false;
            this.groupBoxModifyDisk.Text = "修改磁盘名";
            // 
            // cbTorrentNeverStart
            // 
            this.cbTorrentNeverStart.AutoSize = true;
            this.cbTorrentNeverStart.Checked = true;
            this.cbTorrentNeverStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTorrentNeverStart.Location = new System.Drawing.Point(6, 48);
            this.cbTorrentNeverStart.Name = "cbTorrentNeverStart";
            this.cbTorrentNeverStart.Size = new System.Drawing.Size(144, 16);
            this.cbTorrentNeverStart.TabIndex = 4;
            this.cbTorrentNeverStart.Text = "只修改从未开始的种子";
            this.cbTorrentNeverStart.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "to";
            // 
            // btnDiskChange
            // 
            this.btnDiskChange.Location = new System.Drawing.Point(6, 72);
            this.btnDiskChange.Name = "btnDiskChange";
            this.btnDiskChange.Size = new System.Drawing.Size(152, 23);
            this.btnDiskChange.TabIndex = 2;
            this.btnDiskChange.Text = "修改磁盘名";
            this.btnDiskChange.UseVisualStyleBackColor = true;
            this.btnDiskChange.Click += new System.EventHandler(this.BtnDiskChange_Click);
            // 
            // cbDiskTo
            // 
            this.cbDiskTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDiskTo.FormattingEnabled = true;
            this.cbDiskTo.Location = new System.Drawing.Point(98, 20);
            this.cbDiskTo.Name = "cbDiskTo";
            this.cbDiskTo.Size = new System.Drawing.Size(60, 20);
            this.cbDiskTo.TabIndex = 1;
            // 
            // cbDiskFrom
            // 
            this.cbDiskFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDiskFrom.FormattingEnabled = true;
            this.cbDiskFrom.Location = new System.Drawing.Point(6, 20);
            this.cbDiskFrom.Name = "cbDiskFrom";
            this.cbDiskFrom.Size = new System.Drawing.Size(60, 20);
            this.cbDiskFrom.TabIndex = 0;
            // 
            // tabPageµTorrentOffline
            // 
            this.tabPageµTorrentOffline.Location = new System.Drawing.Point(4, 22);
            this.tabPageµTorrentOffline.Name = "tabPageµTorrentOffline";
            this.tabPageµTorrentOffline.Size = new System.Drawing.Size(792, 424);
            this.tabPageµTorrentOffline.TabIndex = 2;
            this.tabPageµTorrentOffline.Text = "µTorrent 离线";
            this.tabPageµTorrentOffline.UseVisualStyleBackColor = true;
            // 
            // WinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "WinForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WinForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WinForm_FormClosed);
            this.Load += new System.EventHandler(this.WinForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPageqBittorrentOnline.ResumeLayout(false);
            this.groupBoxOnlineOther.ResumeLayout(false);
            this.groupBoxPathMap.ResumeLayout(false);
            this.groupBoxAdd.ResumeLayout(false);
            this.groupBoxAdd.PerformLayout();
            this.groupBoxQbtSysytem.ResumeLayout(false);
            this.groupBoxQbtSysytem.PerformLayout();
            this.groupBoxAddSaveFolder.ResumeLayout(false);
            this.groupBoxAddSaveFolder.PerformLayout();
            this.groupBoxAddType.ResumeLayout(false);
            this.groupBoxAddType.PerformLayout();
            this.groupBoxLogin.ResumeLayout(false);
            this.groupBoxLogin.PerformLayout();
            this.tabPageqBittorrentOffline.ResumeLayout(false);
            this.groupBoxOfflineOther.ResumeLayout(false);
            this.groupBoxTrackers.ResumeLayout(false);
            this.groupBoxTrackers.PerformLayout();
            this.groupBoxModifyDisk.ResumeLayout(false);
            this.groupBoxModifyDisk.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbUrl;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageqBittorrentOnline;
        private System.Windows.Forms.TabPage tabPageqBittorrentOffline;
        private System.Windows.Forms.GroupBox groupBoxAdd;
        private System.Windows.Forms.GroupBox groupBoxAddSaveFolder;
        private System.Windows.Forms.ComboBox cbSaveFolder;
        private System.Windows.Forms.ComboBox cbSaveDisk;
        private System.Windows.Forms.GroupBox groupBoxAddType;
        private System.Windows.Forms.RadioButton rbKeep;
        private System.Windows.Forms.RadioButton rbManual;
        private System.Windows.Forms.RadioButton rbAddPrefixWithFileName;
        private System.Windows.Forms.GroupBox groupBoxLogin;
        private System.Windows.Forms.Button btnAddTorrent;
        private System.Windows.Forms.ComboBox cbSettingSaveFolder;
        private System.Windows.Forms.GroupBox groupBoxModifyDisk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDiskChange;
        private System.Windows.Forms.ComboBox cbDiskTo;
        private System.Windows.Forms.ComboBox cbDiskFrom;
        private System.Windows.Forms.Button btnRemoveNotExistDataFileTorrent;
        private System.Windows.Forms.GroupBox groupBoxOfflineOther;
        private System.Windows.Forms.GroupBox groupBoxTrackers;
        private System.Windows.Forms.Button btnTrackerFindAndReplace;
        private System.Windows.Forms.ComboBox cbTrackerReplace;
        private System.Windows.Forms.ComboBox cbTrackerFind;
        private System.Windows.Forms.GroupBox groupBoxPathMap;
        private System.Windows.Forms.RichTextBox rtbPathMap;
        private System.Windows.Forms.CheckBox cbPathMap;
        private System.Windows.Forms.CheckBox cbTorrentNeverStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFindCategory;
        private System.Windows.Forms.CheckBox cbStartTorrent;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbKeepConnectSetting;
        private System.Windows.Forms.CheckBox cbSkipHashCheck;
        private System.Windows.Forms.Button buttonOther;
        private System.Windows.Forms.TabPage tabPageµTorrentOffline;
        private System.Windows.Forms.GroupBox groupBoxOnlineOther;
        private System.Windows.Forms.Button btnGetCategoryAllTorrentSavePath;
        private System.Windows.Forms.GroupBox groupBoxQbtSysytem;
        private System.Windows.Forms.RadioButton rbLinux;
        private System.Windows.Forms.RadioButton rbWindows;
    }
}

