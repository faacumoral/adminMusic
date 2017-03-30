using musicAdmin.Controllers;
using musicAdmin.Model;
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
    public partial class SeleccionUSB : Form
    {
        private List<USB> usbs = null;
        private ArchivoController ac = new ArchivoController();
        public SeleccionUSB()
        {
            InitializeComponent();
            usbs = ac.GetUSBConectados();
            cboUSB.DataSource = usbs;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Inicio index = new Inicio();
            this.Close();
            DataController.defaultUsb = cboUSB.SelectedItem;
            index.Show();
        }
    }
}
