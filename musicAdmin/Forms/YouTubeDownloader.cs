using musicAdmin.Controllers;
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
    public partial class YouTubeDownloader : Form
    {
        private static YouTubeDownloader form = null;

        public static void SetPBAValue(int value)
        {
            if (value < 0) 
            {
                // no deberir ocurrir pero mejor contemplarlo
                return;
            }
            if ((value + form.pbaDescarga.Value) > form.pbaDescarga.Maximum )
            {
                // si el nuevo value va a darme overflow, seteo maximo
                form.pbaDescarga.Value = form.pbaDescarga.Maximum;
            }
            else
            {
                // si no seteo ese valor
                form.pbaDescarga.Value = value;
            }
            
        }

        public YouTubeDownloader()
        {
            InitializeComponent();
            form = this;
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            // FIXME ver donde guardar archivo descargar, manejar con property
            string video = YoutubeController.GetAudioFromVideo(txtLink.Text, @"C:\Users\FacundoMoral\Downloads", this);
            if (video == null)
            {
                MessageBox.Show("¡La descarga ha fallado!");
            }
            else
            {
                // FIXME ver para ya pasar cancion al pendrive
                MessageBox.Show("¡La descarga ha finalzado! ¿Desea pasar el audio al pendrive contectado?");
            }
            
        }
        public void SetPBA(int newValue)
        {
            pbaDescarga.Value = newValue;
        }

    }
}
