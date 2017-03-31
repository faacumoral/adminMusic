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
    public partial class prueba : Form
    {
        public prueba(string msg)
        {
            InitializeComponent();
            MessageBox.Show(msg);
        }
    }
}
