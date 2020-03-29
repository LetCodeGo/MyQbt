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
        public InfoForm(string title, string info, Form ownerForm)
        {
            InitializeComponent();

            if (ownerForm == null)
            {
                this.StartPosition = FormStartPosition.CenterParent;
            }
            else
            {
                this.StartPosition = FormStartPosition.Manual;
                Point topRight = Helper.GetFormRightTopLocation(ownerForm);
                this.Location = new Point(topRight.X - this.Width, topRight.Y);
            }

            this.Text = title;
            this.Icon = Properties.Resources.icon;
            this.richTextBox.Text = info;
        }
    }
}
