using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BencodeNET.Objects;
using BencodeNET.Parsing;
using System.IO;

namespace MyQbt
{
    public partial class µTorrentOfflineUserControl : UserControl
    {
        private BDictionary utBDictionary = null;

        private static string DefaultDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "uTorrent");

        public µTorrentOfflineUserControl()
        {
            InitializeComponent();
        }

        private void ΜTorrentOfflineUserControl_Load(object sender, EventArgs e)
        {
            this.groupBoxAction.Enabled = false;
        }

        private void BtnLoadResumeData_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = DefaultDirectory;
            dlg.RestoreDirectory = true;
            dlg.Filter = "dat文件|*.dat";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var parser = new BencodeParser();
                utBDictionary = parser.Parse<BDictionary>(dlg.FileName);

                if (utBDictionary != null)
                {
                    this.groupBoxAction.Enabled = true;
                    MessageBox.Show(string.Format("已加载 {0}", dlg.FileName));
                }
            }
        }

        private void BtnSaveResumeData_Click(object sender, EventArgs e)
        {
            if (utBDictionary == null)
            {
                MessageBox.Show("请先加载 resume.data 文件！");
                return;
            }

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.InitialDirectory = DefaultDirectory;
            dlg.RestoreDirectory = true;
            dlg.Filter = "dat文件|*.dat";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(
                    dlg.FileName, FileMode.Create))
                {
                    byte[] bytes = utBDictionary.EncodeAsBytes();
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Flush();

                    MessageBox.Show(string.Format("已保存为 {0}", dlg.FileName));
                }
            }
        }

        public bool CheckNeedSaveWhenFormClosing()
        {
            if (utBDictionary == null) return false;
            else
            {
                DialogResult dr = MessageBox.Show(
                    "关闭前请确保已保存修改过的 resume.dat，确实要关闭吗？",
                    "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (DialogResult.Yes == dr) return false;
                else return true;
            }
        }

        private void BtnRemoveInvalidTorrentInfo_Click(object sender, EventArgs e)
        {
            if (utBDictionary == null)
            {
                MessageBox.Show("请先加载 resume.data 文件！");
                return;
            }

            BString bpath = new BString("path");
            BString blabel = new BString("label");
            BString bcompleded = new BString("completed_on");

            // 待删列表
            List<BString> deleteList = new List<BString>();

            foreach (KeyValuePair<BString, IBObject> kv in utBDictionary)
            {
                if (kv.Key.ToString().ToLower().EndsWith(".torrent"))
                {
                    var tbd = kv.Value as BDictionary;

                    if (tbd[blabel].ToString() == "GGN") continue;

                    string tpath = tbd[bpath].ToString();

                    if (tbd[bcompleded].ToString() != "0")
                    {
                        if (!(Directory.Exists(tpath) || File.Exists(tpath)))
                        {
                            deleteList.Add(kv.Key);
                        }
                    }
                }
            }

            foreach (BString bKey in deleteList) utBDictionary.Remove(bKey);

            MessageBox.Show(string.Format(
                "完成，共删除{0}项", deleteList.Count),
                "提示", MessageBoxButtons.OK);
        }

        private void BtnRemoveTorrent_Click(object sender, EventArgs e)
        {
            if (utBDictionary == null)
            {
                MessageBox.Show("请先加载 resume.data 文件！");
                return;
            }

            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = DefaultDirectory;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string strSelectFolder = dlg.SelectedPath;
                List<string> torrentNameList = new List<string>();

                foreach (KeyValuePair<BString, IBObject> kv in utBDictionary)
                {
                    string tName = kv.Key.ToString();
                    if (tName.ToLower().EndsWith(".torrent"))
                    {
                        torrentNameList.Add(tName);
                    }
                }

                string[] torrentList = Directory.GetFiles(
                    strSelectFolder, "*.torrent", SearchOption.TopDirectoryOnly);

                string newFolder = Path.Combine(Environment.CurrentDirectory,
                    string.Format("T-{0}", DateTime.Now.ToString("yyyy-MM-dd")));
                if (!Directory.Exists(newFolder)) Directory.CreateDirectory(newFolder);

                foreach (string torrentPath in torrentList)
                {
                    string torrentName = torrentPath.Substring(torrentPath.LastIndexOf('\\') + 1);
                    if (!torrentNameList.Contains(torrentName))
                    {
                        string newPath = Path.Combine(newFolder, torrentName);
                        File.Move(torrentPath, newPath);
                    }
                }

                MessageBox.Show("完成", "提示", MessageBoxButtons.OK);
            }
        }
    }
}
