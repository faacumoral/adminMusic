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
        public YouTubeDownloader()
        {
            InitializeComponent();
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            // FIXME ver donde guardar archivo descargar, manejar con property
            // FIXME ver porque no anda video downloader
            string video = YoutubeController.GetAudioFromVideo(txtLink.Text, @"C:\Users\FacundoMoral\Downloads");
            MessageBox.Show(video);
        }
    }
}
