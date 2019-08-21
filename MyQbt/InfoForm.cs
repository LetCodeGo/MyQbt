using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyQbt
{
    public partial class InfoForm : Form
    {
        public InfoForm(string title, string info)
        {
            InitializeComponent();

            this.Text = title;
            this.Icon = Properties.Resources.icon;
            this.richTextBox.Text = info;
        }
    }
}
