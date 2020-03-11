using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyQbt
{
    public partial class AddTorrentManual : Form
    {
        public Action<bool, string> UpdataResultAndReason;
        private bool isAddTorrentSuccess;
        private string failedReason;

        private string torrentPath;
        private string settingSaveFolder;
        private string defaultCategory;

        private bool isWindowsPath;
        private Dictionary<string, string> actualToVirtualDic = null;

        private BencodeNET.Torrents.Torrent bencodeTorrent = null;

        private List<string> trackerList;
        private DataNode rootNode;
        private List<DataNode> listViewNodeList;

        private const TextFormatFlags ftff =
            TextFormatFlags.VerticalCenter |
            TextFormatFlags.WordEllipsis |
            TextFormatFlags.EndEllipsis |
            TextFormatFlags.SingleLine;
        private const TextFormatFlags stff =
            TextFormatFlags.VerticalCenter |
            TextFormatFlags.WordEllipsis |
            TextFormatFlags.Right |
            TextFormatFlags.SingleLine |
            TextFormatFlags.EndEllipsis;
        private Rectangle rect;
        private SolidBrush brush = new SolidBrush(Color.FromArgb(0, 120, 215));

        public class DataNode
        {
            public string Name;
            public long Size;
            public int Layer;
            public bool IsFolder;
            public bool IsExpand;
            public List<DataNode> chileNodeList;

            public DataNode(string name, long size, int layer,
                bool isFolder, bool isExpand)
            {
                Name = name;
                Size = size;
                Layer = layer;
                IsFolder = isFolder;
                IsExpand = isExpand;
            }

            public DataNode FindChildFolderNode(string folderName)
            {
                if ((!IsFolder) || chileNodeList == null) return null;
                else
                {
                    foreach (DataNode dataNode in chileNodeList)
                    {
                        if (dataNode.IsFolder && dataNode.Name == folderName)
                            return dataNode;
                    }
                    return null;
                }
            }
        }

        public static DataNode CreateDataNode(
            BencodeNET.Torrents.Torrent torrent)
        {
            if (torrent.FileMode == BencodeNET.Torrents.TorrentFileMode.Unknown)
                return null;

            DataNode dataNode = new DataNode("", 0, 0, true, true);
            if (torrent.FileMode == BencodeNET.Torrents.TorrentFileMode.Single)
            {
                dataNode.Size += torrent.File.FileSize;
                dataNode.chileNodeList = new List<DataNode>() {
                    new DataNode(torrent.File.FileName,
                    torrent.File.FileSize, 1, false, false) };
                return dataNode;
            }

            foreach (BencodeNET.Torrents.MultiFileInfo multiFileInfo in torrent.Files)
            {
                DataNode fup = dataNode;
                fup.Size += multiFileInfo.FileSize;

                for (int i = 0; i < multiFileInfo.Path.Count - 1; i++)
                {
                    if (fup.chileNodeList == null)
                    {
                        fup.chileNodeList = new List<DataNode>();
                    }

                    DataNode fcu = fup.FindChildFolderNode(multiFileInfo.Path[i]);
                    if (fcu != null)
                    {
                        fcu.Size += multiFileInfo.FileSize;
                    }
                    else
                    {
                        fcu = new DataNode(multiFileInfo.Path[i],
                            multiFileInfo.FileSize, i + 1, true, false);
                        fup.chileNodeList.Add(fcu);
                    }
                    fup = fcu;
                }

                if (fup.chileNodeList == null)
                {
                    fup.chileNodeList = new List<DataNode>();
                }

                fup.chileNodeList.Add(new DataNode(
                    multiFileInfo.FileName,
                    multiFileInfo.FileSize,
                    multiFileInfo.Path.Count,
                    false, false));
            }

            return dataNode;
        }

        public static void GenerateListViewDataFromDataNode(
            DataNode dataNode, ref List<DataNode> nodeList)
        {
            if (dataNode.chileNodeList != null)
            {
                foreach (DataNode childNode in dataNode.chileNodeList)
                {
                    if (childNode.IsFolder)
                    {
                        nodeList.Add(childNode);
                        if (childNode.IsExpand)
                        {
                            GenerateListViewDataFromDataNode(childNode, ref nodeList);
                        }
                    }
                }

                foreach (DataNode childNode in dataNode.chileNodeList)
                {
                    if (!childNode.IsFolder)
                    {
                        nodeList.Add(childNode);
                    }
                }
            }
        }

        public AddTorrentManual(
            string torrentPath,
            BencodeNET.Torrents.Torrent bencodeTorrent,
            string settingSaveFolder,
            bool skipHashCheck,
            bool startTorrent,
            string category,
            bool isWindowsPath,
            Dictionary<string, string> actualToVirtualDic = null)
        {
            InitializeComponent();

            this.isAddTorrentSuccess = false;
            this.failedReason = "程序错误";

            this.torrentPath = torrentPath;
            this.bencodeTorrent = bencodeTorrent;
            this.settingSaveFolder = settingSaveFolder;
            this.cbSkipHashCheck.Checked = skipHashCheck;
            this.cbStartTorrent.Checked = startTorrent;
            this.defaultCategory = category;
            this.isWindowsPath = isWindowsPath;
            this.actualToVirtualDic = actualToVirtualDic;
        }

        private async void AddTorrentManual_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.icon;

            this.cbCategory.SuspendLayout();
            this.cbCategory.Items.Clear();
            this.cbCategory.Items.AddRange(
                (await QbtWebAPI.API.GetAllCategoryString()).ToArray());
            this.cbCategory.Text = this.defaultCategory;
            this.cbCategory.ResumeLayout();

            this.trackerList = new List<string>();
            Array.ForEach<IList<string>>(
                bencodeTorrent.Trackers.ToArray(),
                x => this.trackerList.AddRange(x));

            if (bencodeTorrent.FileMode == BencodeNET.Torrents.TorrentFileMode.Single)
            {
                this.tbSaveFolder.Text = Path.Combine(
                    this.settingSaveFolder,
                    Path.GetFileNameWithoutExtension(bencodeTorrent.DisplayName));
            }
            else
            {
                this.tbSaveFolder.Text = Path.Combine(
                    this.settingSaveFolder, bencodeTorrent.DisplayName);
            }
            this.labelName.Text = bencodeTorrent.DisplayName;
            this.labelComment.Text = bencodeTorrent.Comment;
            this.labelSize.Text = Helper.GetSizeString(bencodeTorrent.TotalSize);
            this.labelInfo.Text = string.Format(
                "Create Time: {0}, By: {1}, PieceSize: {2}, Private: {3}",
                (bencodeTorrent.CreationDate ?? DateTime.MinValue).ToString("yyyy-MM-dd HH:mm:ss"),
                bencodeTorrent.CreatedBy, Helper.GetSizeString(bencodeTorrent.PieceSize),
                bencodeTorrent.IsPrivate.ToString());

            this.rootNode = CreateDataNode(bencodeTorrent);
            this.listViewNodeList = new List<DataNode>();
            GenerateListViewDataFromDataNode(this.rootNode, ref this.listViewNodeList);

            PropertyInfo aProp = typeof(ListView).GetProperty(
                "DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
            aProp.SetValue(this.listView, true, null);
            this.listView.VirtualListSize = this.listViewNodeList.Count;
        }

        private async void BtnOK_Click(object sender, EventArgs e)
        {
            string s1 = this.tbSaveFolder.Text;
            if (!Helper.CheckPath(ref s1, this.isWindowsPath)) return;

            string s2 = Path.GetFileName(s1);

            try
            {
                if (this.cbSkipHashCheck.Checked)
                {
                    if (!Helper.CanSkipCheck(
                        this.bencodeTorrent,
                        Helper.GetVirtualPath(s1, this.actualToVirtualDic), false))
                    {
                        this.isAddTorrentSuccess = false;
                        this.failedReason = "跳过哈希检测失败";
                        return;
                    }
                }

                await QbtWebAPI.API.DownloadFromDisk(
                    new List<string>() { torrentPath },
                    s1, null,
                    string.IsNullOrWhiteSpace(this.cbCategory.Text) ?
                    null : this.cbCategory.Text,
                    this.cbSkipHashCheck.Checked, !this.cbStartTorrent.Checked,
                    false, s2, null, null, null, null);

                this.isAddTorrentSuccess = true;
                this.failedReason = "";
            }
            catch (Exception ex)
            {
                this.failedReason = ex.Message;
            }
            finally
            {
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.failedReason = "用户取消";

            this.Close();
        }

        private void BtnTrackers_Click(object sender, EventArgs e)
        {
            string info = string.Join("\r\n", this.trackerList);

            InfoForm form = new InfoForm("Trackers", info);
            form.ShowDialog();
        }

        private void ListView_DrawColumnHeader(
            object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void ListView_DrawSubItem(
            object sender, DrawListViewSubItemEventArgs e)
        {
            int xOffset = e.Item.IndentCount * 16 + 6;
            int xPos = e.Bounds.X + xOffset + 16;

            DataNode node = this.listViewNodeList[e.ItemIndex];

            if (e.ColumnIndex == 0)
            {
                rect.Height = 16;
                rect.Width = 16;
                rect.X = e.Bounds.X + xOffset;
                rect.Y = e.Bounds.Y;

                if (node.IsFolder)
                {
                    e.Graphics.DrawImage(
                        imageList.Images[node.IsExpand ? 1 : 0], rect);
                }
                else e.Graphics.DrawIcon(
                    IconReader.GetFileIcon(
                        node.Name, IconReader.IconSize.Small, false), rect);

                // set rectangle bounds for drawing of item/subitem text
                rect.Height = e.Bounds.Height;
                rect.Width = e.Bounds.Width - xPos;
                rect.X = xPos;
                rect.Y = e.Bounds.Y;

                // draw item/subitem text
                if ((e.ItemState & ListViewItemStates.Selected) != 0)
                {
                    rect.X += 2;
                    e.Graphics.FillRectangle(brush, rect);
                    rect.X -= 2;
                    // draw selected item's text
                    TextRenderer.DrawText(
                        e.Graphics, e.Item.Text, e.Item.Font,
                        rect, SystemColors.HighlightText, ftff);
                }
                else
                {
                    // draw unselected item's text
                    TextRenderer.DrawText(
                        e.Graphics, e.Item.Text, e.Item.Font,
                        rect, e.Item.ForeColor, ftff);
                }
            }
            else
            {
                if ((e.ItemState & ListViewItemStates.Selected) != 0)
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);

                    TextRenderer.DrawText(
                        e.Graphics, e.SubItem.Text, e.Item.Font,
                        e.Bounds, SystemColors.HighlightText, stff);
                }
                else
                {
                    TextRenderer.DrawText(
                        e.Graphics, e.SubItem.Text, e.Item.Font,
                        e.Bounds, e.Item.ForeColor, stff);
                }
            }
        }

        private void ListView_MouseClick(object sender, MouseEventArgs e)
        {
            ListView lv = (ListView)sender;
            ListViewItem lvi = lv.GetItemAt(e.X, e.Y);

            if (e.Button == MouseButtons.Left)
            {
                if (lvi != null)
                {
                    // hack to draw first column correctly
                    lv.RedrawItems(lvi.Index, lvi.Index, true);

                    DataNode node = this.listViewNodeList[lvi.Index];

                    int xfrom = lvi.IndentCount * 16 + 6;
                    int xto = xfrom + 16;

                    if ((e.X >= xfrom && e.X <= xto) || e.Clicks > 1)
                    {
                        if (node.IsFolder)
                        {
                            node.IsExpand = !node.IsExpand;
                            lvi.Checked = !lvi.Checked;

                            List<DataNode> nodeList = new List<DataNode>();
                            GenerateListViewDataFromDataNode(node, ref nodeList);

                            if (node.IsExpand)
                            {
                                this.listViewNodeList.InsertRange(lvi.Index + 1, nodeList);
                            }
                            else
                            {
                                this.listViewNodeList.RemoveRange(lvi.Index + 1, nodeList.Count);
                            }

                            this.listView.VirtualListSize = this.listViewNodeList.Count;
                        }
                    }
                }
            }

            lvi.Selected = true;
        }

        private void ListView_MouseDoubleClick(
            object sender, MouseEventArgs e)
        {
            ListView_MouseClick(sender, e);
        }

        private void ListView_RetrieveVirtualItem(
            object sender, RetrieveVirtualItemEventArgs e)
        {
            DataNode node = this.listViewNodeList[e.ItemIndex];

            ListViewItem lvi = new ListViewItem(node.Name);
            lvi.SubItems.Add(Helper.GetSizeString(node.Size));
            lvi.IndentCount = node.Layer - 1;

            e.Item = lvi;
        }

        private void SetAllChildNodeExpand(DataNode node, bool isExpand)
        {
            if (node.chileNodeList == null) return;

            foreach (DataNode childNode in node.chileNodeList)
            {
                if (childNode.IsFolder)
                {
                    childNode.IsExpand = isExpand;
                    SetAllChildNodeExpand(childNode, isExpand);
                }
            }
        }

        private void BtnExpandAll_Click(object sender, EventArgs e)
        {
            SetAllChildNodeExpand(this.rootNode, true);
            this.listViewNodeList.Clear();
            GenerateListViewDataFromDataNode(this.rootNode, ref this.listViewNodeList);
            this.listView.VirtualListSize = this.listViewNodeList.Count;
        }

        private void BtnCollapseAll_Click(object sender, EventArgs e)
        {
            SetAllChildNodeExpand(this.rootNode, false);
            this.listViewNodeList.Clear();
            GenerateListViewDataFromDataNode(this.rootNode, ref this.listViewNodeList);
            this.listView.VirtualListSize = this.listViewNodeList.Count;
        }

        private void AddTorrentManual_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.UpdataResultAndReason?.Invoke(
                this.isAddTorrentSuccess, this.failedReason);
        }
    }
}
