using musicAdmin.Controllers;
using musicAdmin.Forms;
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

namespace musicAdmin
{
    public partial class Inicio : Form
    {
        MusicaController mc = new MusicaController();
        ArchivoController ac = new ArchivoController();
        MediaPlayerController mpc = new MediaPlayerController();
        List<Musica> musica = new List<Musica>();
        int defaultUsb = -1;

        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            musica = mc.GetTodasEnMyMusic();
            dgvMusica.DataSource = musica;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            dgvMusica.Focus();
            mpc.Play(musica[dgvMusica.CurrentCell.RowIndex].FullPath);
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            dgvMusica.Focus();
            mpc.Stop();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            List<USB> usbs = ac.GetUSBConectados();
            // chequeo si hay usbs conectados
            if (usbs.Count == 0)
            {
                MessageBox.Show("No se han encontrado USB conectados. Pruebe re-conectarlos si ya lo hizo.");
            } 
            // hay un solo usb o tengo un por default, copio a ese 
            else if (usbs.Count == 1 || defaultUsb != -1)
            {
                if (ac.Copiar(musica[dgvMusica.CurrentCell.RowIndex], usbs[0].Ruta))
                {
                    MessageBox.Show("¡Copia exitosa!");
                }
                else
                {
                    MessageBox.Show("¡Copia falló!");
                }
            }
            // hay mas de uno, tengo que consultar a cual quiero copiar
            else
            {
                MessageBox.Show("Se ha encontrado más de un pendrive conectado, por favor seleccione a cual desea copiar");
                SeleccionUSB formUSB = new SeleccionUSB();
                formUSB.CargarUSBs(usbs);
                formUSB.Show();
                this.Hide();
            }
            dgvMusica.Focus();

        }
        public void SeleccionUSBBack(int index)
        {
            defaultUsb = index;
        }

        private void dgvMusica_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // FIXME
            // agregar logica para editar informacion de la cancion
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            YouTubeDownloader form = new YouTubeDownloader();
            form.Show();
            this.Hide();
        }
    }
}
