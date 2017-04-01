using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace musicAdmin.Forms
{
    public partial class Loading : Form
    {
        string labelMsg = null;
        public Loading(string msg)
        {
            // tengo que guardarlo en otra variable porque todavia no se renderizo el label
            labelMsg = msg;
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            label1.Text = labelMsg;
            this.Width = labelMsg.Length * 15;
        }

    }
}
