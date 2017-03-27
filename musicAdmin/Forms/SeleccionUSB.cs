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
        public SeleccionUSB()
        {
            InitializeComponent();
        }
        public void CargarUSBs(List<USB> usbs)
        {
            List<string> usbStrings = new List<string>();
            foreach (var usb in usbs)
            {
                usbStrings.Add(usb.Etiqueta + " (" + usb.Ruta + ")");
            }
            cboUSB.DataSource = usbStrings;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Inicio index = new Inicio();
            this.Close();
            index.SeleccionUSBBack(cboUSB.SelectedIndex);
            index.Show();
        }
    }
}
